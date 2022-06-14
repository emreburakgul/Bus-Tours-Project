using Microsoft.EntityFrameworkCore;
using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using RebelTours.Management.DataAccess.Extensions;
using RebelTours.Persistence.RebelsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.DataAccess
{
    public class BusRepository : IBusRepository
    {
        private RebelToursDbContext _dbContext = new RebelToursDbContext();
        public void Add(Bus bus)
        {
            _dbContext.Buses.Add(bus);
            _dbContext.SaveChanges();
        }

        public Bus Find(int id, params string[] includings)
        {
            return _dbContext.Buses.Find(id);
        }

        public IEnumerable<Bus> GetAll(params string[] includings)
        {
             return _dbContext.Buses
                .IncludeMultiple(includings)
                .ToList();
        }

        public void Remove(Bus bus)
        {
            _dbContext.Buses.Remove(bus);
            _dbContext.SaveChanges();
        }

        public void Update(Bus bus)
        {
            _dbContext.Buses.Update(bus);
            _dbContext.SaveChanges();
        }
    }
}
