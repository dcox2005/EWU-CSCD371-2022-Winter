namespace Logger;

public class LogFactory
{
    private string? _FilePath;

    public string? FilePath { get => _FilePath; }

    public BaseLogger? CreateLogger(string className)
    {
        if (_FilePath is null)
        {
            return null;
        }

        FileLogger newFileLogger = new FileLogger(_FilePath!)
        {
            ClassName = className
        };

        return newFileLogger;
    }

    public void configureFileLogger(string filePath)
    {
        _FilePath = filePath;
    }
}
