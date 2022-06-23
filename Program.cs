using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            MixArray(array);

            DrawArray(array);

            Console.ReadLine();
        }

        static void MixArray(int[] array)
        {
            Random random = new Random();
            int number = 0;
            int intermediate = 0;

            for (int i = 0; i < array.Length; i++)
            {
                number = random.Next(0, array.Length);
                intermediate = array[i];
                array[i] = array[number];
                array[number] = intermediate;
            }
        }

        static void DrawArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
