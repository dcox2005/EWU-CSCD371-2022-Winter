using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? baseLogger, string message, params object?[] args)
    {
        if(baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

        string? str = String.Format(message, args); 
        baseLogger.Log(LogLevel.Error, str);
    }

    public static void Warning(this BaseLogger? baseLogger, string message, params object?[] args)
    {
        if (baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

        string? str = String.Format(message, args);
        baseLogger.Log(LogLevel.Warning, str);
    }

    public static void Information(this BaseLogger? baseLogger, string message, params object?[] args)
    {
        if (baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

        string? str = String.Format(message, args);
        baseLogger.Log(LogLevel.Information, str);
    }

    public static void Debug(this BaseLogger? baseLogger, string message, params object?[] args)
    {
        if (baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

        string? str = String.Format(message, args);
        baseLogger.Log(LogLevel.Debug, str);
    }
}
