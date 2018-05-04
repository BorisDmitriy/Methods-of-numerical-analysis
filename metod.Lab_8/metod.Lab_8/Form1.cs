using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metod.Lab_8
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

			chart1.Series.Add("Сплайн");
			chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

			chart1.Series.Add("Интрерполяция");
			chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline ;

			double[] MasX = new double[] { 0.55, 0.8, 0.93, 1.16, 1.31, 1.48, 1.78, 2.06, 2.56, 2.89 };
			double[] MasY = new double[] {0.44, 0.8, 1.63, 1.26, 1.07, 1.11, 0.83, 0.37, 0.21, 0.15};
			
			chart1.Series[0].Points.DataBindXY(MasX, MasY);
			chart1.Series[1].Points.DataBindXY(MasX, MasY);


			List<double> X = new List<double>();
			List<double> Y = new List<double>();

			spline s = new spline();

			s.BuildSpline(MasX, MasY, MasX.Length);
			for ( var x = MasX[0] ; x <= MasX[MasX.Length-1]; x += 0.1)
			{
				X.Add(x);
				Y.Add(s.Interpolate(x));
			}
			chart1.Series[2].Points.DataBindXY(X, Y);


			chart1.Series[0].Color = Color.Green;
			chart1.Series[0].BorderWidth = 7;
		}
	}
}
