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
            bool isWork = true;
            bool success = false;

            while (isWork)
            {
                int number = Convert(ref success);

                if (success)
                {
                    Console.Clear();
                    Console.WriteLine($"Вы ввели {number}");
                    isWork = false;
                }                
            }

            Console.ReadLine();
        }

        static int Convert(ref bool success)
        {
            Console.WriteLine("Введите число:");
            string userInput = Console.ReadLine();
            bool result = int.TryParse(userInput, out int number);
            
            if (result)
            {
                success = true;
                return number;
            }

            return 0;
        }
    }
}
