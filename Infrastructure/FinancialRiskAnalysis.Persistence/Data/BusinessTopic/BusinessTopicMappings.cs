using FinancialRiskAnalysis.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialRiskAnalysis.Persistence;

public static class BusinessTopicMappings
{
    public static void OnModelCreating(EntityTypeBuilder<BusinessTopic> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasOne(o => o.Partner)
            .WithMany(m => m.BusinessTopics)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.BusinessContract)
            .WithMany(m => m.BusinessTopics)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.RiskAnalyses)
            .WithOne(o => o.BusinessTopic)
            .OnDelete(DeleteBehavior.Cascade);

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<BusinessTopic> builder)
    {
        var businessTopics = BusinessTopicSeed.BusinessTopics();
        builder.HasData(businessTopics);
    }
}
