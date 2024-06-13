using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class figure
{
    public virtual double surface_area()
    {
        return 0;
    }
}

public class parallelepiped : figure
{
    private double x = 0;
    private double y = 0;

    public parallelepiped (double xx, double yy)
    {
        x = xx;
        y = yy;
    }

    public override double surface_area()
    {
        return 6 * x * y;
    }
}

public class tetrahedron : figure
{
    private double edge = 0;

    public tetrahedron (double a)
    {
        edge = a;
    }
    public override double surface_area()
    {
        return edge * edge * Math.Sqrt(3);
    }
}

public class ball : figure
{
    private double radius = 0;

    public ball(double r)
    {
        radius = r;
    }
    public override double surface_area()
    {
        return 4 * Math.PI * radius * radius;
    }
}

namespace V8
{
    class Program
    {
        static void Main(string[] args)
        {
            var figures = new figure[]{
            new parallelepiped(10,10),
            new tetrahedron(10),
            new ball(10) };

            foreach (var f in figures)
            {
                Console.WriteLine("Surface area: " + f.surface_area());
            }
            Console.ReadLine();
        }
    }
}

