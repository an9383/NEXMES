#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                            
//   Form ID      : PP8500                                                                                                                                                                                    
//   Form Name    : 비가동추이                                                                                                                                                         
//   Name Space   : WIZ.MM                                                                                                                                                                                  
//   Created Date :                                                                                                                                                                                           
//   Made By      : WIZCORE                                                                                                                                                          
//   Description  :                                                                                                                                                                                           
// *---------------------------------------------------------------------------------------------*                                                                                                            
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.PP
{
    public partial class PP8500 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통                                                                                                                                      
        #endregion

        #region<CONSTRUCTOR>
        public PP8500()
        {
            InitializeComponent();
        }
        #endregion

        #region<TOOL BAR AREA>
        /// <summary>                                                                                                                                                                                         
        /// ToolBar의 조회 버튼 클릭                                                                                                                                                                          
        /// </summary>                                                                                                                                                                                        
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = cboPlantCode_H.Value.ToString();                                                // 사업장(공장)                                                                           
                string SYyyy1 = Convert.ToDateTime(this.cboYear_H.Value).ToString("yyyy");                          // 년도
                string SYyyy2 = Convert.ToDateTime(this.cboYear_H.Value).AddYears(-1).ToString("yyyy");             // 전년도

                rtnDtTemp = helper.FillTable("USP_PP8500_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)      // 공장               
                                                                   , helper.CreateParameter("yyyy", SYyyy1, DbType.String, ParameterDirection.Input)               // 년도               
                                                                   , helper.CreateParameter("yyyyOld", SYyyy2, DbType.String, ParameterDirection.Input));          // 전년도(PP4300참초) 
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    NumericSeries series = new NumericSeries();
                    DataTable table = new DataTable();

                    table.Columns.Add("공장", typeof(string));
                    table.Columns.Add("전년", typeof(double));
                    table.Columns.Add("1월", typeof(double));
                    table.Columns.Add("2월", typeof(double));
                    table.Columns.Add("3월", typeof(double));
                    table.Columns.Add("4월", typeof(double));
                    table.Columns.Add("5월", typeof(double));
                    table.Columns.Add("6월", typeof(double));
                    table.Columns.Add("7월", typeof(double));
                    table.Columns.Add("8월", typeof(double));
                    table.Columns.Add("9월", typeof(double));
                    table.Columns.Add("10월", typeof(double));
                    table.Columns.Add("11월", typeof(double));
                    table.Columns.Add("12월", typeof(double));
                    if (grid1.Rows.Count != 0)
                    {
                        for (int i = 0; i < this.rtnDtTemp.Rows.Count; i++)
                        {
                            table.Rows.Add(new object[] {
       rtnDtTemp.Rows[i]["PlantCode"].ToString(),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["OldRA"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra01"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra02"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra03"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra04"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra05"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra06"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra07"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra08"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra09"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra10"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra11"]),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["Ra12"])
                             });
                        }
                    }

                    ultraChart1.Visible = true;

                    ultraChart1.Data.DataSource = table;
                    ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                    ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                    series.DataBind();

                    ultraChart1.Data.DataBind();

                }
                else
                {
                    ultraChart1.Series.Clear();
                    ultraChart1.Visible = false;
                }

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

        #region 폼 로더
        private void PP8500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성                                                                                                                                                                                    
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "Plantcode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OldRA", "전년도", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra01", "1월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra02", "2월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra03", "3월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra04", "4월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra05", "5월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra06", "6월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra07", "7월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra08", "8월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra09", "9월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra10", "10월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra11", "11월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Ra12", "12월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "AllRA", "합계", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);


            #endregion

            #region 콤보박스

            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            this.ultraChart1.EmptyChartText = string.Empty;
            #endregion
        }
        #endregion
    }
}