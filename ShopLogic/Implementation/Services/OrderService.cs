using Shop;
using Shop.Data;
using ShopData.Entities;
using ShopLogic.Abstraction.IMappers;
using ShopLogic.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopLogic.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Order, OrderModel> _orderMapper;
        private readonly ITransportService _transportService;
        private readonly IProductService _productService;

        public OrderService(IUnitOfWork unitOfWork, IMapper<Order, OrderModel> orderMapper, ITransportService transportService, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _orderMapper = orderMapper;
            _transportService = transportService;
            _productService = productService;
        }

        public IEnumerable<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = _unitOfWork.Orders.GetAll().Select(_orderMapper.ToModel).ToList();
            return orders;
        }

        public IEnumerable<OrderModel> OrdersWithReferences()
        {
            return _unitOfWork.Orders.OrdersWithReferences().Select(_orderMapper.ToModel);
        }


        public void MakeOrder(ProductModel product, PlaceModel place, string name, int delay)
        {

            TransportModel transport = _transportService.FindFreeTransport(product);
            OrderModel order = new OrderModel(name, transport, place, product);


            DateTime dateTimeWithDelay = order.EstOrdDeliveryTime + TimeSpan.FromHours(delay);  //
            order.EstOrdDeliveryTime = dateTimeWithDelay;                                       // // //


            _transportService.Transit(transport, order.EstOrdDeliveryTime - DateTime.Now);
            //Console.WriteLine(product.Id);
            //Console.WriteLine(product.name);
            _productService.UpdateProductQuantity(product);
            CreateOrder(order);
            OrderDelayTimer(order);

            //Console.WriteLine(product.Quantity);
        }


        private void CreateOrder(OrderModel order)
        {
            _unitOfWork.Orders.Create(_orderMapper.ToEntity(order));
            _unitOfWork.Save();
        }



        #region OrderDelay
        int delay = 3;

        void OrderDelayTimer(OrderModel order)
        {
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, order, 0, 2000);
        }


        void Count(object obj)
        {
            if (delay == 1)
            {
                OrderModel ord = obj as OrderModel;
                Order orderToChange = _unitOfWork.Orders.Find(o => o.Id == ord.Id).FirstOrDefault();
                orderToChange.State = ShopData.Entities.Enums.OrderState.Created;
                //Console.WriteLine("End of order delay");
                _unitOfWork.Save();
                delay = 3;
            }
            else
            {
                delay -= 1;
                //Console.WriteLine("Order delay " + delay);
            }
        }
        #endregion

    }
}
