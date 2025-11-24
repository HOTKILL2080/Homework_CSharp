using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFunc1
{
    internal class Program
    {
        static string swap_num(string nums)
        {
            string[] nums_arr = nums.Split();
            return string.Join(" ", nums_arr.Reverse());
        }
        static string sum_str(string str)
        {
            string sum = "";
            foreach (string i in str.Split())
            {
                sum += i;
            }
            return sum;
        }
        static int factorial(int fact)
        {
            if (fact == 1 || fact == 0)
            {
                return 1;
            }
            else
            {
                return fact * factorial(fact - 1);
            }
        }
        static int calculate(string[] exp)
        {
            int result = 0;
            if (exp[1] == "+")
            {
                result = int.Parse(exp[0]) + int.Parse(exp[2]);
            }
            else if  (exp[1] == "-")
            {
                result = int.Parse(exp[0]) - int.Parse(exp[2]);
            }
            else if (exp[1] == "*")
            {
                result = int.Parse(exp[0]) * int.Parse(exp[2]);
            }
            else if (exp[1] == "/")
            {
                result = int.Parse(exp[0]) / int.Parse(exp[2]);
            }
            return result;
        }
        static void Main(string[] args)
        {
            //    1 задание
            //    Написать метод чтобы менял цифры местами
            //    2 задание
            //    Написать метод который будет складывать строки из массива
            //    3 задание
            //    На рекурсию написать для вычисления факториала
            //    4 задание
            //    Калькулятор  который будет принимать 2 числа(короче обычный

            Console.WriteLine("Введите: число1 число2 через пробел");
            string nums = Console.ReadLine();
            nums = swap_num(nums);
            Console.WriteLine(nums);

            Console.WriteLine("Сумма:");
            string str = sum_str(nums);
            Console.WriteLine(str);

            try
            {
                Console.WriteLine("Введите факториал:");
                int fact = int.Parse(Console.ReadLine());
                int fact_res = factorial(fact);
                Console.WriteLine("Факториал " + fact + ": " + fact_res);
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Не правильный ввод");
            }
            try
            {
                Console.WriteLine("Введите: число1 знак(+ - / *) число2 через пробел");
                string[] exp = Console.ReadLine().Split();
                Console.WriteLine("Сумма: " + calculate(exp));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Не правильный ввод");
            }
        }
    }
}
