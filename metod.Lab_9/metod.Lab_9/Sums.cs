using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metod.Lab_9
{
	public class Sums
	{
		public double sum(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += x[i];
			}

			return summal;
		}

		public double sum2(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += x[i] * x[i];
			}

			return summal;
		}

		public double sum3(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += x[i] * x[i] * x[i];
			}

			return summal;
		}

		public double sum4(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += x[i] * x[i] * x[i] * x[i];
			}
			return summal;
		}

		public double sum_x_mult_y(double[] x, double[] y)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += x[i] * y[i];
			}
			return summal;
		}

		public double sum_x_x_mult_y(double[] x, double[] y)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += x[i] * x[i] * y[i];
			}
			return summal;
		}

		public double sum_mult2_log_x(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += Math.Log(x[i]) * Math.Log(x[i]);
			}
			return summal;
		}

		public double sum_log_x(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += Math.Log(x[i]);
			}
			return summal;
		}


		public double sum_y_on_log_x(double[] x, double[] y)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal +=(y[i] * Math.Log(x[i]));
			}
			return summal;
		}

		public double sum_dev_1_on_x(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += 1.0 /x[i];
			}
			return summal;
		}

		public double sum_dev_1_on_x_x(double[] x)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += 1.0/ (x[i]*x[i]);
			}
			return summal;
		}

		public double sum_dev_y_on_x(double[] x, double[] y)
		{
			double summal = 0;
			for ( int i = 0 ; i < x.Length ; i++ )
			{
				summal += y[i]/ x[i] ;
			}
			return summal;
		}









	}
}
