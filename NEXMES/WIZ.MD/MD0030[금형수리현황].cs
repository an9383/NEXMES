#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0030
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
    public partial class MD0030 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public MD0030()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0030_Load(object sender, EventArgs e)
        {
            #region GRID SETTING 
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",  "사업장",            true, GridColDataType_emu.VarChar,      140, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE",   "금형코드",          true, GridColDataType_emu.VarChar,      110, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME",   "금형명",            true, GridColDataType_emu.VarChar,      180, 100, Infragistics.Win.HAlign.Left,   true, false);            
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSEQ",    "금형순번",          true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   false, false);            
            _GridUtil.InitColumnUltraGrid(grid1, "REPDATE",    "수리요청일자",       true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REPCODE",    "수리요청코드",       true, GridColDataType_emu.VarChar,      110, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REPSEQ",     "차수",              true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REPDESC",    "요구사항 및 문제점", true, GridColDataType_emu.VarChar,      200, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REPUSER",    "요청자",            true, GridColDataType_emu.VarChar,       90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REPUSERNM",  "요청자명",          true, GridColDataType_emu.VarChar,       90, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKEDATE",   "조치일자",          true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKETYPE",   "조치타입",          true, GridColDataType_emu.VarChar,      120, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKECODE",   "조치코드",          true, GridColDataType_emu.VarChar,      120, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKEGB",     "조치구분",          true, GridColDataType_emu.VarChar,      120, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKEDESC",   "조치변경내용",      true, GridColDataType_emu.VarChar,      200, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKEYN",     "조치완료여부",      true, GridColDataType_emu.VarChar,      110, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKEUSER",   "조치담당자",        true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKEUSERNM", "조치담당자명",      true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "SHOTINIT",   "쇼트초기화",        true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",     "비고",              true, GridColDataType_emu.VarChar,      200, 100, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",   "등록일자",          true,  GridColDataType_emu.DateTime,    180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",      "등록자",            true,  GridColDataType_emu.VarChar,     100, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",   "수정일자",          true,  GridColDataType_emu.DateTime,    180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",     "수정자",            true,  GridColDataType_emu.VarChar,     100, 100, Infragistics.Win.HAlign.Left,   true, false);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MOLDCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion


            #region COMBOBOX SETTING 

            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDREPCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "REPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTAKETYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TAKETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTAKECODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TAKECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDTAKEGB");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TAKEGB", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TAKEYN", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "SHOTINIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP SETTING
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });  // 품목
            btbManager.PopUpAdd(txt_MOLDCODE_H, txt_MOLDNAME_H, "BM0680", new object[] { cbo_PLANTCODE_H, cbo_USEFLAG_H });

            BizGridManager bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });
            bizGridManager.PopUpAdd("REPUSER", "REPUSERNM", "BM0020", new string[] { "PLANTCODE", "", "Y" });
            bizGridManager.PopUpAdd("TAKEUSER", "TAKEUSERNM", "BM0020", new string[] { "PLANTCODE", "", "Y" });
            bizGridManager.PopUpAdd("MOLDCODE", "MOLDNAME", "BM0680", new string[] { "PLANTCODE", "Y" });

            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-5);

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
                base.DoInquire();

                string sPlantCode   = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sMoldCode    = txt_MOLDCODE_H.Text.Trim();
                string sItemCode    = txt_ITEMCODE_H.Text.Trim();
                string sStartDate   = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate     = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sUseFlag     = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_MD0030_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE",   sPlantCode,   DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE",   sStartDate,   DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE",     sEndDate,     DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MOLDCODE",    sMoldCode,    DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE",    sItemCode,    DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG",     sUseFlag,     DbType.String, ParameterDirection.Input));

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
                            helper.ExecuteNoneQuery("USP_MD0030_U1"
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

            //MD0030_EXCEL MD0030_EXCEL = new MD0030_EXCEL();
            //MD0030_EXCEL.ShowDialog();

            base.DoInquire();
        }


        #endregion

        #region < METHOD AREA >

        #endregion
    }
}
