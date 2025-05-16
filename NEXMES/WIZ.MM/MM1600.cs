#region <HEADER AREA>
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1600
//   Form Name    : 자재 LOT 분할 관리
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
using WIZ.PopUp;

#endregion <USING AREA>

namespace WIZ.MM
{
    public partial class MM1600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion <MEMBER AREA>

        #region <CONSTRUCTOR>
        public MM1600()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

        }
        #endregion <CONSTRUCTOR>

        #region <LOAD EVENT>
        private void MM1600_Load(object sender, EventArgs e)
        {
            //GRID SETTING
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "자재 LOT 번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "재고수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTINQTY", "최종입고수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTDATE", "재공최종반영일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);



            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;

            //사업장 콤보박스 데이터 바인딩
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
        }
        #endregion <LOAD EVENT>

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            StringBuilder query = null;

            try
            {
                //base.DoInquire();
                // 등록 관련 정보 Clear
                txtLotNo.Text = string.Empty;
                txtItemCode2.Text = string.Empty;
                txtLotQty.Text = string.Empty;
                txtDivLotCount.Text = string.Empty;

                //////////////////////////////
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);                                        // 사업장(공장)
                string sItemCode = this.txtItemCode.Text.Trim();                                                        // 품목
                string sMatLotNo = this.txtMatLotNo.Text.Trim();                                                        //자재 LOT 번호

                grid1.DataSource = helper.FillTable("USP_MM1600_S1N", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)      //사업부(공장)
                                                             , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)        //품목
                                                             , helper.CreateParameter("MATLOTNO", sMatLotNo, DbType.String, ParameterDirection.Input));      //자재 LOT 번호



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
        /// 분할 조건 Clear
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            txtLotNo.Text = string.Empty;
            txtItemCode2.Text = string.Empty;
            txtLotQty.Text = string.Empty;
            txtDivLotCount.Text = string.Empty;
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
            string RS_MSG = string.Empty;
            string RS_CODE = string.Empty;
            DBHelper helper = new DBHelper("", true);

            StringBuilder query = null;

            try
            {
                base.DoSave();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                string PLANTCODE = string.Empty;
                string PARENTLOT = string.Empty;
                int DIVCNT = 0;

                PLANTCODE = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);              // 사업장
                PARENTLOT = Convert.ToString(txtLotNo.Text);                                              // 모 LOT
                DIVCNT = Convert.ToInt32(txtDivLotCount.Text);                                            // 분할 LOT 수

                if (PARENTLOT == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("분할할 LOT을 선택해 주세요.", "MSG"), "분할 LOT 미선택");
                    return;
                }

                // 분할 갯수에 입력된 문자열을 숫자로 변환시도하여 숫자(정수)가 아닐 시 오류 return
                if (Int32.TryParse(txtDivLotCount.Text, out DIVCNT) == false)
                {
                    MessageBox.Show(Common.getLangText("분할 갯수를 정확히 입력해 주세요.", "MSG"), "분할 갯수 입력 오류");
                    return;
                }

                this.grid1.UpdateData();

                helper.ExecuteNoneQuery("USP_MM1600_U1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("AS_PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_PARENT_LOT", PARENTLOT, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_DIV_CNT", DIVCNT, DbType.Int32, ParameterDirection.Input) // 수정
                                                       , helper.CreateParameter("AS_ENT_USER_ID", this.WorkerID, DbType.String, ParameterDirection.Input));

                helper.Commit();


                if (helper.RSCODE == "S")
                {
                    MessageBox.Show(Common.getLangText("LOT 분할을 완료하였습니다.", "MSG"), "LOT 분할 성공");
                }
                else
                {
                    MessageBox.Show(Common.getLangText("LOT 분할을 실패하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, "LOT 분할 실패");
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
            }
            finally
            {
                helper.Close();

                DoInquire();
            }


        }
        #endregion

        #region < METHOD AREA >
        // Form에서 사용할 함수나 메소드를 정의

        /// <summary>
        /// LOT 분할 버튼 선택 (ToolBar의 저장버튼과 동일)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMM1600_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        /// <summary>
        /// 분할할 LOT 선택 시 선택된 LOT 데이터 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {

            txtLotNo.Text = Convert.ToString(grid1.Rows[grid1.ActiveRow.Index].Cells["MATLOTNO"].Value);
            txtItemCode2.Text = Convert.ToString(grid1.Rows[grid1.ActiveRow.Index].Cells["ITEMCODE"].Value);
            txtItemName2.Text = Convert.ToString(grid1.Rows[grid1.ActiveRow.Index].Cells["ITEMNAME"].Value);
            txtLotQty.Text = Convert.ToString(grid1.Rows[grid1.ActiveRow.Index].Cells["STOCKQTY"].Value);
            txtDivLotCount.Text = string.Empty;
        }

        #endregion

    }
}
