#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : CM0010
//   Form Name    : 설비 사용 현황
//   Name Space   : WIZ.CM
//   Created Date : 2018.10.24
//   Made By      : JWLEE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;

using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class CM0010 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ MEMBER AREA ]
        DataTable rtnDtTemp = new DataTable();

        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();

        BizTextBoxManager _BtbManager = new BizTextBoxManager();
        #endregion

        #region [ CONSTRUCTOR ]
        public CM0010()
        {
            InitializeComponent();
        }
        #endregion

        #region [ FORM EVENT ]
        private void CM0010_Load(object sender, EventArgs e)
        {
            #region Grid Setting
            _GridUtil.InitializeGrid(grid1, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPE", "설비종류", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHSTATUS", "설비상태", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "생산품명", false, GridColDataType_emu.VarChar, 220, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITNAME", "단위", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.SetColumnTextHAlign(grid1, "MACHTYPE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "MACHNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "PRODQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "OPNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);

            grid1.Columns["PRODQTY"].Format = "#,##0";
            grid1.Columns["ORDERQTY"].Format = "#,##0";
            #endregion

            #region ComboBox & Popup Setting            
            // ComboBox : 사업장 정보
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboPlantCode_H.Value = LoginInfo.PlantCode;

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
                string sOPCode = txtOPCode_H.Text.Trim();
                string sWCCode = txtWCCode_H.Text.Trim();
                string sMCCode = txtMCCode_H.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_CM0010_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
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

        #region [ METHOD AREA ]
        #endregion
    }
}