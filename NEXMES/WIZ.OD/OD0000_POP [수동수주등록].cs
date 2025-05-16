#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : 수주 현황
//   Name Space   : WIZ.BM
//   Created Date : 2019-11-11
//   Made By      : 기술연구소 최문준
//   Description  : 수주 현황 정보를 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;

using WIZ.PopUp;
#endregion

namespace WIZ.OD
{
    public partial class OD0000_POP : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet DSGrid1 = new DataSet();
        DataTable dtBARCORE = new DataTable();

        /// <summary>
        /// 타 Form 접근용
        /// </summary>
        public Control.Grid trGrid;
        public Control.Grid crGrid;

        #endregion

        #region < CONSTRUCTOR >
        public OD0000_POP()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >

        public delegate void ChildFormSendDataHandler(string message);
        public event ChildFormSendDataHandler ChildFormEvent;
        private void OD0000_POP_Load(object sender, EventArgs e)
        {
            cbo_ODTYPE.Items.Add("수주요청");
            cbo_ODTYPE.Items.Add("안전재고");
            cbo_ODTYPE.Text = "안전재고";

            btbManager.PopUpAdd(txtCUSTCODE, txtCUSTNAME, "BM0030", new object[] { 10, "", "", "" });
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >
        public void SetMoldInfo(DataTable DTinfo)
        {

        }
        #endregion

        #region < METHOD AREA >

        #endregion

        private void BtnProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCUSTCODE.Text == "")
                {
                    this.ShowDialog("고객사를 선택해주세요.", Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    OD0000_POP_POP1 mbp = new OD0000_POP_POP1(txtCUSTCODE.Text);
                    if (DialogResult.OK == mbp.ShowDialog())
                    {
                        txtITEMCODE.Text = mbp.cITEMCODE;
                        txtITEMNAME.Text = mbp.cITEMNAME;
                    }
                }
            }

