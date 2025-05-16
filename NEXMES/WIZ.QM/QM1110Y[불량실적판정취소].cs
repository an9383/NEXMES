#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM1110Y
//   Form Name    : 불량 판정 취소
//   Name Space   : WIZ.QM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabs;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
using WIZ.REPORT;
#endregion

namespace WIZ.QM
{
    public partial class QM1110Y : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataSet rtnDsTemp = new DataSet();
        DataTable rtnDtTemp = new DataTable();
        DataTable _DtTemp = new DataTable();    //임시로 사용할 데이터테이블 생성

        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager _PopUp = new BizTextBoxManager();
        Common _Common = new Common();

        #endregion


        #region < CONSTRUCTOR >
        public QM1110Y()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENT >
        private void QM1100Y_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "발생작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "발생작업장명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "발생수불일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "생산품명", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORITEMCODE", "불량품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORITEMNAME", "불량품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORGROUP", "불량그룹", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORCODE", "불량코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORNAME", "불량사유", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITRESDATE", "판정일자", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITRES", "판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITDIV", "귀책구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITLINE", "귀책공정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITRESWORKER", "판정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITERQTY", "판정수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITYN", "판정여부", false, GridColDataType_emu.VarChar, 10, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NOTFITSTATUS", "부적합처리상태", false, GridColDataType_emu.VarChar, 10, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ POP-Up Setting ◀
            #endregion

            #region ▶ ComboBox Setting ◀
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("PLANTCODE", "10");

            CboStartdate_H.Value = DateTime.Now.AddDays(-365);
            CboEnddate_H.Value = DateTime.Now;

            cboPlantCode_H.Select();

            _PopUp.PopUpAdd(txtItemCode, txtItemName, "BM0010", new object[] { cboPlantCode_H, "", "" });
            _PopUp.PopUpAdd(txtWcCode, txtWcName, "BM0060", new object[] { cboPlantCode_H, "", "", "" });  //작업장

            #endregion
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
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                            //공장
                string sWorkCenterCode = Convert.ToString(txtWcCode.Tag);                                   //라인코드
                string sStartDate = Convert.ToDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");   //조회일자(시작)
                string sEndDate = Convert.ToDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");     //조회일자(종료)
                string sErrItem = Convert.ToString(txtItemCode.Tag);                                 //불량품목

                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_QM1110Y_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RESFLAG", "", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ERRITEM", sErrItem, DbType.String, ParameterDirection.Input));


                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBind();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoSave()
        {
            int iRows = 0;
            this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
            if (grid1.Rows.Count > 0)
            {
                /*
                foreach (DataRow dr in ((DataTable)grid1.DataSource).Rows)
                {
                    if (Convert.ToBoolean(dr["CHK"])) {  }
                }
                */
                string ls_chk = string.Empty;
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    ls_chk = Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper();
                    if (ls_chk == "TRUE") { iRows++; }
                }

                if (iRows == 0)
                {
                    this.ShowDialog(Common.getLangText("선택된 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            else
            {
                this.ShowDialog(Common.getLangText("조회된 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();

                if (this.ShowDialog(iRows.ToString() + "건의 판정처리를 취소 하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();
                grid1.UpdateData();

                UltraGridUtil.DataRowDelete(this.grid1);

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;

                        case DataRowState.Added:
                            break;

                        case DataRowState.Modified:
                            if (Convert.ToBoolean(drRow["CHK"]))
                            {
                                helper.ExecuteNoneQuery("USP_QM1110Y_D1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("AS_PLANTCODE", GetInBraket(drRow["PLANTCODE"].ToString()), DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_SEQNO", Convert.ToString(drRow["SEQNO"]), DbType.Int32, ParameterDirection.Input)
                                                       );
                            }
                            break;
                    }
                }

                ((DataTable)grid1.DataSource).AcceptChanges();
                helper.Commit();
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                helper.Rollback();
                this.ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                //DoInquire();
            }
        }

        public override void DoDownloadExcel()
        {
            //base.DoDownloadExcel();

            ExcelManager excel = new ExcelManager();
            excel.DownloadExcel(this.grid1, this.Name, false);
        }
        #endregion


        #region < EVENT AREA >
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void grid1_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (Convert.ToString(this.grid1.ActiveCell.Column).Equals("CHK"))
            {
                if (!(DBHelper.nvlString(grid1.ActiveCell.Row.Cells["NOTFITSTATUS"].Value).Equals("C")))
                    e.Cancel = true;
            }
        }

        private void grid1_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            //if (DBHelper.nvlString(e.Cell.Column).Equals("CHK"))
            //{
            //    if (!(DBHelper.nvlString(e.Cell.Row.Cells["NOTFITIFFLAG"].Value).Equals("Y") &&
            //          DBHelper.nvlString(e.Cell.Row.Cells["NOTFITSTATUS"].Value).Equals("C")))
            //    {
            //        e.Cancel = true;
            //        e.Cell.Row.Appearance.BackColor = Color.LightSteelBlue; //불량등록 및 SAP전송
            //    }
            //}
        }


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
            //    POP_TBM0100 _frmA = new POP_TBM0100( values );
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
            //    string[] values = { Convert.ToString(cboPlantCode_H.Value), "", "", "" ,"" ,"" };
            //    POP_TBM0600 _frmA = new POP_TBM0600( values );
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


        #region < USER FUNCTIONS >
        private string GetInBraket(string val)
        {
            int iFrom;
            int iTo;

            iFrom = val.IndexOf("[") + 1;
            iTo = val.IndexOf("]");

            return val.Substring(iFrom, iTo - iFrom).Trim();
        }

        private string GetOutBraket(string val)
        {
            int istart;
            istart = val.IndexOf("]") + 1;

            return val.Substring(istart, val.Length - istart).Trim();
        }

        /// <summary>
        /// 코드마스터 조회 (추가 Query)
        /// </summary>
        /// <param name="MajorCode">MAJORCODE</param>
        /// <param name="sSql">추가 Query</param>
        /// <returns></returns>
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

    }
}

