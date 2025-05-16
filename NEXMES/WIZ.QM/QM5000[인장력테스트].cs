#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM5000
//   Form Name    : 작업지시 생성 및 확정
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;

using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM5000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public QM5000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM5000_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion


        }

        private void GridInitialize()
        {
            try
            {
                //최대 힘	파단점의 신장율	직경	사용자 지정	탄성계수 El.S	탄성계수 El.F	최대 힘의 응력

                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "FILENAME", "파일이름", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATETIME", "날짜", false, GridColDataType_emu.VarChar, 140, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "SEQ", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "RECDATE", false, GridColDataType_emu.VarChar, 180, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUE1", "최대 힘", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUE2", "파단점의 신장율", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUE3", "직경(Denier)", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUE4", "사용자 지정", false, GridColDataType_emu.VarChar, 150, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUE5", "탄성계수 EI.S", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUE6", "탄성계수 EI.F", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUE7", "최대 힘의 응력", false, GridColDataType_emu.VarChar, 120, true, false);



                _GridUtil.SetColumnTextHAlign(grid1, "RECDATETIME", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "SEQ", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "RECDATE", Infragistics.Win.HAlign.Center);

                _GridUtil.SetColumnTextHAlign(grid1, "VALUE1", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "VALUE2", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "VALUE3", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "VALUE4", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "VALUE5", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "VALUE6", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "VALUE7", Infragistics.Win.HAlign.Right);

                _GridUtil.SetInitUltraGridBind(grid1);


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);


                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sFileName = tbFileName.Text;

                base.DoInquire();

                dtGrid = helper.FillTable("USP_QM5000_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_FILENAME", sFileName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));

                grid1.DataSource = dtGrid;
                grid1.DataBind();


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoNew()
        {
            base.DoNew();


        }

        public override void DoDelete()
        {
            base.DoDelete();


        }

        public override void DoSave()
        {

        }
        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >

        #endregion


    }
}
