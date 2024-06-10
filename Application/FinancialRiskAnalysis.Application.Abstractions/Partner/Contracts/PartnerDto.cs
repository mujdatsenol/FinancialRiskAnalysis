namespace FinancialRiskAnalysis.Application.Abstractions;

public class PartnerDto : DtoHasBaseId<Guid>
{
    public required string Name { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public IList<BusinessTopicDto> BusinessTopics { get; set; }

    public IList<PartnerContractDto> PartnerContracts { get; set; }
}
