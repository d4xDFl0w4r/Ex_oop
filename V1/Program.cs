using System;

abstract class Figure
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

class Rectangle(double a, double b) : Figure
{
    public override double CalculateArea()
    {
        return a * b;
    }
}

class Circle(double r) : Figure
{
    public override double CalculateArea()
    {
        return Math.PI * r * r;
    }
}

class RightTriangle(double a, double b) : Figure
{
    public override double CalculateArea()
    {
        return 0.5 * a * b;
    }
}

class Trapezoid(double a, double b, double h) : Figure
{
    public override double CalculateArea()
    {
        return 0.5 * (a + b) * h;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var figures = new Figure[]
        {
            new Rectangle(2, 3),
            new Circle(4),
            new RightTriangle(3, 4),
            new Trapezoid(4, 3, 6)
        };

        foreach (var figure in figures)
        {
            Console.WriteLine("Area: "figure.CalculateArea());
        }
    }
}
