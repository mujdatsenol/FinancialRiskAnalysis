using FinancialRiskAnalysis.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinancialRiskAnalysis.Persistence;

public class MainDbContext : DbContext
{
    // Add Migrations
    // dotnet ef migrations add InitialDatabase --output-dir Contexts\Main\Migrations --context FinancialRiskAnalysis.Persistence.MainDbContext --project ..\..\Infrastructure\FinancialRiskAnalysis.Persistence\FinancialRiskAnalysis.Persistence.csproj --startup-project ..\..\Presentation\FinancialRiskAnalysis.Api\FinancialRiskAnalysis.Api.csproj

    // Update Databse
    // dotnet ef database update --context FinancialRiskAnalysis.Persistence.MainDbContext --project ..\..\Infrastructure\FinancialRiskAnalysis.Persistence\FinancialRiskAnalysis.Persistence.csproj --startup-project ..\..\Presentation\FinancialRiskAnalysis.Api\FinancialRiskAnalysis.Api.csproj

    public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        { }

        public DbSet<BusinessContract> BusinessContracts { get; set; }

        public DbSet<BusinessTopic> BusinessTopics { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<PartnerContract> PartnerContracts { get; set; }

        public DbSet<RiskAnalysis> RiskAnalyses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // NOTE: CLI ile migration üretirken sorun yaşadım. Geçici bir çözüm olarak ekledim.
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=localhost,1433;database=FinancialRiskAnalysis;user id=sa;password=reallyStrongPwd123;TrustServerCertificate=Yes";
                string migrationsAssembly = "FinancialRiskAnalysis.Persistence";

                optionsBuilder.UseSqlServer(
                    connectionString,
                    opt => opt.MigrationsAssembly(migrationsAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BusinessContract>(BusinessContractMappings.OnModelCreating);
            builder.Entity<BusinessTopic>(BusinessTopicMappings.OnModelCreating);
            builder.Entity<Partner>(PartnerMappings.OnModelCreating);
            builder.Entity<PartnerContract>(PartnerContractMappings.OnModelCreating);
            builder.Entity<RiskAnalysis>(RiskAnalysisMappings.OnModelCreating);
        }
}
