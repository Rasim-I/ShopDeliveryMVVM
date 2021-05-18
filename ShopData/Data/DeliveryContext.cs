using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;




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




    }
}
