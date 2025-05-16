#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0020
//   Form Name    : 생산실적조회
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-17
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 생산실적조회
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0020 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        //-- return DataTable
        DataTable rtnDtTemp = new DataTable();
        DataTable _DtTemp = new DataTable();

        //-- 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        #endregion

        #region < CONSTRUCTOR >
        public PP0020()
        {
            InitializeComponent();
        }

        protected override void SetSubData()
        {
            string sMethodText = subData["METHOD_TYPE"];

            if (sMethodText == "CUSTOMER")
            {
                lbl_CUSTCODE_H.Visible = true;
                txt_CUSTCODE_H.Visible = true;
                txt_CUSTNAME_H.Visible = true;
            }
        }

        #endregion

        #region < FORM LOAD >
        private void PP0020_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산계획번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "생산일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.Columns["ORDERQTY"].Format = "#,##0";
            grid1.Columns["PRODQTY"].Format = "#,##0";
            grid1.Columns["ERRORQTY"].Format = "#,##0";


            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0060_CODE("");         //작업장           
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;
            #endregion

            #region POPUP SETTING

            //작업장명
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
            //거래처명
            btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "" });
            //품목
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
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);             //공장
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);//조회일자(시작)
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);  //조회일자(종료)                
                string sWorkcenterCode = txt_WORKCENTERCODE_H.Text.Trim();                              //작업장코드       
                string sWorkCenterName = txt_WORKCENTERNAME_H.Text.Trim();
                string sOPCODE = txtOPCode.Text.Trim();
                string sOPNAME = txtOPName.Text.Trim();
                string sItemCode = txt_ITEMCODE_H.Text.Trim();                            //품목
                string sItemName = txt_ITEMNAME_H.Text.Trim();

                if (Common.DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                rtnDtTemp = helper.FillTable("USP_PP0020_S2", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WORKCENTERNAME", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_OPCODE", sOPCODE, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_OPNAME", sOPNAME, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text, DbType.String, ParameterDirection.Input)
                                        );
                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ORDERNO"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                    grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Middle;
                    grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;
                    grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                    //그리드 가로 세로 Line 설정
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        grid1.DisplayLayout.Rows[i].Appearance.BorderColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion


        #region < EVENT AREA >
        /*        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
                {
                    e.Row.Appearance.BackColor = Color.White;
                }*/

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            Common.CustomMergedCellEvalutor CM1 = new Common.CustomMergedCellEvalutor("RECDATE", "PRODQTY");

            e.Layout.Bands[0].Columns["RECDATE"].MergedCellEvaluator = CM1;
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txt_ITEMCODE_H.Tag = null;
                txt_ITEMCODE_H.Text = string.Empty;
                txt_ITEMNAME_H.Text = string.Empty;
            }
        }

        private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txt_WORKCENTERCODE_H.Tag = null;
                txt_WORKCENTERCODE_H.Text = string.Empty;
                txt_WORKCENTERNAME_H.Text = string.Empty;
            }
        }
        #endregion
    }
}