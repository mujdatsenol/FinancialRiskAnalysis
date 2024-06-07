using Microsoft.AspNetCore.Http;

namespace FinancialRiskAnalysis.Common.Services.Helper;

public interface IServiceResponseHelper : IService
{
    ServiceResponse SetSuccess();

    ServiceResponse<T> SetSuccess<T>(T data);

    ServiceResponse<T> SetError<T>(T data, string errorMessage, int statusCode = StatusCodes.Status500InternalServerError);

    ServiceResponse SetError(string errorMessage, int statusCode = StatusCodes.Status500InternalServerError);

    ServiceResponse SetError(ErrorInfo errorItem);

    ServiceResponse<T> SetError<T>(T data, ErrorInfo errorInfo);
}
