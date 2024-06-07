using FinancialRiskAnalysis.Common.Services.Helper;

namespace FinancialRiskAnalysis.Common.Services;

public sealed class ServiceResponse<TResult> : ServiceResponse
{
    public ServiceResponse(TResult result, bool isSuccessful = true)
        : base(isSuccessful)
    {
        this.Result = result;
    }

    public ServiceResponse(TResult result, ErrorInfo error, bool isSuccessful = false)
        : base(error, isSuccessful)
    {
        this.Result = result;
    }

    public TResult Result { get; set; }
}
