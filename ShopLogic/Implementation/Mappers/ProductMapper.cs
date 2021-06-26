using Shop;
using ShopData.Entities;
using ShopLogic.Abstraction.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shop.Models.EnumSet;

namespace ShopLogic.Implementation.Mappers
{
    public class ProductMapper : IMapper<Product, ProductModel>
    {
        public ProductModel ToModel(Product entity)
        {
           return new ProductModel
            {
                Id = entity.Id,
                name = entity.name,
                
                size = (Size)entity.size,
                Quantity = entity.Quantity,
                type = (Shop.Models.EnumSet.Type)entity.type, //-
                Weight = entity.Weight
            };
        }

        public Product ToEntity(ProductModel model)
        {
            //Console.WriteLine(model.Id + "----------------------------------------------------");
            return new Product
            {
                Id = model.Id,
                name = model.name,
                size = (ShopData.Entities.Enums.Size)model.size, //-
                type = (ShopData.Entities.Enums.Type)model.type, //-
                Quantity = model.Quantity,
                Weight = model.Weight
            };
        }
    }
}
