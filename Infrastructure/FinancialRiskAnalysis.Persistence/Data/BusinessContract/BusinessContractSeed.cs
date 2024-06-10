using FinancialRiskAnalysis.Domain;

namespace FinancialRiskAnalysis.Persistence;

public static class BusinessContractSeed
{
    public static List<BusinessContract> BusinessContracts()
    {
        Guid businessContract1 = new Guid("A0DBC67D-C032-46B1-B4E4-372F1AF5280D");
        Guid businessContract2 = new Guid("B13A2A50-9A66-4A01-91EC-9246FF3970C1");
        Guid businessContract3 = new Guid("5928BF0E-F501-4095-9D54-570A2196D59F");
        Guid businessContract4 = new Guid("E6922D3A-B69B-43D0-90F4-EC34DE7B268D");

        return new List<BusinessContract>()
        {
            new BusinessContract
            {
                Id = businessContract1,
                Name = "İş Anlaşması 1",
                Description = "1. İş anlaşması",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                CreateDate = DateTime.UtcNow
            },
            new BusinessContract
            {
                Id = businessContract2,
                Name = "İş Anlaşması 2",
                Description = "2. İş anlaşması",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(2),
                CreateDate = DateTime.UtcNow
            },
            new BusinessContract
            {
                Id = businessContract3,
                Name = "İş Anlaşması 3",
                Description = "3. İş anlaşması",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(3),
                CreateDate = DateTime.UtcNow
            },
            new BusinessContract
            {
                Id = businessContract4,
                Name = "İş Anlaşması 4",
                Description = "4. İş anlaşması",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                CreateDate = DateTime.UtcNow
            }
        };
    }
}
