namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException : Exception
{
    public BusinessException()
    {
        
    }

    public BusinessException(string? message):base(message) { }
    public BusinessException(string? message, Exception? innerException) : base(message, innerException) { }
    
}

public class ValidationExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}