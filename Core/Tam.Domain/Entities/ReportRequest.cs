using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class ReportRequest
    {
        public int Id { get; set; }

        public int RequestedByUserId { get; set; }
        public string ReportType { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Format { get; set; } = "PDF";
        public string Status { get; set; } = "Pending";
        public string? DownloadUrl { get; set; }

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }

}
