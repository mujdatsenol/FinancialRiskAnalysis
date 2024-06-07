using FinancialRiskAnalysis.Api.Endpoint;

namespace FinancialRiskAnalysis.Api;

public static class WebApplicationExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        PartnerEndpoint.Map(app);
    }
}
