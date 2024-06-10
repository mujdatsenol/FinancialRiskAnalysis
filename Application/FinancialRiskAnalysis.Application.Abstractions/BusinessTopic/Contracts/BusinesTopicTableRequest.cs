namespace FinancialRiskAnalysis.Application.Abstractions;

public class BusinesTopicTableRequest : PagedRequest
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public int PageNumber { get; set; }
}
