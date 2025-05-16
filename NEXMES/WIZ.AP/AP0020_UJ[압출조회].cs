#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0020
//   Form Name    : 작업지시 편성 정보 조회
//   Name Space   : WIZ.AP
//   Created Date : 2018-01-16
//   Made By      : WIZ
//   Edited Date  : 
//   Edit By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Threading;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0020_UJ : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Thread trSelectPrintContents;

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Common _Common = new Common();
        bool xlsVer = true;
        DataTable rtnDtTemp = new DataTable();


        #endregion

        #region < CONSTRUCTOR >
        public AP0020_UJ()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0020_UJ_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID2 작업지시
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKDATE", "작업일자", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "순번", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PNUM", "식별번호", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NonP", "Non-P 수량", false, GridColDataType_emu.VarChar, 90, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTP", "발행수량", false, GridColDataType_emu.VarChar, 200, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DIFF", "차이수량", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MES_LOTNO", "MES_LOTNO", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "COL_TYPE", "지시수량", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRINTDATE", "출력시간", false, GridColDataType_emu.VarChar, 80, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LINK_LOTNO", "LINK_LOTNO", false, GridColDataType_emu.VarChar, 200, true, false);


                _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "LOTP", Infragistics.Win.HAlign.Right);

                _GridUtil.SetInitUltraGridBind(grid1);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;


                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                #endregion

                #region POPUP SETTING

                //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });                        //공정
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });                    //품목
                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        #endregion

        #region < TOOL BAR AREA >

        /// <summary>
        /// /// ToolBar의 조회 버튼 클릭
        /// /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyyMMdd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value);
                //string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());
                string sMesLotNo = DBHelper.nvlString(txt_MES_LOTNO_H.Text.Trim());


                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_AP0020_UJ_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SDATE", sStartDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_EDATE", sEndDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MESLOTNO", sMesLotNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion

        #region < EVENT AREA >

        #endregion
    }
}