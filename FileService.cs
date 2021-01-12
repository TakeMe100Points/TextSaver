using System;
using System.IO;


namespace TextSaver
{
    /// <summary>
    /// Предоставляет функции работы с файлом 
    /// </summary>
    internal class FileService
    {     
        /// <summary>
        /// Получить размер файла по имени
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Размер файла в long</returns>
        public static long GetFileSize(string filename)
        {
            try
            {
                FileInfo info = new FileInfo(filename);
                return info.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get file size error: " + ex.ToString());
                return -1;
            }            
        }        
    }
}
