using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Management.Application.BusModels
{
    public class BusModelSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BusManufacturerName { get; set; }
        public BusType Type { get; set; }
        public int SeatCapacity { get; set; }
        public bool HasToilet { get; set; }
        public string HasToiletString => HasToilet ? "Var" : "Yok";

        //public string HasToiletString
        //{
        //    get
        //    {
        //        return HasToilet ? "Var" : "Yok";
        //    }
        //}
    }
}
