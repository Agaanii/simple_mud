using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    abstract class Spell
    {
        protected int amount;
        public string name;
        public abstract void Cast(Person target);

        int[] thing;
        int[][] things;
        int[,] thing2 = new int[6,9];
        int[,] thing3 =
        {
            {1,2,3 },
            {4,5,6 }
        };
    }

    class HealSpell : Spell
    {
        public override void Cast(Person target)
        {
            target.health += amount;
        }
    }

    class DamageSpell : Spell
    {
        public override void Cast(Person target)
        {
            target.health -= amount;
        }
    }

    class Person
    {
        public int health;
        public string name;
        
        protected IList<Spell> spells;

        public Person()
        {
            spells = new List<Spell>();
            spells.Add(new HealSpell());
            spells.Add(new DamageSpell());
        }

        public virtual Spell ChooseSpell()
        {
            return spells[0];
        }
    }

    class PlayerControlledPerson : Person
    {
        public override Spell ChooseSpell()
        {
            int spellIndex = 0;
            foreach (var s in spells)
            {
                Console.WriteLine("Input " + ++spellIndex + " to cast " + s.name);
            }
            string input = Console.ReadLine();
            int numInput;
            if (int.TryParse(input, out numInput))
            {
                return spells[numInput - 1];
            }
            throw (new Exception("Screw you"));
            // Print off all spells
            // Select input to choose
            // Return
        }
    }

    //interface IList2
    //{
    //    void PrintMe();
    //    void Add(int i);
    //}
    //class List2 : IList2
    //{
    //    void IList2.Add(int i)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    void IList2.PrintMe()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

// Characters + enemies
//   --- Health
//   --- Damage-dealing
//        - Amount of damage
//        - target
//        - caster
//   --- heals
//        - Amount of damage
//        - target
//        - caster

//   --- names
