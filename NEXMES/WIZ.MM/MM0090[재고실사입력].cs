#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0090
//   Form Name    : 재고실사입력
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-28
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고실사입력
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0090 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable dtGrid = new DataTable();
        int SAVEFLAG = 2; // 1. 전산상의 창고에 없는 LOT 추가 시, 저장
                          // 2. 전산상의 창고와 PP0130(실사수량 입력내용)에 있는 LOT의 수량, 실사사유 저장
                          // 1, 2 구분하기 위해 사용.
        #endregion

        #region < CONSTRUCTOR >

        public MM0090()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM EVENT >
        private void MM0090_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDDATE", "지시일자", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHTYPE", "창고구분", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDREMARK", "실사사유", false, GridColDataType_emu.VarChar, 300, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHTYPE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGORDREMARK", Infragistics.Win.HAlign.Left);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "BARCODE", "LOTNO", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "전산수량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TAKINGQTY", "실사수량", false, GridColDataType_emu.VarChar, 100, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "실사반영사유", false, GridColDataType_emu.VarChar, 300, true, true);

            _GridUtil.SetColumnTextHAlign(grid2, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid2, "TAKINGQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "NOWQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid2, "REMARK", Infragistics.Win.HAlign.Left);

            grid2.DisplayLayout.Bands[0].Columns["NOWQTY"].Format = "#,##0";
            grid2.DisplayLayout.Bands[0].Columns["TAKINGQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region < COMBOBOX SETTING >

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE"); //창고구분
            WIZ.Common.FillComboboxMaster(this.cbo_WHTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            GetWhCode("", grid1);

            BizGridManager bizGridManager = new BizGridManager(grid2);
            bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "" });

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// 조회
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
            string sStartDate = Convert.ToString(cbo_STARTDATE_H.Value);
            string sEndDate = Convert.ToString(cbo_ENDDATE_H.Value);
            string sWhType = Convert.ToString(cbo_WHTYPE_H.Value);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0090_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBind();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
                return;
            }
            finally
            {
                helper.Close();
            }
        }
        public override void DoNew()
        {
            try
            {
                if (grid1.Rows.Count == 0)
                    return;

                base.DoNew();

                this.grid2.InsertRow();

                if (Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value) != "창고 전체")
                {
                    grid2.ActiveRow.Cells["WHCODE"].Value = grid1.ActiveRow.Cells["WHCODE"].Value;
                    grid2.ActiveRow.Cells["WHCODE"].Activation = Activation.NoEdit;
                }

                grid2.ActiveRow.Cells["BARCODE"].Activation = Activation.AllowEdit;
                grid2.ActiveRow.Cells["ITEMCODE"].Activation = Activation.AllowEdit;
                grid2.ActiveRow.Cells["ITEMNAME"].Activation = Activation.AllowEdit;

                grid2.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["NOWQTY"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["TAKINGQTY"].Activation = Activation.AllowEdit;
                grid2.ActiveRow.Cells["REMARK"].Activation = Activation.AllowEdit;

                grid2.ActiveRow.Cells["PLANTCODE"].Value = Convert.ToString(this.cbo_PLANTCODE_H.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                string sTakingOrdNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);
                string sWhType = Convert.ToString(grid1.ActiveRow.Cells["WHTYPE"].Value);

                if (this.ShowDialog("변경된 사항을 저장하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
                    return;

                dtGrid = (DataTable)grid2.DataSource;

                foreach (DataRow drRow in dtGrid.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        {
                            ShowDialog(Common.getLangText("품목은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["BARCODE"]) == string.Empty)
                        {
                            ShowDialog(Common.getLangText("LOT No는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["ITEMCODE"]) == string.Empty)
                        {
                            ShowDialog(Common.getLangText("품목은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }

                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("USP_MM0090_I1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_WHCODE", Convert.ToString(drRow["WHCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_LOTNO", Convert.ToString(drRow["BARCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_NOWQTY", Convert.ToString(drRow["NOWQTY"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_TAKINGQTY", Convert.ToString(drRow["TAKINGQTY"]), DbType.String, ParameterDirection.Input)
                                                                   //, helper.CreateParameter("AS_UNITCODE",  Convert.ToString(drRow["UNITCODE"]),  DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            break;
                        case DataRowState.Added:
                            helper.ExecuteNoneQuery("USP_MM0090_I2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_WHCODE", Convert.ToString(drRow["WHCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_LOTNO", Convert.ToString(drRow["BARCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_NOWQTY", Convert.ToString(drRow["NOWQTY"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_TAKINGQTY", Convert.ToString(drRow["TAKINGQTY"]), DbType.String, ParameterDirection.Input)
                                                                   //, helper.CreateParameter("AS_UNITCODE",  Convert.ToString(drRow["UNITCODE"]),  DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            break;
                    }

                }

                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire();
                }
                else
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    helper.Rollback();
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoImportExcel()
        {
            if (grid1.Rows.Count == 0)
            {
                this.ShowDialog(Common.getLangText("데이터를 조회 한 후 진행하세요", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            base.DoImportExcel();

            dtGrid = (DataTable)grid2.DataSource;
            string sWhType = Convert.ToString(grid1.ActiveRow.Cells["WHTYPE"].Value);

            MM0090_EXCEL mm0090_excel = new MM0090_EXCEL(dtGrid, sWhType);
            mm0090_excel.ShowDialog();

            grid2.DataSource = mm0090_excel.dtTemp;
        }
        #endregion

        #region < USER METHOD AREA >

        private void GetWhCode(string sWhType, WIZ.Control.Grid grid)
        {
            DBHelper helper = new DBHelper(false);


            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0090_S5", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input));

                WIZ.UltraGridUtil.SetComboUltraGrid(grid, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

        #region < EVENT AREA >

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            GetWhCode(Convert.ToString(grid1.ActiveRow.Cells["WHTYPE"].Value), grid2);

            try
            {
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sTakingOrdNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);

                rtnDtTemp = helper.FillTable("USP_MM0090_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds();

                        for (int i = 0; i < grid2.Rows.Count; i++)
                        {
                            grid2.Rows[i].Cells["PLANTCODE"].Activation = Activation.NoEdit;
                            grid2.Rows[i].Cells["BARCODE"].Activation = Activation.NoEdit;
                            grid2.Rows[i].Cells["WHCODE"].Activation = Activation.NoEdit;
                            grid2.Rows[i].Cells["ITEMCODE"].Activation = Activation.NoEdit;
                            grid2.Rows[i].Cells["ITEMNAME"].Activation = Activation.NoEdit;
                            grid2.Rows[i].Cells["UNITCODE"].Activation = Activation.NoEdit;
                            grid2.Rows[i].Cells["NOWQTY"].Activation = Activation.NoEdit;
                        }
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }


        }

        #endregion


    }
}
