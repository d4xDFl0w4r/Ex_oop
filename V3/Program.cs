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
        if (a * a < x * x)
        {
            throw new ArgumentException("x (" + x + ") must be in [" + -a + ";" + a + "]");
        }
        return b / a * Math.Sqrt(a * a - x * x);
    }
}

class Hyperbola(double a, double b) : Curve
{
    public override double CalculateY(double x)
    {
        if (x * x < a * a)
        {
            throw new ArgumentException("x (" + x + ") must be in (-inf; " + -a + "] U [" + a + ";inf)");
        }
        return b / a * Math.Sqrt(x * x - a * a);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var curves = new Curve[]
        {
            new Line(2, 3),
            new Ellipse(6, 8),
            new Hyperbola(2, 3)
        };

        foreach (var curve in curves)
        {
            Console.WriteLine("y: " + curve.CalculateY(4));
        }
    }
}