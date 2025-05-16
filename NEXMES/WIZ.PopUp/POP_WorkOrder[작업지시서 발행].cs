using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Telerik.Reporting;

namespace WIZ.PopUp
{
    public partial class POP_WorkOrder : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        DataTable rtnDtTemp = new DataTable();

        WorkOrder1 WorkOrder_Report = new WorkOrder1();

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string sPlantCode = string.Empty;
        private string sOrderNo = string.Empty;

        #endregion

        #region [ 생성자 ]

        public POP_WorkOrder(string plantCode, string orderNo)
        {
            InitializeComponent();

            sPlantCode = plantCode;
            sOrderNo = orderNo;
            //Create the report. You can also use a loop to create instances of multiple reports. 
            var reportBook = new ReportBook();
            var instanceReportSource = new Telerik.Reporting.InstanceReportSource();

            DBHelper helper = new DBHelper(false);

            rtnDtTemp = helper.FillTable("USP_WorkOrder1_R1", CommandType.StoredProcedure
                                , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("WORKUSER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            );

            WorkOrder_Report = new WorkOrder1();
            WorkOrder_Report.DataSource = rtnDtTemp;
            //Add the report objects to the report book. 

            reportBook.Reports.Add(WorkOrder_Report);

            instanceReportSource.ReportDocument = reportBook;
            viewerInstance.ReportDocument = reportBook;
            ReportViewer.ReportSource = instanceReportSource;

            ReportViewer.RefreshReport();
        }

        #endregion

        #region [ Form Load ]
        private void POP_WorkerOrder_Load(object sender, EventArgs e)
        {
            txtPrintingCount.Text = "1";
        }

        #endregion

        #region [ Event Area ]
        private void btnPrint_Click(object sender, EventArgs e)
        {

            Telerik.Reporting.IReportDocument myReport = new WorkOrder1();
            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

            reportProcessor.PrintController = standardPrintController;
            printerSettings.Collate = true;

            //출력매수 설정
            int iPrintingCount = Convert.ToInt16(txtPrintingCount.Text.Trim());
            try
            {
                for (int iCount = 0; iCount < iPrintingCount; iCount++)
                {
                    reportProcessor.PrintReport(viewerInstance, printerSettings);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("출력내역이 존재하지 않습니다.", "ERROR");
                return;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
