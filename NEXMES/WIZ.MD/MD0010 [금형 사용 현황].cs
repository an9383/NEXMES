#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0010
//   Form Name    : 금형 사용 현황
//   Name Space   : WIZ.MD
//   Created Date : 2018.10.24
//   Made By      : JWLEE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
#endregion

namespace WIZ.MD
{
    public partial class MD0010 : WIZ.Forms.BaseMDIChildForm
    {
		#region [ MEMBER AREA ]
		DataTable rtnDtTemp = new DataTable();

		UltraGridUtil _GridUtil = new UltraGridUtil();

		Common _Common = new Common();

		BizTextBoxManager _BtbManager = new BizTextBoxManager();
		#endregion

		#region [ CONSTRUCTOR ]
		public MD0010()
        {
            InitializeComponent();
        }
		#endregion

		#region [ FORM EVENT ]
		private void MD0010_Load(object sender, EventArgs e)
        {
            #region Grid Setting
			_GridUtil.InitializeGrid(grid1, true, false, false, "", false);                
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE",       "금형종류",     false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME",       "금형명",       false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDHSTATUS",    "금형상태",     false, GridColDataType_emu.VarChar, 100, true, false);
			_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "설치작업장",   false, GridColDataType_emu.VarChar, 150, true, false);                
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME",       "설치설비",     false, GridColDataType_emu.VarChar, 150, true, false);			
			_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "생산품목",     false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "생산품명",     false, GridColDataType_emu.VarChar, 220, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSPEC",       "금형규격",     false, GridColDataType_emu.VarChar, 150, true, false);                
            _GridUtil.InitColumnUltraGrid(grid1, "LIMITSHOT",      "한계타수",     false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHECKSHOT",      "점검타수",     false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALSHOT",      "누적타수",     false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USESHOT",        "사용타수",     false, GridColDataType_emu.VarChar, 100, true, false);                
            _GridUtil.InitColumnUltraGrid(grid1, "LASTCHECKDATE",  "최종점검일시", false, GridColDataType_emu.VarChar, 160, true, false);
			_GridUtil.InitColumnUltraGrid(grid1, "LASTUSEDATE",    "최종사용일시", false, GridColDataType_emu.VarChar, 160, true, false);
			_GridUtil.SetInitUltraGridBind(grid1);

			_GridUtil.SetColumnTextHAlign(grid1, "MOLDTYPE",       Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "MOLDNAME",       Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "MACHNAME",       Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME",       Infragistics.Win.HAlign.Left);
			_GridUtil.SetColumnTextHAlign(grid1, "MOLDSPEC",       Infragistics.Win.HAlign.Left);
			_GridUtil.SetColumnTextHAlign(grid1, "LIMITSHOT",      Infragistics.Win.HAlign.Right);
			_GridUtil.SetColumnTextHAlign(grid1, "CHECKSHOT",      Infragistics.Win.HAlign.Right);
			_GridUtil.SetColumnTextHAlign(grid1, "TOTALSHOT",      Infragistics.Win.HAlign.Right);
			_GridUtil.SetColumnTextHAlign(grid1, "USESHOT",        Infragistics.Win.HAlign.Right);     
            #endregion

            #region ComboBox & Popup Setting            
			// ComboBox : 사업장 정보
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
			cboPlantCode_H.Value = LoginInfo.PlantCode;

			// Popup : 작업장 정보
			_BtbManager.PopUpAdd(txtWCCode_H, txtWCName_H, "BM0060", new object[] { cboPlantCode_H, "", "", "" });

			// Popup : 설비 정보
			_BtbManager.PopUpAdd(txtMCCode_H, txtMCName_H, "BM0070", new object[] { cboPlantCode_H, "", "" });

			// Popup : 금형 정보
			_BtbManager.PopUpAdd(txtMDCode_H, txtMDName_H, "BM0680", new object[] { cboPlantCode_H, "" });
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
				string sWCCode    = txtWCCode_H.Text.Trim();
				string sMCCode    = txtMCCode_H.Text.Trim();
				string sMDCode    = txtMDCode_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_MD0010_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE",       sPlantCode, DbType.String, ParameterDirection.Input)
						  , helper.CreateParameter("AS_WORKCENTERCODE",  sWCCode,    DbType.String, ParameterDirection.Input)
						  , helper.CreateParameter("AS_MCCODE",          sMCCode,    DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MDCODE",          sMDCode,    DbType.String, ParameterDirection.Input));

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

		#region [ METHOD AREA ]
		#endregion
	}
}