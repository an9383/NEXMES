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
using System.Drawing;
using System.Windows.Forms;

using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
using System.Text;
using System.Net;
#endregion

namespace WIZ.PL
{
    public partial class PL0100_POP2 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew               = false;
        UltraGridUtil _GridUtil         = new UltraGridUtil();
        BizTextBoxManager btbManager    = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;

        Common    _Common   = new Common();
        DataTable rtnDtTemp = new DataTable();
        DataTable dt        = new DataTable();
        DataSet   DSGrid1   = new DataSet();
        DataTable dtBARCORE = new DataTable();

        /// <summary>
        /// 타 Form 접근용
        /// </summary>
        public Control.Grid trGrid;
        public Control.Grid crGrid;

        #endregion

        #region < CONSTRUCTOR >
        public PL0100_POP2()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >

        public delegate void ChildFormSendDataHandler(string message);
        public event ChildFormSendDataHandler ChildFormEvent;
        private void OD0000_POP_Load(object sender, EventArgs e)
        {
            txtTYPE.Text = "안전재고";
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
                    PL0100_POP_POP1 mbp = new PL0100_POP_POP1(txtCUSTCODE.Text);
                    if (DialogResult.OK == mbp.ShowDialog())
                    {
                        txtPARTNAME.Text = mbp.CheckItem;
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
                rtnDtTemp = helper.FillTable("USP_OD0000_S5", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_SEARCHDATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                string cnt = Convert.ToString(rtnDtTemp.Rows[0]["cnt"]);

                //저장, 수정
                rtnDtTemp = helper.FillTable("USP_PL0100_POP2_OD0000_SAVE", CommandType.StoredProcedure

                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER",      LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_TIME",      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_OD_LotNo",     "OD" + DateTime.Today.ToString("yyyyMMdd") + "M" + cnt, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_Vend",      txtCUSTCODE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_OrderDate", dateTimePicker2.Value.ToString("yyyyMMdd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_FixedDate", dateTimePicker3.Value.ToString("yyyyMMdd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_PartName",  txtPARTNAME.Text, DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_OD_OrderQTY",  txtCNT.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_UnitCost",  txtCOST.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_Money",     txtTOTALCOST.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_Residual",  0, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_HRS",       0, DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_OD_Amount",    0, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_PoNo",      "DH_" + DateTime.Now.ToString("yyyyMMddHHmmss"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_Type",      txtTYPE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_ETC1",      "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_OD_ETC3",      txtETC.Text, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }

                helper.Commit();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }

        }
    }
}
