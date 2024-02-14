using System;
using System.IO;

namespace Library_APP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //определение пути к каталогу, в котором запущена программа
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //создание полного пути к файлу журнала log.txt, комбинирующий rootPath и имя файла
            string logFilePath = Path.Combine(rootPath, "log.txt");

            //создание экземпляра класса ProgramRunner, передавая ему путь к файлу журнала в качестве аргумента конструктора
            ProgramRunner runner = new ProgramRunner(logFilePath);
            //вызов метода Run() объекта runner, который запускает основную логику приложения
            runner.Run();
        }
    }
}