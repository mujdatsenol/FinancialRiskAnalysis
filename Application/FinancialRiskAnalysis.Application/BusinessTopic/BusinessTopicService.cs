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

    public async Task<ServiceResponse<PagedResultDto<BusinessTopicDto>>> Search(BusinesTopicTableRequest request)
    {
        var records = await this.businessTopicRepository
            .GetPagedListAsync(
                predicate: p =>
                    (string.IsNullOrWhiteSpace(request.Title)
                        ? true
                        : p.Title.Contains(request.Title))
                    && (string.IsNullOrWhiteSpace(request.Description)
                        ? true
                        : p.Description.Contains(request.Description)),
                orderBy: null,
                include: null,
                pageIndex: request.PageNumber,
                pageSize: request.PageSize,
                indexFrom: 1)
            .ConfigureAwait(false);

        var items = this.mapper.Map<List<BusinessTopicDto>>(records.Items);

        var result = new PagedResultDto<BusinessTopicDto>
        {
            PagedList = items,
            RowCount = records.TotalCount,
            PageCount = records.TotalPages,
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize,
            HasNextPage = request.PageNumber < records.TotalPages ? true : false,
            HasPreviousPage = request.PageNumber > 1 ? true : false,
        };

        return this.serviceResponseHelper.SetSuccess(result);
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
