#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0050
//   Form Name    : 제품 LOT 분할/병합
//   Name Space   : WIZ.WM
//   Created Date : 2018-03-28
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0050 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();

        string OldItemCode = string.Empty;  // 선택한 품목
        int LotCnt = 0;                     // LOT 선택 갯수

        #endregion

        #region < CONSTRUCTOR >

        public WM0050()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void WM0050_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "총 수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);


            grid1.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INDATE", "입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, false);

            grid2.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region COMBO BOX
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            this.cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  //품목구분
            WIZ.Common.FillComboboxMaster(this.cbo_ITEMTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            GetWhCode();

            rtnDtTemp = _Common.GET_BM0130_CODE("");  //단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0090_CODE("");  //저장위치
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

            #endregion

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            this._GridUtil.Grid_Clear(grid1);
            this._GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                   // 사업장
                string sWHCode = Convert.ToString(cbo_WHCODE_H.Value);                      // 창고코드
                string sItemType = Convert.ToString(cbo_ITEMTYPE_H.Value);                    // 품목구분 
                string sItemCode = this.txt_ITEMCODE_H.Text;                                  // 품목
                string sLotNo = this.txt_LOTNO_H.Text;                                     // LOTNO

                rtnDtTemp = helper.FillTable("USP_WM0050_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                 // 사업장 
                                                            , helper.CreateParameter("AS_WHCODE", sWHCode, DbType.String, ParameterDirection.Input)                 // 창고코드    
                                                            , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)                 // 품목구분
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)                 // 품목                               
                                                            , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));               // LOTNO               


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();


            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void cbo_PLANTCODE_H_TextChanged(object sender, EventArgs e)
        {
            string sPlantCode = Convert.ToString(this.cbo_PLANTCODE_H.Value);

            rtnDtTemp = _Common.GET_BM0080_CODE(sPlantCode); // 창고
            WIZ.Common.FillComboboxMaster(this.cbo_WHCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            //확인 필요
            bool chk = Convert.ToString(this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "TRUE" ? true : false;
            LotCnt = 0;
            //DataTable table = new DataTable();

            if (chk == true)
            {
                this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value = false;

                //선택되지 않은 행을 테이블에서 삭제
                //table.Rows.RemoveAt(grid2.ActiveRow.Index);
            }
            else
            {
                //품목 선택된 정보가 동일한지를 check 하여 동일한 경우만 선택 되도록 한다.2014.7.23 yjlim 추가
                if ((Convert.ToString(this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["ITEMCODE"].Value) == OldItemCode) || (OldItemCode == ""))
                {
                    this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["CHK"].Value = true;
                    OldItemCode = Convert.ToString(this.grid2.Rows[this.grid2.ActiveRow.Index].Cells["ITEMCODE"].Value);  // 선택 품목

                    //선택된 행을 테이블에 삽입
                    //table.Rows.Add(grid2.ActiveRow);

                }
                else
                {
                    this.ShowDialog(Common.getLangText("다른 품목은 LOT 분할 또는 병합할 수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            //this.grid2.UpdateGridData();

            for (int i = 0; i < this.grid2.Rows.Count; i++)
            {
                if (this.grid2.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                {
                    LotCnt = LotCnt + 1;
                }
            }
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            LotCnt = 0;
            this._GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);                // 사업장
                string sWHCode = Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value);                      // 창고
                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);                  // 품목
                string sItemType = Convert.ToString(grid1.ActiveRow.Cells["ITEMTYPE"].Value);
                string sStorageLocCode = Convert.ToString(grid1.ActiveRow.Cells["STORAGELOCCODE"].Value);
                string sLotNO = this.txt_LOTNO_H.Text.ToString();

                rtnDtTemp = helper.FillTable("USP_WM0050_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                // 사업장    
                                                            , helper.CreateParameter("AS_WHCODE", sWHCode, DbType.String, ParameterDirection.Input)                // 창고
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)                // 품목
                                                            , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)                // 품목유형
                                                            , helper.CreateParameter("AS_LOTNO", sLotNO, DbType.String, ParameterDirection.Input)                // LOTNO
                                                            , helper.CreateParameter("AS_STORAGELOCCODE", sStorageLocCode, DbType.String, ParameterDirection.Input));              // 저장위치               

                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds();
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

        }

        private void btn_LOTMERGER_H_Click(object sender, EventArgs e)
        {
            if (LotCnt < 2)
            {
                this.ShowDialog(Common.getLangText("동일품목이 2개 이상 선택된 경우 병합가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }


            WM0050_POP2 wm0050_pop2 = new WM0050_POP2(this.cbo_PLANTCODE_H.Value.ToString(), this.grid2);
            wm0050_pop2.ShowDialog();
            DoInquire();
        }

        private void btn_LOTDIVISTION_B_Click(object sender, EventArgs e)
        {
            if (LotCnt != 1)
            {
                this.ShowDialog(Common.getLangText("품목이 1개 선택된 경우 분할가능합니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            DataTable dtTarget = ((DataTable)this.grid2.DataSource);
            DataRow[] drRow = dtTarget.Select();
            int i = 0;
            string ChkCheckRow = "NONCHK";
            for (i = 0; i < this.grid2.Rows.Count; i++)
            {
                if (this.grid2.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                {
                    ChkCheckRow = "CHK";
                    break;
                }
            }
            if (ChkCheckRow == "NONCHK")
            {
                this.ShowDialog(Common.getLangText("품목이 선택된 경우 분할가능합니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            WM0050_POP1 wm0050_pop1 = new WM0050_POP1(drRow[i]);
            wm0050_pop1.ShowDialog();
        }
        #endregion

        #region < METHOD AREA >
        private void GetWhCode()
        {
            DBHelper helper = new DBHelper();

            string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

            try
            {
                rtnDtTemp = helper.FillTable("USP_WM0050_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHTYPE", "WH002", DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    WIZ.Common.FillComboboxMaster(cbo_WHCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }

        }

        #endregion




    }
}


