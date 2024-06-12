using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract public class progression
{
    public virtual double sum_of_progression(int amount)
    {
        return 0;
    }
}

public class arithmetic_progression : progression
{
    private double first_term_of_progression = 0;
    private double constant_difference = 0;

    public arithmetic_progression(double f, double c)
    {
        first_term_of_progression = f;
        constant_difference = c;
    }
    public override double sum_of_progression(int amount)
    {
        double an = first_term_of_progression + ((amount-1) * constant_difference);
        double sum = (amount * (first_term_of_progression + an)) / 2;
        return sum;
    }
}

public class geometric_progression : progression
{
    private double first_term_of_progression = 0;
    private double constant_attitude = 0;

    public geometric_progression(double f, double c)
    {
        first_term_of_progression = f;
        constant_attitude = c;
    }
    public override double sum_of_progression(int amount)
    {
        double aj = first_term_of_progression * Math.Pow(constant_attitude, amount-1);
        double sum = (first_term_of_progression - (aj* constant_attitude)) / (1 - constant_attitude);
        return sum;
    }
}

namespace V4
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new arithmetic_progression(1, 2);
            var g = new geometric_progression(1, 2);
            Console.WriteLine(a.sum_of_progression(10));
            Console.WriteLine(g.sum_of_progression(10));
            Console.ReadLine();
        }
    }
}
