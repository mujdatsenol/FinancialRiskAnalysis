namespace FinancialRiskAnalysis.Application.Abstractions;

public class RiskAnalysisTableRequest : PagedRequest
{
    public double? RiskScore { get; set; }

    public int PageNumber { get; set; }
}