using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RebelTours.Domain;

namespace RebelTours.Management.Application.Repositories
{
    // Generic
    // Hangi başka bir tip için bu interface oluşturulacaksa o bahsettiğimiz "başka tip"i
    // generic tip olarak (tip parametresi olarak) oluştururuz.
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Find(int id, params string[] includings);

        IEnumerable<TEntity> GetAll(params string[] includings);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);
    }
}
