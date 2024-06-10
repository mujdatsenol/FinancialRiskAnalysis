namespace FinancialRiskAnalysis.Application.Abstractions;

public class UpdateBusinessTopicRequest
{
    public Guid Id { get; set; }
    
    public Guid PartnerId { get; set; }

    public Guid BusinessContractId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}
