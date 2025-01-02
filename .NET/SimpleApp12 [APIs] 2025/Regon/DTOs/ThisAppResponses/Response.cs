using Regon.Enums.DTOs.ThisAppResponses;
using System.Text.Json.Serialization;

namespace Regon.DTOs.ThisAppResponses
{
    public class Response<T>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestStatus Status { get; init; }
        //public KomunikatKodResponse? RequestProblem { get; init; } = null;
        public string? ExceptionMessage { get; init; } = null;
        public T? Result { get; init; }
    }
}
