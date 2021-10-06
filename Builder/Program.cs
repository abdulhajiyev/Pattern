using System;

namespace Builder
{

    // Product
    // Director
    // Builder
    // Builder : Concrete

    static class Program
    {
        static void Main(string[] args)
        {
            /*IBuilder builder = new StoneBuilder();
            Home home = builder.BuildGarden().BuildDoor().BuildGarage().BuildRoof().GetHome();
            Console.WriteLine(home);*/

            IBuilder builder = new StoneBuilder();
            Director director = new Director(builder);
            Home home = director.Make("C");
            Console.WriteLine(home);
        }
    }

    public class Home
    {
        public string Name { get; set; }
        public int Walls { get; set; }
        public int Garage { get; set; }
        public int Garden { get; set; }
        public int Pool { get; set; }
        public int Window { get; set; }
        public int Door { get; set; }
        public bool HasRoof { get; set; }

        public override string ToString() =>
            @$"Name: {Name}
Walls: {Walls}
Garage: {Garage}
Garden: {Garden}
Pool: {Pool}
Window: {Window}
Door: {Door}
Has Roof: {HasRoof}";
    }

    public interface IBuilder
    {
        public Home Home { get; set; }
        IBuilder Reset();
        IBuilder BuildWalls();
        IBuilder BuildGarage();
        IBuilder BuildGarden();
        IBuilder BuildPool();
        IBuilder BuildWindow();
        IBuilder BuildDoor();
        IBuilder BuildRoof();

        Home GetHome();
    }

    public class WoodBuilder : IBuilder
    {


        public Home Home { get; set; } = new Home { Name = "Wood" };

        public IBuilder Reset()
        {
            Home = new Home();
            return this;
        }

        public IBuilder BuildWalls()
        {
            Home.Walls = 8;
            return this;
        }

        public IBuilder BuildGarage()
        {
            Home.Garage = 1;
            return this;
        }

        public IBuilder BuildGarden()
        {
            Home.Garden = 4;
            return this;
        }

        public IBuilder BuildPool()
        {
            Home.Pool = 2;
            return this;
        }

        public IBuilder BuildWindow()
        {
            Home.Window = 3;
            return this;
        }

        public IBuilder BuildDoor()
        {
            Home.Door = 2;
            return this;
        }

        public IBuilder BuildRoof()
        {
            Home.HasRoof = true;
            return this;
        }

        public Home GetHome()
        {
            return Home;
        }
    }

    public class StoneBuilder : IBuilder
    {


        public Home Home { get; set; } = new Home { Name = "Wood" };

        public IBuilder Reset()
        {
            Home = new Home();
            return this;
        }

        public IBuilder BuildWalls()
        {
            Home.Walls = 88;
            return this;
        }

        public IBuilder BuildGarage()
        {
            Home.Garage = 11;
            return this;
        }

        public IBuilder BuildGarden()
        {
            Home.Garden = 44;
            return this;
        }

        public IBuilder BuildPool()
        {
            Home.Pool = 22;
            return this;
        }

        public IBuilder BuildWindow()
        {
            Home.Window = 33;
            return this;
        }

        public IBuilder BuildDoor()
        {
            Home.Door = 22;
            return this;
        }

        public IBuilder BuildRoof()
        {
            Home.HasRoof = true;
            return this;
        }

        public Home GetHome()
        {
            return Home;
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

        public Home Make(string type)
        {
            Builder.Reset();
            switch (type)
            {
                case "A":
                    Builder.Home.Name = "A";
                    return Builder.BuildWalls().BuildGarage().BuildGarden().BuildPool().BuildWindow().BuildDoor().BuildRoof().GetHome();
                case "B":
                    Builder.Home.Name = "B";
                    return Builder.BuildWalls().BuildGarage().BuildWindow().BuildDoor().BuildRoof().GetHome();
                case "C":
                    Builder.Home.Name = "C";
                    return Builder.BuildWalls().BuildWindow().BuildDoor().BuildRoof().GetHome();
                default:
                    throw new Exception("Wrong Type");
            }
        }
    }
}
                         