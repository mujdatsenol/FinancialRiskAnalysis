using System.ComponentModel.DataAnnotations;

namespace FinancialRiskAnalysis.Application.Abstractions;

public class UpdatePartnerRequest
{
    [Required(ErrorMessage = "Id bilgisi boş olamaz")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Partner bilgisi boş olamaz")]
    public required string Name { get; set; }
}
