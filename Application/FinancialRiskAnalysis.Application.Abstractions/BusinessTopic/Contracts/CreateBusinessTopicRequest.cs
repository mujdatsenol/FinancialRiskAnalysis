namespace FinancialRiskAnalysis.Application.Abstractions;

public class CreateBusinessTopicRequest
{
    public Guid PartnerId { get; set; }

    public Guid BusinessContractId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}
