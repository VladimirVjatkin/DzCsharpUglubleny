using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class Weapon
    {
        protected int ammo;
        protected int damage;

        protected Weapon(int initialAmmo, int damage)
        {
            this.ammo = initialAmmo;
            this.damage = damage;
        }

        public abstract void Attack();
        public abstract void Reload();

        public string GetInfo()
        {
            return $"{GetType().Name}: Ammo - {ammo}, Damage - {damage}";
        }
    }

    public class Pistol : Weapon
    {
        public Pistol() : base(10, 20) { }

        public override void Attack()
        {
            if (ammo > 0)
            {
                Console.WriteLine($"Pistol fired! Damage dealt: {damage}");
                ammo--;
            }
            else
            {
                Console.WriteLine("Pistol is out of ammo!");
            }
        }

        public override void Reload()
        {
            ammo = 10;
            Console.WriteLine("Pistol reloaded.");
        }
    }

    public class Shotgun : Weapon
    {
        public Shotgun() : base(5, 50) { }

        public override void Attack()
        {
            if (ammo > 0)
            {
                Console.WriteLine($"Shotgun fired! Damage dealt: {damage}");
                ammo--;
            }
            else
            {
                Console.WriteLine("Shotgun is out of ammo!");
            }
        }

        public override void Reload()
        {
            ammo = 5;
            Console.WriteLine("Shotgun reloaded.");
        }
    }
}
