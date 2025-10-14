using System;
using System.Linq;

namespace OOP_Lab1
{
    public class Vector
    {
        protected int size;
        protected double[] elements;

        public Vector() : this(4) { }

        public Vector(int size)
        {
            this.size = size;
            elements = new double[size];
        }

        public virtual void InputElements()
        {
            Console.WriteLine($"Введіть {size} елементів вектора:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент [{i}] = ");
                while (!double.TryParse(Console.ReadLine(), out elements[i]))
                    Console.Write("Некоректне значення, повторіть: ");
            }
        }

        public virtual void Display()
        {
            Console.WriteLine("Вектор: " + string.Join(", ", elements));
        }

        public virtual double MaxElement() =>
            elements.Length > 0 ? elements.Max() : double.NaN;
    }

    public class Matrix : Vector
    {
        protected const int Size = 4;
        private double[,] _matrix = new double[Size, Size];

        public double[,] Data
        protected double[,] matrix = new double[4, 4];
        // Лише одне поле для зберігання даних матриці
        protected double[,] _matrix = new double[Size, Size];
        private double[,] _matrix = new double[Size, Size];

        public double[,] Data
        {
            get => _matrix;
            set
            {
                if (value.GetLength(0) == Size && value.GetLength(1) == Size)
                    _matrix = value;
                else
                    throw new ArgumentException($"Матриця повинна бути розміру {Size}x{Size}");
            }
        }
        protected double[,] matrix = new double[4, 4];
        private double[,] matrix = new double[4, 4];
        private int rows;
        private int cols;

        public Matrix() : this(4, 4) { }

        public Matrix(int rows, int cols) : base(rows * cols)
        {
            this.rows = rows;
            this.cols = cols;
        }

        public override void InputElements()
        {
            Console.WriteLine($"Введіть елементи матриці {rows}x{cols}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент [{i},{j}] = ");
                    int index = i * cols + j;
                    while (!double.TryParse(Console.ReadLine(), out elements[index]))
                        Console.Write("Некоректне значення, повторіть: ");
                }
            }
        }

        public override void Display()
        {
            Console.WriteLine($"Матриця {rows}x{cols}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{elements[i * cols + j],8}");
                Console.WriteLine();
            }
        }

        public override double MaxElement() => base.MaxElement();
    }

    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var v = new Vector();
            v.InputElements();
            v.Display();
            Console.WriteLine($"Максимальний елемент вектора: {v.MaxElement()}\n");

            var m = new Matrix();
            m.InputElements();
            m.Display();
            Console.WriteLine($"Максимальний елемент матриці: {m.MaxElement()}");
        }
    }
}
