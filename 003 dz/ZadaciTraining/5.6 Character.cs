using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class Character
    {
        protected int health;
        protected int damage;

        protected Character(int health, int damage)
        {
            this.health = health;
            this.damage = damage;
        }

        public abstract void SpecialAbility();
        public virtual void Attack(Character target)
        {
            target.ReceiveDamage(damage);
        }

        protected virtual void ReceiveDamage(int amount)
        {
            health -= amount;
            if (health < 0) health = 0;
        }
    }

    public class Warrior : Character
    {
        public Warrior() : base(100, 10) { }

        public override void SpecialAbility()
        {
            Console.WriteLine("Warrior uses Berserk Rage!");
            damage *= 2;
        }
    }

    public class Mage : Character
    {
        private int mana;

        public Mage() : base(70, 15)
        {
            mana = 100;
        }

        public override void SpecialAbility()
        {
            if (mana >= 30)
            {
                Console.WriteLine("Mage casts Fireball!");
                mana -= 30;
            }
            else
            {
                Console.WriteLine("Not enough mana!");
            }
        }
    }

    public class Archer : Character
    {
        private int arrows;

        public Archer() : base(80, 12)
        {
            arrows = 20;
        }

        public override void SpecialAbility()
        {
            if (arrows >= 3)
            {
                Console.WriteLine("Archer uses Triple Shot!");
                arrows -= 3;
            }
            else
            {
                Console.WriteLine("Not enough arrows!");
            }
        }
    }
}
