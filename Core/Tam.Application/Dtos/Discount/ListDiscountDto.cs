using Tam.Domain.Enums;
using Tam.Domain.Enums.Tam.Domain.Enums;

namespace Tam.Application.Dtos.DiscountDtos
{
    public class ListDiscountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DiscountType Type { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
