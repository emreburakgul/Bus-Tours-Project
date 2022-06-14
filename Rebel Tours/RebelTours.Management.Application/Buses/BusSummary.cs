using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.Buses
{
    public class BusSummary
    {
        public int Id { get; set; }
        public string BusModelName { get; set; }
        public string RegistrationPlate { get; set; }
        public short Year { get; set; }
        public SeatingType SeatMapping { get; set; }
        public int SeatCount { get; set; }
        public int DistanceTraveled { get; set; }
    }
}
