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
                        salesman.ShowAllProduct(salesman.ShowInventory);
                        break;
                    case "2":
                        player.BuyOperation(salesman, player);
                        break;
                    case "3":
                        player.ShowAllProduct(player.ShowInventory);
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
        public int Money { get; private set; }

        public Human(int money)
        {
            Money = money;
        }

        public void ShowAllProduct(List<Product> subjects)
        {

            if(subjects.Count > 0)
            {
                foreach (Product subject in subjects)
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

        public void BuyOperation(Salesman salesman, Player player)
        {
            string userInput;
            int idProduct;

            Console.Write("Введите Id товара, которое хотите приобрести.");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                idProduct = SerachIdProduct(salesman.ShowInventory, result);

                if (idProduct >= 0)
                {
                    if (ExaminationPrice(player, salesman.ShowInventory, idProduct))
                    {
                        player.AddProduct(salesman.DeleteProduct(idProduct));                
                        TransferMoney(salesman, player, player.ShowInventory, idProduct);
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

        private void TransferMoney(Salesman salesman, Player player, List<Product> inventory, int productId)
        {
            int price = inventory[inventory.Count - 1].Price;
            player.Money -= price;
            salesman.Money += price;
        }

        private bool ExaminationPrice(Player player, List<Product> inventory, int productId)
        {
            if (inventory[productId].Price <= player.Money)
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
        private List<Product> _inventory = new List<Product>();

        public List<Product> ShowInventory
        {
            get { return _inventory; }
            private set { }
        }

        public Player (int money) : base(money) { }

        public void AddProduct(Product product)
        {
            _inventory.Add(product);
        }
    }

    class Salesman : Human
    {
        public List<Product> _products = new List<Product>();

        public List<Product> ShowInventory
        {
            get { return _products; }
            private set { }
        }

        public Salesman(int money) : base(money)
        {
            _products.Add(new Product("Яблоко", 100));
            _products.Add(new Product("Груша", 90));
            _products.Add(new Product("Виноград", 150));
            _products.Add(new Product("Арбуз", 300));
            _products.Add(new Product("Топор", 1100));
            _products.Add(new Product("Меч", 1000));
            _products.Add(new Product("Зелье", 40));
            _products.Add(new Product("Сапоги", 500));
            _products.Add(new Product("Лопата", 100000));
        }

        public Product DeleteProduct(int userInput)
        {
            Product product;
            product = _products[userInput];
            _products.RemoveAt(userInput);
            return product;
        }
    }

    class Product
    {
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
