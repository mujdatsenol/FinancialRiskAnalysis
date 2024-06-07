using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinancialRiskAnalysis.Persistence;

public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<MainDbContext>();

        return new MainDbContext(builder.Options);
    }
}
