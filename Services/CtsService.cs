using calculadora_beneficios.Models.Requests;
using calculadora_beneficios.Utils;

namespace calculadora_beneficios.Services;

public class CtsService
{
    public double Calcular(double sueldo, DateTime fechaInicio, DateTime fechaFin, bool asignacionFamiliar = false) 
    {
        // Calculamos numero de meses segun la fechaInicio y fechaFin
        var (meses, dias) = Helpers.CalcularMesesYDias(fechaInicio, fechaFin);

        // Si tiene asignacion familiar entonces se le suma el 10% del sueldo minimo al sueldo
        if (asignacionFamiliar)
            sueldo += Constants.SueldoMinimo * 0.1;

        // El maximo es de 6 meses para el calculo de la cts
        if (meses > 6)
            meses = 6;

        var cts = sueldo / 12 * meses;

        // Si son menos de 6 meses se tiene que agregar lo equivalente a los dias trabajados
        if (meses < 6)
            cts += sueldo / 12 * dias / 30;

        return cts;
    }
}
