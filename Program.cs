using System;

class Vector1D
{
    protected double[] elements = new double[4];

    // Метод для задання елементів вектора
    public virtual void SetElements()
    {
        Console.WriteLine("Введіть 4 елементи вектора:");
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Елемент [{i + 1}]: ");
            elements[i] = double.Parse(Console.ReadLine());
        }
    }

    // Метод для виведення вектора
    public virtual void Display()
    {
        Console.WriteLine("Вектор:");
        for (int i = 0; i < 4; i++)
        {
            Console.Write(elements[i] + " ");
        }
        Console.WriteLine();
    }

    // Метод для знаходження максимального елемента
    public virtual double MaxElement()
    {
        double max = elements[0];
        for (int i = 1; i < 4; i++)
        {
            if (elements[i] > max)
                max = elements[i];
        }
        return max;
    }
}

// Похідний клас — матриця
class Matrix : Vector1D
{
    private double[,] matrix;
    private int rows;
    private int cols;

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        matrix = new double[rows, cols];
    }

    // Перевантаження методу для задання елементів матриці
    public override void SetElements()
    {
        Console.WriteLine($"Введіть елементи матриці розміром {rows}x{cols}:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }

    // Перевантаження методу для виведення матриці
    public override void Display()
    {
        Console.WriteLine("Матриця:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Перевантаження методу для знаходження максимального елемента матриці
    public override double MaxElement()
    {
        double max = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                    max = matrix[i, j];
            }
        }
        return max;
    }
}

class Program
{
    static void Main()
    {
        // Об’єкт класу "одновимірний вектор"
        Vector1D vector = new Vector1D();
        vector.SetElements();
        vector.Display();
        Console.WriteLine("Максимальний елемент вектора: " + vector.MaxElement());

        Console.WriteLine();

        // Об’єкт класу "матриця"
        Matrix matrix = new Matrix(3, 3);
        matrix.SetElements();
        matrix.Display();
        Console.WriteLine("Максимальний елемент матриці: " + matrix.MaxElement());
    }
}
