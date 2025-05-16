#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                            
//   Form ID      : PP4300                                                                                                                                                                                    
//   Form Name    : 월별 작업장 설비 효율관리                                                                                                                                                         
//   Name Space   : WIZ.MM                                                                                                                                                                                  
//   Created Date :                                                                                                                                                                                           
//   Made By      : WIZCORE                                                                                                                                                          
//   Description  :                                                                                                                                                                                           
// *---------------------------------------------------------------------------------------------*                                                                                                            
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP4300 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMEBER AREA >                                                                                                                               
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통                                                                                                                                       
        #endregion

        #region < CONSTRUCTOR >
        public PP4300()
        {
            InitializeComponent();
        }
        #endregion

        #region < PP4300_Load >
        private void PP4300_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            //그리드 객체 생성                                                                                                                                                                                    
            UltraGridUtil _GridUtil = new UltraGridUtil();
            DataTable girddt = new DataTable();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "DescList", "항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "YYYY2", "전년도", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "1월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "2월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "3월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "4월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "5월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "6월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "7월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "8월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "9월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "10월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "11월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "12월", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "YYYY1", "합계", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            girddt.Columns.Add("DescList", typeof(System.String));
            girddt.Columns.Add("YYYY2", typeof(System.String));
            girddt.Columns.Add("M01", typeof(System.String));
            girddt.Columns.Add("M02", typeof(System.String));
            girddt.Columns.Add("M03", typeof(System.String));
            girddt.Columns.Add("M04", typeof(System.String));
            girddt.Columns.Add("M05", typeof(System.String));
            girddt.Columns.Add("M06", typeof(System.String));
            girddt.Columns.Add("M07", typeof(System.String));
            girddt.Columns.Add("M08", typeof(System.String));
            girddt.Columns.Add("M09", typeof(System.String));
            girddt.Columns.Add("M10", typeof(System.String));
            girddt.Columns.Add("M11", typeof(System.String));
            girddt.Columns.Add("M12", typeof(System.String));
            girddt.Columns.Add("YYYY1", typeof(System.String));

            girddt.Rows.Add(new object[] { "조업시간", "" });
            girddt.Rows.Add(new object[] { "계획 Loss", "" });
            girddt.Rows.Add(new object[] { "부하 시간", "" });
            girddt.Rows.Add(new object[] { "관리 Loss", "" });
            girddt.Rows.Add(new object[] { "가동 시간", "" });
            girddt.Rows.Add(new object[] { "정지 Loss", "" });
            girddt.Rows.Add(new object[] { "가치 가동 시간", "" });
            girddt.Rows.Add(new object[] { "불량Loss", "" });
            girddt.Rows.Add(new object[] { "생산량", "" });
            girddt.Rows.Add(new object[] { "불량량", "" });
            girddt.Rows.Add(new object[] { "폐기량", "" });
            girddt.Rows.Add(new object[] { "미등록시간", "" });
            grid1.DataSource = girddt;

            #endregion

            #region --- ComboBox Setting ---
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion

            #region --- POP-Up Setting ---
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>                                                                                                                                                                                         
        /// ToolBar의 조회 버튼 클릭                                                                                                                                                                          
        /// </summary>                                                                                                                                                                                        
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString();                                                // 사업장(공장)                                                                           
                string SYyyy1 = Convert.ToDateTime(this.cboYear_H.Value).ToString("yyyy");                          // 년도
                string SYyyy2 = "2012";                                                                             // 전년도
                string sOPCode = this.txtOPCode.Text.Trim();                                                        // 공정 코드                                                                              
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                        // 작업장 코드                                                                            

                rtnDtTemp = helper.FillTable("USP_PP4300_S1N"
                                                  , CommandType.StoredProcedure
                                                  , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("YYYY1", SYyyy1, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("YYYY2", SYyyy2, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input));

                DataTable dt = (DataTable)grid1.DataSource;
                dt.Clear();

                dt.Rows.Add(new object[] { "조업시간", "" });
                dt.Rows.Add(new object[] { "계획 Loss", "" });
                dt.Rows.Add(new object[] { "부하 시간", "" });
                dt.Rows.Add(new object[] { "관리 Loss", "" });
                dt.Rows.Add(new object[] { "가동 시간", "" });
                dt.Rows.Add(new object[] { "정지 Loss", "" });
                dt.Rows.Add(new object[] { "가치 가동 시간", "" });
                dt.Rows.Add(new object[] { "불량Loss", "" });
                dt.Rows.Add(new object[] { "생산량", "" });
                dt.Rows.Add(new object[] { "불량량", "" });
                dt.Rows.Add(new object[] { "폐기량", "" });
                dt.Rows.Add(new object[] { "미등록시간", "" });

                for (int i = 1; i < 14; i++)
                {
                    dt.Rows[0][i] = "0"; 	     // 조업시간				
                    dt.Rows[1][i] = "0"; 	     // 계획 Loss 			
                    dt.Rows[2][i] = "0";   	     // 부하 시간				
                    dt.Rows[3][i] = "0";  	     // 관리 Loss 			
                    dt.Rows[4][i] = "0";         // 가동 시간			 
                    dt.Rows[5][i] = "0"; 	     // 정지 Loss 			
                    dt.Rows[6][i] = "0";	     // 가치 가동 시간 
                    dt.Rows[7][i] = "0"; 		 // 불량Loss 			 
                    dt.Rows[8][i] = "0"; 	     // 생산중량 			 
                    dt.Rows[9][i] = "0"; 		 // 불량중량 				
                    dt.Rows[10][i] = "0";		 // 폐기중량				
                    dt.Rows[11][i] = "0";		 // 미등록시간	   
                }
                int intGB;
                foreach (DataRow dr in rtnDtTemp.Rows)
                {
                    intGB = Convert.ToInt32(dr["GB"]) + 1;
                    dt.Rows[0][intGB] = dr["WorkAbleTime"];   // 조업시간				
                    dt.Rows[1][intGB] = dr["PlanLossTime"];   // 계획 Loss 			
                    dt.Rows[2][intGB] = dr["WorkTime"];   	  // 부하 시간				
                    dt.Rows[3][intGB] = dr["ManaLossTime"];   // 관리 Loss 			
                    dt.Rows[4][intGB] = dr["RunTime"];        // 가동 시간			 
                    dt.Rows[5][intGB] = dr["StopLossTime"];   // 정지 Loss 			
                    dt.Rows[6][intGB] = dr["ValRunTime"];	  // 가치 가동 시간 
                    dt.Rows[7][intGB] = dr["ErrorLossTime"];  // 불량Loss 			 
                    dt.Rows[8][intGB] = dr["ProdWgt"]; 	      // 생산중량 			 
                    dt.Rows[9][intGB] = dr["ErrorWgt"]; 	  // 불량중량 				
                    dt.Rows[10][intGB] = dr["ScrptWgt"];	  // 폐기중량				
                    dt.Rows[11][intGB] = dr["NoResLossTime"]; // 미등록시간	   
                }

                grid1.DataSource = dt;
                grid1.DataBinds();

                if (dt.Rows.Count > 0)
                {
                    //ultraChart1.Series.Clear();
                    ////ultraChart1.Visible = true;

                    //NumericSeries series = new NumericSeries();
                    //series.Data.DataSource = rtnDtTemp;
                    //series.Data.LabelColumn = "GB";
                    //series.Data.ValueColumn = "RunTime";
                    //ultraChart1.Axis.X.TimeAxisStyle.TimeAxisStyle = Infragistics.UltraChart.Shared.Styles.RulerGenre.Continuous;
                    //ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                    //series.DataBind();

                    //ultraChart1.Series.Add(series);
                    //ultraChart1.Data.DataBind();
                    ultraChart1.Series.Clear();
                    //----------------------------
                    DataTable dt1 = new DataTable();

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
                    dt1.Columns.Add("12월", typeof(System.String));

                    dt1.Rows.Add(new object[] {
                         Convert.ToDouble(dt.Rows[6][2]),
                         Convert.ToDouble(dt.Rows[6][3]),
                         Convert.ToDouble(dt.Rows[6][4]),
                         Convert.ToDouble(dt.Rows[6][5]),
                         Convert.ToDouble(dt.Rows[6][6]),
                         Convert.ToDouble(dt.Rows[6][7]),
                         Convert.ToDouble(dt.Rows[6][8]),
                         Convert.ToDouble(dt.Rows[6][9]),
                         Convert.ToDouble(dt.Rows[6][10]),
                         Convert.ToDouble(dt.Rows[6][11]),
                         Convert.ToDouble(dt.Rows[6][12]),
                         Convert.ToDouble(dt.Rows[6][13])
                  });
                    ultraChart1.DataSource = dt1;
                }
                else
                {
                    ultraChart1.Visible = false;
                }
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

    }
}