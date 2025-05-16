#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0023
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
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    //일렉트로엠 때문에 보냄
    public partial class PP0023 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        //-- return DataTable
        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataTable _DtTemp = new DataTable();

        //-- 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        PopUp_Biz _biz = new PopUp_Biz();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        #endregion

        #region < CONSTRUCTOR >
        public PP0023()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0023_Load(object sender, EventArgs e)
        {

            #region GRID SETTING
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPINFO", "공정정보", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERINFO", "작업장정보", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산계획", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMINFO", "품목정보", false, GridColDataType_emu.VarChar, 240, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKSTATDATE", "생산시작", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKENDDATE", "생산종료", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "생산일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERINFO", "작업장정보", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMINFO", "품목정보", false, GridColDataType_emu.VarChar, 240, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "LOTQTY", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INLOTNO", "투입LOTNO", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INITEMINFO", "투입품목정보", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INLOTQTY", "투입LOTQTY", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INUNITCODE", "투입단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INLOTDATE", "투입일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTDATE", "처리일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);

            //_GridUtil.InitColumnUltraGrid(grid2, "OPSEQ", "공정순서", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY",       "불량수량",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right,  true, false);         
            _GridUtil.SetInitUltraGridBind(grid2);


            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            //rtnDtTemp = _Common.GET_BM0060_CODE("");         //작업장           
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            //cbo_ENDDATE_H.Value   = DateTime.Now;
            #endregion

            #region POPUP SETTING

            ////작업장명
            //btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
            ////품목
            //btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
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
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);   //공장

                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text);

                //string sPlanNo = DBHelper.nvlString(txt_PLANNO_H.Text);

                if (sLotNo == "")
                {
                    ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("LOTNO 를 입력 후 조회하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_PP0023_S1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                        //, helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("PC_CODE", "S1", DbType.String, ParameterDirection.Input));

                rtnDtTemp2 = helper.FillTable("USP_PP0023_S1", CommandType.StoredProcedure
                                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                      //, helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("PC_CODE", "S2", DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;                    
                    //grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ORDERNO"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                    //grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Middle;
                    //grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    //grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;                    
                    //grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    //grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                    ////그리드 가로 세로 Line 설정
                    //for (int i = 0; i < grid1.Rows.Count; i++)
                    //{
                    //    grid1.DisplayLayout.Rows[i].Appearance.BorderColor = Color.Black;
                    //}
                }

                if (rtnDtTemp2.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp2;
                    grid2.DataBinds();

                    //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;                    
                    //grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ORDERNO"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    //grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                    //grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Middle;
                    //grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    //grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;                    
                    //grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    //grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                    ////그리드 가로 세로 Line 설정
                    //for (int i = 0; i < grid1.Rows.Count; i++)
                    //{
                    //    grid1.DisplayLayout.Rows[i].Appearance.BorderColor = Color.Black;
                    //}
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

        //private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Back)
        //    {
        //        txt_ITEMCODE_H.Tag = null;
        //        txt_ITEMCODE_H.Text = string.Empty;
        //        txt_ITEMNAME_H.Text = string.Empty;
        //    }
        //}

        //private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Back)
        //    {
        //        txt_WORKCENTERCODE_H.Tag = null;
        //        txt_WORKCENTERCODE_H.Text = string.Empty;
        //        txt_WORKCENTERNAME_H.Text = string.Empty;
        //    }
        //}
        #endregion

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

                string sPlantCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);             //공장

                string sLotNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["LOTNO"].Value);

                string sWorkCenter = this.grid1.ActiveRow.Cells["WORKCENTERINFO"].Value.ToString().Substring(1, 6);

                if (sPlantCode == string.Empty || sLotNo == string.Empty)
                    return;

                rtnDtTemp2 = helper.FillTable("USP_PP0023_S2", CommandType.StoredProcedure
                                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("AS_WORKCENTERINFO", sWorkCenter, DbType.String, ParameterDirection.Input)
                                      , helper.CreateParameter("PC_CODE", "S2", DbType.String, ParameterDirection.Input));

                grid2.DataSource = rtnDtTemp2;
                grid2.DataBinds(rtnDtTemp2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
    }
}