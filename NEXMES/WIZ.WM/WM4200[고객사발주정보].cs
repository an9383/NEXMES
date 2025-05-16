#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0300X
//   Form Name    : 작업지시 등록
//   Name Space   : WIZ.WM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM4200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil(); // 그리드 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();     // POPUP 화면
        DataTable rtnDtTemp = new DataTable();     // return DataTable 공통
        DataTable dtGrid1 = new DataTable();
        bool e = true;
        #endregion

        public WM4200()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager bizGridManager = new BizGridManager(grid1); ;

            this.cboSOSTDT.Value = System.DateTime.Now;
            this.cboSOEDDT.Value = System.DateTime.Now;

            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "", "" }); //거래처 POP_UP
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });         //품목

            bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "TBM0100", new string[] { "PLANTCODE", "" });        // 품목
            bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "TBM0300", new string[] { "PLANTCODE", "", "", "" }); // 거래처코드
        }

        private void WM4200_Load(object sender, EventArgs e)
        {
            Common _Common = new Common();

            #region Grid 셋팅
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.caption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            //2015-06-01 최재형 DLVYLOC 기존 납품처 -> 하차장으로 변경 / 거래처 = 납품처
            // 거래처 발주번호, 발주유형 품목 수량 단위 납기요청일 하차장 국가
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "일련번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SOTYPE", "발주유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SODATE", "발주일자", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true, "yyyy-MM-dd", "yyyy-mm-dd", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SOQTY", "발주수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, true, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANSHIPDATE", "납품요청일", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, true, "yyyy-MM-dd", "yyyy-mm-dd", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DLVYLOC", "하차장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COUNTRYNAME", "국가", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일시", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일시", false, GridColDataType_emu.DateTime, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region Datatable 셋팅

            dtGrid1 = (DataTable)grid1.DataSource;
            grid1.DataSource = dtGrid1;
            grid1.DataBind();
            #endregion

            #region 콤보박스
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장

            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("SOTYPE");  //발주유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "SOTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }

        #region < GRID AfterRowActivate >
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            // 그리드의 상태 정보를 STATUS BAR에 업데이트 한다.
            this.SetStatusMessage(((DataRowView)this.grid1.ActiveRow.ListObject).Row.RowError);
        }
        #endregion

        #region < TOOL BAR AREA >
        #region  < 신규 >
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            int insrtrowpos = this.grid1.InsertRow();
        }
        #endregion

        #region  < 삭제 >
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoDelete()
        {
            this.grid1.DeleteRow();
        }
        #endregion

        #region  < 조회 >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);
            // 진행중 
            try
            {
                string ls_plantcode = Convert.ToString(cboPlantCode_H.Value);
                string ls_custcode = this.txtCustCode.Text;
                string ls_custName = this.txtCustName.Text;
                string ls_itemcode = this.txtItemCode.Text;
                string ls_sostdt = string.Format("{0:yyyy-MM-dd}", cboSOSTDT.Value);
                string ls_soeddt = string.Format("{0:yyyy-MM-dd}", cboSOEDDT.Value);

                this.dtGrid1 = helper.FillTable("USP_WM4200_S1", CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTNAME", ls_custName, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SOSTDT", ls_sostdt, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SOEDDT", ls_soeddt, DbType.String, ParameterDirection.Input)
                                                   );
                grid1.DataSource = this.dtGrid1;
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }
        #endregion

        #region < 저장 >
        public override void DoSave()
        {
            this.grid1.UpdateData();
            dtGrid1 = (DataTable)grid1.chkChange(); //grid1.chkChange();

            if (dtGrid1 == null) return;

            DBHelper helper = new DBHelper("", true);
            bool issuccess = true;
            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                // C00008 : 고객사 발주서를 업로드 중입니다. 
                this.ShowProgressForm("C00008");

                DataTable dt = grid1.chkChange();

                if (dt == null)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("엑셀 업로드 후 자동 저장됩니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }

                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Added:
                            #region 

                            //2015-07-07 발주번호 체크 추가 최재형
                            if (Convert.IsDBNull(drRow["SONO"]))
                            {
                                this.ShowDialog(Common.getLangText("발주번호를 입력하세요.", "MSG"), DialogForm.DialogType.OK);
                                return;
                            }

                            //2015-07-08 발주일자 체크 추가 최재형
                            if (Convert.IsDBNull(drRow["SODATE"]))
                            {
                                this.ShowDialog(Common.getLangText("발주일자를 입력하세요.", "MSG"), DialogForm.DialogType.OK);
                                return;
                            }

                            //2015-07-08 납품요청일 체크 추가 최재형
                            if (Convert.IsDBNull(drRow["PLANSHIPDATE"]))
                            {
                                this.ShowDialog(Common.getLangText("납품요청일을 입력하세요.", "MSG"), DialogForm.DialogType.OK);
                                return;
                            }

                            //2015-07-07 NULL캐스팅 에러 발생하여 추가 최재형
                            if (Convert.IsDBNull(drRow["SEQNO"]))
                            {
                                this.ShowDialog(Common.getLangText("일련번호를 입력하세요.", "MSG"), DialogForm.DialogType.OK);
                                return;
                            }

                            //2015-07-07 NULL캐스팅 에러 발생하여 추가 최재형
                            if (Convert.IsDBNull(drRow["SOQTY"]))
                            {
                                this.ShowDialog(Common.getLangText("발주수량을 입력하세요.", "MSG"), DialogForm.DialogType.OK);
                                return;
                            }

                            DbParameter[] parametersi = new DbParameter[]
                                                    {
                                                       helper.CreateParameter("PLANTCODE",    DbType.String, Convert.ToString(cboPlantCode_H.Value)) //15-04-24 최재형 Convert.ToString(drRow["PLANTCODE"] -> Convert.ToString(cboPlantCode_H.Value)으로 수정
                                                      ,helper.CreateParameter("SONO",         DbType.String, Convert.ToString(drRow["SONO"]))
                                                      ,helper.CreateParameter("SEQNO",        DbType.String, Convert.ToInt32 (drRow["SEQNO"]))
                                                      ,helper.CreateParameter("SOTYPE",       DbType.String, Convert.ToString(drRow["SOTYPE"]))
                                                      ,helper.CreateParameter("SODATE",       DbType.String, string.Format("{0:yyyy-MM-dd}", drRow["SODATE"]))
                                                      ,helper.CreateParameter("CUSTCODE",     DbType.String, Convert.ToString(drRow["CUSTCODE"]))
                                                      ,helper.CreateParameter("ITEMCODE",     DbType.String, Convert.ToString(drRow["ITEMCODE"]))
                                                      ,helper.CreateParameter("SOQTY",        DbType.String, Convert.ToDouble(drRow["SOQTY"]))
                                                      ,helper.CreateParameter("UNITCODE",     DbType.String, Convert.ToString(drRow["UNITCODE"]))
                                                      ,helper.CreateParameter("PLANSHIPDATE", DbType.String, string.Format("{0:yyyy-MM-dd}", drRow["PLANSHIPDATE"]))
                                                      ,helper.CreateParameter("DLVYLOC",      DbType.String, Convert.ToString(drRow["DLVYLOC"]))
                                                      ,helper.CreateParameter("COUNTRYNAME",  DbType.String, Convert.ToString(drRow["COUNTRYNAME"]))
                                                      ,helper.CreateParameter("REMARK",       DbType.String, Convert.ToString(drRow["REMARK"]))
                                                      ,helper.CreateParameter("WORKERID",     DbType.String, Convert.ToString(this.WorkerID))
                                                    };
                            helper.ExecuteNoneQuery("USP_WM4200_I1", CommandType.StoredProcedure, parametersi);
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            DbParameter[] parametersu = new DbParameter[]
                                                    {
                                                       helper.CreateParameter("PLANTCODE",    DbType.String, Convert.ToString(drRow["PLANTCODE"]))
                                                      ,helper.CreateParameter("SONO",         DbType.String, Convert.ToString(drRow["SONO"]))
                                                      ,helper.CreateParameter("SEQNO",        DbType.String, Convert.ToInt32 (drRow["SEQNO"]))
                                                      ,helper.CreateParameter("SOTYPE",       DbType.String, Convert.ToString(drRow["SOTYPE"]))
                                                      ,helper.CreateParameter("SODATE",       DbType.String, Convert.ToString(drRow["SODATE"]))
                                                      ,helper.CreateParameter("CUSTCODE",     DbType.String, Convert.ToString(drRow["CUSTCODE"]))
                                                      ,helper.CreateParameter("ITEMCODE",     DbType.String, Convert.ToString(drRow["ITEMCODE"]))
                                                      ,helper.CreateParameter("SOQTY",        DbType.String, Convert.ToDouble(drRow["SOQTY"]))
                                                      ,helper.CreateParameter("UNITCODE",     DbType.String, Convert.ToString(drRow["UNITCODE"]))
                                                      ,helper.CreateParameter("PLANSHIPDATE", DbType.String, Convert.ToString(drRow["PLANSHIPDATE"]))
                                                      ,helper.CreateParameter("DLVYLOC",      DbType.String, Convert.ToString(drRow["DLVYLOC"]))
                                                      ,helper.CreateParameter("COUNTRYNAME",  DbType.String, Convert.ToString(drRow["COUNTRYNAME"]))
                                                      ,helper.CreateParameter("REMARK",       DbType.String, Convert.ToString(drRow["REMARK"]))
                                                      ,helper.CreateParameter("WORKERID",     DbType.String, Convert.ToString(this.WorkerID))
                                                    };
                            helper.ExecuteNoneQuery("USP_WM4200_U1", CommandType.StoredProcedure, parametersu);
                            #endregion
                            break;
                        case DataRowState.Deleted:
                            #region 삭제
                            DbParameter[] parametersd = new DbParameter[]
                                                    {
                                                       helper.CreateParameter("PLANTCODE",    DbType.String, Convert.ToString(drRow["PLANTCODE", DataRowVersion.Original]))
                                                      ,helper.CreateParameter("SONO",         DbType.String, Convert.ToString(drRow["SONO",      DataRowVersion.Original]))
                                                      ,helper.CreateParameter("SEQNO",        DbType.String, Convert.ToInt32 (drRow["SEQNO",     DataRowVersion.Original]))
                                                    };
                            helper.ExecuteNoneQuery("USP_WM4200_D1", CommandType.StoredProcedure, parametersd);

                            #endregion
                            break;
                    }
                    if (Convert.ToString(helper.RSCODE) == "E")
                    {
                        issuccess = false;
                        grid1.SetRowError(drRow, this.FormInformation.GetMessage(helper.RSMSG));
                        return;
                    }
                }

                this.ClosePrgFormNew();
                if (issuccess)
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("정상적으로 처리되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("입고완료된 자재는 삭제할 수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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
        #endregion
        #endregion

        #region < METHOD >
        #region<Excel UPLOAD>
        /// <summary>
        /// 고객사 주간생산계획 엑셀 파일을 읽어, 고객사일별 납품계획에 등록 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelUPbtn_Click(object sender, EventArgs e)
        {
            POP_WM4210Y pop_wm4210Y = new POP_WM4210Y();
            pop_wm4210Y.Owner = this;
            pop_wm4210Y.ShowDialog();

            //납품계획 등록 후 재조회
            DoInquire();
            pop_wm4210Y.Dispose();
        }

        private string GetItemName(string plantcode, string itemcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(ITEMNAME, '') FROM TBM0100 WHERE PLANTCODE = '" + plantcode + "' AND ITEMCODE = '" + itemcode + "'"));
            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        private string GetCustCode(string plantcode, string refcustcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(CUSTCODE, '') FROM TBM0300 WHERE PLANTCODE = '" + plantcode + "' AND REFCUSTCODE = '" + refcustcode + "'"));
            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        private string GetCustName(string plantcode, string custcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(CUSTNAME, '') FROM TBM0300 WHERE PLANTCODE = '" + plantcode + "' AND CUSTCODE = '" + custcode + "'"));
            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }


        private string GetWorkCenterName(string plantcode, string workcentercode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(WORKCENTERNAME, '') FROM TBM0600 WHERE PLANTCODE = '" + plantcode + "' AND WORKCENTERCODE = '" + workcentercode + "'"));

            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        private string GetOPName(string plantcode, string opcode)
        {
            DBHelper helper = new DBHelper();
            Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(OPNAME, '') FROM TBM0400 WHERE PLANTCODE = '" + plantcode + "' AND OPCODE = '" + opcode + "'"));

            if (rtnval == null) rtnval = "";

            return rtnval.ToString();
        }

        /// <summary>
        /// 그리드에 신규행이 추가 되었을 경우, 추가행의 각 셀의 배경색을 변경한다.
        /// </summary>
        /// <param name="grid">변경대상 그리드</param>
        /// <param name="rowid">변경대상 행</param>
        private void SetGridInsertRowAppeareance(WIZ.Control.Grid grid, int rowid)
        {
            grid.Rows[rowid].Appearance.BackColor = Color.FromArgb(0xED, 0xFB, 0xFF);
            for (int i = 0; i < grid.Rows[rowid].Cells.Count; i++)
            {
                string col = grid.Rows[rowid].Cells[i].Column.Key;
                switch ((string)grid.DisplayLayout.Bands[0].Columns[col].Tag)
                {
                    case "K":
                        grid.Rows[rowid].Cells[i].Appearance.BackColor = Color.FromArgb(0xF0, 0xFF, 0xD2);
                        break;
                    case "M":
                        grid.Rows[rowid].Cells[i].Appearance.BackColor = Color.FromArgb(0xFF, 0xFF, 0x99);
                        break;
                }
                if (grid.DisplayLayout.Bands[0].Columns[col].CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                {
                    for (int j = 0; j < grid.Rows.Count; j++)
                    {
                        grid.Rows[j].Cells[col].IgnoreRowColActivation = false;
                        grid.Rows[j].Cells[col].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                }
                else
                {
                    grid.Rows[rowid].Cells[col].IgnoreRowColActivation = true;
                    grid.Rows[rowid].Cells[col].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
            }
        }
        #endregion
        #endregion
    }
}
