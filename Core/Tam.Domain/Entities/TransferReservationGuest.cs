﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class TransferReservationGuest : BaseEntity
    {
        public int TransferReservationId { get; set; }
        public TransferReservation TransferReservation { get; set; }

        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Note { get; set; }
    }
}
