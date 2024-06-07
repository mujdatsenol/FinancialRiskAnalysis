﻿namespace FinancialRiskAnalysis.Application.Abstractions;

public class RiskAnalysisDto : DtoHasBaseId<Guid>
{
    public Guid BusinessTopicId { get; set; }

    public double RiskScore { get; set; }

    public DateTime AnalysisDate { get; set; }
}