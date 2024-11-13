namespace calculadora_beneficios.Utils;

public class Helpers
{
    public static (int meses, int dias) CalcularMesesYDias(DateTime fechaInicio, DateTime fechaFin)
    {
        // Aseguramos que la fechaFin sea después de la fechaInicio
        if (fechaFin < fechaInicio)
        {
            throw new ArgumentException("La fecha final debe ser posterior a la fecha de inicio.");
        }

        // Calculamos la diferencia de años, meses y días
        int años = fechaFin.Year - fechaInicio.Year;
        int meses = fechaFin.Month - fechaInicio.Month;
        int dias = fechaFin.Day - fechaInicio.Day;

        // Ajustar meses si el día de la fechaFin es menor que el día de fechaInicio
        if (dias < 0)
        {
            meses--;
            dias += 30; // Consideramos cada mes con 30 días
        }

        // Ajustar años a meses
        meses += años * 12;

        return (meses, dias);
    }
}
