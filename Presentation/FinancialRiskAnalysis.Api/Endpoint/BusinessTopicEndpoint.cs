using FinancialRiskAnalysis.Application.Abstractions;

namespace FinancialRiskAnalysis.Api.Endpoint;

public static class BusinessTopicEndpoint
{
    public static RouteGroupBuilder MapBusinessTopic(this RouteGroupBuilder map)
    {
        map.MapGroup("BusinessTopic").Map();

        return map;
    }

    private static RouteGroupBuilder Map(this RouteGroupBuilder map)
    {
        map.MapGet("/", async (IBusinessTopicService businessTopicService) =>
        {
            
        })
        .WithName("GetAllBusinessTopic")
        .WithOpenApi();

        map.MapGet("/{businessTopicId}", async (IBusinessTopicService businessTopicService, Guid businessTopicId) =>
        {

        })
        .WithName("GetBusinessTopic")
        .WithOpenApi();

        map.MapPost("/", async (IBusinessTopicService businessTopicService) =>
        {

        })
        .WithName("CreateBusinessTopic")
        .WithOpenApi();

        map.MapPut("/{businessTopicId}", async (IBusinessTopicService businessTopicService, Guid businessTopicId) =>
        {

        })
        .WithName("UpdateBusinessTopic")
        .WithOpenApi();

        map.MapDelete("/{businessTopicId}", async (IBusinessTopicService businessTopicService, Guid businessTopicId) =>
        {

        })
        .WithName("DeleteBusinessTopic")
        .WithOpenApi();

        return map;
    }
}
