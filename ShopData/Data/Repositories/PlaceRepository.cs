using Shop;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(DeliveryContext context) : base(context)
        {

        }

        public IEnumerable<Place> GetPopularPlaces(int count)
        {
            return Context.Places.OrderByDescending(p => p.distance).Take(count).ToList();
        }



    }
}
