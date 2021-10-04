using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Logistics logistics = new SeaLogistics();
            ITransport transport = logistics.CreateTransport();
            transport.Deliver();
        }
    }

    public interface ITransport
    {
        public void Deliver();
    }

    class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Land");
        }
    }

    class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Sea");
        }
    }

    public abstract class Logistics
    {
        public void Delivery()
        {
            Console.WriteLine("Delivery");
        }
        public abstract ITransport CreateTransport();
    }

    class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Truck();
    }

    class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Ship();
    }
}
