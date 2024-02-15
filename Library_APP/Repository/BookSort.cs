using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_APP
{
    //класс для сортировки книг
    //применена технология LINQ и паттерн проектирования Strategy
    public class BookSort : ISort
    {
        private readonly ILog _log;
        private readonly BooksRepository _bookRepository;

        public BookSort(ILog log, BooksRepository bookRepository)
        {
            _log = log;
            _bookRepository = bookRepository;
        }

        //сортировка книг по параметру
        public void Sort(Func<Book, object> keySelector, string sortBy)
        {
            var books = _bookRepository.books;
            var sortedBooks = books.OrderBy(keySelector);
            Console.WriteLine($"\nСписок книг отсортированный по {sortBy}:\n");
            ViewSortedBooks(sortedBooks);
        }

        //вывод отсортированных книг
        private void ViewSortedBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}\nНазвание: {book.Title}\nАвтор: {book.Author}\nГод публикации: {book.PubYear}\n");
            }
        }
    }
}