using System;

class LivingBeing
{
    protected LivingBeing(string location)
    {
        Location = location;
    }
    public virtual void Eat(LivingBeing food)
    {
        Console.WriteLine("Это живое существо питается.");
    }
    public virtual void Die()
    {
        Console.WriteLine("Это живое существо умерло.");
    }
    public string Location { get; }
}

internal class Fox : LivingBeing
{
    public Fox(string location, int age) : base(location)
    {
        Age = age;
        FoxCount++;
    }
    public override void Eat(LivingBeing food)
    {
        if (food is Rabbit rabbit && Rabbit.RabbitCount < FoxCount)
        {
            Console.WriteLine("Лиса съела кролика.");
            rabbit.Die();
        }
        else
        {
            Console.WriteLine("Лиса не может съесть эту пищу.");
        }
    }
    public override void Die()
    {
        Console.WriteLine("Лиса умерла.");
        FoxCount--;
    }
    public int Age { get; }

    public static int FoxCount { get; set; }
}

internal class Rabbit : LivingBeing
{
    public Rabbit(string location) : base(location)
    {
        RabbitCount++;
    }
    public override void Eat(LivingBeing food)
    {
        if (food is Grass grass && Grass.GrassCount > RabbitCount)
        {
            Console.WriteLine("Кролик съел траву.");
            grass.Eaten();
        }
        else
        {
            Console.WriteLine("Кролик не может съесть эту пищу.");
        }
    }
    public override void Die()
    {
        Console.WriteLine("Кролик умер.");
        RabbitCount--;
    }
    public static int RabbitCount { get; private set; } = 0;
}

internal class Grass : LivingBeing
{
    public Grass(string location) : base(location)
    {
        GrassCount++;
    }
    
    public override void Eat(LivingBeing food)
    {
        Console.WriteLine("Трава не ест другие существа.");
    }
    public void Eaten()
    {
        Console.WriteLine("Трава была съедена.");
    }
    
    public static int GrassCount { get; set; }
}

internal class NoLife() : LivingBeing("Нет жизни")
{
    public override void Eat(LivingBeing food)
    {
        Console.WriteLine("Нет жизни, нечего есть.");
    }
    public override void Die()
    {
        Console.WriteLine("Нет жизни, нельзя умереть.");
    }
}

internal class Environment(List<LivingBeing> surroundings)
{
    public void Add(LivingBeing being)
    {
        if (being is Fox fox)
        {
            if (Fox.FoxCount <= 5)
            {
                surroundings.Add(fox);
            }
            else
            {
                Fox.FoxCount--;
                Console.WriteLine("Невозможно добавить больше 5 лис");
            }
        }
        else
        {
            surroundings.Add(being);
        }
    }

    public void Simulate()
    {
        foreach (var livingBeing in surroundings)
        {
            switch (livingBeing)
            {
                case Fox fox:
                    Console.WriteLine("Лиса возрастом " + fox.Age + " находится в " + fox.Location);
                    fox.Eat(surroundings[1]);
                    break;
                case Rabbit rabbit:
                    Console.WriteLine("Кролик находится в " + rabbit.Location);
                    rabbit.Eat(surroundings[6]);
                    break;
            }
        }
        Console.WriteLine();
        
        Console.WriteLine("Количество лис: " + Fox.FoxCount);
        Console.WriteLine("Количество кроликов: " + Rabbit.RabbitCount);
        Console.WriteLine();
        
        Console.WriteLine("Ситуация, когда больше лис, чем кроликов:");
        Add(new Fox("Поле", 3));
        Add(new Fox("Поле", 2));
        Add(new Fox("Поле", 1));
        Add(new Fox("Поле", 5));
        Add(new Fox("Поле", 4));
        Console.WriteLine("Количество лис: " + Fox.FoxCount);
        Console.WriteLine("Количество кроликов: " + Rabbit.RabbitCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var surroundings = new List<LivingBeing>
        {
            new Fox("Дом", 4),
            new Rabbit("Поле"),
            new Rabbit("Поле"),
            new Rabbit("Поле"),
            new Rabbit("Поле"),
            new Rabbit("Поле"),
            new Grass("Поле")
        };

        var environment = new Environment(surroundings);
        environment.Simulate();
    }
}
