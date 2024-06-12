using System;

public abstract class Employee(string name, string position)
{
    public string Name { get; } = name;
    public string Position { get; } = position;

    public abstract double CalculateSalary();
}

internal class HourlyEmployee(string name, string position, double hourlyRate, int hoursWorked)
    : Employee(name, position)
{

    public override double CalculateSalary()
    {
        return hourlyRate * hoursWorked;
    }
}

public class SalariedEmployee(string name, string position, double monthlySalary) : Employee(name, position)
{

    public override double CalculateSalary()
    {
        return monthlySalary;
    }
}

public class CommissionEmployee(string name, string position, double sales, double commissionRate)
    : Employee(name, position)
{

    public override double CalculateSalary()
    {
        return sales * commissionRate;
    }
}

public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new HourlyEmployee("Иван Иванов", "Почасовой рабочий", 20, 160),
            new SalariedEmployee("Петр Петров", "Штатный сотрудник", 3000),
            new CommissionEmployee("Сергей Сергеев", "Продавец", 50000, 0.05)
        };

        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.Name}, {employee.Position}: {employee.CalculateSalary()} руб.");
        }
    }
}
