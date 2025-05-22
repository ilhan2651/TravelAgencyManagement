using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public string Method { get; set; } = string.Empty;

    }
}
