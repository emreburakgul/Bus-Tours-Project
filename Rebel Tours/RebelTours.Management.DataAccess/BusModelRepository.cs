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
    public class BusModelRepository : IBusModelRepository
    {
        private RebelToursDbContext _dbContext = new RebelToursDbContext();

        public void Add(BusModel busModel)
        {
            _dbContext.BusModels.Add(busModel);
            _dbContext.SaveChanges();
            
        }

        public BusModel Find(int id, params string[] includings)
        {
            // EXPLICIT LOADING
            //var entity = _dbContext.BusModels.Find(id);

            //if (entity != null && includings != null)
            //{
            //    foreach (var navProp in includings)
            //    {
            //        //_dbContext.Entry(entity).Navigation(navProp).Load();
            //        _dbContext.Entry(entity).Reference(navProp).Load();
            //    }
            //}


            // EAGER LOADING
            var dbQuery = _dbContext.BusModels.AsQueryable();

            dbQuery = EfQueryHelper.IncludeMultiple2(dbQuery, includings);

            return dbQuery.SingleOrDefault(entity => entity.Id == id);
        }

        public IEnumerable<BusModel> GetAll(params string[] includings)
        {
            //IQueryable<BusModel> dbQuery = _dbContext.BusModels.AsQueryable();

            ////dbQuery = EfQueryHelper.IncludeMultiple(dbQuery, includings);

            //dbQuery = dbQuery.IncludeMultiple(includings);

            //return dbQuery.ToList();

            return _dbContext.BusModels
                .IncludeMultiple(includings)
                .ToList();
        }

        public void Remove(BusModel busModel)
        {
            _dbContext.BusModels.Remove(busModel);
            _dbContext.SaveChanges();
        }

        public void Update(BusModel busModel)
        {
            _dbContext.BusModels.Update(busModel);
            _dbContext.SaveChanges();
        }
    }
}
