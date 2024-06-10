namespace FinancialRiskAnalysis.Domain;

public class BusinessContract : IEntity, IEntity<Guid>, ICreated, IUpdated
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<BusinessTopic> BusinessTopics { get; set; }

    public virtual ICollection<PartnerContract> PartnerContracts { get; set; }
}
