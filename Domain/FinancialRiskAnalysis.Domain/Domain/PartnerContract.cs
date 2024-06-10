namespace FinancialRiskAnalysis.Domain;

public class PartnerContract : IEntity, IEntity<Guid>, ICreated, IUpdated
{
    public Guid Id { get; set; }

    public Guid PartnerId { get; set; }
    
    public Guid BusinessContractId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Partner Partner { get; set; }

    public virtual BusinessContract BusinessContract { get; set; }
}
