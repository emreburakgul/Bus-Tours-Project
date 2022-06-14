using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Buses
{
    public interface IBusService
    {
        BusDTO GetById(int id);
        IEnumerable<BusDTO> GetAll();
        IEnumerable<BusSummary> GetSummary();
        void Create(BusDTO bus);
        void Update(BusDTO bus);
        void Delete(BusDTO bus);
    }
}
