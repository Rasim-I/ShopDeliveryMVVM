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

namespace ShopLab4.ViewModel
{
    internal class MainPageViewModel : ViewModelBase
    {

        IData _shopData = new ShopData();  //

        //public MainPageViewModel(IData shopData)
        //{
        //    this._shopData = shopData;
        //}


        #region OrderProcessing

        static int delay = 0;

        public void MakeOrder(Guid productId, Guid placeId, string name)
        {

            Product orderedProduct = FindProduct(productId); 
            Place postOffice = FindPostOffice(placeId);  
            Transport transport = FindFreeTransport(orderedProduct);
            Order order = new Order(name, transport, postOffice, orderedProduct);



            DateTime dateTimeWithDelay = order.EstOrdDeliveryTime + TimeSpan.FromHours(delay);  //
            order.EstOrdDeliveryTime = dateTimeWithDelay;                                       //




            transport.Transit(order.EstOrdDeliveryTime - DateTime.Now);

            UpdateProductQuantity(orderedProduct);
            Console.WriteLine(orderedProduct.quantity);
            _shopData.SaveToDB(order);

            OrderDeliveryTimer();
        }


        void UpdateProductQuantity(Product product)
        {
            if (product.quantity > 0)
                product.quantity -= 1;
            else
                _shopData.DeleteFromDB(product);
        }


        public Product FindProduct(Guid ID)
        {
            return _shopData.Products().Find(p => p.Id == ID);
        }


        public Place FindPostOffice(Guid ID)
        {
            return _shopData.PostOffice().Find(pst => pst.Id == ID);
        }


        public List<Transport> FindCompatibleTransport(Product product)
        {
            if (product.type == Type.furniture)
            {
                return _shopData.Transports().FindAll(t => t.capacity > Capacity.medium);
            }
            else if (product.size >= Size.medium)
                return _shopData.Transports().FindAll(t => t.capacity >= Capacity.medium);
            else
                return _shopData.Transports();
        }


        public Transport FindFreeTransport(Product product)
        {
            List<Transport> CompatibleTransport = FindCompatibleTransport(product);
            try
            {
                Transport transport = CompatibleTransport.Find(t => t.state == State.free);
                if (transport == null)
                    throw new Exception();
                return transport;
            }
            catch (Exception)
            {
                return CompatibleTransport.OrderBy(t => (int)t.TimeUntilFree.TotalHours).First();
            }
        }

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

            MakeOrder(SelectedProduct.Id, SelectedOffice.Id, EnteredName);
            SelectedOffice = null;
            SelectedProduct = null;
            EnteredName = null;
        }

        #endregion


        private Product _selectedProduct;
        private string _enteredName;
        private Place _selectedOffice;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public Place SelectedOffice
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

        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<Place> Offices { get; }



        public MainPageViewModel()
        {
            CreateOrderCommand = new ActionCommand(OnCreateOrderExecuted, CanCreateOrder);
            Products = new ObservableCollection<Product>(_shopData.Products());
            Offices = new ObservableCollection<Place>(_shopData.PostOffice());
        }


    }
}
