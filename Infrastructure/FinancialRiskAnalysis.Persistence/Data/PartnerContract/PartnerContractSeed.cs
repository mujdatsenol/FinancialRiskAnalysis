using FinancialRiskAnalysis.Domain;

namespace FinancialRiskAnalysis.Persistence;

public static class PartnerContractSeed
{
    public static List<PartnerContract> PartnerContracts()
    {
        Guid partnerContract1 = new Guid("791F5E69-124D-4CF3-9027-AC5532C9C59A");
        Guid partnerContract2 = new Guid("488306DB-7E95-4291-932B-E960F9217DA1");
        Guid partnerContract3 = new Guid("5A7CF61B-176F-430F-8C6F-EACA016234AF");
        Guid partnerContract4 = new Guid("25648D6A-643D-4877-87F6-DAEDE8401870");

        Guid partner1 = new Guid("5B5ABA2C-068C-4850-86AB-A4E2ECA325ED");
        Guid partner2 = new Guid("06500DC8-F77B-417D-BB5D-0D6AC7E3661A");
        Guid partner3 = new Guid("284E5EA4-32DA-4643-84B9-B7A889F9FE78");
        Guid partner4 = new Guid("83975A8C-637D-4CD8-B77E-1493F80A76CB");

        Guid businessContract1 = new Guid("A0DBC67D-C032-46B1-B4E4-372F1AF5280D");
        Guid businessContract2 = new Guid("B13A2A50-9A66-4A01-91EC-9246FF3970C1");
        Guid businessContract3 = new Guid("5928BF0E-F501-4095-9D54-570A2196D59F");
        Guid businessContract4 = new Guid("E6922D3A-B69B-43D0-90F4-EC34DE7B268D");

        return new List<PartnerContract>()
        {
            new PartnerContract
            {
                Id = partnerContract1,
                PartnerId = partner1,
                BusinessContractId = businessContract1,
                CreateDate = DateTime.UtcNow
            },
            new PartnerContract
            {
                Id = partnerContract2,
                PartnerId = partner2,
                BusinessContractId = businessContract2,
                CreateDate = DateTime.UtcNow
            },
            new PartnerContract
            {
                Id = partnerContract3,
                PartnerId = partner3,
                BusinessContractId = businessContract3,
                CreateDate = DateTime.UtcNow
            },
            new PartnerContract
            {
                Id = partnerContract4,
                PartnerId = partner4,
                BusinessContractId = businessContract4,
                CreateDate = DateTime.UtcNow
            }
        };
    }
}
