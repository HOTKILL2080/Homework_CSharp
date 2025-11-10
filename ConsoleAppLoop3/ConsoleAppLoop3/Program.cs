using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLoop3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string value = "0";
            int result = 0;
            bool exit = false;
            while (!exit) {
                Console.WriteLine("\n1 - Посчитать сумму.\n2 - Ввести новые цифры.\n3 - Выход.\n");
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                    
                        foreach (char item in value)
                        {
                            result += int.Parse(item.ToString());
                        }
                        Console.WriteLine("Сумма: " + result.ToString());
                        result = 0;
                        break;
                    case '2':
                        Console.WriteLine("Введите цифры через пробел:");
                        string[] nums = Console.ReadLine().Split();
                        value = "0";
                        foreach (string item in nums)
                        {
                            if (int.TryParse(item, out int num))
                            {
                                value += item;
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели не цифру: " + item);
                                value = "0";
                            }
                        }
                        break;
                    case '3': exit = true; break;
                }
            }
        }
    }
}
