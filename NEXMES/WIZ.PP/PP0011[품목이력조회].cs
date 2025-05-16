#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0010
//   Form Name    : 품목마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-04
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목과 품목관련 기준정보 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0011 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성
        string sSelPlantCode = "";

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public PP0011()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0011_Load(object sender, EventArgs e)
        {
            try
            {
                cbo_STARTDATE_H.Value = DateTime.Now;
                cbo_ENDDATE_H.Value = DateTime.Now;

                #region GRID SETTING

                //GRID1 품목
                _GridUtil.InitializeGrid(this.grid1, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "조립일시", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품번", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SHIPDATE", "출하일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", true, GridColDataType_emu.Double, 100, 140, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PACKNO", "박스LOT", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "포장LOT", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO1", "조립LOT 1 (HSG/COVER)", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO2", "조립LOT 2 (TPA/LEVER)", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO3", "조립LOT 3 (SLIDER,PLATE)", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RESULT", "출하상태", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);
                #endregion

                //콤보박스 셋팅
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //팝업 셋팅
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, null, null });  // 품목
                //btbManager.PopUpAdd(txt_ITEMCODE2_H, txt_ITEMNAME2_H, "BM0010", new object[] { cbo_PLANTCODE_H, null, null });  // 품목

                //GRID1 품목
                _GridUtil.InitializeGrid(this.grid2, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "포장LOT", true, GridColDataType_emu.VarChar, 200, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "생산수량", true, GridColDataType_emu.VarChar, 120, 140, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITNAME", "단위", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INLOTNO", "조립LOT", true, GridColDataType_emu.VarChar, 250, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INITEMCODE", "투입품목", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INITEMNAME", "투입품명", true, GridColDataType_emu.VarChar, 250, 140, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INLOTQTY", "소모수량", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INUNITNAME", "단위", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                sSelPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());
                //string sItemCode2 = DBHelper.nvlString(txt_ITEMCODE2_H.Text.Trim());
                //string sItemName2 = DBHelper.nvlString(txt_ITEMNAME2_H.Text.Trim());
                string sBarcode = DBHelper.nvlString(txtBarcode.Text.Trim());
                string sInBarcode = DBHelper.nvlString(txtInBarcode.Text.Trim());
                //string sInBarcode = DBHelper.nvlString(txtInBarcode.Text.Trim());

                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                grid1.SuspendLayout();

                string sInItemCode = "";

                if (rdoG1.Checked) sInItemCode = "1";
                if (rdoG2.Checked) sInItemCode = "2";
                if (rdoG3.Checked) sInItemCode = "3";

                rtnDtTemp = helper.FillTable("USP_PP0011_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sSelPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WORKCENTERCODE", "", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_STARTDATE", sSDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ENDDATE", sEDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_INITEMCODE", sInItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_INITEMNAME", "", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_BARCODE", sBarcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_INBARCODE", sInBarcode, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);
                grid1.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
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

        }

        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {
            base.DoImportExcel();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        private void btnUNPACK_Click(object sender, EventArgs e)
        {
            if (grid1.Selected.Rows.Count > 0)
            {
                int iCount = 0;

                if (this.ShowDialog(Common.getLangText("선택한 항목을 포장 취소하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                DBHelper helper = new DBHelper("", true);

                try
                {
                    foreach (UltraGridRow row in grid1.Selected.Rows)
                    {
                        string sPACKNO = DBHelper.nvlString(row.Cells["PACKNO"].Value);

                        helper.ExecuteNoneQuery("USP_DX0600_D2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sSelPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BARCODE", sPACKNO, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", sUserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "E")
                        {
                            helper.Rollback();

                            iCount = 0;

                            throw new Exception(helper.RSMSG);
                        }
                        iCount++;
                    }

                    if (iCount > 0)
                    {
                        helper.Commit();
                        MessageBox.Show("정상적으로 처리되었습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid1.Rows.Count > 0)
            {
                if (grid1.ActiveRow != null)
                {
                    string sLotno = grid1.ActiveRow.Cells["LOTNO"].Text;
                    DBHelper helper = new DBHelper(false);
                    rtnDtTemp = helper.FillTable("USP_PP0011_S2", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_PLANTCODE", sSelPlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_LOTNO", sLotno, DbType.String, ParameterDirection.Input));


                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                    grid2.ResumeLayout(false);
                }
            }
        }
    }
}