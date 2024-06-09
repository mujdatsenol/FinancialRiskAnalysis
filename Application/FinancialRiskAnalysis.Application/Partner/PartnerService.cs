using AutoMapper;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Common.Services;
using FinancialRiskAnalysis.Common.Services.Helper;
using FinancialRiskAnalysis.Domain;
using Microsoft.Extensions.Configuration;

namespace FinancialRiskAnalysis.Application;

public class PartnerService : IPartnerService
{
    private readonly IDataManager dataManager;
    private readonly IRepository<Partner> partnerRepository;
    private readonly IConfiguration configuration;
    private readonly IServiceResponseHelper serviceResponseHelper;
    private readonly IMapper mapper;

    public PartnerService(
        IDataManager dataManager,
        IRepository<Partner> partnerRepository,
        IConfiguration configuration,
        IServiceResponseHelper serviceResponseHelper,
        IMapper mapper)
    {
        this.dataManager = dataManager;
        this.partnerRepository = partnerRepository;
        this.configuration = configuration;
        this.serviceResponseHelper = serviceResponseHelper;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<List<PartnerDto>>> GetPartners()
    {
        return this.serviceResponseHelper.SetSuccess(new List<PartnerDto>{
            new PartnerDto() {
                Id = new Guid(),
                Name = "test"
            }
        });

        var result = await this.partnerRepository.GetListAsync().ConfigureAwait(false);

        var dtoResult = this.mapper.Map<List<PartnerDto>>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }
}
