using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class DiscountTransfer
    {
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
