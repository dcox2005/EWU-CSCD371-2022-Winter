using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }


        public override void Log(LogLevel logLevel, string message)
        {
            using StreamWriter file = new(FilePath, append: true);
            string currentTime = DateTime.Now.ToString();
            string log = $"{currentTime} {ClassName} {logLevel}: {message}";
            file.WriteLine(log);
        }
    }
}