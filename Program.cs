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
            Random random = new Random();
            int numberMin = 1;
            int numberMax = 101;
            int randomNumber = random.Next(numberMin, numberMax);
            int number = 2;
            int degreeNumber = 2;

            for (int i = number; i <= randomNumber; i *= degreeNumber)
            {
                number = i;
                Console.WriteLine($"Начально число: {randomNumber}. Возводимое в степень число:{number}.");
            }
            Console.WriteLine($"Начально число: {randomNumber}. Возводимое в степень число:{number * degreeNumber}.");
            Console.ReadLine();
        }
    }
}