using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface ISystemItem
    {
        string Name { get; set; }
        string Path { get; set; }
        float Size { get; }
    }

    class File:ISystemItem
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public float Size { get; }

        public File(string name, string path, float size)
        {
            Name = name;
            Path = path;
            Size = size;
        }
    }

    class Folder:ISystemItem
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public float Size { get; }
    }
}
