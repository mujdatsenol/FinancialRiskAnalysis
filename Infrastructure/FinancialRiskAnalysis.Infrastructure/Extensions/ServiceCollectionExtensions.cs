using FinancialRiskAnalysis.Application;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Common.Services.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialRiskAnalysis.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IBusinessContractService, BusinessContractService>();
        services.AddTransient<IBusinessTopicService, BusinessTopicService>();
        services.AddTransient<IPartnerService, PartnerService>();
        services.AddTransient<IPartnerContractService, PartnerContractService>();
        services.AddTransient<IRiskAnalysisService, RiskAnalysisService>();

        services.AddTransient<IServiceResponseHelper, ServiceResponseHelper>();
    }

    public static void RegisterMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
    }
}
