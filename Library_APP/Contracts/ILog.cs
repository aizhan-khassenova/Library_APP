namespace Library_APP
{
    //интерфейс для логирования событий
    //применены паттерны проектирования Strategy и Observer 
    public interface ILog
    {
        public void Log(string message);
    }
}