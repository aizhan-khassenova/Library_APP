using System;
using System.IO;

namespace Library_APP
{
    public class Program
    {
        //применение паттерна проектирования Factory Method
        public static void Main(string[] args)
        {
            //создание пути к файлу журнала log.txt
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath = Path.Combine(rootPath, "log.txt");

            //запуск приложения
            ProgramRunner runner = new ProgramRunner(logFilePath);
            runner.Run();
        }
    }
}