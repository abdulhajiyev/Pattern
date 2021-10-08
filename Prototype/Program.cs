using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car
            {
                Vendor = "Kia",
                Model = "Cerato",
                Year = 2020
            };
            Car car2 = car1.Clone() as Car;

            car1.Model = "Deep";

            Console.WriteLine(car1.Model);
            Console.WriteLine(car2.Model);
        }
    }

    interface IPrototype
    {
        IPrototype Clone();
    }

    class Car : IPrototype
    {
        public string Vendor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(Car prototype)
        {
            Vendor = prototype.Vendor;
            Model = prototype.Model;
            Year = prototype.Year;
        }

        public Car()
        {
            
        }

        public IPrototype Clone() => new Car(this);
    }
}
