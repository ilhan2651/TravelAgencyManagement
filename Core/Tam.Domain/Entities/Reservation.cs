using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Rezervation : BaseEntity
    {

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime RezervationDate { get; set; } = DateTime.UtcNow;
        public int numberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string status { get; set; }
    }
}
