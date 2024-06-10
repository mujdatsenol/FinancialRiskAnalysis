using System.Net;
using AutoMapper;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Common.Services;
using FinancialRiskAnalysis.Common.Services.Helper;
using FinancialRiskAnalysis.Domain;
using Microsoft.Extensions.Configuration;

namespace FinancialRiskAnalysis.Application;

public class BusinessContractService : IBusinessContractService
{
    private readonly IDataManager dataManager;
    private readonly IRepository<BusinessContract> businessContractRepository;
    private readonly IConfiguration configuration;
    private readonly IServiceResponseHelper serviceResponseHelper;
    private readonly IMapper mapper;

    public BusinessContractService(
        IDataManager dataManager,
        IRepository<BusinessContract> memberRepository,
        IConfiguration configuration,
        IServiceResponseHelper serviceResponseHelper,
        IMapper mapper)
    {
        this.dataManager = dataManager;
        this.businessContractRepository = memberRepository;
        this.configuration = configuration;
        this.serviceResponseHelper = serviceResponseHelper;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<List<BusinessContractDto>>> GetBusinessContracts()
    {
        var result = await this.businessContractRepository
            .GetListAsync(orderBy: o => o.OrderBy(o => o.StartDate))
            .ConfigureAwait(false);

        var dtoResult = this.mapper.Map<List<BusinessContractDto>>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse<BusinessContractDto>> GetBusinessContract(Guid id)
    {
        var result = await this.businessContractRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (result == null)
        {
            return this.serviceResponseHelper.SetError<BusinessContractDto>(
                null,
                "Bir iş anlaşması bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        var dtoResult = this.mapper.Map<BusinessContractDto>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse> CreateBusinessContract(CreateBusinessContractRequest request)
    {
        await this.businessContractRepository.AddAsync(
            new BusinessContract()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CreateDate = DateTime.UtcNow
            })
            .ConfigureAwait(false);

        return this.serviceResponseHelper.SetSuccess();
    }

    public async Task<ServiceResponse> UpdateBusinessContract(Guid id, UpdateBusinessContractRequest request)
    {
        var businessContract = await this.businessContractRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (businessContract == null)
        {
            return this.serviceResponseHelper.SetError(
                "Güncellenecek bir iş anlaşması bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        businessContract.Name = request.Name;
        businessContract.Description = request.Description;
        businessContract.StartDate = request.StartDate;
        businessContract.EndDate = request.EndDate;
        businessContract.UpdateDate = DateTime.UtcNow;

        await this.businessContractRepository.UpdateAsync(businessContract);

        return this.serviceResponseHelper.SetSuccess();
    }
}
