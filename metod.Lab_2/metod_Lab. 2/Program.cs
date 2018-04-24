using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metod_Lab._2
{
	class Program
	{
		public static double F(double x)
		{

			double f = Math.Atan(1 / x) - x * x;
			return f;
		}

		public static double dF(double x) //возвращает значение производной
		{
			return ((Math.Log(1 + x * x)) / 2 - (x * x * x) / 3 + Math.Atan(1 / x) * x);
		}

		public static double func(double x)
		{
			return x - (1 / (dF(x))) * F(x);
		}

		

		static void Main()
		{
				double a=1, b=1, e = Math.Pow(10, -5);
			do
			{

				Console.Write("Введите a:");
				a = double.Parse(Console.ReadLine());
				if (a==0) Console.Write("\nДеление на 0!!! Повторите ввод\n");
			}
			while (a==0);

		Console.Write("Введите b :"); b = double.Parse(Console.ReadLine());
				

		method_chord(a, b, e);
		method_aitken(a, b, e);
		method_stephenson(a, b, e);

		Console.ReadKey();
		
		}
	
	

		public static void method_chord(double a, double b, double e)
		{

			Console.WriteLine("\nМетод хорд:\n");
			double x_next = 0;
			double tmp;
			int i = 3;
			do
			{
				tmp = x_next;
				x_next = b - F(b) * (a - b) / (F(a) -F(b));
				a = b;
				b = tmp;
				i++;
			} while (Math.Abs(x_next - b) > e);
			
			Console.WriteLine("Ответ: X = {0}\n Итераций пройдено: {1}\n\n", x_next, i);
		}
		
		public static void method_aitken(double a, double b,double e)
		{


			Console.WriteLine("\nМетод Эйткена:\n");
			double x0 = (a + b) / 2.0;
			double x1 = func(x0);
			double x2 = func(x1);
			double x_temp = (x0 * x2 - (x1*x1)) / (x2 - 2 * x1 + x0);
			double x3 = func(x_temp);



			int i = 1;
			while (Math.Abs(F(x3)) > e)
			{
				x0 = x_temp;
				x2 = func(x1);
				x1 = x3;
				x_temp= (x0 * x2 - (x1 * x1)) / (x2 - 2 * x1 + x0);
				x3 = func(x_temp);
				i++;
			}

			Console.WriteLine("Ответ: X = {0}\n Итераций пройдено: {1}\n\n", x_temp, i);
		}


		public static double x_n(double x)
		{
			return x - (F(x) * F(x)) / (F(x) - F(x - F(x)));
		}

		public static void method_stephenson(double a, double b, double e)
		{
			Console.WriteLine("\nМетод Стеффенсена:\n");
			double x = (a + b) / 2.0;

			int i = 1;
			while (Math.Abs(F(x))>e)
			{
				x = x_n(x);
				i++;
			}
			Console.WriteLine("Ответ: X = {0}\n Итераций пройдено: {1}\n\n", x, i);
		}
	}
}
