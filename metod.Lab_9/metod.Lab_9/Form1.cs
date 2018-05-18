using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metod.Lab_9
{
	public partial class Form1 : Form
	{


		public List<double> linear(Sums s, double[] X, double[] Y)
		{
			double[] coefficient = new double [2]; 
			double[,] sys_matrix = {{s.sum2(X), s.sum(X) },
									{s.sum(X), X.Length } };
			double[] solution_row = {s.sum_x_mult_y(X, Y), s.sum(Y) };

			alglib.rmatrixsolve(sys_matrix, 2, solution_row, out int t, out alglib.densesolverreport c, out coefficient);

			List<double> cof = new List<double>();
			cof.AddRange(coefficient);
			return cof;
		}

		static List<double> quadratic(Sums s, double[] X, double[] Y)
		{
			double[] coefficient = new double[3];
			double[,] sys_matrix = {{s.sum4(X), s.sum3(X),s.sum2(X) },
									{s.sum3(X),s.sum2(X), s.sum(X) },
									{s.sum2(X),s.sum(X),X.Length } };
			double[] solution_row = {s.sum_x_x_mult_y(X, Y), s.sum_x_mult_y(X,Y),s.sum(Y) };

			alglib.rmatrixsolve(sys_matrix, 3, solution_row, out int t, out alglib.densesolverreport c, out coefficient);
			List<double> cof = new List<double>();
			cof.AddRange(coefficient);
			return cof;
		}
		

		static List<double> exponential(Sums s,double[] X, double[] Y)
		{
			double[] coefficient = new double[2];
			double[,] sys_matrix = {{s.sum2(X), s.sum(X)},
									{s.sum(X),X.Length }};
			double[] solution_row = { s.sum_y_on_log_x(X, Y), s.sum_log_x(Y)};

			alglib.rmatrixsolve(sys_matrix, 2, solution_row, out int t, out alglib.densesolverreport c, out coefficient);
			coefficient[1] = Math.Exp(coefficient[1]);
			List<double> cof = new List<double>();
			cof.AddRange(coefficient);
			return cof;
		}


		static List<double> log(Sums s, double[] X, double[] Y)
		{
			double[] coefficient = new double[2];
			double[,] sys_matrix = {{s.sum_mult2_log_x(X), s.sum_log_x(X) },
									{s.sum_log_x(X), X.Length } };
			double[] solution_row = { s.sum_y_on_log_x(X, Y), s.sum(Y) };

			alglib.rmatrixsolve(sys_matrix, 2, solution_row, out int t, out alglib.densesolverreport c, out coefficient);
			List<double> cof = new List<double>();
			cof.AddRange(coefficient);
			return cof;
		}
		

		static List<double> hyperbolic(Sums s, double[] X, double[] Y)
		{
			double[] coefficient = new double[2];
			double[,] sys_matrix = {{s.sum_dev_1_on_x_x(X), s.sum_dev_1_on_x(X)},
									{s.sum_dev_1_on_x(X),X.Length }};
			double[] solution_row = { s.sum_dev_y_on_x(X, Y), s.sum(Y) };

			alglib.rmatrixsolve(sys_matrix, 2, solution_row, out int t, out alglib.densesolverreport c, out coefficient);
			List<double> cof = new List<double>();
			cof.AddRange(coefficient);
			return cof;
		}


		public Form1()
		{
			InitializeComponent();

			chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

			chart1.Series.Add("Линейная функция: y = ax + b");
			chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			chart1.Series.Add("Многочлен второй степени: y = a*x^2 + b*x + c");
			chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			chart1.Series.Add("Показательная функция: y = a*exp(b*e)");
			chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			chart1.Series.Add("Логарифмическая функция: y = a*ln(x) + b");
			chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			chart1.Series.Add("Гиперболическая функция: y = a/x + b");
			chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			double[] MasX = new double[] { 1.00, 1.64, 2.28, 2.91, 3.56, 4.19, 4.84, 5.48 };
			double[] MasY = new double[] { 0.28, 0.19, 0.15, 0.11, 0.09, 0.08, 0.07, 0.06 };

			chart1.Series[0].Points.DataBindXY(MasX, MasY);

			Sums s = new Sums();
			List<double> X = new List<double>();
			List<double> Y = new List<double>();


			
			List<double> coeffish = linear(s, MasX, MasY);

			for ( var i = 0 ; i < MasX.Length ; i++ )
			{
				X.Add(MasX[i]);
				Y.Add(coeffish[0] * MasX[i] + coeffish[1]);
			}
			chart1.Series[1].Points.DataBindXY(X, Y);
			X.Clear();
			Y.Clear();
			coeffish.Clear();



			coeffish = quadratic(s, MasX, MasY);

			for ( var i = 0 ; i < MasX.Length ; i++ )
			{
				X.Add(MasX[i]);
				Y.Add(coeffish[0] * ( MasX[i] * MasX[i] ) + coeffish[1] * MasX[i] + coeffish[2]);
			}
			chart1.Series[2].Points.DataBindXY(X, Y);
			X.Clear();
			Y.Clear();
			coeffish.Clear();


			coeffish = exponential(s, MasX, MasY);
			for ( var i = 0 ; i < MasX.Length ; i++ )
			{
				X.Add(MasX[i]);
				Y.Add(coeffish[0] * Math.Exp(coeffish[1] * MasX[i]));
			}
			//chart1.Series[3].Points.DataBindXY(X, Y);
			X.Clear();
			Y.Clear();
			coeffish.Clear();



			coeffish = log(s,  MasX, MasY);
			for ( var i = 0 ; i < MasX.Length ; i++ )
			{
				X.Add(MasX[i]);
				Y.Add(coeffish[0] * Math.Log(MasX[i]) + coeffish[1]);
			}
			chart1.Series[4].Points.DataBindXY(X, Y);
			X.Clear();
			Y.Clear();
			coeffish.Clear();


			coeffish = hyperbolic(s,MasX, MasY);
			for ( var i = 0 ; i < MasX.Length ; i++ )
			{
				X.Add(MasX[i]);
				Y.Add(coeffish[0] / MasX[i] + coeffish[1]);
			}
			chart1.Series[5].Points.DataBindXY(X, Y);
			
		}

	}
}
