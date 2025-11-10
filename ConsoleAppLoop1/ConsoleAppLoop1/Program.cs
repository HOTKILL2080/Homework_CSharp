using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLoop1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 4 цифры через пробел:");
            string[] nums = Console.ReadLine().Split();
            string result = "";
            foreach (string item in nums)
            {
                if (int.TryParse(item, out _))
                {
                    result += item;    
                }
                else
                {
                    Console.WriteLine("Не цифра: " + item);
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
