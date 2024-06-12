Вариант 1.
Создать абстрактный базовый класс с виртуальной функцией - площадь. Создать производные классы: прямоугольник, круг, прямоугольный треугольник, трапеция со своими функциями площади. Для проверки определить массив ссылок на абстрактный класс, которым присваиваются адреса различных объектов. Площадь трапеции:S=(a+b)h/2
Код:
using System;
abstract class Shape
{
    public abstract double CalculateArea();
}
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}
class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
class RightTriangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return (Base * Height) / 2;
    }
}
class Trapezoid : Shape
{
    public double Top { get; set; }
    public double Bottom { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return (Top + Bottom) * Height / 2;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[4];

        shapes[0] = new Rectangle { Width = 5, Height = 3 };
        shapes[1] = new Circle { Radius = 2 };
        shapes[2] = new RightTriangle { Base = 4, Height = 2 };
        shapes[3] = new Trapezoid { Top = 3, Bottom = 5, Height = 2 };

        foreach (var shape in shapes)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }
    }
}
Вариант 2.
Создать абстрактный класс с виртуальной функцией: норма. Создать производные классы: комплексные числа, вектор из 10 элементов, матрица (2х2). Определить функцию нормы - для комплексных чисел - модуль в квадрате, для вектора - корень квадратный из суммы элементов по модулю, для матрицы - максимальное значение по модулю.
Код:
using System;
abstract class Norm
{
    public abstract double CalculateNorm();
}
class ComplexNumber : Norm
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public override double CalculateNorm()
    {
        return Real * Real + Imaginary * Imaginary;
    }
}
class Vector : Norm
{
    public double[] Elements { get; set; }

    public override double CalculateNorm()
    {
        double sum = 0;
        foreach (var element in Elements)
        {
            sum += element * element;
        }
        return Math.Sqrt(sum);
    }
}
class Matrix : Norm
{
    public double[,] Elements { get; set; }

    public override double CalculateNorm()
    {
        double maxNorm = 0;
        int rows = Elements.GetLength(0);
        int columns = Elements.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                double norm = Math.Abs(Elements[i, j]);
                if (norm > maxNorm)
                {
                    maxNorm = norm;
                }
            }
        }

        return maxNorm;
    }
}
class Program
{
    static void Main(string[] args)
    {
        ComplexNumber complexNumber = new ComplexNumber { Real = 3, Imaginary = 4 };
        Vector vector = new Vector { Elements = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } };
        Matrix matrix = new Matrix { Elements = new double[,] { { 1, 2 }, { -3, 4 } } };

        Console.WriteLine("Complex Number Norm: " + complexNumber.CalculateNorm());
        Console.WriteLine("Vector Norm: " + vector.CalculateNorm());
        Console.WriteLine("Matrix Norm: " + matrix.CalculateNorm());
    }
}



































Вариант 3.
Создать абстрактный класс (кривые) вычисления координаты y для некоторой x. Создать производные классы: прямая, эллипс, гипербола со своими функциями вычисления y в зависимости от входного параметра x.
Уравнение прямой: y=ax+b , эллипса: x2/a2+y2/b2=1, гиперболы: x2/a2-y2/b2=1
Код:
using System;
abstract class Curve
{
    public abstract double CalculateY(double x);
}
class Line : Curve
{
    public double A { get; set; }
    public double B { get; set; }

    public override double CalculateY(double x)
    {
        return A * x + B;
    }
}
class Ellipse : Curve
{
    public double A { get; set; }
    public double B { get; set; }

    public override double CalculateY(double x)
    {
        return Math.Sqrt(1 - (x * x) / (A * A)) * B;
    }
}
class Hyperbola : Curve
{
    public double A { get; set; }
    public double B { get; set; }

