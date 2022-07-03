using System;
using System.Collections.Generic;
using System.Linq;

namespace hw7._1
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
        private List<Criminal> _databases = new List<Criminal>();
        private List<Criminal> _databasesSort = new List<Criminal>();

        public Database()
        {
            _databases.Add(new Criminal("Andrey", 80, 175, "Фин", false));
            _databases.Add(new Criminal("Эдик", 74, 182, "Грузин", false));
            _databases.Add(new Criminal("Григорий", 123, 140, "Татарин", true));
            _databases.Add(new Criminal("Никита", 76, 187, "Мексиканец", false));
            _databases.Add(new Criminal("Andrey", 74, 182, "Грузин", false));
            _databases.Add(new Criminal("Andrey", 80, 175, "Фин", false));
            _databases.Add(new Criminal("Andrey", 80, 175, "Фин", false));
        }

        public void Work()
        {
            string userInputNationality;
            string userInputGrowth;
            string userInputWeight;

            Console.Write("Введите национальность:");
            userInputNationality = Console.ReadLine();

            Console.Write("Введите рост:");
            userInputGrowth = Console.ReadLine();

            Console.Write("Введите вес:");
            userInputWeight = Console.ReadLine();

            if(int.TryParse(userInputWeight, out int result1) && int.TryParse(userInputGrowth, out int result2))
            {
                var databaseSort = _databases.Where(criminal => criminal.Concluded == false && criminal.Nationality == userInputNationality && criminal.Growth == result2 && criminal.Weight == result1);
                _databasesSort = databaseSort.ToList();
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }

            ShowInfo();
            Console.ReadLine();
        }

        public void ShowInfo()
        {
            string concluded;

            foreach (Criminal criminal in _databasesSort)
            {     
                if(criminal.Concluded == true)
                {
                    concluded = "Заключён";
                }
                else
                {
                    concluded = "Не заключён";
                }

                Console.WriteLine($"{criminal.Name} - вес:{criminal.Growth}, вес:{criminal.Weight}, национальность:{criminal.Nationality}, {concluded}.");
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public bool Concluded { get; private set; }

        public Criminal(string name, int weight, int growth, string nationality, bool concluded)
        {
            Name = name;
            Growth = growth;
            Weight = weight;
            Nationality = nationality;
            Concluded = concluded;
        }
    }
}
