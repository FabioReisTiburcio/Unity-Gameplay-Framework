using System;
using UnityEngine;
namespace GameplayFramework.Core.Logging
{
    /// <summary>
    /// Logs info, warning and error messages to the Unity console using the framework name as a prefix.
    /// </summary>
    public static class FrameworkLogger
    {
        public static void Info(string message)
        {
            Log(message, LogLevel.Info);
        }
        public static void Warning(string message)
        {

            Log(message, LogLevel.Warning);
        }
        public static void Error(string message)
        {
            Log(message, LogLevel.Error);
        }
        public static void Error(Exception exception)
        {
            Log(exception.ToString(), LogLevel.Error);
        }

        private static void Log(string message, LogLevel level)
        {
            string logMessage = $"[{FrameworkInfo.Name}] {message}";
            switch (level)
            {
                case LogLevel.Info:
                    Debug.Log(logMessage);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(logMessage);
                    break;
                case LogLevel.Error:
                    Debug.LogError(logMessage);
                    break;
            }

        }
    }
}
