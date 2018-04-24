using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metod.Lab_3
{
	class Program
	{

		static double func(double x)
		{
			return x * x * x - 12 * x + 6;
		}
		
		static void lobachevsky_method(double [] a)
		{

			Console.WriteLine("Метод Лобачевского\n");

			int step = 1;
			double fault = 0.0001;

			while (true)
			{
				double A0 = Math.Pow(a[0], 2);
				double A1 = Math.Pow(a[1], 2) - 2 * a[0] * a[2];
				double A2 = Math.Pow(a[2], 2) - 2 * a[1] * a[3];
				double A3 = Math.Pow(a[3], 2);


				double x1 = Math.Pow((A1 / A0), (1.0 / Math.Pow(2, step)));

				double x2 = Math.Pow((A2 / A1), (1.0 / Math.Pow(2, step)));

				double x3 = Math.Pow((A3 / A2), (1.0 / Math.Pow(2, step)));
				step++;

				if ((func(-x1) < fault || func(x1) < fault) && (func(-x2) < fault || func(x2) < fault) && (func(-x3) < fault || func(x3) < fault))
				{
					double[] X = { x1, x2, x3 };
					for (int i = 0; i < 3; i++)
					{
						if (func(X[i]) < fault)
							Console.WriteLine("{0} корень = {1}", i+1, X[i]);

						if (func(-X[i]) < fault)
							Console.WriteLine("{0} корень = {1}", i+1, -X[i]);
					}
					return;
				}

				a[0] = A0;
				a[1] = A1;
				a[2] = A2;
				a[3] =A3;
			}
		}

		static double min0(double[] arr)
		{
			double min = 0;
			for (var i = 0; i < arr.Length; i++)
			{
				if (arr[i] < 0 && arr[i] < min)
					min = arr[i];
			}
			return min; 
		}


		static void bernoulli_method(double [] a)
		{

			Console.WriteLine("Метод Бернулли:\n");
			
			double[] b = new double[a.Length];
			double[] n = new double[a.Length];
			
			 b[0] = Math.Abs(min0(a));
			 n[0] = 1 + (b[0] / Math.Abs(a[0]));
			


			double[] p1= new double[a.Length];
			for ( int i =0 ; i < a.Length ; i++ )
			{
				p1[i] = a[a.Length-i-1];
			}

			
			b[1] = Math.Abs(min0(p1));
			n[1] = 1 + Math.Sqrt(b[1]/Math.Abs(p1[0]));
			


			double[] p2 = new double[a.Length];
			for ( int i = 1 ; i < a.Length ; i++ )
			{
				p2[i-1] = Math.Pow(-1,(a.Length-1))* a[i-1];
			}
			p2[p2.Length - 1] = a[a.Length - 1];

			b[2] = Math.Abs(min0(p2));
			n[2]=1 + Math.Pow((b[2] / Math.Abs(p2[0])),(1.0/3.0));



			double[] p3 = new double[a.Length]; 
			for ( int i = 0 ; i < a.Length ; i++ )
			{
				p3[i] = -1* p2[p2.Length - i - 1];
			}

			b[3] = Math.Abs(min0(p3));
			n[3]= 1+ Math.Pow((b[3] / Math.Abs(p3[0])), ((1.0) / 4));


			Console.WriteLine("Положительный:  от "+1/n[1]+" до "+n[0]);
			Console.WriteLine("Отрицательный:  от " + -n[2]+ " до " + -1.0 / n[3]);
		}



		static void Main(string[] args)
		{

			double[] a = { 1, 0, -12, 6 };

			//bernoulli_method(a);
			lobachevsky_method(a);

			Console.ReadKey();
		}
	}
}
