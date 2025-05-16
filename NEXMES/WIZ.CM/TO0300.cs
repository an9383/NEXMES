#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TO0300
//   Form Name    : TOOL 검증 DATA 관리
//   Name Space   : WIZ.CM.DLL
//   Created Date : 2012-12-18
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class TO0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public TO0300()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);


            //TBM0700 : 설비
            //   - 1 : MachCode, 2 : MachName, param[0] : MachType, param[1] : MachType1
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" });           //라인 팝업
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });                                          //공정 팝업
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });                                          //설비 팝업
            btbManager.PopUpAdd(txtToolCode, txtToolName, "TTO0100", new object[] { cboPlantCode_H, "", "", "" });                              //TOOl 팝업

            gridManager.PopUpAdd("MachCode", "Machname", "TBM0700", new string[] { "", "", "", "Y" });
            gridManager.PopUpAdd("ToolCode1", "ToolName1", "TTO0100_GetData", new string[] { "PlantCode", "", "", "", "N" }, new string[] { "ToolSeq1|Seq" });
            gridManager.PopUpAdd("ToolCode2", "ToolName2", "TTO0100_GetData", new string[] { "PlantCode", "", "", "", "N" }, new string[] { "ToolSeq2|Seq" });
        }
        #endregion

        #region 폼 초기화

        private void TO0300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            //사업장, 공정, 작업장, 설비코드, 상태, 시작시간, 종료시간, 시간, 작업자수, 생산수량, 수불일자
            _GridUtil.InitColumnUltraGrid(grid1, "plantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Seq", "시퀀스", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkDate", "교체일자", false, GridColDataType_emu.YearMonthDay, 100, 30, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Machname", "설비", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolCode1", "교체전 TOOL코드", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolName1", "교체전 TOOL명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolSeq1", "교체전 TOOL순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PreData1", "Data1", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PreData2", "Data2", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PreData3", "Data3", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolCode2", "교체후 TOOL코드", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolName2", "교체후 TOOL명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolSeq2", "교체후 TOOL순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PostData1", "Data1", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PostData2", "Data2", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PostData3", "Data3", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            string[] sMergeColumn2 = { "ToolCode1", "ToolName1", "ToolSeq1", "PreData1", "PreData2", "PreData3" };
            // string[] sMergeColumn3    = { "PreData1", "PreData2", "PreData3" };
            string[] sMergeColumn4 = { "ToolCode2", "ToolName2", "ToolSeq2", "PostData1", "PostData2", "PostData3" };
            string[] sHeadColumn =   {"plantCode" , "Seq","WorkDate","MachCode","Machname","ToolCode1", "ToolName1", "ToolSeq1","PreData1","PreData2","PreData3","ToolCode2",
                                             "ToolName2","ToolSeq2","PostData1","PostData2","PostData3","MakeDate","Maker","EditDate","Editor"};




            //그리드 머지

            _GridUtil.GridHeaderMerge(grid1, "G2", "교체전", sMergeColumn2, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G4", "교체후", sMergeColumn4, sHeadColumn);

            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 4);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 17, 20);

            grid1.Columns["G2"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.Columns["G4"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();          // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            //Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("dTable1", -1);

            //Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup1 = new Infragistics.Win.UltraWinGrid.UltraGridGroup("NewGroup0", 24791040);
            //Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();

            //ultraGridGroup1.Header.Appearance            = appearance29;
            //ultraGridGroup1.Header.Caption               = "라인";
            //ultraGridGroup1.Key                          = "NewGroup0";
            //ultraGridGroup1.RowLayoutGroupInfo.LabelSpan = 1;

            //appearance29.FontData.Name         = "맑은 고딕";
            //appearance29.FontData.SizeInPoints = 10F;
            //appearance29.TextHAlignAsString    = "Center";
            //this.grid1.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
        }

        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                   // 공장코드 
                string sOPCode = txtOPCode.Text.Trim();                                       // 품목                                                          
                string sOPName = txtOPName.Text.Trim();                                       // 검사항목                                                          
                string sWorkCenterCode = txtWorkCenterCode.Text;                              // 검사항목 
                string sWorkCenterName = txtWorkCenterName.Text;                              // 사용여부 
                string sMachCode = txtMachCode.Text;                                          // 설비코드
                string sMachName = txtMachName.Text;                                          // 설비 명
                string sToolCode = txtToolCode.Text;                                          // TOOL 코드
                string sToolName = txtToolName.Text;                                          // TOOL 명
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_date.Value);          // 시작 일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_dateto.Value);          // 종료 일자


                grid1.DataSource = helper.FillTable("USP_TO0300_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@OPNAME", sOPName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@WORKCONTERNAME", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@TOOLCODE", sToolCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@TOOLNAME", sToolName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@Seq1", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@Seq2", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("@Seq3", "", DbType.String, ParameterDirection.Input));


                string[] sMergeColumn2 = { "ToolCode1", "ToolName1", "ToolSeq1", "PreData1", "PreData2", "PreData3" };
                // string[] sMergeColumn3    = { "PreData1", "PreData2", "PreData3" };
                string[] sMergeColumn4 = { "ToolCode2", "ToolName2", "ToolSeq2", "PostData1", "PostData2", "PostData3" };
                string[] sHeadColumn =   {"plantCode" , "Seq","WorkDate","MachCode","Machname","ToolCode1", "ToolName1", "ToolSeq1","PreData1","PreData2","PreData3","ToolCode2",
                                             "ToolName2","ToolSeq2","PostData1","PostData2","PostData3","MakeDate","Maker","EditDate","Editor"};




                //그리드 머지

                _GridUtil.GridHeaderMerge(grid1, "G2", "교체전", sMergeColumn2, sHeadColumn);
                _GridUtil.GridHeaderMerge(grid1, "G4", "교체후", sMergeColumn4, sHeadColumn);

                _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 4);
                _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 17, 20);

                grid1.Columns["G2"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid1.Columns["G4"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //_GridUtil.GridHeaderMerge(grid1, "Group1", "교체전", new string[] { "ToolCode1", "ToolName1", "ToolSeq1", "PreData1", "PreData2", "PreData3" }
                //    , new string[] { "ToolCode1", "ToolName1", "ToolSeq1", "PreData1", "PreData2", "PreData3" });

                //_GridUtil.GridHeaderMerge(grid1, "Group2", "교체후", new string[] { "ToolCode2", "ToolName2", "ToolSeq2", "PostData1", "PostData2", "PostData3" }
                //    , new string[] { "ToolCode2", "ToolName2", "ToolSeq2", "PostData1", "PostData2", "PostData3" });

                //_GridUtil.GridHeaderMerge(grid1, "s", "", new string[] {  }
                //    , new string[] { "plantCode", "Seq", "WorkDate", "MachCode", "Machname", "MakeDate", "Maker", "EditDate", "Editor" });

                grid1.DataBinds();
                // _Common.Grid_Column_Width(this.grid1); //grid 정리용
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                //helper.Close();
                //if (param != null) { param = null; }
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                //int j = 0;
                //for (int i = 0; i < grid1.Rows.Count; i++)
                //{
                //    if (grid1.Rows[i].Cells["PlantCode"].Value.ToString() == "" || grid1.Rows[i].Cells["MachCode"].Value.ToString() == "" ||
                //        grid1.Rows[i].Cells["WorkDate"].Value.ToString() == "")
                //    {
                //        j = j + 1;
                //    }
                //    if (j == 1)
                //    {
                //        ShowDialog("C:I00006", Windows.Forms.DialogForm.DialogType.OK);

                //        CancelProcess = true;
                //        j = 0;
                //        return;
                //    }

                //}
                base.DoNew();
                int iRow = _GridUtil.AddRow(this.grid1);
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "WorkDate");
                UltraGridUtil.ActivationAllowEdit(grid1, "MachCode");
                UltraGridUtil.ActivationAllowEdit(grid1, "Machname");
                UltraGridUtil.ActivationAllowEdit(grid1, "ToolCode1");
                UltraGridUtil.ActivationAllowEdit(grid1, "ToolName1");
                UltraGridUtil.ActivationAllowEdit(grid1, "ToolSeq1");
                UltraGridUtil.ActivationAllowEdit(grid1, "PreData1");
                UltraGridUtil.ActivationAllowEdit(grid1, "PreData2");
                UltraGridUtil.ActivationAllowEdit(grid1, "PreData3");
                UltraGridUtil.ActivationAllowEdit(grid1, "ToolCode2");
                UltraGridUtil.ActivationAllowEdit(grid1, "ToolName2");
                UltraGridUtil.ActivationAllowEdit(grid1, "ToolSeq2");
                UltraGridUtil.ActivationAllowEdit(grid1, "PostData1");
                UltraGridUtil.ActivationAllowEdit(grid1, "PostData2");
                UltraGridUtil.ActivationAllowEdit(grid1, "PostData3");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sPlantCode = "";
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["plantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "지시번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_TO0300_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", Convert.ToInt64(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)          // 순번
                                                    , helper.CreateParameter("@MACHCODE", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)           // 일자
                                                    , helper.CreateParameter("@WORKDATE", Convert.ToString(drRow["WorkDate"]), DbType.String, ParameterDirection.Input)           // 툴코드 1
                                                    , helper.CreateParameter("@SEQ", Convert.ToString(drRow["Seq"]), DbType.Int64, ParameterDirection.Input)           // 툴순번 1
                                                    , helper.CreateParameter("@pRetCode", DbType.String, ParameterDirection.Output, null, 1)
                                                    , helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200));



                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_TO0300_I1", CommandType.StoredProcedure
                                                        , helper.CreateParameter("@PlantCde", Convert.ToString(drRow["plantCode"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@MachCode", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@WorkDate", Convert.ToString(drRow["WorkDate"]).Substring(0, 10), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@ToolCode1", Convert.ToString(drRow["ToolCode1"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@ToolSeq1", Convert.ToString(drRow["ToolSeq1"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@ToolCode2", Convert.ToString(drRow["ToolCode2"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@ToolSeq2", Convert.ToString(drRow["ToolSeq2"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@PreData1", Convert.ToString(drRow["PreData1"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@PreData2", Convert.ToString(drRow["PreData2"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@PreData3", Convert.ToString(drRow["PreData3"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@PostData1", Convert.ToString(drRow["PostData1"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@PostData2", Convert.ToString(drRow["PostData2"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@PostData3", Convert.ToString(drRow["PostData3"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_TO0300_U1", CommandType.StoredProcedure
                                                        , helper.CreateParameter("@PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)       // 사업장 수정
                                                        , helper.CreateParameter("@MachCode", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)       // 설비
                                                        , helper.CreateParameter("@WorkDate", Convert.ToString(drRow["WorkDate"]), DbType.String, ParameterDirection.Input)       // 일자
                                                        , helper.CreateParameter("@Seq", Convert.ToString(drRow["Seq"]), DbType.String, ParameterDirection.Input)       // 순번
                                                        , helper.CreateParameter("@ToolCode1", Convert.ToString(drRow["ToolCode1"]), DbType.String, ParameterDirection.Input)       // TOOL CODE1
                                                        , helper.CreateParameter("@ToolSeq1", Convert.ToString(drRow["ToolSeq1"]), DbType.String, ParameterDirection.Input)       // TOOL SEQ1
                                                        , helper.CreateParameter("@ToolCode2", Convert.ToString(drRow["ToolCode2"]), DbType.String, ParameterDirection.Input)       // TOOL CODE2
                                                        , helper.CreateParameter("@ToolSeq2", Convert.ToString(drRow["ToolSeq2"]), DbType.String, ParameterDirection.Input)       // TOOL SEQ2
                                                        , helper.CreateParameter("@PreData1", Convert.ToString(drRow["PreData1"]), DbType.String, ParameterDirection.Input)       // 변경전 데이터1
                                                        , helper.CreateParameter("@PreData2", Convert.ToString(drRow["PreData2"]), DbType.String, ParameterDirection.Input)       // 변경전 데이터2
                                                        , helper.CreateParameter("@PreData3", Convert.ToString(drRow["PreData3"]), DbType.String, ParameterDirection.Input)       // 변경전 데이터3
                                                        , helper.CreateParameter("@PostData1", Convert.ToString(drRow["PostData1"]), DbType.String, ParameterDirection.Input)       // 
                                                        , helper.CreateParameter("@PostData2", Convert.ToString(drRow["PostData2"]), DbType.String, ParameterDirection.Input)       // 
                                                        , helper.CreateParameter("@PostData3", Convert.ToString(drRow["PostData3"]), DbType.String, ParameterDirection.Input)       // 
                                                        , helper.CreateParameter("@Editor", this.WorkerID, DbType.String, ParameterDirection.Input));     // 



                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("plantCode");
                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

    }
}
