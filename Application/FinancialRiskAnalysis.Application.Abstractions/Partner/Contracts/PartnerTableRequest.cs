namespace FinancialRiskAnalysis.Application.Abstractions;

public class PartnerTableRequest : PagedRequest
{
    public string? Name { get; set; }

    public int PageNumber { get; set; }
}