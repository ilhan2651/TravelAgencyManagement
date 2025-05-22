using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class AffiliateTransferSale
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public int AffiliatePartnerId { get; set; }
        public AffiliatePartner AffiliatePartner { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal TotalCommissionAmount { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public string? Note { get; set; }
    }
}
