using FinancialRiskAnalysis.Common.Services;

namespace FinancialRiskAnalysis.Application.Abstractions;

public interface IPartnerService : IApplicationService
{
    Task<ServiceResponse<PagedResultDto<PartnerDto>>> Search(PartnerTableRequest request);

    Task<ServiceResponse<List<PartnerDto>>> GetPartners();

    Task<ServiceResponse<PartnerDto>> GetPartner(Guid id);

    Task<ServiceResponse> CreatePartner(CreatePartnerRequest request);

    Task<ServiceResponse> UpdatePartner(Guid id, UpdatePartnerRequest request);
}
