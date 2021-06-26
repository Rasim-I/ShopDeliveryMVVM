using Shop;
using Shop.Data;
using ShopData.Data.Repositories.IRepositories;
using ShopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DeliveryContext context) : base(context)
        {

        }



    }
}
