using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP5400 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMEBER AREA >
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp = new DataTable();  // return DataTable 공통

        DataTable rtnClonTemp = new DataTable();
        DataTable rtnClonTemp2 = new DataTable();

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        DBHelper helper = new DBHelper(false);

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();

        //변수 선언
        BizTextBoxManager btbManager;

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        int fstart = 0;
        #endregion

        #region < CONSTRUCTOR >
        public PP5400()
        {

            InitializeComponent();
            btbManager = new BizTextBoxManager();
            this.plantCode = CModule.GetAppSetting("Site", "10");

            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "BM0060", new object[] { cboPlantCode_H, "", "", "" });
        }
        #endregion

        #region < PP5400_Load >
        private void PP5400_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT", "구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT01", "1월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT02", "2월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT03", "3월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT04", "4월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT05", "5월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT06", "6월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT07", "7월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT08", "8월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT09", "9월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT10", "10월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT11", "11월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MT12", "12월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "AVGTOT", "누계평균", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "SEQ", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, "###,##0.##", null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MT", "구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //  _GridUtil.InitColumnUltraGrid(grid2, string.Format("{0:MMdd}", System.DateTime.Today), string.Format("{0:MM/dd}", System.DateTime.Today), false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region --- ComboBox Setting ---
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //   this.cboPlantCode_H.Value = Common.sPlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("FAILURESTATUS"); // 진행 상태
            WIZ.Common.FillComboboxMaster(this.cboFailUreStatus, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");


            #endregion

            Chart3.EmptyChartText = string.Empty;
            Chart4.EmptyChartText = string.Empty;

            cboPlantCode_H.Value = plantCode;
            this.CboStartDate_H.Value = System.DateTime.Today.AddDays(-30);
            this.CboEndDate_H.Value = System.DateTime.Today;
            this.txtWorkCenterCode_H.Value = "WC0006";
            this.txtWorkCenterName_H.Value = "노광작업장";
            this.CboStartDate_H.Visible = false;
            this.CboEndDate_H.Visible = false;
            this.sLabel2.Visible = false;
            this.cboSM_H.Visible = true;
            fstart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", this.CboStartDate_H.Value));
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            if (this.TabControl1.SelectedTab.Index == 0)
            {
                DoFind();
            }
            else
            {
                DoFind1();
            }
        }


        #endregion

        #region < METHOD >


        #endregion

        #region < 조회 기능 >
        private void KeyPress_Event(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DoFind();
                e.Handled = true;
            }
        }

        private void DoFind(bool check = true, int RowIndex = -1)
        {
            try
            {
                //  this.ShowProgressForm("C00005");
                if (this.txtWorkCenterCode_H.Text == "")
                {
                    this.ShowDialog(Common.getLangText("작업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK); //작업장을 확인하세요.
                    return;
                }

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sWorkcenterCode = this.txtWorkCenterCode_H.Text.ToString();
                string sMonthDt = string.Format("{0:yyyy}", cboSM_H.Value);

                rtnDtTemp = helper.FillTable("USP_PP5400_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("YYYYDATE", sMonthDt, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                this.grid1.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);

                if (rtnDtTemp.Rows.Count > 0)
                {
                    this.grid1.Rows[0].Appearance.BackColor = Color.LightSkyBlue;
                    this.grid1.Rows[1].Appearance.BackColor = Color.LightSeaGreen;
                    this.grid1.Rows[2].Appearance.BackColor = Color.White;
                    this.grid1.Rows[3].Appearance.BackColor = Color.White;
                    this.grid1.Rows[4].Appearance.BackColor = Color.White;

                    // MTTR 조회
                    /*    rtnClonTemp = helper.FillTable("USP_PP5400_S3"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("STARTDATE", sMonthDt, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ENDDATE", "", DbType.String, ParameterDirection.Input)
                                                   );

                        //MTTP 조회
                        rtnClonTemp2 = helper.FillTable("USP_PP5400_S4"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("STARTDATE", sMonthDt, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ENDDATE", "", DbType.String, ParameterDirection.Input)
                                                   );
                        */

                    rtnClonTemp = rtnDtTemp.Clone();
                    rtnClonTemp2 = rtnDtTemp.Clone();
                    DataRow drRow = null;// rtnDtTemp.Select("ROW = '1'");
                    DataRow drRow1 = null;
                    //mttr
                    drRow = rtnDtTemp.Rows[0];
                    rtnClonTemp.Rows.Add(drRow.ItemArray);
                    //mtbf
                    drRow1 = rtnDtTemp.Rows[1];
                    rtnClonTemp2.Rows.Add(drRow1.ItemArray);

                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    Chart3.Series.Clear();
                    Chart4.Series.Clear();
                    Chart3.Data.DataSource = null;
                    Chart4.Data.DataSource = null;
                    //Chart3.Visible = false;
                    //Chart4.Visible = false;
                    if (check)
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    return;
                }
                grid1.Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                grid1.Columns["WORKCENTERNAME"].CellAppearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void DoFind1(bool check = true, int RowIndex = -1)
        {
            try
            {
                if (!(CheckData(fstart)))
                {
                    return;
                }

                if (this.txtWorkCenterCode_H.Text == "")
                {
                    this.ShowDialog(Common.getLangText("작업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }


                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sWorkcenterCode = this.txtWorkCenterCode_H.Text.ToString();
                string sSTARTDATE = string.Format("{0:yyyy-MM-dd}", this.CboStartDate_H.Value);
                string sENDDATE = string.Format("{0:yyyy-MM-dd}", this.CboEndDate_H.Value);

                grid2.DataBindings.Clear();
                rtnDtTemp = helper.FillTable("USP_PP5400_S2", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("STARTDATE", sSTARTDATE, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("ENDDATE", sENDDATE, DbType.String, ParameterDirection.Input));

                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds();

                cell_format();


                this.grid2.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);

                if (rtnDtTemp.Rows.Count > 0)
                {
                    this.grid2.Rows[0].Appearance.BackColor = Color.LightSkyBlue;
                    this.grid2.Rows[1].Appearance.BackColor = Color.LightSeaGreen;
                    this.grid2.Rows[2].Appearance.BackColor = Color.White;
                    this.grid2.Rows[3].Appearance.BackColor = Color.White;
                    this.grid2.Rows[4].Appearance.BackColor = Color.White;

                    rtnClonTemp = rtnDtTemp.Clone();
                    rtnClonTemp2 = rtnDtTemp.Clone();
                    DataRow drRow = null;// rtnDtTemp.Select("ROW = '1'");
                    DataRow drRow1 = null;
                    //mttr
                    drRow = rtnDtTemp.Rows[0];
                    rtnClonTemp.Rows.Add(drRow.ItemArray);
                    //mtbf
                    drRow1 = rtnDtTemp.Rows[1];
                    rtnClonTemp2.Rows.Add(drRow1.ItemArray);

                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                    Chart3.Series.Clear();
                    Chart4.Series.Clear();
                    Chart3.Data.DataSource = null;
                    Chart4.Data.DataSource = null;
                    if (check)
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); // 조회할 데이터가 없습니다.
                    return;
                }
                grid1.Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                grid1.Columns["WORKCENTERNAME"].CellAppearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion

        public void cell_format()
        {
            int columncnt = this.grid2.Columns.Count;

            for (int i = 0; i < columncnt; i++)
            {
                if (this.grid2.Columns[i].Index == 3)
                {
                    this.grid2.Columns[i].Hidden = true;
                }
                if (this.grid2.Columns[i].Index > 3)
                {
                    this.grid2.Columns[i].CellAppearance.TextHAlign = HAlign.Right;
                    this.grid2.Columns[i].Format = "###,##0.##";
                }
            }

            grid2.Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
            grid2.Columns["WORKCENTERNAME"].CellAppearance.BackColor = Color.White;
        }
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            //if (((WIZ.Control.Grid)sender).ActiveRow == null)
            //    return;

            string WORKCENTERNAME = ((WIZ.Control.Grid)sender).ActiveRow.Cells["WORKCENTERNAME"].Value.ToString();

            if (this.TabControl1.SelectedTab.Index == 0)
            {
                if (rtnClonTemp.Rows.Count > 0 || rtnClonTemp2.Rows.Count > 0)
                {

                    DataRow[] row = rtnClonTemp.Select("WORKCENTERNAME = '" + WORKCENTERNAME + "'");
                    DataTable dt = new DataTable();

                    dt.Columns.Add("MT", typeof(System.String));
                    dt.Columns.Add("1월", typeof(System.Double));
                    dt.Columns.Add("2월", typeof(System.Double));
                    dt.Columns.Add("3월", typeof(System.Double));
                    dt.Columns.Add("4월", typeof(System.Double));
                    dt.Columns.Add("5월", typeof(System.Double));
                    dt.Columns.Add("6월", typeof(System.Double));
                    dt.Columns.Add("7월", typeof(System.Double));
                    dt.Columns.Add("8월", typeof(System.Double));
                    dt.Columns.Add("9월", typeof(System.Double));
                    dt.Columns.Add("10월", typeof(System.Double));
                    dt.Columns.Add("11월", typeof(System.Double));
                    dt.Columns.Add("12월", typeof(System.Double));

                    for (int i = 0; i < rtnClonTemp.Rows.Count; i++)
                    {
                        dt.Rows.Add(new object[]
                       {
                           row[i]["MT"].ToString(),
                           Convert.ToDouble(row[i]["MT01"]),
                           Convert.ToDouble(row[i]["MT02"]),
                           Convert.ToDouble(row[i]["MT03"]),
                           Convert.ToDouble(row[i]["MT04"]),
                           Convert.ToDouble(row[i]["MT05"]),
                           Convert.ToDouble(row[i]["MT06"]),
                           Convert.ToDouble(row[i]["MT07"]),
                           Convert.ToDouble(row[i]["MT08"]),
                           Convert.ToDouble(row[i]["MT09"]),
                           Convert.ToDouble(row[i]["MT10"]),
                           Convert.ToDouble(row[i]["MT11"]),
                           Convert.ToDouble(row[i]["MT12"])
                       });
                    }

                    DataRow[] row1 = rtnClonTemp2.Select("WORKCENTERNAME = '" + WORKCENTERNAME + "'");
                    DataTable dt1 = new DataTable();

                    dt1.Columns.Add("MT", typeof(System.String));
                    dt1.Columns.Add("1월", typeof(System.Double));
                    dt1.Columns.Add("2월", typeof(System.Double));
                    dt1.Columns.Add("3월", typeof(System.Double));
                    dt1.Columns.Add("4월", typeof(System.Double));
                    dt1.Columns.Add("5월", typeof(System.Double));
                    dt1.Columns.Add("6월", typeof(System.Double));
                    dt1.Columns.Add("7월", typeof(System.Double));
                    dt1.Columns.Add("8월", typeof(System.Double));
                    dt1.Columns.Add("9월", typeof(System.Double));
                    dt1.Columns.Add("10월", typeof(System.Double));
                    dt1.Columns.Add("11월", typeof(System.Double));
                    dt1.Columns.Add("12월", typeof(System.Double));

                    for (int i = 0; i < rtnClonTemp2.Rows.Count; i++)
                    {
                        dt1.Rows.Add(new object[]
                        {
                             row1[i]["MT"].ToString(),
                             Convert.ToDouble(row1[i]["MT01"]),
                             Convert.ToDouble(row1[i]["MT02"]),
                             Convert.ToDouble(row1[i]["MT03"]),
                             Convert.ToDouble(row1[i]["MT04"]),
                             Convert.ToDouble(row1[i]["MT05"]),
                             Convert.ToDouble(row1[i]["MT06"]),
                             Convert.ToDouble(row1[i]["MT07"]),
                             Convert.ToDouble(row1[i]["MT08"]),
                             Convert.ToDouble(row1[i]["MT09"]),
                             Convert.ToDouble(row1[i]["MT10"]),
                             Convert.ToDouble(row1[i]["MT11"]),
                             Convert.ToDouble(row1[i]["MT12"])
                        });
                    }

                    Chart3.DataSource = dt;
                    Chart4.DataSource = dt1;
                }
                else
                {
                    Chart3.Series.Clear();
                    Chart4.Series.Clear();
                    Chart3.Data.DataSource = null;
                    Chart4.Data.DataSource = null;
                }
            }
            else if (this.TabControl1.SelectedTab.Index == 1)
            {
                int columncnt = this.grid2.Columns.Count;
                if (rtnClonTemp.Rows.Count > 0 || rtnClonTemp2.Rows.Count > 0)
                {
                    // DataRow[] row = rtnClonTemp.Select("WORKCENTERNAME = '" + WORKCENTERNAME + "'");
                    DataRow row = rtnClonTemp.Rows[0];
                    DataTable dt = new DataTable();
                    dt = rtnClonTemp.Clone();
                    dt.Rows.Add(row.ItemArray);
                    dt.Columns.RemoveAt(0);
                    dt.Columns.Remove("ROW");
                    int dt1 = dt.Columns.Count;
                    dt.Columns.RemoveAt(dt.Columns.Count - 1);

                    //DataRow[] row1 = rtnClonTemp2.Select("WORKCENTERNAME = '" + WORKCENTERNAME + "'");
                    DataTable dt2 = new DataTable();
                    DataRow row1 = rtnClonTemp2.Rows[0];
                    dt2 = rtnClonTemp2.Clone();
                    dt2.Rows.Add(row1.ItemArray);
                    dt2.Columns.RemoveAt(0);
                    dt2.Columns.Remove("ROW");
                    // dt.Columns.RemoveAt(1);
                    int dt3 = dt2.Columns.Count;
                    dt2.Columns.RemoveAt(dt2.Columns.Count - 1);


                    Chart3.DataSource = dt;
                    Chart4.DataSource = dt2;
                }
                else
                {
                    Chart3.Series.Clear();
                    Chart4.Series.Clear();
                    Chart3.Data.DataSource = null;
                    Chart4.Data.DataSource = null;
                }
            }


        }

        private void TabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (TabControl1.SelectedTab.Index == 0)
            {
                this.CboStartDate_H.Visible = false;
                this.CboEndDate_H.Visible = false;
                this.sLabel2.Visible = false;
                this.cboSM_H.Visible = true;
                this.lblDate.Text = "고장 년도";
                Chart3.Series.Clear();
                Chart4.Series.Clear();
                Chart3.Data.DataSource = null;
                Chart4.Data.DataSource = null;
                _GridUtil.Grid_Clear(grid1);
            }
            else
            {
                this.CboStartDate_H.Visible = true;
                this.CboEndDate_H.Visible = true;
                this.sLabel2.Visible = true;
                this.cboSM_H.Visible = false;
                this.lblDate.Text = "고장 일자";

                Chart3.Series.Clear();
                Chart4.Series.Clear();
                Chart3.Data.DataSource = null;
                Chart4.Data.DataSource = null;
                _GridUtil.Grid_Clear(grid2);
            }

            //  DoFind();
        }

        private void CboStartDate_H_TextChanged(object sender, EventArgs e)
        {
            if (this.TabControl1.SelectedTab.Index > 0)
            {
                if (!(CheckData(fstart)))
                {
                    return;
                }
            }
            /*  TimeSpan TS = Convert.ToDateTime(this.CboStartDate_H.Value) - Convert.ToDateTime(this.CboEndDate_H.Value);
              int DATE = -(TS.Days);

              _GridUtil.Grid_Clear(grid2);
              grid2.DisplayLayout.ClearGroupByColumns();
              grid2.ResetDisplayLayout();

              for (int I = 0; I <= DATE; I++)
              {
                  _GridUtil.InitColumnUltraGrid(grid2, string.Format("{0:MMdd}", Convert.ToDateTime(this.CboStartDate_H.Value).AddDays(I))
                       , string.Format("{0:MM/dd}", Convert.ToDateTime(this.CboStartDate_H.Value).AddDays(I)), false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,##0.##", null, null, null, null);
              }
              _GridUtil.SetInitUltraGridBind(grid2);
              */
        }

        private bool CheckData(int fstart)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", this.CboStartDate_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", this.CboEndDate_H.Value));
            int today = Convert.ToInt32(string.Format("{0:yyyyMMdd}", System.DateTime.Today));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                this.CboStartDate_H.Value = DateTime.ParseExact(Convert.ToString(fstart), "yyyyMMdd", null);
                // this.CboStartDate_H.Text = string.Format("{0:yyyy-MM-dd}", sEnd);
                return false;
            }
            if (sEnd > today)
            {
                this.ShowDialog(Common.getLangText("조회 종료일자가 현재일보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                this.CboEndDate_H.Value = System.DateTime.Today;
                return false;
            }
            return true;
        }

        private void CboStartDate_H_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(string.Format("{0:yyyyMMdd}", this.CboStartDate_H.Value)) <= fstart)
                fstart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", this.CboStartDate_H.Value));
        }

    }
}
