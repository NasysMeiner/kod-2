using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool success = false;
            int number = GetNumber(ref success);

            Console.Clear();
            Console.WriteLine($"Вы ввели {number}"); 
            Console.ReadLine();
        }

        static int GetNumber(ref bool success)
        {
            bool isWork = true;
            
            while (isWork)
            {
                Console.WriteLine("Введите число:");
                string userInput = Console.ReadLine();
                bool result = int.TryParse(userInput, out int number);

                if (result)
                {
                    success = true;
                    isWork = false;
                    return number;
                }
            }

            return 0;
        }
    }
}
