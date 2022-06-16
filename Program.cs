using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message;
            int numberOfRepetitions;

            Console.Write("Введите сообщение:");
            message = Console.ReadLine();

            Console.Write("Введите кол-во повторений:");
            numberOfRepetitions = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfRepetitions; i++)
            {
                Console.WriteLine(message);
            }
            Console.ReadLine();
        }
    }
}
