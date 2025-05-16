#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0090
//   Form Name    : 제품 입고이력
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Editor       : 
//   Edit Date    :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Configuration;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0090 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region < CONSTRUCTOR >
        public WM0090()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0090_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "입고자명", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INTYPE", "입고유형", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FRWHCODE", "FROM 창고코드", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FRSTORAGELOCCODE", "FROM 위치코드", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "TO 창고코드", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "TO 위치코드", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);

                grid1.Columns["INQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FRWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0090_CODE("");  //위치
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FRSTORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("INTYPE");  //입고유형
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-5);
                cbo_ENDDATE_H.Value = DateTime.Now;

                #endregion

                #region < POP-UP SETTING >

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

                #endregion


                //txt_LOTNO_H.Select();
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
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            base.DoInquire();

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_WM0090_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    return;
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
    }
}
