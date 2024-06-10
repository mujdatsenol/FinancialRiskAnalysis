using FinancialRiskAnalysis.Domain;

namespace FinancialRiskAnalysis.Persistence;

public static class PartnerSeed
{
    public static List<Partner> Partners()
    {
        Guid partner1 = new Guid("5B5ABA2C-068C-4850-86AB-A4E2ECA325ED");
        Guid partner2 = new Guid("06500DC8-F77B-417D-BB5D-0D6AC7E3661A");
        Guid partner3 = new Guid("284E5EA4-32DA-4643-84B9-B7A889F9FE78");
        Guid partner4 = new Guid("83975A8C-637D-4CD8-B77E-1493F80A76CB");

        return new List<Partner>()
        {
            new Partner
            {
                Id = partner1,
                Name = "İş Ortağı 1",
                CreateDate = DateTime.UtcNow
            },
            new Partner
            {
                Id = partner2,
                Name = "İş Ortağı 2",
                CreateDate = DateTime.UtcNow
            },
            new Partner()
            {
                Id = partner3,
                Name = "İş Ortağı 3",
                CreateDate = DateTime.UtcNow
            },
            new Partner()
            {
                Id = partner4,
                Name = "İş Ortağı 4",
                CreateDate = DateTime.UtcNow
            }
        };
    }
}
