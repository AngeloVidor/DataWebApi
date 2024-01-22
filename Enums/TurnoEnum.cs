using System.Text.Json.Serialization;

namespace WebAPI;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TurnoEnum
{
    Manha,
    Tarde,
    Noite
}
