using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class ReportRequest : BaseEntity
    {

        public int RequestedByUserId { get; set; }
        public User RequestedByUser { get; set; }

        public string ReportType { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Format { get; set; } = "PDF";
        public string Status { get; set; } = "Pending";
        public string? DownloadUrl { get; set; }

        public DateTime? CompletedAt { get; set; }
    }

}
