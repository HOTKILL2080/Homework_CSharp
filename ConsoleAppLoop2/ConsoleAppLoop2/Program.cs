using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLoop2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();
            if (int.TryParse(line[0], out int num1))
            {
                if (int.TryParse(line[1], out int num2))
                {

                }
                else
                {
                    Console.WriteLine("Не число: " + line[1]);
                }
                if (num1 > num2)
                {
                    (num1, num2) = (num2, num1);
                }
                for (int i = num1; i <= num2; i++)
                {
                    if (i%2 == 0)
                    {
                        Console.Write(i+" ");
                    }
                }
               
            }
            else 
            {
                Console.WriteLine("Не число: " + line[0]);
            }
        }
    }
}
