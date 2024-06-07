namespace FinancialRiskAnalysis.Domain;

public class BusinessContract : IEntity, IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<BusinessTopic> BusinessTopics { get; set; }

    public virtual ICollection<PartnerContract> PartnerContracts { get; set; }
}
