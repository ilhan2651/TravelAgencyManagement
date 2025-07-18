﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.PaymentDtos
{
    public class CreatePaymentDto
    {
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidAt { get; set; }
        public bool IsRefunded { get; set; }
        public string TransactionCode { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
    }

}
