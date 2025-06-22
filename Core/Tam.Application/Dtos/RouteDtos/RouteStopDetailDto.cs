namespace Tam.Application.Dtos.RouteDtos
{
    public class RouteStopDetailDto
    {
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
        public TimeSpan? StopDuration { get; set; }
        public string? Note { get; set; }
        public int Order { get; set; }
    }
}
