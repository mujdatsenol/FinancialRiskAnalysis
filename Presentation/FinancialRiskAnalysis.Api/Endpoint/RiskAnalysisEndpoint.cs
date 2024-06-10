using FinancialRiskAnalysis.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRiskAnalysis.Api;

public static class RiskAnalysisEndpoint
{
    public static RouteGroupBuilder MapRiskAnalysis(this RouteGroupBuilder map)
    {
        map.MapGroup("RiskAnalysis").Map();

        return map;
    }

    private static RouteGroupBuilder Map(this RouteGroupBuilder map)
    {
        map.MapGet("/", async (IRiskAnalysisService riskAnalysisService) =>
        {
            var result = await riskAnalysisService.GetRiskAnalyses().ConfigureAwait(false);
            return result;
        })
        .WithName("GetAllRiskAnalysis")
        .WithOpenApi();

        map.MapGet("/{riskAnalysisId}", async (IRiskAnalysisService riskAnalysisService, Guid riskAnalysisId) =>
        {
            var result = await riskAnalysisService.GetRiskAnalysis(riskAnalysisId).ConfigureAwait(false);
            return result;
        })
        .WithName("GetRiskAnalysis")
        .WithOpenApi();

        map.MapPost("/", async (IRiskAnalysisService riskAnalysisService, [FromBody] CreateRiskAnalysisRequest request) =>
        {
            var result = await riskAnalysisService.CreateRiskAnalysis(request);
            return result;
        })
        .WithName("CreateRiskAnalysis")
        .WithOpenApi();

        map.MapPut("/{riskAnalysisId}", async (
            IRiskAnalysisService riskAnalysisService,
            [FromRoute] Guid riskAnalysisId,
            [FromBody] UpdateRiskAnalysisRequest request) =>
        {
            var result = await riskAnalysisService.UpdateRiskAnalysis(riskAnalysisId, request);
            return result;
        })
        .WithName("UpdateRiskAnalysis")
        .WithOpenApi();

        map.MapDelete("/{riskAnalysisId}", async (IRiskAnalysisService riskAnalysisService, Guid riskAnalysisId) =>
        {
            return Results.BadRequest("Bu özellik kullanılmıyor!");
        })
        .WithName("DeleteRiskAnalysis")
        .WithOpenApi();

        return map;
    }
}
