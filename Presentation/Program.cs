
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Services;
using Services.Abstract;
using Services.Config;
using Services.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opt =>
			opt.UseSqlite(builder.Configuration.GetConnectionString("Default"),
			x => x.MigrationsAssembly("DataAccess")
		  )
	  );


builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(opt =>
	{
		opt.LoginPath = "/SignIn";
		opt.Cookie.HttpOnly = true;
		opt.Cookie.Name = "AuthCookie";
		opt.Cookie.MaxAge = TimeSpan.FromSeconds(300);

		//opt.Events = new CookieAuthenticationEvents
		//{		
		//	OnRedirectToLogin = x =>
		//	{
		//		x.HttpContext.Response.StatusCode = 401;
		//		return Task.CompletedTask;
		//	}
		//};
	});


builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

var mapperConfig = new MapperConfiguration( mc=>
	mc.AddProfile(new MapperProfile())	
);

builder.Services.AddSingleton(mapperConfig.CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Main}/{action=Home}"
	);

app.Run();
