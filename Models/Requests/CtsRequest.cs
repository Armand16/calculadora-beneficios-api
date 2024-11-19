using System.Text.Json.Serialization;

namespace calculadora_beneficios.Models.Requests;

public class CtsRequest
{
    public double Sueldo { get; set; }
    public string FechaInicio { get; set; } = string.Empty;
    public string FechaFin { get; set; } = string.Empty;
    public bool? AsignacionFamiliar { get; set; } = false;
}
