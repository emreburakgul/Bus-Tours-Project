using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Stations
{
    public class StationService : IStationService
    {

        private readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public CommandResult Create(StationDTO station)
        {
            return CommandResult.Error("Bir hata meydana geldi");

            try
            {
                var stationRep = new Station()
                {
                    Name = station.Name,
                    CityId = station.CityId
                };

                _stationRepository.Add(stationRep);

                return CommandResult.Success("Başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                return CommandResult.Error("Bir hata meydana geldi", ex.Message);
            }
        }

        public CommandResult Delete(StationDTO station)
        {
            try
            {
                var stationEntity = _stationRepository.Find(station.Id);

                _stationRepository.Remove(stationEntity);

                return CommandResult.Success("Başarıyla silindi");
            }
            catch (Exception ex)
            {
                return CommandResult.Error("Silme işlemi başarısız", ex.Message);
            }
        }

        public CommandResult Update(StationDTO station)
        {
            try
            {
                var entity = _stationRepository.Find(station.Id);

                entity.Name = station.Name;
                entity.CityId = station.CityId;

                _stationRepository.Update(entity);

                return CommandResult.Success("Başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return CommandResult.Error("Güncelleme işlemi başarısız", ex.Message);
            }
        }

        public IEnumerable<StationDTO> GetAll()
        {
            var stationEf = _stationRepository.GetAll();

            var stationDTO = new List<StationDTO>();

            foreach (var item in stationEf)
            {
                stationDTO.Add(new StationDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    CityId = item.CityId

                });
            }
            return stationDTO;
        }

        public IEnumerable<StationSummary> GetSummaries()
        {
            var stationEf = _stationRepository.GetAll("City");

            var stationDTO = new List<StationSummary>();

            foreach (var item in stationEf)
            {
                stationDTO.Add(new StationSummary
                {
                    Id = item.Id,
                    Name = item.Name,
                    CityName = item.City.Name
                });
            }
            return stationDTO;
        }

        public StationDTO GetById(int id)
        {
            var stationEf = _stationRepository.Find(id);

            var stationDto = new StationDTO
            {

                Id = stationEf.Id,
                Name = stationEf.Name,
                CityId = stationEf.CityId
            };

            return stationDto;
        }

        public StationSummary GetSummaryById(int id)
        {
            var stationEntity = _stationRepository.Find(id, "City");

            return new StationSummary()
            {
                Id = stationEntity.Id,
                Name = stationEntity.Name,
                CityName = stationEntity.City.Name
            };
        }
    }
}
