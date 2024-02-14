using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_APP
{
    //класс BooksRepository реализующий интерфейс IBook, содержит список книг и экземпляр интерфейса ILog для журналирования
    public class BooksRepository : IBook
    {
        private readonly ILog _log;
        public List<Book> books { get; set; }

        //конструктор инициализирующий репозиторий книг начальным списком книг
        public BooksRepository(ILog log) {
            _log = log;

            books = new List<Book>()
            {
                new Book { Id = 1, Title = "Властелин Колец", Author = "Дж. Р. Р. Толкин", PubYear = 1954},
                new Book { Id = 2, Title = "Гарри Поттер и философский камень", Author = "Джоан Роулинг", PubYear = 1997},
                new Book { Id = 3, Title = "Преступление и наказание", Author = "Федор Достоевский", PubYear = 1866},
                new Book { Id = 4, Title = "Война и мир", Author = "Лев Толстой", PubYear = 1869},
            };
        }

        //метод выводящий в консоль информацию о каждой книге и возвращающий список книг
        public List<Book> ReadBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}\nНазвание: {book.Title}\nАвтор: {book.Author}\nГод публикации: {book.PubYear}\n");
            }

            return books;
        }

        //метод добавляющий новую книгу в репозиторий
        public void CreateBook()
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();
            Console.Write("Введите год публикации книги: ");
            int pubYear;

            while (!int.TryParse(Console.ReadLine(), out pubYear) || pubYear <= 0)
            {
                Console.Write("Год публикации должен быть положительным числом. Пожалуйста, введите снова: ");
            }

            int id = books.Count + 1;
            Book newBook = new Book { Id = id, Title = title, Author = author, PubYear = pubYear };
            books.Add(newBook);

            string message = $"Добавлена новая книга: '{title}' (Автор: {author}, Год: {pubYear})";
            Console.WriteLine(message);
            _log.Log(message);
        }

        //метод обновляющий информацию о книге в репозитории
        public void UpdateBook()
        {
            Console.Write("Введите ID книги, которую вы хотите обновить: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите положительное целое число: ");
            }

            Book bookToUpdate = books.FirstOrDefault(book => book.Id == id);

            if (bookToUpdate == null)
            {
                Console.WriteLine($"Книга с ID {id} не найдена.");
                return;
            }

            Console.WriteLine($"Текущая информация о книге:");
            Console.WriteLine($"ID: {bookToUpdate.Id}, Название: {bookToUpdate.Title}, Автор: {bookToUpdate.Author}, Год публикации: {bookToUpdate.PubYear}");
            Console.Write("Введите новое название книги (нажмите Enter, чтобы оставить без изменений): ");
            string newTitle = Console.ReadLine();

            if (!string.IsNullOrEmpty(newTitle))
            {
                bookToUpdate.Title = newTitle;
            }

            Console.Write("Введите нового автора книги (нажмите Enter, чтобы оставить без изменений): ");
            string newAuthor = Console.ReadLine();

            if (!string.IsNullOrEmpty(newAuthor))
            {
                bookToUpdate.Author = newAuthor;
            }

            Console.Write("Введите новый год публикации книги (нажмите Enter, чтобы оставить без изменений): ");
            string pubYearInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(pubYearInput))
            {
                int newPubYear;

                if (int.TryParse(pubYearInput, out newPubYear) && newPubYear > 0)
                {
                    bookToUpdate.PubYear = newPubYear;
                }
                else
                {
                    Console.WriteLine("Неверный формат года публикации. Год должен быть положительным числом.");
                }
            }

            string message = $"Книга с ID {id} успешно обновлена.";
            Console.WriteLine(message);
            _log.Log(message);
        }

        //метод удаляющий книгу из репозитория
        public void DeleteBook()
        {
            Console.Write("Введите ID книги, которую вы хотите удалить: ");
            int idToDelete;

            while (!int.TryParse(Console.ReadLine(), out idToDelete) || idToDelete <= 0)
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите положительное целое число: ");
            }

            Book bookToDelete = books.FirstOrDefault(book => book.Id == idToDelete);

            if (bookToDelete == null)
            {
                Console.WriteLine($"Книга с ID {idToDelete} не найдена.");
                return;
            }

            books.Remove(bookToDelete);

            string message = $"Книга с ID {idToDelete} успешно удалена.";
            Console.WriteLine(message);
            _log.Log(message);
        }
    }
}