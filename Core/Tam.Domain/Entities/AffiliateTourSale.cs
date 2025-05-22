using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class AffiliateTourSale: BaseEntity
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public int AffiliatePartnerId { get; set; }
        public AffiliatePartner AffiliatePartner { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal CommissionRate { get; set; } 
        public decimal TotalCommissionAmount { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public string? Note { get; set; }
    }
}
