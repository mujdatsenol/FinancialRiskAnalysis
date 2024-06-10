using System.Net;
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

    public async Task<ServiceResponse<BusinessTopicDto>> GetBusinessTopic(Guid id)
    {
        var result = await this.businessTopicRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (result == null)
        {
            return this.serviceResponseHelper.SetError<BusinessTopicDto>(
                null,
                "Bir iş konusu bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        var dtoResult = this.mapper.Map<BusinessTopicDto>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse> CreateBusinessTopic(CreateBusinessTopicRequest request)
    {
        await this.businessTopicRepository.AddAsync(
            new BusinessTopic()
            {
                Id = Guid.NewGuid(),
                PartnerId = request.PartnerId,
                BusinessContractId = request.BusinessContractId,
                Title = request.Title,
                Description = request.Description,
                CreateDate = DateTime.UtcNow
            })
            .ConfigureAwait(false);

        return this.serviceResponseHelper.SetSuccess();
    }

    public async Task<ServiceResponse> UpdateBusinessTopic(Guid id, UpdateBusinessTopicRequest request)
    {
        var businessTopic = await this.businessTopicRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (businessTopic == null)
        {
            return this.serviceResponseHelper.SetError(
                "Güncellenecek bir iş konusu bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        businessTopic.PartnerId = request.PartnerId;
        businessTopic.BusinessContractId = request.BusinessContractId;
        businessTopic.Title = request.Title;
        businessTopic.Description = request.Description;
        businessTopic.UpdateDate = DateTime.UtcNow;

        await this.businessTopicRepository.UpdateAsync(businessTopic);

        return this.serviceResponseHelper.SetSuccess();
    }
}
