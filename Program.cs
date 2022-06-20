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
            Random random = new Random();
            int[] array = new int[30]; 
            int maxRepeat = 0;
            int number = 0;
            int repeat = 1;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 4);
            }

            for (int d = 0; d < array.Length; d++)
            {
                Console.Write(array[d]);
            }

            Console.WriteLine();

            for (int j = 0; j < array.Length; j++)
            {
                if (j == array.Length - 1)
                {
                    break;
                }
                else if (array[j] == array[j + 1])
                {
                    repeat++;
                }
                else
                {
                    if (repeat > maxRepeat)
                    {
                        maxRepeat = repeat;
                        number = array[j];
                    }
                    repeat = 1;
                }
            }
           
            Console.WriteLine();
            Console.WriteLine($"Число: {number} повторялось больше всех, а именно: {maxRepeat}");
            Console.ReadLine();
        }
    }
}
