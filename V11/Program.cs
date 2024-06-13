using System;
abstract class Mammal
{
    public abstract void Description();
}
class Animal : Mammal
{
    public override void Description()
    {
        Console.WriteLine("Это животное.");
    }
}
class Dog : Animal
{
    public override void Description()
    {
        Console.WriteLine("Это собака.");
    }
}
class Cow : Animal
{
    public override void Description()
    {
        Console.WriteLine("Это корова.");
    }
}
class Human : Mammal
{
    public override void Description()
    {
        Console.WriteLine("Это человек.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Mammal[] mammals = new Mammal[4];
        mammals[0] = new Animal();
        mammals[1] = new Dog();
        mammals[2] = new Cow();
        mammals[3] = new Human();

        foreach (var mammal in mammals)
        {
            mammal.Description();
        }
    }
}