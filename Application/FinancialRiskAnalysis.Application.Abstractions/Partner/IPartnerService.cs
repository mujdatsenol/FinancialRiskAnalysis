using FinancialRiskAnalysis.Common.Services;

namespace FinancialRiskAnalysis.Application.Abstractions;

public interface IPartnerService : IApplicationService
{
    Task<ServiceResponse<List<PartnerDto>>> GetPartners();
}