            catch
            {

            }
        }

        private void txtCOST_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            int.TryParse(txtCOST.Text, out a);
            int.TryParse(txtCNT.Text, out b);
            int cal = a * b;
            txtTOTALCOST.Text = cal.ToString();
        }

        private void txtCNT_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            int.TryParse(txtCOST.Text, out a);
            int.TryParse(txtCNT.Text, out b);
            int cal = a * b;
            txtTOTALCOST.Text = cal.ToString();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (Convert.ToInt32(txtCNT.Text) == 0)
                {
                    if (this.ShowDialog("수량이 0으로 되어있습니다. 계속 진행하시겠습니까?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                    {
                        int iRow = trGrid.InsertRow();
                        rtnDtTemp = helper.FillTable("USP_OD0000_S5", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_SEARCHDATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                        string cnt = Convert.ToString(rtnDtTemp.Rows[0]["cnt"]);

                        if (cbo_ODTYPE.Text == "수주요청")
                        {
                            trGrid.Rows[iRow].Cells["OD_LotNo"].Value = "OD" + DateTime.Today.ToString("yyyyMMdd") + "A" + cnt;

                            trGrid.Rows[iRow].Cells["CHK"].Value = "";
                            trGrid.Rows[iRow].Cells["CUSTCODE"].Value = txtCUSTCODE.Text;
                            trGrid.Rows[iRow].Cells["CUSTNAME"].Value = txtCUSTNAME.Text;
                            trGrid.Rows[iRow].Cells["OD_OrderDate"].Value = dateTimePicker2.Value.ToString("yyyyMMdd");
                            trGrid.Rows[iRow].Cells["OD_FixedDate"].Value = dateTimePicker3.Value.ToString("yyyyMMdd");
                            trGrid.Rows[iRow].Cells["OD_PartName"].Value = txtITEMNAME.Text;
                            trGrid.Rows[iRow].Cells["OD_OrderQTY"].Value = txtCNT.Text;
                            trGrid.Rows[iRow].Cells["OD_UnitCost"].Value = txtCOST.Text;
                            trGrid.Rows[iRow].Cells["OD_Money"].Value = txtTOTALCOST.Text;
                            trGrid.Rows[iRow].Cells["OD_Residual"].Value = txtCNT.Text;
                            trGrid.Rows[iRow].Cells["OD_HRS"].Value = 0;
                            trGrid.Rows[iRow].Cells["OD_Amount"].Value = 0;
                            trGrid.Rows[iRow].Cells["OD_PoNo"].Value = "DH_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            trGrid.Rows[iRow].Cells["OD_Type"].Value = cbo_ODTYPE.Text;
                            trGrid.Rows[iRow].Cells["OD_ETC3"].Value = txtETC.Text;
                        }
                        else
                        {
                            trGrid.Rows[iRow].Cells["OD_LotNo"].Value = "OD" + DateTime.Today.ToString("yyyyMMdd") + "M" + cnt;

                            trGrid.Rows[iRow].Cells["CHK"].Value = "";
                            trGrid.Rows[iRow].Cells["CUSTCODE"].Value = txtCUSTCODE.Text;
                            trGrid.Rows[iRow].Cells["CUSTNAME"].Value = txtCUSTNAME.Text;
                            trGrid.Rows[iRow].Cells["OD_OrderDate"].Value = dateTimePicker2.Value.ToString("yyyyMMdd");
                            trGrid.Rows[iRow].Cells["OD_FixedDate"].Value = dateTimePicker3.Value.ToString("yyyyMMdd");
                            trGrid.Rows[iRow].Cells["OD_PartName"].Value = txtITEMNAME.Text;
                            trGrid.Rows[iRow].Cells["OD_OrderQTY"].Value = txtCNT.Text;
                            trGrid.Rows[iRow].Cells["OD_UnitCost"].Value = txtCOST.Text;
                            trGrid.Rows[iRow].Cells["OD_Money"].Value = txtTOTALCOST.Text;
                            trGrid.Rows[iRow].Cells["OD_Residual"].Value = txtCNT.Text;
                            trGrid.Rows[iRow].Cells["OD_HRS"].Value = 0;
                            trGrid.Rows[iRow].Cells["OD_Amount"].Value = 0;
                            trGrid.Rows[iRow].Cells["OD_PoNo"].Value = "DH_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            trGrid.Rows[iRow].Cells["OD_Type"].Value = cbo_ODTYPE.Text;
                            trGrid.Rows[iRow].Cells["OD_ETC3"].Value = txtETC.Text;
                        }
                    }
                }
                else
                {
                    int iRow = trGrid.InsertRow();
                    rtnDtTemp = helper.FillTable("USP_OD0000_S5", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_SEARCHDATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                    string cnt = Convert.ToString(rtnDtTemp.Rows[0]["cnt"]);

                    if (cbo_ODTYPE.Text == "수주요청")
                    {
                        trGrid.Rows[iRow].Cells["OD_LotNo"].Value = "OD" + DateTime.Today.ToString("yyyyMMdd") + "A" + cnt;

                        trGrid.Rows[iRow].Cells["CHK"].Value = "";
                        trGrid.Rows[iRow].Cells["CUSTCODE"].Value = txtCUSTCODE.Text;
                        trGrid.Rows[iRow].Cells["CUSTNAME"].Value = txtCUSTNAME.Text;
                        trGrid.Rows[iRow].Cells["OD_OrderDate"].Value = dateTimePicker2.Value.ToString("yyyyMMdd");
                        trGrid.Rows[iRow].Cells["OD_FixedDate"].Value = dateTimePicker3.Value.ToString("yyyyMMdd");
                        trGrid.Rows[iRow].Cells["OD_PartName"].Value = txtITEMNAME.Text;
                        trGrid.Rows[iRow].Cells["OD_OrderQTY"].Value = txtCNT.Text;
                        trGrid.Rows[iRow].Cells["OD_UnitCost"].Value = txtCOST.Text;
                        trGrid.Rows[iRow].Cells["OD_Money"].Value = txtTOTALCOST.Text;
                        trGrid.Rows[iRow].Cells["OD_Residual"].Value = txtCNT.Text;
                        trGrid.Rows[iRow].Cells["OD_HRS"].Value = 0;
                        trGrid.Rows[iRow].Cells["OD_Amount"].Value = 0;
                        trGrid.Rows[iRow].Cells["OD_PoNo"].Value = "DH_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        trGrid.Rows[iRow].Cells["OD_Type"].Value = cbo_ODTYPE.Text;
                        trGrid.Rows[iRow].Cells["OD_ETC3"].Value = txtETC.Text;
                    }
                    else
                    {
                        trGrid.Rows[iRow].Cells["OD_LotNo"].Value = "OD" + DateTime.Today.ToString("yyyyMMdd") + "M" + cnt;

                        trGrid.Rows[iRow].Cells["CHK"].Value = "";
                        trGrid.Rows[iRow].Cells["CUSTCODE"].Value = txtCUSTCODE.Text;
                        trGrid.Rows[iRow].Cells["CUSTNAME"].Value = txtCUSTNAME.Text;
                        trGrid.Rows[iRow].Cells["OD_OrderDate"].Value = dateTimePicker2.Value.ToString("yyyyMMdd");
                        trGrid.Rows[iRow].Cells["OD_FixedDate"].Value = dateTimePicker3.Value.ToString("yyyyMMdd");
                        trGrid.Rows[iRow].Cells["OD_PartName"].Value = txtITEMNAME.Text;
                        trGrid.Rows[iRow].Cells["OD_OrderQTY"].Value = txtCNT.Text;
                        trGrid.Rows[iRow].Cells["OD_UnitCost"].Value = txtCOST.Text;
                        trGrid.Rows[iRow].Cells["OD_Money"].Value = txtTOTALCOST.Text;
                        trGrid.Rows[iRow].Cells["OD_Residual"].Value = txtCNT.Text;
                        trGrid.Rows[iRow].Cells["OD_HRS"].Value = 0;
                        trGrid.Rows[iRow].Cells["OD_Amount"].Value = 0;
                        trGrid.Rows[iRow].Cells["OD_PoNo"].Value = "DH_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        trGrid.Rows[iRow].Cells["OD_Type"].Value = cbo_ODTYPE.Text;
                        trGrid.Rows[iRow].Cells["OD_ETC3"].Value = txtETC.Text;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
