namespace FinancialRiskAnalysis.Application.Abstractions;

public class CreateRiskAnalysisRequest
{
    public Guid BusinessTopicId { get; set; }

    public double RiskScore { get; set; }
}
