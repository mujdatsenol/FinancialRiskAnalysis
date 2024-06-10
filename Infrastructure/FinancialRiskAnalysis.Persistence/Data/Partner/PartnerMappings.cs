using FinancialRiskAnalysis.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialRiskAnalysis.Persistence;

public static class PartnerMappings
{
    public static void OnModelCreating(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasMany(m => m.BusinessTopics)
            .WithOne(o => o.Partner)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.PartnerContracts)
            .WithOne(o => o.Partner)
            .OnDelete(DeleteBehavior.Cascade);

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<Partner> builder)
    {
        var partners = PartnerSeed.Partners();
        builder.HasData(partners);
    }
}
