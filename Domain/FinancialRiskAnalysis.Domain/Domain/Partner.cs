namespace FinancialRiskAnalysis.Domain;

public class Partner : IEntity, IEntity<Guid>
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public virtual ICollection<BusinessTopic> BusinessTopics { get; set; }

    public virtual ICollection<PartnerContract> PartnerContracts { get; set; }
}
