namespace FinancialRiskAnalysis.Application.Abstractions;

public class UpdatePartnerContractRequest
{
    public Guid Id { get; set; }

    public Guid PartnerId { get; set; }
    
    public Guid BusinessContractId { get; set; }
}
