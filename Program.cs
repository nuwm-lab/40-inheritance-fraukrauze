using System;

namespace OOP_Lab
{
    class Vector
    {
        protected double[] elements = new double[4];

        public virtual void SetElements()
        {
            Console.WriteLine("Введіть 4 елементи вектора:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"elements[{i}] = ");
                elements[i] = Convert.ToDouble(Console.ReadLine());
            }
        }

        public virtual void Display()
        {
            Console.WriteLine("Вектор:");
            foreach (double e in elements)
                Console.Write($"{e}\t");
            Console.WriteLine();
        }

        public virtual double MaxElement()
        {
            double max = elements[0];
            for (int i = 1; i < elements.Length; i++)
                if (elements[i] > max)
                    max = elements[i];
            return max;
        }
    }

    class Matrix : Vector
    {
        protected const int Size = 4;
        private double[,] _matrix = new double[Size, Size];

        public double[,] Data
        protected double[,] matrix = new double[4, 4];

        public override void SetElements()
        {
            Console.WriteLine("Введіть елементи матриці 4x4:");
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"matrix[{i},{j}] = ");
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
        }

        public override void Display()
        {
            Console.WriteLine("Матриця:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }

        public override double MaxElement()
        {
            double max = matrix[0, 0];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
            return max;
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
            Console.WriteLine($"Максимальний елемент матриці: {matrix.MaxElement()}");

            Console.ReadKey();
        }
    }
}
