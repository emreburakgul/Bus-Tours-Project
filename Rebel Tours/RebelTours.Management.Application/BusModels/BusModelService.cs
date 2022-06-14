using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.BusModels
{
    public class BusModelService : IBusModelService
    {
        private readonly IBusModelRepository _busModelRepository;

        public BusModelService(IBusModelRepository busModelRepository)
        {
            _busModelRepository = busModelRepository;
        }

        public void Create(BusModelDTO busModel)
        {
            var modelEntity = new BusModel(busModel.Id, busModel.Name, busModel.BusManufacturerId, busModel.Type,
                busModel.SeatCapacity, busModel.HasToilet);

            _busModelRepository.Add(modelEntity);
        }

        public void Delete(BusModelDTO busModel)
        {
            var modelEntity = _busModelRepository.Find(busModel.Id);

            _busModelRepository.Remove(modelEntity);

        }

        public IEnumerable<BusModelDTO> GetAll()
        {
            var modelEntity = _busModelRepository.GetAll();

            var modelDTO = new List<BusModelDTO>();

            foreach (var model in modelEntity)
            {
                modelDTO.Add(new BusModelDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    BusManufacturerId = model.BusManufacturerId,
                    Type = model.Type,
                    SeatCapacity = model.SeatCapacity,
                    HasToilet = model.HasToilet
                });
            }

            return modelDTO;
        }

        public IEnumerable<BusModelSummary> GetSummaries()
        {
            var busModelEntities = _busModelRepository.GetAll("BusManufacturer");

            var busModels = busModelEntities.Select(entity => new BusModelSummary
            {
                Id = entity.Id,
                Name = entity.Name,
                BusManufacturerName = entity.BusManufacturer.Name,
                Type = entity.Type,
                SeatCapacity = entity.SeatCapacity,
                HasToilet = entity.HasToilet
            });

            //var busModels = new List<BusModelSummary>();

            //foreach (var model in busModelEntities)
            //{
            //    busModels.Add(new BusModelSummary
            //    {
            //        Id = model.Id,
            //        Name = model.Name,
            //        BusManufacturerName = model.BusManufacturer.Name,
            //        Type = model.Type,
            //        SeatCapacity = model.SeatCapacity,
            //        HasToilet = model.HasToilet
            //    });
            //}

            return busModels;
        }

        public BusModelDTO GetById(int id)
        {
            var modelEntity = _busModelRepository.Find(id);

            var modelDTO = new BusModelDTO
            {
                Id = modelEntity.Id,
                Name = modelEntity.Name,
                BusManufacturerId = modelEntity.BusManufacturerId,
                Type = modelEntity.Type,
                SeatCapacity = modelEntity.SeatCapacity,
                HasToilet = modelEntity.HasToilet
            };
            return modelDTO;
        }

        public void Update(BusModelDTO busModel)
        {
            var entityModel = _busModelRepository.Find(busModel.Id);
            entityModel.Name = busModel.Name;


            _busModelRepository.Update(entityModel);

        }
    }
}
