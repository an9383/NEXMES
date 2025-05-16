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

#region < USING AREA >
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
#endregion

namespace WIZ.CM
{
    public partial class CM1000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region < CONSTRUCTOR >

        public CM1000()
        {
            InitializeComponent();
        }

        private void CM1000_Load(object sender, EventArgs e)
        {
            DoChart();

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

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "팀구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
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

            //그리드 라인 색깔 해제
            //grid1.UseAppStyling = false;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            _GridUtil.SetInitUltraGridBind(grid1);

            #region Grid MERGE
            grid1.Columns["PLANTCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PLANTCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantcode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            //DBHelper helper = new DBHelper(false,"Data Source=192.168.100.20;Initial Catalog=MTMES;User ID=sa;Password=qwer1234!~");
            DBHelper helper = new DBHelper(false);

            string splantcode = Convert.ToString(cboPlantcode.Value);
            string sDtp_date = cbo_date.Value.ToString().Substring(0, 4);

            try
            {
                base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_CM1000_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("@PlantCode", splantcode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@YEAR", sDtp_date, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@Param1", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@Param2", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@Param3", "", DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                DoChart();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
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
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }
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

        #region <METHOD AREA>
        private void DoChart()
        {
            if (rtnDtTemp.Rows.Count > 0)
            {
                NumericSeries series = new NumericSeries();
                DataTable table = new DataTable();

                //table.Columns.Add("사업장", typeof(string));
                //table.Columns.Add("계획량", typeof(double));
                //table.Columns.Add("생산량", typeof(double));
                if (grid1.Rows.Count != 0)
                {
                    table.Columns.Add("월", typeof(string));
                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        table.Columns.Add(rtnDtTemp.Rows[i]["DEPTCODE"].ToString().Replace(DBHelper.gGetName(grid1.Rows[i].Cells["PLANTCODE"].Text.ToString()), "").Trim(), typeof(double));
                    }
                    for (int j = 2; j < rtnDtTemp.Columns.Count; j++)
                    {
                        DataRow tdr = table.NewRow();
                        tdr[0] = grid1.Columns[j].Header.Caption;
                        for (int i = 0; i < this.rtnDtTemp.Rows.Count; i++)
                        {
                            if (rtnDtTemp.Rows[i][j] == null || rtnDtTemp.Rows[i][j].ToString() == "")
                                tdr[i + 1] = DBNull.Value;
                            else tdr[i + 1] = rtnDtTemp.Rows[i][j];

                        }
                        table.Rows.Add(tdr);
                    }

                }

                ultraChart1.Visible = true;

                ultraChart1.Data.DataSource = table;
                ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                series.DataBind();

                ultraChart1.Data.DataBind();

                ////************************   컬럼 차트 데이터 값 표시 *********************************

                //for (int k = 0; k < table.Rows.Count; k++)
                //{
                //    ChartTextAppearance PlantValue = new ChartTextAppearance();
                //    ChartTextAppearance ResultValue = new ChartTextAppearance();

                //    PlantValue.Row = k;
                //    PlantValue.Column = k;
                //    ResultValue.Row = k;
                //    ResultValue.Column = k;


                //    PlantValue.ItemFormatString = table.Rows[k]["계획량"].ToString();
                //    PlantValue.ItemFormatString = "<DATA_VALUE:0.#>";
                //    PlantValue.VerticalAlign = StringAlignment.Far;
                //    PlantValue.Visible = true;

                //    ResultValue.ItemFormatString = table.Rows[k]["생산량"].ToString();
                //    ResultValue.ItemFormatString = "<DATA_VALUE:0.#>";
                //    ResultValue.VerticalAlign = StringAlignment.Far;
                //    ResultValue.Visible = true;


                //    this.ultraChart1.ColumnChart.ChartText.Add(PlantValue);
                //    this.ultraChart1.ColumnChart.ChartText.Add(ResultValue);

                //    PlantValue.ChartTextFont = new Font("맑은고딕", 10f);
                //    PlantValue.FontColor = Color.Black;
                //    ResultValue.ChartTextFont = new Font("맑은고딕", 10f);
                //    ResultValue.FontColor = Color.Black;
                //}
            }
            else
            {
                ultraChart1.Series.Clear();
                //ultraChart1.Visible = false;
            }
        }
        #endregion
    }
}
