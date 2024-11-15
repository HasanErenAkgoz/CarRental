using System.Text.Json;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.SeriLog;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Pipelines.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>,  ILoggableRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LoggerServiceBase _loggerService;

    public LoggingBehavior(LoggerServiceBase loggerService, IHttpContextAccessor httpContextAccessor)
    {
        _loggerService = loggerService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
       List<LogParameter> logParameters =
            new()
            {
                new LogParameter{Type= request.GetType().Name, Value= request },
            };
       LogDetail logDetail
           = new()
           {
               MethodName = next.Method.Name,
               LogParameters = logParameters,
               User = _httpContextAccessor.HttpContext.User.Identity?.Name??"?"
           };

       _loggerService.Info(JsonSerializer.Serialize(logDetail));
       return await next();
    }
}