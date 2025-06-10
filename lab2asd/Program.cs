using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab2asd
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
          
            DynamicArray arr = new DynamicArray(10);
            arr.FillTestData(new double[] { 1.5, -3, 2.2, 4, -1, 6, 0, 5 });

            Console.WriteLine("Масив:");
            arr.Print();

            Console.WriteLine("Сума елементiв з непарними iндексами: " + arr.SumOddIndex());
            Console.WriteLine("Сума мiж першим i останнiм вiд’ємними: " + arr.SumBetweenNegatives());

            Console.Write("Введiть M: ");
            int m = int.Parse(Console.ReadLine());

            arr.MoveFirstMToEnd(m);

            Console.WriteLine("Масив пiсля перестановки:");
            arr.Print();
        }
    }
    class DynamicArray
    {
        private double[] items;
        private int size;

        public DynamicArray(int capacity)
        {
            items = new double[capacity];
            size = 0;
        }

        public void Add(double value)
        {
            if (size == items.Length)
                Resize(items.Length * 2);
            items[size++] = value;
        }

        private void Resize(int newCapacity)
        {
            double[] newItems = new double[newCapacity];
            for (int i = 0; i < size; i++)
                newItems[i] = items[i];
            items = newItems;
        }

        public double SumOddIndex()
        {
            double sum = 0;
            for (int i = 1; i < size; i += 2)
                sum += items[i];
            return sum;
        }

        public double SumBetweenNegatives()
        {
            int first = -1, last = -1;
            for (int i = 0; i < size; i++)
                if (items[i] < 0) { first = i; break; }
            for (int i = size - 1; i >= 0; i--)
                if (items[i] < 0) { last = i; break; }

            double sum = 0;
            if (first != -1 && last != -1 && first < last)
                for (int i = first + 1; i < last; i++)
                    sum += items[i];
            return sum;
        }

        public void MoveFirstMToEnd(int m)
        {
            if (m >= size || m < 0) return;

            double[] newArray = new double[size];
            int index = 0;
            for (int i = m; i < size; i++)
                newArray[index++] = items[i];
            for (int i = 0; i < m; i++)
                newArray[index++] = items[i];
            items = newArray;
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
                Console.Write(items[i] + " ");
            Console.WriteLine();
        }

        public void FillTestData(double[] data)
        {
            foreach (var item in data)
                Add(item);
        }
    }

}
