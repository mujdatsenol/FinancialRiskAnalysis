namespace FinancialRiskAnalysis.Domain;

public class RiskAnalysis : IEntity, IEntity<Guid>, ICreated, IUpdated
{
    public Guid Id { get; set; }

    public Guid BusinessTopicId { get; set; }

    public virtual BusinessTopic BusinessTopic { get; set; }

    public double RiskScore { get; set; }

    public DateTime AnalysisDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
