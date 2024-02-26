using System;

namespace HasADemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            PetrolEngine p = new PetrolEngine();
            DieselEngine d = new DieselEngine();
            GasEngine g = new GasEngine();
            car.engine = d;
            car.Move();
        }
    }


    public class Car
    {
        public Engine engine { get; set; }
        public void Move()
        {
            engine.Start();
        }
    }
    abstract public class Engine
    {
        abstract public void Start();
    }

    public class PetrolEngine : Engine
    {
        public override void Start()
        {
            Console.WriteLine("Starting Petrol Engine");
        }
    }

    public class DieselEngine : Engine
    {
        public override void Start()
        {
            Console.WriteLine("Starting Diesel Engine");
        }
    }

    public class GasEngine : Engine
    {
        public override void Start()
        {
            Console.WriteLine("Starting Gas Engine");
        }
    }
}
