using System.Net;
using AutoMapper;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Common.Services;
using FinancialRiskAnalysis.Common.Services.Helper;
using FinancialRiskAnalysis.Domain;
using Microsoft.Extensions.Configuration;

namespace FinancialRiskAnalysis.Application;

public class PartnerContractService : IPartnerContractService
{
    private readonly IDataManager dataManager;
    private readonly IRepository<PartnerContract> partnerContractRepository;
    private readonly IConfiguration configuration;
    private readonly IServiceResponseHelper serviceResponseHelper;
    private readonly IMapper mapper;

    public PartnerContractService(
        IDataManager dataManager,
        IRepository<PartnerContract> partnerContractRepository,
        IConfiguration configuration,
        IServiceResponseHelper serviceResponseHelper,
        IMapper mapper)
    {
        this.dataManager = dataManager;
        this.partnerContractRepository = partnerContractRepository;
        this.configuration = configuration;
        this.serviceResponseHelper = serviceResponseHelper;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<List<PartnerContractDto>>> GetPartnerContracts()
    {
        var result = await this.partnerContractRepository.GetListAsync().ConfigureAwait(false);
        var dtoResult = this.mapper.Map<List<PartnerContractDto>>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse<PartnerContractDto>> GetPartnerContract(Guid id)
    {
        var result = await this.partnerContractRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (result == null)
        {
            return this.serviceResponseHelper.SetError<PartnerContractDto>(
                null,
                "Bir iş ortağı sözleşmesi bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        var dtoResult = this.mapper.Map<PartnerContractDto>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse> CreatePartnerContract(CreatePartnerContractRequest request)
    {
        await this.partnerContractRepository.AddAsync(
            new PartnerContract()
            {
                Id = Guid.NewGuid(),
                PartnerId = request.PartnerId,
                BusinessContractId = request.BusinessContractId,
                CreateDate = DateTime.UtcNow
            })
            .ConfigureAwait(false);

        return this.serviceResponseHelper.SetSuccess();
    }

    public async Task<ServiceResponse> UpdatePartnerContract(Guid id, UpdatePartnerContractRequest request)
    {
        var partnerContract = await this.partnerContractRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (partnerContract == null)
        {
            return this.serviceResponseHelper.SetError(
                "Güncellenecek bir iş ortağı sözleşmesi bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        partnerContract.PartnerId = request.PartnerId;
        partnerContract.BusinessContractId = request.BusinessContractId;
        partnerContract.UpdateDate = DateTime.UtcNow;

        await this.partnerContractRepository.UpdateAsync(partnerContract);

        return this.serviceResponseHelper.SetSuccess();
    }
}
