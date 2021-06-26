using Shop.Data;
using Shop.Models;
using Shop;
using ShopLab4.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using static Shop.Models.EnumSet;
using Type = Shop.Models.EnumSet.Type;
using ShopData.Entities;
using ShopLogic.Abstraction.IServices;
using ShopLogic.Abstraction.IMappers;
using ShopLogic.Implementation.Mappers;
using ShopLogic.Implementation.Services;

namespace ShopLab4.ViewModel
{
    internal class MainPageViewModel : ViewModelBase
    {
        private DeliveryContext context;    //
        private IUnitOfWork _unitOfWork;    //
        private IMapper<Order, OrderModel> _orderMapper = new OrderMapper();
        private IMapper<Transport, TransportModel> _transportMapper = new TransportMapper();
        private IMapper<Product, ProductModel> _productMapper = new ProductMapper();
        private IMapper<Place, PlaceModel> _placeMapper = new PlaceMapper();
        private IOrderService _orderService;
        private ITransportService _transportService;
        private IProductService _productService;
        private IPlaceService _placeService;
        

        #region OrderDelay

        static int delay = 0;


        #region Timer
        void OrderDeliveryTimer()
        {
            TimerCallback tm = new TimerCallback(Count);
            delay = 5;
            Timer timer = new Timer(tm, 0, 0, 2000);
        }


        void Count(object obj)
        {
            //this.delay = (int)obj;
            if (delay > 0)
            {
                delay -= 1;
                Console.WriteLine("time " + delay);
            }

        }
        #endregion


        #endregion


        #region command

        public ICommand CreateOrderCommand { get; }

        private bool CanCreateOrder(object p) => (EnteredName != null && SelectedOffice != null && SelectedProduct != null);

        private void OnCreateOrderExecuted(object p)
        {
            //OrderService.MakeORder
            _orderService.MakeOrder(SelectedProduct, SelectedOffice, EnteredName, delay);
            OrderDeliveryTimer();
            SelectedOffice = null;
            SelectedProduct = null;
            EnteredName = null;
        }

        #endregion


        private ProductModel _selectedProduct;
        private string _enteredName;
        private PlaceModel _selectedOffice;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public PlaceModel SelectedOffice
        {
            get { return _selectedOffice; }
            set
            {
                _selectedOffice = value;
                OnPropertyChanged("SelectedOffice");
            }
        }

        public string EnteredName
        {
            get { return _enteredName; }
            set
            {
                _enteredName = value;
                OnPropertyChanged("EnteredName");
            }
        }

        public ObservableCollection<ProductModel> Products { get; set; }

        public ObservableCollection<PlaceModel> Offices { get; }



        public MainPageViewModel()
        {
            context = new DeliveryContext();
            _unitOfWork = new UnitOfWork(context);
            // this._unitOfWork = unitOfWork;
            _transportService = new TransportService(_unitOfWork, _transportMapper);
            _productService = new ProductService(_unitOfWork, _productMapper);
            _orderService = new OrderService(_unitOfWork, _orderMapper, _transportService, _productService);
            _placeService = new PlaceService(_unitOfWork, _placeMapper);
            CreateOrderCommand = new ActionCommand(OnCreateOrderExecuted, CanCreateOrder);
            Products = new ObservableCollection<ProductModel>(_productService.GetProducts());
            Offices = new ObservableCollection<PlaceModel>(_placeService.GetPlaces());
        }


    }
}
