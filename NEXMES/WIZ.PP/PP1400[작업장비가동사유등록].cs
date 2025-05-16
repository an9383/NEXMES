#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP1400
//   Form Name    : 비가동 현황 및 사유등록
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP1400 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMEBER AREA >
        DataSet rtnDsTemp = new DataSet();      //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통
        DataTable _DtTemp = new DataTable();    //임시로 사용할 데이터테이블 생성
        DataTable DtChange = new DataTable();         //GRID1 DataSource

        UltraGridUtil _GridUtil = new UltraGridUtil();          //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //팝업 매니저

        #endregion


        #region < CONSTRUCTOR >
        public PP1400()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP1400_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "라인", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "라인명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "시작시간", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "종료시간", false, GridColDataType_emu.VarChar, 135, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME", "소요시간(분)", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "비가동", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPDESC", "비가동명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCLASS", "비가동유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPE", "비가동구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTYPENM", "비가동구분명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCLASSNM", "비가동유형명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비가동사유", false, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERCNT", "작업자수", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "Lot No", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 125, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "설비카운트", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTQTY", "입고량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "작성자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            DtChange = (DataTable)grid1.DataSource;
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("PLANTCODE", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPCLASS");  //비가동 유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STOPCLASS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPTYPE");  //비가동 타입
            WIZ.Common.FillComboboxMaster(this.cboStopType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STOPTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = GET_TBM1100_CODE(Convert.ToString(this.cboPlantCode_H.Value));
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STOPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cboStartDate.Value = DateTime.Now;
            cboEndDate.Value = DateTime.Now;
            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode_H.Select();
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {

            //DBHelper helper = new DBHelper(false);

            //try
            //{
            //    string sPlantCode      = Convert.ToString(cboPlantCode_H.Value);            //공장코드
            //    string sStartDate      = string.Format("{0:yyyyMMdd}", cboStartDate.Value); //조회일자(시작)
            //    string sEndDate        = string.Format("{0:yyyyMMdd}", cboEndDate.Value);   //조회일자(종료)




            //    string sStopType       = Convert.ToString(cboStopType_H.Value);

            //    if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
            //    {
            //        this.ShowDialog("시작일자를 종료일자보다 이전으로 선택해주십시오.", WIZ.Forms.DialogForm.DialogType.OK);
            //        return;
            //    }

            //    base.DoInquire();

            //    rtnDtTemp = helper.FillTable("USP_PP1400_S1N", CommandType.StoredProcedure
            //                        , helper.CreateParameter("AS_PLANTCODE",      sPlantCode,      DbType.String, ParameterDirection.Input)
            //                        , helper.CreateParameter("AS_STARTDATE",      sStartDate,      DbType.String, ParameterDirection.Input)
            //                        , helper.CreateParameter("AS_ENDDATE",        sEndDate,        DbType.String, ParameterDirection.Input)
            //                        , helper.CreateParameter("AS_STOPTYPE",       sStopType,       DbType.String, ParameterDirection.Input));

            //    foreach (UltraGridRow ugr in grid1.Rows)
            //    {
            //        if (Convert.ToString(ugr.Cells["STOPCLASS"].Value) == "0")
            //        {
            //            ugr.Cells["STOPCODE"].IgnoreRowColActivation = true;
            //            ugr.Cells["STOPCODE"].Activation             = Activation.NoEdit;
            //            ugr.Cells["STOPDESC"].IgnoreRowColActivation = true;
            //            ugr.Cells["STOPDESC"].Activation             = Activation.NoEdit;
            //        }
            //    }

            //    this.ClosePrgFormNew();

            //    if (this.rtnDtTemp.Rows.Count > 0)
            //    {
            //        grid1.DataSource = rtnDtTemp;
            //        grid1.DataBinds();

            //        grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
            //        grid1.DisplayLayout.Bands[0].Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;
            //        grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
            //        grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;

            //        grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            //        grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;

            //        grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            //        grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            //    }
            //    else
            //    {
            //        // 조회할 데이터가 없습니다.
            //        this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
            //        return;
            //    }
            //    DtChange = rtnDtTemp;
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.ToString());
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);
            if (((DataTable)grid1.DataSource).GetChanges() == null)
                return;
            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel) //변경된 사항을 저장하시겠습니까?
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                this.grid1.UpdateData();

                //helper.Transaction = helper._sConn.BeginTransaction();

                foreach (DataRow drRow in DtChange.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:
                            #region --- 수정 ---
                            helper.ExecuteNoneQuery("USP_PP1400_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("RECDATE", Convert.ToString(drRow["RECDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STARTDATE", Convert.ToString(drRow["STARTDATE"]), DbType.DateTime, ParameterDirection.Input)
                                                    , helper.CreateParameter("STOPCODE", Convert.ToString(drRow["STOPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STOPCLASS", Convert.ToString(drRow["STOPCLASS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STOPTYPE", Convert.ToString(drRow["STOPTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            string s = helper.RSCODE;
                            break;
                    }
                }
                this.ClosePrgFormNew();
                if (helper.RSCODE == "S")
                {

                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                }
                else
                {
                    string a = helper.RSMSG;
                    helper.Rollback();
                    this.ShowDialog(Common.getLangText("데이터 등록을 실패하였습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
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
        public override void DoDownloadExcel()
        {
            //base.DoDownloadExcel();

            WIZ.REPORT.ExcelManager excel = new WIZ.REPORT.ExcelManager();
            excel.DownloadExcel(this.grid1, this.Name, false);
        }
        #endregion


        #region < EVENTS >
        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;
        }


        #endregion


        #region < USER FUNCTIONS >
        private DataTable GET_TBM1100_CODE(string PlantCode)
        {
            DBHelper helper = new DBHelper(false);
            DataTable DtTemp = new DataTable();

            try
            {
                // 비가동 내역 콤보박스.
                StringBuilder query = new StringBuilder();

                query.Remove(0, query.Length);
                query.AppendLine("   SELECT DISTINCT STOPCODE AS CODE_ID,                       ");
                query.AppendLine("          '['  || STOPCODE || '] '||  STOPDESC AS CODE_NAME   ");
                query.AppendLine("     FROM TBM1100 WHERE PLANTCODE LIKE '" + PlantCode + "%'   ");
                query.AppendLine(" ORDER BY STOPCODE                                            ");

                DtTemp = helper.FillTable(Convert.ToString(query), CommandType.Text);

                return DtTemp;
            }
            catch (Exception ex)
            {
                return DtTemp;
            }
            finally
            {
                helper.Close();
            }
        }

        private DataTable GET_TBM0000_CODE_N(string MajorCode, string sSql)
        {
            DataTable Dt = new DataTable();

            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine(" SELECT MINORCODE                             AS CODE_ID,     ");
                query.AppendLine("        '['  || MinorCode || '] '||  CodeName AS CODE_NAME,   ");
                query.AppendLine("        RelCode1, RelCode2, RelCode3, RelCode4, RelCode5,     ");
                query.AppendLine("        DisplayNo                             AS DisplayNo    ");
                query.AppendLine("   FROM TBM0000                                               ");
                query.AppendLine("  WHERE MajorCode = '" + MajorCode.ToUpper() + "'             ");
                query.AppendLine("    AND MinorCode <> '$'                                      ");
                query.AppendLine("    " + sSql + "                                              ");
                query.AppendLine("    AND UseFlag ='Y'                                          ");
                query.AppendLine("  ORDER BY DisplayNo                                          ");

                Dt = helper.FillTable(Convert.ToString(query), CommandType.Text);

                return Dt;
            }
            catch
            {
                return Dt;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < Event >
        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtItemCode.Tag = null;
                txtItemCode.Text = string.Empty;
                txtItemName.Text = string.Empty;
            }
        }

        private void txtItemCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "" };
            //    POP_TBM0100 _frmA = new POP_TBM0100(values);
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtItemCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtItemName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }

        private void txtWcCode_ButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "", "", "", "", "" };
            //    POP_TBM0600 _frmA = new POP_TBM0600(values);
            //    _frmA.ShowDialog();
            //    rtnDtTemp = (DataTable)_frmA.Tag;
            //    if (rtnDtTemp.Rows.Count > 0)
            //    {
            //        txtWcCode.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
            //        txtWcName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
            //    }
            //    _frmA.Dispose();
            //}
            //catch
            //{
            //}
        }

        private void txtWcCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtWcCode.Tag = null;
                txtWcCode.Text = string.Empty;
                txtWcName.Text = string.Empty;
            }
        }
        #endregion
    }
}
