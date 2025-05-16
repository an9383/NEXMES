#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0190
//   Form Name    : 출하지시 조회
//   Name Space   : WIZ.WM
//   Created Date : 2021-04-27
//   Made By      : 
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
    public partial class WM0190 : WIZ.Forms.BaseMDIChildForm
    {
        //출하지시 관련 정보

        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;
        BizGridManager bizGridManager2;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataTable rtnDtTemp3 = new DataTable();
        DataTable rtnDtTemp4 = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;
        DataTable dtGrid3;
        DataTable dtGrid4;
        /// <summary>
        /// 생성시 그리드 컬럼 숫자
        /// </summary>
        public int grid3Count = 0;
        #endregion

        #region < CONSTRUCTOR >
        public WM0190()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0190_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEFLAG", "완료여부", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "수주순번", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "고객번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OUTQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "재고", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "예정일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSER", "완료자", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, false);
                grid1.Columns["CONTRACTQTY"].Format = "#,##0";
                grid1.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Fixed = true;

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(grid3, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "SELOUTNO", "출하지시번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid3, "RECDATE", "출하계획일자", false, GridColDataType_emu.YearMonthDay, 120, 0, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "ENDDATE", "출하완료날짜", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "CONTRACTSEQ", "수주순번", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid3, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false); 
                //_GridUtil.InitColumnUltraGrid(grid3, "CUSTCODE", "고객번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid3, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "SHIPQTY", "출하수량", false, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                cbo_STARTDATE2_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE2_H.Value = DateTime.Now;


                //rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                //UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //UltraGridUtil.SetComboUltraGrid(this.grid3, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                //거래처

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //UltraGridUtil.SetComboUltraGrid(this.grid3, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //거래처
                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "Y" });
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "" });

                bizGridManager = new BizGridManager(this.grid1);
                bizGridManager.PopUpAdd("CustCode", "CustName", "BM0030", new string[] { "PlantCode", "", "Y" });

                bizGridManager2 = new BizGridManager(this.grid1);
                bizGridManager2.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "1", "Y" });
                bizGridManager2.PopUpClosed += BizGridManager2_PopUpClosed;
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        private void BizGridManager2_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
            DBHelper helper = new DBHelper(false);

            string sPlantCode = CModule.ToString(grid.ActiveRow.Cells["PLANTCODE"].Value);
            string sSelOutNo = CModule.ToString(grid.ActiveRow.Cells["SELOUTNO"].Value);

            DataSet ds = helper.FillDataSet("USP_AP0160_S4", CommandType.StoredProcedure
                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_ITEMCODE", sCode, DbType.String, ParameterDirection.Input));

            if (ds.Tables.Count >= 1)
            {
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    grid.ActiveRow.Cells["UNITCODE"].Value = CModule.ToString(ds.Tables[0].Rows[0]["UNITCODE"]);
                }
            }

            if (ds.Tables.Count >= 2)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    if (CModule.ToString(ds.Tables[1].Rows[i]["SELOUTNO"]) == sSelOutNo && CModule.ToString(ds.Tables[1].Rows[i]["ITEMCODE"]) == sCode)
                    {
                        grid.ActiveRow.Cells["SHIPQTY"].Value = string.Format("{0:#,##0}", CModule.ToDouble(ds.Tables[1].Rows[i]["OUTQTY"]));
                        break;
                    }
                }
            };
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            if (!CheckData() || !CheckData2())
            {
                return;
            }

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                string sSDate2 = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE2_H.Value);
                string sEDate2 = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE2_H.Value);
                string SeloutNo = DBHelper.nvlString(txt_SeloutNo_H.Text);

                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid3);

                base.DoInquire();

                dtGrid = helper.FillTable("USP_WM0190_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input));

                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);

                dtGrid = helper.FillTable("USP_WM0190_S2", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTSEQ", "", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_SELOUTNO", SeloutNo, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_STARTDATE", sSDate2, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ENDDATE", sEDate2, DbType.String, ParameterDirection.Input));

                grid3.DataSource = dtGrid;
                grid3.DataBinds(dtGrid);
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
            //base.DoNew();

            //DBHelper helper = new DBHelper(false);

            //try
            //{

            //    if (grid3.ActiveRow != null)
            //    {
            //        bool bselect2 = false;

            //        if (grid1.ActiveRow != null)
            //        {
            //            string sContractNo = CModule.ToString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
            //            string sContractSeq = CModule.ToString(grid1.ActiveRow.Cells["SEQ"].Value);
            //            string sCustCode = CModule.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
            //            string sCustName = CModule.ToString(grid1.ActiveRow.Cells["CUSTNAME"].Value);
            //            string sItemCode = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            //            string sItemName = CModule.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            //            string sUnitCode = CModule.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);

            //            for (int iRow = 0; iRow < grid3.Rows.Count; iRow++)
            //            {
            //                if (CModule.ToString(grid3.Rows[iRow].Cells["ITEMCODE"].Value) == sItemCode)
            //                {
            //                    bselect2 = true;
            //                }
            //            }

            //            if (!bselect2)
            //            {

            //                this.grid3.InsertRow();
            //                this.grid3.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            //                this.grid3.ActiveRow.Cells["SELOUTNO"].Value = this.grid2.ActiveRow.Cells["SELOUTNO"].Value;
            //                this.grid3.ActiveRow.Cells["CUSTCODE"].Value = sCustCode;
            //                this.grid3.ActiveRow.Cells["CUSTNAME"].Value = sCustName;
            //                this.grid3.ActiveRow.Cells["CONTRACTNO"].Value = sContractNo;
            //                this.grid3.ActiveRow.Cells["CONTRACTSEQ"].Value = sContractSeq;
            //                this.grid3.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
            //                this.grid3.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
            //                this.grid3.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;
            //                grid3.UpdateData();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        //선택
            //        bool bselect = false;

            //        if (grid1.ActiveRow == null)
            //        {
            //            this.ShowDialog(Common.getLangText("출하지시를 편성할 수주를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
            //             return;
            //        }

            //        for (int iRow = 0; iRow < grid2.Rows.Count; iRow++)
            //        {
            //            if (CModule.ToString(grid2.Rows[iRow].Cells["SELOUTNO"].Value) == "[ NEW SHIP ]")
            //            {
            //                bselect = true;
            //            }

            //        }

            //        if (!bselect)
            //        {
            //            this.grid2.InsertRow();
            //            this.grid2.ActiveRow.Cells["SELOUTNO"].Value = "[ NEW SHIP ]";
            //            this.grid2.ActiveRow.Cells["RECDATE"].Value = string.Format("{0:yyyy-MM-dd}", this.cbo_NEWORDERDATE_H.Value);
            //            grid2.ActiveRow.Cells["ENDDATE"].Activation = Activation.NoEdit;
            //            grid2.UpdateData();
            //        }

            //        if (grid1.ActiveRow != null)
            //        {
            //            string sContractNo = CModule.ToString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
            //            string sContractSeq = CModule.ToString(grid1.ActiveRow.Cells["SEQ"].Value);
            //            string sCustCode = CModule.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
            //            string sCustName = CModule.ToString(grid1.ActiveRow.Cells["CUSTNAME"].Value);
            //            string sItemCode = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            //            string sItemName = CModule.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            //            string sUnitCode = CModule.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);


            //            this.grid3.InsertRow();
            //            this.grid3.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            //            this.grid3.ActiveRow.Cells["SELOUTNO"].Value = this.grid2.ActiveRow.Cells["SELOUTNO"].Value;
            //            this.grid3.ActiveRow.Cells["CUSTCODE"].Value = sCustCode;
            //            this.grid3.ActiveRow.Cells["CUSTNAME"].Value = sCustName;
            //            this.grid3.ActiveRow.Cells["CONTRACTNO"].Value = sContractNo;
            //            this.grid3.ActiveRow.Cells["CONTRACTSEQ"].Value = sContractSeq;
            //            this.grid3.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
            //            this.grid3.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
            //            this.grid3.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;
            //            grid3.UpdateData();

            //        }

            //    }

            //    //if (grid1.ActiveRow == null)
            //    //{
            //    //    this.ShowDialog(Common.getLangText("출하지시를 편성할 수주를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
            //    //    return;
            //    //}
            //    //bool bselect = false;
            //    //bNew = true;
            //    //_GridUtil.Grid_Clear(grid3);                  
            //    //this.grid3.InsertRow();

            //    //string sContractNo = CModule.ToString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
            //    //string sContractSeq = CModule.ToString(grid1.ActiveRow.Cells["SEQ"].Value);
            //    //string sCustCode = CModule.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
            //    //string sItemCode = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            //    //string sItemName = CModule.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            //    //string sUnitCode = CModule.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);

            //    // //사업장과 사용여부는 행 추가시 기본으로 세팅
            //    //this.grid3.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            //    //this.grid3.ActiveRow.Cells["SELOUTNO"].Value = "[ NEW SHIP ]";                   
            //    //this.grid3.ActiveRow.Cells["CUSTCODE"].Value = sCustCode;
            //    //this.grid3.ActiveRow.Cells["CONTRACTNO"].Value = sContractNo;
            //    //this.grid3.ActiveRow.Cells["CONTRACTSEQ"].Value = sContractSeq;
            //    //this.grid3.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
            //    //this.grid3.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
            //    //this.grid3.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;


            //    ////사용자 입력 필요한 부분 기본 세팅
            //    ////사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
            //    //grid3.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
            //    ////grid3.ActiveRow.Cells["SELOUTNO"].Activation = Activation.NoEdit;
            //    //grid3.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
            //    //grid3.ActiveRow.Cells["SHIPQTY"].Activation = Activation.NoEdit;

            //    //if (grid2.Rows.Count > 0)
            //    //{
            //    //    for (int iRow = 0; iRow < grid2.Rows.Count; iRow++)
            //    //    {
            //    //        if (CModule.ToString(this.grid3.ActiveRow.Cells["SELOUTNO"].Value) != CModule.ToString(grid2.Rows[iRow].Cells["SELOUTNO"].Value))
            //    //        {
            //    //            bselect = true;
            //    //        }
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    bselect = true;
            //    //}

            //    //if (bselect)
            //    //{
            //    //    this.grid2.InsertRow();
            //    //    this.grid2.ActiveRow.Cells["SELOUTNO"].Value = this.grid3.ActiveRow.Cells["SELOUTNO"].Value;
            //    //    this.grid2.ActiveRow.Cells["RECDATE"].Value = string.Format("{0:yyyy-MM-dd}", this.cbo_NEWORDERDATE_H.Value);
            //    //    grid2.ActiveRow.Cells["ENDDATE"].Activation = Activation.NoEdit;
            //    //}


            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }

        public override void DoDelete()
        {
            //DBHelper helper = new DBHelper("", true);
            //if (grid2.IsActivate)
            //{
            //    //this.grid2.DeleteRow();
            //    DataRow dr = null;
            //    dr = (grid2.ActiveRow.ListObject as DataRowView).Row;

            //    if (dr != null)
            //    {
            //        string sPlantCode = string.Empty;
            //        string sSoNoDate = string.Empty;
            //        string sCustcode = string.Empty;
            //        string sSelOutNo = string.Empty;
            //        string sItemCode = string.Empty;
            //        string sPlanQty = string.Empty;
            //        string sShipQty = string.Empty;
            //        string sUser = LoginInfo.UserID;

            //        #region --- 삭제 ---
            //        sSelOutNo = DBHelper.nvlString(dr["SELOUTNO"]);
            //        if (sSelOutNo != "[ NEW SHIP ]")
            //        {                       
            //            sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
            //            sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

            //            helper.ExecuteNoneQuery("USP_WM0190_D1", CommandType.StoredProcedure
            //          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //          , helper.CreateParameter("AS_SONO", sSelOutNo, DbType.String, ParameterDirection.Input)
            //          , helper.CreateParameter("AS_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
            //          , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
            //          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
            //            #endregion
            //            if (helper.RSCODE != "S")
            //            {
            //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
            //                helper.Rollback();
            //                return;
            //            }
            //            else
            //            {
            //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
            //                helper.Commit();
            //            }
            //        }
            //        else {
            //            this.grid2.DeleteRow();
            //            grid2.UpdateData();
            //        }
            //    }
            //}

            //if (grid3.IsActivate)
            //{
            //    //this.grid3.DeleteRow();
            //    DataRow dr = null;
            //    dr = (grid3.ActiveRow.ListObject as DataRowView).Row;

            //    if (dr != null)
            //    {

            //        string sPlantCode = string.Empty;
            //        string sSoNoDate = string.Empty;
            //        string sCustcode = string.Empty;
            //        string sSelOutNo = string.Empty;
            //        string sItemCode = string.Empty;
            //        string sPlanQty = string.Empty;
            //        string sShipQty = string.Empty;
            //        string sUser = LoginInfo.UserID;


            //        #region --- 삭제 ---
            //        sSelOutNo = DBHelper.nvlString(dr["SELOUTNO"]);

            //        sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
            //        sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            //        sItemCode = DBHelper.nvlString(dr["ITEMCODE"]);
            //        sPlanQty = DBHelper.nvlString(dr["PLANQTY"]);
            //        sShipQty = DBHelper.nvlString(dr["SHIPQTY"]);

            //        double sS;

            //        if (sShipQty != "")
            //        {
            //            sS = Convert.ToDouble(sShipQty);

            //            if (sS != 0)
            //            {
            //                this.ShowDialog("출하수량이 있으면 삭제가 되지 않습니다.", Forms.DialogForm.DialogType.OK);

            //                return;
            //            }
            //        }

            //        if (sSelOutNo != "[ NEW SHIP ]")
            //        {
            //            helper.ExecuteNoneQuery("USP_WM0190_D1", CommandType.StoredProcedure
            //            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //            , helper.CreateParameter("AS_SONO", sSelOutNo, DbType.String, ParameterDirection.Input)
            //            , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
            //            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
            //            , helper.CreateParameter("AS_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
            //            , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

            //            if (helper.RSCODE != "S")
            //            {
            //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
            //                helper.Rollback();
            //                return;
            //            }
            //            else
            //            {
            //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
            //                helper.Commit();
            //            }
            //        }
            //        else
            //        {
            //            this.grid2.DeleteRow();
            //            grid2.UpdateData();
            //        }
            //        #endregion
            //    }

            //}
            //helper.Close();
            //DoInquire();
        }

        public override void DoSave()
        {


            //DataTable dtChange2 = grid3.chkChange();
            //if (dtChange == null && dtChange2 == null)
            //    return;


            //string sPlantCode = string.Empty;
            //string sSoNoDate = string.Empty;
            //string sCustcode = string.Empty;
            //string sSelOutNo = string.Empty;
            //string sItemCode = string.Empty;
            //string sPlanQty = string.Empty;
            //string sShipQty = string.Empty;
            //string sRT_SelOutNo = "";
            //string sContractN0 = string.Empty;
            //string sContractSeq = string.Empty;
            //string sUser = LoginInfo.UserID;

            ////double dOrderQty;

            //DBHelper helper = new DBHelper("", true);

            //try
            //{
            //    base.DoSave();
            //    if (dtChange != null)
            //    {
            //        foreach (DataRow drChange in dtChange.Rows)
            //        {
            //            switch (drChange.RowState)
            //            {
            //                case DataRowState.Deleted:
            //                    #region --- 삭제 ---

            //                    #endregion
            //                    break;
            //                case DataRowState.Added:
            //                case DataRowState.Modified:
            #region --- 추가/수정 --
            //sSelOutNo = DBHelper.nvlString(drChange["SELOUTNO"]);
            //sCustcode = "";

            //DateTime dt = DBHelper.nvlDateTime(drChange["RECDATE"]);
            //sSoNoDate = CModule.ToString(dt.ToString("yyyy-MM-dd"));

            ////sSoNoDate = CModule.ToString(string.Format("{0:yyyy-MM-dd}", drChange["RECDATE"]));                                
            ////sSoNoDate = DBHelper.nvlString();
            //if (sSoNoDate == "")
            //{
            //    sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
            //}


            //sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

            ////  helper.ExecuteNoneQuery("USP_WM0190_I1", CommandType.StoredProcedure
            ////, helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            ////, helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
            ////, helper.CreateParameter("AS_CONTRACTNO", DBHelper.nvlString(drChange["CONTRACTNO"]), DbType.String, ParameterDirection.Input)
            ////, helper.CreateParameter("AS_CONTRACTSEQ", DBHelper.nvlString(drChange["CONTRACTSEQ"]), DbType.String, ParameterDirection.Input)
            ////, helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
            ////, helper.CreateParameter("AS_CUSTOMERCODE", sCustcode, DbType.String, ParameterDirection.Input)
            ////, helper.CreateParameter("AS_SONODATE", sSoNoDate, DbType.String, ParameterDirection.Input)
            ////, helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
            //helper.ExecuteNoneQuery("USP_WM0190_I1", CommandType.StoredProcedure
            //, helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //, helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
            //, helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
            //, helper.CreateParameter("AS_CONTRACTSEQ", "", DbType.String, ParameterDirection.Input)
            //, helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
            //, helper.CreateParameter("AS_CUSTOMERCODE", sCustcode, DbType.String, ParameterDirection.Input)
            //, helper.CreateParameter("AS_SONODATE", sSoNoDate, DbType.String, ParameterDirection.Input)
            //, helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));


            //if (helper.RSCODE == "E")
            //{
            //    throw new Exception(helper.RSMSG);
            //}

            //if (helper.RSMSG.StartsWith("CONNO"))
            //{
            //    sRT_SelOutNo = helper.RSMSG.Split('|')[1];
            //}

            #endregion
            //                    break;
            //            }
            //        }
            //    }

            //    if (dtChange2 != null)
            //    {

            //        foreach (DataRow drChange2 in dtChange2.Rows)
            //        {
            //            switch (drChange2.RowState)
            //            {
            //                case DataRowState.Deleted:
            //                    #region --- 삭제 ---

            //                    #endregion
            //                    break;
            //                case DataRowState.Added:
            //                case DataRowState.Modified:
            //                    #region -- 추가/수정 --
            //                  //  sSelOutNo = sRT_SelOutNo == "" ? DBHelper.nvlString(grid2.ActiveRow.Cells["SELOUTNO"].Value) : sRT_SelOutNo;
            //                  //  sSoNoDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
            //                  //  sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            //                  //  sPlanQty = DBHelper.nvlString(drChange2["PLANQTY"]);
            //                  //  sShipQty = DBHelper.nvlString(drChange2["SHIPQTY"]);
            //                  //  sItemCode = DBHelper.nvlString(drChange2["ITEMCODE"]);
            //                  //  sContractN0 = DBHelper.nvlString(drChange2["CONTRACTNO"]);
            //                  //  sContractSeq = DBHelper.nvlString(drChange2["CONTRACTSEQ"]);
            //                  //  sCustcode = DBHelper.nvlString(drChange2["CUSTCODE"]);
            //                  //  double sP;
            //                  //  double sS;
            //                  //  if (sPlanQty == "")
            //                  //  {
            //                  //      this.ShowDialog("계획수량을 입력해주세요.", Forms.DialogForm.DialogType.OK);
            //                  //      return;
            //                  //  }
            //                  //  sP = DBHelper.nvlDouble(sPlanQty);
            //                  //  sS = DBHelper.nvlDouble(sShipQty);

            //                  //  if (sP < sS)
            //                  //  {
            //                  //      this.ShowDialog("계획수량 출하수량보다 작으면 안됩니다.", Forms.DialogForm.DialogType.OK);                                    
            //                  //      return;
            //                  //  }

            //                  //  helper.ExecuteNoneQuery("USP_WM0190_I1", CommandType.StoredProcedure
            //                  //, helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_SELOUTNO", sSelOutNo, DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_CONTRACTNO", sContractN0, DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_CONTRACTSEQ", sContractSeq, DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_CUSTOMERCODE", sCustcode, DbType.String, ParameterDirection.Input)
            //                  //, helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

            //                    #endregion
            //                    break;
            //            }
            //            if (helper.RSCODE != "S")
            //            {
            //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

            //                return;
            //            }
            //        }
            //    }

            //    helper.Commit();

            //    DoInquire();
            //}
            //catch (Exception ex)
            //{
            //    helper.Rollback();

            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();

            //    ClosePrgFormNew();
            //}
        }


        #region < EVENT AREA >

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            if (!CheckData() || !CheckData2())
            {
                return;
            }

            try
            {

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);


                string sSDate2 = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE2_H.Value);
                string sEDate2 = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE2_H.Value);
                string SeloutNo = DBHelper.nvlString(txt_SeloutNo_H.Text);
                string sCONTRACTNO = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                string sSeq = DBHelper.nvlString(grid1.ActiveRow.Cells["SEQ"].Value);

                _GridUtil.Grid_Clear(grid3);

                dtGrid = helper.FillTable("USP_WM0190_S2", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_CLOSEFLAG", "", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTNO", sCONTRACTNO, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTSEQ", sSeq, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_SELOUTNO", SeloutNo, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_STARTDATE", sSDate2, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ENDDATE", sEDate2, DbType.String, ParameterDirection.Input));

                grid3.DataSource = dtGrid;
                grid3.DataBinds(dtGrid);
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

        private bool CheckData()
        {
            int sStDate = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value));
            int sEnDate = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value));
            if (sStDate > sEnDate)
            {
                this.ShowDialog("시작일자를 종료일자보다 이전으로 선택해주십시오.", Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
            CheckData2();
        }

        private bool CheckData2()
        {
            int sStDate2 = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_STARTDATE2_H.Value));
            int sEnDate2 = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cbo_ENDDATE2_H.Value));
            if (sStDate2 > sEnDate2)
            {
                this.ShowDialog("시작일자를 종료일자보다 이전으로 선택해주십시오.", Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }


        #endregion

        #region < METHOD AREA >

        #endregion


    }

    #endregion
}
