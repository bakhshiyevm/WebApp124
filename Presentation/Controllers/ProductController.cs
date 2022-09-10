using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Presentation.Controllers
{
	//[Authorize]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}


		[HttpGet]
		[Route("Products")]
		public IActionResult Products(SortOrder  sortOrder, int page = 1, int pageSize = 15, string searchName = null)
		{

			#region initial data


			//_productService.Create(new DTO.ProductDTO
			//{
			//	Name = "Pulp Fiction",
			//	Price = 20,
			//	ImgPath = "~/img/pulp_fict.jpg",

			//}); ;


			//_productService.Create(new DTO.ProductDTO
			//{
			//	Name = "Pulp Fiction",
			//	Price = 20,
			//	ImgPath = "~/img/pulp_fict.jpg",

			//}); ;

			//_productService.Create(new DTO.ProductDTO
			//{
			//	Name = "Pulp Fiction",
			//	Price = 20,
			//	ImgPath = "~/img/pulp_fict.jpg",

			//}); ;


			//_productService.Create(new DTO.ProductDTO
			//{
			//	Name = "Pulp Fiction",
			//	Price = 20,
			//	ImgPath = "~/img/pulp_fict.jpg",

			//}); ;


			//_productService.Create(new DTO.ProductDTO
			//{
			//	Name = "Pulp Fiction",
			//	Price = 20,
			//	ImgPath = "~/img/pulp_fict.jpg",

			//}); ;
			#endregion

			IEnumerable<ProductDTO> prods;

			if (searchName != null)
			{
				prods = _productService.Get()
					.Where(p => p.Name.ToLower().Contains(searchName.ToLower()));
			}
			else
			{
				prods = _productService.Get();
			}

			ViewBag.NameSort = sortOrder == SortOrder.NameAsc ? SortOrder.NameDesc : SortOrder.NameAsc;
			ViewBag.PriceSort = sortOrder == SortOrder.PriceAsc ? SortOrder.PriceDesc : SortOrder.PriceAsc;

			prods = sortOrder switch
			{
				SortOrder.NameDesc => prods.OrderByDescending(s => s.Name),
				SortOrder.PriceAsc => prods.OrderBy(s => s.Price),
				SortOrder.PriceDesc => prods.OrderByDescending(s => s.Price),

				_ => prods.OrderBy(s => s.Name),
			};




			var allProductsCount = prods.Count();
			ViewBag.HasPrevious = true;
			ViewBag.HasNext = true;

			if (page * pageSize >= allProductsCount)
			{
				ViewBag.HasNext = false;
			}
			if (page <= 1)
			{
				ViewBag.HasPrevious = false;
			}


			var products = prods.
				Skip((page - 1) * pageSize).Take(pageSize).ToList();

			//var products = _productService.Get(page, pageSize);

			if (products.Count() == 0)
			{
				return NotFound();
			}
			var pagedRs = new PagedResponseDTO<ProductDTO>(page, pageSize, products);

			return View(pagedRs);
		}

		[HttpGet]
		[Route("Products/{id}")]
		public IActionResult GetProduct(int id) 
		{
			var prod = _productService.Get(id);
			return View(prod);
		}
	}
}
