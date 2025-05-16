#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP3500
//   Form Name    : 외주가공 출고처리
//   Name Space   : WIZ.PP
//   Created Date : 2017-04-19
//   Made By      : WIZCORE 남부사무소 개발팀 사원 윤근욱
//   Description  : 외주가공 출고처리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP3500 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        string sPlantCode = "";

        #endregion

        #region < CONSTRUCTOR >
        public PP3500()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM_LOAD >
        private void PP3500_Load(object sender, EventArgs e)
        {
            #region < GRID >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "공정재고 LOTNO", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "보관창고", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "최초입고수량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "현재고수량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX >
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = "10";

            rtnDtTemp = _Common.GET_BM0030_CODE(""); //거래처
            WIZ.Common.FillComboboxMaster(this.cboCustCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0030_CODE(""); //거래처
            WIZ.Common.FillComboboxMaster(this.cboCustCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            cboRecDate.Value = DateTime.Now;  //수불일자
            #endregion

            #region < POP-UP >
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "BM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "BM0300", new object[] { cboPlantCode_H, "" });
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sItemCode = this.txtItemCode_H.Text.Trim();
                string sLotNo = this.txtLOTNO_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_PP3500_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count <= 0)
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }

                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
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
            base.DoSave();
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        //더블클릭시 클릭된 Row 품목 정보가 출고처리의 항목에 INPUT
        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            sPlantCode = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            txtLOTNO.Text = grid1.ActiveRow.Cells["LOTNO"].Text;
            txtItemCode.Text = grid1.ActiveRow.Cells["ITEMCODE"].Text;
            cboWhCode.Value = grid1.ActiveRow.Cells["WHCODE"].Value.ToString();
            txtNowQty.Text = grid1.ActiveRow.Cells["NOWQTY"].Value.ToString();
            txtUnitCode.Text = grid1.ActiveRow.Cells["UNITCODE"].Value.ToString();
        }

        //버튼 클릭시 TPP0500Y의 재고 감소시키고, TPP0510Y에 출고이력 남기고, TPP0520에 외주출고 이력 남기기
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtLOTNO.Text.ToString() == "")
            {
                this.ShowDialog(Common.getLangText("출고할 LOT가 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (txtItemCode.Text == "")
            {
                this.ShowDialog(Common.getLangText("출고할 품목이 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (cboWhCode.Value.ToString() == "")
            {
                this.ShowDialog(Common.getLangText("재고가 출고될 창고가 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //if (cboCustCode.Value.ToString() == "")
            //{
            //    this.ShowDialog("출고시킬 거래처를 선택되지 않았습니다!");
            //    return;
            //}

            if (txtCustCode.Text.ToString() == "")
            {
                this.ShowDialog(Common.getLangText("출고시킬 거래처를 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (Convert.ToInt32(txtNowQty.Text) <= 0)
            {
                this.ShowDialog(Common.getLangText("출고수량을 확인해주세요!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog("LOTNO : " + txtLOTNO.Text + "\n품목 : " + txtItemCode.Text + "\n출고량 : " + txtNowQty.Text + "\n위의 항목을 외주 출고등록 하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                base.DoSave();

                helper.ExecuteNoneQuery("USP_PP3500_I1", CommandType.StoredProcedure
              , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(sPlantCode), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("RECDATE", DBHelper.nvlString(cboRecDate.Value), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("LOTNO", DBHelper.nvlString(txtLOTNO.Text), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("ITEMCODE", DBHelper.nvlString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("FRWHCODE", DBHelper.nvlString(cboWhCode.Value), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("TOWHCODE", DBHelper.nvlString(txtCustCode.Value), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("NOWQTY", Convert.ToDouble(txtNowQty.Text), DbType.Double, ParameterDirection.Input)
              , helper.CreateParameter("UNITCODE", DBHelper.nvlString(txtUnitCode.Text), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("MAKEDATE", DateTime.Now, DbType.DateTime, ParameterDirection.Input)
              , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("출고 되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                this.ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();

                txtLOTNO.Clear();
                txtItemCode.Clear();
                txtCustCode.Clear();
                txtCustName.Clear();
                cboWhCode.Clear();
                txtNowQty.Clear();
                txtUnitCode.Clear();
            }
        }


        #endregion

        #region < METHOD AREA >
        // Form에서 사용할 함수나 메소드를 정의
        #endregion


    }
}
