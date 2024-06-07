namespace FinancialRiskAnalysis.Common.Services.Helper;

[Serializable]
public class ErrorInfo
{
    public ErrorInfo()
    {
    }

    public ErrorInfo(string message)
    {
        this.Message = message;
    }

    public ErrorInfo(int code)
    {
        this.Code = code;
    }

    public ErrorInfo(int code, string message)
        : this(message)
    {
        this.Code = code;
    }

    public ErrorInfo(string message, string details)
        : this(message)
    {
        this.Details = details;
    }

    public ErrorInfo(int code, string message, string details)
        : this(message, details)
    {
        this.Code = code;
    }

    public int Code { get; set; }

    public string Details { get; set; }

    public string Message { get; set; }

    public IEnumerable<ValidationErrorInfo> ValidationErrors { get; set; }
}
