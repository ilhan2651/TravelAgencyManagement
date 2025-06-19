using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Tour;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.Guide
{
    public class GuideDetailDto : ListGuideDto
    {

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<TourMiniDto> Tours { get; set; } = [];
    }
}
