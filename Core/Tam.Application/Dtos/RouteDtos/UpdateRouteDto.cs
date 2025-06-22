namespace Tam.Application.Dtos.RouteDtos
{
    public class UpdateRouteDto
    {
        public string Name { get; set; } = string.Empty;
        public int? StartLocationId { get; set; }
        public int? EndLocationId { get; set; }
        public List<RouteStopDto>? RouteStops { get; set; }
    }
}
