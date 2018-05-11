using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metod.Lab_8
{
	class ParabSpline
	{
		// Вычисление значения интерполированной функции в произвольной точке
		public double build_spline_and_interpolate(double x, double[] arraX, double[] arrayY)
		{
			List<double> a = new List<double>();
			List<double> z = new List<double>();
			a.AddRange(arrayY);
			for ( int i = 0 ; i < arrayY.Length-1 ; i++ )
			{
				z.Add(2 * ( arrayY[i + 1] - arrayY[i] ) /
						  ( arraX[i + 1] - arraX[i] ));
			}
			List<double> b = new List<double>();
			b.Add( a[0]);

			for ( int i = 1 ; i < arrayY.Length ; i++ )
			{
				b.Add( z[i - 1] - b[i - 1]);
			}

			List<double> c = new List<double>();

			for ( int i = 0 ; i < arrayY.Length-1 ; i++ )
			{
				c.Add(( b[i + 1] - b[i] ) /
					   ( 2 * ( arraX[i + 1] - arraX[i] ) ));
			}
			
			//производим бинарный поиск нужного эл-та массива
			int j = 0;
			int id = arraX.Length - 1;
			while ( j + 1 < id )
			{
				int k = j + ( id - j ) / 2;
				if ( x <= arraX[k] )
				{
					id = k;
				}
				else
				{
					j = k;
				}
			}

			if ( x < arraX[id] )
				return a[id - 1] + ( x - arraX[id - 1] ) * b[id - 1] + c[id - 1] * ( x - arraX[id - 1] ) * ( x - arraX[id - 1] );
			else
				return a[id];
			
		}
	}
}

