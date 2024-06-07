namespace FinancialRiskAnalysis.Application.Abstractions;

public class BusinessTopicDto : DtoHasBaseId<Guid>
{
    public Guid PartnerId { get; set; }

    public Guid BusinessContractId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IList<RiskAnalysisDto> RiskAnalyses { get; set; }
}
