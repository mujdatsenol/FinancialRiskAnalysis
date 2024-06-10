namespace FinancialRiskAnalysis.Application.Abstractions;

public class CreatePartnerContractRequest
{
    public Guid PartnerId { get; set; }
    
    public Guid BusinessContractId { get; set; }
}
