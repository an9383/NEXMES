#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0200
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
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region < CONSTRUCTOR >
        public PP0200()
        {
            InitializeComponent();
        }
        #endregion
        #region < FORM LOAD >
        private void PP0200_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING
                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid1, "LVL",            "레벨",      false, GridColDataType_emu.VarChar,   50,  80, Infragistics.Win.HAlign.Right,  true, false, null, null, null, null, null);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "코드", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "수불일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKINDATE", "장착날짜", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKENDDATE", "탈착날짜", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKLIMITQTY", "한계사용량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "사용량", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


                _GridUtil.SetInitUltraGridBind(grid1);


                #endregion

                #region COMBOBOX SETTING
                //날짜 셋팅
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;


                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });  // 품목
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
                #endregion

                txt_MOLDCODE_H.Select();
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
                string sMoldCode = DBHelper.nvlString(txt_MOLDCODE_H.Text.Trim());
                string sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                base.DoInquire();


                rtnDtTemp = helper.FillTable("USP_PP0200_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

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
