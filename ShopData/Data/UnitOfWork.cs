using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryContext _context;

        public IPlaceRepository Places { get; private set; }



        public UnitOfWork(DeliveryContext context)
        {
            _context = context;
            Places = new PlaceRepository(_context);

        }


        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }



    }
}
