using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class figure
{
    public virtual double volume()
    {
        return 0;
    }
}

public class parallelepiped : figure
{
    private double first_side = 0;
    private double second_side = 0;
    private double third_side = 0;

    public parallelepiped(double x, double y, double z)
    {
        first_side = x;
        second_side = y;
        third_side = z;
    }
    public override double volume()
    {
        return first_side * second_side * third_side;
    }
}

public class pyramid : figure
{
    private double first_side = 0;
    private double second_side = 0;
    private double height = 0;

    public pyramid(double x, double y, double h)
    {
        first_side = x;
        second_side = y;
        height = h;
    }
    public override double volume()
    {
        return first_side * second_side * height * 0.333333;
    }
}

public class tetrahedron : figure
{
    private double edge = 0;

    public tetrahedron(double a)
    {
        edge = a;
    }
    public override double volume()
    {
        return ((edge * edge * edge) *Math.Sqrt(2))/12;
    }
}

public class ball : figure
{
    private double radius = 0;

    public ball(double r)
    {
        radius = r;
    }
    public override double volume()
    {
        return 1.33333333333 * Math.PI * (radius * radius * radius);
  ;
    }
}

namespace V10
{
    class Program
    {
        static void Main(string[] args)
        {
            var figures = new figure[]
            {
                new parallelepiped(10, 10, 10),
                new pyramid(10, 10, 10),
                new tetrahedron(10),
                new ball(10)
            };

            foreach(var figure in figures)
            {
                Console.WriteLine("Объём: " + figure.volume());
            }

            Console.ReadLine();
        }
    }
}
