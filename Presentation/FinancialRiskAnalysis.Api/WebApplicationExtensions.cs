using FinancialRiskAnalysis.Api.Endpoint;

namespace FinancialRiskAnalysis.Api;

public static class WebApplicationExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGroup("api")
            .MapPartner()
            .WithTags("Partner");
        
        // Single map test
        PartnerEndpoint.MapSingle(app);
    }
}
