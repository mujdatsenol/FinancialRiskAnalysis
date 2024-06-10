using System.ComponentModel.DataAnnotations;

namespace FinancialRiskAnalysis.Application.Abstractions;

public class CreatePartnerRequest
{
    [Required(ErrorMessage = "Partner bilgisi boş olamaz")]
    public required string Name { get; set; }
}
