namespace FinancialRiskAnalysis.Domain;

public class RiskAnalysis : IEntity, IEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid BusinessTopicId { get; set; }

    public virtual BusinessTopic BusinessTopic { get; set; }

    public double RiskScore { get; set; }

    public DateTime AnalysisDate { get; set; }
}
