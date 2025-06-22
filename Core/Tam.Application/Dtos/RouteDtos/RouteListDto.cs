// RouteListDto.cs
namespace Tam.Application.Dtos.RouteDtos
{
    public class RouteListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? StartLocationName { get; set; }
        public string? EndLocationName { get; set; }
    }
}
