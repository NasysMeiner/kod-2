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
                    _cardDeck.DeleteCard(number);
                    _inventory[numberOfCards - 1].InfoCard(_inventory[numberOfCards - 1]);
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
                card.InfoCard(card);
            }
        }
    }

    class CardDeck
    {   
        private List<Card> _cards = new List<Card>();
        private string _name;

        public void CreateCardDeck()
        {
            int numberOfSuits = 4;

            for (int i = 0; i < numberOfSuits; i++)
            {
                if (i == 0)
                {
                    _name = "трефы";
                }
                else if (i == 1)
                {
                    _name = "Бубны";
                }
                else if (i == 2)
                {
                    _name = "Червы";
                }
                else
                {
                    _name = "Пики";
                }

                CreateCards(_name);
            }
        }

        private void CreateCards(string name)
        {
            int amountCard = 13;

            for (int i = 0; i < amountCard; i++)
            {
                
                NewCard(name, i);            
            }
        }

        private void NewCard(string suit, int intermediate)
        {
            string name;

            if (intermediate == 0)
            {
                name = "Туз";
            }
            else if (intermediate == 10)
            {
                name = "Валет";
            }
            else if (intermediate == 11)
            {
                name = "Дама";
            }
            else if (intermediate == 12)
            {
                name = "Король";
            }
            else
            {
                name = $"{intermediate + 1}";
            }

            Card card = new Card(suit, name);
            _cards.Add(card);
        }

        public Card TakeTheCard(int number)
        {
            return _cards[number];
        }

        public void DeleteCard(int number)
        {
            _cards.RemoveAt(number);
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

        public void InfoCard(Card card)
        {
            Console.WriteLine($"Карта: {card._name} {card._suit}");
        }
    }
}
