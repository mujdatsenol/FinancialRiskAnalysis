using FinancialRiskAnalysis.Common.Services;

namespace FinancialRiskAnalysis.Application.Abstractions;

public interface IPartnerContractService : IApplicationService
{
    Task<ServiceResponse<List<PartnerContractDto>>> GetPartnerContracts();

    Task<ServiceResponse<PartnerContractDto>> GetPartnerContract(Guid id);

    Task<ServiceResponse> CreatePartnerContract(CreatePartnerContractRequest request);

    Task<ServiceResponse> UpdatePartnerContract(Guid id, UpdatePartnerContractRequest request);
}
