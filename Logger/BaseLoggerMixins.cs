using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? baseLogger, string? message, params object?[] args)
    {
        if(baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

    }

    public static void Warning(this BaseLogger? baseLogger, string? message, params object?[] args)
    {
        if (baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

    }

    public static void Information(this BaseLogger? baseLogger, string? message, params object?[] args)
    {
        if (baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

    }

    public static void Debug(this BaseLogger? baseLogger, string? message, params object?[] args)
    {
        if (baseLogger is null) throw new ArgumentNullException(nameof(BaseLogger));

    }
}
