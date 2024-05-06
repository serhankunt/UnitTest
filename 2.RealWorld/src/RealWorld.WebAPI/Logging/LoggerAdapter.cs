namespace RealWorld.WebAPI.Logging;

public sealed class LoggerAdapter<TType>(
    ILogger<TType> logger) : ILoggerAdapter<TType>
{
    public void LogError(Exception? exception, string? message, params object?[] args)
    {
        logger.LogError(exception, message, args);
    }

    public void LogInformation(string? message, params object?[] args)
    {
        logger.LogInformation(message, args);
    }
}
