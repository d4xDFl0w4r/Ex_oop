using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class person
{
    public string gender = "";
    public person()
    {
        gender = "";
    }
    public virtual void reaction(person p)
    {
        if (p.gender == "female")
        {
            Console.WriteLine("Здравствуйте, девушка!");
        }
        if (p.gender == "male")
        {
            Console.WriteLine("Здравствуйте, молодой человек!");
        }
        if (p.gender == "")
        {
            Console.WriteLine("Здравствуйте!");
        }
        return;
    }
}

public class girls : person
{
    public girls()
    {
       gender = "female";
    }
    public override void reaction(person p)
    {
        if (p.gender == "female")
        {
            Console.WriteLine("Здравствуйте!");
        }
        if (p.gender == "male")
        {
            Console.WriteLine("Здравствуйте, молодой человек!");
        }
        if (p.gender == "")
        {
            Console.WriteLine("Здравствуйте!");
        }
        return;
    }
}

public class boys : person
{
    public boys()
    {
        gender = "male";
    }
    public override void reaction(person p)
    {
        if (p.gender == "female")
        {
            Console.WriteLine("Здравствуйте, девушка!");
        }
        if (p.gender == "male")
        {
            Console.WriteLine("Здравствуйте!");
        }
        if (p.gender == "")
        {
            Console.WriteLine("Здравствуйте!");
        }
        return;
    }
}

namespace V9
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new person();
            var girl = new girls();
            var boy = new boys();

            Console.WriteLine("Person`s reactions:");
            person1.reaction(person1);
            person1.reaction(girl);
            person1.reaction(boy);
            Console.WriteLine("Girl`s reactions:");
            girl.reaction(person1);
            girl.reaction(girl);
            girl.reaction(boy);
            Console.WriteLine("Boy`s reactions:");
            boy.reaction(person1);
            boy.reaction(girl);
            boy.reaction(boy);
            Console.ReadLine();
        }
    }
}
