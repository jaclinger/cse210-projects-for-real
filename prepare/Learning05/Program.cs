using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
     
        List<Shape> shapes = new List<Shape>();

        
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 3, 5));
        shapes.Add(new Circle("Green", 2));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} - Area: {shape.GetArea():0.00}");
        }
    }
}
