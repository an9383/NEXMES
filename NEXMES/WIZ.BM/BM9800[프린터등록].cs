 /* 개발정보
   Form Name    : 품목별 프린터관리
   Created Date : 2019-12-18
   Made By      : 윤석현
   Description  : 프린터 서버 구축에 필요한 기본 정보 등록/수정
 */

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WIZ;
using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
using System.IO.Ports;
#endregion

namespace WIZ.BM
{
    public partial class BM9700 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        string sUserID = WIZ.LoginInfo.UserID;
        DateTime dtNow = DateTime.Now;

        #endregion

        #region < CONSTRUCTOR >

        public BM9700()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void MM0070_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PROCESSGROUP", "공정구분", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "GROUPNAME",    "공정명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PRINTERTYPE",  "프린터TYPE", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "FILENAME",     "출력양식",   false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",       "비고",       false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",        "등록자",     false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",     "등록일시",   false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",       "수정자",     false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",     "수정일시",   false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Left, true, false);
            
            //grid1.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "USERID",          "로그인ID",       false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "PRINTERTYPE",     "프린터TYPE",   false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "PRINTER_NAME",    "프린터명",     false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "PRINTER_IP",      "프린터IP",     false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK",          "비고",         false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER",           "등록자",       false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE",        "등록일시",     false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR",          "수정자",       false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE",        "수정일시",     false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Left, true, false); ;

            _GridUtil.SetInitUltraGridBind(grid2);

            grid1.DisplayLayout.Bands[0].Columns["PRINTERTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;

            grid2.DisplayLayout.Bands[0].Columns["USERID"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["PRINTERTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;


            #endregion

            DataTable rtnDtTemp = new DataTable();  // return DataTable 공통


            /*
             BM0000
             (this.grid2, "PRINTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME")
                            MAJORCODE                MINORCODE  CODENAME
             */
            #region COMBO BOX
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("PRINTERTYPE"); //프린터 타입,  A:일반, B:바코드프린터
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRINTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PRINTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_TSY0030_CODE("USERID"); //로그인ID 지정
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USERID", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion



            #region POPUP

            //btbManager.PopUpAdd("", "", "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

            //BizGridManager bizGridManager = new BizGridManager(grid1); //품목
            //bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });


            #endregion



        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼
        /// </summary>
        public override void DoInquire()
        {
            this._GridUtil.Grid_Clear(grid1);
            this._GridUtil.Grid_Clear(grid2);
            
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                   // 사업장

                rtnDtTemp = helper.FillTable("USP_BM9700_S1", CommandType.StoredProcedure,
                    helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                rtnDtTemp2 = helper.FillTable("USP_BM9700_S2", CommandType.StoredProcedure, 
                    helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                grid2.DataSource = rtnDtTemp2;
                grid2.DataBinds();

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
            
        }
        /// <summary>
        /// ToolBar의 추가 버튼
        /// </summary>
        public override void DoNew()
        {

            base.DoNew();

            int iRow = 0;
            if (this.grid2.IsActivate)
            {
                iRow = this.grid2.InsertRow();

                //this.grid2.ActiveRow.Cells["MajorCode"].Value = this.grid1.ActiveRow.Cells["MajorCode"].Value;
                //this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
                //this.grid2.ActiveRow.Cells["Lang"].Value = WIZ.Common.Lang;
                //UltraGridUtil.ActivationAllowEdit(this.grid2, "MinorCode");

                grid2.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                return;
            }
            iRow = this.grid1.InsertRow();
            grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;


            //this.grid1.ActiveRow.Cells["MinorCode"].Value = "$";
            //this.grid1.ActiveRow.Cells["SysFlag"].Value = "U";
            //this.grid1.ActiveRow.Cells["Lang"].Value = WIZ.Common.Lang;
            //UltraGridUtil.ActivationAllowEdit(this.grid1, "MajorCode");

        }
        /// <summary>
        /// ToolBar의 삭제 버튼
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            if (this.grid1.IsActivate)
            {
                this.grid1.DeleteRow();
            }
            else if (this.grid2.IsActivate)
            {
                this.grid2.DeleteRow();
            }
        }

        public override void DoSave()
        {

            base.DoSave();

            this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
            this.grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

            this.Grid1ToolAct1();
            this.Grid1ToolAct2();
        }

        private void Grid1ToolAct1()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PRINTERTYPE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, Common.getLangText("프린터TYPE 미선택", "TEXT"));
                            continue;
                        }
                        if (drRow["PROCESSGROUP"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, Common.getLangText("공정구분 미선택", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제

                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM9700_D1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MAKER", DBHelper.nvlString(drRow["MAKER"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(drRow["MAKEDATE"]), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM9700_I1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PROCESSGROUP", DBHelper.nvlString(drRow["PROCESSGROUP"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("GROUPNAME", DBHelper.nvlString(drRow["GROUPNAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTERTYPE", DBHelper.nvlString(drRow["PRINTERTYPE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("FILENAME", DBHelper.nvlString(drRow["FILENAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM9700_U1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PROCESSGROUP", DBHelper.nvlString(drRow["PROCESSGROUP"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("GROUPNAME", DBHelper.nvlString(drRow["GROUPNAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTERTYPE", DBHelper.nvlString(drRow["PRINTERTYPE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("FILENAME", DBHelper.nvlString(drRow["FILENAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", DBHelper.nvlString(drRow["MAKER"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(drRow["MAKEDATE"]), DbType.DateTime, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();
                helper.Commit();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        private void Grid1ToolAct2()
        {
            DataTable dt = grid2.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                base.DoSave();
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["USERID"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, Common.getLangText("사용자 미선택", "TEXT"));
                            continue;
                        }
                        if (drRow["PRINTERTYPE"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, Common.getLangText("프린터TYPE 미선택", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM9700_D2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MAKER", DBHelper.nvlString(drRow["MAKER"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(drRow["MAKEDATE"]), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM9700_I2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("USERID", DBHelper.nvlString(drRow["USERID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTERTYPE", DBHelper.nvlString(drRow["PRINTERTYPE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTER_NAME", DBHelper.nvlString(drRow["PRINTER_NAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTER_IP", DBHelper.nvlString(drRow["PRINTER_IP"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM9700_U2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("USERID", DBHelper.nvlString(drRow["USERID"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTERTYPE", DBHelper.nvlString(drRow["PRINTERTYPE"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTER_NAME", DBHelper.nvlString(drRow["PRINTER_NAME"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PRINTER_IP", DBHelper.nvlString(drRow["PRINTER_IP"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKER", DBHelper.nvlString(drRow["MAKER"]), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(drRow["MAKEDATE"]), DbType.DateTime, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid2.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid2.SetAcceptChanges();
                helper.Commit();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();

                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion





    }
}


