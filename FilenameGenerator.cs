using System;

namespace TextSaver
{
    /// <summary>
    /// Содержит реализацию генерации файла
    /// </summary>
    internal static class FilenameGenerator
    {
        /// <summary>
        /// Генерирует имя файла исходя из текущего времени
        /// В формате DD-MM-YYYY-HH-mm-ss.txt
        /// </summary>
        /// <returns>Строка с результатом</returns>
        public static string GetFilenameFromCurrentDateTime()
        {
            return $"{DateTime.Now.ToString().Replace(':', '-').Replace('.', '-').Replace(' ', '-')}.txt";
        }
    }
}