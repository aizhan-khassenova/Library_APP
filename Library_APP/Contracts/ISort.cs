using System;

namespace Library_APP
{
    public interface ISort
    {
        void Sort(Func<Book, object> keySelector, string sortBy);
    }
}