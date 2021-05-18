using System;
using System.Collections.Generic;
using System.Linq;
using static Shop.Models.EnumSet;
using Type = Shop.Models.EnumSet.Type;
using Shop.Models;
using Shop;

namespace Shop.Data
{
    public class ShopData : IData
    {

        public List<Product> Products()
        {
            return StoredProducts.Where(p => p.quantity > 0).ToList();
        }

        public List<Place> PostOffice()
        {
            return StoredPostOffice;
        }

        public List<Order> Orders()
        {
            return StoredOrders;
        }
        public List<Transport> Transports()
        {
            return StoredTransports;
        }

        static List<Product> StoredProducts = new List<Product>();
        static List<Transport> StoredTransports = new List<Transport>();
        static List<Place> StoredPostOffice = new List<Place>();
        static List<Order> StoredOrders = new List<Order>();



        public static void Storehouse()
        {

            StoredProducts.Add(new Product("Frige", Type.electronics, 80, Size.big, 1));

            StoredProducts.Add(new Product("Clock", Type.electronics, 3, Size.little, 3));
            StoredProducts.Add(new Product("Table", Type.furniture, 15, Size.medium, 4));
            StoredProducts.Add(new Product("Chair", Type.furniture, 5, Size.medium, 5));
            StoredProducts.Add(new Product("Pills", Type.meds, 1, Size.tiny, 5));
            StoredProducts.Add(new Product("Pizza", Type.food, 1, Size.little, 2));

            
            StoredTransports.Add(new CapaciousTransport("Car-1"));
            StoredTransports.Add(new BalancedTransport("Car-2"));
            StoredTransports.Add(new FastTransport("Car-3"));



            StoredPostOffice.Add(new Place("Office-2", 100));
            StoredPostOffice.Add(new Place("Office-3", 400));
            StoredPostOffice.Add(new Place("Office-4", 1500));
            StoredPostOffice.Add(new Place("Office-5", 234));

        }

        public void SaveToDB(Transport transport)
        {
            StoredTransports.Add(transport);
        }
        public void SaveToDB(Order order)
        {
            StoredOrders.Add(order);
        }
        public void SaveToDB(Place place)
        {
            StoredPostOffice.Add(place);
        }
        public void SaveToDB(Product product, int quantity)
        {
            StoredProducts.Add(product);
        }
        public void DeleteFromDB(Product product)
        {
            StoredProducts.Remove(product);
        }

    }
}
