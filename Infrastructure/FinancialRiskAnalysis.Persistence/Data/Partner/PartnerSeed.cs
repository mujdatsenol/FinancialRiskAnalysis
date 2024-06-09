using FinancialRiskAnalysis.Domain;

namespace FinancialRiskAnalysis.Persistence;

public static class PartnerSeed
{
    public static List<Partner> Partners()
    {
        Guid partner1 = new Guid("5B5ABA2C-068C-4850-86AB-A4E2ECA325ED");
        Guid partner2 = new Guid("06500DC8-F77B-417D-BB5D-0D6AC7E3661A");
        Guid partner3 = new Guid("284E5EA4-32DA-4643-84B9-B7A889F9FE78");

        return new List<Partner>()
        {
            new Partner
            {
                Id = partner1,
                Name = "İş Ortağı 1"
            },
            new Partner
            {
                Id = partner2,
                Name = "İş Ortağı 1"
            },
            new Partner()
            {
                Id = partner3,
                Name = "İş Ortağı 1"
            }
        };
    }
}
