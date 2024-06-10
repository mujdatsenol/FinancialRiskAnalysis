using FinancialRiskAnalysis.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

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
        map.MapPost("/search", async (
            IBusinessContractService businessContractService,
            [FromBody] BusinessContractTableRequest request) =>
        {
            var result = await businessContractService.Search(request).ConfigureAwait(false);
            return result;
        })
        .WithName("SearchBusinessContract")
        .WithOpenApi();

        map.MapGet("/", async (IBusinessContractService businessContractService) =>
        {
            var result = await businessContractService.GetBusinessContracts().ConfigureAwait(false);
            return result;
        })
        .WithName("GetAllBusinessContract")
        .WithOpenApi();

        map.MapGet("/{businessContractId}", async (
            IBusinessContractService businessContractService,
            Guid businessContractId) =>
        {
            var result = await businessContractService.GetBusinessContract(businessContractId).ConfigureAwait(false);
            return result;
        })
        .WithName("GetBusinessContract")
        .WithOpenApi();

        map.MapPost("/", async (
            IBusinessContractService businessContractService,
            [FromBody] CreateBusinessContractRequest request) =>
        {
            var result = await businessContractService.CreateBusinessContract(request);
            return result;
        })
        .WithName("CreateBusinessContract")
        .WithOpenApi();

        map.MapPut("/{businessContractId}", async (
            IBusinessContractService businessContractService,
            [FromRoute] Guid businessContractId,
            [FromBody] UpdateBusinessContractRequest request) =>
        {
            var result = await businessContractService.UpdateBusinessContract(businessContractId, request);
            return result;
        })
        .WithName("UpdateBusinessContract")
        .WithOpenApi();

        map.MapDelete("/{businessContractId}", async (
            IBusinessContractService businessContractService,
            Guid businessContractId) =>
        {
            return Results.BadRequest("Bu özellik kullanılmıyor!");
        })
        .WithName("DeleteBusinessContract")
        .WithOpenApi();

        return map;
    }
}
