using System.Text.Json.Serialization;

namespace calculadora_beneficios.Models.Requests;

public class CtsRequest
{
    public double Sueldo { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool? AsignacionFamiliar { get; set; } = false;
}
