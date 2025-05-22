using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities

{
    public class AffiliatePartner : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<AffiliateTourSale>? AffiliateTourSales { get; set; }
        public ICollection<AffiliateTransferSale>? AffiliateTransferSales { get; set; }


    }
}
