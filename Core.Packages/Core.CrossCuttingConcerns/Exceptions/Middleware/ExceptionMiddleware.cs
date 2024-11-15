using System.Text.Json;
using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.SeriLog;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly HttpContextAccessor _httpContextAccessor;
    private readonly LoggerServiceBase _loggerService ;

    public ExceptionMiddleware(RequestDelegate next, HttpContextAccessor httpContextAccessor, LoggerServiceBase loggerService)
    {
        _next = next;
        _httpContextAccessor = new HttpContextAccessor();
        _loggerService = loggerService;
        _httpExceptionHandler = new HttpExceptionHandler();
    }

    public async Task Invoke(HttpContext context) 
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await LogException(context, exception);
            await HandleExceptionAsync(context.Response, exception);
        }
    }
 
    private  Task LogException(HttpContext context, Exception exception)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter{Type= context.GetType().Name, Value= exception },
        };
        
        LogDetailWithException logDetail
            = new()
            {
                MethodName = _next.Method.Name,
                LogParameters = logParameters,
                ExceptionMessage = exception.Message,
                User = _httpContextAccessor.HttpContext.User.Identity?.Name??"?"
            };
        
        _loggerService.Error(JsonSerializer.Serialize(logDetail));
        return Task.CompletedTask;
    }


    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _httpExceptionHandler.Response = response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }
}