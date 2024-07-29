using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class Vehicle
    {
        public abstract void StartEngine();
        public abstract void StopEngine();
        public abstract int Speed { get; set; }

        public string Description()
        {
            return $"This is a {GetType().Name} with a max speed of {Speed} km/h.";
        }
    }

    public class Car : Vehicle
    {
        private bool isEngineRunning;
        public override int Speed { get; set; } = 180;

        public override void StartEngine()
        {
            isEngineRunning = true;
            Console.WriteLine("Car engine started.");
        }

        public override void StopEngine()
        {
            isEngineRunning = false;
            Console.WriteLine("Car engine stopped.");
        }
    }

    public class Motorcycle : Vehicle
    {
        private bool isEngineRunning;
        public override int Speed { get; set; } = 200;

        public override void StartEngine()
        {
            isEngineRunning = true;
            Console.WriteLine("Motorcycle engine started.");
        }

        public override void StopEngine()
        {
            isEngineRunning = false;
            Console.WriteLine("Motorcycle engine stopped.");
        }
    }
}
