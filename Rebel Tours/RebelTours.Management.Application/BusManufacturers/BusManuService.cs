using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.BusManufacturers
{
    public class BusManuService : IBusManuService
    {
        private readonly IBusManuRepository _manuRepository;

        public BusManuService(IBusManuRepository manuRepository)
        {
            _manuRepository = manuRepository;
        }

        public void Create(BusManuDTO busManu)
        {
            var busManuRep = new BusManufacturer(busManu.Id, busManu.Name);

            _manuRepository.Add(busManuRep);
        }

        public void Delete(BusManuDTO busManu)
        {
            var entitybusManu = _manuRepository.Find(busManu.Id);
            _manuRepository.Remove(entitybusManu);
        }

        public IEnumerable<BusManuDTO> GetAll()
        {
            var busManuEntity = _manuRepository.GetAll();
            var busManuDTO = new List<BusManuDTO>();

            foreach (var item in busManuEntity)
            {
                busManuDTO.Add(new BusManuDTO() { Id = item.Id, Name = item.Name });
            }

            return busManuDTO;
        }

        public BusManuDTO GetById(int id)
        {
            var busManuEntity = _manuRepository.Find(id);

            return new BusManuDTO() { Id = busManuEntity.Id, Name = busManuEntity.Name };
        }

        public void Update(BusManuDTO busManu)
        {
            var busManuEntity = _manuRepository.Find(busManu.Id);

            busManuEntity.Name = busManu.Name;

            _manuRepository.Update(busManuEntity);
        }
    }

}
