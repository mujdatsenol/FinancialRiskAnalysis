using AutoMapper;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Common.Services;
using FinancialRiskAnalysis.Common.Services.Helper;
using FinancialRiskAnalysis.Domain;
using Microsoft.Extensions.Configuration;

namespace FinancialRiskAnalysis.Application;

public class BusinessTopicService : IBusinessTopicService
{
    private readonly IDataManager dataManager;
    private readonly IRepository<BusinessTopic> businessTopicRepository;
    private readonly IConfiguration configuration;
    private readonly IServiceResponseHelper serviceResponseHelper;
    private readonly IMapper mapper;

    public BusinessTopicService(
        IDataManager dataManager,
        IRepository<BusinessTopic> businessTopicRepository,
        IConfiguration configuration,
        IServiceResponseHelper serviceResponseHelper,
        IMapper mapper)
    {
        this.dataManager = dataManager;
        this.businessTopicRepository = businessTopicRepository;
        this.configuration = configuration;
        this.serviceResponseHelper = serviceResponseHelper;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<List<BusinessTopicDto>>> GetBusinessTopics()
    {
        var result = await this.businessTopicRepository.GetListAsync().ConfigureAwait(false);

        var dtoResult = this.mapper.Map<List<BusinessTopicDto>>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }
}
