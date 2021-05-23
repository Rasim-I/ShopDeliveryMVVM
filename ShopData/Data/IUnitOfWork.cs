using ShopData.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPlaceRepository Places { get; }
        IProductRepository Products {get; }
        ITransportRepository Transports { get;  }
        IOrderRepository Orders { get;  }
        //ITransportRepository
        int Save();
    }
}
