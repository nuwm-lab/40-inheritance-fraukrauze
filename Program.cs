using System;

namespace OOP_Lab
{
    // Клас "Одновимірний вектор розмірності 4"
    class Vector
    {
        protected double[] elements = new double[4];

        // Метод задання елементів вектора
        public virtual void InputElements()
        {
            Console.WriteLine("Введіть 4 елементи вектора:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Елемент [{i}] = ");
                elements[i] = double.Parse(Console.ReadLine());
            }
        }

        // Метод виведення вектора
        public virtual void Display()
        {
            Console.Write("Вектор: ");
            foreach (var item in elements)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        // Метод знаходження максимального елемента
        public virtual double MaxElement()
        {
            double max = elements[0];
            foreach (var item in elements)
                if (item > max) max = item;
            return max;
        }
    }

    // Похідний клас "Матриця 4x4"
    class Matrix : Vector
    {
        private double[,] matrix = new double[4, 4];

        // Перевантажений метод задання елементів матриці
        public override void InputElements()
        {
            Console.WriteLine("Введіть елементи матриці 4x4:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Елемент [{i},{j}] = ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        // Перевантажений метод виведення матриці
        public override void Display()
        {
            Console.WriteLine("Матриця 4x4:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }
        }

        // Перевантажений метод знаходження максимального елемента матриці
        public override double MaxElement()
        {
            double max = matrix[0, 0];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (matrix[i, j] > max) max = matrix[i, j];
            return max;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Об’єкт класу Vector
            Vector v = new Vector();
            v.InputElements();
            v.Display();
            Console.WriteLine($"Максимальний елемент вектора: {v.MaxElement()}\n");

            // Об’єкт класу Matrix
            Matrix m = new Matrix();
            m.InputElements();
            m.Display();
            Console.WriteLine($"Максимальний елемент матриці: {m.MaxElement()}");
        }
    }
}
