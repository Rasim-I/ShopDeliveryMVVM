using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; }
        //ITransportRepository
        int Save();
    }
}
