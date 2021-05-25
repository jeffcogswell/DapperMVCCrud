using System;

namespace DepInj
{

    class Engine
    {
        public virtual void Run()
        {
            Console.WriteLine("Engine is Running");
        }
    }

    class EconomyEngine : Engine
    {
        public override void Run()
        {
            Console.WriteLine("Economy engine is running with good gas mileage!");
        }
    }

    class TurboEngine : Engine
    {
        public override void Run()
        {
            Console.WriteLine("Turbo engine is running really fast!");
        }
    }

    class SuperTurboEngine : Engine
    {
        public override void Run()
        {
            Console.WriteLine("Super Turbo is running!");
        }
    }

    class Car
    {
        Engine _engine;

        public Car(Engine newEngine)
        {
            _engine = newEngine;
        }

        public void Drive()
        {
            Console.WriteLine("Car is starting up!");
            _engine.Run();
            Console.WriteLine("Car is going");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //TurboEngine te = new TurboEngine();
            //Car ford = new Car(te);

            EconomyEngine ee = new EconomyEngine();
            //Car ford = new Car(ee);

            // Dependency Injection
            SuperTurboEngine ste = new SuperTurboEngine();
            Car ford = new Car(ste);

            ford.Drive();
        }
    }
}