    public override double CalculateY(double x)
    {
        return Math.Sqrt((x * x) / (A * A) - 1) * B;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Curve[] curves = new Curve[3];

        curves[0] = new Line { A = 2, B = 3 };
        curves[1] = new Ellipse { A = 2, B = 3 };
        curves[2] = new Hyperbola { A = 2, B = 3 };

        foreach (var curve in curves)
        {
            Console.WriteLine("y: " + curve.CalculateY(2));
        }
    }
}
Вариант 4.
Создать абстрактный базовый класс с виртуальной функцией - сумма прогрессии. Создать производные классы: арифметическая прогрессия и геометрическая прогрессия. Каждый класс имеет два поля типа double. Первое - первый член прогрессии, второе (double) - постоянная разность (для арифметической) и постоянное отношение (для геометрической). Определить функцию вычисления суммы, где параметром является количество элементов прогрессии.
Арифметическая прогрессия aj=a0+jd, j=0,1,2,…
Сумма арифметической прогрессии: sn=(n+1)(a0+an)/2
Геометрическая прогрессия: aj=a0rj, j=0,1,2,…
Сумма геометрической прогрессии: sn=(a0-anr)/(1-r)
Код:
using System;
abstract class Progression
{
    public abstract double CalculateSum(int n);
}
class ArithmeticProgression : Progression
{
    public double FirstTerm { get; set; }
    public double CommonDifference { get; set; }

    public override double CalculateSum(int n)
    {
        return (n + 1) * (FirstTerm + (FirstTerm + CommonDifference * n)) / 2;
    }
}

class GeometricProgression : Progression
{
    public double FirstTerm { get; set; }
    public double CommonRatio { get; set; }

    public override double CalculateSum(int n)
    {
        return (FirstTerm - (FirstTerm * Math.Pow(CommonRatio, n))) / (1 - CommonRatio);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Progression[] progressions = new Progression[2];

        progressions[0] = new ArithmeticProgression { FirstTerm = 1, CommonDifference = 2 };
        progressions[1] = new GeometricProgression { FirstTerm = 2, CommonRatio = 3 };

        foreach (var progression in progressions)
        {
            Console.WriteLine("Sum: " + progression.CalculateSum(5));
        }
    }
}
Вариант 9.
Создать класс человек, производные от которого девушки и молодые люди. Определить виртуальную функцию реакции человека на вновь увиденного другого человека.
using System;
class Person
{
    public virtual void ReactToNewPerson()
    {
        Console.WriteLine("Обычная реакция человека на вновь увиденного другого человека.");
    }
}
class Girl : Person
{
    public override void ReactToNewPerson()
    {
        Console.WriteLine("Реакция девушки на вновь увиденного другого человека.");
    }
}
class YoungPerson : Person
{
    public override void ReactToNewPerson()
    {
        Console.WriteLine("Реакция молодого человека на вновь увиденного другого человека.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person();
        Person girl1 = new Girl();
        Person youngPerson1 = new YoungPerson();

        person1.ReactToNewPerson();
        girl1.ReactToNewPerson(); 
        youngPerson1.ReactToNewPerson();
    }
}





























Вариант 7.
Создать базовый класс - работник и производные классы - служащий с почасовой оплатой, служащий в штате и служащий с процентной ставкой. Определить функцию начисления зарплаты.
using System;
class Employee
{
    private string name;
    protected double baseSalary;
    public Employee(string name, double baseSalary)
    {
        this.name = name;
        this.baseSalary = baseSalary;
    }

    public string GetName()
    {
        return name;
    }

