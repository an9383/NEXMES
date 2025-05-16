#region ▶ HEADER AREA 
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM4100
//   Form Name    : 고객사 납품계획
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region ▶ USING AREA 
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM4100 : WIZ.Forms.BaseMDIChildForm
    {
        #region ▶ MEMBER AREA 
        System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();

        BizTextBoxManager btbManager = new BizTextBoxManager();

        // return DataTable
        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid1 = new DataTable();
        DataTable dtSource = new DataTable();
        #endregion

        #region ▶ Form Initialize
        /// <summary>
        /// Initialize
        /// </summary>
        public WM4100()
        {
            InitializeComponent();
        }
        #endregion

        #region ▶ Form Load Event
        private void WM4100_Load(object sender, EventArgs e)
        {
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "", "", "", "" });     //작업장 POP_UP
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" }); //품목

            dtpBaseDt.Value = DateTime.Now;

            //-- GridInitialize
            GridInit();
            //--

            //-- 사업장 ComboBox
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            //--
        }
        #endregion

        #region ▶ Grid Initialize
        /// <summary>
        /// Grid Initialize
        /// </summary>
        private void GridInit()
        {
            try
            {
                // InitColumnUltraGrid
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "IDX", "항목번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "GUBUN", "항목", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

                for (int i = 0; i < 31; i++)
                {
                    //_GridUtil.InitColumnUltraGrid(grid1, "D" + i.ToString("00"), "D+" + i.ToString("#,###0"), false, GridColDataType_emu.Double, 60, 100, Infragistics.Win.HAlign.Right, true,  false,  "#,###0", null, null, null, null);
                    _GridUtil.InitColumnUltraGrid(grid1, "D" + i.ToString("00"), "D+" + i.ToString("#,###0"), false, GridColDataType_emu.IntegerNonNegative, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                }

                _GridUtil.SetInitUltraGridBind(grid1);

                this.grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["IDX"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["GUBUN"].Header.Fixed = true;

                _GridUtil.SetColumnMerge(this, grid1, "PLANTCODE");
                _GridUtil.SetColumnMerge(this, grid1, "CUSTCODE");
                _GridUtil.SetColumnMerge(this, grid1, "CUSTNAME");
                _GridUtil.SetColumnMerge(this, grid1, "ITEMCODE");
                _GridUtil.SetColumnMerge(this, grid1, "ITEMNAME");

                grid1.DisplayLayout.Appearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["IDX"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["GUBUN"].CellAppearance.BackColor = Color.White;

                for (int i = 0; i < 31; i++)
                {
                    grid1.DisplayLayout.Bands[0].Columns["D" + i.ToString("00")].CellAppearance.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region ▶ GRID AfterRowActivate 
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            // 그리드의 상태 정보를 STATUS BAR에 업데이트 한다.
            //this.SetStatusMessage(((DataRowView)this.grid1.ActiveRow.ListObject).Row.RowError);
        }
        #endregion

        #region ▶ TOOL BAR AREA 
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);

            try
            {
                string ls_plantcode = Convert.ToString(cboPlantCode_H.Value);
                string ls_plandate = string.Format("{0:yyyy-MM-dd}", dtpBaseDt.Value);
                string ls_custcode = this.txtCustCode.Text;
                string ls_itemcode = this.txtItemCode.Text;

                this.dtSource = helper.FillTable("USP_WM4100Y_S1", CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_BASEDT", ls_plandate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input));

                if (this.dtSource.Rows.Count == 0)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("고객사의 생산계획이 없습니다. 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                grid1.DataSource = this.dtSource;
                grid1.DataBinds();
                this.ClosePrgFormNew();
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

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoDelete()
        {
        }

        /// <summary>
        /// ToolBar의 저장 버튼 클릭
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);
            bool issuccess = true;

            try
            {
                //this.Focus();
                this.grid1.UpdateData();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                // 진행중 
                this.ShowProgressForm("C00007");
                // 업데이트 데이터       

                foreach (DataRow drRow in dtSource.Rows)
                {
                    switch (drRow.RowState)
                    {

                        case DataRowState.Added:
                            #region 추가
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            string ls_plantcode = Convert.ToString(drRow["PLANTCODE"]);
                            string ls_custcode = Convert.ToString(drRow["CUSTCODE"]);
                            string ls_itemcode = Convert.ToString(drRow["ITEMCODE"]);
                            string ls_maker = this.WorkerID.Trim();
                            string ls_plandate = string.Empty;
                            string ls_saleqty = string.Empty;
                            string ls_ToDay = DateTime.Now.ToString("dd");
                            string ls_planday = string.Empty;


                            for (int i = 0; i < 31; i++)
                            {
                                ls_plandate = string.Format("{0:yyyy-MM-dd}", ((DateTime)this.dtpBaseDt.Value).AddDays(i));
                                ls_planday = string.Format("{0:dd}", ((DateTime)this.dtpBaseDt.Value).AddDays(i));
                                ls_saleqty = Convert.ToString(drRow["D" + i.ToString("00")]);

                                if (Convert.ToInt32(ls_ToDay) <= Convert.ToInt32(ls_planday))
                                {
                                    helper.ExecuteNoneQuery("USP_WM4100Y_U1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_PLANDATE", ls_plandate, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_PSQTY", ls_saleqty, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input));

                                    if (Convert.ToString(helper.RSCODE) == "E")
                                    {
                                        issuccess = false;
                                        this.ShowDialog(ls_plandate + "일자[" + ls_plandate + "]의 품목[" + ls_itemcode + "]\r\n정보처리 오류가 발생했습니다. \r\n" + helper.RSMSG.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
                                    }
                                }
                            }
                            #endregion
                            break;
                        case DataRowState.Deleted:
                            #region 삭제
                            #endregion
                            break;
                    }

                }

                this.ClosePrgFormNew();
                if (issuccess)
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("정상적으로 처리되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(Common.getLangText("납품계획 등록중 오류가 발생했습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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

        #region ▶ METHOD 
        /// <summary>
        /// 숫자인지 체크
        /// </summary>
        /// <param name="_RecVal"></param>
        /// <returns></returns>
        private bool _IsNumber(string _RecVal)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d]+");

            if (!regex.IsMatch(_RecVal)) { return true; } else { return false; }
        }

        //이전날짜에 대한 입력 가능 여부 확인
        private bool _InputYN(string gColKey)
        {
            try
            {
                UltraGridCell cell = grid1.ActiveCell;

                DateTime today = DateTime.Now;
                DateTime searchDate = Convert.ToDateTime(dtpBaseDt.Value);

                if (searchDate.CompareTo(DateTime.Now) < 0)
                {
                    int tDay1 = Convert.ToInt32(string.Format("{0:dd}", today).Trim());      //금일 일자
                    int tDay2 = Convert.ToInt32(string.Format("{0:dd}", searchDate).Trim()); //금일 일자
                    string tMonth1 = string.Format("{0:yyyyMM}", today).Trim();                   //금일 년월일
                    string tMonth2 = string.Format("{0:yyyyMM}", searchDate).Trim();              //조회 기준일자

                    if (string.Compare(tMonth1, tMonth2) == 0)
                    {
                        //금일과 같은 월의 금일 이전일자 수정 불가.
                        if (Convert.ToInt32(tDay1) < Convert.ToInt32(tDay2))
                            return false;
                    }
                    else if (string.Compare(tMonth1, tMonth2) > 0)
                    {   //당월이 아닌 날짜는 수정 불가 처리.
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        /// <summary>
        /// Grid Click Cell Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            try
            {
                if (grid1.Rows.Count < 1) return;

                //편집모드 Exit 처리
                grid1.PerformAction(UltraGridAction.ExitEditMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //--
                UltraGridCell cell = grid1.ActiveCell;

                //이전날짜에 대한 입력 제어
                if (_InputYN(cell.Column.Key) == false)
                {
                    MessageBox.Show(Common.getLangText("당월이 아니거나 금일보다 이전 일자는 입력이 불가 합니다.", "MSG"), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (Convert.ToString(grid1.Rows[cell.Row.Index].Cells["GUBUN"].Value))
                {
                    case "계획납품량":
                        if (e.KeyChar == 13) { return; }
                        else if (e.KeyChar == 8)
                        {
                            string sValue = Convert.ToString(grid1.Rows[cell.Row.Index].Cells[cell.Column.Index].Value);
                            string subStrValue = string.Empty;

                            if (sValue.Trim().Length == 1) { subStrValue = "0"; }
                            if (sValue.Trim().Length > 1)
                            {
                                subStrValue = sValue.Trim().Substring(0, sValue.Trim().Length - 1);
                            }

                            grid1.Rows[cell.Row.Index].Cells[cell.Column.Key].Value = subStrValue;
                        }
                        else if (e.KeyChar == 9) { SendKeys.Send("{TAB}"); }
                        else
                        {
                            if (_IsNumber(Convert.ToString(e.KeyChar))) { grid1.Rows[cell.Row.Index].Cells[cell.Column.Key].Value += Convert.ToString(e.KeyChar); }
                            else { MessageBox.Show(Common.getLangText("숫자만 입력 가능 합니다.", "MSG"), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                        break;
                    default:
                        break;

                }
                //--
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("IDX", "GUBUN");

            for (int i = 0; i < 31; i++)
            {
                e.Layout.Bands[0].Columns["D" + i.ToString("00")].MergedCellEvaluator = CM1;
            }
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                UltraGridCell cell = grid1.ActiveCell;

                //이전날짜에 대한 입력 제어
                if (_InputYN(cell.Column.Key) == false)
                {
                    MessageBox.Show(Common.getLangText("당월이 아니거나 금일보다 이전 일자는 입력이 불가 합니다.", "MSG"), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (e.KeyCode.ToString())
                {
                    case "Delete":
                        grid1.Rows[cell.Row.Index].Cells[cell.Column.Index].Value = "0";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePlan_Click(object sender, EventArgs e)
        {

            if (this.ShowDialog(Common.getLangText("납품수량을 확정 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                string ls_plantcode = Convert.ToString(cboPlantCode_H.Value);
                string ls_basedate = string.Format("{0:yyyy-MM-dd}", dtpBaseDt.Value);
                string ls_msker = this.WorkerID.Trim();

                helper.ExecuteNoneQuery("USP_WM4100_T1", CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_BASEDT", ls_basedate, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", ls_msker, DbType.String, ParameterDirection.Input));

                if (Convert.ToString(helper.RSCODE) == "S")
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("정상적으로 처리되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(Common.getLangText("납품계획 등록중 오류가 발생했습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }

                this.ClosePrgFormNew();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
    }

    #region ▶ CustomMergedCellEvalutor Class
    public class CustomMergedCellEvalutor : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
    {
        string Col1 = string.Empty;
        string Col2 = string.Empty;

        public CustomMergedCellEvalutor(string pCol1, string pCol2)
        {
            Col1 = pCol1;
            Col2 = pCol2;
        }

        public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1,
                                  Infragistics.Win.UltraWinGrid.UltraGridRow row2,
                                  Infragistics.Win.UltraWinGrid.UltraGridColumn col)
        {
            try
            {
                if (row1.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                    && row2.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                    && row1.GetCellValue(Col2).GetType().ToString() != "System.DBNull"
                    && row2.GetCellValue(Col2).GetType().ToString() != "System.DBNull")
                {
                    string value1 = (string)row1.GetCellValue(Col1);
                    string value2 = (string)row2.GetCellValue(Col1);

                    string value3 = (string)row1.GetCellValue(Col2);
                    string value4 = (string)row2.GetCellValue(Col2);

                    return (value1 + value3) == (value2 + value4);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
    #endregion
}
