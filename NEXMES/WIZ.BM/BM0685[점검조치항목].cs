/*
  Form Name    : 금형 점검/조치항목
  Created Date : 2020-06-17
  Made By      : 윤석현
  Description  : 금형, 노즐 등 설비에 장착하여 사용 하는 기구에 대한 점검/조치 항목
*/

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0685 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataSet rtnDsTemp = new DataSet();

        string sUserID = WIZ.LoginInfo.UserID;
        DateTime dtNow = DateTime.Now;

        #endregion

        #region < CONSTRUCTOR >

        public BM0685()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void MM0070_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MODINSPCODE", "점검코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MODINSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, false, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ACTIONCODE", "조치코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ACTIONNAME", "조치항목명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, false, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.SetInitUltraGridBind(grid2);


            grid1.DisplayLayout.Bands[0].Columns["MODINSPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MODINSPNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

            grid2.DisplayLayout.Bands[0].Columns["ACTIONCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["ACTIONNAME"].Header.Appearance.ForeColor = Color.SkyBlue;



            #endregion

            /*
             BM0000
             (this.grid2, "PRINTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME")
                            MAJORCODE                MINORCODE  CODENAME
             */
            #region COMBO BOX
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            //rtnDtTemp = _Common.GET_BM0000_CODE("PRINTERTYPE"); //프린터 타입,  A:일반, B:바코드프린터
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRINTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PRINTERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

                rtnDsTemp = helper.FillDataSet("USP_BM0685_S1", CommandType.StoredProcedure,
                    helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));


                //검사항목
                grid1.DataSource = rtnDsTemp.Tables[0];
                grid1.DataBinds();

                //조치항목
                grid2.DataSource = rtnDsTemp.Tables[1];
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

            if (this.grid2.IsActivate)
            {
                this.grid2.InsertRow();

                this.grid2.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
                this.grid2.ActiveRow.Cells["ACTIONCODE"].Value = Common.getLangText("자동채번", "TEXT");

                //grid2.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                //grid2.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                //grid2.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                //grid2.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                return;
            }
            this.grid1.InsertRow();

            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
            this.grid1.ActiveRow.Cells["MODINSPCODE"].Value = Common.getLangText("자동채번", "TEXT");

            //grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            //grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            //grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
            //grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;

        }
        /// <summary>
        /// ToolBar의 삭제 버튼
        /// </summary>
        public override void DoDelete()
        {
            //base.DoDelete();

            //if (this.grid1.IsActivate)
            //{
            //    this.grid1.DeleteRow();
            //}
            //else if (this.grid2.IsActivate)
            //{
            //    this.grid2.DeleteRow();
            //}
        }

        public override void DoSave()
        {

            base.DoSave();

            //this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
            //this.grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

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
                        if (drRow["MODINSPNAME"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, Common.getLangText("점검항목명 미입력", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            /*
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM0685_D1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(drRow["MAKEDATE"]), DbType.DateTime, ParameterDirection.Input));
                            */
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM0685_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODINSPCODE", DBHelper.nvlString(drRow["MODINSPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODINSPNAME", DBHelper.nvlString(drRow["MODINSPNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0685_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODINSPCODE", DBHelper.nvlString(drRow["MODINSPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODINSPNAME", DBHelper.nvlString(drRow["MODINSPNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
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
                        if (drRow["ACTIONNAME"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, Common.getLangText("조치항목명 미입력", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            /*
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM0685_D2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(drRow["MAKEDATE"]), DbType.DateTime, ParameterDirection.Input));
                            */
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM0685_I2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ACTIONCODE", DBHelper.nvlString(drRow["ACTIONCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ACTIONNAME", DBHelper.nvlString(drRow["ACTIONNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0685_U2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ACTIONCODE", DBHelper.nvlString(drRow["ACTIONCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ACTIONNAME", DBHelper.nvlString(drRow["ACTIONNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
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