    public virtual double CalculateSalary()
    {
        return baseSalary;
    }
}
class HourlyPaidEmployee : Employee
{
    private double hoursWorked;
    private double hourlyRate;
    public HourlyPaidEmployee(string name, double baseSalary, double hoursWorked, double hourlyRate): base(name, baseSalary)
    {
        this.hoursWorked = hoursWorked;
        this.hourlyRate = hourlyRate;
    }
    public override double CalculateSalary()
    {
        return baseSalary + (hoursWorked * hourlyRate);
    }
}
class SalariedEmployee : Employee
{
    private int daysWorked;
    public SalariedEmployee(string name, double baseSalary, int daysWorked
: base(name, baseSalary)
    {
        this.daysWorked = daysWorked;
    }
    public override double CalculateSalary()
    {
        return baseSalary * (daysWorked / 30.0);
    }
}
class CommissionedEmployee : Employee
{
    private double sales;
    private double commissionRate;
    public CommissionedEmployee(string name, double baseSalary, double sales, double commissionRate): base(name, baseSalary)
    {
        this.sales = sales;
        this.commissionRate = commissionRate;
    }
    public override double CalculateSalary()
    {
        return baseSalary + (sales * commissionRate / 100);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee1 = new HourlyPaidEmployee("John Doe", 10, 40, 15);
        Employee employee2 = new SalariedEmployee("Jane Smith", 2000, 25);
        Employee employee3 = new CommissionedEmployee("Bob Johnson", 1000, 50000, 2.5);
        Console.WriteLine("Salary for " + employee1.GetName() + ": " + employee1.CalculateSalary());
        Console.WriteLine("Salary for " + employee2.GetName() + ": " + employee2.CalculateSalary());
        Console.WriteLine("Salary for " + employee3.GetName() + ": " + employee3.CalculateSalary());
        Console.ReadLine();
    }
}
Вариант 5.
Создать базовый класс список. Реализовать на базе списка стек и очередь с виртуальными функциями вставки и вытаскивания.
using System;
using System.Collections.Generic;
abstract class List
{
    protected List<int> elements;

    public List()
    {
        elements = new List<int>();
    }

    public abstract void Insert(int value);
    public abstract int Remove();

    public List<int> Elements
    {
        get { return elements; }
    }
}
class Stack : List
{
    public override void Insert(int value)
    {
        Elements.Add(value);
    }

    public override int Remove()
    {
        if (Elements.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        int lastIndex = Elements.Count - 1;
        int value = Elements[lastIndex];
        Elements.RemoveAt(lastIndex);

        return value;
    }
}
class Queue : List
{
    public override void Insert(int value)
    {
        Elements.Add(value);
    }

    public override int Remove()
    {
        if (Elements.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        int value = Elements[0];
        Elements.RemoveAt(0);

        return value;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Stack stack = new Stack();
        Queue queue = new Queue();
        // Вставка элементов в стек
        stack.Insert(10);
        stack.Insert(20);
        stack.Insert(30);
        // Вставка элементов в очередь
        queue.Insert(100);
        queue.Insert(200);
        queue.Insert(300);
        // Извлечение элементов из стека и вывод на экран
        Console.WriteLine("Stack:");
        while (stack.Elements.Count > 0)
        {
            int value = stack.Remove();
            Console.WriteLine(value);
        }
        // Извлечение элементов из очереди и вывод на экран
        Console.WriteLine("Queue:");
        while (queue.Elements.Count > 0)
        {
            int value = queue.Remove();
            Console.WriteLine(value);
        }
    }
}


Вариант 6.
Создать базовый класс - фигура, и производные класс - круг, прямоугольник, трапеция. Определить виртуальные функции площадь, периметр и вывод на печать.
using System;
abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
    public abstract void Print();
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
    public override void Print()
    {
        Console.WriteLine("Circle:");
        Console.WriteLine("Area: " + CalculateArea());
        Console.WriteLine("Perimeter: " + CalculatePerimeter());
        Console.WriteLine();
    }
}
class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }
    public override double CalculateArea()
    {
        return length * width;
    }
    public override double CalculatePerimeter()
    {
        return 2 * (length + width);
    }
    public override void Print()
    {
        Console.WriteLine("Rectangle:");
        Console.WriteLine("Area: " + CalculateArea());
        Console.WriteLine("Perimeter: " + CalculatePerimeter());
        Console.WriteLine();
    }
}
class Trapezoid : Shape
{
    private double base1;
    private double base2;
    private double height;
    private double side1;
    private double side2;

