namespace ShopData.Migrations
{
    using Shop;
    using Shop.Models;
    using ShopData.Entities;
    using ShopData.Entities.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Type = Entities.Enums.Type;

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


            StoredProducts.Add(new Product() { Id = Guid.NewGuid(), name = "Frige", type = Type.electronics, Weight = 80, size = Size.big, Quantity = 1 });
            StoredProducts.Add(new Product() { Id = Guid.NewGuid(), name = "Clock", type = Type.electronics, Weight = 3, size = Size.little, Quantity = 3 });
            StoredProducts.Add(new Product() { Id = Guid.NewGuid(),  name = "Table", type = Type.furniture, Weight = 15, size = Size.medium, Quantity = 4 });
            StoredProducts.Add(new Product() { Id = Guid.NewGuid(), name = "Chair", type = Type.furniture, Weight = 5, size = Size.medium, Quantity = 5 });
            StoredProducts.Add(new Product() { Id = Guid.NewGuid(), name = "Pills", type = Type.meds, Weight = 1, size = Size.tiny, Quantity = 5 });
            StoredProducts.Add(new Product() { Id = Guid.NewGuid(), name = "Pizza", type = Type.food, Weight = 1, size = Size.little, Quantity = 2 });



            StoredTransports.Add(new BalancedTransport() { Id = Guid.NewGuid(), name = "Car-1", state = State.free, TimeUntilFree = TimeSpan.Zero.Ticks});
            StoredTransports.Add(new CapaciousTransport() { Id = Guid.NewGuid(), name = "Car-2", state = State.free, TimeUntilFree = TimeSpan.Zero.Ticks });
            StoredTransports.Add(new FastTransport() { Id = Guid.NewGuid(), name = "Car-3", state = State.free, TimeUntilFree = TimeSpan.Zero.Ticks });



            StoredPostOffice.Add(new Place() { Id = Guid.NewGuid(), name = "Office-2", distance = 100 });
            StoredPostOffice.Add(new Place() { Id = Guid.NewGuid(), name = "Office-3", distance = 400 });
            StoredPostOffice.Add(new Place() { Id = Guid.NewGuid(), name = "Office-4", distance = 1500 });
            StoredPostOffice.Add(new Place() { Id = Guid.NewGuid(), name = "Office-5", distance = 234 });

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
