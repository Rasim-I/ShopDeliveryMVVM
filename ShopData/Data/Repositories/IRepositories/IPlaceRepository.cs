using Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public interface IPlaceRepository : IRepository<Place>
    {
        IEnumerable<Place> GetPopularPlaces(int count);

    }
}
