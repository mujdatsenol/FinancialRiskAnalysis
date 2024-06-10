namespace FinancialRiskAnalysis.Domain;

public interface ICreated : IEntity
{
    DateTime CreateDate { get; set; }
}
