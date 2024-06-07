using FinancialRiskAnalysis.Application;
using FinancialRiskAnalysis.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialRiskAnalysis.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IBusinessContractService, BusinessContractService>();
        services.AddTransient<IBusinessTopicService, BusinessTopicService>();
        services.AddTransient<IPartnerService, PartnerService>();
        // services.AddTransient<IPartnerContractSerice, PartnerContractService>();
        services.AddTransient<IRiskAnalysisService, RiskAnalysisService>();
    }

    public static void RegisterMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
    }
}
