#region <HEADER AREA>
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1500
//   Form Name    : 자재 LOT 병합 관리
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion <HEADER AREA>

#region <USING AREA>
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

#endregion <USING AREA>

namespace WIZ.MM
{
    public partial class MM1500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        string OldItemCode = string.Empty;  // 병합의 조건이 품목이 같은 정보야 함으로
        #endregion

        #region <CONSTRUCTOR>
        public MM1500()
        {
            InitializeComponent();
        }
        #endregion

        #region  <LOAD EVENT>
        private void MM1500_Load(object sender, EventArgs e)
        {
            //GRID SETTING
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "자재 LOT 번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "재고수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTINQTY", "최종입고수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTDATE", "재공최종반영일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.Columns["CHK"].Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.Never;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None;

            //사업장 콤보박스 데이터 바인딩
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
        }
        #endregion <LOAD EVENT>

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            StringBuilder query = null;
            try
            {

                base.DoInquire();
                txtMergeLotCount_H.Text = "";
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);            // 사업장(공장)
                string sItemCode = this.txtItemCode.Text.Trim();                            // 품목
                string sMatLotNo = this.txtMatLotNo.Text.Trim();
                OldItemCode = "";  //선택 품목 clear

                grid1.DataSource = helper.FillTable("USP_MM1500_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)             //사업부(공장)
                                                                   , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)               //품목
                                                                   , helper.CreateParameter("MATLOTNO", sMatLotNo, DbType.String, ParameterDirection.Input));             //자재 LOT 번호

                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (query != null) { query = null; }
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            txtMergeLotCount_H.Text = string.Empty;
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            string RSTMSG = string.Empty;
            DBHelper helper = new DBHelper("", true);
            StringBuilder query = null;
            base.DoSave();
            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                bool CHK = false;
                string PLANTCODE = string.Empty;
                string LOT = string.Empty;
                string PARENTLOT = string.Empty;

                bool COMPAREITEM = true;
                string PREITEMCODE = string.Empty;
                string NOWITEMCODE = string.Empty;

                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    CHK = this.grid1.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE" ? true : false;
                    PLANTCODE = Convert.ToString(this.grid1.Rows[i].Cells["PLANTCODE"].Value);
                    LOT = Convert.ToString(this.grid1.Rows[i].Cells["MATLOTNO"].Value);
                    NOWITEMCODE = Convert.ToString(this.grid1.Rows[i].Cells["ITEMCODE"].Value);

                    // 동일품목만 선택 확인
                    if (PREITEMCODE == string.Empty)
                    {
                        if (CHK == true)
                        {
                            PREITEMCODE = NOWITEMCODE;
                            PARENTLOT = LOT;
                        }
                    }
                    else
                    {
                        if (CHK == true)
                        {
                            if (PREITEMCODE != NOWITEMCODE)
                            {
                                COMPAREITEM = false;
                                break;
                            }

                            PARENTLOT = PARENTLOT + "|" + LOT;
                        }
                    }
                }

                if (COMPAREITEM == false)
                {
                    MessageBox.Show(Common.getLangText("다른 품목이 선택되어 LOT 병합을 실패하였습니다.", "MSG"), "LOT 병합 실패");
                    return;
                }
                helper.ExecuteNoneQuery("USP_MM1500_U1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_PARENT_LOT", PARENTLOT, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ENT_USER_ID", this.WorkerID, DbType.String, ParameterDirection.Input));
                helper.Commit();

            }
            catch (Exception ex)
            {

                string RSTCODE = string.Empty;
                RSTCODE = "E";
                RSTMSG = ex.Message.ToString();
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                if (query != null) { query = null; }
                DoInquire();
            }
        }
        #endregion

        #region <METHOD AREA>

        #endregion <METHOD AREA>

        #region <EVENT AREA>
        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {

            bool chk = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "TRUE" ? true : false;

            if (chk == true)
            {
                this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = false;
            }
            else
            {
                //품목 선택된 정보가 동일한지를 check 하여 동일한 경우 만 선택 되도록 한다.2014.7.23 yjlim 추가
                if ((Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["ITEMCODE"].Value) == OldItemCode) || (OldItemCode == ""))
                {
                    this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = true;
                    OldItemCode = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["ITEMCODE"].Value);  // 선택 품목
                }
                else
                {
                    MessageBox.Show("다른 품목은 LOT 병합할 수 없습니다.", "LOT 선택 문제");
                    return;
                }
            }
            this.grid1.UpdateGridData();

            int LotCnt = 0;
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (this.grid1.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                {
                    LotCnt = LotCnt + 1;
                }
            }
            txtMergeLotCount_H.Text = Convert.ToString(LotCnt);

        }

        private void btnMM1500_1_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnMM1500_2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                this.grid1.Rows[i].Cells["CHK"].Value = false;
            }
            txtMergeLotCount_H.Text = "0";
        }


        #endregion <EVENT AREA>
    }
}
