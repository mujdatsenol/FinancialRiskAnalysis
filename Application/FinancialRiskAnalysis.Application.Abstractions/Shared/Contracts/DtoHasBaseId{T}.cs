namespace FinancialRiskAnalysis.Application.Abstractions;

public abstract class DtoHasBaseId<T> : DtoBase, IDtoHasId<T>
{
    public T Id { get; set; }
}
