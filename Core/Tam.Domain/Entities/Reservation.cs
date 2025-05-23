using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Reservation : BaseEntity
    {

       
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public int NumberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public string Note { get; set; } = string.Empty;
      
    }
}
