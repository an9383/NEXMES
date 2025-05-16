using System;
using System.Data;
using Telerik.Reporting;

namespace WIZ.PopUp
{
    public partial class POP_WM0040 : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        DataTable rtnDtTemp = new DataTable();
        DataTable DtChange1 = new DataTable();
        WM0040_R[] WM0040 = new WM0040_R[10];

        WM0040_R WM0040_N;
        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        private string sPlantCode = string.Empty;
        private string sPickingOrderNO = string.Empty;
        private string sOrderType = string.Empty;

        private string sTraTypeName = string.Empty;
        private string sPrePrintFlag = string.Empty;
        private string sPlanDate = string.Empty;
        private string sGubun = string.Empty;




        #endregion

        #region [ 생성자 ]

        //재발행시
        public POP_WM0040(DataTable dtTemp, string PrePrintFlag)
        {
            InitializeComponent();
            sPrePrintFlag = PrePrintFlag;

            sPlantCode = CModule.GetAppSetting("Site", "10");
            //Create the report. You can also use a loop to create instances of multiple reports. 
            var reportBook = new ReportBook();
            var instanceReportSource = new Telerik.Reporting.InstanceReportSource();

            int a = 0;
            foreach (DataRow dr_Grid in dtTemp.Rows)
            {

                DBHelper helper = new DBHelper(false);

                //출력 조회SP

                rtnDtTemp = helper.FillTable("USP_WM0040_R1", CommandType.StoredProcedure
                                , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 공장
                                , helper.CreateParameter("PickingOrderNO", dr_Grid["TRANO"], DbType.String, ParameterDirection.Input)       // 반출번호
                                , helper.CreateParameter("WorkerID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input) // 출력자
                                , helper.CreateParameter("PrePrintFlag", sPrePrintFlag, DbType.String, ParameterDirection.Input)          // 발행 재발행 여부
                                , helper.CreateParameter("PlanDate", sPlanDate, DbType.String, ParameterDirection.Input)              // 출하지시일
                                , helper.CreateParameter("Gubun", sGubun, DbType.String, ParameterDirection.Input)                 // 계획납품, AS 구분
                            );

                //데이터 바인딩
                WM0040[a] = new WM0040_R();
                WM0040[a].DataSource = rtnDtTemp;

                //Add the report objects to the report book. 
                reportBook.Reports.Add(WM0040[a]);
                a++;

            }

            instanceReportSource.ReportDocument = reportBook;
            viewerInstance.ReportDocument = reportBook;
            ReportViewer.ReportSource = instanceReportSource;

            ReportViewer.RefreshReport();
        }

        public POP_WM0040(string PlantCode, string PickingOrderNO, string OrderType, string PrePrintFlag, string PlanDate)
        {
            InitializeComponent();

            sPlantCode = PlantCode;
            sPickingOrderNO = PickingOrderNO;
            sOrderType = OrderType;
            sPrePrintFlag = PrePrintFlag;
            sPlanDate = PlanDate;

        }

        public POP_WM0040(string PlantCode, string PickingOrderNO, string OrderType, string PrePrintFlag, string PlanDate, string Gubun)
        {
            InitializeComponent();

            sPlantCode = PlantCode;
            sPickingOrderNO = PickingOrderNO;
            sOrderType = OrderType;
            sPrePrintFlag = PrePrintFlag;
            sPlanDate = PlanDate;
            sGubun = Gubun;
        }
        #endregion

        #region [ Form Load ]
        private void POP_WM0040_Load(object sender, EventArgs e)
        {
            txtPickingNo.Text = sPickingOrderNO;
            txtPickingType.Text = sOrderType;
            //txtPrintingCount.Text = "3";

            //신규 발행
            if (sPrePrintFlag == "N")
            {
                if (!Inquire())     // 출력 내용이없는 경우 종료
                    this.Close();
            }
            //재 발행
            else
            {
                lblPickingType.Visible = false;
                lblPickingNo.Visible = false;
                txtPickingNo.Visible = false;
                txtPickingType.Visible = false;

            }
        }

        #endregion

        #region [ User Method Area ]
        private Boolean Inquire()
        {
            bool flgInquire_Succeed = true;

            DateTime sNow = DateTime.Now;
            string sDate = string.Empty;
            sDate = sNow.ToString("yyyy") + "년 " + sNow.ToString("MM") + "월 " + sNow.ToString("dd") + "일 " + string.Format("{0:t}", sNow);

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_WM0040_R1", CommandType.StoredProcedure
                                                , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 공장
                                                , helper.CreateParameter("PickingOrderNO", sPickingOrderNO, DbType.String, ParameterDirection.Input)        // 반출번호
                                                , helper.CreateParameter("WorkerID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input) // 출력자
                                                , helper.CreateParameter("PrePrintFlag", sPrePrintFlag, DbType.String, ParameterDirection.Input)          // 발행 재발행 여부
                                                , helper.CreateParameter("PlanDate", sPlanDate, DbType.String, ParameterDirection.Input)              // 출하지시일
                                                , helper.CreateParameter("Gubun", sGubun, DbType.String, ParameterDirection.Input)                 // 계획납품, AS 구분
                                            );
                if (helper.RSCODE != "S")
                {
                    SException ex = new SException(helper.RSCODE, null);
                    throw ex;
                }

                if (rtnDtTemp.Rows.Count < 1)
                {
                    this.ClosePrgFormNew();
                    SException ex = new SException("조회할 데이터가 없습니다.", null); // 조회할 데이터가 존재하지 않습니다.
                }
                else
                {
                    //원본
                    WM0040_N = new WM0040_R();

                    objectDataSource.DataSource = rtnDtTemp;
                    WM0040_N.DataSource = objectDataSource;
                    viewerInstance.ReportDocument = WM0040_N.Report;

                    //viewerInstance.Parameters.Add("TraPlanDate", sTraPlanDate);

                    ReportViewer.ReportSource = viewerInstance;
                    ReportViewer.RefreshReport();
                }
            }
            catch (SException ex)
            {
                flgInquire_Succeed = false;
                this.ClosePrgFormNew();
                this.ShowErrorMessage(ex);
            }
            catch (Exception ex)
            {
                flgInquire_Succeed = false;
                throw ex;
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

            if (flgInquire_Succeed == true)
                return true;
            else
                return false;
        }

        #endregion

        #region [ Event Area ]
        private void btnPrint_Click(object sender, EventArgs e)
        {

            Telerik.Reporting.IReportDocument myReport = new WM0040_R();
            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

            reportProcessor.PrintController = standardPrintController;
            printerSettings.Collate = true;

            reportProcessor.PrintReport(viewerInstance, printerSettings);

            //출력매수 설정
            //int iPrintingCount = Convert.ToInt16(txtPrintingCount.Text.Trim());
            //try
            //{
            //    for (int iCount = 0; iCount < iPrintingCount; iCount++)
            //    {
            //        reportProcessor.PrintReport(viewerInstance, printerSettings);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("출력내역이 존재하지 않습니다.", "ERROR");
            //    return;
            //}
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
