using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Domain
{
    public class Bus
    {
        public Bus(
            int id,
            int busModelId, 
            string registrationPlate, 
            short year, 
            SeatingType seatMapping,            
            int distanceTraveled)
        {
            Id = id;
            BusModelId = busModelId;
            RegistrationPlate = registrationPlate;
            Year = year;
            SeatMapping = seatMapping;         
            DistanceTraveled = distanceTraveled;
        }

        public int Id { get; set; }
        public int BusModelId { get; }
        public string RegistrationPlate { get; }
        public short Year { get; }
        public SeatingType SeatMapping { get; set; }
        public int SeatCount
        {
            get
            {
                return BusModel.SeatTemplate.GetSeatCount(SeatMapping);
            }
        }
        public int DistanceTraveled { get; set; }

        public BusModel BusModel { get; set; }

    }
}
