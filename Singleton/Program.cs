using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            President president = President.Instance;
            President ok = President.Instance;
            Console.WriteLine(president.Name);
            Console.WriteLine(ok.Name);
        }
    }

    class President
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Height { get; set; }

        private President() { }

        private static President _instance;

        public static President Instance => _instance ??= new President { Name = "XXX", Surname = "XXX", Height = 195 };
    }
}
