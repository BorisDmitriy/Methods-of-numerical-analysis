using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2st_system
{
	public class System
	{
		public double f1(double x1, double x2)
		{
			return Math.Sin(x1+ x2) - 1.2*x1 - 0.2;
		}

		public double f2(double x1, double x2)
		{
			return x1 * x1 + x2 * x2 - 1;
		}

		public double df1dx1(double x1, double x2)
		{
			return Math.Cos(x1 + x2) - 1.2;
		}

		public double df1dx2(double x1, double x2)
		{
			return Math.Cos(x1 + x2);
		}

		public double df2dx1(double x1, double x2)
		{
			return 2*x1;
		}

		public double df2dx2(double x1, double x2)
		{
			return 2*x2;
		}
	}





	class Program
	{

		static double iter_function_x1(System system, double x1, double x2, double[] c)
		{
			return x1 + c[0] * system.f1(x1, x2) + c[1] * system.f2(x1, x2);
		}

		static double iter_function_x2(System system, double x1, double x2, double[] c)
		{
			return x2 + c[0] * system.f1(x1, x2) + c[1] * system.f2(x1, x2);
		}

		static void iteration_method(System system, double clone_x1, double clone_x2, double fault = 0.001)
		{
			double x1 = clone_x1;
			double x2 = clone_x2;

			double[,] a = { { system.df1dx1(x1, x2), system.df2dx1(x1, x2) }, { system.df2dx1(x1, x2), system.df2dx2(x1, x2) } };

			double[] solve_for_x = { -1, 0 };
			
			alglib.rmatrixsolve(a, 2, solve_for_x, out int t, out alglib.densesolverreport s, out double[] c1);

			double[] solve_for_y = { 0, -1 };
			alglib.rmatrixsolve(a, 2, solve_for_y, out int t1, out alglib.densesolverreport s1, out double[] c2);
			


			double x1_temp, x2_temp;

			while ( ( Math.Abs(system.f1(x1, x2)) > fault ) && ( Math.Abs(system.f2(x1, x2)) > fault ) )
			{
				x1_temp = x1;
				x2_temp = x2;

				x1 = iter_function_x1(system, x1_temp, x2_temp, c1);
				x2 = iter_function_x2(system, x1_temp, x2_temp, c2);

			}

			Console.WriteLine("Первый корень:" + x1);
			Console.WriteLine("Второй корень:" + x2);
		}








		static void newton_method(System system, double clone_x1, double clone_x2, double fault = 0.001)
		{
			double x1 = clone_x1;
			double x2 = clone_x2;

			while ( ( Math.Abs(system.f1(x1, x2)) > fault ) && ( Math.Abs(system.f2(x1, x2)) > fault ) )
			{

				x1 = x1 - ( system.f1(x1, x2) * system.df2dx2(x1, x2) - system.df1dx2(x1, x2) * system.f2(x1, x2) ) /
						  ( system.df1dx1(x1, x2) * system.df2dx2(x1, x2) - system.df2dx1(x1, x2) * system.df1dx2(x1, x2) );


				x2 = x2 - ( system.df1dx1(x1, x2) * system.f2(x1, x2) - system.f1(x1, x2) * system.df2dx1(x1, x2) ) /
						  ( system.df1dx1(x1, x2) * system.df2dx2(x1, x2) - system.df2dx1(x1, x2) * system.df1dx2(x1, x2) );
			}

			Console.WriteLine("Первый корень:" + x1);
			Console.WriteLine("Второй корень:" + x2);
		}

		static void Main(string[] args)
		{
			System system = new System();
			

			Console.Write("           Вторая система         ");

			Console.Write("\nВведите значение x1 приближённого к 1-ому корню: ");
			double x1 = double.Parse(Console.ReadLine());

			Console.Write("Введите значение x2 приближённого ко 2-ому корню: ");
			double x2 = double.Parse(Console.ReadLine());


			Console.WriteLine("\n\nМетод итерации:");
			iteration_method(system, x1, x2);


			Console.WriteLine("\n\nМетод Ньютона:");
			newton_method(system, x1, x2);


			Console.ReadKey();
		}


	}
}

