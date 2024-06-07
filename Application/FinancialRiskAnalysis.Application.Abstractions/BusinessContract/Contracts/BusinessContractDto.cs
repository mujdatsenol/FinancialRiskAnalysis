namespace FinancialRiskAnalysis.Application.Abstractions;

public class BusinessContractDto : DtoHasBaseId<Guid>
{
    public string Name { get; set; }
    
    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public IList<BusinessTopicDto> BusinessTopics { get; set; }

    // public IList<PartnerContractDto> PartnerContracts { get; set; }
}
