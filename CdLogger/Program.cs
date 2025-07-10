using System.Runtime.CompilerServices;

namespace cdlog;

public static class Logger
{
    public enum LogLevel
    {
        Info,
        Warn,
        Error,
        Debug
    }

    public static void Log(
        string message,
        LogLevel level = LogLevel.Info,
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        var prevColor = Console.ForegroundColor;

        var timestamp = DateTime.Now.ToString("[dd-MM-yyyy HH:mm:ss]");

        var fileName = Path.GetFileName(sourceFilePath);

        Console.ForegroundColor = level switch
        {
            LogLevel.Info => ConsoleColor.Green,
            LogLevel.Warn => ConsoleColor.DarkYellow,
            LogLevel.Error => ConsoleColor.Red,
            LogLevel.Debug => ConsoleColor.Cyan,
            _ => ConsoleColor.White
        };

        Console.Write($"{timestamp} ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($"[{fileName}:{sourceLineNumber}] ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"[{level.ToString().ToLower()}] ");
        Console.ForegroundColor = prevColor;
        Console.WriteLine(message);
    }
}