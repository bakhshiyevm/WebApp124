using Services.Abstract;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ProductService : BaseService<ProductDTO,Product, ProductDTO>, IProductService
    {
        public ProductService(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

            var opt = new DbContextOptionsBuilder<AppDbContext>();
            opt.UseSqlite("test");

        }

    }
}
