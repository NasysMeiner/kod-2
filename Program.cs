using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string symbol = "";
            int depth = 0;
            int depthMax = 0;
            int correctness = 0;

            symbol = Console.ReadLine();

            for (int i = 0; i < symbol.Length; i++)
            {
                switch (Convert.ToString(symbol[i]))
                {
                    case "(":
                        correctness++;
                        break;
                    case ")":
                        if (correctness > 0)
                        {
                            correctness--;
                        }
                        else
                        {
                            break;
                        }
                        break;
                }
            }

            if (correctness == 0)
            {
                Console.WriteLine("Корректное выражение.");

                for (int i = 0; i < symbol.Length; i++)
                {
                    if (symbol[i] == Convert.ToChar("("))
                    {
                        depth++;
                    }
                    else
                    {
                        if (depth > depthMax)
                        {
                            depthMax = depth;
                        }
                        depth--;
                    }
                }

                Console.WriteLine($"Символ {symbol} имеет глубину: {depthMax}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Некорректное выражение.");
            }
            Console.ReadLine();
        }
    }
}
