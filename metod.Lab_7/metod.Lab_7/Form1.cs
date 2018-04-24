using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metod.Lab_7
{
	public partial class Form1 : Form
	{


		static double InterpolateLagrangePolynomial(double x, double[] MasX, double[] MasY, int size)
		{
			double lagrangePol = 0;

			for ( int i = 0 ; i < size ; i++ )
			{
				double basicsPol = 1;
				for ( int j = 0 ; j < size ; j++ )
				{
					if ( j != i )
					{
						basicsPol *= ( x - MasX[j] ) / ( MasX[i] - MasX[j] );
					}
				}
				lagrangePol += basicsPol * MasY[i];
			}

			return lagrangePol;
		}


		static double aitken_interpolation(double arg,double[] MasX,double[]  MasY)
		{

			List<List<double>> f = new List<List<double>>();

			for ( int i = 0 ; i <= MasY.Length ; i++ )
			{
				f.Add(new List<double>());
			}

			f[0].AddRange(MasY);


			for ( int st = 1 ; st <= MasY.Length ; st++ )
			{
				for ( int i = 1 ; i < f[st - 1].Count ; i++ )
				{
					double polynom = 1 / ( MasX[i + st - 1] - MasX[i - 1] ) *
						( ( f[st - 1][i - 1] * ( MasX[i + st - 1] - arg ) ) -
						( ( MasX[i - 1] - arg ) * f[st - 1][i] ) );


					f[st].Add(polynom);
				}
			}
			
			return f[MasY.Length-1][0];
		}






		public Form1()
		{
			InitializeComponent();

			chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			
			chart1.Series.Add("Интерполяция Лагранджа");
			chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			chart1.Series.Add("Узлы интерполяции");
			chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

			chart1.Series.Add("Cхема Эйткен");
			chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;


			double[] MasX = new double[] { 0.43, 0.48, 0.55, 0.62, 0.70, 0.75 };
			double[] MasY = new double[] { 1.63597, 1.73234, 1.87686, 2.03045, 2.22846, 2.35973 };
			double arg =0.608;

		

			List<double> y_forGraph = new List<double>();
			List<double> x_forGraph = new List<double>();

			for ( double j = 0 ; j <= 1 ; j += 0.05 )
			{
				x_forGraph.Add(j);
				y_forGraph.Add (InterpolateLagrangePolynomial(j, MasX, MasY, MasX.Length));
			}
			
			

			chart1.Series[1].Points.DataBindXY(x_forGraph, y_forGraph);
			chart1.Series[2].Points.DataBindXY(MasX, MasY);

			
			chart1.Series[3].Points.AddXY(arg, aitken_interpolation( arg, MasX, MasY));


			chart1.Series[2].Color = Color.Green;
			chart1.Series[2].BorderWidth = 7;
			chart1.Series[3].BorderWidth = 7;
		}
	}
}
