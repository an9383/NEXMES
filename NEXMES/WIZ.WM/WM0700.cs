#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM0700
//   Form Name    :  제품 입출고 이력현황
//   Name Space   :  WIZ.WM
//   Created Date :  
//   Made By      :  WIZCORE
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
    public partial class WM0700 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public WM0700()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0700_Load(object sender, EventArgs e)
        {
            #region ▶ GRID

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTDATE", "입출일자", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고수량", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTQTY", "출고수량", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "INQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "OUTQTY", Infragistics.Win.HAlign.Right);

            grid1.Columns["INQTY"].Format = "#,##0";
            grid1.Columns["OUTQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region ▶ POP-UP
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "" });
            #endregion

            #region ▶ COMBOBOX

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.plantCode = CModule.GetAppSetting("Site", "10");
            cboPlantCode.Value = plantCode;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sItemCode = txtItemCode.Text.Trim();
                string sStDate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEdDate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);

                rtnDtTemp = helper.FillTable("USP_WM0700_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", sStDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", sEdDate, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다."), Forms.DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText(helper.RSMSG), Forms.DialogForm.DialogType.OK);

                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText(ex.ToString()), Forms.DialogForm.DialogType.OK);
                return;
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        #endregion

        #region < METHOD AREA >

        #endregion
    }

}