    public Trapezoid(double base1, double base2, double height, double side1, double side2)
    {
        this.base1 = base1;
        this.base2 = base2;
        this.height = height;
        this.side1 = side1;
        this.side2 = side2;
    }
    public override double CalculateArea()
    {
        return (base1 + base2) * height / 2;
    }
    public override double CalculatePerimeter()
    {
        return base1 + base2 + side1 + side2;
    }
    public override void Print()
    {
        Console.WriteLine("Trapezoid:");
        Console.WriteLine("Area: " + CalculateArea());
        Console.WriteLine("Perimeter: " + CalculatePerimeter());
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(4, 6);
        Trapezoid trapezoid = new Trapezoid(3, 5, 2, 4, 3);

        circle.Print();
        rectangle.Print();
        trapezoid.Print();
    }
}
Вариант 8.
Создать абстрактный базовый класс с виртуальной функцией - площадь поверхности. Создать производные классы: параллелепипед, тетраэдр, шар со своими функциями площади поверхности. Для проверки определить массив ссылок на абстрактный класс, которым присваиваются адреса различных объектов.
Площадь поверхности параллелепипеда: S=6xy. Площадь поверхности шара: S=4 r2. Площадь поверхности тетраэдра: S=a2 3
using System;
abstract class Shape
{
    public abstract double CalculateSurfaceArea();
}
class Cuboid : Shape
{
    private double length;
    private double width;
    private double height;
    public Cuboid(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }
    public override double CalculateSurfaceArea()
    {
        return 2 * (length * width + length * height + width * height);
    }
}
class Tetrahedron : Shape
{
    private double sideLength;
    public Tetrahedron(double sideLength)
    {
        this.sideLength = sideLength;
    }
    public override double CalculateSurfaceArea()
    {
        return Math.Sqrt(3) * sideLength * sideLength;
    }
}

class Sphere : Shape
{
    private double radius;
    public Sphere(double radius)
    {
        this.radius = radius;
    }
    public override double CalculateSurfaceArea()
    {
        return 4 * Math.PI * radius * radius;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[3];
        shapes[0] = new Cuboid(2, 3, 4);
        shapes[1] = new Tetrahedron(5);
        shapes[2] = new Sphere(2.5);

        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine("Surface area of shape " + (i + 1) + ": " + shapes[i].CalculateSurfaceArea());
        }

        Console.ReadLine();
    }
}


