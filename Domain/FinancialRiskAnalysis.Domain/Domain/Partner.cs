namespace FinancialRiskAnalysis.Domain;

public class Partner : IEntity, IEntity<Guid>, ICreated, IUpdated
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<BusinessTopic> BusinessTopics { get; set; }

    public virtual ICollection<PartnerContract> PartnerContracts { get; set; }
}
