using System.Collections.Generic;

namespace Library_APP
{
    public interface IBook {
        public List<Book> ReadBooks();
        public void CreateBook();
        public void UpdateBook();
        public void DeleteBook();
    }
}