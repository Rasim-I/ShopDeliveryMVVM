using System;
using static Shop.Models.EnumSet;

namespace Shop
{
    public class Order : Base
    {

        public DateTime order_time;

        public Transport transport { get; set; }
        public Place place { get; set; }
        public Product product { get; set; }

        public String CustomerName { get; }

        public DateTime EstOrdDeliveryTime { get; set; }

        TimeSpan CalculateTime(DateTime order_time)
        {
            int distance = place.distance;

            int time;

            if (transport.speed > Speed.medium)
                time = (distance / 100) + Calculate_traffic(order_time);
            else
                time = (distance / 50) + Calculate_traffic(order_time);

            return TimeSpan.FromHours(time) + transport.TimeUntilFree;
        }

        int Calculate_traffic(DateTime order_time)
        {
            if ((order_time.Hour >= 13) && (order_time.Hour < 16))
                return 2;
            else
                return 1;
        }

        public Order(String Customer_Name, Transport transport, Place place, Product product)
        {
            order_time = DateTime.Now;

            this.transport = transport;
            this.place = place;
            this.product = product;
            this.CustomerName = Customer_Name;
            EstOrdDeliveryTime = DateTime.Now + CalculateTime(order_time);
            EstOrdDeliveryTime.Add(TimeSpan.FromDays(3));
        }

    }
}
