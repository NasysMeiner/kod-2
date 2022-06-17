using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string symbol;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.Write("Введите символ: ");
            symbol = Console.ReadLine();

            for (int i = 0; i < name.Length + 2; i++)
            {
                if (i == name.Length + 1)
                {
                    Console.WriteLine(symbol);
                }
                else
                {
                    Console.Write(symbol);
                }
            }

            Console.WriteLine(symbol + name + symbol);
            
            for(int i = 0; i < name.Length + 2; i++)
            {
                Console.Write(symbol);
            }

            Console.ReadLine();
        }
    }
}
