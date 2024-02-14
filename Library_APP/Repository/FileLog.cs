using System;
using System.IO;

namespace Library_APP
{
    //класс для записи логов в файл
    public class FileLog : ILog
    {
        private string _filePath;

        public FileLog(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(_filePath, $"[{DateTime.Now:HH:mm:ss dd.MM.yyyy}] - {message}\n");
        }
    }
}