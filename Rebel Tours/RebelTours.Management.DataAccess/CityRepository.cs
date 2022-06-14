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
   public class CityRepository : ICityRepository
    {
        private readonly RebelToursDbContext _dbContext = new RebelToursDbContext();

        public IEnumerable<City> GetAll(params string[] includings)
        {
            var dbContext = new RebelToursDbContext();

            return dbContext.Cities
                .IncludeMultiple(includings)
                .ToList();
        }

        public void Add(City city)
        {
            var dbContext = new RebelToursDbContext();

            dbContext.Cities.Add(city);
            dbContext.SaveChanges();
        }

        public void Update(City city)
        {
            _dbContext.Cities.Update(city);
            _dbContext.SaveChanges();
        }

        public void Remove(City city)
        {
            _dbContext.Cities.Remove(city);
            _dbContext.SaveChanges();
        }

        public City Find(int id, params string[] includings)
        {
            var cityEntity= _dbContext.Cities.Find(id);
            return cityEntity;
        }
    }
}
