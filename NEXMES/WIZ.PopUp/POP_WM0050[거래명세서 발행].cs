using System;
using System.Data;
using System.Windows.Forms;
using Telerik.Reporting;

namespace WIZ.PopUp
{
    public partial class POP_WM0050 : WIZ.Forms.BasePopupForm
    {
        #region [ 선언자 ]
        DataTable rtnDtTemp = new DataTable();
        DataTable DtChange1 = new DataTable();
        WM0050_R[] WM0050 = new WM0050_R[10];

        WM0050_R WM0050_N;
        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        private string sPlantCode = string.Empty;
        private string sPICKINGNO = string.Empty;
        private string sTRSNSTNO = string.Empty;  //거래 명세서번호
        private string sPrePrintFlag = string.Empty;


        #endregion

        #region [ 생성자 ]

        //재발행시
        public POP_WM0050(DataTable dtTemp, string PrePrintFlag)
        {
            InitializeComponent();
            sPrePrintFlag = PrePrintFlag;

            //Create the report. You can also use a loop to create instances of multiple reports. 
            var reportBook = new ReportBook();
            var instanceReportSource = new Telerik.Reporting.InstanceReportSource();

            int a = 0;
            foreach (DataRow dr_Grid in dtTemp.Rows)
            {

                DBHelper helper = new DBHelper(false);

                //출력 조회SP SP 생성해야함.
                rtnDtTemp = helper.FillTable("USP_WM0050_R1", CommandType.StoredProcedure
                                , helper.CreateParameter("PlantCode", dr_Grid["PLANTCODE"], DbType.String, ParameterDirection.Input)             // 공장
                                , helper.CreateParameter("PICKINGNO", dr_Grid["PICKINGNO"], DbType.String, ParameterDirection.Input)               // 상차번호
                                 , helper.CreateParameter("TRSNSTNO", dr_Grid["TRSNSTNO"], DbType.String, ParameterDirection.Input)               // 거래명세서번호
                                , helper.CreateParameter("WorkerID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input) // 출력자
                                , helper.CreateParameter("PrePrintFlag", sPrePrintFlag, DbType.String, ParameterDirection.Input)          // 발행 재발행 여부
                            );



                //데이터 바인딩
                WM0050[a] = new WM0050_R();
                WM0050[a].DataSource = rtnDtTemp;

                //Add the report objects to the report book. 
                reportBook.Reports.Add(WM0050[a]);
                a++;

            }

            instanceReportSource.ReportDocument = reportBook;
            viewerInstance.ReportDocument = reportBook;
            ReportViewer.ReportSource = viewerInstance;

            ReportViewer.RefreshReport();

            //DBHelper helper = new DBHelper(false);

            //rtnDtTemp = helper.FillTable("USP_WM0050_R1", CommandType.StoredProcedure
            //                                            , helper.CreateParameter("PlantCode", dtTemp.Rows[0]["PLANTCODE"], DbType.String, ParameterDirection.Input)
            //                                            , helper.CreateParameter("PICKINGNO", dtTemp.Rows[0]["PICKINGNO"], DbType.String, ParameterDirection.Input)
            //                                            , helper.CreateParameter("TRSNSTNO", dtTemp.Rows[0]["TRSNSTNO"], DbType.String, ParameterDirection.Input)
            //                                            , helper.CreateParameter("WorkerID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
            //                                            , helper.CreateParameter("PrePrintFlag", sPrePrintFlag, DbType.String, ParameterDirection.Input));

            //WM0050_N = new WM0050_R();
            //WM0050_N.DataSource = rtnDtTemp;

            //reportBook.Reports.Add(WM0050_N);

            //instanceReportSource.ReportDocument = reportBook;
            //viewerInstance.ReportDocument = reportBook;
            //ReportViewer.ReportSource = instanceReportSource;

            //ReportViewer.RefreshReport();

        }

        public POP_WM0050(string PlantCode, string PICKINGNO, string TRSNSTNO, string PrePrintFlag)
        {
            InitializeComponent();

            sPlantCode = PlantCode;
            sPICKINGNO = PICKINGNO; // 상차번호
            sTRSNSTNO = TRSNSTNO; //출하 지시번호
            sPrePrintFlag = PrePrintFlag;

        }
        #endregion

        #region [ Form Load ]
        private void POP_WM0050_Load(object sender, EventArgs e)
        {
            txtPickingNo.Text = sTRSNSTNO;
            // txtPickingType.Text = sTraTypeName;
            //txtPrintingCount.Text = "3";

            //신규 발행
            if (sPrePrintFlag == "N")
            {
                lblPickingType.Visible = false;
                lblPickingNo.Visible = false;
                txtPickingNo.Visible = false;
                txtPickingType.Visible = false;
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
                rtnDtTemp = helper.FillTable("USP_WM0050_R1", CommandType.StoredProcedure
                                                , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 공장
                                                , helper.CreateParameter("PICKINGNO", sPICKINGNO, DbType.String, ParameterDirection.Input)            // 반출번호
                                                , helper.CreateParameter("WorkerID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input) // 출력자
                                                , helper.CreateParameter("TRSNSTNO", sTRSNSTNO, DbType.String, ParameterDirection.Input)               // 거래명세서번호
                                                , helper.CreateParameter("PrePrintFlag", sPrePrintFlag, DbType.String, ParameterDirection.Input)          // 발행 재발행 여부
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
                    WM0050_N = new WM0050_R();

                    objectDataSource.DataSource = rtnDtTemp;
                    WM0050_N.DataSource = objectDataSource;
                    viewerInstance.ReportDocument = WM0050_N.Report;

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

            Telerik.Reporting.IReportDocument myReport = new WM0050_R();
            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

            reportProcessor.PrintController = standardPrintController;
            printerSettings.Collate = true;

            //   reportProcessor.PrintReport(viewerInstance, printerSettings);

            //   출력매수 설정
            int iPrintingCount = Convert.ToInt16(txtPrintingCount.Text);
            try
            {
                for (int iCount = 0; iCount < iPrintingCount; iCount++)
                {
                    reportProcessor.PrintReport(viewerInstance, printerSettings);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("출력내역이 존재하지 않습니다.", "ERROR");
                return;
            }

            MessageBox.Show("출력완료 되었습니다.");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
