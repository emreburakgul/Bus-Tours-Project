using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RebelTours.Management.DataAccess.Extensions
{
    public static class EfQueryHelper
    {
        // Dönüş tipleri ve parametreler eğer generic tipse, o generic tipler AÇIK değil KAPALI
        // generic tipler olmalıdır

        public static IQueryable<TEntity> IncludeMultiple2<TEntity>(
            this IQueryable<TEntity> dbQuery, 
            params string[] includings)
            where TEntity : class
        {
            // IQueryable => Generic olmayan bir interface (non-generic type)
            // IQueryable<TEntity> => Generic açık tip bir interface (open generic type)
            // IQueryable<BusModel> => Kapatılmış bir generic (closed generic type)

            if (includings != null)
            {
                foreach (var navProp in includings)
                {
                    dbQuery = dbQuery.Include(navProp);
                }
            }

            return dbQuery;
        }
    }
}
