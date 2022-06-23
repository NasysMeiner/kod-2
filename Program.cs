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

            List<int> prices = new List<int>();
            prices.Add(100);
            prices.Add(130);
            prices.Add(260);
            prices.Add(38);
            prices.Add(289);
            prices.Add(97);
            prices.Add(300);
            prices.Add(689);
            prices.Add(1000);
            prices.Add(523);
            prices.Add(57);

            size = prices.Count;

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Клиентов осталось: {prices.Count}. Текущий заработок: {sum}.");
                Console.WriteLine("Цена текущей покупки: " + prices[0]);
                Console.ReadKey();
                sum += prices[0];
                prices.RemoveAt(0);
                Console.Clear();
            }
           
            Console.WriteLine($"Клиентов осталось: {prices.Count}. Текущий заработок: {sum}.");
            Console.ReadKey();
        }
    }
}
