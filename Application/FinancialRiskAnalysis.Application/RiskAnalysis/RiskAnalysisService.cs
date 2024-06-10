using System.Net;
using AutoMapper;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Common.Services;
using FinancialRiskAnalysis.Common.Services.Helper;
using FinancialRiskAnalysis.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinancialRiskAnalysis.Application;

public class RiskAnalysisService : IRiskAnalysisService
{
    private readonly IDataManager dataManager;
    private readonly IRepository<RiskAnalysis> riskAnalysisRepository;
    private readonly IConfiguration configuration;
    private readonly IServiceResponseHelper serviceResponseHelper;
    private readonly IMapper mapper;

    public RiskAnalysisService(
        IDataManager dataManager,
        IRepository<RiskAnalysis> riskAnalysisRepository,
        IConfiguration configuration,
        IServiceResponseHelper serviceResponseHelper,
        IMapper mapper)
    {
        this.dataManager = dataManager;
        this.riskAnalysisRepository = riskAnalysisRepository;
        this.configuration = configuration;
        this.serviceResponseHelper = serviceResponseHelper;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<PagedResultDto<RiskAnalysisDto>>> Search(RiskAnalysisTableRequest request)
    {
        var records = await this.riskAnalysisRepository
            .GetPagedListAsync(
                predicate: p =>
                    (request.RiskScore == null || request.RiskScore == 0
                        ? true
                        : p.RiskScore == request.RiskScore),
                orderBy: null,
                include: null, //i => i.Include(i => i.BusinessTopic),
                pageIndex: request.PageNumber,
                pageSize: request.PageSize,
                indexFrom: 1)
            .ConfigureAwait(false);

        var items = this.mapper.Map<List<RiskAnalysisDto>>(records.Items);

        var result = new PagedResultDto<RiskAnalysisDto>
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

    public async Task<ServiceResponse<List<RiskAnalysisDto>>> GetRiskAnalyses()
    {
        var result = await this.riskAnalysisRepository.GetListAsync().ConfigureAwait(false);
        var dtoResult = this.mapper.Map<List<RiskAnalysisDto>>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse<RiskAnalysisDto>> GetRiskAnalysis(Guid id)
    {
        var result = await this.riskAnalysisRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (result == null)
        {
            return this.serviceResponseHelper.SetError<RiskAnalysisDto>(
                null,
                "Bir risk analizi bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        var dtoResult = this.mapper.Map<RiskAnalysisDto>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse> CreateRiskAnalysis(CreateRiskAnalysisRequest request)
    {
        await this.riskAnalysisRepository.AddAsync(
            new RiskAnalysis()
            {
                Id = Guid.NewGuid(),
                BusinessTopicId = request.BusinessTopicId,
                RiskScore = request.RiskScore,
                CreateDate = DateTime.UtcNow
            })
            .ConfigureAwait(false);

        return this.serviceResponseHelper.SetSuccess();
    }

    public async Task<ServiceResponse> UpdateRiskAnalysis(Guid id, UpdateRiskAnalysisRequest request)
    {
        var riskAnalysis = await this.riskAnalysisRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (riskAnalysis == null)
        {
            return this.serviceResponseHelper.SetError(
                "Güncellenecek bir risk analizi bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        riskAnalysis.BusinessTopicId = request.BusinessTopicId;
        riskAnalysis.RiskScore = request.RiskScore;
        riskAnalysis.UpdateDate = DateTime.UtcNow;

        await this.riskAnalysisRepository.UpdateAsync(riskAnalysis);

        return this.serviceResponseHelper.SetSuccess();
    }
}
