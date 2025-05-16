#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PT0400
//   Form Name    : 작업장별 월 생산 추이 정보 조회
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : PP4500 품목별 월 생산 추이 정보 화면을 이용 작업장별로 조회하는 화면 추가
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using WIZ.Forms;
#endregion

namespace WIZ.PP
{

    public partial class PT0400 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region<CONSTRUCTOR>
        public PT0400()
        {
            InitializeComponent();
        }
        #endregion

        #region PT0400_Load
        private void PT0400_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "팀구분", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "OPCode", "작업장코드", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "OPName", "작업장명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "TotQty", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "TOTALRATE", "달성률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P01", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P02", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P03", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P04", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P05", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P06", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P07", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P08", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P09", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P10", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P11", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "P12", "생산량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "불량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12RATE", "양품률(%)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,0", null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //string[] sMergeColumn = { "PlantCode", "DEPTCODE", "OPCode", "OPName", "ItemCode", "ItemName" };
            string[] sMergeColumn = { "PlantCode" };
            //string[] sMergeColumnSum = { "PLANQTY", "TotQty", "TOTALRATE" };
            string[] sMergeColumn1 = { "P01", "M01", "M01RATE" };
            string[] sMergeColumn2 = { "P02", "M02", "M02RATE" };
            string[] sMergeColumn3 = { "P03", "M03", "M03RATE" };
            string[] sMergeColumn4 = { "P04", "M04", "M04RATE" };
            string[] sMergeColumn5 = { "P05", "M05", "M05RATE" };
            string[] sMergeColumn6 = { "P06", "M06", "M06RATE" };
            string[] sMergeColumn7 = { "P07", "M07", "M07RATE" };
            string[] sMergeColumn8 = { "P08", "M08", "M08RATE" };
            string[] sMergeColumn9 = { "P09", "M09", "M09RATE" };
            string[] sMergeColumn10 = { "P10", "M10", "M10RATE" };
            string[] sMergeColumn11 = { "P11", "M11", "M11RATE" };
            string[] sMergeColumn12 = { "P12", "M12", "M12RATE" };

            string[] sHeadColumn = {"PlantCode", "P01","M01","M01RATE", "P02", "M02", "M02RATE", "P03", "M03", "M03RATE",
            "P04","M04", "M04RATE", "P05", "M05", "M05RATE", "P06", "M06", "M06RATE", "P07", "M07", "M07RATE",
            "P08", "M08","M08RATE", "P09", "M09", "M09RATE", "P10", "M10", "M10RATE", "P11", "M11", "M11RATE",
            "P12", "M12","M12RATE"};


            //그리드 머지
            _GridUtil.GridHeaderMerge(grid1, "G1", "1월", sMergeColumn1, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "2월", sMergeColumn2, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G3", "3월", sMergeColumn3, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G4", "4월", sMergeColumn4, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G5", "5월", sMergeColumn5, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G6", "6월", sMergeColumn6, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G7", "7월", sMergeColumn7, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G8", "8월", sMergeColumn8, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G9", "9월", sMergeColumn9, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G10", "10월", sMergeColumn10, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G11", "11월", sMergeColumn11, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G12", "12월", sMergeColumn12, sHeadColumn);

            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 0);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            this.ultraChart1.EmptyChartText = string.Empty;
        }
        #endregion PT0400_Load

        #region 조회
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string SYyyy = Convert.ToDateTime(this.cboYear_H.Value).ToString("yyyy");

                rtnDtTemp = helper.FillTable("USP_PT0400_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("Yyyy", SYyyy, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    //----------------------------
                    DataTable dt = new DataTable();

                    dt.Columns.Add("PlantCode", typeof(System.String));
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
                    dt.Columns.Add("12월", typeof(System.String));

                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        dt.Rows.Add(new object[] {
                            rtnDtTemp.Rows[i]["PlantCode"].ToString(),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M01"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M02"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M03"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M04"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M05"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M06"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M07"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M08"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M09"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M10"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M11"]),
                            Convert.ToDouble(rtnDtTemp.Rows[i]["M12"])
                        });
                    }
                    ultraChart1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 조회
    }
}
