using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int constantNumber = 7;
            int initialNumber = 5;
            int finalNumber = 96;

            for (int i = 0; i <= finalNumber;)
            {
                Console.WriteLine(initialNumber);

                initialNumber = initialNumber + constantNumber;
                i = initialNumber;
            }
            Console.ReadLine();
        }
    }
}
