using FinancialRiskAnalysis.Common.Services.Helper;

namespace FinancialRiskAnalysis.Common.Services;

[Serializable]
public class ServiceResponse
{
    public ServiceResponse(bool isSuccessful = true)
    {
        this.IsSuccessful = isSuccessful;
    }

    public ServiceResponse(ErrorInfo error, bool isSuccessfull = false)
    {
        this.Error = error;
        this.IsSuccessful = isSuccessfull;
    }

    public ErrorInfo Error { get; set; }

    public bool IsSuccessful { get; set; }
}
