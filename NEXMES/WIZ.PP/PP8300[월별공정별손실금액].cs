#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                            
//   Form ID      : PP8300                                                                                                                                                                                    
//   Form Name    : 월별 공정별 손실금액
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
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP8300 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통                                                                                                                                       
        #endregion

        #region<CONSTRUCTOR>
        public PP8300()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
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

                string sPlantCode = cboPlantCode_H.Value.ToString();                                               // 사업장(공장)                                                                           
                string SYyyy1 = Convert.ToDateTime(this.cboYear_H.Value).ToString("yyyy");                         // 년도
                string SYyyy2 = "2012";                                                                            // 전년도
                string sOPCode = this.txtOPCode.Text.Trim();                                                       // 공정 코드                                                                              

                rtnDtTemp = helper.FillTable("USP_PP8300_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)           // 공장               
                                                            , helper.CreateParameter("yyyy", SYyyy1, DbType.String, ParameterDirection.Input)                    // 년도               
                                                            , helper.CreateParameter("yyyyOld", SYyyy2, DbType.String, ParameterDirection.Input)                 // 전년도(PP4300참초) 
                                                            , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input));               // 공정 코드          
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                if (rtnDtTemp.Rows.Count > 0)
                {

                    NumericSeries series = new NumericSeries();
                    DataTable table = new DataTable();

                    table.Columns.Add("공정", typeof(string));
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
                              rtnDtTemp.Rows[i]["OPName"].ToString(),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["OldSA"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA01"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA02"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA03"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA04"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA05"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA06"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA07"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA08"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA09"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA10"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA11"].ToString()),
                              Convert.ToDouble(rtnDtTemp.Rows[i]["SA12"].ToString())
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
        private void PP8300_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성                                                                                                                                                                                    
            UltraGridUtil _GridUtil = new UltraGridUtil();
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명명", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OldSA", "전년도", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA01", "1월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA02", "2월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA03", "3월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA04", "4월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA05", "5월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA06", "6월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA07", "7월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA08", "8월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA09", "9월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA10", "10월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA11", "11월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SA12", "12월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TotSA", "합계", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###,###", null, null, null, null);
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