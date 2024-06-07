using FinancialRiskAnalysis.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialRiskAnalysis.Persistence;

public static class PartnerContractMappings
{
    public static void OnModelCreating(EntityTypeBuilder<PartnerContract> builder)
    {
        builder.HasOne(o => o.Partner)
            .WithMany(m => m.PartnerContracts)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.BusinessContract)
            .WithMany(m => m.PartnerContracts)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
