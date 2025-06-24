using Tam.Domain.Enums;
using Tam.Domain.Enums.Tam.Domain.Enums;

namespace Tam.Application.Dtos.DiscountDtos
{
    public class UpdateDiscountDto
    {
        public string Name { get; set; } = string.Empty;
        public DiscountType Type { get; set; } = DiscountType.Percentage;
        public decimal Value { get; set; }
        public decimal? MinAmount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
