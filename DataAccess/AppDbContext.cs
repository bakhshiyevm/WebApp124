using DataAccess.Entities;
using DataAccess.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }



		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}


		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{

		//          //testing load data from another class
		//          //InitialData.LoadInitialData(ref modelBuilder);
		//	base.OnModelCreating(modelBuilder);
		//}
	}
}
