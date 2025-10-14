using System;

namespace OOP_Lab
{
    public class Vector
    {
        protected const int Size = 4;
        protected double[] _elements = new double[Size];

        public virtual void SetElements()
        {
            Console.WriteLine($"Введіть {Size} елементи вектора:");
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"_elements[{i}] = ");
                while (!double.TryParse(Console.ReadLine(), out _elements[i]))
                    Console.Write("Некоректне значення! Введіть число: ");
            }
        }

        public virtual void Display()
        {
            Console.WriteLine("Вектор:");
            foreach (double e in _elements)
                Console.Write($"{e}\t");
            Console.WriteLine();
        }

        public virtual double MaxElement()
        {
            double max = _elements[0];
            for (int i = 1; i < Size; i++)
                if (_elements[i] > max)
                    max = _elements[i];
            return max;
        }
    }

    public class Matrix : Vector
    {
        // Лише одне поле для зберігання даних матриці
        protected double[,] _matrix = new double[Size, Size];

        // Опціональна властивість для доступу до даних (можна видалити, якщо не потрібна)
        public double[,] Data
        {
            get { return _matrix; }
            set
            {
                if (value.GetLength(0) == Size && value.GetLength(1) == Size)
                    _matrix = value;
                else
                    throw new ArgumentException($"Матриця повинна бути розміру {Size}x{Size}");
            }
        }

        public override void SetElements()
        {
            Console.WriteLine($"Введіть елементи матриці {Size}x{Size}:");
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"_matrix[{i},{j}] = ");
                    while (!double.TryParse(Console.ReadLine(), out _matrix[i, j]))
                        Console.Write("Некоректне значення! Введіть число: ");
                }
        }

        public override void Display()
        {
            Console.WriteLine("Матриця:");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Console.Write($"{_matrix[i, j]}\t");
                Console.WriteLine();
            }
        }

        public override double MaxElement()
        {
            double max = _matrix[0, 0];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (_matrix[i, j] > max)
                        max = _matrix[i, j];
            return max;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Vector vector = new Vector();
            vector.SetElements();
            vector.Display();
            Console.WriteLine($"Максимальний елемент вектора: {vector.MaxElement()}\n");

            Matrix matrix = new Matrix();
            matrix.SetElements();
            matrix.Display();
            Console.WriteLine($"Максимальний елемент матриці: {matrix.MaxElement()}");

            Console.ReadKey();
        }
    }
}
