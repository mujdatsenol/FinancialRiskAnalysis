using FinancialRiskAnalysis.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRiskAnalysis.Api;

public static class PartnerContractEndpoint
{
    public static RouteGroupBuilder MapPartnerContract(this RouteGroupBuilder map)
    {
        map.MapGroup("PartnerContract").Map();

        return map;
    }

    private static RouteGroupBuilder Map(this RouteGroupBuilder map)
    {
        map.MapGet("/", async (IPartnerContractService partnerContractService) =>
        {
            var result = await partnerContractService.GetPartnerContracts().ConfigureAwait(false);
            return result;
        })
        .WithName("GetAllPartnerContract")
        .WithOpenApi();

        map.MapGet("/{partnerContractId}", async (IPartnerContractService partnerContractService, Guid partnerContractId) =>
        {
            var result = await partnerContractService.GetPartnerContract(partnerContractId).ConfigureAwait(false);
            return result;
        })
        .WithName("GetPartnerContract")
        .WithOpenApi();

        map.MapPost("/", async (IPartnerContractService partnerContractService, [FromBody] CreatePartnerContractRequest request) =>
        {
            var result = await partnerContractService.CreatePartnerContract(request);
            return result;
        })
        .WithName("CreatePartnerContract")
        .WithOpenApi();

        map.MapPut("/{partnerContractId}", async (
            IPartnerContractService partnerContractService,
            [FromRoute] Guid partnerContractId,
            [FromBody] UpdatePartnerContractRequest request) =>
        {
            var result = await partnerContractService.UpdatePartnerContract(partnerContractId, request);
            return result;
        })
        .WithName("UpdatePartnerContract")
        .WithOpenApi();

        map.MapDelete("/{partnerContractId}", async (IPartnerContractService partnerContractService, Guid partnerContractId) =>
        {
            return Results.BadRequest("Bu özellik kullanılmıyor!");
        })
        .WithName("DeletePartnerContract")
        .WithOpenApi();

        return map;
    }
}
