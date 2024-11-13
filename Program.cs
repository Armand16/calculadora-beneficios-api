using calculadora_beneficios.Models.Requests;
using calculadora_beneficios.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CtsService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/cts", (CtsService ctsService, [FromBody] CtsRequest request) => {
    var cts = ctsService.Calcular(request.Sueldo, request.FechaInicio, request.FechaFin, request.AsignacionFamiliar!.Value);
    return Results.Ok(new
    {
        cts
    });
});

app.Run();
