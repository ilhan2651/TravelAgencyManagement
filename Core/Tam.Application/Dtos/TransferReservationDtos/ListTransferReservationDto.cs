using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TransferReservationDtos
{
    public class ListTransferReservationDto
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public string Status { get; set; }
        public int TotalPrice { get; set; }
        public string TransferName { get; set; }=string.Empty;
        public string CustomerName { get; set; } = string.Empty;
    }
}
