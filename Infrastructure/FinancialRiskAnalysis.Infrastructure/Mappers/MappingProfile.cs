using AutoMapper;
using FinancialRiskAnalysis.Application.Abstractions;
using FinancialRiskAnalysis.Domain;

namespace FinancialRiskAnalysis.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
        this.DestinationMemberNamingConvention = new PascalCaseNamingConvention();

        this.CreateMap<BusinessContract, BusinessContractDto>().ReverseMap().DisableCtorValidation();
        this.CreateMap<BusinessTopic, BusinessTopicDto>().ReverseMap().DisableCtorValidation();
        this.CreateMap<Partner, PartnerDto>().ReverseMap().DisableCtorValidation();
        // this.CreateMap<PartnerContract, PartnerContractDto>().ReverseMap().DisableCtorValidation();
        this.CreateMap<RiskAnalysis, RiskAnalysisDto>().ReverseMap().DisableCtorValidation();
    }
}
