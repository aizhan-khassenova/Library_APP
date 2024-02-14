namespace Library_APP
{
    //класс LogClass принимает интерфейс ILog в качестве зависимости в конструкторе
    public class LogClass
    {
        private ILog _log;

        public LogClass(ILog log)
        {
            _log = log;
        }

        //метод Log() вызывает метод Log() объекта _log, который обрабатывает сообщение в соответствии с реализацией интерфейса ILog
        public void Log(string message)
        {
            _log.Log(message);
        }
    }
}