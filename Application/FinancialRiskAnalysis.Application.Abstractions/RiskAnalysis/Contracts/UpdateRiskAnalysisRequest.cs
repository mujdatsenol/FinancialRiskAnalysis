namespace FinancialRiskAnalysis.Application.Abstractions;

public class UpdateRiskAnalysisRequest
{
    public Guid Id { get; set; }

    public Guid BusinessTopicId { get; set; }

    public double RiskScore { get; set; }
}
