using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public interface IMovable
    {
        void Move(int x, int y);
        void Stop();
    }

    public interface IAttacker
    {
        void Attack(IVulnerable target);
    }

    public interface IVulnerable
    {
        void TakeDamage(int damage);
        bool IsAlive { get; }
    }

    public class Player : IMovable, IAttacker, IVulnerable
    {
        public int Health { get; private set; } = 100;
        public bool IsAlive => Health > 0;

        public void Move(int x, int y)
        {
            Console.WriteLine($"Player moved to ({x}, {y})");
        }

        public void Stop()
        {
            Console.WriteLine("Player stopped");
        }

        public void Attack(IVulnerable target)
        {
            Console.WriteLine("Player attacks");
            target.TakeDamage(10);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Player took {damage} damage. Remaining health: {Health}");
        }
    }

    public class Enemy : IMovable, IAttacker, IVulnerable
    {
        public int Health { get; private set; } = 50;
        public bool IsAlive => Health > 0;

        public void Move(int x, int y)
        {
            Console.WriteLine($"Enemy moved to ({x}, {y})");
        }

        public void Stop()
        {
            Console.WriteLine("Enemy stopped");
        }

        public void Attack(IVulnerable target)
        {
            Console.WriteLine("Enemy attacks");
            target.TakeDamage(5);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Enemy took {damage} damage. Remaining health: {Health}");
        }
    }
}
