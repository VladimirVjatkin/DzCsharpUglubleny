using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public class GameCharacter
    {
        private int health;
        private int armor;
        private int damage;

        public GameCharacter(int health, int armor, int damage)
        {
            this.health = health;
            this.armor = armor;
            this.damage = damage;
        }

        public void Attack(GameCharacter target)
        {
            int actualDamage = CalculateActualDamage(damage, target.armor);
            target.ReceiveDamage(actualDamage);
        }

        private void ReceiveDamage(int incomingDamage)
        {
            health -= incomingDamage;
            if (health < 0) health = 0;
        }

        private int CalculateActualDamage(int rawDamage, int targetArmor)
        {
            return Math.Max(rawDamage - targetArmor, 0);
        }

        public int GetHealth() => health;
    }
}
