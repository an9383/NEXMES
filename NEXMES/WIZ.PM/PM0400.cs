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
using Infragistics.UltraChart.Core.Layers;
using Infragistics.UltraChart.Core.Primitives;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace WIZ.PM
{
    public partial class PM0400 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private string save_plantcode = "820";
        private string save_Y00 = "2013";
        #endregion

        #region < CONSTRUCTOR >

        public PM0400()
        {
            InitializeComponent();
        }

        private void PM0400_Load(object sender, EventArgs e)
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


            _GridUtil.InitColumnUltraGrid(grid1, "prod", "*", false, GridColDataType_emu.VarChar, 40, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MONITEMSPNAME", "구분", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MONITEMSPEFFECT", "공수코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTAVG", "전년도평균(%)", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "THISAVG", "이번년평균(%)", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "01", "1월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "02", "2월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "03", "3월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "04", "4월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "05", "5월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "06", "6월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "07", "7월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "08", "8월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "09", "9월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "10", "10월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "11", "11월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "12", "12월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);


            //그리드 라인 색깔 해제
            //grid1.UseAppStyling = false;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            string[] sMergeColumn = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            string[] sMergeColumn2 = { "MONITEMSPNAME", "MONITEMSPEFFECT", "LASTAVG", "THISAVG" };
            string[] sMergeColumn3 = { "LASTAVG", "THISAVG" };
            string[] sMergeColumn4 = { "prod" };
            string[] sHeadColumn = { "prod", "MONITEMSPNAME", "MONITEMSPEFFECT", "LASTAVG", "THISAVG", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "RowNum", "*", false, GridColDataType_emu.VarChar, 40, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPCode", "구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TypeName", "구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LASTAVG", " ", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "THISAVG", " ", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "01", "1월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "02", "2월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "03", "3월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "04", "4월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "05", "5월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "06", "6월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "07", "7월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "08", "8월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "09", "9월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "10", "10월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "11", "11월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "12", "12월", false, GridColDataType_emu.VarChar, 72, 100, Infragistics.Win.HAlign.Right, true, true, "###,###,###", null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            grid2.Columns["OPCode"].CellMultiLine = DefaultableBoolean.True;

            cbo_plantcode.SelectedText = "820";

            #region Grid MERGE
            grid1.Columns["prod"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["prod"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["prod"].MergedCellStyle = MergedCellStyle.Always;

            grid2.Columns["OPCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid2.Columns["OPCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid2.Columns["OPCode"].MergedCellStyle = MergedCellStyle.Always;

            UltraGridBand band = grid2.DisplayLayout.Bands[0];

            band.RowLayoutStyle = RowLayoutStyle.GroupLayout;
            band.Columns.Add("G1", "구분");

            band.Columns["G1"].RowLayoutColumnInfo.OriginX = 0;
            band.Columns["G1"].RowLayoutColumnInfo.OriginY = 0;

            band.Columns["G1"].RowLayoutColumnInfo.SpanX = 4;
            band.Columns["G1"].RowLayoutColumnInfo.SpanY = 2;

            band.Columns["G1"].RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;

            //그리드 머지
            _GridUtil.GridHeaderMerge(grid1, "G1", "년도", sMergeColumn, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G3", "평균", sMergeColumn3, sHeadColumn);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 1);

            #endregion Grid MERGE

            #endregion



            //#region Grid2 셋팅
            //_GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            //// InitColumnUltraGrid
            //// 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            //// 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            //// 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            ////A.PLANTCODE , C.Value2 AS LASTYEAR,
            ////     [01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12] from

            //_GridUtil.InitColumnUltraGrid(grid2, "M00NAME", "구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid2, "M00", "구분코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid2, "problemremark", "문제점", false, GridColDataType_emu.VarChar, 300, 8000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid2, "analyremark", "원인분석", false, GridColDataType_emu.VarChar, 300, 8000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid2, "measureremark", "대책", false, GridColDataType_emu.VarChar, 300, 8000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid2, "deptremark", "담당부서", false, GridColDataType_emu.VarChar, 100, 1000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid2, "resultremark", "조치결과", false, GridColDataType_emu.VarChar, 100, 1000, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);


            //grid2.DisplayLayout.Bands[0].Columns["problemremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            //grid2.DisplayLayout.Bands[0].Columns["analyremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            //grid2.DisplayLayout.Bands[0].Columns["measureremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            //grid2.DisplayLayout.Bands[0].Columns["deptremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            //grid2.DisplayLayout.Bands[0].Columns["resultremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;

            //grid2.DisplayLayout.Override.DefaultRowHeight = 150;
            //grid2.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
            //grid2.DisplayLayout.Bands[0].Columns["problemremark"].VertScrollBar = true;
            //grid2.DisplayLayout.Bands[0].Columns["analyremark"].VertScrollBar = true;
            //grid2.DisplayLayout.Bands[0].Columns["measureremark"].VertScrollBar = true;


            ////그리드 라인 색깔 해제
            ////grid2.UseAppStyling = false;
            //grid2.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            //grid2.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            //grid2.EnterNextRowEnable = false;


            //#endregion

            #region 콤보박스

            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_plantcode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TARGETCLASS", "RELCODE2 = 'T'");
            WIZ.Common.FillComboboxMaster(this.cbo_TARGETCLASS, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            #endregion

        }


        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            string sChkCell = "first";
            DataSet rtnDsTemp = new DataSet(); // return DataSet 공통);
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[7];
            try
            {
                sChkCell = "first";
                base.DoInquire();
                string sTITLE = string.Empty;
                if (cbo_TARGETCLASS.Value.ToString() == "CL09")
                {
                    sTITLE = "가공";
                }
                else
                {
                    sTITLE = "조립";
                }
                label3.Text = sTITLE;

                label1.Text = "<" + cbo_date.Text + "년도 공정품질 현황(" + sTITLE + ")>";

                string sDtp_date = cbo_date.Value.ToString().Substring(0, 4);
                string sGUBUN = cbo_TARGETCLASS.Value.ToString();

                param[0] = helper.CreateParameter("@etc1", "", DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@etc2", "", DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@gubun", sGUBUN, DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@Date", sDtp_date, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@Plantcode", cbo_plantcode.Value.ToString(), DbType.String, ParameterDirection.Input);

                param[5] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                param[6] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);
                /*
                param[0] = helper.CreateParameter("@etc1", "", SqlDbType.VarChar, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@etc2", "", SqlDbType.VarChar, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@gubun", sGUBUN, SqlDbType.VarChar, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@Date", sDtp_date, SqlDbType.VarChar, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@Plantcode", cbo_plantcode.SelectedValue.ToString(), SqlDbType.VarChar, ParameterDirection.Input);

                param[5] = helper.CreateParameter("RS_CODE", SqlDbType.VarChar, ParameterDirection.Output, null, 1);
                param[6] = helper.CreateParameter("RS_MSG", SqlDbType.VarChar, ParameterDirection.Output, null, 200)
                 */
                rtnDsTemp = helper.FillDataSet("USP_PM0400_S1", CommandType.StoredProcedure, param);

                //List<SqlParameter> sList = new List<SqlParameter>();


                DataTable rtnDT = helper.FillTable("USP_PM0400_S2", CommandType.StoredProcedure
                                                                  , helper.CreateParameter("@etc1", Convert.ToString(""), DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("@etc2", Convert.ToString(""), DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("@gubun", Convert.ToString(""), DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("@Date", Convert.ToString(""), DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("@Plantcode", Convert.ToString(""), DbType.String, ParameterDirection.Input));

                /*
                 
                DataSet rtnDsTemp = SqlDBHelper.FillDataSet("USP_PM0400_S1", CommandType.StoredProcedure, param);
                

                List<SqlParameter> sList = new List<SqlParameter>();
                sList.Add(helper.CreateParameter("@etc1", "", SqlDbType.VarChar, ParameterDirection.Input));
                sList.Add(helper.CreateParameter("@etc2", "", SqlDbType.VarChar, ParameterDirection.Input));
                sList.Add(helper.CreateParameter("@gubun", sGUBUN, SqlDbType.VarChar, ParameterDirection.Input));
                sList.Add(helper.CreateParameter("@Date", sDtp_date, SqlDbType.VarChar, ParameterDirection.Input));
                sList.Add(helper.CreateParameter("@Plantcode", cbo_plantcode.SelectedValue.ToString(), SqlDbType.VarChar, ParameterDirection.Input));

                sList.Add(helper.CreateParameter("RS_CODE", SqlDbType.VarChar, ParameterDirection.Output, null, 1));
                sList.Add(helper.CreateParameter("RS_MSG", SqlDbType.VarChar, ParameterDirection.Output, null, 200));

                
                DataTable rtnDT = SqlDBHelper.FillTable("USP_PM0400_S2", CommandType.StoredProcedure, sList);
                 */





                for (int i = 0; i < rtnDT.Rows.Count; i++)
                {
                    DataRow dr1 = rtnDT.NewRow();
                    dr1["RowNum"] = rtnDT.Rows[i]["RowNum"];
                    dr1["OPCode"] = rtnDT.Rows[i]["OPCode"];
                    dr1["TypeName"] = "점유율(%)";

                    DataRow dr2 = rtnDT.NewRow();
                    dr2["RowNum"] = rtnDT.Rows[i]["RowNum"];
                    dr2["OPCode"] = rtnDT.Rows[i]["OPCode"];
                    dr2["TypeName"] = "점유불량율";

                    rtnDT.Rows.InsertAt(dr2, i + 1);
                    rtnDT.Rows.InsertAt(dr1, i + 1);

                    i += 2;
                }

                //-- 점유율, 점유불량율 계산
                if (rtnDsTemp.Tables.Count > 1)
                {
                    DataTable tdt = rtnDsTemp.Tables[0];

                    for (int i = 0; i < rtnDT.Rows.Count; i += 3)
                    {
                        bool bProc = false;

                        for (int j = 0; j < rtnDT.Columns.Count; j++)
                        {
                            string sColName = rtnDT.Columns[j].ColumnName;

                            if (sColName == "LASTAVG")
                            {
                                bProc = true;
                            }

                            if (bProc)
                            {
                                //double 전체불량 = SqlDBHelper.nvlDouble(tdt.Rows[1][sColName]);
                                //double 불량수_양품수 = 전체불량 + SqlDBHelper.nvlDouble(tdt.Rows[2][sColName]);
                                double 전체불량 = DBHelper.nvlDouble(tdt.Rows[1][sColName]);
                                double 불량수_양품수 = 전체불량 + DBHelper.nvlDouble(tdt.Rows[2][sColName]);

                                if (!(전체불량 == 0 || 불량수_양품수 == 0))
                                {
                                    //double 불량수 = SqlDBHelper.nvlDouble(rtnDT.Rows[i][sColName]);
                                    double 불량수 = DBHelper.nvlDouble(rtnDT.Rows[i][sColName]);

                                    double 점유율 = 불량수 / 전체불량 * 100;
                                    double 점유불량율 = 불량수 / 불량수_양품수 * 1000000;

                                    rtnDT.Rows[i + 1][sColName] = Math.Round(점유율, 2);
                                    rtnDT.Rows[i + 2][sColName] = Math.Round(점유불량율, 2);
                                    //불량수 / ( 전체불량수+ 전체양품수) * 1000000
                                }
                            }
                        }
                    }
                }

                //rtnDT.Columns["LASTAVG"].Caption = (SqlDBHelper.nvlInt(sDtp_date) - 1).ToString() + "년";
                rtnDT.Columns["LASTAVG"].Caption = (DBHelper.nvlInt(sDtp_date) - 1).ToString() + "년";
                rtnDT.Columns["THISAVG"].Caption = sDtp_date + "년";


                //string steamcode = rtnDsTemp.Tables[1].Rows[0]["Minorcode"].ToString();
                //string steamcode2 = rtnDsTemp.Tables[1].Rows[1]["Minorcode"].ToString();

                int lastrow = rtnDsTemp.Tables[0].Rows.Count - 1;

                Hashtable hash = new Hashtable();

                foreach (DataRow drRow in rtnDsTemp.Tables[0].Rows)
                {
                    // hash.Add(SqlDBHelper.gGetCode(drRow["MONITEMSPEFFECT"]), drRow);
                    hash.Add(DBHelper.gGetCode(drRow["MONITEMSPEFFECT"]), drRow);
                }

                if (rtnDsTemp.Tables[0].Rows.Count > 0)
                {
                    for (int i = rtnDsTemp.Tables[0].Columns.IndexOf("LASTAVG"); i < rtnDsTemp.Tables[0].Columns.Count; i++)
                    {
                        double result_Tm1 = DBHelper.nvlDouble(((DataRow)hash["BADQTY"])[i]);
                        double result_Tm2 = DBHelper.nvlDouble(((DataRow)hash["GOODQTY"])[i]);
                        ((DataRow)hash["SUMQTY"])[i] = result_Tm2 == 0 ? 0 : DBHelper.nvlDouble((result_Tm1 / (result_Tm1 + result_Tm2) * 1000000));
                        /*
                         double result_Tm2 = SqlDBHelper.nvlDouble(((DataRow)hash["GOODQTY"])[i]);
                        ((DataRow)hash["SUMQTY"])[i] = result_Tm2 == 0 ? 0 : SqlDBHelper.nvlDouble((result_Tm1 / (result_Tm1 + result_Tm2) * 1000000));
                         */
                    }

                    grid1.DataSource = rtnDsTemp.Tables[0];
                    grid1.DataBind();



                    for (int i = grid1.Columns.IndexOf("LASTAVG"); i < grid1.Columns.Count; i++)
                    {
                        if (grid1.Rows[0].Cells[2].Value.ToString() == "")
                        {
                            grid1.DisplayLayout.Rows[0].Appearance.BackColor = Color.Blue;
                            grid1.DisplayLayout.Rows[0].Appearance.ForeColor = Color.White;
                            grid1.DisplayLayout.Rows[0].Appearance.FontData.SizeInPoints = 10;
                            grid1.DisplayLayout.Rows[0].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            grid1.Rows[0].Activation = Activation.NoEdit;
                        }

                        grid1.DisplayLayout.Rows[lastrow].Appearance.BackColor = Color.LightGreen;
                        grid1.DisplayLayout.Rows[lastrow].Appearance.ForeColor = Color.Black;
                        grid1.DisplayLayout.Rows[lastrow].Appearance.FontData.SizeInPoints = 10;
                        grid1.DisplayLayout.Rows[lastrow].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                        grid1.Rows[lastrow].Activation = Activation.NoEdit;
                    }
                }

                save_plantcode = cbo_plantcode.Value.ToString();
                save_Y00 = cbo_date.Value.ToString().Substring(0, 4);
                grid1.Columns["G1"].Header.Caption = cbo_date.Text + "년도";
                grid1.Columns["LASTAVG"].Header.Caption = Convert.ToInt16(cbo_date.Text) - 1 + "년도평균(%)";
                grid1.Columns["THISAVG"].Header.Caption = cbo_date.Text + "년도평균(%)";

                //*// 차트
                if (rtnDsTemp.Tables[0].Rows.Count > 0 && rtnDT.Rows.Count > 0)
                {
                    label1.Visible = true;

                    DataTable mainDt = new DataTable();

                    mainDt.Columns.Add("월", typeof(string));

                    List<int> iList = new List<int>();

                    for (int i = 0; i < rtnDT.Rows.Count; i++)
                    {
                        if (DBHelper.nvlString(rtnDT.Rows[i]["TypeName"]) == "점유불량율")
                        //SqlDBHelper.nvlString(rtnDT.Rows[i]["TypeName"]) == "점유불량율")
                        {
                            // mainDt.Columns.Add(SqlDBHelper.nvlString(rtnDT.Rows[i]["OPCode"]), typeof(double));
                            mainDt.Columns.Add(DBHelper.nvlString(rtnDT.Rows[i]["OPCode"]), typeof(double));
                            iList.Add(i);
                        }
                    }

                    //*// 레전드 설정
                    groupBox1.Visible = true;
                    int iLabel = 0;

                    PColor1.Visible = false;
                    GName1.Visible = false;

                    PColor2.Visible = false;
                    GName2.Visible = false;

                    PColor3.Visible = false;
                    GName3.Visible = false;

                    PColor4.Visible = false;
                    GName4.Visible = false;

                    for (iLabel = 0; iLabel < iList.Count; iLabel++)
                    {
                        switch (iLabel)
                        {
                            case 0:
                                GName1.Visible = true;
                                PColor1.Visible = true;
                                GName1.Text = DBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                //GName1.Text = SqlDBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                break;
                            case 1:
                                GName2.Visible = true;
                                PColor2.Visible = true;
                                GName2.Text = DBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                //GName2.Text = SqlDBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                break;
                            case 2:
                                GName3.Visible = true;
                                PColor3.Visible = true;
                                GName3.Text = DBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                //GName3.Text = SqlDBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                break;
                            case 3:
                                GName4.Visible = true;
                                PColor4.Visible = true;
                                GName4.Text = DBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                //GName4.Text = SqlDBHelper.nvlString(rtnDT.Rows[iList[iLabel]]["OPCode"]);
                                break;
                        }
                    }

                    int iRight = groupBox1.Width - 5;
                    if (GName1.Visible)
                    {
                        GName1.Left = iRight - (GName1.Width + 5);
                        PColor1.Left = GName1.Left - (PColor1.Width + 5);

                        iRight = PColor1.Left - 5;
                    }

                    if (GName2.Visible)
                    {
                        GName2.Left = iRight - (GName2.Width + 5);
                        PColor2.Left = GName2.Left - (PColor2.Width + 5);

                        iRight = PColor2.Left - 5;
                    }

                    if (GName3.Visible)
                    {
                        GName3.Left = iRight - (GName3.Width + 5);
                        PColor3.Left = GName3.Left - (PColor3.Width + 5);

                        iRight = PColor3.Left - 5;
                    }

                    if (GName4.Visible)
                    {
                        GName4.Left = iRight - (GName4.Width + 5);
                        PColor4.Left = GName4.Left - (PColor4.Width + 5);

                        iRight = PColor4.Left - 5;
                    }

                    GNameETC.Left = iRight - (GNameETC.Width + 5);
                    PColorETC.Left = GNameETC.Left - (PColorETC.Width + 5);

                    //*// 레전드 설정 완료

                    mainDt.Columns.Add("목표", typeof(double));

                    if (grid1.Rows.Count != 0)
                    {
                        for (int i = 3; i < rtnDT.Columns.Count; i++)
                        {
                            List<object> dList = new List<object>();

                            if (rtnDT.Columns[i].Caption.Contains("년"))
                            {
                                dList.Add(DBHelper.nvlString(rtnDT.Columns[i].Caption) + " 평균");
                                //dList.Add(SqlDBHelper.nvlString(rtnDT.Columns[i].Caption) + " 평균");
                            }
                            else
                            {
                                dList.Add(DBHelper.nvlString(rtnDT.Columns[i].Caption) + "월");
                                //dList.Add(SqlDBHelper.nvlString(rtnDT.Columns[i].Caption) + "월");
                            }

                            foreach (int idx in iList)
                            {
                                dList.Add(DBHelper.nvlDouble(rtnDT.Rows[idx][i]));
                                // dList.Add(SqlDBHelper.nvlDouble(rtnDT.Rows[idx][i]))
                            }

                            dList.Add(DBHelper.nvlDouble(rtnDsTemp.Tables[0].Rows[0][i]));
                            //dList.Add(SqlDBHelper.nvlDouble(rtnDsTemp.Tables[0].Rows[0][i]));

                            mainDt.Rows.Add(dList.ToArray());
                        }
                    }
                    #region 차트

                    chart.ChartType = ChartType.Composite;
                    ChartArea area = new ChartArea();
                    chart.CompositeChart.ChartAreas.Add(area);
                    area.Border.Color = Color.White;
                    AxisItem xAxisColumn = new AxisItem(chart, AxisNumber.X_Axis);
                    AxisItem xAxisLine = new AxisItem(chart, AxisNumber.X_Axis);
                    AxisItem yAxis = new AxisItem(chart, AxisNumber.Y_Axis);
                    AxisItem yAxis2 = new AxisItem(chart, AxisNumber.Y_Axis);

                    xAxisColumn.DataType = AxisDataType.String;
                    xAxisColumn.SetLabelAxisType = SetLabelAxisType.GroupBySeries;
                    xAxisColumn.Labels.ItemFormat = AxisItemLabelFormat.ItemLabel;
                    xAxisLine.DataType = AxisDataType.String;
                    xAxisLine.SetLabelAxisType = SetLabelAxisType.ContinuousData;

                    yAxis.DataType = AxisDataType.Numeric;
                    yAxis.Labels.ItemFormat = AxisItemLabelFormat.DataValue;
                    yAxis.Labels.ItemFormatString = "<DATA_VALUE:###,##0>";
                    // Y축을 왼쪽에 표시 하고자 할 경우  : AxisNumber.Y_Axis
                    //      오른쪽에 표시 하고자 할 경우 : AxisNumber.Y2_Axis
                    yAxis.OrientationType = AxisNumber.Y_Axis;
                    yAxis.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
                    yAxis.Labels.VerticalAlign = System.Drawing.StringAlignment.Far;

                    yAxis.DataType = AxisDataType.Numeric;
                    yAxis.TickmarkStyle = AxisTickStyle.Smart;
                    //yAxis.TickmarkInterval = 500;
                    yAxis.LineThickness = 2;

                    yAxis2.OrientationType = AxisNumber.Y2_Axis;

                    yAxis2.DataType = AxisDataType.Numeric;
                    yAxis2.TickmarkStyle = AxisTickStyle.Smart;
                    yAxis2.TickmarkInterval = 40;

                    yAxis2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
                    yAxis2.Labels.VerticalAlign = System.Drawing.StringAlignment.Far;

                    // Y2축 라벨 표시를 계단식을 보여줄지 여부 설정
                    yAxis2.Labels.Layout.Behavior = AxisLabelLayoutBehaviors.None;
                    yAxis2.Labels.Visible = true;

                    yAxis2.Labels.ItemFormat = AxisItemLabelFormat.DataValue;
                    yAxis2.MajorGridLines.Visible = true;
                    yAxis2.LineColor = Color.Blue;

                    yAxis2.RangeType = AxisRangeType.Custom;
                    yAxis2.RangeMin = -1;
                    yAxis2.RangeMax = 1;
                    yAxis2.Extent = 30;

                    //chart.Margin = new System.Windows.Forms.Padding(25,25,25, 25);
                    #endregion

                    #region[차트바인딩]

                    area.Axes.Add(xAxisColumn);
                    area.Axes.Add(xAxisLine);
                    area.Axes.Add(yAxis);
                    //area.Axes.Add(yAxis2);

                    List<NumericSeries> nsList = new List<NumericSeries>();

                    foreach (int i in iList)
                    {
                        NumericSeries ss = new NumericSeries();
                        ss.Data.DataSource = mainDt;
                        ss.Data.LabelColumn = "월";
                        ss.Data.ValueColumn = DBHelper.nvlString(rtnDT.Rows[i]["OPCode"]);
                        //ss.Data.ValueColumn = SqlDBHelper.nvlString(rtnDT.Rows[i]["OPCode"]);

                        nsList.Add(ss);
                    }

                    NumericSeries seriesLine2 = new NumericSeries();
                    seriesLine2.Data.DataSource = mainDt;
                    //  seriesLine2.Data.LabelColumn = "목적";
                    seriesLine2.Data.ValueColumn = "목표";

                    chart.Series.Add(seriesLine2);
                    chart.Series.AddRange(nsList.ToArray());

                    ChartLayerAppearance columnLayer = new ChartLayerAppearance();
                    columnLayer.AxisX = xAxisColumn;
                    columnLayer.AxisX.ScrollScale.Visible = true;
                    columnLayer.AxisY = yAxis;

                    columnLayer.AxisY.ScrollScale.Visible = true;

                    columnLayer.ChartArea = area;
                    columnLayer.ChartType = ChartType.StackColumnChart;
                    columnLayer.Series.Clear();

                    foreach (NumericSeries ns in nsList)
                    {
                        columnLayer.Series.Add(ns);
                    }

                    columnLayer.SwapRowsAndColumns = true;

                    ChartLayerAppearance lineLayer = new ChartLayerAppearance();
                    lineLayer.AxisX = xAxisLine;
                    lineLayer.AxisY = yAxis;
                    lineLayer.AxisY.TickmarkStyle = AxisTickStyle.Smart;
                    seriesLine2.PEs.Add(new PaintElement(Color.Blue));

                    lineLayer.ChartArea = area;
                    lineLayer.ChartType = ChartType.LineChart;
                    lineLayer.Series.Add(seriesLine2);
                    chart.CompositeChart.ChartLayers.Clear();
                    chart.CompositeChart.ChartLayers.Add(columnLayer);
                    chart.CompositeChart.ChartLayers.Add(lineLayer);
                    chart.CompositeChart.ChartAreas.Add(area);
                    chart.ColumnChart.ColumnSpacing = 1;

                    chart.Axis.X.Labels.SeriesLabels.Orientation = TextOrientation.VerticalLeftFacing;

                    chart.Legend.Visible = true;
                    chart.Legend.Location = LegendLocation.Top;

                    columnLayer.AxisX.Extent = 30;
                    columnLayer.AxisY.Extent = 40;

                    lineLayer.AxisX.Extent = 30;
                    lineLayer.AxisY.Extent = 40;


                    this.chart.InvalidateLayers();

                    for (int i = 0; i < rtnDT.Rows.Count; i++)
                    {
                        //if (SqlDBHelper.nvlString(rtnDT.Rows[i]["TypeName"]) == "점유불량율")
                        if (DBHelper.nvlString(rtnDT.Rows[i]["TypeName"]) == "점유불량율")
                            rtnDT.Rows.RemoveAt(i--);
                    }

                    //grid2.Columns["LASTAVG"].Header.Caption = (SqlDBHelper.nvlInt(sDtp_date) - 1).ToString() + "년";
                    grid2.Columns["LASTAVG"].Header.Caption = (DBHelper.nvlInt(sDtp_date) - 1).ToString() + "년";
                    grid2.Columns["THISAVG"].Header.Caption = sDtp_date + "년";

                    grid2.DataSource = rtnDT;
                    grid2.DataBind();

                    #endregion
                }
                //*//
            }
            catch (SqlException)
            {
                //this.ShowDialog(""+e, Windows.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        /// 


        private void chart_FillSceneGraph(object sender, Infragistics.UltraChart.Shared.Events.FillSceneGraphEventArgs e)
        {
            List<Primitive> list = new List<Primitive>();
            foreach (Primitive item in e.SceneGraph)
            {
                Box pl = item as Box;
                //Line sLine = item as Line;
                if (pl != null && pl.Series != null)
                {
                    pl.rect = new Rectangle(pl.rect.X + (pl.rect.Width / 4), pl.rect.Y, pl.rect.Width / 2, pl.rect.Height);
                }

                if (pl != null && pl.Series != null && ((NumericDataPoint)pl.DataPoint).Value != null)
                {
                    Text txt = new Text();
                    txt.SetTextString(((NumericDataPoint)pl.DataPoint).Value.ToString());
                    txt.bounds.Location = new Point(pl.rect.X + (pl.rect.Width / 2 - 5), pl.rect.Y + (pl.rect.Height / 2));
                    list.Add(txt);
                }
            }
        }

        public override void DoNew()
        {


        }
        public override void DoDownloadExcel()
        {
            this.grid1.Focus();

            base.DoDownloadExcel();
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

            this.Focus();

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                return;

            base.DoSave();

            //UltraGridUtil.DataRowDelete(this.grid1);
            // this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

            foreach (DataRow drRow in dt.Rows)
            {
                switch (drRow.RowState)
                {
                    case DataRowState.Modified:

                        #region 수정

                        if (DBHelper.gGetCode(drRow["MONSUBEFFECT"]) == "MonthPSum")
                        //SqlDBHelper.gGetCode(drRow["MONSUBEFFECT"]) == "MonthPSum")
                        {
                            continue;
                        }


                        for (int i = 5; i < 17; i++)
                        {

                            if (//SqlDBHelper.gGetCode(drRow[i]) != string.Empty)
                                DBHelper.gGetCode(drRow[i]) != string.Empty)
                            {

                                //SqlDBHelper.gGetCode(drRow[i]) != string.Empty)
                                //SqlParameter[] param = null;
                                DBHelper helper = new DBHelper(false);
                                System.Data.Common.DbParameter[] param = null;

                                try
                                {

                                    //param = new SqlParameter[8];
                                    param = new System.Data.Common.DbParameter[8];

                                    param[0] = helper.CreateParameter("@plantcode", save_plantcode, DbType.String, ParameterDirection.Input);
                                    param[1] = helper.CreateParameter("@MONSUBEFFECT", DBHelper.gGetCode(drRow["MONSUBEFFECT"]), DbType.String, ParameterDirection.Input);     // 등록자\
                                    param[2] = helper.CreateParameter("@Y00", save_Y00, DbType.String, ParameterDirection.Input);
                                    param[3] = helper.CreateParameter("@M00", grid1.Columns[i].Key, DbType.String, ParameterDirection.Input);
                                    param[4] = helper.CreateParameter("@RstValue", DBHelper.gGetCode(drRow[i]), DbType.String, ParameterDirection.Input);
                                    param[5] = helper.CreateParameter("@USER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);

                                    param[6] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                                    param[7] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                                    helper.ExecuteNoneQuery("USP_PM0400_I1", CommandType.StoredProcedure, param);


                                    if (param[6].Value.ToString() == "E") throw new Exception(param[7].Value.ToString());

                                    helper.Commit();

                                    /*
                                      param[0] = helper.CreateParameter("@plantcode", save_plantcode, SqlDbType.VarChar, ParameterDirection.Input);
                                    param[1] = helper.CreateParameter("@MONSUBEFFECT", SqlDBHelper.gGetCode(drRow["MONSUBEFFECT"]), SqlDbType.VarChar, ParameterDirection.Input);     // 등록자\
                                    param[2] = helper.CreateParameter("@Y00", save_Y00, SqlDbType.VarChar, ParameterDirection.Input);
                                    param[3] = helper.CreateParameter("@M00", grid1.Columns[i].Key, SqlDbType.VarChar, ParameterDirection.Input);
                                    param[4] = helper.CreateParameter("@RstValue", SqlDBHelper.gGetCode(drRow[i]), SqlDbType.VarChar, ParameterDirection.Input);
                                    param[5] = helper.CreateParameter("@USER", WIZ.LoginInfo.UserID, SqlDbType.VarChar, ParameterDirection.Input);

                                    param[6] = helper.CreateParameter("RS_CODE", SqlDbType.VarChar, ParameterDirection.Output, null, 1);
                                    param[7] = helper.CreateParameter("RS_MSG", SqlDbType.VarChar, ParameterDirection.Output, null, 200);

                                    SqlDBHelper.ExecuteNoneQuery("USP_PM0400_I1", CommandType.StoredProcedure, param);
                

                                    if (param[6].Value.ToString() == "E") throw new Exception(param[7].Value.ToString());

                                    helper.Transaction.Commit();
                                     */

                                }
                                catch (Exception ex)
                                {
                                    //helper.Transaction.Rollback();
                                    helper.Rollback();
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    //if (SqlDBHelper._sConn != null) { SqlDBHelper._sConn.Close(); }
                                    helper.Close();
                                    if (param != null) { param = null; }
                                }
                                helper.Close();

                            }
                        }




                        break;


                        #endregion
                }

            }

            //this.grid2.UpdateGridData();
            //if (grid2.Rows.Count >= 1)
            //{
            //    if (grid2.Rows[0].Cells["problemRemark"].Value.ToString().Trim() == string.Empty &&
            //        grid2.Rows[0].Cells["analyremark"].Value.ToString().Trim() == string.Empty &&
            //        grid2.Rows[0].Cells["measureremark"].Value.ToString().Trim() == string.Empty &&
            //        grid2.Rows[0].Cells["deptremark"].Value.ToString().Trim() == string.Empty &&
            //        grid2.Rows[0].Cells["resultremark"].Value.ToString().Trim() == string.Empty
            //        )
            //    {
            //        return;
            //    }


            //    if (grid2.Rows[0].Cells["M00"].Value.ToString() != string.Empty)
            //    {

            //        SqlDBHelper helper = new SqlDBHelper(false);
            //        SqlParameter[] param = null;

            //        try
            //        {

            //            param = new SqlParameter[12];

            //            param[0] = helper.CreateParameter("@plantcode", save_plantcode, SqlDbType.VarChar, ParameterDirection.Input);
            //            param[1] = helper.CreateParameter("@targetclass", "CL08", SqlDbType.VarChar, ParameterDirection.Input);
            //            param[2] = helper.CreateParameter("@Y00", save_Y00, SqlDbType.VarChar, ParameterDirection.Input);
            //            param[3] = helper.CreateParameter("@M00", SqlDBHelper.nvlString(grid2.Rows[0].Cells["M00"].Value.ToString()), SqlDbType.VarChar, ParameterDirection.Input);
            //            param[4] = helper.CreateParameter("@problemRemark", SqlDBHelper.nvlString(grid2.Rows[0].Cells["problemremark"].Value), SqlDbType.VarChar, ParameterDirection.Input);
            //            param[5] = helper.CreateParameter("@analyremark", SqlDBHelper.nvlString(grid2.Rows[0].Cells["analyremark"].Value), SqlDbType.VarChar, ParameterDirection.Input);
            //            param[6] = helper.CreateParameter("@measureremark", SqlDBHelper.nvlString(grid2.Rows[0].Cells["measureremark"].Value), SqlDbType.VarChar, ParameterDirection.Input);
            //            param[7] = helper.CreateParameter("@deptremark", SqlDBHelper.nvlString(grid2.Rows[0].Cells["deptremark"].Value), SqlDbType.VarChar, ParameterDirection.Input);
            //            param[8] = helper.CreateParameter("@resultremark", SqlDBHelper.nvlString(grid2.Rows[0].Cells["resultremark"].Value), SqlDbType.VarChar, ParameterDirection.Input);
            //            param[9] = helper.CreateParameter("@USER", WIZ.LoginInfo.UserID, SqlDbType.VarChar, ParameterDirection.Input);

            //            param[10] = helper.CreateParameter("RS_CODE", SqlDbType.VarChar, ParameterDirection.Output, null, 1);
            //            param[11] = helper.CreateParameter("RS_MSG", SqlDbType.VarChar, ParameterDirection.Output, null, 200);

            //            SqlDBHelper.ExecuteNoneQuery("USP_PM0400_I2", CommandType.StoredProcedure, param);

            //            if (param[10].Value.ToString() == "E") throw new Exception(param[11].Value.ToString());

            //            helper.Transaction.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            helper.Transaction.Rollback();
            //            MessageBox.Show(ex.ToString());
            //        }
            //        finally
            //        {
            //            if (SqlDBHelper._sConn != null) { SqlDBHelper._sConn.Close(); }
            //            if (param != null) { param = null; }
            //        }
            //    }
            //}





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
        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        //private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        //{

        //    if (e.Cell.Column.Header.Column.ToString().Trim().Length > 3)
        //    {
        //        return;
        //    }

        //    if (sChkCell == e.Cell.Column.Header.Column.ToString())
        //    {
        //        return;
        //    }


        //    if (e.Cell.Column.Header.Column.ToString() != "")
        //    {
        //        string sM00 = e.Cell.Column.Header.Column.ToString();
        //        string sM00NAME = e.Cell.Column.Header.Caption.ToString();

        //        SqlDBHelper helper = new SqlDBHelper(false);
        //        SqlParameter[] param = new SqlParameter[9];

        //        try
        //        {
        //            param[0] = helper.CreateParameter("@etc1", "", SqlDbType.VarChar, ParameterDirection.Input);
        //            param[1] = helper.CreateParameter("@etc2", "", SqlDbType.VarChar, ParameterDirection.Input);
        //            param[2] = helper.CreateParameter("@etc3", "", SqlDbType.VarChar, ParameterDirection.Input);
        //            param[3] = helper.CreateParameter("@plantcode", save_plantcode, SqlDbType.VarChar, ParameterDirection.Input);
        //            param[4] = helper.CreateParameter("@targetclass", "CL08", SqlDbType.VarChar, ParameterDirection.Input);
        //            param[5] = helper.CreateParameter("@Y00", save_Y00, SqlDbType.VarChar, ParameterDirection.Input);
        //            param[6] = helper.CreateParameter("@M00", sM00, SqlDbType.VarChar, ParameterDirection.Input);

        //            param[7] = helper.CreateParameter("RS_CODE", SqlDbType.VarChar, ParameterDirection.Output, null, 1);
        //            param[8] = helper.CreateParameter("RS_MSG", SqlDbType.VarChar, ParameterDirection.Output, null, 200);

        //            rtnDtTemp = SqlDBHelper.FillTable("USP_PM0400_S2", CommandType.StoredProcedure, param);

        //            if (rtnDtTemp.Rows.Count == 0)
        //            {
        //                rtnDtTemp.Rows.Add(new object[] { sM00NAME, sM00,"", "", "", "", "" });

        //            }

        //            //grid2.DataSource = rtnDtTemp;
        //           // grid2.DataBind();


        //        }

        //        catch (Exception ex)
        //        {
        //            helper.Transaction.Rollback();
        //            MessageBox.Show(ex.ToString());
        //        }
        //        finally
        //        {
        //            if (SqlDBHelper._sConn != null) { SqlDBHelper._sConn.Close(); }
        //            if (param != null) { param = null; }
        //            sChkCell = e.Cell.Column.Header.Column.ToString();
        //        }


        //    }


        //}

        #endregion
    }
}

