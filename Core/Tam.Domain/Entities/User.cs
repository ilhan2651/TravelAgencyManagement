using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }        
        public bool IsDeleted => DeletedAt.HasValue;
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserRole>? UserRoles { get; set; } 
        public ICollection<ActionLog>? ActionLogs { get; set; } 
        public ICollection<AuditTrail>? AuditTrails { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<ReportRequest>? ReportRequests { get; set; }

    }
}
