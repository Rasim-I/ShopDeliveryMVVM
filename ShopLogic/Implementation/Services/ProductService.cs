using Shop;
using Shop.Data;
using ShopData.Entities;
using ShopLogic.Abstraction.IMappers;
using ShopLogic.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Product, ProductModel> _productMapper;
        //private readonly TransportService _transportService;
        //private readonly ProductService _productService;

        public ProductService(IUnitOfWork unitOfWork, IMapper<Product, ProductModel> productMapper)
        {
            _unitOfWork = unitOfWork;
            _productMapper = productMapper;
        }


        public void UpdateProductQuantity(ProductModel product)
        {
            // if (product.Quantity > 0)
            // {
            Product productToChange = _unitOfWork.Products.Find(p => p.Id == product.Id).FirstOrDefault();
            productToChange.Quantity -= 1;
            _unitOfWork.Save();
                //UpdateProduct(product);
            //}
            //else
            //{
            //    DeleteProduct(product);
           // }
        }

        /*
        void UpdateProduct(ProductModel product)
        {
            Product productToChange = _unitOfWork.Products.Find(p => p.Id == product.Id).FirstOrDefault();
            productToChange.Quantity -= 1; // = _productMapper.ToEntity(product);
            //_unitOfWork.Products.Update(_productMapper.ToEntity(product));
            _unitOfWork.Save();
        } 

        void DeleteProduct(ProductModel product)
        {
            _unitOfWork.Products.Delete(_productMapper.ToEntity(product));
            _unitOfWork.Save();
        }

        */


        public ProductModel FindProduct(Guid ID)
        {
            return _productMapper.ToModel(_unitOfWork.Products.Get(ID));
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return _unitOfWork.Products.GetAll().Where(p => p.Quantity > 0).Select(_productMapper.ToModel);
        }

    }
}
