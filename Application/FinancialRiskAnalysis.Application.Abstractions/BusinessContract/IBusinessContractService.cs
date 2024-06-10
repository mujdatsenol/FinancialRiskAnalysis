using FinancialRiskAnalysis.Common.Services;

namespace FinancialRiskAnalysis.Application.Abstractions;

public interface IBusinessContractService : IApplicationService
{
    Task<ServiceResponse<PagedResultDto<BusinessContractDto>>> Search(BusinessContractTableRequest request);

    Task<ServiceResponse<List<BusinessContractDto>>> GetBusinessContracts();

    Task<ServiceResponse<BusinessContractDto>> GetBusinessContract(Guid id);

    Task<ServiceResponse> CreateBusinessContract(CreateBusinessContractRequest request);

    Task<ServiceResponse> UpdateBusinessContract(Guid id, UpdateBusinessContractRequest request);
}
