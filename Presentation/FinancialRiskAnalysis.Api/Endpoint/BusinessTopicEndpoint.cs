using FinancialRiskAnalysis.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

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
        map.MapPost("/search", async (
            IBusinessTopicService businessTopicService,
            [FromBody] BusinesTopicTableRequest request) =>
        {
            var result = await businessTopicService.Search(request).ConfigureAwait(false);
            return result;
        })
        .WithName("SearchBusinessTopic")
        .WithOpenApi();
        
        map.MapGet("/", async (IBusinessTopicService businessTopicService) =>
        {
            var result = await businessTopicService.GetBusinessTopics().ConfigureAwait(false);
            return result;
        })
        .WithName("GetAllBusinessTopic")
        .WithOpenApi();

        map.MapGet("/{businessTopicId}", async (IBusinessTopicService businessTopicService, Guid businessTopicId) =>
        {
            var result = await businessTopicService.GetBusinessTopic(businessTopicId).ConfigureAwait(false);
            return result;
        })
        .WithName("GetBusinessTopic")
        .WithOpenApi();

        map.MapPost("/", async (IBusinessTopicService businessTopicService, [FromBody] CreateBusinessTopicRequest request) =>
        {
            var result = await businessTopicService.CreateBusinessTopic(request);
            return result;
        })
        .WithName("CreateBusinessTopic")
        .WithOpenApi();

        map.MapPut("/{businessTopicId}", async (
            IBusinessTopicService businessTopicService,
            [FromRoute] Guid businessTopicId,
            [FromBody] UpdateBusinessTopicRequest request) =>
        {
            var result = await businessTopicService.UpdateBusinessTopic(businessTopicId, request);
            return result;
        })
        .WithName("UpdateBusinessTopic")
        .WithOpenApi();

        map.MapDelete("/{businessTopicId}", async (IBusinessTopicService businessTopicService, Guid businessTopicId) =>
        {
            return Results.BadRequest("Bu özellik kullanılmıyor!");
        })
        .WithName("DeleteBusinessTopic")
        .WithOpenApi();

        return map;
    }
}
