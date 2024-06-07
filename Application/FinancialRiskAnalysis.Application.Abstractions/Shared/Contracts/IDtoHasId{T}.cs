namespace FinancialRiskAnalysis.Application.Abstractions;

public interface IDtoHasId<T> : IDto
{
    T Id { get; set; }
}
