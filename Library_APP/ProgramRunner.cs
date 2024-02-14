using System;

namespace Library_APP
{
    //основное меню приложения
    public class ProgramRunner
    {
        private readonly ILog _log;

        public ProgramRunner(string logFilePath)
        {
            _log = new FileLog(logFilePath);
        }

        public void Run()
        {
            BooksRepository bookRepository = new BooksRepository(_log);
            BookSort sortRepository = new BookSort(_log, bookRepository);
            _log.Log("\nПрограмма запущена\n");
            Console.WriteLine("\tБИБЛИОТЕКА\n");
            Console.WriteLine("Меню функций:");
            Console.WriteLine("1. Вывод списка книг");
            Console.WriteLine("2. Добавление книги");
            Console.WriteLine("3. Обновление книги");
            Console.WriteLine("4. Удаление книги");
            Console.WriteLine("5. Сортировка книг");
            Console.Write("0. Закрыть программу\n\n");

            while (true)
            {
                Console.WriteLine("________________________________");
                Console.Write("Введите пункт меню для выбора: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n\n\n\tСПИСОК КНИГ\n");
                        bookRepository.ReadBooks();
                        break;

                    case "2":
                        Console.WriteLine("\n\n\n\tДОБАВЛЕНИЕ КНИГИ\n");
                        bookRepository.CreateBook();
                        break;

                    case "3":
                        Console.WriteLine("\n\n\n\tОБНОВЛЕНИЕ КНИГИ\n");
                        bookRepository.UpdateBook();
                        break;

                    case "4":
                        Console.WriteLine("\n\n\n\tУДАЛЕНИЕ КНИГИ\n");
                        bookRepository.DeleteBook();
                        break;

                    case "5":
                        bool sorted = true;
                        Console.WriteLine("\n\tСОРТИРОВКА КНИГ\n");
                        Console.WriteLine("Выберите параметр:");
                        Console.WriteLine("1. ID");
                        Console.WriteLine("2. Название");
                        Console.WriteLine("3. Автор");
                        Console.WriteLine("4. Год публикации");
                        Console.WriteLine("0. Главное меню\n");

                        while (sorted)
                        {
                            Console.Write("Введите пункт функции для выбора: ");
                            string inputSort = Console.ReadLine();

                            switch (inputSort)
                            {
                                case "1":
                                    sortRepository.SortById();
                                    break;
                                case "2":
                                    sortRepository.SortByTitle();
                                    break;
                                case "3":
                                    sortRepository.SortByAuthor();
                                    break;
                                case "4":
                                    sortRepository.SortByPubYear();
                                    break;
                                case "0":
                                    sorted = false;
                                    break;
                                default:
                                    Console.WriteLine("Введен неверный пункт меню!");
                                    break;
                            }
                        }

                        break;

                    case "0":
                        _log.Log("\nПрограмма завершена");
                        return;

                    default:
                        Console.WriteLine("Введен неверный пункт меню!\n");
                        break;
                }
            }
        }
    }
}