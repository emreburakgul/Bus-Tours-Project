using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.BusManufacturers
{
  public  interface IBusManuService
    {
        BusManuDTO GetById(int id);

        IEnumerable<BusManuDTO> GetAll();
        void Create(BusManuDTO busManu);
        void Update(BusManuDTO busManu);
        void Delete(BusManuDTO busManu);
       


    }
}
