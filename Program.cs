using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int variable = 0;
            Console.CursorVisible = false;
            Warrior[] warriors = { new Knight(500, 90, 75), new Barbarian(700, 70, 2, 10), new Assassin(400, 70, 150), new Mag(400, 100, 1.1, 3), new Archer(350, 90, 2) };

            Console.WriteLine("Выберите 1 бойца:");
            Console.WriteLine("\n1 - рыцарь (имеет большое кол-во брони).\n2 - варвар (атаки имеют двойной урон).\n3 - ассасин (всегда бьёт критами).\n4 - маг (имеет процентную прибавку по урону).\n5 - лучник (уколняется каждые несколько ходов).");
            userInput = Console.ReadLine();

            Warrior warrior1 = warriors[Convert.ToInt32(userInput) - 1];

            Console.WriteLine("Выберите 2 бойца:");
            Console.WriteLine("\n1 - рыцарь.\n2 - варвар.\n3 - ассасин.\n4 - маг.\n5 - лучник.");
            userInput = Console.ReadLine();

            Warrior warrior2 = warriors[Convert.ToInt32(userInput) - 1];
            warrior1.ShowStats();
            warrior2.ShowStats();
            Console.WriteLine("\nНажмите чтобы начать бой.");
            Console.ReadKey();
            Console.Clear();

            while(warrior1.Health > 0 && warrior2.Health > 0)
            {
                warrior1.TakeDamage(warrior2.Damage, variable);
                warrior2.TakeDamage(warrior1.Damage, variable);
                warrior1.ShowStats();
                warrior2.ShowStats();
                variable++;
                Console.ReadLine();
                Console.Clear();
            }

            if (warrior1.Health <= 0)
            {
                Console.WriteLine($"Победил: {warrior2.Name}");
            }
            else if (warrior2.Health <= 0)
            {
                Console.WriteLine($"Победил: {warrior1.Name}");
            }
            else
            {
                Console.WriteLine("Ничья");
            }

            Console.ReadLine();
        }
    }

    class Warrior
    {
        public string Name { get; private set;}
        public int CooldownShield { get; private set;}
        public int CooldownDodge { get; private set;}
        public double Health { get; private set;}
        public double Damage { get; private set;}
        public int Armor { get; private set;}

        public Warrior(double health, double damage, string name, int armor = 1, int cooldownDodge = 0, int cooldownShield = 0)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
            CooldownDodge = cooldownDodge;
            CooldownShield = cooldownShield;
        }

        public void TakeDamage(double damage, int variable)
        {
            if(CooldownDodge != 0 && variable > 0)
            {
                if(variable % CooldownDodge == 0)
                {
                    damage = 0;
                    Console.WriteLine($"{Name} уклонился.\n");
                }
            }

            if(CooldownShield != 0 && variable > 0)
            {
                if(variable % CooldownShield == 0)
                {
                    damage *= 0.95;
                    Console.WriteLine($"{Name} использовал щит.\n");
                }
            }

            Health -= damage * ((Convert.ToDouble(100) - Armor) / Convert.ToDouble(100));
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}: {Health}Hp, урона: {Damage} и брони:{Armor}.");
        }
    }

    class Knight : Warrior
    {
        public Knight(double health, int damage, int armor) : base(health, damage, "Рыцарь", armor)
        {

        }
    }

    class Barbarian : Warrior
    {
        public Barbarian(double health, int damage, int attackSpeed, int armor) : base(health, damage * attackSpeed, "Варвар", armor)
        {

        }
    }

    class Assassin : Warrior
    {
        public Assassin(double health, int damage, double critDamage) : base(health, damage * (critDamage / 100), "Ассасин")
        {

        }
    }

    class Mag : Warrior
    {
        public Mag(double health, int damage, double damageRatio, int cooldownShield) : base(health , damage * damageRatio, "Маг", cooldownShield:cooldownShield)
        {

        }
    }

    class Archer : Warrior
    {
        public Archer(double health, int damage, int cooldownDodge) : base(health, damage, "Лучник", cooldownDodge:cooldownDodge)
        {

        }
    }

}
