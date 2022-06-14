using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RebelTours.Management.DataAccess.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> queryable, IEnumerable<string> includings)
            where T : class
        {
            if (includings != null)
            {
                foreach (var navProp in includings)
                {
                    queryable = queryable.Include(navProp);
                }
            }

            return queryable;
        }
    }
}
