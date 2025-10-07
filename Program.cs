using System;

namespace OOP_Lab
{
    class Vector
    {
        protected const int Size = 4;
        private double[] _elements = new double[Size];

        public double[] Elements
        {
            get { return _elements; }
        }

        public Vector() { }

        public Vector(double[] values)
        {
            if (values.Length == Size)
                _elements = values;
        }

        public virtual void SetElements()
        {
            Console.WriteLine($"Введіть {Size} елементи вектора:");
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"elements[{i}] = ");
                elements[i] = Convert.ToDouble(Console.ReadLine());
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

    class Matrix
    {
        protected const int Size = 4;
        private double[,] _matrix = new double[Size, Size];

        public double[,] Data
        {
            Console.WriteLine("Введіть елементи матриці 4x4:");
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"matrix[{i},{j}] = ");
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
        }

        public virtual void Display()
        {
            Console.WriteLine("Матриця:");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Console.Write($"{_matrix[i, j]}\t");
                Console.WriteLine();
            }
        }

        public virtual double MaxElement()
        {
            double max = _matrix[0, 0];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (_matrix[i, j] > max)
                        max = _matrix[i, j];
            return max;
        }
    }

    class DiagonalMatrix : Matrix
    {
        public DiagonalMatrix() : base() { }

        public override void SetElements()
        {
            Console.WriteLine("Введіть діагональні елементи матриці 4x4:");
            for (int i = 0; i < Size; i++)
            {
                double value;
                while (true)
                {
                    Console.Write($"diag[{i}] = ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out value))
                    {
                        Data[i, i] = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Невірне значення! Введіть число ще раз.");
                    }
                }
            }
        }

        public double Trace()
        {
            double sum = 0;
            for (int i = 0; i < Size; i++)
                sum += Data[i, i];
            return sum;
        }

        public override void Display()
        {
            Console.WriteLine("Діагональна матриця:");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Console.Write($"{Data[i, j]}\t");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Vector vector = new Vector();
            vector.SetElements();
            vector.Display();
            Console.WriteLine($"Максимальний елемент вектора: {vector.MaxElement()}\n");

            Matrix matrix = new Matrix();
            matrix.SetElements();
            matrix.Display();
            Console.WriteLine($"Максимальний елемент матриці: {matrix.MaxElement()}\n");

            DiagonalMatrix dmatrix = new DiagonalMatrix();
            dmatrix.SetElements();
            dmatrix.Display();
            Console.WriteLine($"Слід (Trace) діагональної матриці: {dmatrix.Trace()}");

            Console.ReadKey();
        }
    }
}
