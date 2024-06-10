using System.Net;
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

    public async Task<ServiceResponse<PagedResultDto<PartnerDto>>> Search(PartnerTableRequest request)
    {
        var records = await this.partnerRepository
            .GetPagedListAsync(
                predicate: p =>
                    (string.IsNullOrWhiteSpace(request.Name)
                        ? true
                        : p.Name.Contains(request.Name)),
                orderBy: null,
                include: null,
                pageIndex: request.PageNumber,
                pageSize: request.PageSize,
                indexFrom: 1)
            .ConfigureAwait(false);

        var items = this.mapper.Map<List<PartnerDto>>(records.Items);

        var result = new PagedResultDto<PartnerDto>
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

    public async Task<ServiceResponse<List<PartnerDto>>> GetPartners()
    {
        var result = await this.partnerRepository.GetListAsync().ConfigureAwait(false);
        var dtoResult = this.mapper.Map<List<PartnerDto>>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse<PartnerDto>> GetPartner(Guid id)
    {
        var result = await this.partnerRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (result == null)
        {
            return this.serviceResponseHelper.SetError<PartnerDto>(
                null,
                "Bir iş ortağı bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        var dtoResult = this.mapper.Map<PartnerDto>(result);

        return this.serviceResponseHelper.SetSuccess(dtoResult);
    }

    public async Task<ServiceResponse> CreatePartner(CreatePartnerRequest request)
    {
        await this.partnerRepository.AddAsync(
            new Partner()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreateDate = DateTime.UtcNow
            })
            .ConfigureAwait(false);

        return this.serviceResponseHelper.SetSuccess();
    }

    public async Task<ServiceResponse> UpdatePartner(Guid id, UpdatePartnerRequest request)
    {
        var partner = await this.partnerRepository
            .GetFirstOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        if (partner == null)
        {
            return this.serviceResponseHelper.SetError(
                "Güncellenecek bir iş ortağı bulanamadı!",
                (int)HttpStatusCode.NotFound);
        }

        partner.Name = request.Name;
        partner.UpdateDate = DateTime.UtcNow;

        await this.partnerRepository.UpdateAsync(partner);

        return this.serviceResponseHelper.SetSuccess();
    }
}
