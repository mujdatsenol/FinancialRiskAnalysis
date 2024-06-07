namespace FinancialRiskAnalysis.Domain;

public class BusinessTopic : IEntity, IEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid PartnerId { get; set; }

    public Guid BusinessContractId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public virtual ICollection<RiskAnalysis> RiskAnalyses { get; set; }
}
