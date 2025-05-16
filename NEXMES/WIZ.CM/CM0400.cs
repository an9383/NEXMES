#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
#endregion

namespace WIZ.CM
{
    public partial class CM0400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        public Dictionary<string, NumericSeries> SeriesDict;

        #endregion

        #region < CONSTRUCTOR >

        public CM0400()
        {
            InitializeComponent();
        }

        private void CM0400_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            //A.PLANTCODE , C.Value2 AS LASTYEAR,
            //     [01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12] from

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GUBUN", "구분(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GR", "CHK", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "00", "전년도평균", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "01", "1월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "02", "2월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "03", "3월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "04", "4월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "05", "5월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "06", "6월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "07", "7월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "08", "8월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "09", "9월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "10", "10월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "11", "11월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "12", "12월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "AVRS", "평균", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            //그리드 라인 색깔 해제
            //grid1.UseAppStyling = false;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            _GridUtil.SetInitUltraGridBind(grid1);

            // cbotype.SelectedText = "MTTR";  2014.7.14 임영조 맊음

            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE

            #endregion



            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("FAULTANTYPE");     // MTBR,MTTR 구분
            WIZ.Common.FillComboboxMaster(this.cbotype, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");


            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion
        }


        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        /// 
        private ChartLayerAppearance lineLayer = new ChartLayerAppearance();
        public override void DoInquire()
        {
            //DBHelper helper = new DBHelper(false,"Data Source=192.168.100.20;Initial Catalog=MTMES;User ID=sa;Password=qwer1234!~");
            DBHelper helper = new DBHelper(false);
            try
            {
                //DtChange.Clear();

                base.DoInquire();

                string stype = DBHelper.nvlString(cbotype.Value); //Convert.ToString(cbotype.Text);
                string sDtp_date = cbo_date.Value.ToString().Substring(0, 4);

                DataTable rtnDtTemp = helper.FillTable("USP_CM0400_S1", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("etc1", "", DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("etc2", "", DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("etc3", "", DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("Date", sDtp_date, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("type", stype, DbType.String, ParameterDirection.Input));


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();



                if (rtnDtTemp.Rows.Count > 0)
                {
                    Hashtable hash = new Hashtable();

                    foreach (DataRow drRow in rtnDtTemp.Rows)
                    {
                        hash.Add(Convert.ToString(drRow["GUBUN"]) + "|" + Convert.ToString(drRow["GR"]), drRow);
                    }


                    DataTable graphDt = new DataTable();
                    for (int i = 1; i < 13; i++)
                    {
                        graphDt.Columns.Add(i + "월", typeof(double));
                    }

                    if (stype == "MTBF")
                    {
                        graphDt.Rows.Add(new object[] { Convert.ToDouble(grid1.Rows[((DataRow)hash["M/T(MTBF)" + "|" + "QUERY"]).Table.Rows.IndexOf(((DataRow)hash["M/T(MTBF)" + "|" + "QUERY"]))].Cells[4].Value.ToString()) });
                        graphDt.Rows.Add(new object[] { Convert.ToDouble(grid1.Rows[((DataRow)hash["DAC(MTBF)" + "|" + "QUERY"]).Table.Rows.IndexOf(((DataRow)hash["DAC(MTBF)" + "|" + "QUERY"]))].Cells[4].Value.ToString()) });
                    }
                    else
                    {

                        graphDt.Rows.Add(new object[] { Convert.ToDouble(grid1.Rows[((DataRow)hash["M/T(MTTR)" + "|" + "QUERY"]).Table.Rows.IndexOf(((DataRow)hash["M/T(MTTR)" + "|" + "QUERY"]))].Cells[4].Value.ToString()) });
                        graphDt.Rows.Add(new object[] { Convert.ToDouble(grid1.Rows[((DataRow)hash["DAC(MTTR)" + "|" + "QUERY"]).Table.Rows.IndexOf(((DataRow)hash["DAC(MTTR)" + "|" + "QUERY"]))].Cells[4].Value.ToString()) });
                    }

                    for (int i = 1; i < 12; i++)
                    {
                        graphDt.Rows[0][i] = DBHelper.nvlDouble(grid1.Rows[1].Cells[i + 4].Value.ToString());
                        graphDt.Rows[1][i] = DBHelper.nvlDouble(grid1.Rows[3].Cells[i + 4].Value.ToString());
                    }





                    chart.DataSource = graphDt;
                    chart.Data.DataBind();
                    chart.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                    chart.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;

                    grid1.Rows[1].Activation = Activation.NoEdit;
                    grid1.Rows[3].Activation = Activation.NoEdit;
                    chart.TitleTop.Text = sDtp_date + "년도" + "-" + cbotype.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {
                //this.ShowDialog(""+e, Windows.Forms.DialogForm.DialogType.OK);
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {


        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            //DBHelper helper = new DBHelper(false,"Data Source=192.168.100.20;Initial Catalog=MTMES;User ID=sa;Password=qwer1234!~");
            DBHelper helper = new DBHelper(false);
            //System.Data.Common.DbParameter[] param = null;

            string[] sArr = chart.TitleTop.Text.Split('-');

            string sYear = null;
            string stype = null;

            if (sArr.Length == 2)
            {
                sYear = sArr[0].Substring(0, 4);
                stype = sArr[1];
            }

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();

                //UltraGridUtil.DataRowDelete(this.grid1);
                //this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:

                            string svalue = string.Empty;
                            string smonth = string.Empty;
                            #region 수정

                            //param = new System.Data.Common.DbParameter[8];

                            for (int i = 0; i < grid1.Columns.Count; i++)
                            {

                                if (grid1.Columns[i].Header.Caption.IndexOf("월") >= 0)
                                {
                                    if (Convert.ToString(drRow[grid1.Columns[i].Key]) != "")
                                    {
                                        helper.ExecuteNoneQuery("USP_CM0400_I1", CommandType.StoredProcedure
                                                                               , helper.CreateParameter("value", Convert.ToString(drRow[grid1.Columns[i].Key]), DbType.String, ParameterDirection.Input)
                                                                               , helper.CreateParameter("month", grid1.Columns[i].Key, DbType.String, ParameterDirection.Input)
                                                                               , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)    // 등록자\
                                                                               , helper.CreateParameter("Year", sYear, DbType.String, ParameterDirection.Input)
                                                                               , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                                               , helper.CreateParameter("type", stype, DbType.String, ParameterDirection.Input));

                                    }
                                }
                            }

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE");
                helper.Commit();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                //if (param != null) { param = null; }
            }
        }

        private void DoGraph()
        {
            try
            {
                string sPlcCode;
                chart.Series.Clear();
                //chart.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;

                int idx = 0;
                chart.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL:HH:mm:ss>";

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sPlcCode = DBHelper.nvlString(grid1.Rows[i].Cells["PLANTCODE"].Value);

                    idx = GetSeriesIndex(sPlcCode);

                    NumericTimeSeries n = (NumericTimeSeries)chart.Series[idx];
                    n.Points.Add(new NumericTimeDataPoint(DBHelper.nvlDateTime(grid1.Rows[i].Cells["01"].Value)
                                , DBHelper.nvlDouble(grid1.Rows[i].Cells["PLANTCODE"].Value), "", true));

                }
                chart.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                chart.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message);
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
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }
        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "설비코드가 있습니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion
    }
}
