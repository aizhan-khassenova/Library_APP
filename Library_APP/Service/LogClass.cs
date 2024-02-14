namespace Library_APP
{
    public class LogClass
    {
        private ILog _log;

        public LogClass(ILog log)
        {
            _log = log;
        }

        //обработка логов
        public void Log(string message)
        {
            _log.Log(message);
        }
    }
}