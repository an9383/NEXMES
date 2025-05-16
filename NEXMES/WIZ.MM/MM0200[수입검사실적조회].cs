#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0200
//   Form Name    : 수입검사실적 관리
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA > 
        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        private string plantCode = string.Empty; //plantcode default 설정
        private string sLotno = "";
        private string sItemCode = string.Empty;

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >

        public MM0200()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");
        }

        #endregion

        #region < FORM EVENT >
        private void MM0200_Load(object sender, EventArgs e)
        {
            #region < GRID >
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "검사일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "업체명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS1", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPMATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TINSPRESULT1", "종합결과코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TINSPRESULT2", "종합결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTINSPQTY", "총 검사수", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT1", "결과코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT2", "합/불", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULTVAL", "검사값", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한치", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한치", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER", "검사자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BTN", "이미지", false, GridColDataType_emu.Button, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            string[] arrMerCol1 = { "InspCode", "InspName", "InspResult2", "InspResultVal", "SpecLSL", "SpecUSL", "WORKER", "BTN" };

            _GridUtil.GridHeaderMerge(grid1, "A", "개별판정", arrMerCol1, null);
            #endregion

            #region < COMBOBOX & POPUP >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("OKNG");  //판정
            WIZ.Common.FillComboboxMaster(this.cboInspResult_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0301", new object[] { cboPlantCode_H, "", "", "" });

            cboPlantCode_H.Value = plantCode;

            if (this.Tag != null)
            {
                string[] words = this.Tag.ToString().Split(',');
                this.txtLotNo_H.Text = words[0];
                this.cboStartDate.Value = words[1];
                this.cboEndDate.Value = words[1];
            }

            cboStartDate.Value = DateTime.Now.AddDays(-5);

            DoInquire();

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
                //  base.DoInquire();
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                                                                        // 사업장 공장코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cboStartDate.Value);                                                           // 시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate.Value);
                string sItemCode = this.txtItemCode.Text;                                                                                          // 품목     
                string sCustCode = this.txtCustCode.Text.Trim();                                                                                   // 업체코드            	
                string sInspResult = Convert.ToString(cboInspResult_H.Value);                                                                      // 검사결과     
                string sPoNo = this.txtPoNo.Text.Trim();                                                                                           // 발주번호     
                string LOTNO = this.txtLotNo_H.Text.Trim();                                                                                        // lotno

                grid1.DataSource = helper.FillTable("USP_MM0200_S1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)          // 공장(사업장) 
                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.DateTime, ParameterDirection.Input)          // 검사일자(시) 
                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.DateTime, ParameterDirection.Input)          // 검사일자(종) 
                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)          // 품목     
                                                   , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input)          // 업체코드     
                                                   , helper.CreateParameter("InspResult", sInspResult, DbType.String, ParameterDirection.Input)          // 검사결과     
                                                   , helper.CreateParameter("PoNo", sPoNo, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("LOTNO", LOTNO, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();


                //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["PoNo"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["PoNo"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["CustCode"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["CustCode"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["CustName"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["CustName"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                //grid1.DisplayLayout.Bands[0].Columns["ItemCode"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["ItemCode"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["ItemName"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["ItemName"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                //grid1.DisplayLayout.Bands[0].Columns["InspMatLotNo"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["InspMatLotNo"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["InspDate"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["InspDate"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["TInspResult1"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["TInspResult1"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["TInspResult2"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["TInspResult2"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //grid1.DisplayLayout.Bands[0].Columns["TOTINSPQTY"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["TOTINSPQTY"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                //grid1.DisplayLayout.Bands[0].Columns["LOTSTATUS1"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["LOTSTATUS1"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                grid1.DisplayLayout.Bands[0].Columns["CHK"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["CHK"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["TInspResult1"].Value.ToString() == "2")
                    {
                        grid1.Rows[i].Cells["TInspResult2"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["TInspResult2"].Appearance.ForeColor = Color.White;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion


        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            Grid1ToolAct();
        }

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {

                string sPlantCode = "";
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();
                sLotno = "";
                string sMaker = DBHelper.nvlString(this.WorkerID);

                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            if (Convert.ToString(drRow["CHK"]) == "False") continue;     // 선택되어있을경우 
                            if (Convert.ToString(drRow["InspMatLotNo"]) == sLotno) continue;  // lot no 에 대하여 1번 처리 하였을경우 (lot no 는 병합되어 여러 행으로 나타나있음)

                            helper.ExecuteNoneQuery("USP_MM0200_D1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_BARCODE", Convert.ToString(drRow["InspMatLotNo"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_LOTSTATUS", Convert.ToString(drRow["LOTSTATUS"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_WORKERID", sMaker, DbType.String, ParameterDirection.Input)
                                                   //, helper.CreateParameter("AS_QTY",       Convert.ToString(drRow["QTY"]),       DbType.String, ParameterDirection.Input)                    
                                                   //, helper.CreateParameter("AS_UNITCODE",  Convert.ToString(drRow["UNITCODE"]),  DbType.String, ParameterDirection.Input)                    
                                                   , helper.CreateParameter("AS_PONO", Convert.ToString(drRow["PONO"]), DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE != "S")
                            {
                                this.ClosePrgFormNew();
                                helper.Rollback();
                                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            this.sLotno = Convert.ToString(drRow["InspMatLotNo"]);
                            #endregion
                            break;
                    }
                }

                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();

                    this.DoInquire();
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
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

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            string sFinishFlag = string.Empty;
            string sInsplotno = string.Empty;
            string sInspcode = string.Empty;

            try
            {
                sInsplotno = Convert.ToString(e.Cell.Row.Cells["InspMatLotNo"].Value);
                sInspcode = Convert.ToString(e.Cell.Row.Cells["InspCode"].Value);
                DataTable dtTarget = ((DataTable)this.grid1.DataSource);
                DataRow[] drRow = dtTarget.Select("InspMatLotNo = '" + sInsplotno + "' AND InspCode ='" + sInspcode + "'");

                POP_MM0200 pop_MM0200 = new POP_MM0200(drRow[0]);
                pop_MM0200.ShowDialog();

                //   POP_MM0900 pop_mm0900 = new POP_MM0900(drRow[0]);
                //   pop_mm0900.ShowDialog();


                this.DoInquire();

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            MM9900.CustomMergedCellEvalutor CM1 = new MM9900.CustomMergedCellEvalutor("InspMatLotNo", "InspDate");
            e.Layout.Bands[0].Columns["InspDate"].MergedCellEvaluator = CM1;

            MM9900.CustomMergedCellEvalutor CM2 = new MM9900.CustomMergedCellEvalutor("InspMatLotNo", "TInspResult1");
            e.Layout.Bands[0].Columns["TInspResult1"].MergedCellEvaluator = CM2;

            MM9900.CustomMergedCellEvalutor CM6 = new MM9900.CustomMergedCellEvalutor("InspMatLotNo", "TInspResult2");
            e.Layout.Bands[0].Columns["TInspResult2"].MergedCellEvaluator = CM6;

            MM9900.CustomMergedCellEvalutor CM3 = new MM9900.CustomMergedCellEvalutor("InspMatLotNo", "TOTINSPQTY");
            e.Layout.Bands[0].Columns["TOTINSPQTY"].MergedCellEvaluator = CM3;

            MM9900.CustomMergedCellEvalutor CM4 = new MM9900.CustomMergedCellEvalutor("InspMatLotNo", "LOTSTATUS1");
            e.Layout.Bands[0].Columns["LOTSTATUS1"].MergedCellEvaluator = CM4;

            MM9900.CustomMergedCellEvalutor CM5 = new MM9900.CustomMergedCellEvalutor("InspMatLotNo", "CHK");
            e.Layout.Bands[0].Columns["CHK"].MergedCellEvaluator = CM5;
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            //string sMatLotNo = "";
            //if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "CHK")
            //{
            //    sMatLotNo = Convert.ToString(this.grid1.ActiveRow.Cells["InspMatLotNo"].Value);
            //    for (int i = 0; i < this.grid1.Rows.Count; i++)
            //    {
            //        if (sMatLotNo == Convert.ToString(grid1.Rows[i].Cells["InspMatLotNo"].Value))
            //        {
            //            if (Convert.ToString(this.grid1.Rows[i].Cells["CHK"].Value) == "True")
            //            {
            //                this.grid1.Rows[i].Cells["CHK"].Value = false;
            //            }
            //            else this.grid1.Rows[i].Cells["CHK"].Value = true;
            //        }
            //    }
            //}

            string sMatLotNo = Convert.ToString(this.grid1.ActiveRow.Cells["InspMatLotNo"].Value);

            for (int i = 0; i < this.grid1.Rows.Count; i++)
            {
                if (sMatLotNo == Convert.ToString(grid1.Rows[i].Cells["InspMatLotNo"].Value))
                {
                    if (Convert.ToString(this.grid1.Rows[i].Cells["CHK"].Value) == "True")
                    {
                        this.grid1.Rows[i].Cells["CHK"].Value = false;
                    }
                    else this.grid1.Rows[i].Cells["CHK"].Value = true;
                }
            }
        }

        private void gbxHeader_Click(object sender, EventArgs e)
        {

        }
    }
}


