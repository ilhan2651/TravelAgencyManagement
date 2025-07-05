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
        public int TransferName { get; set; }
        public int CustomerName { get; set; }
    }
}
