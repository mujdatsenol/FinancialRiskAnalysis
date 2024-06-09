using FinancialRiskAnalysis.Application.Abstractions;

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
        map.MapGet("/", async (IBusinessContractService riskAnalysisService) =>
        {

        })
        .WithName("GetAllRiskAnalysis")
        .WithOpenApi();

        map.MapGet("/{riskAnalysisId}", async (IRiskAnalysisService riskAnalysisService, Guid riskAnalysisId) =>
        {

        })
        .WithName("GetRiskAnalysis")
        .WithOpenApi();

        map.MapPost("/", async (IRiskAnalysisService riskAnalysisService) =>
        {

        })
        .WithName("CreateRiskAnalysis")
        .WithOpenApi();

        map.MapPut("/{riskAnalysisId}", async (IRiskAnalysisService riskAnalysisService, Guid riskAnalysisId) =>
        {

        })
        .WithName("UpdateRiskAnalysis")
        .WithOpenApi();

        map.MapDelete("/{riskAnalysisId}", async (IRiskAnalysisService riskAnalysisService, Guid riskAnalysisId) =>
        {

        })
        .WithName("DeleteRiskAnalysis")
        .WithOpenApi();

        return map;
    }
}
