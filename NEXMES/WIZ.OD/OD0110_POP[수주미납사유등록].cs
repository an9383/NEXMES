#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : ���� ��Ȳ
//   Name Space   : WIZ.BM
//   Created Date : 2019-11-11
//   Made By      : ��������� �ֹ���
//   Description  : ���� ��Ȳ ������ ����
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.OD
{
    public partial class OD0110_POP : WIZ.Forms.BaseMDIChildForm
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
        public OD0110_POP()
        {
            InitializeComponent();


        }
        #endregion

        #region < FORM LOAD >
        private void OD0110_POP_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >


            dtp_STARTDATE.Value = DateTime.Today;
            dtp_STARTDATE.Value.ToString("yyyy-MM-dd");

            #endregion

            #region < GRID LOAD >

            DBHelper helper = new DBHelper(false);
            // GRID3
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
                DSGrid1 = helper.FillDataSet("USP_PL0100_MD_S1", CommandType.StoredProcedure);

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


                this.ShowDialog("��ȹ����� �Ϸ�Ǿ����ϴ�.", Forms.DialogForm.DialogType.OK);
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

        /*private void CALDAYWEEK() // �ְ� �����°���
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
            }
            catch
            {

            }
        }
    }
}