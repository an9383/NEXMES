#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0005
//   Form Name    : 코어마스터
//   Name Space   : WIZ.MD
//   Created Date : 2020-10-13
//   Made By      : 최문석
//   Description  : 코어관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MD
{
    public partial class MD0005 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataSet DSGrid1 = new DataSet();
        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();
        DataTable dtGrid3 = new DataTable();

        string CORECODE = "";
        /// <summary>
        /// N : DoNew / S : Normal
        /// </summary>
        string ModeStatus = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0005()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0005_Load(object sender, EventArgs e)
        {
            GridInitialize();
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_Code", "코어코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_Vend", "업체명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_CoreName", "코어명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_PartName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_ChaSu", "차수", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.InitColumnUltraGrid(grid1, "Core_Area", "보관함 NO.", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_Cost", "단가", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_Count", "재고량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_SafetyQTY", "안전재고", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_DRevNo", "도면Rev No.", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_CRevNo", "코어Rev No.", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_ETC1", "메모", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                #region --- Combobox & Popup Setting ---

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                btbManager.PopUpAdd(txtCOREMAKECOMPANY, txtCOMPANYNAME, "BM0030", new object[] { 10, "", "", "" });

                #endregion
            }

            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }


        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;
            ClosePrgFormNew();
            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);

                DSGrid1 = helper.FillDataSet("USP_MD0005_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Text), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("Core_Code", "", DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = DSGrid1.Tables[2];
                    grid1.DataBinds();
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();
                helper.Close();
            }
        }

        public override void DoNew()
        {
            ModeStatus = "N";

            try
            {
                base.DoNew();

                if (bNew)
                {
                    this.ShowDialog(Common.getLangText("입력 중인 코어정보가 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }


                CLEAN();

                txtCORECODE.Text = "[ NEW CORECODE ]";

                grid1.UpdateData();

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }

        public override void DoDelete()
        {

        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                //저장, 수정
                rtnDtTemp = helper.FillTable("USP_MD0005_SAVE", CommandType.StoredProcedure

                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_Core_Code", txtCORECODE.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_Vend", txtCOREMAKECOMPANY.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_CoreName", txtCORENAME.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_PartName", txtPARTNAME.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_ChaSu", txtDEGREE.Text, DbType.String, ParameterDirection.Input)

                    , helper.CreateParameter("AS_Core_Area", txtLOCKERNUM.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_DRevNo", txtDRAWINGNUM.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_CRevNo", txtCORENUM.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_Cost", txtCOST.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_SafetyQTY", txtSAFETYSTOCK.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_Core_Count", txtCNT.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("@AS_Core_ETC1", txtMEMO.Text, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }

                helper.Commit();
                this.ShowDialog("등록이 완료되었습니다.", Forms.DialogForm.DialogType.OK);
                ModeStatus = "S";
                DoInquire();
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

        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (ModeStatus == "N")
            {
                if (this.ShowDialog("추가를 취소하시겠습니까?", WIZ.Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    ModeStatus = "S";
                    DoInquire();
                }

                if (grid1.ActiveCell == null)
                {
                    return;
                }

                try
                {
                    DBHelper helper;
                    helper = new DBHelper(false);

                    string sCoreCode = CModule.ToString(grid1.ActiveRow.Cells["Core_Code"].Value);
                    DSGrid1 = helper.FillDataSet("USP_MD0005_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Text), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("Core_Code", sCoreCode, DbType.String, ParameterDirection.Input));

                    SetMoldInfo(DSGrid1.Tables[0]);
                }
                catch (Exception ex)
                {
                    this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }

            else
            {
                if (grid1.ActiveCell == null)
                {
                    this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                try
                {
                    DBHelper helper;
                    helper = new DBHelper(false);

                    string sCoreCode = CModule.ToString(grid1.ActiveRow.Cells["Core_Code"].Value);
                    DSGrid1 = helper.FillDataSet("USP_MD0005_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Text), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("Core_Code", sCoreCode, DbType.String, ParameterDirection.Input));


                    listBox1.Items.Clear();

                    for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[1].Rows.Count; grid1rowNUM++)
                    {
                        listBox1.Items.Add(CModule.ToString(DSGrid1.Tables[1].Rows[grid1rowNUM]["ITEMCODE"]) + " - " + CModule.ToString(DSGrid1.Tables[1].Rows[grid1rowNUM]["ITEMNAME"]));
                    }

                    SetMoldInfo(DSGrid1.Tables[0]);
                }
                catch (Exception ex)
                {
                    this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
                }

            }
        }

        public void SetMoldInfo(DataTable DTinfo)
        {
            if (DTinfo.Rows.Count > 0)
            {
                txtCORECODE.Text = CModule.ToString(DTinfo.Rows[0]["Core_Code"]);
                txtCOREMAKECOMPANY.Text = CModule.ToString(DTinfo.Rows[0]["Core_Vend"]);
                txtCOMPANYNAME.Text = CModule.ToString(DTinfo.Rows[0]["MCNAME"]);
                txtCORENAME.Text = CModule.ToString(DTinfo.Rows[0]["Core_CoreName"]);
                txtPARTNAME.Text = CModule.ToString(DTinfo.Rows[0]["Core_PartName"]);

                txtDEGREE.Text = CModule.ToString(DTinfo.Rows[0]["Core_ChaSu"]);
                txtLOCKERNUM.Text = CModule.ToString(DTinfo.Rows[0]["Core_Area"]);
                txtDRAWINGNUM.Text = CModule.ToString(DTinfo.Rows[0]["Core_DRevNo"]);
                txtCORENUM.Text = CModule.ToString(DTinfo.Rows[0]["Core_CRevNo"]);

                txtCOST.Text = CModule.ToString(DTinfo.Rows[0]["Core_Cost"]);
                txtSAFETYSTOCK.Text = CModule.ToString(DTinfo.Rows[0]["Core_SafetyQTY"]);
                txtCNT.Text = CModule.ToString(DTinfo.Rows[0]["Core_Count"]);
                txtMEMO.Text = CModule.ToString(DTinfo.Rows[0]["Core_ETC1"]);

                //사용가능 설비 리스트
            }
            else
            {
                CLEAN();
            }

        }

        private void CLEAN()
        {
            txtCORECODE.Text = "";
            txtCOMPANYNAME.Text = "";
            txtCOREMAKECOMPANY.Text = "";
            txtCORENAME.Text = "";
            txtPARTNAME.Text = "";

            txtLOCKERNUM.Text = "";

            listBox1.Items.Clear();

            txtDEGREE.Text = "";
            txtCOST.Text = "";
            txtDRAWINGNUM.Text = "";
            txtCORENUM.Text = "";
            txtSAFETYSTOCK.Text = "";

            txtMEMO.Text = "";
            txtCNT.Text = "";
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void BtnProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCORECODE.Text == "")
                {
                    this.ShowDialog("코어를 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                }
                else if (txtCORECODE.Text == "[ NEW CORECODE ]")
                {
                    this.ShowDialog("코어를 등록이후 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    string sCORECODE = CModule.ToString(grid1.ActiveRow.Cells["Core_Code"].Value);
                    MD0005_POP1 mbp = new MD0005_POP1(sCORECODE);
                    if (DialogResult.OK == mbp.ShowDialog())
                    {
                        DBHelper helper;
                        helper = new DBHelper(false);

                        listBox1.Items.Clear();
                        DSGrid1 = helper.FillDataSet("USP_MD0005_S1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Text), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Core_Code", sCORECODE, DbType.String, ParameterDirection.Input));

                        for (int grid1rowNUM = 0; grid1rowNUM < DSGrid1.Tables[1].Rows.Count; grid1rowNUM++)
                        {
                            listBox1.Items.Add(CModule.ToString(DSGrid1.Tables[1].Rows[grid1rowNUM]["ITEMCODE"]) + " - " + CModule.ToString(DSGrid1.Tables[1].Rows[grid1rowNUM]["ITEMNAME"]));
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
