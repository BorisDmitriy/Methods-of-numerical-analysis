using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._1
{
    class Program
    {
        public static double F(double x)
        {
            double f = Math.Exp(x) + 1 - Math.Sqrt(9 - x * x);
            return f;
        }


        static void Main(string[] args)
		{
			double a , b ,x0, e = Math.Pow(10, -5);


			 Console.Write("Введите a :"); a = double.Parse(Console.ReadLine());

			Console.Write("Введите b :"); b = double.Parse(Console.ReadLine());


			Console.Write("Введите произвольную точку, принадлежащую [{0};{1}] : " , a , b); x0 = double.Parse(Console.ReadLine());

			metod_popolam(a,b,e);
			metod_iterazi(x0,e);
			method_Newton(x0,e);

			Console.ReadKey();
		}


        public static void metod_popolam(double a, double b,double e)
		{

            int k = 1;
            double c;
            bool t;
            t = true;


            do
            {
                c = (a + b) / 2;
                if (Math.Abs(F(a)) > e || k==1000)
                {
                    if (F(a) * F(c) > 0)
                    {
                        a = c;
                        k++;
                    }
                    else
                    {
                        b = c;
                        k++;
                    }
                }
                else
                {
                    t = false;
                    break;
                }
            }

            while (t == true);
			if (t==true)
			{
				Console.WriteLine("Не найдено");
			}
			else
			{
				Console.WriteLine("\nМетод деления пополам:\n");
				Console.WriteLine("Ответ: X = {0} ", c);
				Console.WriteLine("Итераций пройдено: {0}\n\n", k);
			}
		}


		public static double func(double x)
		{
			return x - (1 / (dF(x))) * F(x);
		}

		public static void metod_iterazi(double x0,double e)
		{
			double x1 = 0;
			int i = 0;
			bool error = false;

			do
			{
				x1 = func(x0);
				i++;
				if (Math.Abs(F(x0)) > e && i == 1000)
				{
					error = true;
					break;
				}
				x0 = x1;
			} while (Math.Abs(x0 - func(x0)) > e);
			if (error)
			{
				Console.WriteLine("Не найдено");
			}
			else
			{
				Console.WriteLine("Метод простой итерации\n");
				Console.WriteLine("Ответ: X = {0} ", x1);
				Console.WriteLine("Итераций пройдено: {0}\n\n", i);
			}
		}
	
		public static double dF(double x) //возвращает значение производной
		{
			return (Math.Exp(x) + (x/ (Math.Sqrt(9.0 - x * x))));
		}
		

		public static void method_Newton(double x,double e)
		{
			int i = 0;
			double x0;
			
			do
			{

				x0 = x - F(x) / dF(x);
				x = x0;
				i++;

			} while (Math.Abs(F(x)) >= e);

			Console.WriteLine("Метод Ньютона\n");
			Console.WriteLine("Ответ: X = {0} ", x);
			Console.WriteLine("Итераций пройдено: {0}\n\n", i);
		}
	}
}
