using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class AuditTrail
    {
        public int Id { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public int EntityId { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string? Username { get; set; }

        public string? OldValues { get; set; }
        public string? NewValues { get; set; }

        public string IpAddress { get; set; } = string.Empty;
        public DateTime ActionTime { get; set; } = DateTime.UtcNow;
    }
}
