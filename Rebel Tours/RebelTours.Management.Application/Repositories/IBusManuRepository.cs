using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Repositories
{
  public  interface IBusManuRepository
    {
        IEnumerable<BusManufacturer> GetAll();
        void Add(BusManufacturer busManu);
        void Update(BusManufacturer busManu);
        void Remove(BusManufacturer busManu);
        BusManufacturer Find(int id);

    }
}
