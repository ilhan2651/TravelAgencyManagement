using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Tam.Application.Dtos.RouteDtos
{
    public class RouteStopDto
    {
        public int LocationId { get; set; }
        [JsonConverter(typeof(Application.Common.Converter.TimeSpanConverter))]


        public TimeSpan? StopDuration { get; set; }
        public string? Note { get; set; }
        public int Order { get; set; }
    }
}