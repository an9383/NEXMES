

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.PM
{
    public partial class PM0110 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>


        #endregion

        #region<CONSTRUCTOR>
        public PM0110()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        /// 

        #region<METHOD AREA>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[8];
            string sThisdate = CboStartdate_H.Value.ToString().Substring(0, 4) + CboStartdate_H.Value.ToString().Substring(5, 2); ;

            string sPlantCode = cboPlantCode_H.Value.ToString();
            string sTARGETCLASS = cboTagetClass.Value.ToString();

            try
            {
                base.DoInquire();

                param[0] = helper.CreateParameter("@etc1", "", DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@etc2", "", DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@etc3", "", DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@TARGETCLASS", sTARGETCLASS, DbType.String, ParameterDirection.Input);
                param[5] = helper.CreateParameter("@Thisdate", sThisdate, DbType.String, ParameterDirection.Input);

                param[6] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                param[7] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);


                grid1.DataSource = helper.FillTable("USP_PM0110_S1", CommandType.StoredProcedure, param);

                if (param[6].Value.ToString() == "E") throw new Exception(param[7].Value.ToString());

                grid1.DataBinds();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }
        }
        #endregion

        #region 폼 로더
        private void PM0110_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "targetclass", "주요항목", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "lastmon", "전월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false, "###,###,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "thismon", "금월", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false, "###,###,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "dismon", "차이", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Center, true, false, "###,###,##0.00", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "disvar", "증감", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "problemremark", "원인", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "analyremark", "원인분석", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "measureremark", "개선대책", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "deptremark", "담당", false, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "resultremark", "조치결과", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            string[] sMergeColumn = { "targetclass" };
            string[] sMergeColumn2 = { "lastmon", "thismon", "dismon", "disvar" };
            string[] sMergeColumn3 = { "problemremark", "analyremark", "measureremark", "deptremark", "resultremark" };
            string[] sHeadColumn = { "targetclass", "lastmon", "thismon", "dismon", "disvar", "problemremark", "analyremark", "measureremark", "deptremark", "resultremark" };

            _GridUtil.SetInitUltraGridBind(grid1);

            //AUTO 사이즈
            grid1.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;

            //그리드 멀티 라인
            grid1.DisplayLayout.Bands[0].Columns["problemremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Bands[0].Columns["analyremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Bands[0].Columns["measureremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Bands[0].Columns["deptremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Bands[0].Columns["resultremark"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;

            //그리드 라인 색깔 해제
            //grid1.UseAppStyling = false;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            //그리드 머지
            //_GridUtil.GridHeaderMerge(grid1, "G1", "", sMergeColumn, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "성과지표", sMergeColumn2, sHeadColumn);
            //_GridUtil.GridHeaderMerge(grid1, "G3", "", sMergeColumn3, sHeadColumn);

            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 0);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 5, 9);

            grid1.Columns["G2"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;


            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TARGETCLASS");
            WIZ.Common.FillComboboxMaster(this.cboTagetClass, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "targetclass", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region Grid MERGE
            grid1.Columns["targetclass"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["targetclass"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["targetclass"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE
        }
        #endregion
    }
}