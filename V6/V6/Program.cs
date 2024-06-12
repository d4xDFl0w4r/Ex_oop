using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class figure
{
    public virtual double area()
    {
        return 0;
    }

    public virtual double perimeter()
    {
        return 0;
    }

    public virtual void print()
    {
        return;
    }
}

public class circle : figure
{
    private double radius = 0;

    public circle (double r)
    {
        radius = r;
    }
    public override double area()
    {
        return Math.PI * radius * radius;
    }

    public override double perimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override void print()
    {
        Console.WriteLine("radius = " + radius);
        Console.WriteLine("area = " + area());
        Console.WriteLine("perimeter = " + perimeter());
        return;
    }
}

public class rectangle : figure
{
    private double length = 0;
    private double width = 0;

    public rectangle (double l, double w)
    {
        length = l;
        width = w;
    }
    public override double area()
    {
        return length * width;
    }

    public override double perimeter()
    {
        return 2 * (length + width);
    }

    public override void print()
    {
        Console.WriteLine("length = " + length);
        Console.WriteLine("width = " + width);
        Console.WriteLine("area = " + area());
        Console.WriteLine("perimeter = " + perimeter());
        return;
    }
}

public class trapezoid : figure
{
    private double height = 0;
    private double first_base = 0;
    private double second_base = 0;
    private double first_side = 0;
    private double second_side = 0;

    public trapezoid(double h, double fb, double sb, double fs, double ss)
    {
        height = h;
        first_base = fb;
        second_base = sb;
        first_side = fs;
        second_side = ss;
}
    public override double area()
    {
        return ((first_base + second_base) / 2) * height;
    }

    public override double perimeter()
    {
        return first_base + second_base + first_side + second_side;
    }

    public override void print()
    {
        Console.WriteLine("height = " + height);
        Console.WriteLine("first_base = " + first_base);
        Console.WriteLine("second_base = " + second_base);
        Console.WriteLine("first_side = " + first_side);
        Console.WriteLine("second_side = " + second_side);
        Console.WriteLine("area = " + area());
        Console.WriteLine("perimeter = " + perimeter());
        return;
    }
}
namespace V6
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new circle(10);
            var r = new rectangle(10,10);
            var t = new trapezoid(5.83, 10, 20, 7, 8);
            c.print();
            Console.WriteLine();
            r.print();
            Console.WriteLine();
            t.print();
            Console.ReadLine();
        }
    }
}
