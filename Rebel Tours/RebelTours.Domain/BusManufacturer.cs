﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Domain
{
    public class BusManufacturer
    {
        public BusManufacturer(int id, string name)
        {
            Id = id;
            Name = name;

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
