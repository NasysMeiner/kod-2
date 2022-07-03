using System;
using System.Collections.Generic;
using System.Linq;

namespace hw7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Work();
        }
    }

    class Database
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Database()
        {
            _criminals.Add(new Criminal("Oleg", "Антиправительственное"));
            _criminals.Add(new Criminal("Андрей", "Неизвестно"));
            _criminals.Add(new Criminal("Эдик", "Антиправительственное"));
            _criminals.Add(new Criminal("Владик", "Неизвестно"));
            _criminals.Add(new Criminal("Никита", "Антиправительственное"));
            _criminals.Add(new Criminal("Акакий", "Антиправительственное"));
            _criminals.Add(new Criminal("Валерий", "Неизвестно"));
            _criminals.Add(new Criminal("Глеб", "Неизвестно"));
            _criminals.Add(new Criminal("Марк", "Антиправительственное"));
            _criminals.Add(new Criminal("Карл", "Антиправительственное"));
        }

        public void Work()
        {
            ShowInfo();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Амнистия.");
            Console.ReadLine();
            Console.Clear();

            var criminalsSort = _criminals.Where(criminal => criminal.Cause != "Антиправительственное");
            _criminals = criminalsSort.ToList();
            ShowInfo();
            Console.ReadLine();
        }

        public void ShowInfo()
        {
            foreach(var criminal in _criminals)
            {
                Console.WriteLine($"{criminal.Name} - {criminal.Cause}.");
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string Cause { get; private set; }

        public Criminal(string name, string cause)
        {
            Name = name;
            Cause = cause;
        }
    }
}
