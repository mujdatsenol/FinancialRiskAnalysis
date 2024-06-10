namespace FinancialRiskAnalysis.Application.Abstractions;

public class BusinessContractTableRequest : PagedRequest
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int PageNumber { get; set; }
}
