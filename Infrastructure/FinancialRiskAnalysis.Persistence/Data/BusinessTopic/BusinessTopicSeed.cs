using FinancialRiskAnalysis.Domain;

namespace FinancialRiskAnalysis.Persistence;

public static class BusinessTopicSeed
{
    public static List<BusinessTopic> BusinessTopics()
    {
        Guid businessTopic1 = new Guid("C541A1CF-90D3-48D9-8FBC-93D42A984CFF");
        Guid businessTopic2 = new Guid("56C98E67-275D-41FB-9662-CD557F3A4449");
        Guid businessTopic3 = new Guid("3E00F72C-6B01-41DD-85DE-0D7876E36DD4");
        Guid businessTopic4 = new Guid("73085F06-9B59-444C-BC73-559501584122");

        Guid partner1 = new Guid("5B5ABA2C-068C-4850-86AB-A4E2ECA325ED");
        Guid partner2 = new Guid("06500DC8-F77B-417D-BB5D-0D6AC7E3661A");
        Guid partner3 = new Guid("284E5EA4-32DA-4643-84B9-B7A889F9FE78");
        Guid partner4 = new Guid("83975A8C-637D-4CD8-B77E-1493F80A76CB");

        Guid businessContract1 = new Guid("A0DBC67D-C032-46B1-B4E4-372F1AF5280D");
        Guid businessContract2 = new Guid("B13A2A50-9A66-4A01-91EC-9246FF3970C1");
        Guid businessContract3 = new Guid("5928BF0E-F501-4095-9D54-570A2196D59F");
        Guid businessContract4 = new Guid("5928BF0E-F501-4095-9D54-570A2196D59F");

        return new List<BusinessTopic>()
        {
            new BusinessTopic
            {
                Id = businessTopic1,
                PartnerId = partner1,
                BusinessContractId = businessContract1,
                Title = "İş Konusu 1",
                Description = "1. İş Konusu",
                CreateDate = DateTime.UtcNow
            },
            new BusinessTopic
            {
                Id = businessTopic2,
                PartnerId = partner2,
                BusinessContractId = businessContract2,
                Title = "İş Konusu 2",
                Description = "2. İş Konusu",
                CreateDate = DateTime.UtcNow
            },
            new BusinessTopic
            {
                Id = businessTopic3,
                PartnerId = partner3,
                BusinessContractId = businessContract3,
                Title = "İş Konusu 3",
                Description = "3. İş Konusu",
                CreateDate = DateTime.UtcNow
            },
            new BusinessTopic
            {
                Id = businessTopic4,
                PartnerId = partner4,
                BusinessContractId = businessContract4,
                Title = "İş Konusu 4",
                Description = "4. İş Konusu",
                CreateDate = DateTime.UtcNow
            }
        };
    }
}
