using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IFurnitureFactory furnitureFactory = new ModernFurnitureFactory();
            furnitureFactory.CreateChair();
            furnitureFactory.CreateSofa();
            furnitureFactory.CreateTable();
        }
    }

    public interface ICoffeeTable
    {
        bool CanOpen();
        bool CanRotate();
    }
    class VictorianCoffeeTable : ICoffeeTable
    {
        public VictorianCoffeeTable()
        {
            Console.WriteLine("Victorian Coffee Table");
        }
        public bool CanOpen() => false;

        public bool CanRotate() => true;
    }
    class ModernCoffeeTable : ICoffeeTable
    {
        public ModernCoffeeTable()
        {
            Console.WriteLine("Modern Coffee Table");
        }
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
        public VictorianSofa()
        {
            Console.WriteLine("Victorian Sofa");
        }
        public bool CanOpen() => false;

        public bool HasCorner() => true;
    }
    class ModernSofa : ISofa
    {
        public ModernSofa()
        {
            Console.WriteLine("Modern Sofa");
        }
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
        public VictorianChair()
        {
            Console.WriteLine("Victorian Chair");
        }
        public bool HasLegs() => true;

        public bool SitOn() => true;
    }
    public class ModernChair : IChair
    {
        public ModernChair()
        {
            Console.WriteLine("Modern Chair");
        }
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
