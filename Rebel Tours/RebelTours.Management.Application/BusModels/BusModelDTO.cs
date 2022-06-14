using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.BusModels
{
  public  class BusModelDTO
    {
        // sadece verilere değer taşıma amacımız olduğu için setleri açık oldu. 
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusManufacturerId { get; set; }
        public BusType Type { get; set; }
        public int SeatCapacity { get; set; }
        public bool HasToilet { get; set; }       
    }
}
