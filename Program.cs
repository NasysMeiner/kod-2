using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            CarService carService = new CarService();
            carService.Work();
        }
    }

    class CarService
    {
        private List<Detail> _details = new List<Detail>();
        private Queue<Detail> _damageDetails = new Queue<Detail>();
        private Queue<Car> _cars = new Queue<Car>();
        private Car _nowСar;
        public int Money { get; private set; }
        public int PriceMoney { get; private set; }
        public int Fine { get; private set; }

        public CarService()
        {
            PriceMoney = 1000;
            Fine = 700;

            _details.Add(new Detail("Колесо", true, 1000));
            _details.Add(new Detail("Колесо", true, 1000));
            _details.Add(new Detail("Подъёмник окна", true, 2000));
            _details.Add(new Detail("Дверная ручка", true, 500));
            _details.Add(new Detail("Лобовое стекло", true, 5000));
            _details.Add(new Detail("Лобовое стекло", true, 5000));
            _details.Add(new Detail("Торпеда", true, 2500));
            _details.Add(new Detail("Фары", true, 1500));
            _details.Add(new Detail("Руль", true, 700));

            _cars.Enqueue(new Car(true, true, false, true, true, true, true));
            _cars.Enqueue(new Car(true, false, true, true, true, true, true));
            _cars.Enqueue(new Car(true, true, true, true, false, true, true));
            _cars.Enqueue(new Car(true, true, true, true, true, true, false));
            _cars.Enqueue(new Car(true, true, false, true, true, true, true));
            _cars.Enqueue(new Car(true, false, true, true, true, true, true));
            _cars.Enqueue(new Car(false, true, true, true, true, true, true));
        }

        public void Work()
        {
            Random random = new Random();

            ShowAllDetail();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Клиентов в очереди:{_cars.Count}.");
            Console.ReadLine();
            Console.Clear();

            while (_cars.Count > 0)
            {
                ShowAllDetail();
                WatchCar();
                RepairCar(random);
            }

            Console.Clear();
            Console.WriteLine($"Клиенты закончились.");
            ShowAllDetail();
            Console.ReadLine();
        }

        private void ShowAllDetail()
        {
            int positionY = 2;

            Console.SetCursorPosition(80, 0);
            Console.WriteLine($"Ваши деньги:{Money}\n");

            foreach (Detail detail in _details)
            {
                Console.SetCursorPosition(80, positionY);
                Console.WriteLine($"{detail.Name}.");
                positionY++;
            }
        }

        private void WatchCar()
        {
            _nowСar = _cars.Dequeue();

            Console.SetCursorPosition(0, 0);

            foreach (Detail detail in _nowСar._car)
            {
                if (detail.Condition == false)
                {
                    Console.WriteLine($"{detail.Name} - требует замены.");
                    _damageDetails.Enqueue(detail);
                }
            }
        }

        private void RepairCar(Random random)
        {
            Detail emptyDetail = new Detail();
            Detail replaceDetail = _damageDetails.Dequeue();
            string userInput;
            int repairStatus = 0;
            int number;
            int damageMoney = 0;
            int plusMoney = 0;
            bool workStatus = false;

            Console.WriteLine("\nМеню\n1 - Заменить деталь.\n2 - отказаться от клиента.");
            userInput = Console.ReadLine();

            if(userInput == "1")
            {
                Detail deleteDetail = new Detail();

                foreach (Detail detail in _nowСar._car)
                {
                    if (detail.Condition == false)
                    {                        
                        foreach(Detail newDetail in _details)
                        {
                            if(newDetail.Name == replaceDetail.Name)
                            {
                                _nowСar.Replacement(replaceDetail);
                                deleteDetail = newDetail;
                                repairStatus++;
                                Console.WriteLine("Замена прошла успешно.");

                                Money += deleteDetail.PriceDetail + PriceMoney;
                                plusMoney = deleteDetail.PriceDetail;
                                replaceDetail = emptyDetail;
                                workStatus = true;
                                
                                if(_damageDetails.Count > 0)
                                {
                                    replaceDetail = _damageDetails.Dequeue();
                                }
                            }
                        }

                        if(repairStatus > 0)
                        {
                            _details.Remove(deleteDetail);
                            repairStatus--;
                        }
                        else
                        {
                            number = random.Next(0, _damageDetails.Count);
                            deleteDetail = _details[number];
                            damageMoney = deleteDetail.PriceDetail;
                            _details.Remove(deleteDetail);
                        }
                    }
                }

                if (workStatus)
                {
                    Console.WriteLine($"\nКлиент уехал довольный и заплатил вам {plusMoney} за деталь и {PriceMoney} за работу.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Вы ставите не ту деталь, и возмещаете ущёрб клиенту в размере {damageMoney}.");
                    Money -= damageMoney;
                    Console.ReadLine();
                    Console.Clear();
                }            
            }
            else
            {
                Console.WriteLine($"Вы ставите не ту деталь, и получаете штраф в размере {Fine}.");
                Money -= Fine;
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class Car
    {
        public List<Detail> _car = new List<Detail>();

        public Car(bool wheel, bool windshild, bool doorhandle, bool windowRaiser, bool torpedo, bool lights, bool steeringWheel)
        {
            _car.Add(new Detail("Колесо", wheel));
            _car.Add(new Detail("Подъёмник окна", windshild));
            _car.Add(new Detail("Дверная ручка", doorhandle));
            _car.Add(new Detail("Лобовое стекло", windowRaiser));
            _car.Add(new Detail("Торпеда", torpedo));
            _car.Add(new Detail("Фары", lights));
            _car.Add(new Detail("Руль", steeringWheel));
        }

        public void Replacement(Detail detail)
        {
            detail.Repair();
        }
    }

    class Detail
    {
        public string Name { get; private set; }
        public bool Condition { get; private set; }
        public int PriceDetail { get; private set; }

        public Detail(string name = "", bool condition = true, int priceDetail = 0)
        {
            Name = name;
            Condition = condition;
            PriceDetail = priceDetail;
        }

        public void Repair()
        {
            Condition = true;
        }
    }
}
