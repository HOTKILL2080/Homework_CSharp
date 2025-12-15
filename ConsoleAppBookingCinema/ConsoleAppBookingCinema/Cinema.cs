using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ConsoleAppBookingCinema
{
    // create_cinema_timetable - Функция создаёт новое расписание по дате текущего зала в формате "Dictionary<string, Dictionary<int, string>[,]>"
    // generate_code - создаёт уникальный код из = номер_зала+рандомное_число
    // taking_seat - делает места с забронировано на занято
    // delete_timetable - удаляет все не актуальные по дате расписание
    // book_ticket - бронирует билет по ряду и месту
    // create_price - создаёт цену на основе места и времени
    // find_booking - ищет бронь по уникальному коду
    // cancel_booking - ну это отмена брони
    // show_tickets - выводит все билеты текущего зала
    // show_cinema_hall - функция выводит зал = ряды места и статус в виде цвета
    // delete_ticket - удаляет билет по уникальному коду

    public class Cinema
    {
        private Dictionary<string, Dictionary<int, string>[,]> cinema_timetable; // Хранение расписания зала
        private int number_of_seats;                                             // Кол-во мест в зале
        private int number_of_rows;                                              // Кол-во рядов
        private Random random = new Random();                                    // Экземпляр класса Random
        public Dictionary<int, string[]> cinema_tickets;                         // Хранение билетов
        private string number_of_hall;                                           // номер зала (ВАЖНО номер не должен повторятся)

        // Цвета для консоли
        private System.ConsoleColor booking_color = ConsoleColor.DarkCyan;
        private System.ConsoleColor busy_color = ConsoleColor.Red;
        private System.ConsoleColor free_color = ConsoleColor.Green;
        private System.ConsoleColor date_color = ConsoleColor.Magenta;

        public Cinema(string hall, int seats, int rows)
        {
            number_of_rows = rows;
            number_of_seats = seats;
            number_of_hall = hall;
            cinema_timetable = new Dictionary<string, Dictionary<int, string>[,]>();
            cinema_tickets = new Dictionary<int, string[]>();
        }
        public int get_number_of_row()
        {
            return number_of_rows;
        }
        public int get_number_of_seat()
        {
            return number_of_seats;
        }
        // create_cinema_timetable - Функция создаёт новое расписание по дате текущего зала в формате "Dictionary<string, Dictionary<int, string>[,]>"
        private void create_cinema_timetable(string date) 
        {
            cinema_timetable.Add(date, new Dictionary<int, string>[number_of_rows, number_of_seats]);
            for (int i = 0; i < number_of_rows; i++)
            {
                for (int e = 0; e < number_of_seats; e++)
                {
                    cinema_timetable[date][i, e] = new Dictionary<int, string>();
                    cinema_timetable[date][i, e].Add(e, "Свободно");
                }
            }
        }
        // generate_code - создаёт уникальный код из = номер_зала+рандомное_число
        private int generate_code(string date, int row, int seat)
        {
            int unique_code;
            while (true)
            {
                unique_code = int.Parse(number_of_hall + random.Next(1000, 9999).ToString());
                if (!cinema_tickets.ContainsKey(unique_code))
                {
                    cinema_tickets.Add(unique_code, new string[3] { date, row.ToString(), seat.ToString() });
                    return unique_code;
                }
            }
        }
        // taking_seat - делает места с забронировано на занято
        public void taking_seat(string date)
        {
            if (cinema_timetable.ContainsKey(date))
            {
                for (int row = 0; row < number_of_rows - 1; row++)
                {
                    for (int seat = 0; seat < number_of_seats - 1; seat++)
                    {
                        if (cinema_timetable[date][row, seat][seat] == "Забронировано")
                        {
                            cinema_timetable[date][row, seat][seat] = "Занято";
                        }
                    }
                }
            }
        }
        // delete_timetable - удаляет все не актуальные по дате расписание
        public void delete_timetable(string today_date, string past_date) // Сука на это гавно натурально полдня ушло
        {
            if (cinema_timetable.ContainsKey(past_date))
            {
                cinema_timetable.Remove(past_date);
            }
            // 0_0 без коментариев можно я перестану писать кинотеатр
            while ((int.Parse(past_date.Substring(6, 4)) < int.Parse(today_date.Substring(6, 4))) ||
                   (int.Parse(past_date.Substring(6, 4)) == int.Parse(today_date.Substring(6, 4)) &&
                    int.Parse(past_date.Substring(3, 2)) < int.Parse(today_date.Substring(3, 2))) ||
                   (int.Parse(past_date.Substring(6, 4)) == int.Parse(today_date.Substring(6, 4)) &&
                    int.Parse(past_date.Substring(3, 2)) == int.Parse(today_date.Substring(3, 2)) &&
                    int.Parse(past_date.Substring(0, 2)) < int.Parse(today_date.Substring(0, 2))) ||
                   (int.Parse(past_date.Substring(6, 4)) == int.Parse(today_date.Substring(6, 4)) &&
                    int.Parse(past_date.Substring(3, 2)) == int.Parse(today_date.Substring(3, 2)) &&
                    int.Parse(past_date.Substring(0, 2)) == int.Parse(today_date.Substring(0, 2)) &&
                   (int.Parse(past_date.Substring(11, 2)) < int.Parse(today_date.Substring(11, 2)) ||
                   (int.Parse(past_date.Substring(11, 2)) == int.Parse(today_date.Substring(11, 2)) &&
                    int.Parse(past_date.Substring(14, 2)) < int.Parse(today_date.Substring(14, 2))))))
            {
                if (past_date.Substring(11, 5) == "10:00")
                {
                    past_date = past_date.Replace("10:00", "14:30");
                }
                else if (past_date.Substring(11, 5) == "14:30")
                {
                    past_date = past_date.Replace("14:30", "19:00");
                }
                else if (past_date.Substring(11, 5) == "19:00")
                {
                    past_date = past_date.Replace("19:00", "22:15");
                }
                else if (past_date.Substring(11, 5) == "22:15")
                {
                    if (int.Parse(past_date.Substring(0, 2)) < 31)
                    {
                        past_date = past_date.Remove(0, 2).Insert(0, (int.Parse(past_date.Substring(0, 2)) + 1).ToString());
                        past_date = past_date.Replace("22:15", "10:00");
                        if (past_date.Length == 15)
                        {
                            past_date = past_date.Insert(0, "0");
                        }
                    }
                    else if (int.Parse(past_date.Substring(3, 2)) < 12)
                    {
                        past_date = past_date.Remove(3, 2).Insert(3, (int.Parse(past_date.Substring(3, 2)) + 1).ToString());
                        past_date = past_date.Remove(0, 2).Insert(0, "01");
                        past_date = past_date.Replace("22:15", "10:00");
                        if (past_date.Length == 15)
                        {
                            past_date = past_date.Insert(3, "0");
                        }
                    }
                    else
                    {
                        past_date = past_date.Replace(past_date.Substring(6, 4), (int.Parse(past_date.Substring(6, 4)) + 1).ToString());
                        past_date = past_date.Remove(3, 2).Insert(3, "01");             // -Здесь был смешной баг который забрал 10м моей жизни. Там
                        past_date = past_date.Remove(0, 2).Insert(0, "01");             // стоял Replace заменяет всё что найдёт по аргументу поэтому
                        past_date = past_date.Replace("22:15", "10:00");                // когда месяц был 12 и наступал 1012 год он сбрасывался на
                    }                                                                   // 1001 и зацикливался и мой комп улетал в стратосферу ха ха #####
                }                                                                       // по итогу я переписал здесь всё с replace на remove и insert
                if (cinema_timetable.ContainsKey(past_date))
                {
                    cinema_timetable.Remove(past_date);
                }
            }
        }
        // delete_ticket - удаляет билет по уникальному коду
        public void delete_ticket(int code_ticket)
        {
            cinema_tickets.Remove(code_ticket);
        }
        // book_ticket - бронирует билет по ряду и месту
        public void book_ticket(string date, int row, int seat, bool kaftanokinator = false)
        {
            int ticket_code;
            int price;
            string action = "";
            if (!cinema_timetable.ContainsKey(date))
            {
                create_cinema_timetable(date);
            }
            if (cinema_timetable[date][row - 1, seat - 1][seat - 1] == "Забронировано" || cinema_timetable[date][row - 1, seat - 1][seat - 1] == "Занято")
            {
                Console.Write("                                                        ");
                Console.WriteLine("Уже занято");
                return;
            }
            price = create_price(date, row, seat, number_of_rows, number_of_seats);
            Console.Write("\n                                                   ");
            Console.WriteLine("Цена билета - " + price);
            Console.Write("\n                                                   ");
            Console.WriteLine("Забронировать:");
            Console.Write("                                                 ");
            Console.WriteLine("1 - Да       2 - Нет");
            Console.Write("                                                         ");
            if (!kaftanokinator)
            {
                action = Console.ReadLine();
            }
            if (action == "1" || action.ToLower() == "да" || kaftanokinator)
            {
                ticket_code = generate_code(date, row, seat);
                Console.Write("\n\n");
                Console.Write("                                                        ");
                Console.WriteLine("Успех:");
                Console.Write("                                                        ");
                Console.WriteLine("Номер билета - " + ticket_code);
                Console.Write("                                                        ");
                Console.WriteLine("Ряд - " + row.ToString());
                Console.Write("                                                        ");
                Console.WriteLine("Место - " + seat.ToString());
                cinema_timetable[date][row - 1, seat - 1][seat - 1] = "Забронировано";
            }
            else if (action == "2" || action.ToLower() == "нет")
            {
                Console.Write("                                                        ");
                Console.WriteLine("Вы отменили покупку билета");
            }   
        }
        // create_price - создаёт цену на основе места и времени
        private int create_price(string date, int row, int seat, int number_of_row, int number_of_seat)
        {
            int price = 300;
            if (
                Math.Ceiling(number_of_seat / 2.0 + (number_of_seat / 2.0) * 0.10) >= seat &&
                Math.Floor(number_of_seat / 2.0 - (number_of_seat / 2.0) * 0.10) <= seat &&
                Math.Ceiling(number_of_row / 2.0 + (number_of_row / 2.0) * 0.40 ) >= row &&
                Math.Floor(number_of_row / 2.0 - (number_of_row / 2.0) * 0.30) <= row) 
            {
                price = (int)(price + price * 0.5);
            }
            else if (
                Math.Ceiling(number_of_seat / 2.0 + (number_of_seat / 2.0) * 0.10) < seat &&
                Math.Ceiling(number_of_seat / 2.0 + (number_of_seat / 2.0) * 0.40) >= seat ||
                Math.Floor(number_of_seat / 2.0 - (number_of_seat / 2.0) * 0.10) > seat &&
                Math.Floor(number_of_seat / 2.0 - (number_of_seat / 2.0) * 0.40) <= seat &&
                Math.Ceiling(number_of_row / 2.0 + (number_of_row / 2.0) * 0.30) >= row &&
                Math.Floor(number_of_row / 2.0 - (number_of_row / 2.0) * 0.30) <= row)
            {
                price = (int)(price + price * 0.3);
            }
            if (date.Substring(11, 5) == "10:00")
            {
                price = (int)(price + price * 0.1);
            }
            else if (date.Substring(11, 5) == "14:30")
            {
                price = (int)(price + price * 0.3);
            }
            else if (date.Substring(11, 5) == "19:00")
            {
                price = (int)(price + price * 0.5);
            }
            else if (date.Substring(11, 5) == "22:15")
            {
                price = (int)(price + price * 0.2);
            }
            return price;

        }
        // find_booking - ищет бронь по уникальному коду
        public void find_booking(int ticket_code)
        {
            if (cinema_tickets.ContainsKey(ticket_code))
            {
                string date = cinema_tickets[ticket_code][0];
                string row = cinema_tickets[ticket_code][1];
                string seat = cinema_tickets[ticket_code][2];
                show_cinema_hall(date);
                Console.Write("\n                                                  ");
                Console.WriteLine("Номер вашего билета - " + ticket_code);
                Console.Write("                                                  ");
                Console.WriteLine("Ряд - " + row);
                Console.Write("                                                  ");
                Console.WriteLine("Место - " + seat);
                while (true)
                {
                    Console.Write("\n                                               ");
                    Console.WriteLine("Хотите отменить бронирование:");
                    Console.Write("                                                    ");
                    Console.WriteLine("1 - Да       2 - Нет");
                    Console.Write("                                                            ");
                    string action = Console.ReadLine();
                    if (action.ToLower() == "да" || action == "1")
                    {
                        cancel_booking(date, int.Parse(row), int.Parse(seat));
                        break;
                    }
                    else if (action.ToLower() == "нет" || action == "2")
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Такого билета нет");
                Console.ResetColor();
            }
        }
        // cancel_booking - ну это отмена брони
        public void cancel_booking(string date, int row, int seat)
        {
            int key = 0;
            foreach(var i in cinema_tickets)
            {
                if (i.Value[0] == date && i.Value[1] == row.ToString() && i.Value[2] == seat.ToString())
                {
                    cinema_timetable[date][row - 1, seat - 1][seat - 1] = "Свободно";
                    key = i.Key;
                    break;
                } 
            }
            delete_ticket(key);
        }
        // show_tickets - выводит все билеты текущего зала
        public void show_tickets()
        {
            Console.Write("\n\n\n");
            if (cinema_tickets.Count == 0)
            {
                Console.Write("                                                  ");
                Console.WriteLine("Билетов нет");
                return;
            }
            foreach (var i in cinema_tickets)
            {
                Console.Write("                                     ");
                Console.WriteLine("Билет: " + i.Key + " Дата - " + i.Value[0] + " Ряд - " + i.Value[1] + " Место - " + i.Value[2]);
            }
        }
        // show_cinema_hall - функция выводит зал = ряды места и статус в виде цвета
        public void show_cinema_hall(string date)
        {
            if (!cinema_timetable.ContainsKey(date))
            {
                create_cinema_timetable(date);
            }
            Console.Clear();
            Console.Write("\n\n\n\n\n\n");
            Console.Write("                                                   ");
            Console.ForegroundColor = date_color;
            Console.WriteLine(date);
            Console.ResetColor();
            Console.Write("                                                  ");
            Console.Write("  ");
            for (int j = 0; j < number_of_seats*3; j++)
            {
                Console.Write("_");
            }
            for (int i = number_of_rows; i > 0; i--)
            {
                Console.Write("\n");
                Console.Write("                                                  ");
                Console.Write($"{i} ");
                for (int e = 0; e < number_of_seats; e++)
                {
                    if (cinema_timetable[date][i - 1, e][e] == "Свободно")
                    {
                        Console.ForegroundColor = free_color;
                    }
                    else if (cinema_timetable[date][i - 1, e][e] == "Забронировано")
                    {
                        Console.ForegroundColor = booking_color;
                    }
                    else if (cinema_timetable[date][i - 1, e][e] == "Занято")
                    {
                        Console.ForegroundColor = busy_color;
                    }
                    Console.Write("|" + (e + 1) + "|");
                    Console.ResetColor();
                }
                Console.Write($" {i}");
                Console.Write("\n  ");
                Console.Write("                                                  ");
                for (int j = 0; j < number_of_seats * 3; j++)
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
        }
    }
}