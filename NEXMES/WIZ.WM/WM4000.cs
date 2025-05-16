#region ▶ HEADER AREA 
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM4000
//   Form Name    : 고객사 생산계획 등록
//   Created Date : 2015.10.20
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region ▶ USING AREA 
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM4000 : WIZ.Forms.BaseMDIChildForm
    {
        #region ▶ MEMBER AREA 
        //--객체 생성
        System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        PopUp_Biz _biz = new PopUp_Biz();
        Common _Common = new Common();
        //--

        //-- return DataTable 공통
        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid1 = new DataTable();
        DataTable dtSource = new DataTable();
        //--

        string fileTemp;
        #endregion

        #region ▶ InitializeComponent 
        public WM4000()
        {
            InitializeComponent();
        }
        #endregion

        #region ▶ Form Load 
        private void WM4000_Load(object sender, EventArgs e)
        {
            try
            {
                GridInit();

                btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "ALL", "ALL", "", "" });
                btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

                #region Datatable 셋팅
                dtGrid1 = (DataTable)grid1.DataSource;
                grid1.DataSource = dtGrid1;
                grid1.DataBind();

                this.dtSource.Columns.Add("PLANTCODE", typeof(string));
                this.dtSource.Columns.Add("CUSTCODE", typeof(string));
                this.dtSource.Columns.Add("CUSTNAME", typeof(string));
                this.dtSource.Columns.Add("ITEMCODE", typeof(string));
                this.dtSource.Columns.Add("ITEMNAME", typeof(string));
                this.dtSource.Columns.Add("PLANDATE", typeof(string));
                this.dtSource.Columns.Add("PLANDAY", typeof(string));
                this.dtSource.Columns.Add("PLANPRODQTY", typeof(double));
                #endregion

                #region 콤보박스
                rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장

                WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("FINISHFLAG");  //지시상태
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("FASTORDERTYPE");  //작지유형
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FASTORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                #endregion

                cboStdt.Value = DateTime.Now;

                BizGridManager bizGridManager;
                bizGridManager = new BizGridManager(grid1);
                bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "TBM0100", new string[] { "PLANTCODE", "R/M" });
                bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "TBM0301", new string[] { "PLANTCODE", "C", "" });
            }
            catch
            {
            }
        }
        #endregion

        #region ▶ InitColumnUltraGrid 
        /// <summary>
        /// InitColumnUltraGrid
        /// </summary>
        private void GridInit()
        {
            try
            {
                // InitColumnUltraGrid
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "PACKQTY", "용기당수량", false, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, false, true, "#,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "D_N", "전일생산실적", false, GridColDataType_emu.Double, 60, 100, Infragistics.Win.HAlign.Right, false, true, "#,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "D", "D", false, GridColDataType_emu.Double, 60, 100, Infragistics.Win.HAlign.Right, true, true, "#,##0", null, null, null, null);

                for (int i = 1; i <= 30; i++)
                {
                    _GridUtil.InitColumnUltraGrid(grid1, "D_" + i.ToString("#,###0"), "D+" + i.ToString("#,###0"), false, GridColDataType_emu.Double, 60, 100, Infragistics.Win.HAlign.Right, true, true, "#,###0", null, null, null, null);
                }

                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);  //2015.04.28 등록잀기 컬럼 추가

                _GridUtil.SetInitUltraGridBind(grid1);

                this.grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["BOXNAME"].Header.Fixed = true;
                this.grid1.DisplayLayout.Bands[0].Columns["PACKQTY"].Header.Fixed = true;
            }
            catch
            {
            }
        }
        #endregion

        #region ▶ GRID AfterRowActivate 
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            // 그리드의 상태 정보를 STATUS BAR에 업데이트 한다.
            this.SetStatusMessage(((DataRowView)this.grid1.ActiveRow.ListObject).Row.RowError);
        }
        #endregion

        #region ▶ TOOL BAR AREA 

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            int insrtrowpos = this.grid1.InsertRow();
            this.grid1.Rows[insrtrowpos].Cells["PLANTCODE"].Value = this.cboPlantCode_H.Value;
            //this.grid1.Rows[insrtrowpos].Cells["FASTORDERTYPE"].Value = "F";
            //this.grid1.Rows[insrtrowpos].Cells["ORDSTATUS"].Value     = "R";
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 클릭
        /// </summary>
        public override void DoDelete()
        {

        }

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);

                string ls_plantcode = Convert.ToString(cboPlantCode_H.Value);
                string ls_plandate = string.Format("{0:yyyy-MM-dd}", cboStdt.Value);
                string ls_custcode = this.txtCustCode.Text;
                string ls_custName = this.txtCustName.Text;
                string ls_itemcode = this.txtItemCode.Text;

                dtGrid1 = helper.FillTable("USP_WM4000Y_S1", CommandType.StoredProcedure
                                                               , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_BASEDT", ls_plandate, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_CUSTNAME", ls_custName, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input));

                if (this.dtGrid1.Rows.Count == 0)
                {
                    this.ShowDialog(Common.getLangText("고객사의 생산계획이 없습니다. 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                grid1.DataSource = this.dtGrid1;
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 저장 버튼 클릭
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);
            bool issuccess = true;
            dtGrid1 = (DataTable)grid1.DataSource;

            try
            {
                this.grid1.UpdateData();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel) //변경된 사항을 저장하시겠습니까?
                {
                    CancelProcess = true;
                    return;
                }

                // 진행중 
                //this.ShowProgressForm("C00007");
                // 업데이트 데이터       

                //string Check = "Default";
                string ls_itemcode = string.Empty, ls_plantcode = string.Empty;
                string ls_custcode = string.Empty, ls_basedt = string.Empty;
                string ls_ChkItem = string.Empty, ls_maker = string.Empty;
                string ls_plandate = string.Empty, ls_planprodqty = string.Empty;

                #region ▶ 엑셀 저장용 DataSourcd = dtGirid1 
                foreach (DataRow drRow in this.dtGrid1.Rows)
                {
                    ls_plantcode = Convert.ToString(drRow["PLANTCODE"]);
                    ls_itemcode = Convert.ToString(drRow["ITEMCODE"]);
                    ls_custcode = Convert.ToString(drRow["CUSTCODE"]);
                    ls_basedt = string.Format("{0:yyyy-MM-dd}", ((DateTime)this.cboStdt.Value).AddDays(-1));
                    ls_ChkItem = this.GetChkItem(this.cboPlantCode_H.Value.ToString(), ls_custcode, ls_itemcode);
                    ls_maker = this.WorkerID;

                    //거래처별 품목 확인 메세지 수정
                    //if (ls_ChkItem != "")
                    //{
                    //    this.ShowDialog(ls_ChkItem, WIZ.Forms.DialogForm.DialogType.OK);
                    //    helper.Rollback();
                    //    return;
                    //}

                    drRow.RowError = "";

                    if (drRow.RowState == DataRowState.Unchanged) continue;
                    if (drRow.RowState == DataRowState.Modified)
                    {
                        ModifiedQty(drRow);
                        return;
                    }

                    helper.ExecuteNoneQuery("USP_WM4000Y_I0", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_BASEDT", ls_basedt, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input));

                    if (Convert.ToString(helper.RSCODE) == "E")
                    {
                        issuccess = false;
                        drRow.RowError = this.FormInformation.GetMessage(helper.RSMSG);
                        continue;
                    }

                    string colid = String.Empty;

                    for (int i = -1; i <= 30; i++)
                    {
                        if (i == -1) { colid = "D_N"; }
                        else if (i == 0) { colid = "D"; }
                        else { colid = "D_" + i.ToString("##"); }

                        ls_plandate = string.Format("{0:yyyy-MM-dd}", ((DateTime)this.cboStdt.Value).AddDays(i));
                        ls_planprodqty = Convert.ToString(Convert.ToDouble(DBHelper.nvlString(drRow[colid], "0")));

                        helper.ExecuteNoneQuery("USP_WM4000Y_I1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANDATE", ls_plandate, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANPRODQTY", ls_planprodqty, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_BASEDT", ls_basedt, DbType.String, ParameterDirection.Input));

                        if (Convert.ToString(helper.RSCODE) == "E")
                        {
                            string a = helper.RSMSG;
                            issuccess = false;
                            drRow.RowError = this.FormInformation.GetMessage(helper.RSMSG);
                            MessageBox.Show(helper.RSMSG);
                            return;
                        }
                        if (Convert.ToString(helper.RSCODE) == "O")
                        {
                            string msg = helper.RSMSG;
                            issuccess = false;
                            this.ShowDialog(msg, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    //Check = "DtGird1";
                }
                #endregion

                //#region ▶ 개별 수정용 DataSourCe = dtSource 
                //if (Check != "DtGird1")
                //{
                //    foreach (DataRow drRow in this.dtSource.Rows)
                //    {
                //        ls_plantcode = Convert.ToString(drRow["PLANTCODE"]);                    
                //        ls_itemcode  = Convert.ToString(drRow["ITEMCODE"]);
                //        ls_custcode  = Convert.ToString(drRow["CUSTCODE"]);
                //        ls_basedt    = string.Format("{0:yyyy-MM-dd}", ((DateTime)this.cboStdt.Value).AddDays(-1));
                //        ls_ChkItem   = this.GetChkItem(this.cboPlantCode_H.Value.ToString(), ls_custcode, ls_itemcode);
                //        ls_maker     = this.WorkerID;

                //        drRow.RowError = "";

                //        if (drRow.RowState == DataRowState.Unchanged) continue;

                //        helper.ExecuteNoneQuery("USP_WM4000Y_I0", CommandType.StoredProcedure
                //                                                , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                //                                                , helper.CreateParameter("AS_CUSTCODE",  ls_custcode,  DbType.String, ParameterDirection.Input)
                //                                                , helper.CreateParameter("AS_BASEDT",    ls_basedt,    DbType.String, ParameterDirection.Input)
                //                                                , helper.CreateParameter("AS_ITEMCODE",  ls_itemcode,  DbType.String, ParameterDirection.Input)
                //                                                , helper.CreateParameter("AS_MAKER",     ls_maker,     DbType.String, ParameterDirection.Input));
                //        if (Convert.ToString(helper.RSCODE) == "E")
                //        {
                //            issuccess = false;
                //            drRow.RowError = this.FormInformation.GetMessage(helper.RSMSG);
                //            continue;
                //        }

                //        string colid = String.Empty;
                //        for (int i = -1; i <= 30; i++)
                //        {
                //            if (i == -1) { colid = "D_N"; }
                //            else if (i == 0) { colid = "D"; }
                //            else { colid = "D_" + i.ToString("##"); }

                //            ls_plandate = string.Format("{0:yyyy-MM-dd}", ((DateTime)this.cboStdt.Value).AddDays(i));
                //            ls_planprodqty = Convert.ToString(Convert.ToDouble(drRow[colid]));

                //            helper.ExecuteNoneQuery("USP_WM4000Y_I1", CommandType.StoredProcedure
                //                                                    , helper.CreateParameter("AS_PLANTCODE",   ls_plantcode,   DbType.String, ParameterDirection.Input)
                //                                                    , helper.CreateParameter("AS_CUSTCODE",    ls_custcode,    DbType.String, ParameterDirection.Input)
                //                                                    , helper.CreateParameter("AS_PLANDATE",    ls_plandate,    DbType.String, ParameterDirection.Input)
                //                                                    , helper.CreateParameter("AS_ITEMCODE",    ls_itemcode,    DbType.String, ParameterDirection.Input)
                //                                                    , helper.CreateParameter("AS_PLANPRODQTY", ls_planprodqty, DbType.String, ParameterDirection.Input)
                //                                                    , helper.CreateParameter("AS_MAKER",       ls_maker,       DbType.String, ParameterDirection.Input)
                //                                                    , helper.CreateParameter("AS_BASEDT",      ls_basedt,      DbType.String, ParameterDirection.Input));
                //            if (Convert.ToString(helper.RSCODE) == "E")
                //            {
                //                issuccess = false;
                //                drRow.RowError = this.FormInformation.GetMessage(helper.RSMSG);
                //            }
                //        }
                //    }
                //}
                //#endregion

                if (issuccess)
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("정상적으로 처리되었습니다", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
                //else
                //{
                //    helper.Rollback();
                //    this.ShowDialog("R00155", WIZ.Forms.DialogForm.DialogType.OK); //생산계획 업로드중 오류가 발생했습니다.
                //}

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
                DoInquire();
            }
        }
        #endregion

        #region ▶ METHOD 
        public void ModifiedQty(DataRow dtRow)
        {
            DBHelper helper = new DBHelper(false);
            DataRow drRow = dtRow;

            try
            {
                string ls_itemcode = string.Empty, ls_plantcode = string.Empty;
                string ls_custcode = string.Empty, ls_basedt = string.Empty;
                string ls_ChkItem = string.Empty, ls_maker = string.Empty;
                string ls_plandate = string.Empty, ls_planprodqty = string.Empty;

                ls_plantcode = Convert.ToString(drRow["PLANTCODE"]);
                ls_itemcode = Convert.ToString(drRow["ITEMCODE"]);
                ls_custcode = Convert.ToString(drRow["CUSTCODE"]);
                ls_basedt = string.Format("{0:yyyy-MM-dd}", ((DateTime)this.cboStdt.Value).AddDays(-1));
                ls_ChkItem = this.GetChkItem(this.cboPlantCode_H.Value.ToString(), ls_custcode, ls_itemcode);
                ls_maker = this.WorkerID;

                helper.ExecuteNoneQuery("USP_WM4000Y_I0", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_BASEDT", ls_basedt, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input));

                if (Convert.ToString(helper.RSCODE) == "E")
                {
                    string msg = helper.RSMSG;
                    drRow.RowError = this.FormInformation.GetMessage(helper.RSMSG);
                    this.ShowDialog(msg, Forms.DialogForm.DialogType.OK);
                    return;
                }

                string colid = String.Empty;

                for (int i = -1; i <= 30; i++)
                {
                    if (i == -1) { colid = "D_N"; }
                    else if (i == 0) { colid = "D"; }
                    else { colid = "D_" + i.ToString("##"); }

                    ls_plandate = string.Format("{0:yyyy-MM-dd}", ((DateTime)this.cboStdt.Value).AddDays(i));
                    ls_planprodqty = Convert.ToString(Convert.ToDouble(DBHelper.nvlString(drRow[colid], "0")));

                    //helper.ExecuteNoneQuery("USP_WM4000Y_I1", CommandType.StoredProcedure
                    //                                        , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                    //                                        , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                    //                                        , helper.CreateParameter("AS_PLANDATE", ls_plandate, DbType.String, ParameterDirection.Input)
                    //                                        , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                    //                                        , helper.CreateParameter("AS_PLANPRODQTY", ls_planprodqty, DbType.String, ParameterDirection.Input)
                    //                                        , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input)
                    //                                        , helper.CreateParameter("AS_BASEDT", ls_basedt, DbType.String, ParameterDirection.Input));

                    helper.ExecuteNoneQuery("USP_WM4000Y_U1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTCODE", ls_custcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANDATE", ls_plandate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANPRODQTY", ls_planprodqty, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input));

                    if (Convert.ToString(helper.RSCODE) == "E")
                    {
                        string a = helper.RSMSG;
                        MessageBox.Show(helper.RSMSG);
                        return;
                    }
                    if (Convert.ToString(helper.RSCODE) == "O")
                    {
                        string msg = helper.RSMSG;
                        this.ShowDialog(msg, Forms.DialogForm.DialogType.OK);
                    }
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
                this.ClosePrgFormNew();
                helper.Close();
                DoInquire();
            }
        }
        #region ▶ Excel UPLOAD 
        /// <summary>
        /// 고객사 주간생산계획 엑셀 파일을 읽어, 고객사일별 납품계획에 등록 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelUPbtn_Click(object sender, EventArgs e)
        {
            POP_WM4000_EXCEL pop_wm4000_excel = new POP_WM4000_EXCEL((DateTime)cboStdt.Value);
            pop_wm4000_excel.ShowDialog();

            //try
            //{
            //    OpenFileDialog openfiledialog = new OpenFileDialog();
            //    openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

            //    if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        //엑셀 파일 READ
            //        DataTable dtExcelImport = GetExcel(openfiledialog.FileName); 

            //        //대상 GRID DataTable 복사(구조o, 데이터x)
            //        DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();

            //        //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
            //        for (int i = 1; i < dtExcelImport.Rows.Count; i++)
            //        {
            //            if (Convert.ToString(dtExcelImport.Rows[i][0]) == string.Empty)
            //            {
            //                break;
            //            }

            //            DataRow drTarget = dtTarget.NewRow();

            //            drTarget["PLANTCODE"] = Convert.ToString(this.cboPlantCode_H.Value);  //WIZ.LoginInfo.PlantCode.Trim();
            //            drTarget["CUSTCODE"]  = Convert.ToString(dtExcelImport.Rows[i][0]);
            //            drTarget["CUSTNAME"] = Convert.ToString(dtExcelImport.Rows[i][1]);
            //            drTarget["ITEMCODE"]  = Convert.ToString(dtExcelImport.Rows[i][2]);
            //            drTarget["ITEMNAME"] = Convert.ToString(dtExcelImport.Rows[i][3]);
            //            drTarget["D"] = Convert.ToString(dtExcelImport.Rows[i][4]);
            //            drTarget["D_1"] = Convert.ToString(dtExcelImport.Rows[i][5]);
            //            drTarget["D_2"] = Convert.ToString(dtExcelImport.Rows[i][6]);
            //            drTarget["D_3"] = Convert.ToString(dtExcelImport.Rows[i][7]);
            //            drTarget["D_4"] = Convert.ToString(dtExcelImport.Rows[i][8]);
            //            drTarget["D_5"] = Convert.ToString(dtExcelImport.Rows[i][9]);
            //            drTarget["D_6"] = Convert.ToString(dtExcelImport.Rows[i][10]);
            //            drTarget["D_7"] = Convert.ToString(dtExcelImport.Rows[i][11]);
            //            drTarget["D_8"] = Convert.ToString(dtExcelImport.Rows[i][12]);
            //            drTarget["D_9"] = Convert.ToString(dtExcelImport.Rows[i][13]);
            //            drTarget["D_10"] = Convert.ToString(dtExcelImport.Rows[i][14]);
            //            drTarget["D_11"] = Convert.ToString(dtExcelImport.Rows[i][15]);
            //            drTarget["D_12"] = Convert.ToString(dtExcelImport.Rows[i][16]);
            //            drTarget["D_13"] = Convert.ToString(dtExcelImport.Rows[i][17]);
            //            drTarget["D_14"] = Convert.ToString(dtExcelImport.Rows[i][18]);
            //            drTarget["D_15"] = Convert.ToString(dtExcelImport.Rows[i][19]);
            //            drTarget["D_16"] = Convert.ToString(dtExcelImport.Rows[i][20]);
            //            drTarget["D_17"] = Convert.ToString(dtExcelImport.Rows[i][21]);
            //            drTarget["D_18"] = Convert.ToString(dtExcelImport.Rows[i][22]);
            //            drTarget["D_19"] = Convert.ToString(dtExcelImport.Rows[i][23]);
            //            drTarget["D_20"] = Convert.ToString(dtExcelImport.Rows[i][24]);
            //            drTarget["D_21"] = Convert.ToString(dtExcelImport.Rows[i][25]);
            //            drTarget["D_22"] = Convert.ToString(dtExcelImport.Rows[i][26]);
            //            drTarget["D_23"] = Convert.ToString(dtExcelImport.Rows[i][27]);
            //            drTarget["D_24"] = Convert.ToString(dtExcelImport.Rows[i][28]);
            //            drTarget["D_25"] = Convert.ToString(dtExcelImport.Rows[i][29]);
            //            drTarget["D_26"] = Convert.ToString(dtExcelImport.Rows[i][30]);
            //            drTarget["D_27"] = Convert.ToString(dtExcelImport.Rows[i][31]);
            //            drTarget["D_28"] = Convert.ToString(dtExcelImport.Rows[i][32]);
            //            drTarget["D_29"] = Convert.ToString(dtExcelImport.Rows[i][33]);
            //            drTarget["D_30"] = Convert.ToString(dtExcelImport.Rows[i][34]);

            //            dtTarget.Rows.Add(drTarget);
            //        }

            //        this.grid1.DataSource = dtTarget;
            //        this.grid1.DataBind();

            //        dtGrid1 = (DataTable)this.grid1.DataSource;
            //    }
            //}
            //catch (Exception ex)
            //{   
            //    this.ShowDialog(Common.getLangText("엑셀수작업 등록 양식이 잘못되었습니다. 양식다운을 하신 뒤에 작업을 진행하십시오.", "MSG") + Environment.NewLine + "오류내용: " + ex.Message);
            //}
            #region 주석
            /*
            bool exfile = false;
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter           = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx";
            openFileDialog1.FileName         = "";

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            if (openFileDialog1.FileName     == "") return;

            // 고객사 주간생산계획 업로드 ..
            this.ShowProgressForm("C00007");

            this.dtGrid1.Clear();

            //프로그래스 바 자원 해제
            this.ClosePrgFormNew();

            // 파일의 절대 경로 검색 및 EXCEL 파일 객체 생성
            string    filePath       = openFileDialog1.FileName;

            //2015-03-31 최재형 해당 엑셀파일 에러처리
            Workbook workbook = null;
            try
            {
                workbook = Workbook.Load(filePath);
            }
            catch (System.IO.IOException ex)
            {
                //this.ShowDialog(Common.getLangText("엑셀파일이 다른프로그램에서 사용중입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                //return;
                //2015-04-22 엑셀 사용중일때 업로드 가능
                fileTemp = filePath + "_tmp";
                File.Copy(filePath, fileTemp, true);
                workbook = Workbook.Load(fileTemp);
                File.Delete(fileTemp);
                exfile = true;

            }

            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("엑셀파일 형식이 틀립니다. 확인하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); 
                return;
            }

            Worksheet worksheet      = workbook.Worksheets[0];
            bool      iserror        = false;
            string    itemcode       = String.Empty;
            string    itemname       = String.Empty;
            string    custcode       = this.txtCustCode.Text.Trim();
            string    custname       = String.Empty;
            DateTime  plandt         = (DateTime)this.cboStdt.Value;
            int       rowcount       = 0;

            try
            {
                // WorkSheet에 있는 Row를 DataTable에 추가
                foreach (WorksheetRow worksheetrow in worksheet.Rows)
                {
                    rowcount++;

                    // HEADER 행 제외
                    if (rowcount <= 2) continue;

                    // ITEMCODE NULL 체크
                    if (worksheetrow.Cells[1].Value == null) continue;

                    // ITECODE DATA 처리
                    itemcode = Regex.Replace(Convert.ToString(worksheetrow.Cells[1].Value).Replace('-', ' '), " ", "");
                    if (itemcode.Length > 5)
                        itemcode = itemcode.Substring(0, 5) + "-" + itemcode.Substring(5, itemcode.Length - 5);

                    itemname = this.GetItemName(this.cboPlantCode_H.Value.ToString(), itemcode);

                    // 15-06-24 GetCustCode의 쿼리 WHERE 절의 refcustcode -> custcode로 변경 최재형
                    custcode = this.GetCustCode(this.cboPlantCode_H.Value.ToString(), Convert.ToString(worksheetrow.Cells[0].Value));
                    if (custcode == "") custcode = Convert.ToString(worksheetrow.Cells[0].Value);
                    custname = this.GetCustName(this.cboPlantCode_H.Value.ToString(), custcode);

                    // 공장코드, 거래처, 품목를 이용하여 중복 CHEK 중복일 경우 중복된 행을 생성, 중복이 아닐 경우는 신규 행 생성
                    DataRow[] foundrow;

                    StringBuilder rowfilter = new StringBuilder();
                    rowfilter.Append("PLANTCODE = '").Append(this.cboPlantCode_H.Value.ToString()).Append("' ");
                    rowfilter.Append("AND CUSTCODE = '").Append(custcode).Append("' ");
                    rowfilter.Append("AND ITEMCODE = '").Append(itemcode).Append("' ");

                    foundrow = this.dtGrid1.Select(rowfilter.ToString());

                    DataRow datarow = this.dtGrid1.NewRow();
                    if (foundrow.Length == 0)
                    {
                        datarow["PLANTCODE"] = this.cboPlantCode_H.Value;
                        datarow["ITEMCODE"] = itemcode;
                        datarow["ITEMNAME"] = itemname;
                        datarow["CUSTCODE"] = custcode;
                        datarow["CUSTNAME"] = custname;
                        datarow["BoxName"] = this.GetBoxName(this.cboPlantCode_H.Value.ToString(), custcode, itemcode);
                        datarow["PACKQTY"] = this.GetPackQty(this.cboPlantCode_H.Value.ToString(), custcode, itemcode);

                        // 15-06-24 고객사별 출하품목 체크 추가 최재형
                        string ChkItem = this.GetChkItem(this.cboPlantCode_H.Value.ToString(), custcode, itemcode);

                        //2015-07-02 서보경 거래처별 품목 확인 메세지 수정
                        if (ChkItem !="")
                        {
                          //datarow.RowError = ((WIZ.Forms.BaseMDIChildForm)this).FormInformation.GetMessage("R10015");  //고객사별 출하품목을 확인하세요
                            datarow.RowError = ChkItem;

                        }

                        datarow["MakeDate"] = System.DateTime.Now.ToString("yyyy-MM-dd"); //2015.04.28 등록일시 추가
                    }
                    else
                        datarow = foundrow[0];
                    if (datarow["D_N"].ToString() == "") datarow["D_N"] = 0;

                    //업로드 엑셀파일의 전일실적
                    datarow["D_N"] = Convert.ToDouble(datarow["D_N"]) + Convert.ToDouble(worksheetrow.Cells[2].Value);
                    string colid = string.Empty;

                    //업로드 엑셀파일의 D-DAY의 1달 데이터
                    for (int i = 3; i < 34; i++)
                    {
                        if (i == 3)
                            colid = "D";
                        else
                            colid = "D_" + (i - 3).ToString("##");

                        if (datarow[colid].ToString() == "") datarow[colid] = 0;

                        datarow[colid] = Convert.ToDouble(datarow[colid]) + Convert.ToDouble(worksheetrow.Cells[i].Value);

                    }
                    if (foundrow.Length == 0)
                        this.dtGrid1.Rows.Add(datarow);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("엑셀 업로드 중 오류가 발생하였습니다. 관리자에게 문의 하십시오.");
            }
            if (exfile == true) //2015-04-21 프로세서 사용 에러로 인해 생성된 복제파일 삭제
            {
                File.Delete(fileTemp);
                fileTemp = null;
            }

            // 데이터 소스 바인딩            
            grid1.DataSource = this.dtGrid1;
            grid1.DataBind();
            ClosePrgFormNew();
            */
            #endregion
        }

        private DataTable GetExcel(string sFilePath)
        {
            string oledbConnStr = string.Empty;

            if (sFilePath.IndexOf(".xlsx") > -1)
            {
                // 엑셀 2007 이상
                oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 12.0\";HDR=NO;IMEX=1;";
            }
            else
            {
                // 엑셀 2003 및 이하 버전                
                oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
            }

            DataTable dtExcel = null;
            OleDbDataAdapter adt = null;

            using (OleDbConnection con = new OleDbConnection(oledbConnStr))
            {
                con.Open();

                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = dt.Rows[0]["TABLE_NAME"].ToString();             //엑셀 첫 번째 시트명
                string sQuery = string.Format(" SELECT * FROM [{0}] ", sheetName);  //조회 쿼리

                dtExcel = new DataTable();
                adt = new OleDbDataAdapter(sQuery, con);
                adt.Fill(dtExcel);
            }

            return dtExcel;
        }

        //private string GetItemName(string plantcode, string itemcode)
        //{
        //    DBHelper helper = new DBHelper();
        //    Object   rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(ItemName, '') FROM TBM0100 WHERE PlantCode = '" + plantcode + "' AND ItemCode = '" + itemcode + "'"));
        //    if (rtnval == null) rtnval = "";

        //    return rtnval.ToString();
        //}

        //private string GetCustCode(string plantcode, string refcustcode)
        //{
        //    DBHelper helper = new DBHelper();
        //    Object   rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(CustCode, '') FROM TBM0300 WHERE PlantCode = '" + plantcode + "' AND CustCode = '" + refcustcode + "'"));
        //    if (rtnval == null) rtnval = "";

        //    return rtnval.ToString();
        //}

        //private string GetCustName(string plantcode, string custcode)
        //{
        //    DBHelper helper = new DBHelper();
        //    Object   rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(CustName, '') FROM TBM0300 WHERE PlantCode = '" + plantcode + "' AND custcode = '" + custcode + "'"));
        //    if (rtnval == null) rtnval = "";

        //    return rtnval.ToString();
        //}

        //private string GetWorkCenterName(string plantcode, string workcentercode)
        //{
        //    DBHelper helper = new DBHelper();
        //    Object   rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(WorkCenterName, '') FROM TBM0600 WHERE PlantCode = '" + plantcode + "' AND WorkCenterCode = '" + workcentercode + "'"));

        //    if (rtnval == null) rtnval = "";

        //    return rtnval.ToString();        
        //}

        //private string GetOPName(string plantcode, string opcode)
        //{
        //    DBHelper helper = new DBHelper();
        //    Object   rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(OPName, '') FROM TBM0400 WHERE PlantCode = '" + plantcode + "' AND OPCode = '" + opcode + "'"));

        //    if (rtnval == null) rtnval = "";

        //    return rtnval.ToString();        
        //}

        //private string GetBoxSpec(string plantcode, string custcode, string itemcode)
        //{
        //    DBHelper helper = new DBHelper();
        //    Object   rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(BOXSPEC, '') FROM TBM1800 WHERE PlantCode = '" + plantcode + "' AND CustCode = '" + custcode + "'" + " AND ItemCode = '" + itemcode + "'"));

        //    if (rtnval == null || Convert.ToString(rtnval) == "") rtnval = "";

        //    return rtnval.ToString();        
        //}

        //private string GetBoxName(string plantcode, string custcode, string itemcode)
        //{
        //    string Boxspec = this.GetBoxSpec(plantcode, custcode, itemcode);

        //    DBHelper helper = new DBHelper();
        //    Object rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(BoxName, '') FROM TBM1801 WHERE PlantCode = '" + plantcode + "' AND Boxspec = '" + Boxspec + "'" ));

        //    if (rtnval == null || Convert.ToString(rtnval) == "") rtnval = "";

        //    return rtnval.ToString();
        //}

        //private double GetPackQty(string plantcode, string custcode, string itemcode)
        //{
        //    DBHelper helper = new DBHelper();
        //    Object   rtnval = Convert.ToString(helper.ExecuteScalar("SELECT ISNULL(PackQty, 0) FROM TBM1800 WHERE PlantCode = '" + plantcode + "' AND CustCode = '" + custcode + "'" + " AND ItemCode = '" + itemcode + "'"));

        //    if (rtnval == null || Convert.ToString(rtnval) == "") rtnval = 0;

        //    return Convert.ToDouble(rtnval);        
        //}

        // 15-06-24 고객사별 출하품목 체크 추가 최재형
        private string GetChkItem(string as_plantcode, string as_custcode, string as_itemcode)
        {
            // 2015-07-02 서보경 고객사별 출하 품목 체크 수정(관련 거래처코드도 체크 가능)
            DBHelper helper = new DBHelper(false);
            DataTable dtTemp = new DataTable();
            string RS_CODE = string.Empty, RS_MSG = string.Empty;
            try
            {

                dtTemp = helper.FillTable("USP_WM4000Y_ITEMCHK", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", as_plantcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_CUSTCODE", as_custcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", as_itemcode, DbType.String, ParameterDirection.Input));

                if (Convert.ToString(helper.RSMSG) != "")
                {
                    return Convert.ToString(helper.RSMSG);
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
            return "";
        }

        /// <summary>
        /// 그리드에 신규행이 추가 되었을 경우, 추가행의 각 셀의 배경색을 변경한다.
        /// </summary>
        /// <param name="grid">변경대상 그리드</param>
        /// <param name="rowid">변경대상 행</param>
        private void SetGridInsertRowAppeareance(WIZ.Control.Grid grid, int rowid)
        {
            grid.Rows[rowid].Appearance.BackColor = Color.FromArgb(0xED, 0xFB, 0xFF);
            for (int i = 0; i < grid.Rows[rowid].Cells.Count; i++)
            {
                string col = grid.Rows[rowid].Cells[i].Column.Key;
                switch ((string)grid.DisplayLayout.Bands[0].Columns[col].Tag)
                {
                    case "K":
                        grid.Rows[rowid].Cells[i].Appearance.BackColor = Color.FromArgb(0xF0, 0xFF, 0xD2);
                        break;
                    case "M":
                        grid.Rows[rowid].Cells[i].Appearance.BackColor = Color.FromArgb(0xFF, 0xFF, 0x99);
                        break;
                }
                if (grid.DisplayLayout.Bands[0].Columns[col].CellActivation == Infragistics.Win.UltraWinGrid.Activation.NoEdit)
                {
                    for (int j = 0; j < grid.Rows.Count; j++)
                    {
                        grid.Rows[j].Cells[col].IgnoreRowColActivation = false;
                        grid.Rows[j].Cells[col].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                }
                else
                {
                    grid.Rows[rowid].Cells[col].IgnoreRowColActivation = true;
                    grid.Rows[rowid].Cells[col].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
            }
        }
        #endregion

        private void grid1_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {

            // 수정된 행이 D Column 일 경우만 수행
            if (!Regex.IsMatch(e.Cell.Column.Key, "D*")) return;

            // 2015-04-22 선택된 DAY를 저장하기 위해 추가
            string D = e.Cell.Column.Key;

            var results = from datarow in dtSource.AsEnumerable()
                          where datarow.Field<string>("CUSTCODE") == e.Cell.Row.Cells["CUSTCODE"].Value.ToString()
                             && datarow.Field<string>("ITEMCODE") == e.Cell.Row.Cells["ITEMCODE"].Value.ToString()
                          //2015-04-22 최재형 PLANDAY 사용안함 
                          //&& datarow.Field<string>("PLANDAY")  == e.Cell.Column.Key 
                          select datarow;
            foreach (var Row in results)
                //최재형 PlanProdQty 사용안함 
                //Row["PlanProdQty"] = e.Cell.Value; 
                Row[D] = e.Cell.Value;
        }
        #endregion
    }
}
