using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "Percentage";

        public decimal Value { get; set; }
        public decimal? MinAmount { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
    }

}
