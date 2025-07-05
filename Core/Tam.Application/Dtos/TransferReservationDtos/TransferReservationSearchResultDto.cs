using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TransferReservationDtos
{
    public class TransferReservationSearchResultDto
    {
        public int Id { get; set; }  
        public string CustomerName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
    }
}
