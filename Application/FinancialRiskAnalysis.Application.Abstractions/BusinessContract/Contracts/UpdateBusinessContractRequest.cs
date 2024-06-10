namespace FinancialRiskAnalysis.Application.Abstractions;

public class UpdateBusinessContractRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
