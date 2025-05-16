#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0070_TEST
//   Form Name    : 금형수리현황
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형수리현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

using WIZ;
using WIZ.PopUp;

#endregion

namespace WIZ.MD
{
    public partial class MD0050 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public MD0050()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0050_Load(object sender, EventArgs e)
        {
            #region GRID SETTING 
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "Core_Code",         "코어코드",       true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Core_Vend",         "업체명",         true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Core_CoreName",     "코어명",         true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Core_PartName",     "품목명",         true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);            
            _GridUtil.InitColumnUltraGrid(grid1, "Core_ChaSu",        "차수",           true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);            
            _GridUtil.InitColumnUltraGrid(grid1, "Core_Area",         "보관함위치",     true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);

            _GridUtil.InitColumnUltraGrid(grid1, "Core_SafetyQTY",    "안전재고",       true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_WIOorkdate",     "기준재고",       true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_WorkGB",         "입고수량",       true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_MD_CVT",         "불출수량",       true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_MD_CVT_No",      "예외불출",       true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_PT_CVT",         "현 재고",        true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "RP_PT_CVT_No",      "비고",           true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            
            _GridUtil.SetInitUltraGridBind(grid1);

            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today;

            #endregion

            #region COMBOBOX SETTING 

            #endregion

            #region POPUP SETTING

            BizGridManager bizGridManager = new BizGridManager(grid1);

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MD0050_UJ_S1", CommandType.StoredProcedure);
                
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["REPSEQ"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();

            if (rtnDtTemp == null)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]

                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            //drRow.RejectChanges();

                            //helper.ExecuteNoneQuery("USP_BM0010_D1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_PLANTCODE",       DBHelper.nvlString(drRow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_ITEMCODE",        DBHelper.nvlString(drRow["ITEMCODE"]),   DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_MD0070_TEST_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]),   DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDCODE",  DBHelper.nvlString(drRow["MOLDCODE"]),    DbType.String, ParameterDirection.Input)                                                                                                                                                            
                                                    , helper.CreateParameter("AI_MOLDSEQ",   DBHelper.nvlString(drRow["MOLDSEQ"]),     DbType.String, ParameterDirection.Input)                                                                                                                                                            
                                                    , helper.CreateParameter("AS_REPDATE",   DBHelper.nvlString(drRow["REPDATE"]),     DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REPCODE",   DBHelper.nvlString(drRow["REPCODE"]),     DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REPSEQ",    DBHelper.nvlString(drRow["REPSEQ"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKETYPE",  DBHelper.nvlString(drRow["TAKETYPE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKECODE",  DBHelper.nvlString(drRow["TAKECODE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEDESC",  DBHelper.nvlString(drRow["TAKEDESC"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEYN",    DBHelper.nvlString(drRow["TAKEYN"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEGB",    DBHelper.nvlString(drRow["TAKEGB"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEDATE",  DBHelper.nvlString(drRow["TAKEDATE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEUSER",  DBHelper.nvlString(drRow["TAKEUSER"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SHOTINIT",  DBHelper.nvlString(drRow["SHOTINIT"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK",    DBHelper.nvlString(drRow["REMARK"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR",    LoginInfo.UserID,                         DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                base.DoInquire();
            }
        }

        public override void DoImportExcel()
        {
            base.DoImportExcel();
            base.DoInquire();
        }

        #endregion

        #region < METHOD AREA >

        #endregion

        private void gbxBody_Click(object sender, EventArgs e)
        {

        }

        private void btn_Etcissue_Click(object sender, EventArgs e)
        {
        }

        private void btn_Initem_Click(object sender, EventArgs e)
        {
            MD0050_POP1 mbp = new MD0050_POP1();
            mbp.Show();
        }

        private void btn_Etcissue_Click_1(object sender, EventArgs e)
        {
            MD0050_POP2 mbp = new MD0050_POP2();
            mbp.Show();
        }
    }
}
