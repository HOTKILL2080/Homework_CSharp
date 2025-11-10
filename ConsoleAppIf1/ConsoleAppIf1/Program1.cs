using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppIf1
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            int num1, num2 = 0;
            int num_result = 0;

            Console.WriteLine("Введите 1-ю(е) цифру/число: ");
            string num1_str = Console.ReadLine();
            if (int.TryParse(num1_str, out int numa))
            {
                num1 = numa;
                Console.WriteLine("Введите 2-ю(е) цифру/число: ");
                string num2_str = Console.ReadLine();
                if (int.TryParse(num2_str, out int numb))
                {
                    num2 = numb;
                    Console.WriteLine("Введите арифмитический знак(+, -, *, /): ");
                    string sign = Console.ReadLine();
                    switch (sign)
                    {
                        case "+": num_result = num1 + num2; break;
                        case "-": num_result = num1 - num2; break;
                        case "*": num_result = num1 * num2; break;
                        case "/": num_result = num1 / num2; break;
                        default: Console.WriteLine("Вы ввели неверный знак."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не цифру/число: " + num2_str);
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не цифру/число: " + num1_str);
            }
            Console.WriteLine("Итог: " + num_result.ToString());
            Console.ReadKey();
        }
    }
}
