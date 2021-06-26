using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Abstraction.IServices
{
    public interface IPlaceService
    {
        IEnumerable<PlaceModel> GetPlaces();
    }
}
