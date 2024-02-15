using System;

namespace Library_APP
{
    //основной класс для управления программой
    //применены принцип программирования Dependency Injection и паттерны проектирования Strategy, Factory Method
    public class ProgramRunner
    {
        private readonly ILog _log;

        public ProgramRunner(string logFilePath)
        {
            //создание экземпляра FileLog для записи логов в файл
            _log = new FileLog(logFilePath);
        }

        //метод для запуска программы и отображения главного меню
        public void Run()
        {
            //создание репозитория книг
            BooksRepository bookRepository = new BooksRepository(_log);
            //создание объекта для сортировки книг
            BookSort sortRepository = new BookSort(_log, bookRepository);
            //запись в лог о запуске программы
            _log.Log("\nПрограмма запущена\n");
            //отображение главного меню
            Console.WriteLine("\tБИБЛИОТЕКА\n");
            Console.WriteLine("Меню функций:");
            Console.WriteLine("1. Вывод списка книг");
            Console.WriteLine("2. Добавление книги");
            Console.WriteLine("3. Обновление книги");
            Console.WriteLine("4. Удаление книги");
            Console.WriteLine("5. Сортировка книг");
            Console.Write("0. Закрыть программу\n\n");

            //цикл для обработки выбора пользователем пунктов меню
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
                        Console.WriteLine("\n\n\n\tСОРТИРОВКА КНИГ\n");
                        Console.WriteLine("Выберите параметр:");
                        Console.WriteLine("1. ID");
                        Console.WriteLine("2. Название");
                        Console.WriteLine("3. Автор");
                        Console.WriteLine("4. Год публикации");
                        Console.WriteLine("0. Главное меню\n");

                        //цикл для выбора критерия сортировки
                        while (sorted)
                        {
                            Console.Write("Введите пункт функции для выбора: ");
                            string inputSort = Console.ReadLine();

                            switch (inputSort)
                            {
                                case "1":
                                    sortRepository.Sort(book => book.Id, "Id");
                                    break;
                                case "2":
                                    sortRepository.Sort(book => book.Title, "названию");
                                    break;
                                case "3":
                                    sortRepository.Sort(book => book.Author, "автору");
                                    break;
                                case "4":
                                    sortRepository.Sort(book => book.PubYear, "году публикации");
                                    break;
                                case "0":
                                    sorted = false;
                                    break;
                                default:
                                    Console.WriteLine("Введен неверный пункт функции!\n");
                                    break;
                            }
                        }

                        Console.WriteLine("");

                        break;

                    case "0":
                        //запись в лог о завершении программы
                        _log.Log("\nПрограмма завершена\n");
                        return;

                    default:
                        Console.WriteLine("Введен неверный пункт меню!\n");
                        break;
                }
            }
        }
    }
}