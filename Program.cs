using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = { { 2, 5, 6 }, { 7, 1, 10 }, { 2, 13, 23 } };
            int sum = 0;
            int multiplication = 1;
            int sumLine = 1;
            int multiplicationPillar = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("|" + array[i, j] + "|");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sum += array[sumLine, i];
            }

            for (int j = 0; j < array.GetLength(0); j++)
            {                
                multiplication *= array[j, multiplicationPillar];
            }

            Console.WriteLine($"Сумма равна: {sum}, произведение равно: {multiplication}.");
            Console.ReadLine();
        }
    }
}
