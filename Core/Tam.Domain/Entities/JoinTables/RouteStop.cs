﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities.JoinTables
{
    public class RouteStop
    {
        public int RouteId { get; set; }
        public int LocationId { get; set; }
        public TimeSpan? StopDuration { get; set; }
        public string? Note { get; set; }
        public int Order { get; set; }
        public Route? Route { get; set; }
        public Location? Location { get; set; }

    }

}
