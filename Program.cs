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

            for (int i = initialNumber; i <= finalNumber; i += constantNumber)
            {
                Console.WriteLine(initialNumber);

                initialNumber += constantNumber;
            }
            Console.ReadLine();
        }
    }
}
