#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0002
//   Form Name    : 작업지시 생성 및 확정
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WIZ.PopUp;
using WIZ.Control;

using Infragistics.Win.UltraWinGrid;
using System.Collections.Generic;
using System.Text;
#endregion

namespace WIZ.MM
{
    public partial class MM0002 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataTable rtnDtTemp3 = new DataTable();
        DataTable rtnDtTemp4 = new DataTable();


        DataTable dtGrid2;


        #endregion

        #region < CONSTRUCTOR >
        public MM0002()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0002_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        private void BtbManager_PopUpClosed(object tCode, object tName, bool bFindOK)
        {
            SBtnTextEditor sCode = tCode as SBtnTextEditor;
            SBtnTextEditor sName = tName as SBtnTextEditor;

            if (tCode != null)
            {
                if (sCode.Name == "txt_ITEMCODE_S")
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("Select BACKCOLOR FROM BM0010 with (NOLOCK) where ITEMCODE = '" + sCode.Text.Trim() + "' ");

                    DBHelper db = new DBHelper();

                    DataTable dt = db.FillTable(sSQL.ToString());

                    sCode.Appearance.BackColor = Color.White;
                    sName.Appearance.BackColor = Color.White;

                    if (dt.Rows.Count == 1)
                    {
                        string sBackColor = DBHelper.nvlString(dt.Rows[0]["BACKCOLOR"]);
                        Color _color = ColorTranslator.FromHtml(sBackColor);

                        sCode.Appearance.BackColor = _color;
                        sName.Appearance.BackColor = _color;
                    }
                }
            }
        }

        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TMPINDATE", "가입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO2", "재발행발주번호", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "발주순번", true, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TMPINGROUPNO", "발주그룹순번", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "최초수량", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "출하수량", true, GridColDataType_emu.Double, 80, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REORDER", "재발주처리", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);
                
                //grid2
                DBHelper helper = new DBHelper(true);

                bool Colvisible_DS = false;
                if (helper.DBConnect.Database.ToString() == "P2001")
                {
                    Colvisible_DS = true;
                }

                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PONO", "이전발주번호", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "POSEQNO", "발주순번", true, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PONO2", "재발행발주번호", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PODATE", "발주일", true, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANINDATE", "입고예정일", true, GridColDataType_emu.YearMonthDay, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE2", "거래처2", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, Colvisible_DS, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME2", "거래처명2", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, Colvisible_DS, true);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "반출LOT번호", true, GridColDataType_emu.VarChar, 130, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPENAME", "품목유형", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPFLAG", "검사구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "POQTY", "발주량(ⓐ)", true, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCOST", "매입단가", true, GridColDataType_emu.Float, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTSTATUS", "상태", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);

                //2020-07-07 이후 개발 예정
                _GridUtil.InitColumnUltraGrid(grid2, "UNITBUTTON", "단위량계산", true, GridColDataType_emu.Button, 90, 100, Infragistics.Win.HAlign.Center, Colvisible_DS, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MATERIALGRADE", "재질", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INQTY", "입고량", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "TMPINQTY", "가입고량(ⓑ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "REINQTY", "입고잔량\r\n(ⓐ-ⓑ)", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Center, true, true);

                //2021-06-15 최문석 금액부분 추가
                _GridUtil.InitColumnUltraGrid(grid2, "FINISHFLAG", "진행여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime24, 160, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime24, 160, 100, Infragistics.Win.HAlign.Center, true, false);

                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["PODATE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["PLANINDATE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["CUSTCODE2"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["CUSTNAME2"].Header.Appearance.ForeColor   = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["POQTY"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["USEFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["UNITCOST"].Header.Appearance.ForeColor = Color.SkyBlue;

                //grid2.Columns["POQTY"].Format = "#,##0";
                //grid2.Columns["INQTY"].Format = "#,##0";
                //grid2.Columns["TMPINQTY"].Format = "#,##0";
                //grid2.Columns["REINQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid2);


                #region --- Combobox & Popup Setting ---

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-30);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(1);

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //rtnDtTemp = _Common.GET_BM0000_CODE("URGENT");
                //UltraGridUtil.SetComboUltraGrid(this.grid4, "URGENT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //2109.11.20 추가로 함
                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE"); //품목유형
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

                btbManager.PopUpClosed += BtbManager_PopUpClosed;
                // grid 입력용 POPUP
                bizGridManager = new BizGridManager(grid2);
                //bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });
                bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "BM0030", new string[] { "PLANTCODE", "VD", "" });
                //bizGridManager.PopUpAdd("CUSTCODE2", "CUSTNAME2", "BM0030", new string[] { "PLANTCODE", "VD", "" });
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                            // 사업장(공장)
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");   // 가입고시작일자
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");     // 가입고 끝일자
                //string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());                          // LOTNO
                //string sPoNo = DBHelper.nvlString(txt_PONO_H.Text.Trim());                           // 발주번호
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_MM0002_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    //, helper.CreateParameter("AS_LOTNO",     sLotNo,     DbType.String, ParameterDirection.Input)
                                                                    //, helper.CreateParameter("AS_PONO",      sPoNo,      DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
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

        public override void DoNew()
        {
            _GridUtil.Grid_Clear(grid2);

            base.DoNew();

            try
            {
                if (grid1.ActiveRow.Cells["REORDER"].Value.ToString().Trim() == "N")
                {
                    int iRow = grid2.InsertRow();
                    grid2.Rows[iRow].Cells["PONO"].Value = CModule.ToString(grid1.ActiveRow.Cells["PONO"].Value);
                    grid2.Rows[iRow].Cells["PLANTCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    grid2.Rows[iRow].Cells["ITEMCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    grid2.Rows[iRow].Cells["ITEMNAME"].Value = CModule.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                    grid2.Rows[iRow].Cells["LOTNO"].Value = CModule.ToString(grid1.ActiveRow.Cells["LOTNO"].Value);

                    grid2.Rows[iRow].Cells["CUSTCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
                    grid2.Rows[iRow].Cells["CUSTNAME"].Value = CModule.ToString(grid1.ActiveRow.Cells["CUSTNAME"].Value);
                    grid2.Rows[iRow].Cells["PODATE"].Value = DBHelper.nvlDateTime(DateTime.Now).ToString("yyyy-MM-dd");
                    grid2.Rows[iRow].Cells["PLANINDATE"].Value = DBHelper.nvlDateTime(DateTime.Now.AddDays(7)).ToString("yyyy-MM-dd");
                    grid2.Rows[iRow].Cells["POQTY"].Value = CModule.ToString(grid1.ActiveRow.Cells["LOTQTY"].Value);
                    grid2.Rows[iRow].Cells["UNITCOST"].Value = "0";

                    grid2.Rows[iRow].Cells["USEFLAG"].Value = "Y";
                    grid2.Rows[iRow].Cells["MAKER"].Value = CModule.ToString(grid1.ActiveRow.Cells["MAKER"].Value);
                    grid2.Rows[iRow].Cells["MAKEDATE"].Value = DBHelper.nvlDateTime(DateTime.Now).ToString();
                    grid2.Rows[iRow].Cells["EDITOR"].Value = CModule.ToString(grid1.ActiveRow.Cells["EDITOR"].Value);
                    grid2.Rows[iRow].Cells["EDITDATE"].Value = DBHelper.nvlDateTime(DateTime.Now).ToString();
                    grid2.Rows[iRow].Cells["LOTNO"].Value = CModule.ToString(grid1.ActiveRow.Cells["LOTNO"].Value);

                    grid2.Rows[iRow].Cells["PLANTCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["PONO"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["ITEMCODE"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["ITEMNAME"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["LOTNO"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["CUSTCODE"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["CUSTNAME"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["PODATE"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["POQTY"].Activation = Activation.NoEdit;
                    grid2.Rows[iRow].Cells["UNITCOST"].Activation = Activation.NoEdit;
                    //grid2.ActiveRow.Cells["FINISHFLAG"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                }
                else
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("재발주처리가 완료되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;

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


        //public override void DoDelete()
        //{
        //    base.DoDelete();

        //    this.grid4.DeleteRow();

        //    DataTable dtChange = grid4.chkChange();
        //}

        public override void DoSave()
        {
            rtnDtTemp = grid2.chkChange();
            if (rtnDtTemp == null)
                return;

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoSave();

                string ssub = subData["RELCODE1"];

                string sPoDate = string.Empty;
                string sPoNo = string.Empty;
                string sLotNo = string.Empty;
                string sPlanInDate = string.Empty;
                string sFinishFlag = string.Empty;

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["PODATE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("발주일자를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["PLANINDATE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("입고예정일을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (drRow["ITEMCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["CUSTCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("거래처를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["POQTY"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("발주수량을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (drRow["ITEMTYPE"].ToString().Trim() == "1" && drRow["ITEMTYPE"].ToString().Trim() == "2")
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("완제품 및 반제품은 발주정보를 등록 할수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }
                }

                this.ClosePrgFormNew();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            //sFinishFlag = DBHelper.nvlString(drRow["FINISHFLAG"]);

                            //if (sFinishFlag != "D")
                            //{
                            //    this.ClosePrgFormNew();
                            //    throw new Exception(Common.getLangText("발주정보 상태가 대기가 아닙니다. 삭제 할 수 없습니다.", "MSG"));
                            //}

                            helper.ExecuteNoneQuery("USP_MM0000_D1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PONO", DBHelper.nvlString(drRow["PONO"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AI_POSEQNO", DBHelper.nvlInt(drRow["POSEQNO"]), DbType.Int32, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            sPoNo = DBHelper.nvlString(drRow["PONO"]);
                            sLotNo = DBHelper.nvlString(drRow["LOTNO"]);
                            sPoDate = DBHelper.nvlString(drRow["PODATE"]).Substring(0, 10);
                            sPlanInDate = DBHelper.nvlString(drRow["PLANINDATE"]).Substring(0, 10);

                            string sValue = "";
                            DBHelper helper2 = new DBHelper("", true);
                            if (ssub == "M_CURRECNY")
                            {
                                sValue = DBHelper.nvlString(drRow["CURRENCY"]);
                            }

                            helper.ExecuteNoneQuery("USP_MM0002_I1", CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PODATE", sPoDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PLANINDATE", sPlanInDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_POQTY", DBHelper.nvlDouble(drRow["POQTY"]), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_UNITCOST", DBHelper.nvlDouble(drRow["UNITCOST"]), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //sFinishFlag = DBHelper.nvlString(drRow["FINISHFLAG"]);

                            //if (sFinishFlag != "D")
                            //{
                            //    this.ClosePrgFormNew();
                            //    throw new Exception(Common.getLangText("발주정보 상태가 대기가 아닙니다. 수정 할 수 없습니다.", "MSG"));
                            //}

                            sPoDate = DBHelper.nvlString(drRow["PODATE"]).Substring(0, 10);
                            sPlanInDate = DBHelper.nvlString(drRow["PLANINDATE"]).Substring(0, 10);
                            sLotNo = DBHelper.nvlString(drRow["LOTNO"]);

                            helper.ExecuteNoneQuery("USP_MM0002_U1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PONO", grid2.ActiveRow.Cells["PONO"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_LOTNO", grid2.ActiveRow.Cells["LOTNO"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AI_POSEQNO", grid2.ActiveRow.Cells["POSEQNO"].Value, DbType.Int32, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PODATE", sPoDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PLANINDATE", sPlanInDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AF_POQTY", DBHelper.nvlDouble(drRow["POQTY"]), DbType.Double, ParameterDirection.Input)
                                                   , helper.CreateParameter("AI_COST", DBHelper.nvlDouble(drRow["UNITCOST"]), DbType.Int32, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_USEFLAG", grid2.ActiveRow.Cells["USEFLAG"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                this.ClosePrgFormNew();
                helper.Commit();
                grid1.UpdateData();
                grid2.UpdateData();
                //_GridUtil.Grid_Clear(grid2);
                DoInquire(); //성공적으로 수행되었을 경우에만 조회
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

        #region < EVENT AREA >

        /* 2019.11.15 수정 */
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;

            DBHelper helper = new DBHelper(false);

            if (grid1.Rows.Count <= 0)
                return;

            try
            {
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sPoNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PONO"].Value);
                string sLotNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["LOTNO"].Value);
                //string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value).Trim();

                if (sPlantCode == string.Empty || sLotNo == string.Empty)
                    return;

                dtGrid2 = helper.FillTable("USP_MM0002_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                       //, helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       );

                grid2.DataSource = dtGrid2;
                grid2.DataBinds(dtGrid2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);

            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }


        #endregion

        #region < METHOD AREA >

        #endregion

    }
}
