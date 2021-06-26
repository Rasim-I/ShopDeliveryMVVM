using Shop;
using Shop.Data;
using ShopData.Entities;
using ShopLab4.Commands;
using ShopLogic.Abstraction.IMappers;
using ShopLogic.Abstraction.IServices;
using ShopLogic.Implementation.Mappers;
using ShopLogic.Implementation.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopLab4.ViewModel
{
    class OrdersPageViewModel : ViewModelBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper<Order, OrderModel> _orderMapper = new OrderMapper();
        private readonly IMapper<Transport, TransportModel> _transportMapper = new TransportMapper();
        private readonly IMapper<Product, ProductModel> _productMapper = new ProductMapper();
        private readonly ITransportService _transportService;
        private readonly IProductService _productService;

        private DeliveryContext context;
        
       



        public ObservableCollection<OrderModel> Orders { get; }        



        public OrdersPageViewModel()
        {

            context = new DeliveryContext();
            IUnitOfWork _unitOfWork = new UnitOfWork(context);
            _transportService = new TransportService(_unitOfWork, _transportMapper);
            _productService = new ProductService(_unitOfWork, _productMapper);
            _orderService = new OrderService(_unitOfWork, _orderMapper, _transportService, _productService);
            Orders = new ObservableCollection<OrderModel>(_orderService.OrdersWithReferences());
          
        }


    }
}
