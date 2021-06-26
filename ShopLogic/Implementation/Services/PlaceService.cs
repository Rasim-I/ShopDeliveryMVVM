using Shop;
using Shop.Data;
using ShopData.Entities;
using ShopLogic.Abstraction.IMappers;
using ShopLogic.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLogic.Implementation.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Place, PlaceModel> _placeMapper;

        public PlaceService(IUnitOfWork unitOfWork, IMapper<Place, PlaceModel> placeMapper)
        {
            _unitOfWork = unitOfWork;
            _placeMapper = placeMapper;
        }


        public IEnumerable<PlaceModel> GetPlaces()
        {
            return _unitOfWork.Places.GetAll().Select(_placeMapper.ToModel);
        }

        //public PlaceModel FindPostOffice(Guid ID)
        //{
        //    return _unitOfWork.Places.Get(ID);
        //}


        


    }
}
