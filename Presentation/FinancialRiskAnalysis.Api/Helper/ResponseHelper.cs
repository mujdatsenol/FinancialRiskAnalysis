#pragma warning disable CS8602 // Dereference of a possibly null reference.

using FinancialRiskAnalysis.Common.Services;
using FinancialRiskAnalysis.Common.Services.Helper;

namespace FinancialRiskAnalysis.Api;

public static class ResponseHelper
{
    private static IServiceResponseHelper? serviceResponseHelper;

    public static TBuilder WithServiceResponse<TBuilder>(this TBuilder builder, WebApplication app)
        where TBuilder : IEndpointConventionBuilder
    {
        serviceResponseHelper = app.Services.GetRequiredService<IServiceResponseHelper>();
        CheckServiceResponse();
        return builder;
    }

    public static void CheckServiceResponse()
    {
        if (serviceResponseHelper == null)
        {
            throw new ArgumentNullException(nameof(serviceResponseHelper),
                "If you need use ResponseHelper you must do IServiceResponseHelper register to services. Is already registered then use WithServiceResponse() with RouteHandlerBuilder available methods.");
        }
    }

    public static ServiceResponse Success()
    {
        CheckServiceResponse();
        return serviceResponseHelper.SetSuccess();
    }

    public static ServiceResponse<T> Success<T>(T data)
    {
        CheckServiceResponse();
        return serviceResponseHelper.SetSuccess(data);
    }

    public static ServiceResponse<T> Error<T>(T data, string errorMessage, int statusCode = StatusCodes.Status500InternalServerError)
    {
        CheckServiceResponse();
        return serviceResponseHelper.SetError(data, errorMessage, statusCode);
    }

    public static ServiceResponse Error(string errorMessage, int statusCode = StatusCodes.Status500InternalServerError)
    {
        CheckServiceResponse();
        return serviceResponseHelper.SetError(errorMessage, statusCode);
    }

    public static ServiceResponse Error(ErrorInfo error)
    {
        CheckServiceResponse();
        return serviceResponseHelper.SetError(error);
    }
}
