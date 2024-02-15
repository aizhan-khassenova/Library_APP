using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_APP
{
    //класс BooksRepository реализует репозиторий книг
    //применены технология LINQ и паттерны проектирования Repository и Command 
    public class BooksRepository : IBook
    {
        private readonly ILog _log;
        public List<Book> books { get; set; }

        public BooksRepository(ILog log) {
            _log = log;

            //начальный список книг
            books = new List<Book>()
            {
                new Book { Id = 1, Title = "Властелин Колец", Author = "Дж. Р. Р. Толкин", PubYear = 1954},
                new Book { Id = 2, Title = "Гарри Поттер и философский камень", Author = "Джоан Роулинг", PubYear = 1997},
                new Book { Id = 3, Title = "Преступление и наказание", Author = "Федор Достоевский", PubYear = 1866},
                new Book { Id = 4, Title = "Война и мир", Author = "Лев Толстой", PubYear = 1869},
            };
        }

        //вывод всех книг
        public List<Book> ReadBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}\nНазвание: {book.Title}\nАвтор: {book.Author}\nГод публикации: {book.PubYear}\n");
            }

            return books;
        }

        //создание книги
        public void CreateBook()
        {
            Console.Write("Введите название: ");
            string title = Console.ReadLine();

            while (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write("Введите название: ");
                title = Console.ReadLine();
            }

            Console.Write("Введите автора: ");
            string author = Console.ReadLine();

            while (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write("Введите автора: ");
                author = Console.ReadLine();
            }

            Console.Write("Введите год публикации: ");
            int pubYear;

            while (!int.TryParse(Console.ReadLine(), out pubYear) || pubYear <= 0)
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write("Введите год публикации: ");
            }

            int id = books.Count + 1;
            Book newBook = new Book { Id = id, Title = title, Author = author, PubYear = pubYear };
            books.Add(newBook);
            string message = $"\nУспешно добавлена книга с ID {id}!\n";
            Console.WriteLine(message);
            _log.Log(message);
        }

        //обновление книги
        public void UpdateBook()
        {
            Console.Write("Введите ID: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write("Введите ID: ");
            }

            Book bookToUpdate = books.FirstOrDefault(book => book.Id == id);

            if (bookToUpdate == null)
            {
                Console.WriteLine($"\nКнига не найдена!\n");
                return;
            }

            Console.WriteLine($"\nОбновляемая книга:\n");
            Console.WriteLine($"ID: {bookToUpdate.Id}\nНазвание: {bookToUpdate.Title}\nАвтор: {bookToUpdate.Author}\nГод публикации: {bookToUpdate.PubYear}\n");
            Console.WriteLine("Чтобы оставить без изменений нажмите Enter!\n");
            Console.Write("Введите название: ");
            string newTitle = Console.ReadLine();

            if (!string.IsNullOrEmpty(newTitle))
            {
                bookToUpdate.Title = newTitle;
            }

            Console.Write("Введите автора: ");
            string newAuthor = Console.ReadLine();

            if (!string.IsNullOrEmpty(newAuthor))
            {
                bookToUpdate.Author = newAuthor;
            }

            int pubYear;

            while (true)
            {
                Console.Write("Введите год публикации: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                if (!int.TryParse(input, out pubYear) || pubYear <= 0)
                {
                    Console.WriteLine("Некорректный ввод!");
                }
                else
                {
                    bookToUpdate.PubYear = pubYear;
                    break;
                }
            }

            string message = $"\nУспешно обновлена книга с ID {bookToUpdate.Id}!\n";
            Console.WriteLine(message);
            _log.Log(message);
        }

        //удаление книги
        public void DeleteBook()
        {
            Console.Write("Введите ID: ");
            int idToDelete;

            while (!int.TryParse(Console.ReadLine(), out idToDelete) || idToDelete <= 0)
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write("Введите ID: ");
            }

            Book bookToDelete = books.FirstOrDefault(book => book.Id == idToDelete);

            if (bookToDelete == null)
            {
                Console.WriteLine($"\nКнига не найдена!\n");
                return;
            }

            Console.WriteLine($"\nУдаляемая книга:\n");
            Console.WriteLine($"ID: {bookToDelete.Id}\nНазвание: {bookToDelete.Title}\nАвтор: {bookToDelete.Author}\nГод публикации: {bookToDelete.PubYear}");
            Console.Write($"\nУдалить книгу с ID {idToDelete} [да/нет]? ");
            string confirmation = Console.ReadLine().ToLower();

            while (confirmation != "да" && confirmation != "нет")
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write($"\nУдалить книгу с ID {idToDelete} [да/нет]? ");
                confirmation = Console.ReadLine().ToLower();
            }

            if (confirmation == "да")
            {
                books.Remove(bookToDelete);
                string message = $"\nУспешно удалена книга с ID {idToDelete}!\n";
                Console.WriteLine(message);
                _log.Log(message);
            }
            else
            {
                Console.WriteLine("\nУдаление отменено!\n");
            }
        }
    }
}