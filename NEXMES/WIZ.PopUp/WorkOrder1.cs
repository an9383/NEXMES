namespace WIZ.PopUp
{
    using System;
    using System.Collections;

    /// <summary>
    /// Summary description for XWM2200R1.
    /// </summary>
    public partial class WorkOrder1 : Telerik.Reporting.Report
    {
        public WorkOrder1()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private ArrayList SumList = new ArrayList();

        private void textBox76_ItemDataBound(object sender, EventArgs e) //group footer
        {
            int sumVal = Convert.ToInt32(((Telerik.Reporting.Processing.TextBox)sender).Value);
            SumList.Add(sumVal);
        }

        private void textBox46_ItemDataBound(object sender, EventArgs e) //report footer
        {
            int arraySum = 0;
            foreach (int i in SumList)
            {
                arraySum = arraySum + i;
            }

            ((Telerik.Reporting.Processing.TextBox)sender).Value = arraySum;

            SumList.Clear();
        }
    }
}
