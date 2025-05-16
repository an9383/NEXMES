#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM4300
//   Form Name    : 발주대비 미납현황 상세
//   Name Space   : WIZ.WM
//   Created Date : 2015.11.10
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.IO.Ports;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM4300 : WIZ.Forms.BaseMDIChildForm
    {
        #region ▶ Member Field 
        // return DataTable 공통
        DataTable rtnDtTemp = new DataTable();
        DataTable DTChange1 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();
        SerialPort ComPort = new SerialPort();

        Common _Common = new Common();
        #endregion ▶ Member Field

        public WM4300()
        {
            InitializeComponent();
        }

        private void WM4300_Load(object sender, EventArgs e)
        {
            #region ▶ Grid1 Setting 
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "발주처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARTYPE", "차종", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SONO", "발주번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANSHIPDATE", "납품일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, "yyyy-MM-dd", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SOQTY", "발주수량", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPQTY", "납품량", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "VENDOR", "납품처", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "VENDORNAME", "납품처명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DLVYLOC", "하치장", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COUNTRYNAME", "국가", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            DTChange1 = (DataTable)grid1.DataSource;
            grid1.DataSource = DTChange1;
            grid1.DataBind();
            #endregion

            //--사업장
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = "1100";
            //--

            //-- PopUp Setting
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0320Y", new object[] { "", "" });
            //--
        }

        #region < Toolbar Area >
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string plantcode = Convert.ToString(cboPlantCode_H.Value);
                string fromdate = string.Format("{0:yyyy-MM-dd}", cboFromDate.Value);
                string todate = string.Format("{0:yyyy-MM-dd}", cboToDate.Value);
                string custcode = this.txtCustCode.Text.Trim();
                string custName = this.txtCustName.Text.Trim();

                // 발주처 필수 입력항목
                if (custcode.Trim().Length == 0 && custName.Trim().Length == 0)
                {
                    ShowDialog(Common.getLangText("발주처를 반드시 입력 하셔야 합니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                base.DoInquire();

                DTChange1 = helper.FillTable("USP_WM4300_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE", plantcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("FROMPLANSHIPDT", fromdate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("TOPLANSHIPDT", todate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CUSTCODE", custcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CUSTNAME", custName, DbType.String, ParameterDirection.Input)
                                            );
                if (helper.RSCODE != "S")
                {
                    this.ClosePrgFormNew();
                    ShowDialog(helper.RSCODE, WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                grid1.DataSource = DTChange1;
                grid1.DataBinds();

                if (DTChange1.Rows.Count < 1)
                {
                    this.ClosePrgFormNew();
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion < Toolbar Area >
    }
}
