using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";

            Dictionary<string, string> words = new Dictionary<string, string>();
            words.Add("яблоко","фрукты");
            words.Add("виноград", "фрукты");
            words.Add("огруец", "овощи");
            words.Add("кабачок", "овощи");
            words.Add("помидор", "овощи");
            words.Add("груша", "фрукты");

            Console.Write("Введите плод:");
            userInput = Console.ReadLine();

            if(words.ContainsKey(userInput))
            {
                Console.WriteLine(words[userInput]);
            }

            Console.ReadLine();
        }
    }
}
