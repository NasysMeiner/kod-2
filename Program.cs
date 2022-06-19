using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 4, 5, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 5 };
            int maxRepeat = 0;
            int number = 0;
            int repeat = 1;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    repeat++;
                }
                else if (repeat < maxRepeat && array[i] != array[i + 1])
                {
                    repeat = 1;
                }
                if (repeat > maxRepeat && array[i] != array[i + 1] || i == array.Length - 2)
                {
                    number = array[i];
                    maxRepeat = repeat;
                    repeat = 1;
                }

                Console.Write(array[i]);
            }

            Console.WriteLine();
            Console.WriteLine($"Число: {number} повторялось больше всех, а именно: {maxRepeat}");
            Console.ReadLine();
        }
    }
}
