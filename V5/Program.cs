using System;
using System.Collections.Generic;

public abstract class MyList<T>
{
    protected readonly List<T> Items = [];

    public virtual void Insert(T item)
    {
        Items.Add(item);
    }

    public abstract T Remove();

    public bool IsEmpty()
    {
        return Items.Count == 0;
    }

    public int Size()
    {
        return Items.Count;
    }
}

internal class MyStack<T> : MyList<T>
{
    public override void Insert(T item)
    {
        base.Insert(item);
    }

    public override T Remove()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var item = Items[Items.Count - 1];
        Items.RemoveAt(Items.Count - 1);
        return item;
    }
}

internal class MyQueue<T> : MyList<T>
{
    public override void Insert(T item)
    {
        base.Insert(item);
    }

    public override T Remove()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        var item = Items[0];
        Items.RemoveAt(0);
        return item;
    }
}

public class Program
{
    public static void Main()
    {
        var stack = new MyStack<int>();
        stack.Insert(1);
        stack.Insert(2);
        stack.Insert(3);
        Console.WriteLine("Stack: ");
        while (!stack.IsEmpty())
        {
            Console.WriteLine(stack.Remove());
        }

        var queue = new MyQueue<int>();
        queue.Insert(1);
        queue.Insert(2);
        queue.Insert(3);
        Console.WriteLine("\nQueue: ");
        while (!queue.IsEmpty())
        {
            Console.WriteLine(queue.Remove());
        }
    }
}