Вариант 10.
Создать абстрактный базовый класс с виртуальной функцией - объем. Создать производные классы: параллелепипед, пирамида, тетраэдр, шар со своими функциями объема. Для проверки определить массив ссылок на абстрактный класс, которым присваиваются адреса различных объектов.
Объем параллелепипеда - V=xyz (x,y,z - стороны , пирамиды: V=xyh (x,y, - стороны, h - высота), тетраэдра: V= a32/12, шара: V=4 r3/3.
using System;
abstract class Shape
{
    public abstract double CalculateVolume();
}
class Cuboid : Shape
{
    private double length;
    private double width;
    private double height;
    public Cuboid(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }
    public override double CalculateVolume()
    {
        return length * width * height;
    }
}
class Pyramid : Shape
{
    private double baseLength;
    private double baseWidth;
    private double height;
    public Pyramid(double baseLength, double baseWidth, double height)
    {
        this.baseLength = baseLength;
        this.baseWidth = baseWidth;
        this.height = height;
    }

    public override double CalculateVolume()
    {
        return (baseLength * baseWidth * height) / 3;
    }
}

class Tetrahedron : Shape
{
    private double sideLength;

    public Tetrahedron(double sideLength)
    {
        this.sideLength = sideLength;
    }

    public override double CalculateVolume()
    {
        return (Math.Sqrt(2) * Math.Pow(sideLength, 3)) / 12;
    }
}

class Sphere : Shape
{
    private double radius;

    public Sphere(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateVolume()
    {
        return (4 * Math.PI * Math.Pow(radius, 3)) / 3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[4];
        shapes[0] = new Cuboid(2, 3, 4);
        shapes[1] = new Pyramid(5, 6, 7);
        shapes[2] = new Tetrahedron(8);
        shapes[3] = new Sphere(9);

        foreach (var shape in shapes)
        {
            Console.WriteLine("Объем: " + shape.CalculateVolume());
        }
    }
}
Вариант 11.
Создать абстрактный класс - млекопитающие. Определить производные классы - животные и люди. У животных определить производные классы собак и коров. Определить виртуальные функции описания человека, собаки и коровы.
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


































Вариант 12.
Создать базовый класс - Предок, у которого есть имя. определить виртуальную функцию печати. Создать производный класс Ребенок, у которого функция печати дополнительно выводит имя. Создать производный класс от последнего класса - Внук, у которого есть отчество. Написать свою функцию печати.
using System;
class Ancestor
{
    protected string name;

    public Ancestor(string name)
    {
        this.name = name;
    }
    public virtual void Print()
    {
        Console.WriteLine("Имя: " + name);
    }
}
class Child : Ancestor
{
    public Child(string name) : base(name)
    {
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine("Это ребенок.");
    }
}
class Grandchild : Child
{
    private string patronymic;

    public Grandchild(string name, string patronymic) : base(name)
    {
        this.patronymic = patronymic;
    }

    public void PrintWithPatronymic()
    {
        base.Print();
        Console.WriteLine("Отчество: " + patronymic);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Ancestor ancestor = new Ancestor("Предок");
        Child child = new Child("Ребенок");
        Grandchild grandchild = new Grandchild("Внук", "Отчество");
        ancestor.Print();
        Console.WriteLine();
        child.Print();
        Console.WriteLine();
        grandchild.PrintWithPatronymic();
        Console.WriteLine();
    }
}
Вариант 14.
Создать абстрактный базовый класс с виртуальной функцией - корни уравнения. Создать производные классы: класс линейных уравнений и класс квадратных уравнений. Определить функцию вычисления корней уравнений.
using System;
abstract class Equation
{
    public abstract void Solve();
}
class LinearEquation : Equation
{
    private double a;
    private double b;
    public LinearEquation(double a, double b)
    {
        this.a = a;
        this.b = b;
    }
    public override void Solve()
    {
        if (a == 0)
        {
            Console.WriteLine("Уравнение не является линейным.");
        }
        else
        {
            double x = -b / a;
            Console.WriteLine("Корень линейного уравнения: x = " + x);
        }
    }
}
class QuadraticEquation : Equation
{
    private double a;
    private double b;
    private double c;

    public QuadraticEquation(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override void Solve()
    {
        if (a == 0)
        {
            Console.WriteLine("Уравнение не является квадратным.");
        }
        else
        {
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                Console.WriteLine("Уравнение не имеет действительных корней.");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Уравнение имеет один корень: x = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("Уравнение имеет два корня: x1 = " + x1 + ", x2 = " + x2);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Equation equation1 = new LinearEquation(2, 4);
        equation1.Solve();
        Equation equation2 = new QuadraticEquation(1, -3, 2);
        equation2.Solve();
        Equation equation3 = new QuadraticEquation(1, 2, 3);
        equation3.Solve();
    }
}































Вариант 13.
Создать класс живущих с местоположением. Определить наследуемые классы - лиса, кролик и трава. Лиса ест кролика. Кролик ест траву. Лиса может умереть - определен возраст. Кролик тоже может умереть. Кроме этого определен класс - отсутствие жизни. Если в окрестности имеется больше травы, чем кроликов, то трава остается, иначе трава съедена. Если лис слишком старый он может умереть. Если лис слишком много (больше 5 в окрестности), лисы больше не появляются. Если кроликов меньше лис, то лис ест кролика.
using System;
class LivingBeing
{
    protected string location;
    public LivingBeing(string location)
    {
        this.location = location;
    }
    public virtual void Eat(LivingBeing food)
    {
        Console.WriteLine("Это живое существо питается.");
    }
    public virtual void Die()
    {
        Console.WriteLine("Это живое существо умерло.");
    }
    public string Location
    {
        get { return location; }
    }
}
class Fox : LivingBeing
{
    private int age;
    private static int foxCount = 0;
    public Fox(string location, int age) : base(location)
    {
        this.age = age;
        foxCount++;
    }
    public override void Eat(LivingBeing food)
    {
        if (food is Rabbit)
        {
            Console.WriteLine("Лиса съела кролика.");
            Rabbit rabbit = (Rabbit)food;
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
        foxCount--;
    }
    public int Age
    {
        get { return age; }
    }
    public static int FoxCount
    {
        get { return foxCount; }
    }
}

class Rabbit : LivingBeing
{
    private static int rabbitCount = 0;
    public Rabbit(string location) : base(location)
    {
        rabbitCount++;
    }
    public override void Eat(LivingBeing food)
    {
        if (food is Grass)
        {
            Console.WriteLine("Кролик съел траву.");
            Grass grass = (Grass)food;
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
        rabbitCount--;
    }
    public static int RabbitCount
    {
        get { return rabbitCount; }
    }
}

class Grass : LivingBeing
{
    private bool eaten = false;

    public Grass(string location) : base(location)
    {
    }
    public override void Eat(LivingBeing food)
    {
        Console.WriteLine("Трава не ест другие существа.");
    }
    public void Eaten()
    {
        eaten = true;
        Console.WriteLine("Трава была съедена.");
    }
    public bool EatenStatus
    {
        get { return eaten; }
    }
}

class NoLife : LivingBeing
{
    public NoLife() : base("Нет жизни")
    {
    }
    public override void Eat(LivingBeing food)
    {
        Console.WriteLine("Нет жизни, нечего есть.");
    }
    public override void Die()
    {
        Console.WriteLine("Нет жизни, нельзя умереть.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        LivingBeing[] surroundings = new LivingBeing[7];
        surroundings[0] = new Fox("Дом", 4);
        surroundings[1] = new Rabbit("Поле");
        surroundings[2] = new Rabbit("Поле");
        surroundings[3] = new Rabbit("Поле");
        surroundings[4] = new Rabbit("Поле");
        surroundings[5] = new Rabbit("Поле");
        surroundings[6] = new Grass("Поле");
        // Проверка питания и смерти
        foreach (var livingBeing in surroundings)
        {
            if (livingBeing is Fox)
            {
                Fox fox = (Fox)livingBeing;
                Console.WriteLine("Лиса возрастом " + fox.Age + " находится в " + fox.Location);
                fox.Eat(surroundings[1]);
            }
            else if (livingBeing is Rabbit)
            {
                Rabbit rabbit = (Rabbit)livingBeing;
                Console.WriteLine("Кролик находится в " + rabbit.Location);
                rabbit.Eat(surroundings[6]);
            }
        }
        Console.WriteLine();
        // Проверка количества лис и кроликов
        Console.WriteLine("Количество лис: " + Fox.FoxCount);
        Console.WriteLine("Количество кроликов: " + Rabbit.RabbitCount);
        Console.WriteLine();
        // Проверка ситуации, когда больше лис, чем кроликов
        Console.WriteLine("Ситуация, когда больше лис, чем кроликов:");
        Fox fox1 = new Fox("Поле", 3);
        Fox fox2 = new Fox("Поле", 2);
        Fox fox3 = new Fox("Поле", 1);
        Fox fox4 = new Fox("Поле", 5);
        Fox fox5 = new Fox("Поле", 4);
        Console.WriteLine("Количество лис: " + Fox.FoxCount);
        Console.WriteLine("Количество кроликов: " + Rabbit.RabbitCount);
    }
}


