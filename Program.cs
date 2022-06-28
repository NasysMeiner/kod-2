using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Player player = new Player();
            player.Play();
            player.ShowInfoAllCards();
            Console.ReadLine();
        }
    }

    class Player
    {
        private List<Card> _inventory = new List<Card>();
        private CardDeck _cardDeck = new CardDeck();
        private Random _random = new Random();

        public void Play()
        {
            bool isPlay = true;
            string userInput;
            int number;
            int amountCard = 51;
            int numberOfCards = 0;

            _cardDeck.CreateCardDeck();

            while (isPlay)
            {
                number = _random.Next(0, amountCard);
                amountCard--;

                Console.WriteLine("\n1 - тянуть карту.\n2 - вывести информацию о картах и выйти.");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    _inventory.Add(_cardDeck.TakeTheCard(number));
                    numberOfCards++;                   
                    _cardDeck.ShowInfoCard(_inventory[numberOfCards - 1]);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userInput == "2")
                {
                    isPlay = false;                    
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void ShowInfoAllCards()
        {
            foreach (Card card in _inventory)
            {
                _cardDeck.ShowInfoCard(card);
            }
        }
    }

    class CardDeck
    {   
        private List<Card> _cards = new List<Card>();
        private string _name;

        public void CreateCardDeck()
        {
            string[] suits = { "Трефы", "Бубны", "Червы", "Пики" };
            string[] names = { "туз", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    Card card = new Card(suits[i], names[j]);
                    _cards.Add(card);
                }
            }
        }

        public Card TakeTheCard(int number)
        {
            Card timeCard = _cards[number];
            DeleteCard(number);
            return timeCard;
        }

        public void DeleteCard(int number)
        {
            _cards.RemoveAt(number);
        }

        public void ShowInfoCard(Card variable)
        {
            Console.WriteLine($"Карта: {variable.Name} {variable.Suit}");
        }
    }

    class Card
    {
        private string _suit;
        private string _name;

        public Card(string suit = "", string name = "")
        {
            _suit = suit;
            _name = name;
        }

        public string Suit
        {
            get { return _suit; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
