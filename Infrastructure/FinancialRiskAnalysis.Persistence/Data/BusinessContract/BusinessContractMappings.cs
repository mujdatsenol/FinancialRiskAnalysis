using FinancialRiskAnalysis.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialRiskAnalysis.Persistence;

public static class BusinessContractMappings
{
    public static void OnModelCreating(EntityTypeBuilder<BusinessContract> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasMany(m => m.BusinessTopics)
            .WithOne(o => o.BusinessContract)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.PartnerContracts)
            .WithOne(o => o.BusinessContract)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(name: "BusinessContract");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<BusinessContract> builder)
    {
        var businessContracts = BusinessContractSeed.BusinessContracts();
        builder.HasData(businessContracts);
    }
}
