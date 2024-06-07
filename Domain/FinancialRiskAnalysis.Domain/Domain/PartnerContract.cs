namespace FinancialRiskAnalysis.Domain;

public class PartnerContract : IEntity
{
    public int PartnerId { get; set; }
    
    public int BusinessContractId { get; set; }
}
