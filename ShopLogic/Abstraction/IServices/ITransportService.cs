using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Abstraction.IServices
{
    public interface ITransportService
    {
        TransportModel FindFreeTransport(ProductModel product);
        void Transit(TransportModel transport, TimeSpan time);
    }
}
