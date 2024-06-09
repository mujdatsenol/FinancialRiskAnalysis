using FinancialRiskAnalysis.Application.Abstractions;

namespace FinancialRiskAnalysis.Api.Endpoint;

public static class BusinessContractEndpoint
{
    public static RouteGroupBuilder MapBusinessContract(this RouteGroupBuilder map)
    {
        map.MapGroup("BusinessContract").Map();

        return map;
    }

    private static RouteGroupBuilder Map(this RouteGroupBuilder map)
    {
        map.MapGet("/", async (IBusinessContractService businessContractService) =>
        {

        })
        .WithName("GetAllBusinessContract")
        .WithOpenApi();

        map.MapGet("/{businessContractId}", async (IBusinessContractService businessContractService, Guid businessContractId) =>
        {

        })
        .WithName("GetBusinessContract")
        .WithOpenApi();

        map.MapPost("/", async (IBusinessContractService businessContractService) =>
        {

        })
        .WithName("CreateBusinessContract")
        .WithOpenApi();

        map.MapPut("/{businessContractId}", async (IBusinessContractService businessContractService, Guid businessContractId) =>
        {

        })
        .WithName("UpdateBusinessContract")
        .WithOpenApi();

        map.MapDelete("/{businessContractId}", async (IBusinessContractService businessContractService, Guid businessContractId) =>
        {

        })
        .WithName("DeleteBusinessContract")
        .WithOpenApi();

        return map;
    }
}
