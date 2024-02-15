using System;

namespace Library_APP
{
    //интерфейс для сортировки книг
    //применение паттерна проектирования Strategy
    public interface ISort
    {
        void Sort(Func<Book, object> keySelector, string sortBy);
    }
}