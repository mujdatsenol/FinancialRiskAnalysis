using FinancialRiskAnalysis.Domain;

namespace FinancialRiskAnalysis.Persistence;

public static class RiskAnalysisSeed
{
    public static List<RiskAnalysis> RiskAnalyses()
    {
        Guid riskAnalysis1 = new Guid("85015A94-693B-4418-A164-FF437599FE9E");
        Guid riskAnalysis2 = new Guid("BA175A89-0E8B-481A-AEBA-32D7599A4AFE");
        Guid riskAnalysis3 = new Guid("F4115479-0078-4F1D-8438-960315985F86");
        Guid riskAnalysis4 = new Guid("9263E450-A593-4506-8E19-B6AC0DF0F0C8");

        Guid businessTopic1 = new Guid("C541A1CF-90D3-48D9-8FBC-93D42A984CFF");
        Guid businessTopic2 = new Guid("56C98E67-275D-41FB-9662-CD557F3A4449");
        Guid businessTopic3 = new Guid("3E00F72C-6B01-41DD-85DE-0D7876E36DD4");
        Guid businessTopic4 = new Guid("73085F06-9B59-444C-BC73-559501584122");

        return new List<RiskAnalysis>()
        {
            new RiskAnalysis
            {
                Id = riskAnalysis1,
                BusinessTopicId = businessTopic1,
                RiskScore = 15.8,
                AnalysisDate = DateTime.UtcNow.AddDays(5),
                CreateDate = DateTime.UtcNow,
            },
            new RiskAnalysis
            {
                Id = riskAnalysis2,
                BusinessTopicId = businessTopic2,
                RiskScore = 30.1,
                AnalysisDate = DateTime.UtcNow.AddMonths(1),
                CreateDate = DateTime.UtcNow
            },
            new RiskAnalysis
            {
                Id = riskAnalysis3,
                BusinessTopicId = businessTopic3,
                RiskScore = 75,
                AnalysisDate = DateTime.UtcNow.AddDays(3),
                CreateDate = DateTime.UtcNow
            },
            new RiskAnalysis
            {
                Id = riskAnalysis4,
                BusinessTopicId = businessTopic4,
                RiskScore = 53.4,
                AnalysisDate = DateTime.UtcNow.AddDays(7),
                CreateDate = DateTime.UtcNow
            }
        };
    }
}
