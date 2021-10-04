using System;

namespace FactoryMethod
{
    public abstract class Logistics
    {
        public void Delivery()
        {
            Console.WriteLine("Delivery");
        }
        public abstract ITransport CreateTransport();
    }
}
