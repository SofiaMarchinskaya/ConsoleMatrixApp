using System;
using System.ComponentModel;
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
            string n_s = Console.ReadLine();
            int? n = n_s.SafeParseInt();
            if (n == null) {
                return;
            }
            Console.WriteLine("Columns = ");
            n_s = Console.ReadLine();
            int? m = n_s.SafeParseInt();
            if (m == null)
            {
                return;
            }
            double[,] matrix = new double[(int)n, (int)m];
            Program program = new Program();
            Console.WriteLine("Insert matrix. Write rows ");
            bool result = program.ReadMatrix(ref matrix);
            if (!result)
            {
                Console.WriteLine("Error occured while data reading. Try Again!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Done!");
            Console.WriteLine("Matrix: ");
            program.PrintMatrix(matrix);

            Console.WriteLine("Insert number p = ");
            double p = Double.Parse(Console.ReadLine());
            double min = program.Min(matrix);
            double max = program.Max(matrix);
            Console.WriteLine("Min number in matrix = " + min);
            Console.WriteLine("Max number in matrix = " + max);
            Console.WriteLine("Max-Min = " + (max - min));
            if (max - min > p)
            {
                Console.WriteLine("Max-Min = " + (max - min) + " is greater than p = " + p);
                program.ReplaceValues(ref matrix);
                Console.WriteLine("Result after replacing: ");
                program.PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine("Max-Min = " + (max - min) + " is less or equals p = " + p);
            }
            Console.ReadLine();
        }

        double Min(double[,] matrix)
        {
            double min = matrix[0, 0];
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }

        double Max(double[,] matrix)
        {
            double max = matrix[0, 0];
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
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
                    if (matrix[i, j] > 0)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

        }

        bool ReadMatrix(ref double[,] matrix)
        {
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                string[] s = Console.ReadLine().Split(' ');
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    double? result = s[j].SafeParseDouble();
                    if (result == null)
                    {
                        return false;
                    }
                    matrix[i,j] = (double)result;
                }
            }
            return true;
        }

        void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

    }

    public static class SafeParser
    {
        public static double? SafeParseDouble(this string input)
        {
            double output = 0.0;
            bool result = double.TryParse(input, out output);
            if (!result)
            {
                Console.WriteLine("Parsing error for " + input);
                Console.ReadLine();
                return null;
            }
            return output;
        }


        public static int? SafeParseInt(this string input)
        {
            int output = 0;
            bool result = int.TryParse(input, out output);
            if (!result)
            {
                Console.WriteLine("Parsing error for " + input);
                Console.ReadLine();
                return null;
            }
            return output;
        }
    }
}
 
