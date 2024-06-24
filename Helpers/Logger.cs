namespace DGII_Connect;
using System;
using System.IO;

public static class Logger
{
    private static readonly object _lock = new();
    private static readonly string _logFilePath = "./application.log";

    public static void LogInfo(string message)
    {
        Log("INFO", message);
    }

    public static void LogError(string message)
    {
        Log("ERROR", message);
    }

    public static void LogWarning(string message)
    {
        Log("WARNING", message);
    }

    private static void Log(string level, string message)
    {
        lock (_lock)
        {
            using (StreamWriter writer = new(_logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}");
            }
        }
    }
}
