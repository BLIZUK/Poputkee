using System;
using System.Diagnostics;
using System.IO;

namespace Poputkee.Core.Services;
public static class Logger
{
    // Уровни логирования
    public enum LogLevel
    {
        Debug,
        // Для отладочной информации
        Info,         // Основные события
        Error         // Критические ошибки
    }

    // Текущий уровень (показывать сообщения этого уровня и выше)
    public static LogLevel Level { get; set; } = LogLevel.Debug;

    // Путь к файлу логов (null = не записывать в файл)
    public static string LogFilePath { get; set; }

    // Цвета для консоли
    private static ConsoleColor GetColor(LogLevel level) => level switch
    {
        LogLevel.Debug => ConsoleColor.Gray,
        LogLevel.Info => ConsoleColor.White,
        LogLevel.Error => ConsoleColor.Red,
        _ => ConsoleColor.White
    };

    // Основной метод логирования
    public static void Log(LogLevel level, string message)
    {
        if (level < Level) return;

        // Форматирование сообщения
        var logMessage = $"[{DateTime.Now:HH:mm:ss}] {level}: {message}";

        // Вывод в консоль
        Console.ForegroundColor = GetColor(level);
        Console.WriteLine(logMessage);
        Console.ResetColor();

        // Запись в файл
        if (!string.IsNullOrEmpty(LogFilePath))
        {
            File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
        }
    }

    // Быстрые методы
    public static void LogDebug(string message) => Log(LogLevel.Debug, message);
    public static void LogInfo(string message) => Log(LogLevel.Info, message);
    public static void LogError(string message) => Log(LogLevel.Error, message);
}