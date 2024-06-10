namespace FinancialRiskAnalysis.Domain;

public interface IUpdated : IEntity
{
    DateTime? UpdateDate { get; set; }
}
