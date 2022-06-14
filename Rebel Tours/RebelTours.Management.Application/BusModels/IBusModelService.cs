using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.BusModels
{
    public interface IBusModelService
    {
        BusModelDTO GetById(int id);

        IEnumerable<BusModelDTO> GetAll();
        IEnumerable<BusModelSummary> GetSummaries();
        void Create(BusModelDTO busModel);
        void Update(BusModelDTO busModel);
        void Delete(BusModelDTO busModel);
    }
}
