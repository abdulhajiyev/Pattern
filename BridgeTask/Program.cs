using System;

namespace BridgeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Color red = new ColorRed();
            Color green = new ColorGreen();
            Color blue = new ColorBlue();

            Square square = new Square(red);
            Circle circle = new Circle(green);
            Rectangle rectangle = new Rectangle(blue);

            Console.WriteLine(square);
            Console.WriteLine(circle);
            Console.WriteLine(rectangle);

        }
    }



    public abstract class Color
    {
        public abstract int Red { get; }

        public abstract int Green { get; }

        public abstract int Blue { get; }
    }

    public class ColorRed : Color
    {
        public override int Red => 255;

        public override int Green => 0;

        public override int Blue => 0;
    }

    public class ColorGreen : Color
    {
        public override int Red => 0;

        public override int Green => 255;

        public override int Blue => 0;
    }

    public class ColorBlue : Color
    {
        public override int Red => 0;

        public override int Green => 0;

        public override int Blue => 255;
    }

    public abstract class Shape
    {
        private readonly Color _color;

        protected Shape(Color color)
        {
            _color = color;
        }

        protected string GetColorString() => $"R={_color.Red} G={_color.Green} B={_color.Blue}";
    }

    public class Square : Shape
    {
        public Square(Color color) : base(color) { }

        public override string ToString() => $"The color for the square is {GetColorString()}";
    }

    public class Circle : Shape
    {
        public Circle(Color color) : base(color) { }

        public override string ToString() => $"The color for the circle is {GetColorString()}";
    }

    public class Rectangle : Shape
    {
        public Rectangle(Color color) : base(color) { }

        public override string ToString() => $"The color for the rectangle is {GetColorString()}";
    }
}
