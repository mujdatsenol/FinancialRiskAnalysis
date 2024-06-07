﻿using AutoMapper;
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
}
