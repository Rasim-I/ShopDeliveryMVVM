using Shop;
using System.Collections.Generic;

namespace Shop.Data
{
    public interface IData
    {
        List<Product> Products();
        List<Transport> Transports();
        List<Place> PostOffice();
        List<Order> Orders();
        void SaveToDB(Transport transport);
        void SaveToDB(Order order);
        void SaveToDB(Place place);
        void SaveToDB(Product product, int quantity);
        void DeleteFromDB(Product product);

        //void Storehouse();
    }
}
