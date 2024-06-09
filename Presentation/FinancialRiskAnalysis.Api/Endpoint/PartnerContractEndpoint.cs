using FinancialRiskAnalysis.Application.Abstractions;

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

        })
        .WithName("GetAllPartnerContract")
        .WithOpenApi();

        map.MapGet("/{partnerContractId}", async (IPartnerContractService partnerContractService, Guid partnerContractId) =>
        {

        })
        .WithName("GetPartnerContract")
        .WithOpenApi();

        map.MapPost("/", async (IPartnerContractService partnerContractService) =>
        {

        })
        .WithName("CreatePartnerContract")
        .WithOpenApi();

        map.MapPut("/{partnerContractId}", async (IPartnerContractService partnerContractService, Guid partnerContractId) =>
        {

        })
        .WithName("UpdatePartnerContract")
        .WithOpenApi();

        map.MapDelete("/{partnerContractId}", async (IPartnerContractService partnerContractService, Guid partnerContractId) =>
        {

        })
        .WithName("DeletePartnerContract")
        .WithOpenApi();

        return map;
    }
}
