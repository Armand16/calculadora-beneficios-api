using System.Globalization;
using calculadora_beneficios.Models.Requests;
using calculadora_beneficios.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CtsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/cts", (CtsService ctsService, [FromBody] CtsRequest request) => {

    try
    {
        var cultureInfo = new CultureInfo("es-ES");
        DateTime fechaInicioDateTime = DateTime.ParseExact(request.FechaInicio, "dd/MM/yyyy", cultureInfo);
        DateTime fechaFinDateTime;

        // Si la fechaFin no está definida entonces se debe asignar como hoy en Perú
        if (string.IsNullOrWhiteSpace(request.FechaFin))
            fechaFinDateTime = DateTime.UtcNow.AddHours(-5);
        else 
            fechaFinDateTime = DateTime.ParseExact(request.FechaFin, "dd/MM/yyyy", cultureInfo);
        
        var cts = ctsService.Calcular(request.Sueldo, fechaInicioDateTime, fechaFinDateTime, request.AsignacionFamiliar!.Value);

        return Results.Ok(new
        {
            cts
        });   
    }
    catch (FormatException)
    {
        return Results.BadRequest(new
        {
            message = "El formato de las fechas debe ser dd/MM/yyyy"
        });        
    }
});

app.Run();
