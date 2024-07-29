using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class Vehicle
    {
        protected bool isRunning;
        protected int fuel;

        public virtual void StartEngine()
        {
            if (fuel > 0)
            {
                isRunning = true;
                Console.WriteLine("Engine started.");
            }
            else
            {
                Console.WriteLine("Not enough fuel to start.");
            }
        }

        public virtual void StopEngine()
        {
            isRunning = false;
            Console.WriteLine("Engine stopped.");
        }

        public abstract void Refuel(int amount);
    }

    public class Car : Vehicle
    {
        public override void Refuel(int amount)
        {
            fuel += amount;
            Console.WriteLine($"Car refueled. Current fuel: {fuel}");
        }

        public override void StartEngine()
        {
            base.StartEngine();
            if (isRunning)
            {
                Console.WriteLine("Car is ready to drive.");
            }
        }
    }

    public class ElectricCar : Vehicle
    {
        private int batteryCharge;

        public override void Refuel(int amount)
        {
            batteryCharge += amount;
            Console.WriteLine($"Electric car charged. Current charge: {batteryCharge}%");
        }

        public override void StartEngine()
        {
            if (batteryCharge > 0)
            {
                isRunning = true;
                Console.WriteLine("Electric motor activated.");
            }
            else
            {
                Console.WriteLine("Not enough charge to start.");
            }
        }
    }
}
