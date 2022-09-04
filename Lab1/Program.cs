using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rows = ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Columns = ");
            int m = Int32.Parse(Console.ReadLine());
            double[,] matrix = new double[n,m];
            Program program = new Program();
            Console.WriteLine("Insert matrix. Write rows ");
            program.ReadMatrix(ref matrix);
            Console.WriteLine("Done!");
            Console.WriteLine("Matrix: ");
            program.PrintMatrix(matrix);

            Console.WriteLine("Insert number p = ");
            double p = Double.Parse(Console.ReadLine());
            double min = program.Min(matrix);
            double max = program.Max(matrix);
            Console.WriteLine("Min number in matrix = " + min);
            Console.WriteLine("Max number in matrix = " + max);
            Console.WriteLine("Max-Min = " + (max-min));
            if (max - min > p)
            {
                Console.WriteLine("Max-Min = " + (max - min) + " is greater than p = " + p);
                program.ReplaceValues(ref matrix);
                Console.WriteLine("Result after replacing: ");
                program.PrintMatrix(matrix);
            }
            else {
                Console.WriteLine("Max-Min = " + (max - min) + " is less or equals p = " + p);
             }
            Console.ReadLine();
        }

        double Min(double[,] matrix)
        {
            double min = matrix[0,0];
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    if (matrix[i,j] < min)
                    {
                        min = matrix[i,j];
                    }
                }
            }
            return min;
        }

        double Max(double[,] matrix)
        {
            double max = matrix[0,0];
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i,j];
                    }
                }
            }
            return max;
        }

        void ReplaceValues(ref double[,] matrix)
        {
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        matrix[i,j] = 1;
                    }
                    else
                    {
                        matrix[i,j] = 0;
                    }
                }
            }

        }

        void ReadMatrix(ref double[,] matrix)
        {
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                string[] s = Console.ReadLine().Split(' ');
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                   matrix[i, j] = Double.Parse(s[j]);
                }
            }

        }
        void PrintMatrix(double[,] matrix) { 
        for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        
        }
    }
}
