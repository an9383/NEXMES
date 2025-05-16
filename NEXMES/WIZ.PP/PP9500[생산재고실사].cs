using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP9500 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        BizTextBoxManager btbManager;
        BizGridManager gridManager;
        PopUp_Biz _biz = new PopUp_Biz();

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region [ 생성자 ]
        public PP9500()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Form Load ]
        private void PP9500_Load(object sender, EventArgs e)
        {
            #region [ Grid1 셋팅 ]
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 110, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGDT", "실사일자", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BARCODE", "LOTNO", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 70, 70, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 70, 70, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "저장위치", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMQTY", "품목수량", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "전산수량", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGQTY", "실사수량", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 60, 60, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CLOSEYN", "반영여부", false, GridColDataType_emu.VarChar, 70, 70, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGDATE", "실사반영시간", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //DtChange1 = (DataTable)grid1.DataSource;
            #endregion

            #region [ 콤보박스 및 팝업 ]
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");     //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = "1100";

            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "", "", "Y" }); //아이템 POP_UP

            GetCloseYN();

            #endregion
        }
        #endregion

        #region [ Tool Bar Area ]
        /// <summary>
        /// 조회
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sTakingDate = string.Format("{0:yyyy-MM-dd}", this.cboTakingDate_H.Value);
                string sItemCode = txtItemCode.Text.Trim();
                string sBarCode = txtBarCode.Text.Trim();
                string sCloseYN = Convert.ToString(cboCloseYN.Value);
                string sTakingYN = string.Empty;

                if (rbtnTaking.Checked == true)
                {
                    //실사
                    sTakingYN = "Y";

                    rtnDtTemp = helper.FillTable("USP_PP9500_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_FLAG", sTakingYN, DbType.String, ParameterDirection.Input)                                 // 실사여부
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                                 // 공장
                                             , helper.CreateParameter("AS_TAKINGDT", sTakingDate, DbType.String, ParameterDirection.Input)                                 // 실사일자
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)                                 // 품목
                                             , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)                                 // 바코드
                                             , helper.CreateParameter("AS_CLOSEYN", sCloseYN, DbType.String, ParameterDirection.Input));                               // 실사 반영 여부
                }
                else
                {
                    //미실사
                    sTakingYN = "N";

                    rtnDtTemp = helper.FillTable("USP_PP9500_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_FLAG", sTakingYN, DbType.String, ParameterDirection.Input)                                 // 실사여부
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                                 // 공장
                                             , helper.CreateParameter("AS_TAKINGDT", sTakingDate, DbType.String, ParameterDirection.Input)                                 // 실사일자
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)                                 // 품목
                                             , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input)                                 // 바코드
                                             , helper.CreateParameter("AS_CLOSEYN", sCloseYN, DbType.String, ParameterDirection.Input));                               // 실사 반영 여부
                }

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["TAKINGDT"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMQTY"].MergedCellStyle = MergedCellStyle.Always;

                    //grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Top;
                    grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;

                    grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        public override void DoSave()
        {
            this.grid1.UpdateData();

            if (grid1.Rows.Count == 0)
            {
                return;
            }

            int cnt = 0;

            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                {
                    cnt++;
                    break;
                }
            }

            if (cnt == 0)
            {
                this.ShowDialog(Common.getLangText("실사 적용할 대상이 없습니다. 선택 후 진행하세요.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();
                if (this.ShowDialog(Common.getLangText("생산 재고 실사 등록을 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    DoInquire();
                    return;
                }
                base.DoSave();

                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper() == "TRUE")
                    {

                        string sTakingDt = Convert.ToString(grid1.Rows[i].Cells["TAKINGDT"].Value);
                        string sNowDt = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                        string sSearchDate = string.Format("{0:yyyy-MM-dd}", cboTakingDate_H.Value);

                        if (sTakingDt == string.Empty)
                        {
                            //실사일자가 없을경우..(미실사 내용 반영 시)
                            sTakingDt = sNowDt;

                        }

                        if (sTakingDt != sSearchDate)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("실사 일자와 반영일자가 다릅니다. 실사반영을 할 수 없습니다.", "MSG"), DialogForm.DialogType.OK);
                            DoInquire();
                            return;
                        }

                        if (sTakingDt != sNowDt)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("실사 일자와 반영일자가 다릅니다. 실사반영을 할 수 없습니다.", "MSG"), DialogForm.DialogType.OK);
                            DoInquire();
                            return;
                        }

                        helper.ExecuteNoneQuery("USP_PP9500_I1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("@AS_PLANTCODE", Convert.ToString(grid1.Rows[i].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("@AS_TAKINGDT", sTakingDt, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("@AS_BARCODE", Convert.ToString(grid1.Rows[i].Cells["BARCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("@AS_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("@AS_TAKINGQTY", Convert.ToString(grid1.Rows[i].Cells["TAKINGQTY"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("@AS_WHCODE", Convert.ToString(grid1.Rows[i].Cells["WHCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("@AS_STOARAGECODE", Convert.ToString(grid1.Rows[i].Cells["STORAGELOCCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("@AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));
                    }
                }
                if (helper.RSCODE != "S")
                {
                    this.ThrowError(helper.RSCODE, helper.RSMSG);
                }
                else
                {
                    helper.Commit();
                    this.DoInquire();

                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ User Method Area ]
        /// 실사반영여부 콤보박스 정의
        /// </summary>
        private void GetCloseYN()
        {
            //자재창고
            DBHelper helper = new DBHelper(false);
            DataTable dttemp = new DataTable();

            dttemp.Columns.Add("CODE_ID", typeof(string));
            dttemp.Columns.Add("CODE_NAME", typeof(string));

            try
            {
                dttemp.Rows.Add("Y", "반영");
                dttemp.Rows.Add("N", "미반영");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }

            WIZ.Common.FillComboboxMaster(this.cboCloseYN, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "전체", "");
        }

        #endregion

        #region [ Event Area ]
        /// <summary>
        /// 반영 항목은 체크 안되도록
        /// </summary>
        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            string sCloseYN = string.Empty;
            string sValue = string.Empty;

            if (e.Cell.Column.Key == "CHK")
            {
                sCloseYN = Convert.ToString(e.Cell.Row.Cells["CLOSEYN"].Value);
                sValue = Convert.ToString(e.Cell.Value);

                if (sCloseYN == "반영")
                    e.Cell.Value = sValue;
                else
                    e.Cell.Value = (sValue == "TRUE" ? "FALSE" : "TRUE");
            }
        }

        private void grid1_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            string sCloseYN = string.Empty;
            string sValue = string.Empty;

            if (e.Cell.Column.Key == "CHK")
            {
                sCloseYN = Convert.ToString(e.Cell.Row.Cells["CLOSEYN"].Value);
                sValue = Convert.ToString(e.Cell.OriginalValue);

                if (sCloseYN == "반영")
                    e.Cancel = true;
            }
        }

        private void cboTakingDate_H_ValueChanged(object sender, EventArgs e)
        {
            int iTakingDt = Convert.ToInt32(string.Format("{0:yyyyMMdd}", this.cboTakingDate_H.Value));
            int iNowDt = Convert.ToInt32(string.Format("{0:yyyyMMdd}", DateTime.Now));

            if (iTakingDt > iNowDt)
            {
                this.ShowDialog("[" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "] 이후 날짜를 선택할 수 없습니다.", DialogForm.DialogType.OK);
                cboTakingDate_H.Value = DateTime.Now;
            }
        }

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            try
            {
                e.Row.Appearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
        }
        #endregion

    }
}
