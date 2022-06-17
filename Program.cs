using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int min = 1;
            int max = 101;
            int randomNumber = rand.Next(min, max);
            int number = 2;

            for (int i = number; i <= randomNumber; i *= 2)
            {
                number = i;
                Console.WriteLine($"Начально число: {randomNumber}. Возводимое в степень число:{number}.");
            }
            Console.WriteLine($"Начально число: {randomNumber}. Возводимое в степень число:{number * 2}.");
            Console.ReadLine();
        }
    }
}