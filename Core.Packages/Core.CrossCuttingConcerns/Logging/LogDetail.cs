namespace Core.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string FullName { get; set; }
    public string MethodName { get; set; }
    public string User { get; set; }
    public List<LogParameter> LogParameters { get; set; }

    public LogDetail()
    {
        FullName = string.Empty;
        MethodName = string.Empty;
        User = string.Empty;
        LogParameters = new List<LogParameter>();
    }
    
    public LogDetail(string fullName, string methodName, string user, List<LogParameter> logParameters)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        MethodName = methodName ?? throw new ArgumentNullException(nameof(methodName));
        User = user ?? throw new ArgumentNullException(nameof(user));
        LogParameters = logParameters ?? throw new ArgumentNullException(nameof(logParameters));
    }
}