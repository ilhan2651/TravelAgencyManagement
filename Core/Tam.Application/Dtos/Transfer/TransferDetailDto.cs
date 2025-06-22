using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.Transfer
{
    public class TransferDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PassengerCount { get; set; }
        public bool IsCompleted { get; set; }

        public string? StartLocationName { get; set; }
        public string? EndLocationName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string AppranteName { get; set; }= string.Empty;
        public string AppranteePhoneNumber { get; set; }= string.Empty;
        public TransferRouteDto? Route { get; set; }

        public ICollection<TransferDriverDto> Drivers { get; set; } = [];
        public ICollection<TransferVehicleDto> Vehicles { get; set; } = [];
        public ICollection<TransferCustomerDto> Customers { get; set; } = [];
    }

}
