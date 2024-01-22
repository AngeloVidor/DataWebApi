using System.Text.Json.Serialization;

namespace WebAPI;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartamentoEnum
{
    RH,
    Financeiro,
    Compras,
    Atendimento,
    Zeladoria
}
