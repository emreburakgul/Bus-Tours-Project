
using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Buses
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
           _busRepository = busRepository;
        }

        public void Create(BusDTO bus)
        {
            var busEntity = new Bus(bus.Id,bus.BusModelId,bus.RegistrationPlate,
                bus.Year,bus.SeatMapping,bus.DistanceTraveled);
            _busRepository.Add(busEntity);
        }

        public void Delete(BusDTO bus)
        {
            var busEntity = _busRepository.Find(bus.Id);

            _busRepository.Remove(busEntity);
        }

        public IEnumerable<BusDTO> GetAll()
        {
            var busEntity = _busRepository.GetAll();

            var busDTO = new List<BusDTO>();

            foreach (var model in busEntity)
            {
                busDTO.Add(new BusDTO
                {
                   Id=model.Id,
                   BusModelId=model.BusModelId,
                   RegistrationPlate=model.RegistrationPlate,
                   Year=model.Year,
                   SeatMapping=model.SeatMapping,
                   SeatCount=model.SeatCount,
                   DistanceTraveled=model.DistanceTraveled                   
                });
            }

            return busDTO;
        }

        public BusDTO GetById(int id)
        {
            var busEntity = _busRepository.Find(id);

            var busDTO = new BusDTO
            {
                Id = busEntity.Id,
                BusModelId = busEntity.BusModelId,
                RegistrationPlate = busEntity.RegistrationPlate,
                Year = busEntity.Year,
                SeatMapping = busEntity.SeatMapping,
                SeatCount = busEntity.SeatCount,
                DistanceTraveled = busEntity.DistanceTraveled
            };
            return busDTO;
        }

        public IEnumerable<BusSummary> GetSummary()
        {
            var busEntity = _busRepository.GetAll("BusModel");

            var busDTO = new List<BusSummary>();

            foreach (var model in busEntity)
            {                
                busDTO.Add(new BusSummary
                {
                    Id = model.Id,
                    BusModelName = model.BusModel.Name,
                    RegistrationPlate = model.RegistrationPlate,
                    Year = model.Year,
                    SeatMapping = model.SeatMapping,
                    SeatCount = model.SeatCount,
                    DistanceTraveled = model.DistanceTraveled                    
                });
            }

            return busDTO;
        }

        public void Update(BusDTO bus)
        {
            var entityBus = _busRepository.Find(bus.Id);

            entityBus.SeatMapping= bus.SeatMapping;
            entityBus.DistanceTraveled = bus.DistanceTraveled;

            _busRepository.Update(entityBus);
        }
    }
}
