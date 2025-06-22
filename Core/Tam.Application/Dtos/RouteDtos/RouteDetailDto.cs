namespace Tam.Application.Dtos.RouteDtos
{
    public class RouteDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? StartLocationName { get; set; }
        public string? EndLocationName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<RouteStopDetailDto>? RouteStops { get; set; }
    }
}
