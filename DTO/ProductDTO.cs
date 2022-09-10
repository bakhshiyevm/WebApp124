using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public enum SortOrder
	{
		NameAsc,
		NameDesc,
		PriceAsc,
		PriceDesc
	}

	public class ProductDTO 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Rating { get; set; }
		public double Price { get; set; }
		public string ImgPath { get; set; }
		public string Note { get; set; }
	}
}
