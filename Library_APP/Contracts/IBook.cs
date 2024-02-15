using System.Collections.Generic;

namespace Library_APP
{
    //интерфейс IBook определяет контракты для работы с книгами
    public interface IBook {
        public List<Book> ReadBooks();
        public void CreateBook();
        public void UpdateBook();
        public void DeleteBook();
    }
}