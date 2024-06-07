using Microsoft.AspNetCore.Http;

namespace FinancialRiskAnalysis.Common.Services.Helper;

public class ServiceResponseHelper : IServiceResponseHelper, IDisposable
{
    ~ServiceResponseHelper()
    { }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public ServiceResponse<T> SetError<T>(T data, string errorMessage, int statusCode = StatusCodes.Status500InternalServerError)
    {
        var error = new ErrorInfo(statusCode, errorMessage);

        return new ServiceResponse<T>(data, error);
    }

    public ServiceResponse SetError(string errorMessage, int statusCode = StatusCodes.Status500InternalServerError)
    {
        var error = new ErrorInfo(statusCode, errorMessage);

        return SetError(error);
    }

    public ServiceResponse SetError(ErrorInfo errorItem)
    {
        return new ServiceResponse(errorItem);
    }

    public ServiceResponse<T> SetError<T>(T data, ErrorInfo errorInfo)
    {
        return new ServiceResponse<T>(data, errorInfo);
    }

    public ServiceResponse SetSuccess()
    {
        return new ServiceResponse();
    }

    public ServiceResponse<T> SetSuccess<T>(T data)
    {
        return new ServiceResponse<T>(data);
    }
}
