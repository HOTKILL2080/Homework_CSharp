using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Collections.Specialized.BitVector32;

namespace ConsoleAppBookingCinema
{
    internal class Program
    {
        // Послание:
        // Я старался писать нормально но когда программа разрастается тонной строк и ты не знаешь как правильно решить
        // ту или иную проблему ты начинаешь долго думать и написание замедляется очень сильно, поэтому я продолжил писать
        // так как мне в голову приходила первая мысль и я её сразу исполнял или так как я увидел гдето только что.
        // Поэтому некоторые вещи могут быть капец какими не логичными и запутанными но в любом случае ОНО то работает.

        // main - ну это функция
        // show_tickets - выводить все существующие билеты всех залов 
        // press_to_next - ReadKey и вывод нажмите на любую клавишу...
        // next_time - меняет текущее время на следуйщее по порядку или на указанную дату
        // find_booking - ищет в массиве кинотеатров билет по уникальному номеру
        // input_date - ввод даты
        // cinema_hall_process - Функция в которой выполняется вся основная работа с залом

        static void Main(string[] args) // Начальное начало
        {
            // Экземпляры класса Cinema - сами залы
            Cinema cinema_hall1 = new Cinema("1", 5, 5);
            Cinema cinema_hall2 = new Cinema("2", 6, 6);
            Cinema cinema_hall3 = new Cinema("3", 4, 8);
            Cinema[] array_cinema_hall = new Cinema[] { cinema_hall1, cinema_hall2, cinema_hall3 };

            // Разные переменные
            string today_date = "01.01.2000 10:00";
            int element = 0;
            string date;
            string action;

            Console.Write("\n\n\n                                     ");
            Console.WriteLine("Управление происходит написанием цифр или");
            Console.Write("                                             ");
            Console.WriteLine("ключевых слов в 'кавычках'");

            Console.Write("\n\n\n                            ");
            Console.WriteLine("Введите сегодняшнюю дату которая больше или равна дате 01.01.2000 10:00");
            Console.Write("                                     ");
            Console.WriteLine("или нажмите ВВОД тогда применется 01.01.2000 10:00");
            today_date = input_date(today_date, false);
            Console.Clear();

            random_booking_timetable(generate_dates(10, today_date), array_cinema_hall);

            // Дальше основное место где можно выбрать фильм или другие действия
            while (true)
            {
                Console.Write("\n\n\n\n\n\n\n");
                Console.Write("                                                       ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(today_date);
                Console.ResetColor();
                Console.Write("\n                                                  ");
                Console.WriteLine("Выберите фильм или действие:");
                Console.Write("                                                  ");
                Console.WriteLine("1 - 'Absolute cinema 2'");
                Console.Write("                                                  ");
                Console.WriteLine("2 - 'C++ is nightmare'");
                Console.Write("                                                  ");
                Console.WriteLine("3 - 'GitHub Man return'");
                Console.Write("                                                  ");
                Console.WriteLine("4 - 'Найти' место по номеру билета");
                Console.Write("                                                  ");
                Console.WriteLine("5 - Изменить 'время' дня");
                Console.Write("                                                  ");
                Console.WriteLine("6 - 'Список' билетов");
                Console.Write("                                                  ");
                action = Console.ReadLine();
                Console.Clear();

                if (action == "1" || action.ToLower() == "absolute cinema 2" || action.ToLower() == "absolutecinema2")
                {
                    cinema_hall_process(cinema_hall1, array_cinema_hall, today_date);
                }
                else if (action == "2" || action.ToLower() == "c++ is nightmare" || action.ToLower() == "c++isnightmare")
                {
                    cinema_hall_process(cinema_hall2, array_cinema_hall, today_date);
                }
                else if (action == "3" || action.ToLower() == "github man return" || action.ToLower() == "githubmanreturn")
                {
                    cinema_hall_process(cinema_hall3, array_cinema_hall, today_date);
                }
                else if (action == "4" || action.ToLower() == "найти")
                {
                    Console.Write("\n                                               ");
                    Console.WriteLine("Введите номер билета:");
                    Console.Write("                                                      ");
                    int.TryParse(Console.ReadLine(), out int ticket_code);
                    find_booking(ticket_code, array_cinema_hall);
                    press_to_next();
                    Console.Clear();
                }
                else if (action == "5" || action.ToLower() == "Время")
                {
                    Console.Write("\n\n\n                                       ");
                    Console.WriteLine("Введите дату или пропустите нажатием ВВОД");
                    Console.Write("                                      ");
                    Console.WriteLine("(тогда применится следующая дата по порядку)");
                    Console.Write("\n                                            ");
                    date = input_date(today_date, false);
                    delete_timetable(date, today_date, array_cinema_hall);
                    today_date = next_time(date, today_date);
                    taking_seat(today_date, array_cinema_hall);
                    press_to_next();
                    Console.Clear();
                }
                else if (action == "6" || action.ToLower() == "Список")
                {
                    show_tickets(array_cinema_hall);
                    press_to_next();
                }
            }
        }
        static string[] generate_dates(int count, string today_date)
        {
            string date = today_date;
            string[] array_date = new string[count * 4 + 1]; 
            array_date[0] = date;
            for (int i = 1; i <= count * 4; i++)
            {
                date = next_time(date, date); 
                array_date[i] = date;
            }
            return array_date;
        }
        static void random_booking_timetable(string[] date_array, Cinema[] array_cinema_hall)
        {
            Random random = new Random();
            foreach (var date in date_array)
            {
                foreach (var hall in array_cinema_hall)
                {
                    int average = (int)Math.Floor(hall.get_number_of_row() * hall.get_number_of_seat() * 0.6);
                    for (int i = 0; i < average; i++)
                    {
                        hall.book_ticket(date, random.Next(1, hall.get_number_of_row()), random.Next(1, hall.get_number_of_seat()), kaftanokinator: true);
                    }
                }
            }
            Console.Clear();
        }
        static void delete_timetable(string today_date, string past_date, Cinema[] array_cinema_hall)
        {
            foreach (var hall in array_cinema_hall)
            {
                hall.delete_timetable(today_date, past_date);
            }
        }
        static void taking_seat(string today_date, Cinema[] array_cinema_hall)
        {
            foreach (var hall in array_cinema_hall)
            {
                hall.taking_seat(today_date);
            }
        }
        // show_tickets - выводить все существующие билеты всех залов 
        static void show_tickets(Cinema[] array_cinema_hall)
        {
            foreach (var hall in array_cinema_hall)
            {
                hall.show_tickets();
            }
        }
        // press_to_next - ReadKey и вывод нажмите на любую клавишу...
        static void press_to_next()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n                                        ");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        // next_time - меняет текущее время на следуйщее по порядку или на указанную дату
        static string next_time(string date, string today_date, bool forceNext = true)
        {
            if (date == "")
            {
                date = today_date;
            }
            string dateOnly = date.Substring(0, 10);
            string todayDateOnly = today_date.Substring(0, 10);
            if (!forceNext)
            {
                return date;
            }
            if (dateOnly == todayDateOnly) 
            {
                if (date.Substring(11, 5) == "10:00")
                {
                    date = date.Replace("10:00", "14:30");
                }
                else if (date.Substring(11, 5) == "14:30")
                {
                    date = date.Replace("14:30", "19:00");
                }
                else if (date.Substring(11, 5) == "19:00")
                {
                    date = date.Replace("19:00", "22:15");
                }
                else if (date.Substring(11, 5) == "22:15")
                {
                    if (int.Parse(date.Substring(0, 2)) < 31)
                    {
                        date = date.Remove(0, 2).Insert(0, (int.Parse(date.Substring(0, 2)) + 1).ToString());
                        date = date.Replace("22:15", "10:00");
                        if (date.Length == 15)
                        {
                            date = date.Insert(0, "0");
                        }
                    }
                    else if (int.Parse(date.Substring(3, 2)) < 12)
                    {
                        date = date.Remove(3, 2).Insert(3, (int.Parse(date.Substring(3, 2)) + 1).ToString());
                        date = date.Remove(0, 2).Insert(0, "01");
                        date = date.Replace("22:15", "10:00");
                        if (date.Length == 15)
                        {
                            date = date.Insert(3, "0");
                        }
                    }
                    else
                    {
                        date = date.Replace(date.Substring(6, 4), (int.Parse(date.Substring(6, 4)) + 1).ToString());
                        date = date.Remove(3, 2).Insert(3, "01");
                        date = date.Remove(0, 2).Insert(0, "01");
                        date = date.Replace("22:15", "10:00");
                    }
                }
            }
            else
            {
                if (date.Substring(11, 5) == "10:00")
                {
                    date = date.Replace("10:00", "14:30");
                }
                else if (date.Substring(11, 5) == "14:30")
                {
                    date = date.Replace("14:30", "19:00");
                }
                else if (date.Substring(11, 5) == "19:00")
                {
                    date = date.Replace("19:00", "22:15");
                }
                else if (date.Substring(11, 5) == "22:15")
                {
                    date = date.Replace("22:15", "10:00");
                }
            }
            Console.Write("                                        ");
            Console.WriteLine("Время обновлено " + date);
            return date;
        }
        // find_booking -  ищет в массиве кинотеатров билет по уникальному номеру
        static void find_booking(int ticket_code, Cinema[] array_cinema_hall)
        {
            if (int.TryParse(ticket_code.ToString()[0].ToString(), out int number_hall) && ticket_code.ToString().Length == 5)
            {
                array_cinema_hall[number_hall - 1].find_booking(ticket_code);
            }
            else
            {
                Console.Write("                                                  ");
                Console.WriteLine("Билет не найден");
            }
        }
        // input_date - ввод даты
        static string input_date(string today_date, bool kaftanakinator = true)
        {
            string date;
            int element = 0;
            while (true)
            {
                Console.Write("\n\n\n\n\n\n\n");
                Console.Write("                                          ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Текущая дата: " + today_date);
                Console.ResetColor();
                Console.Write("                                             ");
                Console.WriteLine("Введите дату в формате");
                Console.Write("                                                   ");
                Console.WriteLine("ДД.ММ.ГГГГ: ");
                Console.Write("\n                                                   ");
                date = Console.ReadLine();
                if (date.Length == 10)
                {
                    element = 0;
                    foreach (char i in date)
                    {
                        if (int.TryParse(i.ToString(), out _) || ((i == '.' && element == 2) || (i == '.' && element == 5)))
                        {
                            element++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("                                                ");
                            Console.WriteLine("Неверный ввод: " + i);
                            Console.ResetColor();
                        }
                    }
                    if (element != 10)
                    {
                        continue;
                    }
                    int day = int.Parse(date.Substring(0, 2));
                    int month = int.Parse(date.Substring(3, 2));
                    int year = int.Parse(date.Substring(6, 4));

                    int todayDay = int.Parse(today_date.Substring(0, 2));
                    int todayMonth = int.Parse(today_date.Substring(3, 2));
                    int todayYear = int.Parse(today_date.Substring(6, 4));
                    bool isValidDate = false;

                    if (year >= todayYear)
                    {
                        if (month == todayMonth)
                        {
                            if (day >= todayDay && day <= 31 && month >= 1 && month <= 12)
                            {
                                isValidDate = true;
                            }
                        }
                        else if (month > todayMonth && month <= 12)
                        {
                            if (day >= 1 && day <= 31 && month >= 1 && month <= 12)
                            {
                                isValidDate = true;
                            }
                        }
                        if (!isValidDate)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("                                                   ");
                            Console.WriteLine("Кривая дата");
                            Console.ResetColor();
                            element = 0;
                        }
                        if (element == 10 && isValidDate)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                                   ");
                        Console.WriteLine("Неверный ввод");
                        Console.ResetColor();
                    }
                }
                else if (kaftanakinator == false && date == "")
                {
                    return today_date;
                }
            }
            while (true)
            {
                if (kaftanakinator == false && date.Length != 10)
                {
                    break;
                }
                Console.Write("\n                                          ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Текущая дата: " + today_date);
                Console.ResetColor();
                Console.Write("                                                  ");
                Console.WriteLine("Выберите время:");
                Console.Write("                                             ");
                Console.WriteLine("1 - 10:00     2 - 14:30");
                Console.Write("                                             ");
                Console.WriteLine("3 - 19:00     4 - 22:15");
                Console.Write("\n                                                       ");
                string time = Console.ReadLine();
                int day = int.Parse(date.Substring(0, 2));
                int month = int.Parse(date.Substring(3, 2));
                int year = int.Parse(date.Substring(6, 4));

                int todayDay = int.Parse(today_date.Substring(0, 2));
                int todayMonth = int.Parse(today_date.Substring(3, 2));
                int todayYear = int.Parse(today_date.Substring(6, 4));

                bool isToday = (day == todayDay && month == todayMonth && year == todayYear);

                if (!isToday)
                {
                    if (time == "1" || time == "10:00")
                    {
                        date += " 10:00";
                        break;
                    }
                    else if (time == "2" || time == "14:30")
                    {
                        date += " 14:30";
                        break;
                    }
                    else if (time == "3" || time == "19:00")
                    {
                        date += " 19:00";
                        break;
                    }
                    else if (time == "4" || time == "22:15")
                    {
                        date += " 22:15";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                               ");
                        Console.WriteLine("Неправильное время");
                        Console.ResetColor();
                    }
                }
                else
                {
                    int currentHour = int.Parse(today_date.Substring(11, 2));

                    if ((time == "1" || time == "10:00") && currentHour <= 10)
                    {
                        date += " 10:00";
                        break;
                    }
                    else if ((time == "2" || time == "14:30") && currentHour <= 14)
                    {
                        date += " 14:30";
                        break;
                    }
                    else if ((time == "3" || time == "19:00") && currentHour <= 19)
                    {
                        date += " 19:00";
                        break;
                    }
                    else if ((time == "4" || time == "22:15") && currentHour <= 22)
                    {
                        date += " 22:15";
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                               ");
                        Console.WriteLine("Неправильное время");
                        Console.ResetColor();
                    }
                }
            }
            return date;
        }
        // cinema_hall_process - Функция в которой выполняется вся основная работа с залом
        static void cinema_hall_process(Cinema cinema_hall, Cinema[] array_cinema_hall, string today_date)
        {
            int row;
            int seat;
            string action;

            string date = input_date(today_date, false);
            string date2 = today_date;
            press_to_next();
            cinema_hall.taking_seat(date);
            while (true)
            {
                cinema_hall.show_cinema_hall(date);
                Console.Write("\n\n");
                Console.Write("                                                ");
                Console.WriteLine("1 - 'Поиск' брони по коду");
                Console.Write("                                                ");
                Console.WriteLine("2 - 'Забронировать' место");
                Console.Write("                                                ");
                Console.WriteLine("3 - 'Отмена' брони");
                Console.Write("                                                ");
                Console.WriteLine("4 - Показать 'список' билетов");
                Console.Write("                                                ");
                Console.WriteLine("5 - Изменить 'время' бронирования");
                Console.Write("                                                ");
                Console.WriteLine("6 - 'Выход'");
                Console.Write("\n                                                ");
                action = Console.ReadLine();
                if (action == "1" || action.ToLower() == "поиск")
                {
                    Console.Write("\n                                               ");
                    Console.WriteLine("Введите номер билета:");
                    Console.Write("                                                "); 
                    int.TryParse(Console.ReadLine(), out int ticket_code);
                    find_booking(ticket_code, array_cinema_hall);
                }
                else if (action == "2" || action.ToLower() == "забронировать")
                {
                    Console.Write("\n                                       ");
                    Console.WriteLine("Введите номер 'ряда' и 'места' через пробел:");
                    Console.Write("                                                           ");
                    var input = Console.ReadLine().Split();
                    Console.Clear();
                    if (input.Length == 2)
                    {
                        bool bool1 = int.TryParse(input[0], out row);
                        bool bool2 = int.TryParse(input[1], out seat);
                        if (bool1 && cinema_hall.get_number_of_row() >= row && row > 0 && bool2 && cinema_hall.get_number_of_seat() >= seat && seat > 0)
                        {
                            cinema_hall.show_cinema_hall(date);
                            cinema_hall.book_ticket(date, row, seat);
                            press_to_next();
                            cinema_hall.taking_seat(today_date);
                            cinema_hall.show_cinema_hall(date);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("                                                      ");
                            Console.WriteLine("Неверный ввод");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                                      ");
                        Console.WriteLine("Неверный ввод");
                    }
                    Console.ResetColor();
                }
                else if (action == "3" || action.ToLower() == "отмена")
                {
                    Console.Write("\n                                       ");
                    Console.WriteLine("Введите номер 'ряда' и 'места' через пробел:");
                    var input = Console.ReadLine().Split();
                    if (input.Length == 2)
                    {
                        if (int.TryParse(input[0], out row) && int.TryParse(input[1], out seat))
                        {
                            cinema_hall.cancel_booking(date, row, seat);
                            cinema_hall.show_cinema_hall(date);
                        }
                    }
                }
                else if (action == "4" || action.ToLower() == "список")
                {
                    cinema_hall.show_tickets();
                }
                else if (action == "5" || action.ToLower() == "время")
                {
                    Console.Write("                                                ");
                    Console.WriteLine("Введите дату или пропустите нажатием ВВОД");
                    Console.Write("                                                ");
                    Console.WriteLine("(тогда применится следующая дата по порядку)");
                    Console.Write("\n                                                ");
                    date = input_date(date2, false);
                    if (date == "")
                    {
                        date = date2;
                    }
                    string new_date = next_time(date, date2);
                    date2 = new_date;
                    date = date2;
                }
                else if (action == "6" || action.ToLower() == "выход")
                {
                    Console.Clear();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n                                        ");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
