using FinancialRiskAnalysis.Common.Services;

namespace FinancialRiskAnalysis.Application.Abstractions;

public interface IBusinessTopicService : IApplicationService
{
    Task<ServiceResponse<List<BusinessTopicDto>>> GetBusinessTopics();

    Task<ServiceResponse<BusinessTopicDto>> GetBusinessTopic(Guid id);

    Task<ServiceResponse> CreateBusinessTopic(CreateBusinessTopicRequest request);

    Task<ServiceResponse> UpdateBusinessTopic(Guid id, UpdateBusinessTopicRequest request);
}
