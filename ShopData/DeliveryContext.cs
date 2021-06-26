using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using ShopData.Entities;

namespace Shop.Data
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext() : base("DbConnection")
        {

        }

        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transport>()
            .Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Transports");
            });
            modelBuilder.Entity<FastTransport>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FastTransports");
            });
            modelBuilder.Entity<CapaciousTransport>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CapacitiousTransports");
            });
            modelBuilder.Entity<BalancedTransport>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BalancedTransports");
            });
        }
        */

    }
}
