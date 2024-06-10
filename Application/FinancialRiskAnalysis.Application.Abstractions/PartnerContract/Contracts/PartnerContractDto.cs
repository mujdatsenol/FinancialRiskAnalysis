namespace FinancialRiskAnalysis.Application.Abstractions;

public class PartnerContractDto : DtoHasBaseId<Guid>
{
    public Guid PartnerId { get; set; }
    
    public Guid BusinessContractId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public PartnerDto Partner { get; set; }

    public BusinessContractDto BusinessContract { get; set; }
}
