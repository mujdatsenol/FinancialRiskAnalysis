﻿using FinancialRiskAnalysis.Application.Abstractions;

namespace FinancialRiskAnalysis.Api.Endpoint;

public static class PartnerEndpoint
{
    public static RouteGroupBuilder MapPartner(this RouteGroupBuilder map)
    {
        map.MapGroup("Partner").Map();

        return map;
    }

    private static RouteGroupBuilder Map(this RouteGroupBuilder map)
    {
        map.MapGet("/", async (IPartnerService partnerService) =>
        {
            var result = await partnerService.GetPartners().ConfigureAwait(false);
            return result;
        })
        .WithName("GetAllPartner")
        .WithOpenApi();

        map.MapGet("/{partnerId}", async (IPartnerService partnerService, Guid partnerId) =>
        {

        })
        .WithName("GetPartner")
        .WithOpenApi();

        map.MapPost("/", async (IPartnerService partnerService) =>
        {

        })
        .WithName("CreatePartner")
        .WithOpenApi();

        map.MapPut("/{partnerId}", async (IPartnerService partnerService, Guid partnerId) =>
        {

        })
        .WithName("UpdatePartner")
        .WithOpenApi();

        map.MapDelete("/{partnerId}", async (IPartnerService partnerService, Guid partnerId) =>
        {

        })
        .WithName("DeletePartner")
        .WithOpenApi();

        return map;
    }

    // Single map test
    public static void MapSingle(this WebApplication app)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();

            return ResponseHelper.Success<WeatherForecast[]>(forecast);
        })
        .WithServiceResponse(app) // If you need use ResponseHelper you must do add this method.
        .WithName("GetWeatherForecast")
        .WithOpenApi();
    }

    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
