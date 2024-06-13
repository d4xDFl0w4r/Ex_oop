using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class equation
{
    public virtual void roots_of_the_equation()
    {
        return;
    }
}

public class linear_equations : equation
{
    private double x = 0;
    private double y = 0;
    private double z = 0;
    private double coefficient_in_front_of_x = 0;
    private double coefficient_in_front_of_y = 0;
    private double coefficient_in_front_of_z = 0;
    private double addition_to_x = 0;
    private double addition_to_y = 0;
    private double addition_to_z = 0;
    private double answer = 0;

    public linear_equations(double cx, double cy, double cz, double ax, double ay, double az, double a)
    {
        coefficient_in_front_of_x = cx;
        coefficient_in_front_of_y = cy;
        coefficient_in_front_of_z = cz;
        addition_to_x = ax;
        addition_to_y = ay;
        addition_to_z = az;
        answer = a;
    }
    public override void roots_of_the_equation()
    {
        for (int i = -999999999; i <= 999999999; i++)
        {
            for (int j = -999999999; j <= 999999999; j++)
            {
                for (int k = -999999999;k <= 999999999; k++)
                {
                    if (coefficient_in_front_of_x * (i + addition_to_x) * coefficient_in_front_of_y * (j + addition_to_y) * coefficient_in_front_of_z * (k + addition_to_z) == answer)
                    {
                        Console.WriteLine("x =" + i + "y =" + j + "z =" + k);
                    }
                }
            }
        } 
        return;
    }
}

public class quadratic_equations : equation
{
    private double x = 0;
    private double coefficient_in_front_of_x2 = 0;
    private double coefficient_in_front_of_x = 0;
    private double c = 0;
    private double answer = 0;

    public quadratic_equations(double cx2, double cx, double cc, double a)
    {
        coefficient_in_front_of_x2 = cx2;
        coefficient_in_front_of_x = cx;
        c = cc;
        answer = a;
    }
    public override void roots_of_the_equation()
    {
        for (int i = -999999999; i <= 999999999; i++)
        {
            if((coefficient_in_front_of_x2 * (i*i)) + (coefficient_in_front_of_x * i) + c == answer)
            {
                Console.WriteLine("x = " + i);
            }
        }
            return;
    }
}

namespace V14
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new linear_equations(1,2,3,1,2,3,0);
            var q = new quadratic_equations(1,2,3,0);

            Console.WriteLine("Roots of linear equations: ");
           // l.roots_of_the_equation();
            Console.WriteLine("Roots of quadratic equations: ");
            q.roots_of_the_equation();
            Console.ReadLine();
        }
    }
}
