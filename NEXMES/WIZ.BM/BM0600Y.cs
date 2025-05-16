#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0600Y
//   Form Name    : 작업장 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-19
//   Made By      : WIZCORE
//   Description  : 작업장(Workcenter) 관리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0600Y : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();


        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private bool formLoad = false;

        //Control 셋팅을 위한 변수 선언
        private string sPlant = string.Empty;
        private string sOP = string.Empty;
        private string sLine = string.Empty;
        private string sWorkCenterCode = string.Empty;
        private string ChkGridCell = "수정불가"; // 추가 시에만 공장 , 공정 , 라인 , 작업장을 수정

        #endregion

        #region < CONSTRUCTOR >
        public BM0600Y()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager gridManager = new BizGridManager(grid1);

            this.plantCode = CModule.GetAppSetting("Site", "10");

            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600Y", new object[] { cboPlantCode_H, txtOpCode_H, cboLineCode_H, cboUseFlag_H });  //라인 POP_UP
            btbManager.PopUpAdd(txtOpCode_H, txtOpName_H, "TBM0400", new object[] { cboPlantCode_H, txtOpCode_H, txtOpName_H, cboUseFlag_H });

        }

        private void BM0600Y_Load(object sender, EventArgs e)
        {

            GridSetting(); // 그리드 셋팅
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ATSTFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ZBFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MOLDUSE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BanCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboBanCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BanCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboBanCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");





            //GetOPCode();
            GetLineCode();

            BizGridManager bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("LINECODE", "LINENAME", "TBM0500", new string[] { "PLANTCODE", "OPCODE", "" });

            cboPlantCode_H.Value = plantCode;
            formLoad = true;
            ChkGridCell = "수정불가";
        }
        #endregion

        private void GridSetting()
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 140, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정ⓒ", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인ⓒ", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장ⓒ", true, GridColDataType_emu.VarChar, 120, 6, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BANCODE", "작업반ⓒ", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ATSTFLAG", "작업지시할당여부", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STDMANCNT", "기준인원", true, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, true, "#,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DOWNTIMECOST", "비가동 금액", true, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, true, "#,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ZBID", "지그비ID", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ZBFLAG", "지그비사용유무ⓒ", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDUSE", "금형사용유무ⓒ", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부ⓒ", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["LINECODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["OPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            DataTable rtnDtTemp = _Common.GET_BM0040_CODE("");  //공정
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }
        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sWorkcentercode = txtWorkCenterCode_H.Text.Trim();
                string sWorkcentername = txtWorkCenterName_H.Text.Trim();
                string sOpCode = txtOpCode_H.Text.Trim();
                string sBanCode = DBHelper.nvlString(this.cboBanCode_H.Value);
                string sZBID = txtZBID_H.Text.Trim();
                string sLineCode = DBHelper.nvlString(this.cboLineCode_H.Value);

                base.DoInquire();
                grid1.DataSource = helper.FillTable("USP_BM0600Y_S1", CommandType.StoredProcedure
                                 , helper.CreateParameter("FLAG", "S", DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)   //공장
                                 , helper.CreateParameter("WORKCENTERCODE", sWorkcentercode, DbType.String, ParameterDirection.Input)   //라인
                                 , helper.CreateParameter("WORKCENTERNAME", sWorkcentername, DbType.String, ParameterDirection.Input)   //라인명
                                 , helper.CreateParameter("OPCODE", sOpCode, DbType.String, ParameterDirection.Input)   //공정
                                 , helper.CreateParameter("LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("BANCODE", sBanCode, DbType.String, ParameterDirection.Input)   //작업반
                                 , helper.CreateParameter("ZBID", sZBID, DbType.String, ParameterDirection.Input)   //지그비 아이디
                                 , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;


                grid1.DisplayLayout.Bands[0].Columns["LINECODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["LINECODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;


                grid1.DisplayLayout.Bands[0].Columns["OPCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["OPCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["LINECODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["OPCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["BANCODE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ATSTFLAG"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["STDMANCNT"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["DOWNTIMECOST"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ZBID"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["ZBFLAG"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["MOLDUSE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["USEFLAG"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellAppearance.BackColor = Color.White;
                grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellAppearance.BackColor = Color.White;
                ChkGridCell = "수정불가";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }

        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();
                this.grid1.InsertRow();

                grid1.ActiveRow.Cells["LINECODE"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.Disabled;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.Disabled;

                if (grid1.Rows.Count > 1)
                {
                    //추가 시 grid에 데이터가 있을 경우 선택된 행의 -1의 데이터 기준으로 추가
                    int iRows = grid1.ActiveRow.Index;

                    grid1.SetDefaultValue("PLANTCODE", grid1.Rows[iRows - 1].Cells["PLANTCODE"].Value.ToString());
                    grid1.SetDefaultValue("OPCODE", grid1.Rows[iRows - 1].Cells["OPCODE"].Value.ToString());
                    grid1.SetDefaultValue("LINECODE", grid1.Rows[iRows - 1].Cells["LINECODE"].Value.ToString());
                    grid1.SetDefaultValue("USEFLAG", "Y");
                    grid1.SetDefaultValue("ATSTFLAG", "N");
                    grid1.SetDefaultValue("ZBFLAG", "N");
                    grid1.SetDefaultValue("MOLDUSE", "N");

                }
                else
                {
                    grid1.SetDefaultValue("PLANTCODE", this.plantCode);
                    grid1.SetDefaultValue("USEFLAG", "Y");
                    grid1.SetDefaultValue("ATSTFLAG", "N");
                    grid1.SetDefaultValue("ZBFLAG", "N");
                    grid1.SetDefaultValue("MOLDUSE", "N");
                }

                grid1.UpdateData();

                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                ChkGridCell = "수정가능";
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
        }

        public void GET_CODE(string flag, string plantcode, string opcode, string linecode, ref string workcentercode)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable _TmpDt = helper.FillTable("USP_BM0600Y_S1", CommandType.StoredProcedure
                                 , helper.CreateParameter("FLAG", flag, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("PLANTCODE", plantcode, DbType.String, ParameterDirection.Input)   //공장
                                 , helper.CreateParameter("WORKCENTERCODE", "", DbType.String, ParameterDirection.Input)   //라인
                                 , helper.CreateParameter("WORKCENTERNAME", "", DbType.String, ParameterDirection.Input)   //라인명
                                 , helper.CreateParameter("OPCODE", opcode, DbType.String, ParameterDirection.Input)   //공정
                                 , helper.CreateParameter("LINECODE", linecode, DbType.String, ParameterDirection.Input)   //공정
                                 , helper.CreateParameter("BANCODE", "", DbType.String, ParameterDirection.Input)   //작업반
                                 , helper.CreateParameter("ZBID", "", DbType.String, ParameterDirection.Input)   //지그비 아이디
                                 , helper.CreateParameter("USEFLAG", "", DbType.String, ParameterDirection.Input));

                if (_TmpDt.Rows.Count > 0)
                {
                    //grid1.SetDefaultValue("WORKCENTERCODE", Convert.ToString(_TmpDt.Rows[0]["MAXSTOPCODE"]));
                    workcentercode = Convert.ToString(_TmpDt.Rows[0]["MAXSTOPCODE"]);
                }

                _TmpDt.Dispose();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
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

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }


                int li_cnt = 0;

                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "" || drRow["OPCODE"].ToString().Trim() == "" || drRow["LINECODE"].ToString().Trim() == "")
                        {
                            this.ShowDialog(Common.getLangText("사업장, 공정, 라인은 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            li_cnt = 1;
                            return;
                        }

                        if (drRow["WORKCENTERNAME"].ToString().Length > 80)
                        {
                            grid1.SetRowError(drRow, "작업장명은 최대 80자리까지 입력가능합니다.");
                            this.ShowDialog(Common.getLangText("작업장명은 최대 80자리까지 입력가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            li_cnt = 1;
                            return;
                        }
                        if (drRow["ZBID"].ToString().Length > 4)
                        {
                            this.ShowDialog(Common.getLangText("지그비ID는 최대 4자리까지 입력가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            li_cnt = 1;
                            return;
                        }
                    }

                    base.DoSave();
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM0600Y_D1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input) // 공장코드
                          , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input));
                            // , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                            // , helper.CreateParameter("LINECODE", Convert.ToString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input));         // 품목

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM0600Y_I1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("WORKCENTERNAME", Convert.ToString(drRow["WORKCENTERNAME"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("BANCODE", Convert.ToString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("ATSTFLAG", Convert.ToString(drRow["ATSTFLAG"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("STDMANCNT", Convert.ToString(drRow["STDMANCNT"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("DOWNTIMECOST", Convert.ToString(drRow["DOWNTIMECOST"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("ZBID", Convert.ToString(drRow["ZBID"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("ZBFLAG", Convert.ToString(drRow["ZBFLAG"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("MOLDUSE", Convert.ToString(drRow["MOLDUSE"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            sPlantCode = Convert.ToString(drRow["PlantCode"]);

                            helper.ExecuteNoneQuery("USP_BM0600Y_U1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("WORKCENTERNAME", Convert.ToString(drRow["WORKCENTERNAME"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("OPCODE", Convert.ToString(drRow["OPCode"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("BANCODE", Convert.ToString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("ATSTFLAG", Convert.ToString(drRow["ATSTFLAG"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("STDMANCNT", Convert.ToString(drRow["STDMANCNT"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("DOWNTIMECOST", Convert.ToString(drRow["DOWNTIMECOST"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("ZBID", Convert.ToString(drRow["ZBID"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("ZBFLAG", Convert.ToString(drRow["ZBFLAG"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("MOLDUSE", Convert.ToString(drRow["MOLDUSE"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                    if (helper.RSCODE == "E") { li_cnt = 1; }
                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();
                if (li_cnt == 0) { DoInquire(); }
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

        #region < EVENT AREA >

        #endregion

        /// 공정 조회
        /// </summary>
        private void GetOPCode()
        {
            //DBHelper helper = new DBHelper(false);

            //try
            //{
            //    string sPlantCode = Convert.ToString(cboPlantCode_H.Value);

            //    StringBuilder command = new StringBuilder();

            //    command.AppendLine("SELECT OPCODE                             AS CODE_ID, ";
            //    command.AppendLine("       '['+ OPCODE +']' + OPNAME          AS CODE_NAME";
            //    command.AppendLine("  FROM TBM0400                                        ";
            //    command.AppendLine(" WHERE PLANTCODE LIKE '" + sPlantCode + "' + '%'      ";
            //    command.AppendLine("   AND USEFLAG = 'Y'                                  ";
            //    command.AppendLine(" ORDER BY OPCODE";

            //    DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
            //    WIZ.Common.FillComboboxMaster(cboOpCode_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //    if (formLoad == false)
            //    {
            //        WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OPCode", dttemp, "CODE_ID", "CODE_NAME");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }

        /// <summary>
        /// 라인 조회
        /// </summary>
        private void GetLineCode()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sOPCode = txtOpCode_H.Text;
                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT LINECODE                             AS CODE_ID, ");
                command.AppendLine("       '['+ LINECODE +']' + LINENAME        AS CODE_NAME");
                command.AppendLine("  FROM TBM0500                                          ");
                command.AppendLine(" WHERE PLANTCODE LIKE '" + sPlantCode + "' + '%'        ");
                command.AppendLine("   AND OPCODE    LIKE '" + sOPCode + "' + '%'        ");
                command.AppendLine("   AND USEFLAG = 'Y'                                    ");
                command.AppendLine(" ORDER BY LINECODE");


                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(cboLineCode_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                if (formLoad == false)
                {
                    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LINECODE", dttemp, "CODE_ID", "CODE_NAME");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void cboPlantCode_H_ValueChanged(object sender, EventArgs e)
        {
            //GetOPCode();
        }

        private void cboOpCode_H_ValueChanged(object sender, EventArgs e)
        {
            //GetLineCode();
            //txtWorkCenterCode_H.Text = string.Empty;
            //txtWorkCenterName_H.Text = string.Empty;
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //try
            //{
            //    if (this.grid1.Rows.Count == 0) return;

            //    if (e.Cell.Column.ToString() != "LINECODE") return;

            //    int iRows = grid1.ActiveRow.Index;
            //    string workcentercode = string.Empty;
            //    string plantcode = string.Empty;
            //    string opcode = string.Empty;
            //    string linecode = string.Empty;

            //    if (iRows == 0)
            //    {
            //        //그리드 row가 첫번쨰 일 경우..
            //        plantcode = grid1.Rows[iRows].Cells["plantcode"].Value.ToString();
            //        opcode = grid1.Rows[iRows].Cells["OPCODE"].Value.ToString();
            //        linecode = grid1.Rows[iRows].Cells["LINECODE"].Value.ToString();

            //        if (plantcode.Length != 4) return;
            //        if (opcode.Length != 3) return;
            //        if (linecode.Length != 4) return;

            //        GET_CODE("C", plantcode, opcode, linecode, ref workcentercode);
            //        grid1.SetDefaultValue("WORKCENTERCODE", workcentercode);
            //        return;
            //    }
            //    else
            //    {
            //        int li_cnt = 0;

            //        plantcode = grid1.Rows[iRows].Cells["plantcode"].Value.ToString();
            //        opcode = grid1.Rows[iRows].Cells["OPCODE"].Value.ToString();
            //        linecode = grid1.Rows[iRows].Cells["LINECODE"].Value.ToString();

            //        if (plantcode.Length != 4) return;
            //        if (opcode.Length != 3) return;
            //        if (linecode.Length != 4) return;

            //        for (int i = 0; i < grid1.Rows.Count; i++)
            //        {
            //            if (linecode == Convert.ToString(grid1.Rows[i].Cells["LINECODE"].Value))
            //            {
            //                li_cnt++;
            //            }
            //        }

            //        GET_CODE("C", plantcode, opcode, linecode, ref workcentercode);

            //        if (workcentercode.Length > 0)
            //        {
            //            if (li_cnt >= Convert.ToInt32(workcentercode.Replace(linecode, "")))
            //            {
            //                string lsCnt = li_cnt.ToString();
            //                string getWorkCenterCode = string.Empty;

            //                if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

            //                getWorkCenterCode = linecode + lsCnt;

            //                for (int i = 0; i < grid1.Rows.Count; i++)
            //                {
            //                    if(getWorkCenterCode == Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value))
            //                    {
            //                        //같은게 잇다..
            //                        int liCnt = 0;
            //                        liCnt = Convert.ToInt32(lsCnt) + 1;
            //                        lsCnt = liCnt.ToString();
            //                        if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }

            //                        getWorkCenterCode = linecode + lsCnt;

            //                    }
            //                }


            //                grid1.SetDefaultValue("WORKCENTERCODE", getWorkCenterCode);
            //            }
            //            else if (li_cnt < Convert.ToInt32(workcentercode.Replace(linecode, "")))
            //            {
            //                if (Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["WORKCENTERCODE"].Value).Replace(linecode, "")) < Convert.ToInt32(workcentercode.Replace(linecode, "")))
            //                {
            //                    grid1.SetDefaultValue("WORKCENTERCODE", workcentercode);
            //                }
            //                else
            //                {
            //                    string lsCnt = Convert.ToString(Convert.ToInt32(Convert.ToString(grid1.Rows[iRows - 1].Cells["WORKCENTERCODE"].Value).Replace(linecode, "")) + 1);
            //                    if (lsCnt.Trim().Length == 1) { lsCnt = "0" + lsCnt; }
            //                    grid1.SetDefaultValue("WORKCENTERCODE", linecode + lsCnt);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}

        }

        private void grid1_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString() == "PLANTCODE")
                {
                    e.Cell.Row.Cells["OPCODE"].Value = string.Empty;
                    e.Cell.Row.Cells["LINECODE"].Value = string.Empty;
                    e.Cell.Row.Cells["WORKCENTERCODE"].Value = string.Empty;
                }
                else if (e.Cell.Column.ToString() == "OPCODE")
                {
                    e.Cell.Row.Cells["LINECODE"].Value = string.Empty;
                    e.Cell.Row.Cells["WORKCENTERCODE"].Value = string.Empty;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void txtWorkCenterName_H_ValueChanged(object sender, EventArgs e)
        {
            //if (txtWorkCenterCode_H.Text.Length != 6)
            //{
            //    txtWorkCenterCode_H.Text = string.Empty;
            //    txtWorkCenterName_H.Text = string.Empty;
            //}
        }

        private void txtWorkCenterCode_H_ValueChanged(object sender, EventArgs e)
        {
            //if (txtWorkCenterCode_H.Text.Length == 6)
            //{
            //    sPlant = txtWorkCenterCode_H.Text.Substring(0, 2) + "00";
            //    sOP    = txtWorkCenterCode_H.Text.Substring(0, 3);
            //    sLine  = txtWorkCenterCode_H.Text.Substring(0, 4);
            //    sWorkCenterCode = txtWorkCenterCode_H.Text;

            //    cboPlantCode_H.Value = sPlant;
            //    cboOpCode_H.Value = sOP;
            //    cboLineCode_H.Value = sLine;
            //    txtWorkCenterCode_H.Text = sWorkCenterCode;

            //}
        }

        private void cboLineCode_H_ValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToString(cboLineCode_H.Value).Length == 4 && Convert.ToString(cboLineCode_H.Value).ToUpper() != "ALL")
            //{

            //    sPlant = Convert.ToString(cboLineCode_H.Value).Substring(0, 2) + "00";
            //    sOP    = Convert.ToString(cboLineCode_H.Value).Substring(0, 3);
            //    sLine  = Convert.ToString(cboLineCode_H.Value);

            //    cboPlantCode_H.Value = sPlant;
            //    cboOpCode_H.Value    = sOP;
            //    cboLineCode_H.Value  = sLine;
            //    txtWorkCenterCode_H.Text = string.Empty;
            //    txtWorkCenterName_H.Text = string.Empty;
            //}

        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;
            if (ChkGridCell != "수정가능")
            {
                if (e.Cell.Column.Key == "PLANTCODE" ||
                    e.Cell.Column.Key == "OPCODE" ||
                    e.Cell.Column.Key == "LINECODE" ||
                    e.Cell.Column.Key == "LINENAME" ||
                    e.Cell.Column.Key == "WORKCENTERCODE")
                {
                    this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Activated = true;
                }
            }
            else
            {
                DataTable dt = grid1.chkChange();
                if (dt == null)
                {
                    this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Activated = true;
                    return;
                }
                //this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
                int CheckRow = 0;
                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Added:
                            if (this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString() != Convert.ToString(drRow["PLANTCODE"]) ||
                                this.grid1.ActiveRow.Cells["OPCODE"].Value.ToString() != Convert.ToString(drRow["OPCODE"]) ||
                                this.grid1.ActiveRow.Cells["LINECODE"].Value.ToString() != Convert.ToString(drRow["LINECODE"]) ||
                                this.grid1.ActiveRow.Cells["LINENAME"].Value.ToString() != Convert.ToString(drRow["LINENAME"]) ||
                                this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString() != Convert.ToString(drRow["WORKCENTERCODE"]))
                            {
                                CheckRow = CheckRow + 1;

                            }
                            break;
                    }
                }
                if (dt.Rows.Count == CheckRow)
                {
                    this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Activated = true;
                }
            }
        }

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                DataTable dt = grid1.chkChange();
                if (dt == null)
                {
                    this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Activated = true;
                    return;
                }
                //this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);
                int CheckRow = 0;
                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Added:
                            if (this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString() != Convert.ToString(drRow["PLANTCODE"]) ||
                                this.grid1.ActiveRow.Cells["OPCODE"].Value.ToString() != Convert.ToString(drRow["OPCODE"]) ||
                                this.grid1.ActiveRow.Cells["LINECODE"].Value.ToString() != Convert.ToString(drRow["LINECODE"]) ||
                                this.grid1.ActiveRow.Cells["LINENAME"].Value.ToString() != Convert.ToString(drRow["LINENAME"]) ||
                                this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString() != Convert.ToString(drRow["WORKCENTERCODE"]))
                            {
                                CheckRow = CheckRow + 1;

                            }
                            break;
                    }
                }
                if (dt.Rows.Count == CheckRow)
                {
                    this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Activated = true;
                }
            }
            catch
            {
            }
        }
    }
}