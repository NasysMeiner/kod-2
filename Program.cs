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
            int Intermediate;

            for (int i = 0; i < 14; i++) //Выбрал именно этот цикл, потому что точно знаю сколько итераций он должен сделать
            {
                Console.WriteLine(initialNumber);
                Intermediate = initialNumber + constantNumber;
                initialNumber = Intermediate;
            }
            Console.ReadLine();
        }
    }
}
