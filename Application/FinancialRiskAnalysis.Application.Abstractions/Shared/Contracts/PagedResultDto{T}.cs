namespace FinancialRiskAnalysis.Application.Abstractions;

public class PagedResultDto<T>
{
    public int CurrentPage { get; set; }

    public int PageCount { get; set; }

    public int PageSize { get; set; }

    public int RowCount { get; set; }

    public bool HasPreviousPage { get; set; }

    public bool HasNextPage { get; set; }

    public IEnumerable<T> PagedList { get; set; }
}
