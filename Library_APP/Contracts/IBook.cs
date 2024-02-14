using System.Collections.Generic;

namespace Library_APP
{
    //интерфейс определяющий контракты для чтения, создания, обновления и удаления книг
    public interface IBook {
        public List<Book> ReadBooks();
        public void CreateBook();
        public void UpdateBook();
        public void DeleteBook();
    }
}