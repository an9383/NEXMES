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
using System.Windows.Forms;
#endregion

namespace WIZ.ETC
{
    public partial class ET0130_POP : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        DataTable rtnDtTemp = new DataTable();
        DataSet DSGrid1 = new DataSet();

        public Control.Grid trGrid;
        DateTime dtFirstDay;
        DateTime dtSecondDay;

        #endregion

        #region < CONSTRUCTOR >
        public ET0130_POP()
        {
            InitializeComponent();


        }
        #endregion

        #region < FORM LOAD >
        private void ET0130_POP_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "ET14_Gubun1", "수리", true, GridColDataType_emu.CheckBox, 80, 100, Infragistics.Win.HAlign.Center, true, false); // 고객사       
            _GridUtil.InitColumnUltraGrid(grid1, "ET14_Gubun2", "교체", true, GridColDataType_emu.CheckBox, 80, 100, Infragistics.Win.HAlign.Center, true, false); // 등록일자 
            _GridUtil.InitColumnUltraGrid(grid1, "ET14_Gubun3", "세척", true, GridColDataType_emu.CheckBox, 80, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "ET14_article", "점검항목정보", true, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "ET14_Recode", "점검내용", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < GRID LOAD >

            DBHelper helper = new DBHelper(false);
            // GRID3
            try
            {
                rtnDtTemp = helper.FillTable("USP_ET0130", CommandType.StoredProcedure);

                if (rtnDtTemp.Rows.Count > 0)
                {

                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid1);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }

            // GRID4
            try
            {
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
            #endregion
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >



        #endregion

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {

            DBHelper helper = new DBHelper(false);

            try
            {
                DSGrid1 = helper.FillDataSet("USP_PL0100_MD_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", grid1.ActiveRow.Cells["MOLDCODE"].Value, DbType.String, ParameterDirection.Input));

                if (DSGrid1.Tables[0].Rows.Count > 0)
                {

                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0000_S6", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_SEARCHDATE", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));

                string cnt = Convert.ToString(rtnDtTemp.Rows[0]["cnt"]);
                int PLUS = 0;


                this.ShowDialog("계획등록이 완료되었습니다.", Forms.DialogForm.DialogType.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }

        private void grid4_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

        }

        private void dtp_STARTDATE_ValueChanged(object sender, EventArgs e)
        {
            string chk = "A";
            DBHelper helper = new DBHelper(false);
            try
            {

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                }
                else
                {

                }
            }
            catch
            {

            }
        }

        /*private void CALDAYWEEK() // 주간 나누는공식
        {
            DateTime dtDay = dtp_STARTDATE.Value;
            System.Globalization.CultureInfo ciCurrent = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dwFirst = ciCurrent.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek dwCal   = ciCurrent.Calendar.GetDayOfWeek(dtDay);

            int iDiff = dwCal - dwFirst;
            dtFirstDay  = dtDay.AddDays(-iDiff + 1);
            dtSecondDay = dtFirstDay.AddDays(6);
        }*/

        private void grid5_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void btn_INSERTROW_Click(object sender, EventArgs e)
        {

        }

        private void chk_DAY_CheckedChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                ET0130_POP mbp = new ET0130_POP();
                mbp.trGrid = grid1;
                if (DialogResult.OK == mbp.ShowDialog())
                {
                    DSGrid1 = helper.FillDataSet("USP_PL0100_S1", CommandType.StoredProcedure);

                    if (DSGrid1.Tables[0].Rows.Count > 0)
                    {
                        grid1.DataSource = DSGrid1.Tables[0];
                        grid1.DataBind();
                    }
                    else
                    {
                        ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }
            catch
            {

            }
        }
    }
}