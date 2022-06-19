using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 100, 4, 6, 1, 8, 10, 11, 34, 87, 20, 21, 31, 67, 45, 63, 92, 49, 67, 51, 70, 11, 25, 72, 97, 66, 83, 52, 67, 81, 1000 };

            if (array[0] > array[1])
            {
                Console.Write("|" + array[0] + "|");
            }

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1] && array[i] > array[i - 1])
                {
                    Console.Write("|" + array[i] + "|");
                }
            }
            
            if (array[array.Length - 1] > array[array.Length - 2])
            {
                Console.Write("|" + array[array.Length - 1] + "|");
            }
            Console.ReadLine();
        }
    }
}
