using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Cities
{
    public class CityService : ICityService
    {
        private const string CreateErrorMessage = "Kaydetme aşamasında bir hata meydana geldi";
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public CommandResult Create(CityDTO city)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(city.Name))
                {
                    return CommandResult.Error("İsim boş geçilemez");
                }

                var cityRep = new City()
                {
                    Name = city.Name
                };

                _cityRepository.Add(cityRep);

                return CommandResult.Success(MessageProvider.CityCreateSuccessMessage);
            }
            catch (Exception)
            {
                return CommandResult.Error(CreateErrorMessage);
            }
        }

        public CommandResult Delete(CityDTO city)
        {
            try
            {
                var entityCity = _cityRepository.Find(city.Id);
                _cityRepository.Remove(entityCity);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                    "Silme işlemi sırasında bir hata meydana geldi",
                    ex.Message);
            }
        }

        public IEnumerable<CityDTO> GetAll()
        {
            var cityEntities = _cityRepository.GetAll();

            var cityDTOs = new List<CityDTO>();
            foreach (var entity in cityEntities)
            {
                //City nesnesini CityDTO nesnesine Mapping yapıyorum
                cityDTOs.Add(new CityDTO()
                {
                    Id = entity.Id,
                    Name = entity.Name

                });
            }

            return cityDTOs;
        }

        public CityDTO GetById(int id)
        {
            var cityEntities = _cityRepository.Find(id);

            var cityDTO = new CityDTO() { Id = cityEntities.Id, Name = cityEntities.Name };
            return cityDTO;
        }

        public CommandResult Update(CityDTO city)
        {
            try
            {
                var cityEntities = _cityRepository.Find(city.Id);

                cityEntities.Name = city.Name;

                _cityRepository.Update(cityEntities);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex.Message);
            }
        }
    }
}
