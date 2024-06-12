using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract public class container
{
    public virtual double norm()
    {
        return 0;
    }
}

class complex_numbers : container
{
    private double _re;
    private double _im;

    public complex_numbers(double re, double im)
    {
        _re = re;
        _im = im;
    }
    public override double norm()
    {
        return _re * _re + _im * _im;
    }
}

class vector : container
{
    private double[] _elementy;

    public vector(double[] elementy)
    {
        _elementy = elementy;
    }
    public override double norm()
    {
        double sum = 0;
        foreach(double num in _elementy)
        {
            sum += Math.Abs(num);
        }
        return Math.Sqrt(sum);
    }
}

class matrix : container
{
    private double[,] _matrica;

    public matrix(double[,] matrica)
    {
        _matrica = matrica;
    }
    public override double norm()
    {
        double maxElement = 0;
        for (int i = 0; i < _matrica.GetLength(0); i++)
        {
            for (int j = 0; j < _matrica.GetLength(1); j++)
            {
                if (Math.Abs(_matrica[i, j]) > maxElement)
                {
                    maxElement = Math.Abs(_matrica[i, j]);
                }
            }
        }
        return maxElement;
    }
}


namespace V2
{
    class Program
    {
        static void Main(string[] args)
        {
            complex_numbers c1 = new complex_numbers(3, 4);
            Console.WriteLine("Норма комплексного числа: " + c1.norm());

            vector v = new vector(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Console.WriteLine("Норма вектора: " + v.norm());

            double[,] matrData = { { 1, 2 }, { 3, 4 } };
            matrix matrica = new matrix(matrData);
            Console.WriteLine("Норма матрицы: " + matrica.norm());
            Console.ReadLine();
        }
    }
}
