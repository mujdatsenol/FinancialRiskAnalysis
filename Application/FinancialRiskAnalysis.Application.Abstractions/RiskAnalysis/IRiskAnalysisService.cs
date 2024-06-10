using FinancialRiskAnalysis.Common.Services;

namespace FinancialRiskAnalysis.Application.Abstractions;

public interface IRiskAnalysisService : IApplicationService
{
    Task<ServiceResponse<List<RiskAnalysisDto>>> GetRiskAnalyses();

    Task<ServiceResponse<RiskAnalysisDto>> GetRiskAnalysis(Guid id);

    Task<ServiceResponse> CreateRiskAnalysis(CreateRiskAnalysisRequest request);

    Task<ServiceResponse> UpdateRiskAnalysis(Guid id, UpdateRiskAnalysisRequest request);
}
