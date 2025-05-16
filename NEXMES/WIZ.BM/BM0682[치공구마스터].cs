#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : 수주 현황
//   Name Space   : WIZ.BM
//   Created Date : 2019-11-11
//   Made By      : 기술연구소 최문준
//   Description  : 수주 현황 정보를 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0682 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();
        DataTable dtGrid3 = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public BM0682()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0682_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "치공구코드", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "치공구이름", false, GridColDataType_emu.VarChar, 120, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE", "치공구타입", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE1", "치공구타입1", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE2", "치공구타입2", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAXCOUNT", "최대수량", false, GridColDataType_emu.Double, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "NOWCOUNT", "현재수량", false, GridColDataType_emu.Double, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CYCLECOUNT", "점검주기", false, GridColDataType_emu.Double, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPCOUNT", "최종점검수량", false, GridColDataType_emu.Double, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종점검일자", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "고객사코드", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델이름", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼번호", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BUYDATE", "구매일자", false, GridColDataType_emu.YearMonthDay, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "최대사용일수", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LIMITDATE", "한계날짜", false, GridColDataType_emu.YearMonthDay, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용유무", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, true, true);

                _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "MAXCOUNT", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "NOWCOUNT", Infragistics.Win.HAlign.Right);

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MOLDCODE", "치공구코드", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "OPNAME", "공정코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "USEQTY", "사용량비율", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKLIMITQTY", "연속사용량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKLIMITTIME", "연속사용시간(분)", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);


                _GridUtil.SetInitUltraGridBind(grid2);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;


                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");



                bizGrid1Manager = new BizGridManager(grid1);
                bizGrid1Manager.PopUpAdd("CustCode", "CustName", "BM0030", new string[] { "PlantCode", "", "Y" });

                bizGrid2Manager = new BizGridManager(grid2);
                bizGrid2Manager.PopUpAdd("Opcode", "OpName", "BM0040", new string[] { "PlantCode", "", "Y" });
                bizGrid2Manager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });  // 품목
                btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });       // 공정         
                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "" });   //거래처

                //bizGrid2Manager.PopUpClosed += BizGridManager_PopUpClosed;

                #endregion

                //dtGrid = (DataTable)grid1.DataSource;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        private void BizGridManager_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
            //if (bFindOK)
            //{

            //    DBHelper helper = new DBHelper(false);

            //    string sPlantCode = CModule.ToString(grid.ActiveRow.Cells["PLANTCODE"].Value);
            //    string sContractNo = CModule.ToString(grid.ActiveRow.Cells["CONTRACTNO"].Value);
            //    string sContractSeq = CModule.ToString(grid.ActiveRow.Cells["SEQ"].Value);

            //    DataSet ds = helper.FillDataSet("USP_AP0110_S4", CommandType.StoredProcedure
            //           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_ITEMCODE", sCode, DbType.String, ParameterDirection.Input));

            //    if (ds.Tables.Count >= 1)
            //    {
            //        if (ds.Tables[0].Rows.Count >= 1)
            //        {
            //            grid.ActiveRow.Cells["UNITCODE"].Value = CModule.ToString(ds.Tables[0].Rows[0]["UNITCODE"]);
            //            grid.ActiveRow.Cells["NOWQTY"].Value = CModule.ToString(ds.Tables[0].Rows[0]["NOWQTY"]);
            //        }
            //    }

            //    if (ds.Tables.Count >= 2)
            //    {
            //        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //        {
            //            if (CModule.ToString(ds.Tables[1].Rows[i]["CONTRACTNO"]) == sContractNo && CModule.ToString(ds.Tables[1].Rows[i]["CONTRACTSEQ"]) == sContractSeq)
            //            {
            //                grid.ActiveRow.Cells["OUTQTY"].Value = string.Format("{0:#,##0}", CModule.ToDouble(ds.Tables[1].Rows[i]["OUTQTY"]));
            //                break;
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid1.DisplayLayout.Bands[0].Columns["REMARK"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            //grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.White;
            //grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.White;

            //grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid2.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid2.DisplayLayout.Bands[0].Columns["CLOSEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            try
            {
                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sUseFlag = CModule.ToString(cbo_USEFLAG_H.Value);

                string sCustCode = CModule.ToString(txt_CUSTCODE_H.Text.Trim());
                string sMoldCode = CModule.ToString(txt_MOLDCODE_H.Text.Trim());

                string sOpCode = CModule.ToString(txt_OPCODE_H.Text.Trim());
                string sItemCode = CModule.ToString(txt_ITEMCODE_H.Text.Trim());

                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);


                base.DoInquire();

                dtGrid = helper.FillTable("USP_BM0682_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("PCCODE", "S1", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                if (dtGrid.Rows.Count > 0)
                {
                    grid1.DataSource = dtGrid;
                    grid1.DataBinds(dtGrid);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoNew()
        {

            try
            {

                base.DoNew();
                if (grid1.IsActivate)
                {
                    if (bNew)
                    {
                        this.ShowDialog(Common.getLangText("입력 중인 그리드가 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                    AddGrid1Row();
                }
                else if (grid2.IsActivate)
                {

                    if (grid1.ActiveRow == null)
                    {
                        this.ShowDialog(Common.getLangText(grid1.Columns["MOLDCODE"].Header.Caption.ToString() + " 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    int iRow = grid2.InsertRow();
                    grid2.Rows[iRow].Cells["PLANTCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    grid2.Rows[iRow].Cells["MOLDCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                    grid2.Rows[iRow].Cells["PLANTCODE"].Activation = Activation.Disabled;
                    grid2.Rows[iRow].Cells["MOLDCODE"].Activation = Activation.Disabled;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }

        private void AddGrid1Row()
        {
            //_GridUtil.Grid_Clear(grid1);
            //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);

            int iRow = grid1.InsertRow();

            grid1.Rows[iRow].Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            grid1.Rows[iRow].Cells["MOLDCODE"].Value = "[ NEW MOLDCODE ]";
            grid1.Rows[iRow].Cells["BUYDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            grid1.Rows[iRow].Cells["USEFLAG"].Value = "Y";

            grid1.Rows[iRow].Cells["NOWCOUNT"].Activation = Activation.Disabled;

            grid1.UpdateData();

            _GridUtil.Grid_Clear(grid2);
        }

        public override void DoDelete()
        {
            //base.DoDelete();

            //this.grid2.DeleteRow();
            DBHelper helper = new DBHelper("", true);

            string sPlantCode = "";
            string sMoldCode = string.Empty;
            string sMoldName = string.Empty;
            string sMoldType = string.Empty;
            string sMoldType1 = string.Empty;
            string sMoldType2 = string.Empty;
            int sMaxCount = 0;
            float sNowCount = 0;
            int sCycleCount = 0;
            int sInspCount = 0;
            string sInspLastDate = string.Empty;
            string sCustCode = string.Empty;
            string sMakeCompany = string.Empty;
            string sMoldLName = string.Empty;
            string sSerialNo = string.Empty;
            string sBuyDate = string.Empty;
            int sLifeTime = 0;
            string sLimitDate = string.Empty;
            string sUseFlag = string.Empty;
            string sItemCode = string.Empty;
            string sRemark = string.Empty;
            string sUser = LoginInfo.UserID;
            string sOpCode = string.Empty;
            float sUseQty = 0;
            float sWorkLimitTime = 0;
            int sWorkLimitQty = 0;


            try
            {

                if (grid1.IsActivate)
                {
                    //this.grid2.DeleteRow();
                    DataRow dr = null;
                    dr = (grid1.ActiveRow.ListObject as DataRowView).Row;

                    if (this.ShowDialog(Common.getLangText("선택 정보를 삭제 하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (dr != null)
                        {
                            sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                            sMoldCode = CModule.ToString(dr["MOLDCODE"]);
                            sMoldName = CModule.ToString(dr["MOLDNAME"]);
                            sMoldType = CModule.ToString(dr["MOLDTYPE"]);
                            sMoldType1 = CModule.ToString(dr["MOLDTYPE1"]);
                            sMoldType2 = CModule.ToString(dr["MOLDTYPE2"]);
                            sMaxCount = CModule.ToInt32(dr["MAXCOUNT"]);
                            sCycleCount = CModule.ToInt32(dr["CYCLECOUNT"]);
                            sCustCode = CModule.ToString(dr["CUSTCODE"]);
                            sMakeCompany = CModule.ToString(dr["MAKECOMPANY"]);
                            sMoldLName = CModule.ToString(dr["MODELNAME"]);
                            sSerialNo = CModule.ToString(dr["SERIALNO"]);
                            sBuyDate = CModule.ToDateString(dr["BUYDATE"]);
                            sLifeTime = CModule.ToInt32(dr["LIFETIME"]);
                            sLimitDate = CModule.ToDateString(dr["LIMITDATE"]);
                            sUseFlag = CModule.ToString(dr["USEFLAG"]);
                            sRemark = CModule.ToString(dr["REMARK"]);
                            sUser = LoginInfo.UserID;


                            helper.ExecuteNoneQuery("USP_BM0682_U1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("PC_CODE", "D1", DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MOLDNAME", sMoldName, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MOLDTYPE", sMoldType, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MOLDTYPE1", sMoldType1, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MOLDTYPE2", sMoldType2, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MAXCOUNT", sMaxCount, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CYCLECOUNT", sCycleCount, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MAKECOMPANY", sMakeCompany, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MODELNAME", sMoldLName, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SERIALNO", sSerialNo, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_BUYDATE", sBuyDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_LIFETIME", sLifeTime, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_LIMITDATE", sLimitDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "S")
                            {
                                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                helper.Commit();
                                DoInquire();
                            }
                            else
                            {
                                throw new Exception("저장 되지 않습니다. " + helper.RSMSG);
                            }

                        }

                    }
                }

                if (grid2.IsActivate)
                {
                    //this.grid2.DeleteRow();
                    DataRow dr = null;
                    dr = (grid2.ActiveRow.ListObject as DataRowView).Row;

                    if (this.ShowDialog(Common.getLangText("선택 정보를 삭제 하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (dr != null)
                        {
                            sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                            sMoldCode = CModule.ToString(dr["MOLDCODE"]);
                            sOpCode = CModule.ToString(dr["OPCODE"]);
                            sItemCode = CModule.ToString(dr["ITEMCODE"]);
                            sUseQty = CModule.ToFloat(dr["USEQTY"]);
                            sWorkLimitTime = CModule.ToFloat(dr["WORKLIMITTIME"]);
                            sWorkLimitQty = CModule.ToInt32(dr["WORKLIMITQTY"]);
                            sUser = LoginInfo.UserID;

                            helper.ExecuteNoneQuery("USP_BM0682_U2", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("PC_CODE", "D1", DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USEQTY", sUseQty, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKLIMITQTY", sWorkLimitQty, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKLIMITTIME", sWorkLimitTime, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "S")
                            {
                                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                                helper.Commit();
                                DoInquire();
                            }
                            else
                            {
                                throw new Exception("저장 되지 않습니다. " + helper.RSMSG);
                            }

                        }

                    }
                }


            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }


        }


        public override void DoSave()
        {
            DataTable dtChange = grid1.chkChange();
            DataTable dtChange2 = grid2.chkChange();
            if (dtChange == null)
            {
                if (dtChange2 == null)
                    return;
            }

            string sPlantCode = "";
            string sMoldCode = string.Empty;
            string sMoldName = string.Empty;
            string sMoldType = string.Empty;
            string sMoldType1 = string.Empty;
            string sMoldType2 = string.Empty;
            int sMaxCount = 0;
            float sNowCount = 0;
            int sCycleCount = 0;
            int sInspCount = 0;
            string sInspLastDate = string.Empty;
            string sCustCode = string.Empty;
            string sMakeCompany = string.Empty;
            string sMoldLName = string.Empty;
            string sSerialNo = string.Empty;
            string sBuyDate = string.Empty;
            int sLifeTime = 0;
            string sLimitDate = string.Empty;
            string sUseFlag = string.Empty;
            string sItemCode = string.Empty;
            string sRemark = string.Empty;
            string sUser = LoginInfo.UserID;
            string sOpCode = string.Empty;
            float sUseQty = 0;
            float sWorkLimitTime = 0;
            int sWorkLimitQty = 0;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();
                if (dtChange != null)
                {
                    foreach (DataRow drChange in dtChange.Rows)
                    {


                        switch (drChange.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- 삭제 ---
                                //  drChange.RejectChanges();

                                //  helper.ExecuteNoneQuery("USP_AP0110_D1", CommandType.StoredProcedure
                                //, helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                //, helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                                //, helper.CreateParameter("AS_SEQ", sContractNO, DbType.String, ParameterDirection.Input));
                                #endregion
                                break;
                            case DataRowState.Added:

                                sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                                sMoldCode = CModule.ToString(drChange["MOLDCODE"]);
                                sMoldName = CModule.ToString(drChange["MOLDNAME"]);
                                sMoldType = CModule.ToString(drChange["MOLDTYPE"]);
                                sMoldType1 = CModule.ToString(drChange["MOLDTYPE1"]);
                                sMoldType2 = CModule.ToString(drChange["MOLDTYPE2"]);
                                sMaxCount = CModule.ToInt32(drChange["MAXCOUNT"]);
                                sNowCount = 0;
                                sCycleCount = CModule.ToInt32(drChange["CYCLECOUNT"]);
                                sInspCount = CModule.ToInt32(drChange["INSPCOUNT"]);
                                sInspLastDate = CModule.ToDateString(drChange["INSPLASTDATE"]);
                                sCustCode = CModule.ToString(drChange["CUSTCODE"]);
                                sMakeCompany = CModule.ToString(drChange["MAKECOMPANY"]);
                                sMoldLName = CModule.ToString(drChange["MODELNAME"]);
                                sSerialNo = CModule.ToString(drChange["SERIALNO"]);
                                sBuyDate = CModule.ToDateString(drChange["BUYDATE"]);
                                sLifeTime = CModule.ToInt32(drChange["LIFETIME"]);
                                sLimitDate = CModule.ToDateString(drChange["LIMITDATE"]);
                                sUseFlag = CModule.ToString(drChange["USEFLAG"]);
                                sRemark = CModule.ToString(drChange["REMARK"]);
                                sUser = LoginInfo.UserID;

                                if (sMoldCode.Trim() == "" || sLimitDate == "")
                                {
                                    throw new Exception("저장 되지 않습니다.");
                                    break;
                                }

                                helper.ExecuteNoneQuery("USP_BM0682_I1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDNAME", sMoldName, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDTYPE", sMoldType, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDTYPE1", sMoldType1, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDTYPE2", sMoldType2, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MAXCOUNT", sMaxCount, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_NOWCOUNT", sNowCount, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CYCLECOUNT", sCycleCount, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_INSPCOUNT", sInspCount, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_INSPLASTDATE", sInspLastDate, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MAKECOMPANY", sMakeCompany, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MODELNAME", sMoldLName, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SERIALNO", sSerialNo, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_BUYDATE", sBuyDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_LIFETIME", sLifeTime, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_LIMITDATE", sLimitDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }
                                break;

                            case DataRowState.Modified:
                                #region --- 수정 ---

                                sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                                sMoldCode = CModule.ToString(drChange["MOLDCODE"]);
                                sMoldName = CModule.ToString(drChange["MOLDNAME"]);
                                sMoldType = CModule.ToString(drChange["MOLDTYPE"]);
                                sMoldType1 = CModule.ToString(drChange["MOLDTYPE1"]);
                                sMoldType2 = CModule.ToString(drChange["MOLDTYPE2"]);
                                sMaxCount = CModule.ToInt32(drChange["MAXCOUNT"]);
                                sCycleCount = CModule.ToInt32(drChange["CYCLECOUNT"]);
                                sCustCode = CModule.ToString(drChange["CUSTCODE"]);
                                sMakeCompany = CModule.ToString(drChange["MAKECOMPANY"]);
                                sMoldLName = CModule.ToString(drChange["MODELNAME"]);
                                sSerialNo = CModule.ToString(drChange["SERIALNO"]);
                                sBuyDate = CModule.ToDateString(drChange["BUYDATE"]);
                                sLifeTime = CModule.ToInt32(drChange["LIFETIME"]);
                                sLimitDate = CModule.ToDateString(drChange["LIMITDATE"]);
                                sUseFlag = CModule.ToString(drChange["USEFLAG"]);
                                sRemark = CModule.ToString(drChange["REMARK"]);
                                sUser = LoginInfo.UserID;


                                helper.ExecuteNoneQuery("USP_BM0682_U1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("PC_CODE", "U1", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDNAME", sMoldName, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDTYPE", sMoldType, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDTYPE1", sMoldType1, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDTYPE2", sMoldType2, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MAXCOUNT", sMaxCount, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CYCLECOUNT", sCycleCount, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MAKECOMPANY", sMakeCompany, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MODELNAME", sMoldLName, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SERIALNO", sSerialNo, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_BUYDATE", sBuyDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_LIFETIME", sLifeTime, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_LIMITDATE", sLimitDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                #endregion
                                break;
                        }
                    }

                    grid1.SetAcceptChanges();

                    helper.Commit();

                    DoInquire();
                }

                if (dtChange2 != null)
                {
                    foreach (DataRow drChange2 in dtChange2.Rows)
                    {
                        switch (drChange2.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- 삭제 ---
                                //  drChange.RejectChanges();

                                //  helper.ExecuteNoneQuery("USP_AP0110_D1", CommandType.StoredProcedure
                                //, helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                //, helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                                //, helper.CreateParameter("AS_SEQ", sContractNO, DbType.String, ParameterDirection.Input));

                                #endregion
                                break;
                            case DataRowState.Added:

                                sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                                sMoldCode = CModule.ToString(drChange2["MOLDCODE"]);
                                sOpCode = CModule.ToString(drChange2["OPCODE"]);
                                sItemCode = CModule.ToString(drChange2["ITEMCODE"]);
                                sUseQty = CModule.ToFloat(drChange2["USEQTY"]);
                                sWorkLimitTime = CModule.ToFloat(drChange2["WORKLIMITTIME"]);
                                sWorkLimitQty = CModule.ToInt32(drChange2["WORKLIMITQTY"]);
                                sUser = LoginInfo.UserID;

                                if (sMoldCode.Trim() == "" || sOpCode == "" || sItemCode == "")
                                {
                                    throw new Exception("저장 되지 않습니다.");
                                    break;
                                }

                                helper.ExecuteNoneQuery("USP_BM0682_I2", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USEQTY", sUseQty, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKLIMITTIME", sWorkLimitTime, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKLIMITQTY", sWorkLimitQty, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }
                                break;

                            case DataRowState.Modified:
                                #region --- 수정 ---
                                sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                                sMoldCode = CModule.ToString(drChange2["MOLDCODE"]);
                                sOpCode = CModule.ToString(drChange2["OPCODE"]);
                                sItemCode = CModule.ToString(drChange2["ITEMCODE"]);
                                sUseQty = CModule.ToFloat(drChange2["USEQTY"]);
                                sWorkLimitTime = CModule.ToFloat(drChange2["WORKLIMITTIME"]);
                                sWorkLimitQty = CModule.ToInt32(drChange2["WORKLIMITQTY"]);
                                sUser = LoginInfo.UserID;


                                helper.ExecuteNoneQuery("USP_BM0682_U2", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("PC_CODE", "U1", DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USEQTY", sUseQty, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKLIMITQTY", sWorkLimitQty, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_WORKLIMITTIME", sWorkLimitTime, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                #endregion
                                break;
                        }
                    }

                    grid2.SetAcceptChanges();

                    helper.Commit();
                    DoInquire();
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                ClosePrgFormNew();
            }
        }
        #endregion

        #region < EVENT AREA >
        //private void btn_COPY_H_Click(object sender, EventArgs e)
        //{
        //    DBHelper helper;

        //    try
        //    {
        //        helper = new DBHelper("", true);

        //        string sMakeDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWCONTRACTDATE_H.Value);

        //        try
        //        {
        //            helper.ExecuteNoneQuery("USP_AP0110_C1", CommandType.StoredProcedure
        //          , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_STANDDATE", "", DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

        //            if (helper.RSCODE == "S")
        //            {
        //                helper.Commit();

        //                DoInquire();
        //            }
        //            else if (helper.RSCODE == "C")
        //            {
        //                string sStandDate = helper.RSMSG;

        //                helper = new DBHelper("", true);

        //                try
        //                {
        //                    DialogResult result = MessageBox.Show("금일 생성 된 수주정보가 없습니다." + Environment.NewLine + sStandDate + " 일 수주정보가 존재 합니다. 복사 하시겠습니까?", "수주정보 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

        //                    if (result.ToString().ToUpper() == "YES")
        //                    {
        //                        helper.ExecuteNoneQuery("USP_AP0110_C1", CommandType.StoredProcedure
        //                      , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_STANDDATE", sStandDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

        //                        if (helper.RSCODE == "S")
        //                        {
        //                            helper.Commit();

        //                            DoInquire();
        //                        }
        //                        else
        //                        {
        //                            helper.Rollback();

        //                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

        //                            return;
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    helper.Rollback();

        //                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //                }
        //                finally
        //                {
        //                    helper.Close();
        //                }
        //            }
        //            else if (helper.RSCODE == "E")
        //            {
        //                helper.Rollback();

        //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            helper.Rollback();

        //            this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //        }
        //        finally
        //        {
        //            helper.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        ClosePrgFormNew();
        //    }
        //}
        #endregion

        #region < METHOD AREA >

        #endregion

        private void btn_COPY_H_Click(object sender, EventArgs e)
        {
            try
            {
                string sPlantCode = "";
                string sMoldSrc = "";
                string sMoldCode = string.Empty;
                string sUser = LoginInfo.UserID;

                if (grid1.ActiveCell == null)
                {
                    this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }


                DBHelper helper;
                helper = new DBHelper("", true);


                sPlantCode = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                sMoldSrc = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);

                if (sMoldCopyText.Text.Trim() != "")
                {
                    sMoldCode = sMoldCopyText.Text.Trim();
                }
                else
                {
                    sMoldCode = "[ NEW MOLDCODE ]";
                }

                sUser = LoginInfo.UserID;

                try
                {
                    helper.ExecuteNoneQuery("USP_BM0682_I3", CommandType.StoredProcedure
                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_MOLDSRC", sMoldSrc, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();

                        DoInquire();
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }

                }
                catch (Exception ex)
                {
                    helper.Rollback();

                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }



        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid1.ActiveCell == null)
            {
                this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            try
            {
                _GridUtil.Grid_Clear(grid2);

                DBHelper helper;
                helper = new DBHelper(false);

                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sOpCode = DBHelper.nvlString(txt_OPCODE_H.Text.Trim());

                dtGrid = helper.FillTable("USP_BM0682_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("PCCODE", "S2", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input));

                if (dtGrid.Rows.Count > 0)
                {
                    grid2.DataSource = dtGrid;
                    grid2.DataBinds(dtGrid);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        //날짜 계산 하기
        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            string sColumn = CModule.ToString(e.Cell.Column.Key);

            if (sColumn == "LIFETIME")
            {
                int Lifetime = CModule.ToInt32(e.Cell.Value);

                string sFDate = CModule.ToString(e.Cell.Row.Cells["BUYDATE"].Value);

                DateTime dt = Convert.ToDateTime(sFDate);

                dt = dt.AddDays(Lifetime);

                e.Cell.Row.Cells["LIMITDATE"].Value = CModule.ToDateString(dt);
            }
        }
    }
}
