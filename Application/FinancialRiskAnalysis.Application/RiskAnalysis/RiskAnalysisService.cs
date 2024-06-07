using AutoMapper;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Common.Services.Helper;
using FinancialRiskAnalysis.Domain;
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
}
