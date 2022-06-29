using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isWork = true;
            int variable = 1;
            string userInput;
            Salesman salesman = new Salesman(0);
            Player player = new Player(100000);

            while (isWork)
            {
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"Денег:{player.Money}.");
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Меню магазина:");
                Console.WriteLine("\n1 - показать весь товар.\n2 - купить товар.\n3 - посмотреть свой инвентарь.\n4 - выйти из магазина.\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.DefineInfo(salesman, player);
                        break;
                    case "2":
                        player.BuyOperation(salesman, player);
                        break;
                    case "3":
                        player.DefineInfo(salesman, player, variable);
                        break;
                    case "4":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Human
    {
        private protected List<Product> _inventory = new List<Product>();
        public int Money { get; private set; }

        public Human(int money)
        {
            Money = money;
        }

        public void DefineInfo(Salesman salesman, Player player, int variable = 0)
        {
            if (variable == 0 )
            {
                ShowAllProduct(salesman._inventory);
            }
            else
            {
                ShowAllProduct(player._inventory);
            }
        }

        public void BuyOperation(Salesman salesman, Player player)
        {
            string userInput;
            int idProduct;

            Console.Write("Введите Id товара, которое хотите приобрести.");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                idProduct = SerachIdProduct(salesman._inventory, result);

                if (idProduct >= 0)
                {
                    if (ExaminationPrice(player, salesman, idProduct))
                    {  
                        player._inventory.Add(salesman.DeleteProduct(idProduct));
                        TransferMoney(salesman, player, player._inventory, idProduct);
                        Console.WriteLine("Товар куплен.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Такого товара нет.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void ShowAllProduct(List<Product> products)
        {
            if(products.Count > 0)
            {
                foreach (Product subject in products)
                {
                    Console.WriteLine($"Товар под ID:{subject.Id} имеет название: {subject.Name} и стоит:{subject.Price}.");
                }
            }
            else
            {
                Console.WriteLine("Пусто.");
            }

            Console.ReadLine();
            Console.Clear();
        }

        private int SerachIdProduct(List<Product> products, int userInput)
        {
            int intermediateId = 0;
            int idProduct = -1;

            foreach (var product in products)
            {
                if (product.Id == userInput)
                {
                    idProduct = intermediateId;
                }

                intermediateId++;
            }

            return idProduct;
        }

        private Product DeleteProduct(int userInput)
        {
            Product product;
            product = _inventory[userInput];
            _inventory.RemoveAt(userInput);
            return product;
        }

        private void TransferMoney(Salesman salesman, Player player, List<Product> inventory, int productId)
        {
            int price = inventory[inventory.Count - 1].Price;
            player.Money -= price;
            salesman.Money += price;
        }

        private bool ExaminationPrice(Player player, Salesman salesman, int productId)
        {
            if (salesman._inventory[productId].Price <= player.Money)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Player : Human
    {
        public Player (int money) : base(money) { }
    }

    class Salesman : Human
    {
        public Salesman(int money) : base(money)
        {
            _inventory.Add(new Product("Яблоко", 100));
            _inventory.Add(new Product("Груша", 90));
            _inventory.Add(new Product("Виноград", 150));
            _inventory.Add(new Product("Арбуз", 300));
            _inventory.Add(new Product("Топор", 1100));
            _inventory.Add(new Product("Меч", 1000));
            _inventory.Add(new Product("Зелье", 40));
            _inventory.Add(new Product("Сапоги", 500));
            _inventory.Add(new Product("Лопата", 100000));
        }
    }

    class Product
    {
        private List<Product> _inventory = new List<Product>();

        private static int _ids = 100;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price{ get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
            Id = ++_ids;
        }
    }
}
