using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ancestor
{
    protected string name = "";

    public Ancestor (string n)
    {
        name = n;
    }

    public virtual void print()
    {
        Console.WriteLine("Ancestor");
        return;
    }
}

public class Child : Ancestor
{
    public Child(string n) : base(n)
    {
        name = n;
    }
    public override void print()
    {
        Console.WriteLine("Child");
        Console.WriteLine("Name: " + name);
        return;
    }
}

public class Grandson : Child
{
    protected string patronymic = "";

    public Grandson(string n, string p) : base(n)
    {
        name = n;
        patronymic = p;
    }
    public override void print()
    {
        Console.WriteLine("Grandson");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Patronymic: " + patronymic);
        return;
    }
}

namespace V12
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Ancestor[]
            {
                new Ancestor("Иван"),
                new Child ("Михаил"),
                new Grandson ("Иван", "Михаилович")
            };

            foreach (var person in people)
            {
                person.print();
            }

            Console.ReadLine();
        }
    }
}
