using Infragistics.UltraChart.Resources.Appearance;
using System.Windows.Forms;

namespace WIZ.Control
{
    public partial class SPC_Chart : UserControl
    {
        public enum SeriesEnum { UCL, LCL, USL, LSL, CL, VALUE };

        public SPC_Chart()
        {
            InitializeComponent();
        }

        public void DoFind()
        {
            // 조회
            Init();


        }

        private void SetSPCLine()
        {
            chart.Series.Clear();

            NumericTimeSeries nUCL = new NumericTimeSeries();
            NumericTimeSeries nLCL = new NumericTimeSeries();
            NumericTimeSeries nUSL = new NumericTimeSeries();
            NumericTimeSeries nLSL = new NumericTimeSeries();
            NumericTimeSeries nCL = new NumericTimeSeries();

            chart.Series.Add(nUCL);
            chart.Series.Add(nLCL);
            chart.Series.Add(nUSL);
            chart.Series.Add(nLSL);
            chart.Series.Add(nCL);
        }

        public void Init()
        {
            SetSPCLine();

            for (int i = 0; i < chart.Series.Count; i++)
            {
            }
        }

        public object DataSource
        {
            get { return chart.DataSource; }
            set { chart.DataSource = value; }
        }
    }
}
