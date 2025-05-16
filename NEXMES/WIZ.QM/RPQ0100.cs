#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : RPQ0100
//   Form Name    : 검사공정/항목등록 및 조회
//   Name Space   : WIZ.QM
//   Created Date : 2013-11-19
//   Made By      : WIZCORE
//   Description  : RPQ 검사공정/항목 등록 및 조회 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{
    public partial class BM0000 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp3 = new DataTable(); // return DataTable 공통

        #endregion

        #region < CONSTRUCTOR >

        public BM0000()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            string sUseFlag = string.Empty;
            string sLineCode = string.Empty;
            string sOPCode = string.Empty;
        }
        #endregion

        #region BM0000_Load
        private void BM0000_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            //---------------------------------------------------------------------그리드1
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid  (91 111 110 114 185 95 100 100 100 156 209 100 100 100 100 90 90 169 90 90 90 90 90 90 90 90 90 90 )
            _GridUtil.InitColumnUltraGrid(grid1, "MajorCode", "주코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MinorCode", "부코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CodeName", "코드명", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //---------------------------------------------------------------------그리드2
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            // InitColumnUltraGrid  (91 111 110 114 185 95 100 100 100 156 209 100 100 100 100 90 90 169 90 90 90 90 90 90 90 90 90 90 )

            _GridUtil.InitColumnUltraGrid(grid2, "MajorCode", "검사공정코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MinorCode", "NO", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CodeName", "내용", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DisplayNo", "유효일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode1", "출력순서", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode2", "검사방법", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode3", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode4", "작업공정코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RelCode5", "입력방법", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UseFlag", "특별관리", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MakeDate", "검사주기", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Maker", "해당제품", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EditDate", "KOR", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Editor", "ENG", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            //DtChange    = (DataTable)grid1.DataSource;
            //DtChange2   = (DataTable)grid2.DataSource;

            #region 콤보박스
            //rtnDtTemp = _Common.GET_TBM0000_CODE("UseFlag");     //사용여부
            //WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion

        }
        #endregion BM0000_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                string sMajorCode = txtMajorCode.Text.Trim();
                string sUseFlag = Convert.ToString(cboUseFlag_H.SelectedValue);
                string sSystemID = WIZ.Common.SystemID;
                string sLang = WIZ.Common.Lang;
                StringBuilder Sql = new StringBuilder();
                Sql.Length = 0;
                Sql.AppendLine("SELECT iprocess_cd, iprocess_name, section  ");
                Sql.AppendLine("  From insp_process   ");
                Sql.AppendLine(" Order by iprocess_cd");

                rtnDtTemp = helper.FillTable(Sql.ToString(), CommandType.Text);

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            if (this.grid2.IsActivate)
            {
                if (this.grid1.Rows.Count == 0)
                {
                    WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm("R00111");
                    checkform.ShowDialog();
                    return;
                }
                if (this.grid1.ActiveRow.Cells["MajorCode"].Value.ToString() == "")
                {
                    WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm("R00000");
                    checkform.ShowDialog();
                    return;
                }
                this.grid2.InsertRow();
                this.grid2.ActiveRow.Cells["MajorCode"].Value = this.grid1.ActiveRow.Cells["MajorCode"].Value;
                this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
                this.grid2.ActiveRow.Cells["Lang"].Value = WIZ.Common.Lang;
                return;
            }
            this.grid1.InsertRow();
            this.grid1.ActiveRow.Cells["MinorCode"].Value = "$";
            this.grid1.ActiveRow.Cells["SysFlag"].Value = "U";
            this.grid1.ActiveRow.Cells["Lang"].Value = WIZ.Common.Lang;
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

            Grid1ToolAct();
            Grid1ToolAct2();
        }
        #endregion

        #region<METHOD AREA>
        private void Grid1ToolAct()
        {
            DBHelper helper = new DBHelper("", true);
            try
            {
                this.Focus();
                base.DoSave();
                this.grid1.UpdateData();
                //helper.Transaction = helper._sConn.BeginTransaction();
                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM0000_D3N", CommandType.StoredProcedure
                                                     , helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM0000_I3N", CommandType.StoredProcedure
                            , helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("CodeName", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SysFlag", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SystemID", Convert.ToString(drRow["SystemID"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Lang", Convert.ToString(drRow["Lang"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UidName", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0000_U3N", CommandType.StoredProcedure
                            , helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("CodeName", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SysFlag", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("MinorLen", Convert.ToString(drRow["MinorLen"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Lang", Convert.ToString(drRow["Lang"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Uid", Convert.ToString(drRow["Uidsys"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UidName", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SystemID", Convert.ToString(drRow["SystemID"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }

                    if (helper.RSCODE == "E")
                    {
                        MessageBox.Show(helper.RSMSG);
                    }
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void Grid1ToolAct2()
        {
            DBHelper helper = new DBHelper("", true);
            try
            {
                this.Focus();
                base.DoSave();
                grid2.UpdateData();
                //helper.Transaction = helper._sConn.BeginTransaction();
                foreach (DataRow drRow in ((DataTable)grid2.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM0000_D4N", CommandType.StoredProcedure
                            , helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("MinorCode", Convert.ToString(drRow["MinorCode"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM0000_I5N", CommandType.StoredProcedure
                            , helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)//this.grid2.ActiveRow.Cells["MajorCode"].Value
                            , helper.CreateParameter("MinorCode", Convert.ToString(drRow["MinorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("CodeName", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode1", Convert.ToString(drRow["RelCode1"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode2", Convert.ToString(drRow["RelCode2"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode3", Convert.ToString(drRow["RelCode3"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode4", Convert.ToString(drRow["RelCode4"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode5", Convert.ToString(drRow["RelCode5"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SysFlag", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SystemID", Convert.ToString(drRow["SystemID"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Lang", Convert.ToString(drRow["Lang"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UidName", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0000_U5N", CommandType.StoredProcedure
                            , helper.CreateParameter("MajorCode", Convert.ToString(drRow["MajorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("MinorCode", Convert.ToString(drRow["MinorCode"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("CodeName", Convert.ToString(drRow["CodeName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode1", Convert.ToString(drRow["RelCode1"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode2", Convert.ToString(drRow["RelCode2"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode3", Convert.ToString(drRow["RelCode3"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode4", Convert.ToString(drRow["RelCode4"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RelCode5", Convert.ToString(drRow["RelCode5"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("DisplayNo", Convert.ToString(drRow["DisplayNo"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SysFlag", Convert.ToString(drRow["SysFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Lang", Convert.ToString(drRow["Lang"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("Uid", Convert.ToString(drRow["Uidsys"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("UidName", Convert.ToString(drRow["UidName"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("SystemID", Convert.ToString(drRow["SystemID"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);


            string sMajorCode = ((WIZ.Control.Grid)(sender)).ActiveRow.Cells["MajorCode"].Text;
            string sUseFlag = Convert.ToString(cboUseFlag_H.SelectedValue);
            string sSystemID = WIZ.Common.SystemID;
            string sLang = WIZ.Common.Lang;

            rtnDtTemp2 = helper.FillTable("USP_BM0000_S4N", CommandType.StoredProcedure
            , helper.CreateParameter("MajorCode", sMajorCode, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("SystemID", sSystemID, DbType.String, ParameterDirection.Input)
            , helper.CreateParameter("Lang", sLang, DbType.String, ParameterDirection.Input));

            if (rtnDtTemp2 != null)
            {
                grid2.DataSource = rtnDtTemp2;
                grid2.DataBinds();

            }
        }

        // grid2 추가행을 생성할 때 MajorCode는 grid1의 MajorCode를 바로 반영함.
        private void grid2_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            e.Row.Cells["MajorCode"].Value = this.grid1.ActiveRow.Cells["MajorCode"].Value;
        }
        #endregion
    }
}

