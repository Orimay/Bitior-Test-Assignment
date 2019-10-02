using System;

namespace OOPDesignFundamentals
{
    partial class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please provide \"shape:arguments\"");

                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine();

                if (!ShapeFactory.TryCreateShapeFromInput(input, out var shape, out var message))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                {
                    message = $"Area: {shape.GetArea().ToString("0.##")}, Perimeter: {shape.GetPerimeter().ToString("0.##")}";
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(message);
                Console.WriteLine();
            }
        }
    }
}
