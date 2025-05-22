using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<UserRole>? UserRoles { get; set; } 
        public ICollection<ActionLog>? ActionLogs { get; set; } 
        public ICollection<AuditTrail>? AuditTrails { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<ReportRequest>? ReportRequests { get; set; }

    }
}
