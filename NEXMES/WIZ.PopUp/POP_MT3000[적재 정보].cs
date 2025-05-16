#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : POP_MT3000
//   Form Name    : 적재 정보
//   Name Space   : WIZ
//   Created Date : 
//   Made By      :
//   Description  : 창고 모니터링(MT3000)에서 USER CONTROL 더블클릭 시 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.PopUp
{
    public partial class POP_MT3000 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        UserControl _ctrl = new UserControl();

        string _sLocCode = string.Empty;
        int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

        #endregion

        #region < CONTRUCTOR >
        public POP_MT3000(string sLocCode, UserControl ctrl)
        {
            InitializeComponent();

            _sLocCode = sLocCode;
            _ctrl = ctrl;


            this.Size = new Size(700, screenHeight / 2);
            this.Location = new Point(screenWidth - this.Width, screenHeight / 2);
        }
        #endregion

        #region < FORM LOAD >
        private void POP_MT3000_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PALLETNO", "파렛트 번호", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT No.", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품번", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량", false, GridColDataType_emu.VarChar, 80, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "STOCKQTY", Infragistics.Win.HAlign.Right);

            grid1.Columns["STOCKQTY"].Format = "#,##0";

            SettingData();
        }
        #endregion

        #region < METHOD AREA >

        private void SettingData()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = LoginInfo.PlantCode;

                rtnDtTemp = helper.FillTable("USP_POP_MT3000_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_LOCCODE", _sLocCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }

        #endregion

        #region < EVENT AREA >
        private void POP_MT3000_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ctrl.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion


    }
}
