using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();      
            field.Play();
        }
    }

    public class Field
    {
        public void Play()
        {
            Platoon platoon1 = new Platoon(1);
            Platoon platoon2 = new Platoon(2);

            platoon1.CreatePlatoon1();
            platoon2.CreatePlatoon2();
            platoon1.ShowInfoPlatoon();
            platoon2.ShowInfoPlatoon();
            Fight(platoon1, platoon2);
            ShowInfo(platoon1 , platoon2);

            Console.ReadKey();
            Console.Clear();
        }

        public void Fight(Platoon platoon1, Platoon platoon2)
        {
            Fighter fighter1 = platoon1.NextUnit();
            Fighter fighter2 = platoon2.NextUnit();

            while (fighter1 != null && fighter2 != null)
            {
                if(fighter1.Health <= 0 || fighter2.Health <= 0)
                {
                    if(fighter1.Health <= 0)
                    {
                        fighter1 = platoon1.NextUnit();
                    }
                    if(fighter2.Health <= 0)
                    {
                        fighter2 = platoon2.NextUnit();
                    }
                }
                else
                {
                    fighter1.TakeDamage(fighter2);
                    fighter2.TakeDamage(fighter1);
                    Console.WriteLine($"1 взвод:{fighter1.Name} - {fighter1.Health}Hp.\n2 Взвод: {fighter2.Name} - {fighter2.Health}Hp.");
                    Console.ReadLine();
                    Console.Clear();
                }               
            }

            if(fighter1 != null)
            {
                platoon1.AddUnit(fighter1);
            }
            if(fighter2 != null)
            {
                platoon2.AddUnit(fighter2);
            }
        }

        public void ShowInfo(Platoon platoon1, Platoon platoon2)
        {
            int numberUnits1 = platoon1.ShowInfoPlatoon();
            int numberUnits2 = platoon2.ShowInfoPlatoon();

            if(numberUnits1 != 0)
            {
                Console.WriteLine("Победил 1 взвод.");
            } 
            else if(numberUnits2 != 0)
            {
                Console.WriteLine("Победил 2 взвод.");
            }
            else
            {
                Console.WriteLine("Ничья");
            }
        }
    }

    public class Platoon
    {
        private int _numberSoldier = 0;
        private int _numberPlatoon;
        private List<Fighter> _warriors = new List<Fighter>();

        public Platoon(int number)
        {
            _numberPlatoon = number;
        }

        public void CreatePlatoon1()
        {
            _warriors.Add(new Soldier("Солдат", 100, 50, 1));
            _warriors.Add(new Tank("Танк", 1000, 350, 75, 2, 2, 0));
            _warriors.Add(new Ship("Корабль", 1500, 1000, 50, 3, 3, 1/4));
        }

        public void CreatePlatoon2()
        {
            _warriors.Add(new Soldier("Солдат", 500, 70, 1));
            _warriors.Add(new Airplane("Самолёт", 1000, 600, 15, 4, 3, 1/2));
            _warriors.Add(new Ship("Корабль", 1700, 650, 30, 3, 3, 1/4));
        }

        public void AddUnit(Fighter fighter)
        {
            _warriors.Add(fighter);
        }

        public int ShowInfoPlatoon()
        {
            int numberUnits = 0;
          
            if(_warriors.Count > 0)
            {
                Console.WriteLine($"Взвод под номером: {_numberPlatoon}.\nБоевые единицы внутри:\n");

                foreach(Fighter warror in _warriors)
                {
                    Console.WriteLine($"{warror.Name} - {warror.Health}Hp. {warror.Damage} урона и {warror.Armor} брони.");
                    numberUnits++;
                }

                Console.ReadKey();
                Console.Clear();

                return numberUnits;
            }           

            return numberUnits;
        } 
        
        public Fighter NextUnit()
        {
            if(_warriors.Count == 0)
            {
                return null;
            }
            else
            {
                Fighter fighter = _warriors[0];
                _warriors.RemoveAt(0);
                _numberSoldier++;

                return fighter;
            }
        }
    }

    public class Fighter
    {   
        public int AcquisitionRateDamage { get; protected set; }
        public string Name { get; protected set; }
        public int FactorDamage { get; protected set; }
        public int CombatUnit { get; protected set; }
        public double Health { get; protected set; }
        public int Armor { get; protected set; }
        public int BaseDamage { get; protected set; }
        public int Damage { get; protected set; }

        public Fighter(string name, double health, int damage, int armor = 0)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
            BaseDamage = damage;
            
        }

        public virtual void TakeDamage(Fighter fighter)
        {
            Health -= fighter.RecalculateDamage(CombatUnit) * (100 - Armor) / 100;
        }

        public virtual double RecalculateDamage(int number)
        {
            return Damage;
        }
    }

    public class Soldier : Fighter
    {      
        public Soldier(string name, double health, int damage, int combatUnit) : base(name, health, damage)
        {
            CombatUnit = combatUnit;
        }
    }

    public class Tank : Fighter
    {
        public Tank(string name, double health, int damage, int armor, int combatUnit, int factorDamage, int acquisitionRateDamage) : base(name, health, damage, armor)
        {
            CombatUnit = combatUnit;
            FactorDamage = factorDamage;
            AcquisitionRateDamage = acquisitionRateDamage;
        }

        public override void TakeDamage(Fighter fighter)
        {
            if(fighter is Soldier)
            {
                Health -= fighter.RecalculateDamage(CombatUnit) * AcquisitionRateDamage;
            }
            else
            {
                base.TakeDamage(fighter);
            }           
        }

        public override double RecalculateDamage(int number)
        {
            if(number == 1)
            {
                if(Damage != BaseDamage)
                {
                    return Damage;
                }
                else
                {
                    Damage *= FactorDamage;
                    return Damage;
                }
            }
            else
            {
                Damage = BaseDamage;
                return base.RecalculateDamage(CombatUnit);
            }
        }
    }

    public class Airplane : Fighter
    {
        public Airplane(string name, double health, int damage, int armor, int combatUnit, int factorDamage, int acquisitionRateDamage) : base(name, health, damage, armor)
        {
            CombatUnit = combatUnit;
            FactorDamage = factorDamage;
            AcquisitionRateDamage = acquisitionRateDamage;
        }

        public override void TakeDamage(Fighter fighter)
        {
            if(fighter is Tank)
            {
                Health -= fighter.RecalculateDamage(CombatUnit) * (100 - Armor) / 100 * AcquisitionRateDamage;
            }
            else
            {
                base.TakeDamage(fighter);
            }           
        }

        public override double RecalculateDamage(int number)
        {
            if(number == 2)
            {
                if(Damage != BaseDamage)
                {
                    return Damage;
                }
                else
                {
                    Damage *= FactorDamage;
                    return Damage;
                }              
            }
            else
            {
                Damage = BaseDamage;
                return base.RecalculateDamage(CombatUnit);
            }
        }
    }

    public class Ship : Fighter
    {
        public Ship(string name, double health, int damage, int armor, int combatUnit, int factorDamage, int acquisitionRateDamage) : base(name, health, damage, armor)
        {
            CombatUnit = combatUnit;
            FactorDamage = factorDamage;
            AcquisitionRateDamage = acquisitionRateDamage;
        }

        public override void TakeDamage(Fighter fighter)
        {
            if(fighter is Airplane)
            {
                Health -= fighter.RecalculateDamage(CombatUnit) * (100 - Armor) / 100 * AcquisitionRateDamage;
            }
            else
            {
                base.TakeDamage(fighter);
            }           
        }

        public override double RecalculateDamage(int number)
        {
            if(number == 2)
            {
                if(Damage != BaseDamage)
                {
                    return Damage;
                }
                else
                {
                    Damage *= FactorDamage;
                    return Damage;
                }
            }
            else
            {
                Damage = BaseDamage;
                return base.RecalculateDamage(CombatUnit);
            }
        }
    }
}
