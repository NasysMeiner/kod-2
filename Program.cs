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
            player.ToPlay();
            player.ShowInfoAllCards();
            Console.ReadLine();
        }
    }

    class Player
    {
        List<Card> inventory = new List<Card>();
        CardDeck cardDeck = new CardDeck();
        Random random = new Random();

        public void ToPlay()
        {
            bool isPlay = true;
            string userInput = "";
            int number = 0;
            int amountCard = 51;
            cardDeck.CreateCardDeck();

            while (isPlay)
            {
                number = random.Next(0, amountCard);
                amountCard--;

                Console.WriteLine("\n1 - тянуть карту.\n2 - вывести информацию о картах и выйти.");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    inventory.Add(cardDeck.TakeTheCard(number));
                    cardDeck.DeleteCard(number);
                    cardDeck.ShowInfoCard(number);
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
            foreach (Card card in inventory)
            {
                card.InfoCard(card);
            }
        }
    }

    class CardDeck
    {   
        List<Card> cards = new List<Card>();
        private string _name = "";

        public void CreateCardDeck()
        {
            for (int i = 0; i < 4; i++)
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

                CreateCard(_name);
            }
        }

        private void CreateCard(string name)
        {
            for (int i = 0; i < 13; i++)
            {
                Card card = new Card();
                card.NewCard(name, i);
                cards.Add(card);
            }
        }

        public Card TakeTheCard(int number)
        {
            return cards[number];
        }

        public void DeleteCard(int number)
        {
            cards.RemoveAt(number);
        }

        public void ShowInfoCard(int number)
        {
            cards[number].InfoCard(cards[number]);
        }
    }

    class Card
    {
        private string _suit;
        private string _name;

        public void NewCard(string suit, int i)
        {
            _suit = suit;

            if (i == 0)
            {
                _name = "Туз";
            }
            else if (i == 10)
            {
                _name = "Валет";
            }
            else if (i == 11)
            {
                _name = "Дама";
            }
            else if (i == 12)
            {
                _name = "Король";
            }
            else
            {
                _name = $"{i + 1}";
            }
        }

        public void InfoCard(Card card)
        {
            Console.WriteLine($"Карта: {card._name} {card._suit}");
        }
    }
}
