using System;

abstract class Curve
{
    public abstract double CalculateY(double x);
}

class Line(double a, double b) : Curve
{
    public override double CalculateY(double x)
    {
        return a * x + b;
    }
}

class Ellipse(double a, double b) : Curve
{
    public override double CalculateY(double x)
    {
        return Math.Sqrt(1 - (x * x) / (a * a)) * b;
    }
}

class Hyperbola(double a, double b) : Curve
{
    public override double CalculateY(double x)
    {
        return Math.Sqrt(x * x / (a * a) - 1) * b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var curves = new Curve[]
        {
            new Line(2, 3),
            new Ellipse(2, 3),
            new Hyperbola(2, 3)
        };

        foreach (var curve in curves)
        {
            Console.WriteLine("y: " + curve.CalculateY(2));
        }
    }
}