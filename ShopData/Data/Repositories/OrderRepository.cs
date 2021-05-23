using Shop;
using Shop.Data;
using ShopData.Data.Repositories.IRepositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShopData.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DeliveryContext context) : base(context)
        {
        }

        public IEnumerable<Order> OrdersWithReferences()
        {
            return db.Orders.Include(o => o.product).Include(o => o.transport).Include(o=>o.place).ToList();
        }
    }
}
