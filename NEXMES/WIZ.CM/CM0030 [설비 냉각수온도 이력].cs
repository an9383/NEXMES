#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : CM0030
//   Form Name    : 설비 냉각수온도 이력
//   Name Space   : WIZ.CM
//   Created Date : 2018.10.05
//   Made By      : JWLEE
//   Description  : 미들웨어에서 자동수집 되는 항목
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;

using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class CM0030 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ MEMBER AREA ]
        DataTable rtnDtTemp = new DataTable();

        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();

        BizTextBoxManager _BtbManager = new BizTextBoxManager();
        #endregion

        #region [ CONSTRUCTOR ]
        public CM0030()
        {
            InitializeComponent();
        }
        #endregion

        #region [ FORM EVENT ]
        private void CM0030_Load(object sender, EventArgs e)
        {
            #region Grid Setting
            _GridUtil.InitializeGrid(grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "측정항목명", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REVISION", "REV.", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "측정일시", false, GridColDataType_emu.VarChar, 160, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPVALUE", "측정결과", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITNAME", "단위", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "스펙종류", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "표준치", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한공차", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한공차", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLWL", "하한워닝", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUWL", "상한워닝", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.SetColumnTextHAlign(grid1, "MACHNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "INSPNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "REVISION", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "INSPVALUE", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECNOL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECLSL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECUSL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECLWL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECUWL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "OPNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
            #endregion

            #region ComboBox & Popup Setting            
            // ComboBox : 사업장 정보
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboPlantCode_H.Value = LoginInfo.PlantCode;

            // Datepicker : 날짜 정보
            dtpSDate_H.Value = DateTime.Now.AddDays(-7);
            dtpEDate_H.Value = DateTime.Now;

            // Popup : 공정 정보
            _BtbManager.PopUpAdd(txtOPCode_H, txtOPName_H, "BM0040", new object[] { cboPlantCode_H, "", "" });

            // Popup : 작업장 정보
            _BtbManager.PopUpAdd(txtWCCode_H, txtWCName_H, "BM0060", new object[] { cboPlantCode_H, "", "", "" });

            // Popup : 설비 정보
            _BtbManager.PopUpAdd(txtMCCode_H, txtMCName_H, "BM0070", new object[] { cboPlantCode_H, "", "" });
            #endregion
        }
        #endregion

        #region [ TOOLBAR AREA ]
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", dtpSDate_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", dtpEDate_H.Value);
                string sOPCode = txtOPCode_H.Text.Trim();
                string sWCCode = txtWCCode_H.Text.Trim();
                string sMCCode = txtMCCode_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_CM0030_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWCCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MCCODE", sMCCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S" && rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                this.ClosePrgFormNew();
            }
        }
        #endregion

        #region [ EVENT AREA ]
        #endregion
    }
}
