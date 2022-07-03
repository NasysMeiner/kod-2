using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            _patients.Add(new Patient("Oleg", "ОРВИ", 18));
            _patients.Add(new Patient("Андрей", "Грип", 16));
            _patients.Add(new Patient("Эдик", "ОРВИ", 30));
            _patients.Add(new Patient("Владик", "Грип", 57));
            _patients.Add(new Patient("Никита", "ОРВИ", 24));
            _patients.Add(new Patient("Акакий", "ОРВИ", 32));
            _patients.Add(new Patient("Валерий", "Ветрянка", 26));
            _patients.Add(new Patient("Глеб", "Грип", 38));
            _patients.Add(new Patient("Марк", "Ветрянка", 17));
            _patients.Add(new Patient("Карл", "Грип", 27));
        }

        public void Work()
        {
            string userInput;

            while (true)
            {
                ShowInfo();
                Console.WriteLine("Меню\n1 - отсортировать список по ФИО.\n2 - отсортировать по возрасту\n3 - вывести больных с кокретным заболеванием.");
                userInput = Console.ReadLine();
                Console.Clear();
                SelectItem(userInput);                        
            }
        }

        public void ShowInfo()
        {
            int positionY = 0;

            foreach(Patient patient in _patients)
            {
                Console.SetCursorPosition(80, positionY);
                Console.WriteLine($"{patient.Name} - {patient.Age} лет, болен:{patient.Disease}.");
                positionY++;
            }
        }

        private void SelectItem(string userInput)
        {
            if (int.TryParse(userInput, out int input))
            {
                switch (input)
                {
                    case 1:
                        SortName();
                        break;
                    case 2:
                        SortAge();
                        break;
                    case 3:
                        ShowDisease();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        private void SortName()
        {
            var sortName = _patients.OrderBy(patient => patient.Name.Substring(0, 1));
            _patients = sortName.ToList();
            Console.WriteLine("Сортировка выполнена");
        }

        private void SortAge()
        {
            var sortAge = _patients.OrderBy(patient => patient.Age);
            _patients = sortAge.ToList();
            Console.WriteLine("Сортировка выполнена");
        }

        private void ShowDisease()
        {
            string userInputDisease;

            Console.Write("Введите болезнь:");
            userInputDisease = Console.ReadLine();

            _patients.Sort((left, right) => left.Disease.CompareTo(right.Disease));
            var diseases = _patients.Where(patient => patient.Disease.StartsWith(userInputDisease));

            Console.WriteLine();
            
            foreach (var disease in diseases)
            {
                Console.WriteLine($"{disease.Name} - {disease.Age} лет, болен:{disease.Disease}.");
            }           
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }

        public Patient(string name, string disease, int age)
        {
            Name = name;
            Disease = disease;
            Age = age;
        }
    }
}
