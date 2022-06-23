using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number = 0;
            int size = 0;

            Queue<int> prices = new Queue<int>();
            prices.Enqueue(100);
            prices.Enqueue(130);
            prices.Enqueue(260);
            prices.Enqueue(38);
            prices.Enqueue(289);
            prices.Enqueue(97);
            prices.Enqueue(300);
            prices.Enqueue(689);
            prices.Enqueue(1000);
            prices.Enqueue(523);
            prices.Enqueue(57);

            size = prices.Count;

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Клиентов осталось: {prices.Count - 1}. Текущий заработок: {sum}.");
                Console.WriteLine("Цена текущей покупки: " + prices.Peek());
                Console.ReadKey();
                if (prices.Count != 0)
                {
                    sum += prices.Dequeue();
                }
                Console.Clear();
            }
           
            Console.WriteLine($"Клиентов осталось: {prices.Count}. Текущий заработок: {sum}.");
            Console.ReadKey();
        }
    }
}
