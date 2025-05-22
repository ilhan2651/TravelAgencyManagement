using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class TaxDetail
    {
        public int Id { get; set; }
        public string TaxDocumentUrl { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidedAt { get; set; }
        public string WhoPaid { get; set; } = string.Empty;
    }
}
