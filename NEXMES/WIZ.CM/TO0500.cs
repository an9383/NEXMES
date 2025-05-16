#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TO0500
//   Form Name    : TOOL LIFE 현황
//   Name Space   : WIZ.CM.DLL
//   Created Date : 2012-12-14
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion


namespace WIZ.CM
{
    public partial class TO0500 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        #endregion

        #region < CONSTRUCTOR >
        public TO0500()
        {
            InitializeComponent();
        }
        #endregion

        #region < TO500_Load >
        private void TO0500_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "plantcode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "toolcode", "TOOL 코드", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolName", "TOOL 명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "seq", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Shelflife", "수명", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "prodqty", "사용량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RATE", "사용률(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "YesNo", "장착여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "machcode", "설비코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "machname", "설비명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            int iColCount = grid1.Columns.Count;

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            grid1.Columns["plantcode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["plantcode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["plantcode"].MergedCellStyle = MergedCellStyle.Always;

            //3자리수 , 표시
            grid1.Columns["prodqty"].Format = "#,###";   //사용량
            grid1.Columns["Shelflife"].Format = "#,###"; //수명
            #endregion

            #region --- ComboBox Setting ---
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");
            WIZ.Common.FillComboboxMaster(this.cboChange, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");    //사용여부
            WIZ.Common.FillComboboxMaster(this.cboEquip, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "YesNo", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region --- POP-Up Setting ---
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // TBM0400 : 공정(작업장) 
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

            //TTO0100 : Tool 마스터
            btbManager.PopUpAdd(txtToolCode, txtToolName, "TTO0100", new object[] { cboPlantCode_H, "", "", "" });

            //TBM0600 : 작업장
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, txtWorkCenterCode, "" });

            //TBM0700 : 설비
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });
            #endregion
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

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value) == "ALL" ? "" : Convert.ToString(cboPlantCode_H.Value);
                string sUseFlag = Convert.ToString(cboEquip.Value) == "ALL" ? "" : Convert.ToString(cboEquip.Value);
                string sOPCode = txtOPCode.Text.Trim();
                string sOPName = txtOPName.Text.Trim();
                string sToolCode = txtToolCode.Text.Trim();
                string sMachCode = txtMachCode.Text.Trim();
                string sMachName = txtMachName.Text.Trim();
                string sToolName = txtToolName.Text.Trim();
                string sWorkCenterCode = txtWorkCenterCode.Text.Trim();
                string sWorkCenterName = txtWorkCenterName.Text.Trim();
                string sType = DBHelper.gGetCode(cboChange.Value);

                grid1.DataSource = helper.FillTable("USP_TO0500_S1_T", CommandType.StoredProcedure
                                                                     , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("OPNAME", sOPName, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("WOKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("WOKCENTERNAME", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("TOOLCODE", sToolCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("TOOLNAME", sToolName, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("USAGE", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("PARAM1", sType, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("PARAM2", sMachCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("PARAM3", sMachName, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                //사용률에 따른 색 표시 노랑 - 90% 이하 , 빨강 - 90% 이상
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    string sRate = DBHelper.nvlString(grid1.Rows[i].Cells["RATE"].Value);

                    sRate = sRate.Replace("%", "");

                    double dRate = DBHelper.nvlDouble(sRate);

                    if (dRate >= 90)
                    {
                        grid1.Rows[i].Cells["RATE"].Appearance.BackColor = Color.Red;
                    }
                    else if (dRate >= 50)
                    {
                        grid1.Rows[i].Cells["RATE"].Appearance.BackColor = Color.Yellow;
                    }
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

        #region < METHOD AREA >
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "prodqty" });
        }
        #endregion
    }
}
