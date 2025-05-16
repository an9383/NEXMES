#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TT1061
//   Form Name    : 브레이징로 온도 데이터 조회
//   Name Space   : WIZ.PP
//   Created Date : 2012-03-19
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.PP
{
    public partial class TT1061 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DBHelper helper = new DBHelper(false);
        private bool bCheck = false;
        private bool bCheck2 = false;
        private bool ball = false;
        #endregion

        #region < CONSTRUCTOR >
        public TT1061()
        {
            InitializeComponent();
        }
        #endregion

        #region < TT1061_Load >
        private void TT1061_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                this.cboMst.Items.Add(i);
                this.cboMen.Items.Add(i);
            }

            #region --- Grid 셋팅 ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "inspdate", "측정일", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "plccode", "항목", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "plcaddr", "PLC주소", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USL", "상한값", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LSL", "하한값", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "plcvalue", "온도", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            grid1.Columns["inspdate"].Format = "yyyy-MM-dd HH:mm:ss";

            #region --- 콤보박스 셋팅 ---
            Common _Common = new Common();

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = helper.FillTable("USP_TT1061_COMBO"
                                         , CommandType.StoredProcedure
                                         , helper.CreateParameter("PLCCODE", "PLC2", DbType.String, ParameterDirection.Input));
            WIZ.Common.FillUltraComboboxMaster(this.cbo_plcAD, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCResult");
            WIZ.Common.FillComboboxMaster(this.cbo_result, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLCResult", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            this.chart.EmptyChartText = string.Empty;
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            if (this.cboHen.Text.ToString() == "")
            {
                this.cboHen.Text = "00";
            }
            if (this.cboMen.Text.ToString() == "")
            {
                this.cboMen.Text = "00";
            }
            if (this.cboHst.Text.ToString() == "")
            {
                this.cboHst.Text = "00";
            }
            if (this.cboMst.Text.ToString() == "")
            {
                this.cboMst.Text = "00";
            }

            string a = DBHelper.nvlString(this.cboHen.Text.Trim());

            DateTime dtStart = DBHelper.nvlDateTime(CboStartdate_H.Value);
            DateTime dtEnd = DBHelper.nvlDateTime(CboEnddate_H.Value);
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.SelectedValue);
            string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value) + " " + DBHelper.nvlString(this.cboHst.Text.ToString()) + ":" + DBHelper.nvlString(this.cboMst.Text.ToString()) + ":00"; ;
            string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value) + " " + DBHelper.nvlString(this.cboHen.Text.ToString()) + ":" + DBHelper.nvlString(this.cboMen.Text.ToString()) + ":00";
            string sPlccode = "PLC2";
            //string sPlcad = DBHelper.nvlString(cbo_plcAD.Text.Trim().Replace(", ","|"));
            string sPlcad2 = string.Empty;
            string sResult = DBHelper.nvlString(cbo_result.SelectedValue);
            string etc1 = "";
            string etc2 = "";
            string etc3 = "";

            for (int i = 0; i < cbo_plcAD.CheckedItems.Count; i++)
            {
                sPlcad2 += ((Infragistics.Win.ValueListItem)(cbo_plcAD.CheckedItems.All[i])).DataValue.ToString() + "|";
            }

            if ((dtStart - dtEnd).TotalDays <= -2.0)
            {
                DialogForm dialogform;

                dialogform = new DialogForm(Common.getLangText("이틀 이하로 검색하여 주십시오", "MSG"), DialogForm.DialogType.OK);

                dialogform.ShowDialog();

                return;
            }

            if (sStartDate.Substring(0, 16) == sEndDate.Substring(0, 16))
            {
                cboHen.Text = "23";
                cboMen.Text = "59";
                sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value) + " " + DBHelper.nvlString(this.cboHen.Text.ToString()) + ":" + DBHelper.nvlString(this.cboMen.Text.ToString()) + ":59.999";
            }

            try
            {
                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_TT1061_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PPLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PSTARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PPLCCODE", sPlccode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PPLCAD", sPlcad2, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SRESULT", sResult, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ETC1", etc1, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ETC2", etc2, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ETC3", etc3, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

                DoGraph();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < METHOD AREA >
        private void DoGraph()
        {
            try
            {
                string sPlcCode;
                chart.Series.Clear();

                int idx = 0;
                chart.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL:HH:mm:ss>";

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlcCode = DBHelper.nvlString(grid1.Rows[i].Cells["plcaddr"].Value);

                    idx = GetSeriesIndex(sPlcCode);

                    NumericTimeSeries n = (NumericTimeSeries)chart.Series[idx];
                    n.Points.Add(new NumericTimeDataPoint(DBHelper.nvlDateTime(grid1.Rows[i].Cells["inspdate"].Value)
                                , DBHelper.nvlDouble(grid1.Rows[i].Cells["plcvalue"].Value), "", true));

                }

                chart.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                chart.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
        }

        private int GetSeriesIndex(string sKey)
        {
            for (int i = 0; i < chart.Series.Count; i++)
            {
                if (chart.Series[i].Key == sKey)
                {
                    return i;
                }
            }

            NumericTimeSeries s = new NumericTimeSeries();
            s.Key = sKey;
            s.Label = sKey;
            chart.Series.Add(s);

            return chart.Series.Count - 1;
        }

        private void CboStartdate_H_ValueChanged(object sender, EventArgs e)
        {
            cboHst.Text = "00";
            cboMst.Text = "00";
        }

        private void cboHst_TextChanged(object sender, EventArgs e)
        {
            cboMst.Text = "00";
        }

        private void CboEnddate_H_ValueChanged(object sender, EventArgs e)
        {
            cboHen.Text = "00";
            cboMen.Text = "00";
        }

        private void cboHen_TextChanged(object sender, EventArgs e)
        {
            cboMen.Text = "00";
        }

        private void chkZone_CheckedChanged(object sender, EventArgs e)
        {
            if (!bCheck && !bCheck2)
            {
                ball = true;
                chkZone1.CheckState = CheckState.Unchecked;
                chkZone2.CheckState = CheckState.Unchecked;

                DoCheckZone();
                ball = false;
            }
        }

        private void DoCheckZone()
        {
            bool bZon1 = false;
            if (chkZone.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < cbo_plcAD.Items.Count; i++)
                {
                    cbo_plcAD.Items[i].CheckState = CheckState.Checked;
                }
                return;
            }
            else
            {
                if (chkZone1.CheckState == CheckState.Unchecked && chkZone2.CheckState == CheckState.Unchecked)
                {
                    for (int i = 0; i < cbo_plcAD.Items.Count; i++)
                    {
                        cbo_plcAD.Items[i].CheckState = CheckState.Unchecked;
                    }
                    return;
                }
            }

            if (chkZone1.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < cbo_plcAD.Items.Count; i++)
                {
                    if (cbo_plcAD.Items[i].DataValue.ToString().IndexOf("Tag1") > 0)
                        cbo_plcAD.Items[i].CheckState = CheckState.Checked;
                    else
                        cbo_plcAD.Items[i].CheckState = CheckState.Unchecked;
                }
                bZon1 = true;
            }

            if (chkZone2.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < cbo_plcAD.Items.Count; i++)
                {
                    if (cbo_plcAD.Items[i].DataValue.ToString().IndexOf("Tag2") > 0)
                        cbo_plcAD.Items[i].CheckState = CheckState.Checked;
                    else
                    {
                        if (!bZon1)
                            cbo_plcAD.Items[i].CheckState = CheckState.Unchecked;
                    }
                }
            }
        }

        private void chkZone1_CheckedChanged(object sender, EventArgs e)
        {
            if (ball) return;
            bCheck = true;
            chkZone.CheckState = CheckState.Unchecked;
            if (!bCheck2)
            {
                chkZone2.CheckState = CheckState.Unchecked;

                DoCheckZone();
            }
            bCheck = false;
        }

        private void chkZone2_CheckedChanged(object sender, EventArgs e)
        {
            if (ball) return;
            bCheck2 = true;
            chkZone.CheckState = CheckState.Unchecked;
            if (!bCheck)
            {
                chkZone1.CheckState = CheckState.Unchecked;

                DoCheckZone();
            }
            bCheck2 = false;
        }
        #endregion
    }
}

