using System;
using System.IO;

namespace Library_APP
{
    //класс FileLog реализует интерфейс ILog и представляет собой логгер, который записывает сообщения в файл
    public class FileLog : ILog
    {
        private string _filePath;

        public FileLog(string filePath)
        {
            _filePath = filePath;
        }

        //метод Log() записывает сообщение с текущим временем в формате[HH:mm:ss dd.MM.yyyy] в указанный файл
        public void Log(string message)
        {
            File.AppendAllText(_filePath, $"[{DateTime.Now:HH:mm:ss dd.MM.yyyy}] - {message}\n");
        }
    }
}