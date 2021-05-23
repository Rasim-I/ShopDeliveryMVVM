using Shop;
using Shop.Data;
using ShopData.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData.Data.Repositories
{
    public class TransportRepository : Repository<Transport>, ITransportRepository
    {
        public TransportRepository(DeliveryContext context) : base(context)
        {

        }



    }
}
