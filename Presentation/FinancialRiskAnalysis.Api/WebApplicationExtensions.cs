using FinancialRiskAnalysis.Api.Endpoint;

namespace FinancialRiskAnalysis.Api;

public static class WebApplicationExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGroup("api")
            .MapPartner()
            .WithTags("Partner");

        app.MapGroup("api")
            .MapBusinessContract()
            .WithTags("Business Contract");

        app.MapGroup("api")
            .MapBusinessTopic()
            .WithTags("Business Topic");

        app.MapGroup("api")
            .MapPartnerContract()
            .WithTags("Partner Contract");

        app.MapGroup("api")
            .MapRiskAnalysis()
            .WithTags("Risk Analysis");

        // Single map test
        // PartnerEndpoint.MapSingle(app);
    }
}
