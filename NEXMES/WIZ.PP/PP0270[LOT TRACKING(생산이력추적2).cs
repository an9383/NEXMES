#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0270
//   Form Name    : LOT 생산이력추적
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Editor       : 
//   Edit Date    :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0270 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region < CONSTRUCTOR >
        public PP0270()
        {
            InitializeComponent();
        }
        #endregion
        #region < FORM LOAD >
        private void PP0270_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING
                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid1, "LVL",            "레벨",      false, GridColDataType_emu.VarChar,   50,  80, Infragistics.Win.HAlign.Right,  true, false, null, null, null, null, null);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "생산LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "생산품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "생산단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO", "투입LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "INITEMCODE", "투입품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "INITEMNAME", "투입품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "INLOTQTY", "투입수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###,##0", null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "INUNITCODE", "투입생산단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTDATE", "발생날짜", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


                _GridUtil.SetInitUltraGridBind(grid1);

                //_GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장",         false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left,   false, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "INOUTDATE", "입출고일자",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true,  false);
                //_GridUtil.InitColumnUltraGrid(grid2, "TYPENAME",  "입출고구분명",   false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left,   true,  false);
                //_GridUtil.InitColumnUltraGrid(grid2, "QTY",       "수량",           false, GridColDataType_emu.Double,  100, 100, Infragistics.Win.HAlign.Right,  true,  false);
                //_GridUtil.InitColumnUltraGrid(grid2, "WHCODE",    "FROM 창고",      false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left,   true,  false);
                //_GridUtil.InitColumnUltraGrid(grid2, "LOCCODE",   "FROM 위치",      false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left,   true,  false);
                //_GridUtil.InitColumnUltraGrid(grid2, "TOWHCODE",  "TO 창고",        false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left,   true,  false);
                //_GridUtil.InitColumnUltraGrid(grid2, "TOLOCCODE", "TO 위치",        false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left,   true,  false);
                //_GridUtil.SetInitUltraGridBind(grid2);
                #endregion

                #region COMBOBOX SETTING
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0130_CODE(""); //단위              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INUNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "TOWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0090_CODE(""); // 저장위치
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "TOLOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                #endregion

                txt_LOTNO_H.Select();
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion 

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            //_GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화

            ultraSplitter.Visible = false;
            // grid2.Visible = false;

            DBHelper helper = new DBHelper(false);

            base.DoInquire();

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());

                if (sLotNo == "")
                {
                    ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("LOTNO 를 입력 후 조회하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_PP0270_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    //조회시 입력한 LOTNO와 GRID의 LOTNO가 같으면 노란색으로 표시
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (Convert.ToString(grid1.Rows[i].Cells["LOTNO"].Value.ToString()) == sLotNo)
                        {
                            grid1.Rows[i].Appearance.BackColor = Color.FromArgb(254, 255, 100);
                        }
                    }

                    this.grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    //this.grid1.DisplayLayout.Bands[0].Columns["LVL"].MergedCellStyle = MergedCellStyle.Always;
                    //this.grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;

                    this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                    this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
                    this.grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;

                    this.grid1.DisplayLayout.Bands[0].Columns["UNITCODE"].MergedCellStyle = MergedCellStyle.Always;
                    this.grid1.DisplayLayout.Bands[0].Columns["INITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    this.grid1.DisplayLayout.Bands[0].Columns["INITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
                    this.grid1.DisplayLayout.Bands[0].Columns["INLOTNO"].MergedCellStyle = MergedCellStyle.Always;


                }
                else
                {
                    ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("LOTNO에 연결된 정보가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                ClosePrgFormNew();
                this.ShowDialog(ex.Message.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }
        #endregion

        private void grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //_GridUtil.Grid_Clear(grid2);

            //if ((grid1.ActiveRow.Cells["INLOTNO"].Value.ToString().Substring(0, 1)).ToLower() == "E".ToLower() || (grid1.ActiveRow.Cells["INLOTNO"].Value.ToString().Substring(0, 1)).ToLower() == "M".ToLower())
            //{
            //    ultraSplitter.Visible   = true;
            //    grid2.Visible = true;

            //    DBHelper helper = new DBHelper(false);

            //    try
            //    {
            //        string sLotNo = DBHelper.nvlString(grid1.ActiveRow.Cells["INLOTNO"].Value);

            //        rtnDtTemp = helper.FillTable("USP_PP0220_S2", CommandType.StoredProcedure
            //                                     , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

            //        if (rtnDtTemp.Rows.Count > 0)
            //        {
            //            grid2.DataSource = rtnDtTemp;
            //            grid2.DataBinds();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ClosePrgFormNew();
            //        this.ShowDialog(ex.Message.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            //    }
            //    finally
            //    {
            //        helper.Close();
            //        ClosePrgFormNew();
            //    }
            //}
            //else
            //{
            //    ultraSplitter.Visible   = false;
            //    grid2.Visible = false;
            //}
        }
    }
}
