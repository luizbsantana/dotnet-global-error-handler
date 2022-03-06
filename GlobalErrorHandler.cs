using System.Net;
using ls_global_error_handler.CustomExceptions;
using ls_global_error_handler.Models;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace ls_global_error_handler;
public class GlobalErrorHandler
{
    private readonly RequestDelegate _requestDelegate;
    private readonly ILogger _logger;

    public GlobalErrorHandler(RequestDelegate requestDelegate, ILogger logger)
    {
        _requestDelegate = requestDelegate;
        _logger = logger;
    }

    public async Task RequestHandlerAsync(HttpContext httpContext)
    {
        try
        {
            await _requestDelegate(httpContext);
        }
        catch (DomainException ex)
        {
            await HandleExceptionAsync(httpContext, ex, new ErrorResponse(ex.StatusCode, ex.Message));
        }
        catch (BusinessException ex)
        {
            await HandleExceptionAsync(httpContext, ex, new ErrorResponse(ex.StatusCode, ex.Message));
        }
        catch (Exception ex)
        {
            _logger.Error(ex, ex.Message);
            await HandleExceptionAsync(httpContext, ex,
                new ErrorResponse(HttpStatusCode.InternalServerError, string.Empty));
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, ErrorResponse errorResponse)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)errorResponse.StatusCode;

        await context.Response.WriteAsync(errorResponse.ToString());
    }
}
