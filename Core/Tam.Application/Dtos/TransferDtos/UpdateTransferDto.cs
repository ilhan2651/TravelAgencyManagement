﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.Transfer
{
    public class UpdateTransferDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AppranteeId { get; set; }
        public int RouteId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PassengerCount { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int? StartLocationId { get; set; }
        public int? EndLocationId { get; set; }
    }
}
