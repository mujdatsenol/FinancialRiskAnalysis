namespace FinancialRiskAnalysis.Common.Services.Helper;

[Serializable]
    public class ValidationErrorInfo
{
    public ValidationErrorInfo()
    {
    }

    public ValidationErrorInfo(string message)
    {
        this.Message = message;
    }

    public string Message { get; set; }
}
