using Shop;
using ShopData.Entities;
using ShopLogic.Abstraction.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Implementation.Mappers
{
    public class PlaceMapper : IMapper<Place, PlaceModel>
    {
        public PlaceModel ToModel(Place entity)
        {
            return new PlaceModel
            {
                Id = entity.Id,
                name = entity.name,
                distance = entity.distance
            };
        }

        public Place ToEntity(PlaceModel model)
        {
            return new Place
            {
                Id = model.Id,
                name = model.name,
                distance = model.distance
            };
        }
    }
}
