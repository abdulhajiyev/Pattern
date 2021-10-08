using System;

namespace BuilderTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public int Seat { get; set; }
        public double Engine { get; set; }
        public int TripComputer { get; set; }
        public int Gps { get; set; }

        public override string ToString() =>
            @$"Name: {Name}
Seat: {Seat}
Engine: {Engine}
TripComputer: {TripComputer}
Gps: {Gps}";
    }

    public class CarManual
    {
        public string Name { get; set; }
        public int Seat { get; set; }
        public double Engine { get; set; }
        public int TripComputer { get; set; }
        public int Gps { get; set; }

        public override string ToString() =>
            @$"Name: {Name}
Seat: {Seat}
Engine: {Engine}
TripComputer: {TripComputer}
Gps: {Gps}";
    }

    public interface IBuilder
    {
        IBuilder Reset();
        IBuilder SetSeat();
        IBuilder SetEngine();
        IBuilder SetTripComputer();
        IBuilder SetGps();
        Car Car { get; set; }
        CarManual CarManual { get; set; }
    }

    public class CarBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car { Name = "Car" };
        public CarManual CarManual { get; set; } = new CarManual { Name = "CarManual" };

        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }

        public IBuilder SetSeat()
        {
            Car.Seat = 8;
            return this;
        }

        public IBuilder SetEngine()
        {
            Car.Engine = 1;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            Car.TripComputer = 4;
            return this;
        }

        public IBuilder SetGps()
        {
            Car.Gps = 2;
            return this;
        }


        public Car GetCar()
        {
            return Car;
        }
    }

    public class CarManualBuilder : IBuilder
    {
        public CarManual CarManual { get; set; } = new CarManual { Name = "CarManual" };

        public IBuilder Reset()
        {
            CarManual = new CarManual();
            return this;
        }

        public IBuilder SetSeat()
        {
            CarManual.Seat = 88;
            return this;
        }

        public IBuilder SetEngine()
        {
            CarManual.Engine = 11;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            CarManual.TripComputer = 44;
            return this;
        }

        public IBuilder SetGps()
        {
            CarManual.Gps = 22;
            return this;
        }

        public CarManual GetCar()
        {
            return CarManual;
        }
    }

    class Director
    {
        private IBuilder Builder { get; set; }

        public Director(IBuilder builder)
        {
            Builder = builder;
        }

        public void ChangeBuilder(IBuilder builder)
        {
            Builder = builder;
        }

        public Car Make(string type)
        {
            Builder.Reset();
            switch (type)
            {
                case "SUV":
                    Builder.Car.Name = "SUV";
                    return Builder.SetSeat().SetEngine().SetTripComputer().SetGps().GetCar();
                case "SportsCar":
                    Builder.Car.Name = "SportsCar";
                    return Builder.SetSeat().SetEngine().GetCar();
                case "Car":
                    Builder.Car.Name = "Car ";
                    return Builder.SetSeat().GetCar();
                default:
                    throw new Exception("Wrong Type");
            }
        }
    }   
}
