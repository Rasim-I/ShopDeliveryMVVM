using Shop;
using ShopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopLogic.Abstraction.IMappers;
using System.Threading.Tasks;

namespace ShopLogic.Implementation.Mappers
{
    public class OrderMapper : IMapper<Order, OrderModel>
    {
        IMapper<Place, PlaceModel> _placeMapper = new PlaceMapper();
        IMapper<Product, ProductModel> _productMapper = new ProductMapper();
        IMapper<Transport, TransportModel> _transportMapper = new TransportMapper();
        public OrderModel ToModel(Order entity)
        {
            return new OrderModel
            {
                Id = entity.Id,
                CustomerName = entity.Customer,
                OrderTime = entity.OrderTime,
                PlaceId = entity.PlaceId,
                place = _placeMapper.ToModel(entity.place),
                ProductId = entity.ProductId,
                product = _productMapper.ToModel(entity.product),
                TransportId = entity.TransportId,
                transport = _transportMapper.ToModel(entity.transport),
                EstOrdDeliveryTime = entity.EstOrdDeliveryTime,
                State = (Shop.Models.EnumSet.OrderState)entity.State

            };
        }

        public Order ToEntity(OrderModel model)
        {
            return new Order
            {
                Id = model.Id,
                Customer = model.CustomerName,
                OrderTime = model.OrderTime,
                PlaceId = model.PlaceId,
                ProductId = model.ProductId,
                TransportId = model.TransportId,
                EstOrdDeliveryTime = model.EstOrdDeliveryTime,
                State = (ShopData.Entities.Enums.OrderState)model.State
                
            };
        }
    }
}
