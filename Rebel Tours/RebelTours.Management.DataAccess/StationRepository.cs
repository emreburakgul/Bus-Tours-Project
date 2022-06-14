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
    public class StationRepository : IStationRepository
    {
        private RebelToursDbContext _dbContext = new RebelToursDbContext();

        public void Add(Station station)
        {
            _dbContext.Stations.Add(station);
            _dbContext.SaveChanges();
                        
        }

        public Station Find(int id, params string[] includings)
        {
            return _dbContext.Stations
                .IncludeMultiple(includings)
                .SingleOrDefault(entity => entity.Id == id);
        }

        public IEnumerable<Station> GetAll(params string[] includings)
        {
            return _dbContext.Stations
                .IncludeMultiple(includings)
                .ToList();
        }

        public IEnumerable<Station> GetAll(bool includeCity = false)
        {
            var dbQuery = _dbContext.Stations.AsQueryable();

            if (includeCity)
            {
                // Eager loading
                //dbQuery = dbQuery.Include(stat => stat.City);
                dbQuery = dbQuery.Include("City");
            }

            return dbQuery.ToList();
        }

        public void Remove(Station station)
        {
            _dbContext.Stations.Remove(station);
            _dbContext.SaveChanges();
        }

        public void Update(Station station)
        {
            _dbContext.Stations.Update(station);
            _dbContext.SaveChanges();
        }
    }
}
