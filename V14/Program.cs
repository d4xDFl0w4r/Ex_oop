using System;

public abstract class equation
{
    public virtual void Equation()
    {
        return;
    }
    public virtual void Roots_of_the_equation()
    {
        return;
    }
}

public class linear_equations : equation
{
    public linear_equations(double a, double b)
    {
        A = a;
        B = b;
    }
    public override void Equation()
    {
        Console.WriteLine($"Линейное уравнение: {A}x + {B} = 0");
    }
    public override void Roots_of_the_equation()
    {
        Console.WriteLine($"Корень: {-B/A}");
    }
    
    private double A { get; set; }
    private double B { get; set; }
}

public class quadratic_equations : equation
{
    public quadratic_equations(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override void Equation()
    {
        Console.WriteLine($"Квадратное уравнение: {A}x^2 + {B}x + {C} = 0");
    }
    public override void Roots_of_the_equation()
    {
        try
        {
            var discriminant = Discriminant();
        }
        catch (ArithmeticException err)
        {
            Console.Beep();
            Console.WriteLine(err.Message);
            return;
        }
        if (Discriminant() == 0)
        {
            Root1 = -B / (2 * A);
            Console.WriteLine($"Совпадающий корень: {Root1}");
        }
        else
        {
            Root1 = (-B - Math.Sqrt(Discriminant())) / (2 * A);
            Root2 = (-B + Math.Sqrt(Discriminant())) / (2 * A);
            Console.WriteLine($"Корень 1: {Root1}");
            Console.WriteLine($"Корень 2: {Root2}");
        }
    }

    private double Discriminant()
    {
        double discriminant = B * B - 4 * A * C;
        if (discriminant < 0)
        {
            throw new ArithmeticException("Отрицательный дискриминант, корней нет");
        }
        else
        {
            return discriminant;
        }
    }
    
    private double A { get; set; }
    private double B { get; set; }
    private double C { get; set; }
    private double Root1 { get; set; }
    private double Root2 { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var l = new linear_equations(2, -30);
        l.Equation();
        l.Roots_of_the_equation();
        
        var q = new quadratic_equations(5, -6, 1);
        q.Equation();
        q.Roots_of_the_equation();
    }
}
