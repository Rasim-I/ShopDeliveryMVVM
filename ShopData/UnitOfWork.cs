using ShopData.Data.Repositories;
using ShopData.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryContext _context;
        public IPlaceRepository Places { get; private set; }
        public IProductRepository Products { get; private set; }
        public ITransportRepository Transports { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(DeliveryContext context)
        {
            _context = context;
            Places = new PlaceRepository(_context);
            Transports = new TransportRepository(_context);
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
