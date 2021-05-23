namespace ShopData.Migrations
{
    using Shop;
    using Shop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static Shop.Models.EnumSet;
    using Type = Shop.Models.EnumSet.Type;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Data.DeliveryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Shop.Data.DeliveryContext";
        }

        protected override void Seed(Shop.Data.DeliveryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            List<Product> StoredProducts = new List<Product>();
            List<Transport> StoredTransports = new List<Transport>();
            List<Place> StoredPostOffice = new List<Place>();
            List<Order> StoredOrders = new List<Order>();


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

            foreach(Place p in StoredPostOffice)
            {
                context.Places.AddOrUpdate(p);
            }

            foreach (Transport t in StoredTransports)
            {
                context.Transports.AddOrUpdate(t);
            }

            foreach (Product p in StoredProducts)
            {
                context.Products.AddOrUpdate(p);
            }

            foreach (Order o in StoredOrders)
            {
                context.Orders.AddOrUpdate(o);
            }

        }
    }
}
