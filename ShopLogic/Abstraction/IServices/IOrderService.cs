using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Abstraction.IServices
{
    public interface IOrderService
    {
        IEnumerable<OrderModel> GetAllOrders();
        void MakeOrder(ProductModel product, PlaceModel place, string name, int delay);
        IEnumerable<OrderModel> OrdersWithReferences();

    }
}
