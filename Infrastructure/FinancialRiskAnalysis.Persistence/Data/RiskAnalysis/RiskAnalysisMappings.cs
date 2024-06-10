using FinancialRiskAnalysis.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialRiskAnalysis.Persistence;

public static class RiskAnalysisMappings
{
    public static void OnModelCreating(EntityTypeBuilder<RiskAnalysis> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasOne(o => o.BusinessTopic)
            .WithMany(m => m.RiskAnalyses)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(name: "RiskAnalysis");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<RiskAnalysis> builder)
    {
        var riskAnalyses = RiskAnalysisSeed.RiskAnalyses();
        builder.HasData(riskAnalyses);
    }
}
