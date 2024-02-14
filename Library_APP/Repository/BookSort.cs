using System;
using System.Linq;

namespace Library_APP
{
    //класс BookSort реализующий интерфейс ISort и содержит экземпляры интерфейсов ILog и BooksRepository
    public class BookSort : ISort
    {
        private readonly ILog _log;
        private readonly BooksRepository _bookRepository;

        //конструктор класса BookSort принимает интерфейс ILog и класс BooksRepository, чтобы инициализировать соответствующие поля
        public BookSort(ILog log, BooksRepository bookRepository)
        {
            _log = log;
            _bookRepository = bookRepository;
        }

        //метод SortById() сортирует книги по идентификатору и выводит отсортированный список в консоль
        public void SortById()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.Id);
            Console.WriteLine("Список книг (отсортированный по Id):");
            ViewSortedBooks(sortedBooks);
        }

        //метод SortByTitle() сортирует книги по названию и выводит отсортированный список в консоль
        public void SortByTitle()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.Title);
            Console.WriteLine("Список книг (отсортированный по названию):");
            ViewSortedBooks(sortedBooks);
        }

        //метод SortByAuthor() сортирует книги по автору и выводит отсортированный список в консоль
        public void SortByAuthor()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.Author);
            Console.WriteLine("Список книг (отсортированный по автору):");
            ViewSortedBooks(sortedBooks);
        }

        //метод SortByPubYear() сортирует книги по году публикации и выводит отсортированный список в консоль
        public void SortByPubYear()
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(book => book.PubYear);
            Console.WriteLine("Список книг (отсортированный по году публикации):");
            ViewSortedBooks(sortedBooks);
        }

        //приватный метод ViewSortedBooks() выводит отсортированные книги на консоль
        private void ViewSortedBooks(IOrderedEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}\nНазвание: {book.Title}\nАвтор: {book.Author}\nГод публикации: {book.PubYear}\n");
            }
        }
    }
}