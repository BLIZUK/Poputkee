using System;
using System.IO;

/*
Дополнительные возможности для расширения:
 - Добавить поддержку форматов логов (JSON, XML)
 - Реализовать ротацию лог-файлов
 - Добавить фильтрацию по категориям
 - Реализовать асинхронную запись 
 - Добавить метрики производительности
 */

namespace Poputkee.Core.Services;

/// <summary>
/// Статический класс для логирования сообщений в консоль и файл
/// </summary>
public static class Logger
{
    #region Logging Configuration

    /// <summary>
    /// Уровни важности логируемых сообщений
    /// </summary>
    public enum LogLevel
    {
        /// <summary>Отладочная информация</summary>
        Debug,
        /// <summary>Основные события приложения</summary>
        Info,
        /// <summary>Критические ошибки</summary>
        Error
    }

    /// <summary>
    /// Текущий минимальный уровень логирования (по умолчанию Debug)
    /// </summary>
    public static LogLevel Level { get; set; } = LogLevel.Debug;

    /// <summary>
    /// Путь к файлу для записи логов (null - запись в файл отключена)
    /// </summary>
    public static string LogFilePath { get; set; }

    #endregion

    #region Private Helpers

    /// <summary>
    /// Получение цвета консоли для разных уровней логирования
    /// </summary>
    private static ConsoleColor GetColor(LogLevel level) => level switch
    {
        LogLevel.Debug => ConsoleColor.Gray,
        LogLevel.Info => ConsoleColor.White,
        LogLevel.Error => ConsoleColor.Red,
        _ => ConsoleColor.White
    };

    #endregion

    #region Public Interface

    /// <summary>
    /// Основной метод логирования
    /// </summary>
    /// <param name="level">Уровень важности сообщения</param>
    /// <param name="message">Текст сообщения</param>
    public static void Log(LogLevel level, string message)
    {
        if (level < Level) return;

        var logMessage = $"[{DateTime.Now:HH:mm:ss}] {level}: {message}";

        WriteToConsole(logMessage, level);
        WriteToFile(logMessage);
    }

    /// <summary>Логирование отладочной информации</summary>
    public static void LogDebug(string message) => Log(LogLevel.Debug, message);

    /// <summary>Логирование информационного сообщения</summary>
    public static void LogInfo(string message) => Log(LogLevel.Info, message);

    /// <summary>Логирование ошибки</summary>
    public static void LogError(string message) => Log(LogLevel.Error, message);

    #endregion

    #region Output Methods

    /// <summary>
    /// Вывод сообщения в консоль с цветом
    /// </summary>
    private static void WriteToConsole(string message, LogLevel level)
    {
        Console.ForegroundColor = GetColor(level);
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Запись сообщения в файл логов
    /// </summary>
    private static void WriteToFile(string message)
    {
        if (!string.IsNullOrEmpty(LogFilePath))
        {
            try
            {
                File.AppendAllText(LogFilePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в лог-файл: {ex.Message}");
            }
        }
    }

    #endregion
}