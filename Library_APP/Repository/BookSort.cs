using System;
using System.Linq;

namespace Library_APP
{
    public class BookSort : ISort
    {
        private readonly ILog _log;
        private readonly BooksRepository _bookRepository;

        public BookSort(ILog log, BooksRepository bookRepository)
        {
            _log = log;
            _bookRepository = bookRepository;
        }

        //сортировка по ID
        public void SortById()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.Id);
            Console.WriteLine("\nСписок книг отсортированный по Id:\n");
            ViewSortedBooks(sortedBooks);
        }

        //сортировка по названию книги
        public void SortByTitle()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.Title);
            Console.WriteLine("\nСписок книг отсортированный по названию:\n");
            ViewSortedBooks(sortedBooks);
        }

        //сортировка по автору
        public void SortByAuthor()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.Author);
            Console.WriteLine("\nСписок книг отсортированный по автору:\n");
            ViewSortedBooks(sortedBooks);
        }

        //сортировка по году публикации
        public void SortByPubYear()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.PubYear);
            Console.WriteLine("\nСписок книг отсортированный по году публикации:\n");
            ViewSortedBooks(sortedBooks);
        }

        //вывод отсортированных книг
        private void ViewSortedBooks(IOrderedEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}\nНазвание: {book.Title}\nАвтор: {book.Author}\nГод публикации: {book.PubYear}\n");
            }
        }
    }
}