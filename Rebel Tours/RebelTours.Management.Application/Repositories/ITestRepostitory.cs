using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Repositories
{
    public interface ITestRepostitory : IRepository<ITest>
    {
    }

    public class TestRepository : ITestRepostitory
    {
        public void Add(ITest entity)
        {
            throw new NotImplementedException();
        }

        public ITest Find(int id, params string[] includings)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITest> GetAll(params string[] includings)
        {
            throw new NotImplementedException();
        }

        public void Remove(ITest entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ITest entity)
        {
            throw new NotImplementedException();
        }
    }
}
