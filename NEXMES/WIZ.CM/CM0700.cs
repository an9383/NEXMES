#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class CM0700 : WIZ.Forms.BaseMDIChildForm
    {

        #region < MEMBER AREA >

        #endregion

        #region < CONSTRUCTOR >

        public CM0700()
        {
            InitializeComponent();
        }

        private void CM0700_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.lblDate, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(lblDate, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblDate, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblDate, "machname", "설비명", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblDate, "COUNT", "수리건수", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblDate, "FaultTime", "수리시간(분)", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblDate, "MTTR", "MTTR", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(lblDate, "MTBF", "MTBF", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(lblDate);

            //그리드 라인 색깔 해제
            //grid1.UseAppStyling = false;
            lblDate.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            lblDate.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.lblDate, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.lblDate);
            #endregion

            #endregion Grid 셋팅

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();
                string sMachCode = txtMachCode.Text.Trim();
                string sWMachName = txtMachName.Text.Trim();
                string sdate = cbo_date.Text.Trim().ToString();
                string sdate_to = cbo_dateto.Text.Trim().ToString();

                lblDate.DataSource = helper.FillTable("USP_CM0700_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@ect1", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ect2", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ect3", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@MACHNAME", sWMachName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@FROMDATE", sdate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@TODATE", sdate_to, DbType.String, ParameterDirection.Input));
                //_GridUtil.SetInitUltraGridBind(grid1);
                lblDate.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region<DoBaseSum>
        public override void DoBaseSum()
        {
            base.DoBaseSum();
            UltraGridRow ugr = lblDate.DoSummaries(new string[] { "COUNT", "FaultTime", "MTTR", "MTBF" });
        }
        #endregion
    }
}
