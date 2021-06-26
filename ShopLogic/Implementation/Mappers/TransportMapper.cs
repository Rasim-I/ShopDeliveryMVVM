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
    public class TransportMapper : IMapper<Transport, TransportModel>
    {
        public TransportModel ToModel(Transport entity)
        {
            return new TransportModel
            {
                Id = entity.Id,
                name = entity.name,
                capacity = (Shop.Models.EnumSet.Capacity)entity.capacity,
                speed = (Shop.Models.EnumSet.Speed)entity.speed,
                state = (Shop.Models.EnumSet.State)entity.state,
                TimeUntilFree = TimeSpan.FromTicks(entity.TimeUntilFree)
            };
        }

        public Transport ToEntity(TransportModel model)
        {
            return new Transport
            {
                Id = model.Id,
                name = model.name,
                capacity = (ShopData.Entities.Enums.Capacity)model.capacity,
                speed = (ShopData.Entities.Enums.Speed)model.speed,
                state = (ShopData.Entities.Enums.State)model.state,
                TimeUntilFree = model.TimeUntilFree.Ticks

            };
        }
    }
}
