using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool work = true;
            int[] array = new int[0];

            string userInput;
            int sum = 0;
            
            while(work)
            {
                userInput = Console.ReadLine();

                if (userInput == "sum")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        sum += array[i];
                    }
                    int[] newArray = new int[0];
                    array = newArray;
                    Console.WriteLine(sum);
                }
                else if (userInput == "exit")
                {
                    work = false;
                }
                else
                {
                    int[] temporary = new int[array.Length + 1];

                    for(int i = 0; i < array.Length; i++)
                    {
                        temporary[i] = array[i];
                    }

                    temporary[temporary.Length - 1] = Convert.ToInt32(userInput);
                    array = temporary;
                }                
            }
        }
    }
}
