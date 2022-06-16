using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int constantNumber = 7;
            int initialNumber = 5;
            int numberOfRepetitions = 14;
            int finalNumber = 96;

            while (initialNumber <= finalNumber) //Выбрал именно этот цикл, потому что я не знаю кол-во итераций
            {
                Console.WriteLine(initialNumber);
                int Intermediate = initialNumber + constantNumber;
                initialNumber = Intermediate;
            }
            Console.ReadLine();
        }
    }
}
