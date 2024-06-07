namespace FinancialRiskAnalysis.Domain.Contract.PagedList;

public class PagedList<T> : IPagedList<T>
{
    internal PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom)
    {
        if (indexFrom > pageIndex)
        {
            throw new ArgumentException($"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
        }

        if (source is IQueryable<T> querable)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.IndexFrom = indexFrom;
            this.TotalCount = querable.Count();
            this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);

            this.Items = querable.Skip((this.PageIndex - this.IndexFrom) * this.PageSize).Take(this.PageSize).ToList();
        }
        else
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.IndexFrom = indexFrom;
            this.TotalCount = source.Count();
            this.TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            this.Items = source.Skip((this.PageIndex - this.IndexFrom) * this.PageSize).Take(this.PageSize).ToList();
        }
    }

    internal PagedList() => this.Items = new T[0];

    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public int TotalPages { get; set; }

    public int IndexFrom { get; set; }

    public IList<T> Items { get; set; }

    public bool HasPreviousPage => PageIndex - IndexFrom > 0;

    public bool HasNextPage => PageIndex - IndexFrom + 1 < TotalPages;
}
