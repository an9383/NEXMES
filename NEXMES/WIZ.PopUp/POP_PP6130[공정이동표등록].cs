#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : POP_PP6130
//   Form Name    : 공정재공 등록 및 발행 (팝업창)
//   Name Space   : WIZ.PopUp
//   Created Date : 2016.07.01
//   Made By      : 여강기K
//   Description  : 공정재공등록(PP6130) 시 (실적일자,등록수량) 입력 후 실적 등록 및 발행(미리보기)
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class POP_PP6130 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();
        Common _Common = new Common();

        string sPlantCode = string.Empty;
        string sOrderNo = string.Empty;
        #endregion


        #region < CONSTRUCTOR >

        public POP_PP6130()
        {
            InitializeComponent();
        }

        public POP_PP6130(string pPlantCode, string pOrderNo)
        {
            InitializeComponent();

            sPlantCode = pPlantCode;
            sOrderNo = pOrderNo;
        }
        #endregion

        #region < FORM LOAD AREA >
        private void POP_PP6130_Load(object sender, EventArgs e)
        {
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //공장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");

            cboPlantCode.Value = sPlantCode;
            txtOrderNo.Text = sOrderNo;

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PP6130_POP_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    txtOrderDate.Text = DBHelper.nvlString(rtnDtTemp.Rows[0]["ORDERDATE"]);
                    txtWorkCenterCode.Text = DBHelper.nvlString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]);
                    txtWorkCenterName.Text = DBHelper.nvlString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]);
                    txtItemCode.Text = DBHelper.nvlString(rtnDtTemp.Rows[0]["ITEMCODE"]);
                    txtItemName.Text = DBHelper.nvlString(rtnDtTemp.Rows[0]["ITEMNAME"]);

                    cboRecDate.Value = DBHelper.nvlString(rtnDtTemp.Rows[0]["ORDERDATE"]);
                    txtLotQty.Focus();
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    //조회할 데이터가 없습니다.
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion


        #region < EVENT AREA >
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtLotQty.Text == "" || txtLotQty.Text == "0")
            {
                MessageBox.Show("수량을 입력하세요.");
                return;
            }


            if (MessageBox.Show("신규 LOT 생성 하시겠습니까?", "LOT 생성", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string sLotNo = string.Empty;

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantcode = DBHelper.nvlString(cboPlantCode.Value);
                string sWorkCenterCode = DBHelper.nvlString(txtWorkCenterCode.Text);
                string sItemCode = DBHelper.nvlString(txtItemCode.Text);
                string sRecDate = DBHelper.nvlString(cboRecDate.Text);
                string sOrderNo = DBHelper.nvlString(txtOrderNo.Text);
                string sLotQty = DBHelper.nvlString(txtLotQty.Text);

                helper.ExecuteNoneQuery("USP_PP6130_POP_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_RECDATE", sRecDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_LOTQTY", sLotQty, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    sLotNo = helper.RSMSG;

                    rtnDtTemp = helper.FillTable("USP_PP6130_S2", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)     // 공장
                        , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)     // 작업장
                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)     // 품번
                        , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));   // LOTNO

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
                        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();
                        PP6130_R pp6130_r = new PP6130_R();

                        objectDataSource.DataSource = rtnDtTemp;
                        pp6130_r.DataSource = objectDataSource;
                        viewerInstance.ReportDocument = pp6130_r.Report;

                        if (chkPreview.Checked == true)
                        {
                            POP_ReportViewer rv = new POP_ReportViewer();
                            rv.reportViewer1.ReportSource = viewerInstance;
                            rv.reportViewer1.RefreshReport();

                            rv.ShowDialog();
                        }
                        else if (chkPrint.Checked == true)
                        {
                            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
                            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

                            reportProcessor.PrintController = standardPrintController;
                            printerSettings.Collate = true;

                            reportProcessor.PrintReport(viewerInstance, printerSettings);
                        }
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("LOT 등록 정보가 존재하지 않습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG, "신규 LOT 생성 실패");
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
            }
            finally
            {
                helper.Close();

                this.Close();
            }
        }

        private void txtLotQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                MessageBox.Show("숫자만 입력가능합니다.");
                e.Handled = true;
            }
        }

        private void chkPreview_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkPreview.Checked == true)
                chkPrint.Checked = false;
        }
        #endregion

    }
}


