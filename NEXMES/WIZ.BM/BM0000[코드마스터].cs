#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0000
//   Form Name    : 코드마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-04
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 시스템에서 관리하는 각종 코드 관리         
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();

        #endregion

        #region < CONSTRUCTOR >

        public BM0000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0000_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            //---------------------------------------------------------------------그리드1
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "MajorCode", "주코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MinorCode", "부코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CodeName", "코드명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MinorLen", "길이", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Right, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SysFlag", "시스템구분", false, GridColDataType_emu.CheckBox, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UidSYS", "Uid", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UidName", "UidName", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SystemID", "SystemID", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Lang", "Lang", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            //---------------------------------------------------------------------그리드2
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "MajorCode", "주코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MinorCode", "부코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CodeName", "코드명", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "DisplayNo", "순서", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode1", "관련1", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode2", "관련2", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode3", "관련3", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode4", "관련4", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode5", "관련5", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "Editor", "수정자", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UidSYS", "Uid", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UidName", "UidName", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SysFlag", "시스템구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "Lang", "Lang", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);

            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region POPUP SETTING

            BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성
            //팝업 셋팅
            btbManager.PopUpAdd(txt_MAJORCODE_H, txt_CODENAME_H, "BM0000", new object[] { });  // 품목
            #endregion

            this.grid1.AllowDrop = true;
            this.grid1.SelectionDrag += new CancelEventHandler(grid1_SelectionDrag);
            this.grid1.DragOver += new DragEventHandler(grid1_DragOver);
            this.grid1.DragDrop += new DragEventHandler(grid1_DragDrop);

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

                base.DoInquire();

                string sMajorCode = txt_MAJORCODE_H.Text.Trim();
                string sCodeName = txt_CODENAME_H.Text.Trim();
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);
                string sSystemID = WIZ.Common.SystemID;

                grid1.DataSource = helper.FillTable("USP_BM0000_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_MAJORCODE", sMajorCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_CODENAME", sCodeName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_SYSTEMID", sSystemID, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

                if (grid1.Rows.Count == 0)
                    _GridUtil.Grid_Clear(grid2);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            int iRow = 0;
            if (this.grid2.IsActivate)
            {
                if (this.grid1.Rows.Count == 0)
                {
                    WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(Common.getLangText("조회할 데이터가 없습니다.", "MSG")); //조회할 데이터가 없습니다.
                    checkform.ShowDialog();
                    return;
                }
                if (this.grid1.ActiveRow.Cells["MajorCode"].Value.ToString() == "")
                {
                    WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(Common.getLangText("대분류를 확인해주세요.", "MSG"));
                    checkform.ShowDialog();
                    return;
                }
                iRow = this.grid2.InsertRow();
                this.grid2.ActiveRow.Cells["MajorCode"].Value = this.grid1.ActiveRow.Cells["MajorCode"].Value;
                this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
                this.grid2.ActiveRow.Cells["Lang"].Value = WIZ.Common.Lang;
                UltraGridUtil.ActivationAllowEdit(this.grid2, "MinorCode");
                return;
            }
            iRow = this.grid1.InsertRow();
            this.grid1.ActiveRow.Cells["MinorCode"].Value = "$";
            this.grid1.ActiveRow.Cells["SysFlag"].Value = "U";
            this.grid1.ActiveRow.Cells["Lang"].Value = WIZ.Common.Lang;
            UltraGridUtil.ActivationAllowEdit(this.grid1, "MajorCode");
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
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
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

            base.DoSave();

            this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
            this.grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

            this.Grid1ToolAct();
            this.Grid1ToolAct2();
        }
        #endregion

        #region< EVENT AREA >

        // grid2 추가행을 생성할 때 MajorCode는 grid1의 MajorCode를 바로 반영함.
        private void grid2_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            e.Row.Cells["MajorCode"].Value = this.grid1.ActiveRow.Cells["MajorCode"].Value;
        }

        private void grid1_SelectionDrag(object sender, CancelEventArgs e)
        {
            grid1.DoDragDrop(grid1.Selected.Rows, DragDropEffects.Move);
        }

        private void grid1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            UltraGrid grid = sender as UltraGrid;
            Point pointInGridCoords = grid.PointToClient(new Point(e.X, e.Y));
            if (pointInGridCoords.Y < 20)
                // Scroll up.
                this.grid1.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp);
            else if (pointInGridCoords.Y > grid.Height - 20)
                // Scroll down.
                this.grid1.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown);
        }

        private void grid1_DragDrop(object sender, DragEventArgs e)
        {
            int dropIndex;

            // Get the position on the grid where the dragged row(s) are to be dropped.
            //get the grid coordinates of the row (the drop zone)
            UIElement uieOver = grid1.DisplayLayout.UIElement.ElementFromPoint(grid1.PointToClient(new Point(e.X, e.Y)));

            //get the row that is the drop zone/or where the dragged row is to be dropped
            UltraGridRow ugrOver = uieOver.GetContext(typeof(UltraGridRow), true) as UltraGridRow;
            if (ugrOver != null)
            {
                dropIndex = ugrOver.Index;    //index/position of drop zone in grid

                //get the dragged row(s)which are to be dragged to another position in the grid
                SelectedRowsCollection SelRows = (SelectedRowsCollection)e.Data.GetData(typeof(SelectedRowsCollection)) as SelectedRowsCollection;
                //get the count of selected rows and drop each starting at the dropIndex
                foreach (UltraGridRow aRow in SelRows)
                {
                    //move the selected row(s) to the drop zone
                    grid1.Rows.Move(aRow, dropIndex);
                }
            }
        }

        #endregion

        #region< METHOD AREA >
        private void Grid1ToolAct()
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
                        if (drRow["MajorCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, Common.getLangText("주코드 error!", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            //drRow.RejectChanges();
                            //helper.ExecuteNoneQuery("USP_BM0000_D3N", CommandType.StoredProcedure
                            //                         , helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM0000_I1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_MAJORCODE", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_CODENAME", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_SYSFLAG", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_SYSTEMID", "NexMES", DbType.String, ParameterDirection.Input) //Convert.ToString(drRow["SystemID"])
                                                                   , helper.CreateParameter("AS_UIDNAME", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0000_U1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_MAJORCODE", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_CODENAME", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_SYSFLAG", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MINORLEN", Convert.ToString(drRow["MinorLen"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_UID", Convert.ToString(drRow["Uidsys"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_UIDNAME", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_SYSTEMID", Convert.ToString(drRow["SystemID"]), DbType.String, ParameterDirection.Input));
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
                        if (drRow["MajorCode"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, Common.getLangText("주코드 error!", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            //drRow.RejectChanges();
                            //helper.ExecuteNoneQuery("USP_BM0000_D4N", CommandType.StoredProcedure
                            //, helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                            //, helper.CreateParameter("MinorCode", Convert.ToString(drRow["MinorCode"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM0000_I2", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_MAJORCODE", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)//this.grid2.ActiveRow.Cells["MajorCode"].Value
                            , helper.CreateParameter("AS_MINORCODE", Convert.ToString(drRow["MinorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CODENAME", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE1", Convert.ToString(drRow["RelCode1"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE2", Convert.ToString(drRow["RelCode2"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE3", Convert.ToString(drRow["RelCode3"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE4", Convert.ToString(drRow["RelCode4"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE5", Convert.ToString(drRow["RelCode5"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_DISPLAYNO", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SYSFLAG", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SYSTEMID", "NexMES", DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_UIDNAME", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0000_U2", CommandType.StoredProcedure, false, true
                            , helper.CreateParameter("AS_MAJORCODE", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MINORCODE", Convert.ToString(drRow["MinorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CODENAME", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE1", Convert.ToString(drRow["RelCode1"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE2", Convert.ToString(drRow["RelCode2"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE3", Convert.ToString(drRow["RelCode3"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE4", Convert.ToString(drRow["RelCode4"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE5", Convert.ToString(drRow["RelCode5"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_DISPLAYNO", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SYSFLAG", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_UID", Convert.ToString(drRow["Uidsys"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_UIDNAME", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SYSTEMID", "NexMES", DbType.String, ParameterDirection.Input));
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

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            /*
            DBHelper helper = new DBHelper(false);

            string sMajorCode = ((WIZ.Control.Grid)(sender)).ActiveRow.Cells["MajorCode"].Text;
            string sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);
            string sSystemID = WIZ.Common.SystemID;
            string sLang = WIZ.Common.Lang;

            rtnDtTemp2 = helper.FillTable("USP_BM0000_S2", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_MAJORCODE", sMajorCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_SYSTEMID", sSystemID, DbType.String, ParameterDirection.Input));

            grid2.DataSource = rtnDtTemp2;
            grid2.DataBinds();
            */


            //grid1에서 키보드 ↑, ↓ 입력시 grid2 조회 기능
            //기능 삭제시 
            //디자이너 파일에서 이벤트 삭제 - this.grid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grid1_KeyUp); 
            //소스코드에서 삭제 - grid1_KeyUp(object sender, KeyEventArgs e), Gird2_Search()

            Gird2_Search();
        }

        #region grid1에서 키보드 ↑, ↓ 입력시 grid2 조회 기능
        private void grid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up) || e.KeyCode.Equals(Keys.Down))
            {
                Gird2_Search();
            }
        }
        private void Gird2_Search()
        {
            DBHelper helper = new DBHelper(false);

            string sMajorCode = grid1.ActiveRow.Cells["MajorCode"].Text;
            string sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);
            string sSystemID = WIZ.Common.SystemID;
            string sLang = WIZ.Common.Lang;

            rtnDtTemp2 = helper.FillTable("USP_BM0000_S2", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_MAJORCODE", sMajorCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_SYSTEMID", sSystemID, DbType.String, ParameterDirection.Input));

            grid2.DataSource = rtnDtTemp2;
            grid2.DataBinds();
        }
        #endregion
    }
}

