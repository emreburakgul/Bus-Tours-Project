using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using RebelTours.Persistence.RebelsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.DataAccess
{
    public class BusManuRepository : IBusManuRepository
    {
        private RebelToursDbContext _dbContext = new RebelToursDbContext();

        public void Add(BusManufacturer busManu)
        {
            _dbContext.BusManufacturers.Add(busManu);
            _dbContext.SaveChanges();
        }

        public BusManufacturer Find(int id)
        {
            var busManuEntity = _dbContext.BusManufacturers.Find(id);

            return busManuEntity;
        }

        public IEnumerable<BusManufacturer> GetAll()
        {
            return _dbContext.BusManufacturers.ToList();

        }

        public void Remove(BusManufacturer busManu)
        {
            _dbContext.BusManufacturers.Remove(busManu);
            _dbContext.SaveChanges();
        }

        public void Update(BusManufacturer busManu)
        {
            _dbContext.BusManufacturers.Update(busManu);
            _dbContext.SaveChanges();
        }
    }
}

