using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface ICoffeeTable
    {
        bool CanOpen();
        bool CanRotate();
    }

    class VictorianCoffeeTable : ICoffeeTable
    {
        public bool CanOpen() => false;

        public bool CanRotate() => true;
    }

    class ModernCoffeeTable : ICoffeeTable
    {
        public bool CanOpen() => false;

        public bool CanRotate() => true;
    }



    public interface ISofa
    {
        bool HasCorner();
        bool CanOpen();
    }
    class VictorianSofa : ISofa
    {
        public bool CanOpen() => false;

        public bool HasCorner() => true;
    }

    class ModernSofa : ISofa
    {
        public bool CanOpen() => true;

        public bool HasCorner() => true;
    }



    public interface IChair
    {
        public bool HasLegs();

        public bool SitOn();
    }

    public class VictorianChair : IChair
    {
        public bool HasLegs() => true;

        public bool SitOn() => true;
    }

    public class ModernChair : IChair
    {
        public bool HasLegs() => true;

        public bool SitOn() => true;
    }


    interface IFurnitureFactory
    {
        ICoffeeTable CreateTable();
        ISofa CreateSofa();
        IChair CreateChair();
    }


    class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new VictorianChair();

        public ISofa CreateSofa() => new VictorianSofa();

        public ICoffeeTable CreateTable() => new VictorianCoffeeTable();
    }

    class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ModernChair();

        public ISofa CreateSofa() => new ModernSofa();

        public ICoffeeTable CreateTable() => new ModernCoffeeTable();
    }
}
