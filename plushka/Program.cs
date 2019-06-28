using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace plushka
{
    class Program
    {
        static double summa1(double x, int N, ref double esp1)
        {
            double summ1 = 1;
            double t = 1;
            for (int i = 1; i < N; i++)
            {
                t *= (x * x / i) * (-1);
                summ1 += t;
            }
            t *= x * x / N * (-1);
            esp1 = t / summ1;
            return summ1;
        }
        static double summa2(double x, double E, ref int kolslag)
        {
            double summ2 = 1, eps = 1;
            double t = x * x * (-1);
            kolslag = 1;
            for (int i = 1; Math.Abs(eps) > E; i++)
            {
                summ2 += t;
                t *= (x * x / (i + 1)) * (-1);
                if (summ2 == 0)
                {
                    eps = 1;
                }
                else
                {
                    eps = t / summ2;
                }
                kolslag = i + 1;
            }
            return summ2;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите значение x\n"); // Ввод значения переменной 
            double x = Convert.ToDouble(Console.ReadLine());// 
            Console.Clear();
            double Eps = Math.Exp(-x * x);//точное значение 
                                          //Console.WriteLine(Eps); 

            Console.Write("Введите число слагаемых\n"); //Ввод числа слагаемых 
            int N = Convert.ToInt32(Console.ReadLine());// 
            Console.Clear();



            Console.Write("Введите точность\n"); // Ввод точности 
            double E = Convert.ToDouble(Console.ReadLine());// 
            Console.Clear();
            double summ1, summ2;
            int kolslag = 0;
            double eps1 = 0;

            summ1 = summa1(x, N, ref eps1);//функция вычилсляющая сумму при слагаемых 
            summ2 = summa2(x, E, ref kolslag);//функция вычилсляющая сумму при точности 

            Console.WriteLine("e^(-x^2)= {0:0.0000}, при {1} слагаемых, Eps={5:0.0000}\ne^(-x^2)={2:0.0000} ,при точности {3},получается {4} слагаемыx\n", summ1, N, summ2, E, kolslag, eps1);
            Console.ReadKey();
        }
    }
}
