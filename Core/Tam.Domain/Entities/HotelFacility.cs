﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class HotelFacility
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
