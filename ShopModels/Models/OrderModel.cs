using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Shop.Models.EnumSet;

namespace Shop
{
    public class OrderModel //: INotifyPropertyChanged
    {
        private Guid _Id { get; set; }
        public DateTime _OrderTime { get; set; }

        public TransportModel transport { get; set; }
        private Guid _transportId;

        public PlaceModel place { get; set; }
        private Guid _placeId;

        public ProductModel product { get; set; }
        private Guid _productId;

        private string _CustomerName { get; set; }

        private DateTime _EstOrdDeliveryTime;


        private OrderState _State;

        public OrderState State
        {
            get => _State;
            set
            {
                _State = value;
                
            }
        }
        
        public Guid Id
        {
            get => _Id;
            set
            {
                _Id = value;

            }
        }

        public Guid ProductId
        {
            get => _productId;
            set
            {
                _productId = value;

            }
        }

        public Guid PlaceId
        {
            get => _placeId;
            set
            {
                _placeId = value;

            }
        }

        public Guid TransportId
        {
            get => _transportId;
            set
            {
                _transportId = value;

            }
        }

        public string CustomerName
        {
            get => _CustomerName;
            set
            {
                _CustomerName = value;

            }
        }

        public DateTime EstOrdDeliveryTime
        {
            get => _EstOrdDeliveryTime;
            set
            {
                _EstOrdDeliveryTime = value;

            }
        }

        public DateTime OrderTime
        {
            get => _OrderTime;
            set
            {
                _OrderTime = value;

            }
        }



        


        

        TimeSpan CalculateTime(DateTime order_time)
        {
            int distance = place.distance;

            int time;

            if (transport.speed > Speed.medium)
                time = (distance / 100) + Calculate_traffic(order_time);
            else
                time = (distance / 50) + Calculate_traffic(order_time);

            //Console.WriteLine(transport.TimeUntilFree);
            return TimeSpan.FromHours(time) + transport.TimeUntilFree;

        }

        int Calculate_traffic(DateTime order_time)
        {
            if ((order_time.Hour >= 13) && (order_time.Hour < 16))
                return 2;
            else
                return 1;
        }

        public OrderModel(string Customer_Name, TransportModel transport, PlaceModel place, ProductModel product)
        {
            OrderTime = DateTime.Now;
            Id = Guid.NewGuid();
            TransportId = transport.Id;
            this.transport = transport;

            PlaceId = place.Id;
            this.place = place;

            ProductId = product.Id;
            this.product = product;
            CustomerName = Customer_Name;
            EstOrdDeliveryTime = DateTime.Now + CalculateTime(OrderTime);
            EstOrdDeliveryTime.Add(TimeSpan.FromHours(3));
            State = OrderState.Pending;

        }
        public OrderModel() { }







        /*
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        */
    }
}
