
using Shop;
using Shop.Data;
using ShopData.Entities;
using ShopData.Entities.Enums;
using ShopLogic.Abstraction.IMappers;
using ShopLogic.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopLogic.Implementation.Services
{
    public class TransportService : ITransportService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Transport, TransportModel> _transportMapper;

        public TransportService(IUnitOfWork unitOfWork, IMapper<Transport, TransportModel> transportMapper)
        {
            _unitOfWork = unitOfWork;
            _transportMapper = transportMapper;
        }

        public TransportModel FindFreeTransport(ProductModel product)
        {
            List<TransportModel> CompatibleTransport = _unitOfWork.Transports.GetAll().Select(t => _transportMapper.ToModel(t)).Where(t => t.isCompatible(product)).ToList();    //   _transportMapper.Map(_unitOfWork. .GetAll())    .Where(t => t.isCompatible(product)).ToList();

            //foreach(TransportModel tr in CompatibleTransport )
            //{
            //    Console.WriteLine(tr.name + "   " + tr.TimeUntilFree);
            //}

            if (CompatibleTransport.Find(t => (State)t.state == State.free) != null)
                return CompatibleTransport.Find(t => (State)t.state == State.free);
            else
                return CompatibleTransport.OrderBy(t => (int)t.TimeUntilFree.TotalHours).First();
        }

        public void Transit(TransportModel transport, TimeSpan time)
        {
            Transport transportToEdit = _unitOfWork.Transports.Find(t => t.Id == transport.Id).FirstOrDefault();
            transportToEdit.TimeUntilFree += time.Ticks ;
            transportToEdit.state = (State)transport.state;
            _unitOfWork.Save();
            //transport.TimeUntilFree += time;
            //transport.state = (Shop.Models.EnumSet.State)State.transit;

            //UpdateTransport(transport);
        }

        public void UpdateTransport(TransportModel transport)
        {
            //Console.WriteLine(transport + "    model ");
            //Console.WriteLine(_transportMapper.ToEntity(transport));

            Transport transport1 = _transportMapper.ToEntity(transport);
            //Console.WriteLine(transport.Id + transport.name + transport.speed + transport.state + transport.TimeUntilFree + transport.capacity);
            //Console.WriteLine(transport1.Id + transport1.name + transport1.speed + transport1.state + transport1.TimeUntilFree + transport1.capacity);

            //_unitOfWork.Transports.Update(_transportMapper.ToEntity(transport));
            Transport tr = _unitOfWork.Transports.Get(transport.Id);
            tr  = _transportMapper.ToEntity(transport);
            _unitOfWork.Save();
        }


    }
}
