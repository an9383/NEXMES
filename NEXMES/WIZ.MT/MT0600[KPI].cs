#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0600
//   Form Name    : KPI 현황
//   Name Space   : WIZ.MT
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0600 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ MEMBER AREA ]
        private string sSDate = string.Empty;

        private int iInterval = 10;

        DataTable rtnDtTemp = new DataTable();
        DataTable dtTemp = new DataTable();

        Timer _Timer = new Timer();

        Common _Common = new Common();
        #endregion

        #region [ CONSTRUCTOR ]
        public MT0600()
        {
            InitializeComponent();

            dtpSDate_H.Value = DateTime.Now;

            if (_IsNumber(txtInterval.Text.Trim()))
            {
                iInterval = Convert.ToInt16(txtInterval.Text.Trim());
            }

            _Timer.Tick += new EventHandler(_Timer_Tick);
            _Timer.Interval = iInterval * 1000;
        }
        #endregion

        #region [ FORM LOAD ]
        private void MT0600_Load(object sender, EventArgs e)
        {
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboPlantCode_H.Value = LoginInfo.PlantCode;

            _Timer.Start();
        }
        #endregion

        #region [ TOOL BAR AREA ]
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", dtpSDate_H.Value);

                dtTemp = helper.FillTable("USP_MT0600_MT", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input));

                if (dtTemp.Rows.Count > 0)
                {
                    lblKPI01.Text = string.Format("{0:0}", dtTemp.Rows[0]["PRODQTY"]);
                    lblKPI02.Text = string.Format("{0:0}", dtTemp.Rows[0]["ERRORQTY"]);
                    lblKPI03.Text = string.Format("{0:0}", dtTemp.Rows[0]["MATQTY_TARGET"]);
                    lblKPI04.Text = string.Format("{0:0.0}", dtTemp.Rows[0]["PACKQTY_TARGET"]);
                    lblKPI05.Text = string.Format("{0:0.0}", dtTemp.Rows[0]["PRODQTY_HOUR"]);
                    lblKPI06.Text = string.Format("{0:0.0}", dtTemp.Rows[0]["ERRORQTY_RATE"]);
                    lblKPI07.Text = string.Format("{0:0}", dtTemp.Rows[0]["MATQTY"]);
                    lblKPI08.Text = string.Format("{0:0.0}", dtTemp.Rows[0]["PACKQTY"]);
                }

                sSDate = string.Format("{0:yyyy-MM-dd}", dtpSDate_H.Value);


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ EVENT AREA ]
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            _Timer.Stop();
            _Timer.Dispose();
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                _Timer.Stop();

                DoInquire();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message);
            }
            finally
            {
                _Timer.Start();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_IsNumber(txtInterval.Text.Trim()))
            {
                iInterval = Convert.ToInt16(txtInterval.Text.Trim());

                _Timer.Interval = iInterval * 1000;
            }
        }
        #endregion

        #region [ METHOD AREA ]
        private static bool _IsNumber(string _RecVal)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d.]+");

            if (!regex.IsMatch(_RecVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
