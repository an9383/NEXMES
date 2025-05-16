using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP6200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        int iColCount;
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Hashtable _groupHash = new Hashtable();
        Hashtable _DayNightHash = new Hashtable();
        DataTable dt = new DataTable();
        #endregion

        #region 생성자
        public PP6200()
        {
            InitializeComponent();
        }
        #endregion

        #region 폼 로드
        private void PP6200_Load(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "검사일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDN", "주야구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", true, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OpSeq", "No", false, GridColDataType_emu.VarChar, 50, 70, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCSpQuality", "특별특성", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCSpQulityName", "특별특성", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCMANASPEC", "관리규격", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCManaSpecName", "관리규격", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCSTANDARD", "측정구", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QCStansdardName", "측정구", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValName", "등록형태", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaLSL", "하한", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ManaUSL", "상한", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RelCode1", "OK", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RelCode2", "NG", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RelCode3", "Check", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerID", "작업자ID", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", "작업자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RstData1", "초품", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Result1", "초품결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RstData2", "중품", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Result2", "중품결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RstData3", "종품", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Result3", "종품결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DSeq", "자품목순서", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlag", "처리구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            ;
            iColCount = grid1.Columns.Count;
            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            grid1.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.GroupLayout;
            grid1.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            #region Grid MERGE
            //grid1.Columns["InspDate"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["InspDate"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["InspDate"].MergedCellStyle = MergedCellStyle.Always;

            #endregion
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspDN", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboDayNight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            _DayNightHash.Clear();

            for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
            {
                if (DBHelper.nvlString(rtnDtTemp.Rows[i]["CODE_ID"]) != "ALL")
                {
                    _DayNightHash.Add(rtnDtTemp.Rows[i]["CODE_ID"], DBHelper.gGetName(rtnDtTemp.Rows[i]["CODE_NAME"]));
                    _DayNightHash.Add(DBHelper.gGetName(rtnDtTemp.Rows[i]["CODE_NAME"]), rtnDtTemp.Rows[i]["CODE_ID"]);
                }
            }

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPRESULT");
            WIZ.Common.FillComboboxMaster(this.cboResult, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("QUERYTYPE");
            WIZ.Common.FillComboboxMaster(this.cboQType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "DATA");

            cboQType.Enabled = false;
            cboQType.Value = "DATA";

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtInspCode, txtInspName, "TBM1500", new object[] { "QC", "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });

            btbManager.PopUpAdd(txtWorkerID, txtWorkerName, "TBM0200", new object[] { cboPlantCode_H, "", "", "", "" });

            btbManager.ClosePopUpEvent += new BizTextBoxManager.ClosePopUpHandler(btbManager_ClosePopUpEvent);
            btbManager.InitTextBoxEvent += new BizTextBoxManager.InitTextBoxHandler(btbManager_InitTextBoxEvent);

            // 위치에 따라 처리가 필요함.
            grid1.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(grid_DoubleClickCell);
            grid1.KeyPressed += new WIZ.Control.Grid.Grid_KeyPressed(grid_KeyPressed);
            grid1.CellChange += new CellEventHandler(grid_CellChange);
        }

        void btbManager_InitTextBoxEvent(object sender, BizTextBoxManager.InitTextBoxArgument e)
        {
            if (GetName(e.TextBox).Contains("txtWorkCenterCode") || GetName(e.TextBox).Contains("txtWorkCenterName"))
            {
                if (GetText(e.TextBox).Length > 0 && GetText(e.TextBox).Length > 0)
                {
                    // 선택된 작업라인이 있는 경우
                    cboQType.Enabled = true;
                }
                else
                {
                    // 선택된 작업라인이 없는 경우
                    cboQType.Enabled = false;
                    cboQType.Value = "DATA";
                }
            }
        }

        private void btbManager_ClosePopUpEvent(object sender, BizTextBoxManager.ClosePopUpArgument e)
        {
            if (GetName(e.CodeBox).Contains("txtWorkCenterCode"))
            {
                if (GetText(e.CodeBox).Length > 0 && GetText(e.NameBox).Length > 0)
                {
                    // 선택된 작업라인이 있는 경우
                    cboQType.Enabled = true;
                }
                else
                {
                    // 선택된 작업라인이 없는 경우
                    cboQType.Enabled = false;
                    cboQType.Value = "DATA";
                }
            }
        }

        private string GetName(object sCode)
        {
            string sValue = string.Empty;
            switch (sCode.GetType().Name)
            {
                case "TextBox":
                    sValue = ((TextBox)sCode).Name;
                    break;
                case "SBtnTextEditor":
                    sValue = ((SBtnTextEditor)sCode).Name;
                    break;
                case "UltraTextEditor":
                    sValue = ((UltraTextEditor)sCode).Name;
                    break;
            }
            return sValue;
        }

        private string GetText(object sCode)
        {
            string sValue = string.Empty;
            switch (sCode.GetType().Name)
            {
                case "TextBox":
                    sValue = ((TextBox)sCode).Text;
                    break;
                case "SBtnTextEditor":
                    sValue = ((SBtnTextEditor)sCode).Text;
                    break;
                case "UltraTextEditor":
                    sValue = ((UltraTextEditor)sCode).Text;
                    break;
            }
            return sValue;
        }

        #region 팝업 메소드
        void grid_CellChange(object sender, CellEventArgs e)
        {
            if (this.grid1.ActiveRow != null && this.grid1.ActiveCell != null)
            {
                try
                {
                    int iRow = this.grid1.ActiveRow.Index;
                    string sKey = this.grid1.ActiveCell.Column.Key;

                    try
                    {
                        if (grid1.Columns[sKey].Header.Caption == "WorkerID")
                        {
                            grid1.Rows[iRow].Cells[this.grid1.ActiveCell.Column.Index + 1].Value = string.Empty;
                        }
                        else if (grid1.Columns[sKey].Header.Caption == "작업자")
                        {
                            grid1.Rows[iRow].Cells[this.grid1.ActiveCell.Column.Index - 1].Value = string.Empty;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void grid_KeyPressed(WIZ.Control.Grid sender, KeyPressEventArgs e)
        {
            if (this.grid1.ActiveRow != null && this.grid1.ActiveCell != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    grid_Popup();
                }
            }
        }

        private void grid_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (this.grid1.ActiveRow != null && this.grid1.ActiveCell != null)
            {
                grid_Popup();
            }
        }

        protected virtual void grid_Popup()
        {

            //비지니스 로직 객체 생성
            PopUp_Biz _biz = new PopUp_Biz();
            DBHelper helper = new DBHelper(false);

            if (grid1.ActiveRow == null || grid1.ActiveRow == null)
                return;

            int iRow = this.grid1.ActiveRow.Index;
            int iCol = this.grid1.ActiveCell.Column.Index;

            string sCode = null;
            string sName = null;

            if (grid1.Columns[iCol].Header.Caption == "WorkerID")
            {
                sCode = grid1.Columns[iCol].Key;
                sName = grid1.Columns[iCol + 1].Key;
            }
            else if (grid1.Columns[iCol].Header.Caption == "작업자")
            {
                sCode = grid1.Columns[iCol - 1].Key;
                sName = grid1.Columns[iCol].Key;
            }

            if (sCode == null || sName == null)
                return;

            string sValueCode = DBHelper.nvlString(grid1.Rows[iRow].Cells[sCode].Text);
            string sValueName = DBHelper.nvlString(grid1.Rows[iRow].Cells[sName].Text);

            //_biz.BM0020_POP_Grid(DBHelper.gGetCode(grid1.Rows[iRow].Cells["PlantCode"].Value), "", "", "", sValueCode, sValueName, "", grid1, sCode, sName);

            grid1.Rows[iRow].Cells[sCode].Tag = "Y";
            grid1.Rows[iRow].Update();
        }

        #endregion
        #endregion

        #region <TOOL BAR AREA >

        #region 조회

        #region 6칸
        //*/
        public override void DoInquire()
        { //임시로 사용할 데이터테이블 생성
            DataTable _DtTemp = new DataTable();
            DBHelper helper = new DBHelper(false);

            try
            {
                if (Convert.ToString(cboQType.Value) != "DATA")
                {
                    if (txtInspCode.Text.Trim().Length <= 2 && txtItemCode.Text.Trim().Length <= 2 && txtInspName.Text.Trim().Length <= 2 && txtItemName.Text.Trim().Length <= 2)
                    {
                        if (DialogResult.OK != ShowDialog(Common.getLangText("입력한 조회 조건이 광범위하여 데이터 조회시 오래 걸릴 수 있습니다.\r\n계속 진행하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO))
                        {
                            CancelProcess = true;
                            return;
                        }
                    }
                }

                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);  // 공장코드
                string sWorkCenterCode = DBHelper.nvlString(txtWorkCenterCode.Text);
                string sWorkCenterName = DBHelper.nvlString(txtWorkCenterName.Text);
                //string.Format("{0:yyyy-MM}", CboStartdate_H.Value);
                string sWorkDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sWorkDateTo = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sWorkDN = DBHelper.nvlString(cboDayNight.Value);
                string sInspResult = DBHelper.nvlString(cboResult.Value);
                string sItemCode = txtItemCode.Text;
                string sItemName = txtItemName.Text;
                string sInspCode = txtInspCode.Text;
                string sInspName = txtInspName.Text;

                _DtTemp = helper.FillTable("USP_PP6200_S1", CommandType.StoredProcedure
                                                          , helper.CreateParameter("pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pWorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pWorkCenterName", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pItemName", sItemName, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pStartDate", sWorkDate, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pEndDate", sWorkDateTo, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pDayNight", sWorkDN, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pInspResult", sInspResult, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pInspCode", sInspCode, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pInspName", sInspName, DbType.String, ParameterDirection.Input)
                                                          , helper.CreateParameter("pQueryType", DBHelper.gGetCode(cboQType.Value), DbType.String, ParameterDirection.Input));

                string[] sExceptString = { "WorkerID", "WorkerName", "InspDate", "InspDN", "RstData1", "Result1", "RstData2", "Result2", "RstData3", "Result3" };

                foreach (DataColumn dc in _DtTemp.Columns)
                {
                    if (!ContainString(sExceptString, dc.ColumnName))
                        dt.Columns.Add(dc.ColumnName);
                }




                _groupHash.Clear();
                // 최초 설정한 컬럼 뒷부분은 모두 숨김.
                for (int i = 0; i < grid1.Columns.Count; i++)
                {
                    if (i >= iColCount)
                    {
                        grid1.Columns[i].Hidden = true;
                    }
                    else
                    {
                        grid1.Columns[i].RowLayoutColumnInfo.OriginX = i * 2;
                        grid1.Columns[i].RowLayoutColumnInfo.OriginY = 0;

                        grid1.Columns[i].RowLayoutColumnInfo.SpanX = 2;
                        grid1.Columns[i].RowLayoutColumnInfo.SpanY = 4;
                    }
                }

                int iIndex = iColCount;
                string sPreInspDate = "";
                string sPreInspDN = "";

                foreach (DataRow dr in _DtTemp.Rows)
                {
                    string sInspDate = DBHelper.nvlString(dr["InspDate"]);
                    string sInspDN = DBHelper.gGetCode(dr["InspDN"]);

                    // 새로운 날짜 데이터가 나타나면, 컬럼명을 수정해야 한다.
                    bool bChange = (sPreInspDate != sInspDate || sPreInspDN != sInspDN);

                    // 선택된 날짜 데이터 저장
                    sPreInspDate = sInspDate;
                    sPreInspDN = sInspDN;

                    string sDNName = DBHelper.nvlString(_DayNightHash[sInspDN]);

                    //for (int c = 0; c < cboDayNight.Items.Count; c++)
                    //{
                    //    KeyValuePair<string, string> sItem = (KeyValuePair<string, string>)cboDayNight.Items[c];
                    //    if (DBHelper.gGetCode(sItem.Key) == sInspDN)
                    //    {
                    //        sDNName = DBHelper.gGetName(sItem.Value);
                    //        break;
                    //    }
                    //}
                    //Grid.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.GroupLayout;
                    // 해당 컬럼명을 수정해야 하면
                    if (bChange)
                    {
                        string sHeaderCaption = sInspDate + " " + sDNName.Trim();
                        iIndex += 9;

                        string sGKey = "Group_" + iIndex.ToString();

                        bool bFind = false;

                        foreach (UltraGridColumn ugc in grid1.Columns)
                        {
                            if (ugc.Key == iIndex.ToString())
                            {
                                bFind = true;
                                break;
                            }
                        }

                        if (!bFind)
                        {
                            //sInspDate + " " + sInspDN
                            // 추가 되어야 함.
                            _GridUtil.InitColumnUltraGrid(grid1, iIndex.ToString(), "WorkerID", false, GridColDataType_emu.VarChar
                                , 60, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);

                            _GridUtil.InitColumnUltraGrid(grid1, (iIndex + 1).ToString(), "작업자", false, GridColDataType_emu.VarChar
                                , 80, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);

                            _GridUtil.InitColumnUltraGrid(grid1, (iIndex + 2).ToString(), "초품", false, GridColDataType_emu.VarChar
                                , 60, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);

                            _GridUtil.InitColumnUltraGrid(grid1, (iIndex + 3).ToString(), "초품결과", false, GridColDataType_emu.VarChar
                                , 50, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
                            // 추가 되어야 함.
                            _GridUtil.InitColumnUltraGrid(grid1, (iIndex + 4).ToString(), "중품", false, GridColDataType_emu.VarChar
                                , 60, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);

                            _GridUtil.InitColumnUltraGrid(grid1, (iIndex + 5).ToString(), "중품결과", false, GridColDataType_emu.VarChar
                                , 50, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
                            // 추가 되어야 함.
                            _GridUtil.InitColumnUltraGrid(grid1, (iIndex + 6).ToString(), "종품", false, GridColDataType_emu.VarChar
                                , 60, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);

                            _GridUtil.InitColumnUltraGrid(grid1, (iIndex + 7).ToString(), "종품결과", false, GridColDataType_emu.VarChar
                                , 50, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
                        }
                        else
                        {
                            // 그리드에는 현재 위치에 컬럼이 있을 때,
                            grid1.Columns[(iIndex + 1).ToString()].Hidden = false;

                            //grid1.Columns[iIndex.ToString()].Header.Caption = "초품";
                            grid1.Columns[(iIndex + 2).ToString()].Hidden = false;

                            //grid1.Columns[(iIndex + 2).ToString()].Header.Caption = "중품";
                            grid1.Columns[(iIndex + 4).ToString()].Hidden = false;

                            //grid1.Columns[(iIndex + 4).ToString()].Header.Caption = "종품";
                            grid1.Columns[(iIndex + 6).ToString()].Hidden = false;
                        }

                        bFind = false;

                        foreach (UltraGridColumn ugc in grid1.Columns)
                        {
                            if (ugc.Key == sGKey)
                            {
                                bFind = true;
                                break;
                            }
                        }

                        if (bFind)
                        {
                            grid1.Columns[sGKey].Header.Caption = sHeaderCaption;
                            grid1.Columns[sGKey].Hidden = false;
                        }
                        else
                        {
                            grid1.Columns.Add(sGKey, sHeaderCaption);
                            grid1.Columns[sGKey].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                            grid1.Columns[sGKey].RowLayoutColumnInfo.OriginX = iIndex * 2;
                            grid1.Columns[sGKey].RowLayoutColumnInfo.OriginY = 0;

                            grid1.Columns[sGKey].RowLayoutColumnInfo.SpanX = 8 * 2;
                            grid1.Columns[sGKey].RowLayoutColumnInfo.SpanY = 2;

                            grid1.Columns[sGKey].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                        }

                        for (int c = 0; c < 8; c++)
                        {
                            grid1.Columns[(iIndex + c).ToString()].RowLayoutColumnInfo.OriginX = (iIndex + c) * 2;
                            grid1.Columns[(iIndex + c).ToString()].RowLayoutColumnInfo.OriginY = 2;
                            grid1.Columns[(iIndex + c).ToString()].Tag = sGKey;

                            if (_groupHash[(iIndex + c).ToString()] == null)
                            {
                                _groupHash.Add((iIndex + c).ToString(), sGKey);
                            }

                            grid1.Columns[(iIndex + c).ToString()].RowLayoutColumnInfo.SpanX = 2;
                            grid1.Columns[(iIndex + c).ToString()].RowLayoutColumnInfo.SpanY = 2;
                        }
                    }

                    // DataTable 에 iIndex 컬럼이 없으면 입력
                    if (!dt.Columns.Contains(iIndex.ToString()))
                    {
                        dt.Columns.Add(iIndex.ToString());
                        dt.Columns.Add((iIndex + 1).ToString());
                        dt.Columns.Add((iIndex + 2).ToString());
                        dt.Columns.Add((iIndex + 3).ToString());
                        dt.Columns.Add((iIndex + 4).ToString());
                        dt.Columns.Add((iIndex + 5).ToString());
                        dt.Columns.Add((iIndex + 6).ToString());
                        dt.Columns.Add((iIndex + 7).ToString());
                    }

                    bool bEqual = false;

                    // 현재 입력된 Row 에서
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // 동일한 데이터가 있는지 확인
                        bEqual = true;

                        foreach (DataColumn dc in _DtTemp.Columns)
                        {
                            // 조회된 데이터와 Inspdate, Result 를 제외한 데이터가 모두 동일한지 확인
                            if (!ContainString(sExceptString, dc.ColumnName))
                            {
                                if (DBHelper.nvlString(dt.Rows[i][dc.ColumnName]) != DBHelper.nvlString(dr[dc.ColumnName]))
                                {
                                    bEqual = false;
                                    break;
                                }
                            }
                        }

                        // 동일한 Row로 확인되면
                        if (bEqual)
                        {
                            // 해당 Rows 의 iIndex 컬럼에 데이터 입력
                            dt.Rows[i][iIndex.ToString()] = DBHelper.nvlString(dr["WorkerID"]);
                            dt.Rows[i][(iIndex + 1).ToString()] = DBHelper.nvlString(dr["WorkerName"]);
                            dt.Rows[i][(iIndex + 2).ToString()] = DBHelper.nvlString(dr["RstData1"]);
                            dt.Rows[i][(iIndex + 3).ToString()] = DBHelper.nvlString(dr["Result1"]);
                            dt.Rows[i][(iIndex + 4).ToString()] = DBHelper.nvlString(dr["RstData2"]);
                            dt.Rows[i][(iIndex + 5).ToString()] = DBHelper.nvlString(dr["Result2"]);
                            dt.Rows[i][(iIndex + 6).ToString()] = DBHelper.nvlString(dr["RstData3"]);
                            dt.Rows[i][(iIndex + 7).ToString()] = DBHelper.nvlString(dr["Result3"]);
                            break;
                        }
                    }

                    // 동일한 Row 가 아니라면
                    if (!bEqual)
                    {
                        // 신규 Row 생성/
                        DataRow tdr = dt.NewRow();

                        // 조회된 데이터에서 Inspdate, Result 를 제외한 데이터를 입력
                        foreach (DataColumn dc in _DtTemp.Columns)
                        {
                            if (!ContainString(sExceptString, dc.ColumnName))
                            {
                                tdr[dc.ColumnName] = dr[dc.ColumnName];
                            }
                        }

                        // iIndex 에 결과값 삽입
                        tdr[iIndex.ToString()] = DBHelper.nvlString(dr["WorkerID"]);
                        tdr[(iIndex + 1).ToString()] = DBHelper.nvlString(dr["WorkerName"]);
                        tdr[(iIndex + 2).ToString()] = DBHelper.nvlString(dr["RstData1"]);
                        tdr[(iIndex + 3).ToString()] = DBHelper.nvlString(dr["Result1"]);
                        tdr[(iIndex + 4).ToString()] = DBHelper.nvlString(dr["RstData2"]);
                        tdr[(iIndex + 5).ToString()] = DBHelper.nvlString(dr["Result2"]);
                        tdr[(iIndex + 6).ToString()] = DBHelper.nvlString(dr["RstData3"]);
                        tdr[(iIndex + 7).ToString()] = DBHelper.nvlString(dr["Result3"]);
                        // 데이터테이블에 추가
                        dt.Rows.Add(tdr);
                    }
                }

                //_GridUtil.SetInitUltraGridBind(grid1);

                grid1.DataSource = dt;
                grid1.DataBinds();

                Hashtable hash = new Hashtable();

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    for (int j = iColCount; j < grid1.Columns.Count; j++)
                    {
                        //SetDataResult(grid1.Rows[i].Cells[j]);
                        // 합격결과에 따라서 글자 색 변경
                        if (DBHelper.nvlString(grid1.Rows[i].Cells[j].Value) == "Y")
                            grid1.Rows[i].Cells[j - 1].Appearance.ForeColor = Color.Blue;

                        if (DBHelper.nvlString(grid1.Rows[i].Cells[j].Value) == "N")
                            grid1.Rows[i].Cells[j - 1].Appearance.ForeColor = Color.Red;
                    }

                    string sType = DBHelper.gGetCode(grid1.Rows[i].Cells["InspValType"].Value);

                    switch (sType)
                    {
                        case "1":
                        case "2":
                        case "5":
                            if (DBHelper.nvlString(grid1.Rows[i].Cells["RelCode1"]) != "" && DBHelper.nvlString(grid1.Rows[i].Cells["RelCode1"]) != "")
                            {
                                ValueList list = null;
                                if (hash[sType] != null)
                                {
                                    list = (ValueList)hash[sType];
                                }
                                else
                                {
                                    list = grid1.DisplayLayout.ValueLists.Add();
                                    list.ValueListItems.Add(DBHelper.nvlString(grid1.Rows[i].Cells["RelCode1"].Value));
                                    list.ValueListItems.Add(DBHelper.nvlString(grid1.Rows[i].Cells["RelCode2"].Value));
                                    list.ValueListItems.Add("");

                                    hash.Add(sType, list);
                                }

                                for (int j = iColCount; j < grid1.Columns.Count; j++)
                                {
                                    if (grid1.Columns[j].Header.Caption == "초품" || grid1.Columns[j].Header.Caption == "중품" || grid1.Columns[j].Header.Caption == "종품")
                                    {
                                        grid1.Rows[i].Cells[j].ValueList = list;
                                    }
                                }
                            }
                            break;

                        case "3":
                            for (int j = iColCount; j < grid1.Columns.Count; j++)
                            {
                                if (grid1.Columns[j].Header.Caption == "초품" || grid1.Columns[j].Header.Caption == "중품" || grid1.Columns[j].Header.Caption == "종품")
                                {
                                    grid1.Rows[i].Cells[j].IgnoreRowColActivation = true;
                                    grid1.Rows[i].Cells[j].Activation = Activation.NoEdit;
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                //if (param != null) { param = null; }
            }
        }
        //*/
        #endregion
        private bool ContainString(string[] sArr, string sItem)
        {
            bool bEqual = false;

            foreach (string s in sArr)
            {
                if (s == sItem)
                {
                    bEqual = true;
                }
            }

            return bEqual;
        }
        #endregion

        #region 저장
        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false); ;

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                DataTable dt = (DataTable)grid1.DataSource;

                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    switch (dt.Rows[iRow].RowState)
                    {
                        case DataRowState.Modified:
                        case DataRowState.Added:
                            #region 추가/수정
                            for (int i = iColCount; i < grid1.Columns.Count; i++)
                            {
                                if (DBHelper.nvlString(grid1.Rows[iRow].Cells[i].Tag) == "Y")
                                {
                                    string sGKey = DBHelper.nvlString(_groupHash[grid1.Columns[i].Key]);
                                    string sGroup = grid1.Columns[sGKey].Header.Caption;
                                    string[] sArr = sGroup.Split(' ');

                                    if (sArr.Length != 2)
                                    {
                                        continue;
                                    }

                                    string sInspDate = sArr[0];
                                    string sInspDN = null;

                                    sInspDN = sArr[1];
                                    sInspDN = DBHelper.nvlString(_DayNightHash[sInspDN]);

                                    int pWorkerID = i;
                                    int pInspValue1 = i + 2;
                                    int pInspResult1 = i + 3;
                                    int pInspValue2 = i + 4;
                                    int pInspResult2 = i + 5;
                                    int pInspValue3 = i + 6;
                                    int pInspResult3 = i + 7;

                                    grid1.Rows[iRow].Cells[pWorkerID].Tag = "";
                                    grid1.Rows[iRow].Cells[pInspValue1].Tag = "";
                                    grid1.Rows[iRow].Cells[pInspResult1].Tag = "";
                                    grid1.Rows[iRow].Cells[pInspValue2].Tag = "";
                                    grid1.Rows[iRow].Cells[pInspResult2].Tag = "";
                                    grid1.Rows[iRow].Cells[pInspValue3].Tag = "";
                                    grid1.Rows[iRow].Cells[pInspResult3].Tag = "";

                                    List<SqlParameter> param = new List<SqlParameter>();

                                    helper.ExecuteNoneQuery("USP_DA1120_I1", CommandType.StoredProcedure
                                                                           , helper.CreateParameter("pPlantCode", DBHelper.gGetCode(dt.Rows[iRow]["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pWorkCenterCode", DBHelper.gGetCode(dt.Rows[iRow]["WorkCenterCode"]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pItemCode", DBHelper.gGetCode(dt.Rows[iRow]["ItemCode"]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pDate", sInspDate, DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pDayNight", DBHelper.nvlString(sInspDN), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pInspCode", DBHelper.gGetCode(dt.Rows[iRow]["InspCode"]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pWorkerID", DBHelper.gGetCode(dt.Rows[iRow][pWorkerID]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pInspValue1", DBHelper.gGetCode(dt.Rows[iRow][pInspValue1]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pInspResult1", DBHelper.gGetCode(dt.Rows[iRow][pInspResult1]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pInspValue2", DBHelper.gGetCode(dt.Rows[iRow][pInspValue2]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pInspResult2", DBHelper.gGetCode(dt.Rows[iRow][pInspResult2]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pInspValue3", DBHelper.gGetCode(dt.Rows[iRow][pInspValue3]), DbType.String, ParameterDirection.Input)
                                                                           , helper.CreateParameter("pInspResult3", DBHelper.gGetCode(dt.Rows[iRow][pInspResult3]), DbType.String, ParameterDirection.Input));
                                }
                            }
                            #endregion
                            break;
                    }
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                throw ex;
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #endregion

        #region 이벤트 처리
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            if (e.Cell.Column.Index >= iColCount)
            {
                string sType = DBHelper.gGetCode(e.Cell.Row.Cells["InspValType"].Value);

                if (e.Cell.Column.Header.Caption == "초품" || e.Cell.Column.Header.Caption == "중품" || e.Cell.Column.Header.Caption == "종품")
                {
                    switch (sType)
                    {
                        case "3":  //확인
                            if (DBHelper.nvlString(e.Cell.Value) == "확인")
                            {
                                e.Cell.Value = "";
                                e.Cell.Row.Cells[e.Cell.Column.Index + 1].Value = "Y";
                            }
                            else
                            {
                                e.Cell.Value = "확인";
                                e.Cell.Row.Cells[e.Cell.Column.Index + 1].Value = "Y";
                            }

                            SetDataResult(e.Cell);
                            //SetEqualValue(e.Cell);
                            break;
                    }
                }
            }
        }

        private void SetDataResult(UltraGridCell cell)
        {
            DBHelper helper = new DBHelper(false);
            bool bChange = false;

            if (cell.Column.Header.Caption == "초품" || cell.Column.Header.Caption == "중품" || cell.Column.Header.Caption == "종품")
            {
                string sType = DBHelper.gGetCode(cell.Row.Cells["InspValType"].Value);
                string sRelCode1 = DBHelper.gGetCode(cell.Row.Cells["RelCode1"].Value);
                string sRelCode2 = DBHelper.gGetCode(cell.Row.Cells["RelCode2"].Value);

                double dLSL = DBHelper.nvlDouble(cell.Row.Cells["ManaLSL"].Value);
                double dUSL = DBHelper.nvlDouble(cell.Row.Cells["ManaUSL"].Value);

                string sGKey = DBHelper.nvlString(_groupHash[cell.Column.Key]);

                string sOK = "Y", sNG = "N";

                if (DBHelper.nvlString(cell.Row.Cells["RelCode3"].Value) != "Y")
                {
                    sNG = "Y";
                }

                if (sRelCode1 == "" && sRelCode2 == "")
                {
                    double dValue = DBHelper.nvlDouble(cell.Value);

                    if (cell.Row.Cells["ManaLSL"].Value == DBNull.Value)
                    {
                        // 하한이 없을 경우
                        if (dUSL >= dValue)
                        {
                            cell.Row.Cells[cell.Column.Index + 1].Value = sOK;
                        }
                        else
                        {
                            cell.Row.Cells[cell.Column.Index + 1].Value = sNG;
                        }
                    }
                    else if (cell.Row.Cells["ManaUSL"].Value == DBNull.Value)
                    {
                        // 상한이 없을 경우
                        if (dLSL <= dValue)
                        {
                            cell.Row.Cells[cell.Column.Index + 1].Value = sOK;
                        }
                        else
                        {
                            cell.Row.Cells[cell.Column.Index + 1].Value = sNG;
                        }
                    }
                    else
                    {
                        if (dLSL <= dValue && dUSL >= dValue)
                        {
                            cell.Row.Cells[cell.Column.Index + 1].Value = sOK;
                        }
                        else
                        {
                            cell.Row.Cells[cell.Column.Index + 1].Value = sNG;
                        }
                    }
                    //SetDataResult(cell);
                    bChange = true;
                }
                else
                {
                    if (sRelCode2 == DBHelper.nvlString(cell.Value))
                    {
                        cell.Row.Cells[cell.Column.Index + 1].Value = sNG;
                    }
                    else
                    {
                        cell.Row.Cells[cell.Column.Index + 1].Value = sOK;
                    }

                    bChange = true;
                    //SetDataResult(_ActiveCell);
                    ///SetEqualValue(_ActiveCell);
                }
            }

            if (bChange)
            {
                cell.Tag = "Y";

                if (DBHelper.nvlString(cell.Row.Cells[cell.Column.Index + 1].Value) == "N")
                {
                    cell.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    cell.Appearance.ForeColor = Color.Blue;
                }

                int iWorkerID = 0;
                int iWorkerName = 0;

                switch (cell.Column.Header.Caption)
                {
                    case "초품":
                        iWorkerID = cell.Column.Index - 2;
                        iWorkerName = cell.Column.Index - 1;
                        break;
                    case "중품":
                        iWorkerID = cell.Column.Index - 4;
                        iWorkerName = cell.Column.Index - 3;
                        break;
                    case "종품":
                        iWorkerID = cell.Column.Index - 6;
                        iWorkerName = cell.Column.Index - 5;
                        break;
                }

                if (txtWorkerID.Text.Trim() != "" && txtWorkerName.Text.Trim() != "")
                {
                    if (DBHelper.nvlString(cell.Row.Cells[iWorkerID].Value) == ""
                            || DBHelper.nvlString(cell.Row.Cells[iWorkerName].Value) == "")
                    {
                        cell.Row.Cells[iWorkerID].Value = txtWorkerID.Text.Trim();
                        cell.Row.Cells[iWorkerName].Value = txtWorkerName.Text.Trim();
                    }
                }

                cell.Row.Cells[iWorkerID].Tag = "Y";
            }
        }

        private void SetEqualValue(UltraGridCell cell)
        {
            DBHelper helper = new DBHelper(false);
            // 아래로 적용
            string sItemCode = DBHelper.nvlString(grid1.Rows[cell.Row.Index].Cells["ItemCode"].Value);
            string sType = DBHelper.gGetCode(grid1.Rows[cell.Row.Index].Cells["InspValType"].Value);

            for (int ia = cell.Row.Index + 1; ia < grid1.Rows.Count; ia++)
            {
                string sItemCode2 = DBHelper.gGetCode(grid1.Rows[ia].Cells["ItemCode"].Value);
                string sValType2 = DBHelper.gGetCode(grid1.Rows[ia].Cells["InspValType"].Value);

                if (sType == sValType2)
                {
                    if (DBHelper.nvlString(grid1.Rows[ia].Cells[cell.Column.Index].Value) == "")
                    {
                        if (sItemCode2 == sItemCode)
                        {
                            grid1.Rows[ia].Cells[cell.Column.Index].Value = cell.Row.Cells[cell.Column.Index].Value;
                            grid1.Rows[ia].Cells[cell.Column.Index + 1].Value = cell.Row.Cells[cell.Column.Index + 1].Value;
                            grid1.Rows[ia].Cells[cell.Column.Index].Tag = "Y";

                            if (DBHelper.nvlString(grid1.Rows[ia].Cells[cell.Column.Index + 1].Value) == "N")
                            {
                                grid1.Rows[ia].Cells[cell.Column.Index].Appearance.ForeColor = Color.Red;
                            }
                            else
                            {
                                grid1.Rows[ia].Cells[cell.Column.Index].Appearance.ForeColor = Color.Blue;
                            }

                            int iWorkerID = 0;
                            int iWorkerName = 0;

                            if (txtWorkerID.Text.Trim() != "" && txtWorkerName.Text.Trim() != "")
                            {
                                switch (cell.Column.Header.Caption)
                                {
                                    case "초품":
                                        iWorkerID = cell.Column.Index - 2;
                                        iWorkerName = cell.Column.Index - 1;
                                        break;
                                    case "중품":
                                        iWorkerID = cell.Column.Index - 4;
                                        iWorkerName = cell.Column.Index - 3;
                                        break;
                                    case "종품":
                                        iWorkerID = cell.Column.Index - 6;
                                        iWorkerName = cell.Column.Index - 5;
                                        break;
                                }

                                if (iWorkerName > 0 && iWorkerID > 0)
                                {
                                    if (DBHelper.nvlString(grid1.Rows[ia].Cells[iWorkerID].Value) == ""
                                            || DBHelper.nvlString(grid1.Rows[ia].Cells[iWorkerName].Value) == "")
                                    {
                                        grid1.Rows[ia].Cells[iWorkerID].Value = txtWorkerID.Text.Trim();
                                        grid1.Rows[ia].Cells[iWorkerName].Value = txtWorkerName.Text.Trim();
                                    }
                                }
                            }

                            grid1.Rows[ia].Cells[iWorkerID].Tag = "Y";
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            SetDataResult(e.Cell);
        }

        #endregion

    }
}
