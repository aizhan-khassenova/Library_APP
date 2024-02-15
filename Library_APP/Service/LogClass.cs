namespace Library_APP
{
    //класс для логирования
    //применение принципа программирования Dependency Injection
    public class LogClass
    {
        private ILog _log;

        public LogClass(ILog log)
        {
            _log = log;
        }

        //метод для записи лога
        public void Log(string message)
        {
            _log.Log(message);
        }
    }
}