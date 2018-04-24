using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chart2DLib;


namespace metod.Lab_6
{
	public partial class Form1 : Form
	{
		
			static public double Newton(double x, int n, double[] MasX, double[] MasY, double step)
			{
				double[,] mas = new double[n + 2, n + 1];
				for ( int i = 0 ; i < 2 ; i++ )
				{
					for ( int j = 0 ; j < n + 1 ; j++ )
					{
						if ( i == 0 )
							mas[i, j] = MasX[j];
						else if ( i == 1 )
							mas[i, j] = MasY[j];
					}
				}
				int m = n;
				for ( int i = 2 ; i < n + 2 ; i++ )
				{
					for ( int j = 0 ; j < m ; j++ )
					{
						mas[i, j] = mas[i - 1, j + 1] - mas[i - 1, j];
					}
					m--;
				}

				double[] dy0 = new double[n + 1];

				for ( int i = 0 ; i < n + 1 ; i++ )
				{
					dy0[i] = mas[i + 1, 0];
				}

				double res = dy0[0];
				double[] xn = new double[n];
				xn[0] = x - mas[0, 0];

				for ( int i = 1 ; i < n ; i++ )
				{
					double ans = xn[i - 1] * ( x - mas[0, i] );
					xn[i] = ans;
					ans = 0;
				}

				int m1 = n + 1;
				int fact = 1;
				for ( int i = 1 ; i < m1 ; i++ )
				{
					fact = fact * i;
					res = res + ( dy0[i] * xn[i - 1] ) / ( fact * Math.Pow(step, i) );
				}

				return res;
			
			}

		static public double inverse_Newton(double x, int n, double[] MasX, double[] MasY, double step)
		{
			double[,] mas = new double[n + 2, n + 1];
			for ( int i = 0 ; i < 2 ; i++ )
			{
				for ( int j = 0 ; j < n + 1 ; j++ )
				{
					if ( i == 0 )
						mas[i, j] = MasX[j];
					else if ( i == 1 )
						mas[i, j] = MasY[j];
				}
			}
			int m = n;
			for ( int i = 2 ; i < n + 2 ; i++ )
			{
				for ( int j = 0 ; j < m ; j++ )
				{
					mas[i, j] = mas[i - 1, j + 1] - mas[i - 1, j];
				}
				m--;
			}

			double[] dy = new double[n + 1];

			for ( int i = 0 ; i < n + 1 ; i++ )
			{
				dy[i] = mas[i + 1, 0];
			}

			double res = dy[n];
			double[] xn = new double[n];
			xn[0] = x - mas[0, 0];

			for ( int i = 1 ; i < n ; i++ )
			{
				double ans = xn[i - 1] * ( x + mas[n, i] );
				xn[i] = ans;
				ans = 0;
			}

			int m1 = n + 1;
			int fact = 1;
			for ( int i = 1, j=n ; i < m1 ; i++,j-- )
			{
				fact = fact * i;
				res = res + ( dy[n] * xn[i - 1] ) / ( fact * Math.Pow(step, i) );
			}

			return res;

		}


		public Form1()
		{
			InitializeComponent();
			
			chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

			chart1.Series.Add("Прямой интерполяция");
			chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			chart1.Series.Add("Обратная интерполяция");
			chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;



			double step = 0.005;

			double[] MasX = new double[] { 0.101, 0.106, 0.111, 0.116, 0.121, 0.126, 0.131, 0.136, 0.141, 0.146 };
			double[] MasY = new double[] { 1.26183, 1.27644, 1.29122, 1.30617, 1.32130, 1.33660, 1.35207, 1.36773, 1.38357, 1.39959 };
			double[] arg = new double[] { 0.1156, 0.1457, 0.1142, 0.1452, 0.1063, 0.1369 };


			double[] res = new double[arg.Length];
			for ( int i = 0 ; i < arg.Length ; i++ )
			{
				res[i] = Newton(arg[i], MasX.Length - 1, MasX, MasY, step);
				Console.WriteLine("res ={0}", res[i]);
			}


			List<double> y_forGraph = new List<double>();
			List<double> x_forGraph = new List<double>();

			for ( double j = 0 ; j <= 1 ; j+=0.05 )
			{
				x_forGraph.Add (j);
				y_forGraph.Add( Newton(j, MasX.Length - 1, MasX, MasY, step));
			}
		
			chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;


			chart1.Series[0].Points.DataBindXY(arg, res);
			chart1.Series[1].Points.DataBindXY(x_forGraph, y_forGraph);

			x_forGraph.Clear();
			y_forGraph.Clear();

			for ( double j = 0 ; j <= 1 ; j += 0.05 )
			{
				x_forGraph.Add(j);
				y_forGraph.Add(inverse_Newton(j, MasX.Length - 1, MasX, MasY, step));
			}

			chart1.Series[2].Points.DataBindXY(x_forGraph, y_forGraph);


			chart1.Series[0].Color = Color.Green;

			chart1.Series[0].BorderWidth = 7;



		}

		private void chart1_Click(object sender, EventArgs e)
		{

		}
	}
}
