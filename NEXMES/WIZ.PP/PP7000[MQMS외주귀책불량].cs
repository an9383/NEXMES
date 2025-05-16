using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP7000 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region<CONSTRUCTOR>
        public PP7000()
        {
            InitializeComponent();
        }
        #endregion

        #region<PP7000_Load>
        private void PP7000_Load(object sender, EventArgs e)
        {
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "IF_KEY", "인터페이스키", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "팀구분", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKDATE", "작업일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "ID", "지시번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WKTIME", "작업시간(분)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERCNT", "작업인원", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PROCFLAG", "I/F상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHPROCFLAG", "I/F상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FirstDS", "초도내용", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATE", "I/F처리일시", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOT", "LOTNO", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE
            // grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            // grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE

            #region 콤보 박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("Deptcode");
            WIZ.Common.FillComboboxMaster(this.cbodeptcode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("Daynight");
            WIZ.Common.FillComboboxMaster(this.cbodaynight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ItemType");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ItemType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("IFPROCFLAG");  //I/F 상태
            WIZ.Common.FillComboboxMaster(this.cboProcFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("IFPROCFLAG", "RELCODE1 = 'Y'");  //I/F 상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProcFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboProcFlag_all, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            #endregion

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { "", "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "Y" });
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantcode = Convert.ToString(cboPlantCode_H.Value);  // 공장코드
                string sWorkdate = Convert.ToDateTime(CboStartDate_H.Value).ToString("yyyy-MM-dd");
                string sWorkdateTo = Convert.ToDateTime(cboEndDate_H.Value).ToString("yyyy-MM-dd");
                string sOpcode = txtOPCode.Text.Trim();
                string sOpname = txtOPName.Text.Trim();
                string sItemcode = txtItemCode.Text.Trim();
                string sItemname = txtItemName.Text.Trim();
                string sDeptcode = Convert.ToString(cbodeptcode.Value);
                string sDaynight = Convert.ToString(cbodaynight.Value);
                string sProcflag = Convert.ToString(cboProcFlag_H.Value);

                grid1.DataSource = helper.FillTable("USP_PP7000_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@PLANTCODE", sPlantcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@WORKDATE", sWorkdate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@WORKDATETO", sWorkdateTo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@OPCODE", sOpcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@OPNAME", sOpname, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ITEMCODE", sItemcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ITEMNAME", sItemname, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@DEPTCODE", sDeptcode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@DAYNIGHT", sDaynight, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@PROCFLAG", sProcflag, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@PARAM1", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@PARAM2", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@PARAM3", "", DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

                for (int I = 0; I < grid1.Rows.Count; I++)
                {
                    if (Convert.ToString(grid1.Rows[I].Cells["PROCFLAG"].Value.ToString()) != "N")
                    {
                        grid1.Rows[I].Cells["PROCFLAG"].IgnoreRowColActivation = true;
                        grid1.Rows[I].Cells["PROCFLAG"].Activation = Activation.NoEdit;

                        grid1.Rows[I].Cells["FirstDS"].IgnoreRowColActivation = true;
                        grid1.Rows[I].Cells["FirstDS"].Activation = Activation.NoEdit;

                    }
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
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
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlanNo"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "지시번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {

                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_PP7000_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("IF_KEY", Convert.ToString(drRow["IF_KEY"]), DbType.String, ParameterDirection.Input)         // 공장코드
                                                    , helper.CreateParameter("PROCFLAG", Convert.ToString(drRow["PROCFLAG"]), DbType.String, ParameterDirection.Input)         // 품목
                                                    , helper.CreateParameter("FIRSTDS", Convert.ToString(drRow["FirstDS"]), DbType.String, ParameterDirection.Input));       // 관리항목

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();
                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();

            }
        }
        #endregion

        #region<Event>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "QTY" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count > 0)
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Selected == true)
                    {
                        if (grid1.Rows[i].Cells["CHPROCFLAG"].Value.ToString() == "N")
                        {
                            grid1.Rows[i].Cells["PROCFLAG"].Value = cboProcFlag_all.Value.ToString();
                        }
                    }
                }
            }
        }

        //private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        //{
        //    int iRow = e.Cell.Row.Index;
        //    string  iCol = e.Cell.Column.ToString();


        //    if (iCol == "PROCFLAG")
        //    {
        //        string sPROCFLAG = grid1.Rows[iRow].Cells["PROCFLAG"].Value.ToString();
        //        string sPROCFLAG_CH = grid1.Rows[iRow].Cells["CHPROCFLAG"].Value.ToString();

        //        if (sPROCFLAG == sPROCFLAG_CH)
        //        {

        //            return;
        //        }

        //        switch (sPROCFLAG)
        //        {

        //            case "E": 
        //                {
        //                    ShowDialog("에러 상태로 변경할수 없습니다");
        //                    this.grid1.Rows[iRow].Cells["PROCFLAG"].Value = sPROCFLAG_CH;
        //                    //grid1.Rows[iRow].Selected = true;

        //                    return;
        //                }



        //            case "P":
        //                {
        //                    ShowDialog("처리중 상태로 변경할수 없습니다i");
        //                    this.grid1.Rows[iRow].Cells["PROCFLAG"].Value = sPROCFLAG_CH;
        //                    //grid1.Rows[iRow].Selected = true;
        //                    return;
        //                }



        //            case "Y":
        //                {
        //                    ShowDialog("I/F 완료 상태로 변경할수 없습니다");
        //                    this.grid1.Rows[iRow].Cells["PROCFLAG"].Value = sPROCFLAG_CH;
        //                    //grid1.Rows[iRow].Selected = true;
        //                    return;
        //                }


        //        }
        //    }

        //}        
        #endregion

    }
}
