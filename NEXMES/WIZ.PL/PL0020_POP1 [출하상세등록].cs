#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : 수주 현황
//   Name Space   : WIZ.BM
//   Created Date : 2019-11-11
//   Made By      : 기술연구소 최문준
//   Description  : 수주 현황 정보를 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PL
{
    public partial class PL0020_POP1 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;

        string sITEMCODE = "";
        string sITEMNAME = "";

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet DSGrid1 = new DataSet();
        DataTable dtBARCORE = new DataTable();

        /// <summary>
        /// 타 Form 접근용
        /// </summary>

        #endregion

        #region < CONSTRUCTOR >
        public PL0020_POP1(string ITEMCODE, string ITEMNAME)
        {
            InitializeComponent();
            sITEMCODE = ITEMCODE;
            sITEMNAME = ITEMNAME;
        }
        #endregion

        #region < FORM LOAD >
        private void PL0020_POP1_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_STATUS", "상태", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_ITEMNAME", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_CHK", "초과수량", true, GridColDataType_emu.CheckBox, 80, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_OUTDATE", "출하예정일", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PL_OUTCNT", "출하예정수량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            DTP1.Value = DateTime.Today.AddDays(-30);
            DTP2.Value = DateTime.Today;
        }
        #endregion

        #region < TOOL BAR AREA >

        private void INQUIRE()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0020_POP1_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_STARTDATE", DTP1.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ENDDATE", DTP2.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToString(grid1.Rows[i].Cells["PL_STATUS"].Value) == "조회")
                {
                    grid1.Rows[i].Cells["PL_OUTDATE"].Activation = Activation.NoEdit;
                }
            }

        }

        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >
        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(grid1.Rows[i].Cells["PL_OUTCNT"].Value) != 0)
                    {
                        helper.ExecuteNoneQuery("USP_PL0020_POP1_I", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                            , helper.CreateParameter("AS_PL_ITEMCODE", Convert.ToString(grid1.Rows[i].Cells["PL_ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PL_OUTDATE", Convert.ToDateTime(grid1.Rows[i].Cells["PL_OUTDATE"].Value).ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PL_OUTCNT", Convert.ToInt32(grid1.Rows[i].Cells["PL_OUTCNT"].Value), DbType.Int32, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PL_CHK", Convert.ToString(grid1.Rows[i].Cells["PL_CHK"].Value), DbType.String, ParameterDirection.Input)

                            , helper.CreateParameter("AS_TYPE", Convert.ToString(grid1.Rows[i].Cells["PL_STATUS"].Value), DbType.String, ParameterDirection.Input));
                    }
                }

                helper.Commit();
                this.ShowDialog("출하계획이 저장되었습니다.", Forms.DialogForm.DialogType.OK);
                INQUIRE();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {

            }
        }

        private void btn_DELETE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (Convert.ToInt32(grid1.ActiveRow.Cells["PL_OUTCNT"].Value) != 0)
                {
                    helper.ExecuteNoneQuery("USP_PL0020_POP1_I", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_PL_ITEMCODE", Convert.ToString(grid1.ActiveRow.Cells["PL_ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PL_OUTDATE", Convert.ToString(grid1.ActiveRow.Cells["PL_OUTDATE"].Value), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PL_OUTCNT", Convert.ToInt32(grid1.ActiveRow.Cells["PL_OUTCNT"].Value), DbType.Int32, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PL_CHK", Convert.ToString(grid1.ActiveRow.Cells["PL_CHK"].Value), DbType.String, ParameterDirection.Input)

                        , helper.CreateParameter("AS_TYPE", "삭제", DbType.String, ParameterDirection.Input));
                }

                helper.Commit();
                this.ShowDialog("출하계획이 삭제되었습니다.", Forms.DialogForm.DialogType.OK);

                grid1.ActiveRow.Delete(false);
                INQUIRE();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {

            }
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                int iROW = grid1.InsertRow();

                grid1.Rows[iROW].Cells["PL_STATUS"].Value = "신규";
                grid1.Rows[iROW].Cells["PLANTCODE"].Value = 10;
                grid1.Rows[iROW].Cells["PL_ITEMCODE"].Value = sITEMCODE;
                grid1.Rows[iROW].Cells["PL_ITEMNAME"].Value = sITEMNAME;
                grid1.Rows[iROW].Cells["PL_OUTDATE"].Value = DateTime.Today.ToString("yyyy-MM-dd");
                grid1.Rows[iROW].Cells["PL_CHK"].Value = false;
            }
            catch
            {

            }
        }

        private void btn_INQ_Click(object sender, EventArgs e)
        {
            INQUIRE();
        }

        #endregion
    }
}
