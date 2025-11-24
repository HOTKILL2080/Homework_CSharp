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
        static int sum_num(string nums)
        {
            int num = 0;
            foreach (string i in nums.Split())
            {
                num += int.Parse(i);
            }
            return num;
        }
        static int factorial(int fac)
        {
            int factorial = 1;
            if (fac == 1 || fac == 0)
            {
                factorial = 1;
            }
            else
            {
                for (int i = 1; i <= fac; i++)
                {
                    Console.WriteLine(i);
                    factorial += factorial * (i-1);
                }
            }
            return factorial;
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

            string nums = Console.ReadLine();
            nums = swap_num(nums);
            Console.WriteLine(nums);

            int num = sum_num(nums);
            Console.WriteLine(num);

            int fac = int.Parse(Console.ReadLine());
            fac = factorial(fac);
            Console.WriteLine(fac);
        }
    }
}
