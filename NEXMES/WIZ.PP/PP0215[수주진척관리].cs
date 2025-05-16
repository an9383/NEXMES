#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0215
//   Form Name    : 공정BOM 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-05
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : BOM 관련 기준정보 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0215 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;
        DataTable rtnDtTemp = new DataTable();// return DataTable 공통
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성


        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public PP0215()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0215_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "수주SEQ", false, GridColDataType_emu.VarChar, 100, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTDATE", "수주일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주량", false, GridColDataType_emu.VarChar, 80, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "마감일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, true, true);

                _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "CUSTCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "CUSTNAME", Infragistics.Win.HAlign.Left);

                _GridUtil.SetInitUltraGridBind(grid1);

                //grid2
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERDATE", "작업지시일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE2", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERQTY", "지시편성수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "작업수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMEID", "프레임ID", false, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKID", "마스크ID", false, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ROW_STATUS", "상태", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);

                grid2.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid2);

                //그리드 객체 생성
                _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "OPINFO", "공정정보", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKCENTERINFO", "작업장정보", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANNO", "생산계획", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMINFO", "품목정보", false, GridColDataType_emu.VarChar, 240, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKSTATDATE", "생산시작", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "WORKENDDATE", "생산종료", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "PRODDATE", "생산일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);


                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                //grid2.DisplayLayout.Bands[0].Columns["OPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["OPSEQ"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["LASTFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["USEFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;

                //grid3.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid3.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor  = Color.SkyBlue;
                //grid3.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid3.DisplayLayout.Bands[0].Columns["BASEQTY"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid3.DisplayLayout.Bands[0].Columns["COMPONENT"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid3.DisplayLayout.Bands[0].Columns["COMPONENTNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid3.DisplayLayout.Bands[0].Columns["COMPONENTQTY"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                //WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("YESNO"); //사용여부
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LASTFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("SEQ"); //사용여부
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "OPSEQ", rtnDtTemp, "CODE_ID", "CODE_ID");

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


                rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "COMPONENTUNIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

                BizGridManager bizGridManager = null;

                bizGridManager = new BizGridManager(grid2);
                bizGridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });

                //bizGridManager = new BizGridManager(grid3);
                //bizGridManager.PopUpAdd("COMPONENT", "COMPONENTNAME", "BM0010", new string[] { "PLANTCODE", "4" , "Y"});

                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid3); // 조회전 그리드 초기화

            bNew = false;

            DBHelper helper = new DBHelper(false);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            try
            {
                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                //string sCloseFlag = CModule.ToString(cbo_CLOSEFLAG_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sitemName = txt_ITEMNAME_H.Text.Trim();

                base.DoInquire();


                dtGrid = helper.FillTable("USP_PP0215_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       //, helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                       //, helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       //, helper.CreateParameter("AS_ITEMNAME", sitemName, DbType.String, ParameterDirection.Input)
                       //, helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       //, helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       //, helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input)
                       );

                if (dtGrid.Rows.Count > 0)
                {
                    grid1.DataSource = dtGrid;
                    grid1.DataBinds(dtGrid);
                }


            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
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

                if (grid2.IsActivate)
                {
                    if (grid1.ActiveRow == null)
                    {
                        this.ShowDialog(Common.getLangText("품목을 선택해주세요", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    this.grid2.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid2.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";

                    //사용자 입력 필요한 부분 기본 세팅
                    grid2.ActiveRow.Cells["OPCODE"].Activation = Activation.AllowEdit;
                    grid2.ActiveRow.Cells["OPSEQ"].Activation = Activation.AllowEdit;


                    //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                    grid2.ActiveRow.Cells["OPNAME"].Activation = Activation.NoEdit;

                }

                else if (grid3.IsActivate)
                {
                    if (grid2.ActiveRow == null)
                    {
                        this.ShowDialog(Common.getLangText("공정을 선택해주세요", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    this.grid3.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid3.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid3.ActiveRow.Cells["USEFLAG"].Value = "Y";
                    grid3.ActiveRow.Cells["ITEMCODE"].Value = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();

                    //사용자 입력 필요한 부분 기본 세팅
                    grid3.ActiveRow.Cells["COMPONENT"].Activation = Activation.AllowEdit;

                    //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                    grid3.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                    //grid3.ActiveRow.Cells["COMPONENTUNIT"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                    grid3.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            DataRow dr = null;

            if (grid2.IsActivate)
            {
                dr = (grid2.ActiveRow.ListObject as DataRowView).Row;

                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Detached)
                {
                    grid2.ActiveRow.Delete();
                }

                else
                {
                    grid2.ActiveRow.Delete();
                    //this.ShowDialog(Common.getLangText("신규 작성 이외에는 삭제할 수 없습니다", "MSG"), Forms.DialogForm.DialogType.OK);
                }

            }

            else if (grid3.IsActivate)
            {
                dr = (grid3.ActiveRow.ListObject as DataRowView).Row;

                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Detached)
                {
                    grid3.ActiveRow.Delete();
                }

                else
                {
                    grid3.ActiveRow.Delete();
                    //this.ShowDialog(Common.getLangText("신규 작성 이외에는 삭제할 수 없습니다", "MSG"), Forms.DialogForm.DialogType.OK);
                }
            }

            //this.grid3.DeleteRow(); //BM은 삭제기능 비활성화
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DateTime dtNow = DateTime.Now;
            DBHelper helper = new DBHelper("", true);
            string sOPCODE = string.Empty;
            string sSEQ = string.Empty;
            string sITEMCODE = string.Empty;

            DataTable rtnDtTemp2 = new DataTable();

            rtnDtTemp = grid2.chkChange();
            rtnDtTemp2 = grid3.chkChange();

            sITEMCODE = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();

            try
            {
                if (rtnDtTemp != null || rtnDtTemp2 != null)
                {
                    if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        CancelProcess = true;
                        return;
                    }
                }

                base.DoSave();

                if (rtnDtTemp != null)
                {

                    foreach (DataRow drRow in rtnDtTemp.Rows)
                    {
                        //필수입력항목이 입력되었는지 확인
                        if (drRow.RowState != DataRowState.Deleted)
                        {
                            #region [ validation 체크 ]
                            if (Convert.ToString(drRow["OPCODE"]) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("품목은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (Convert.ToString(drRow["OPSEQ"]) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("생산수량은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (Convert.ToString(drRow["USEFLAG"]) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("하위품목은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            #endregion
                        }
                        switch (drRow.RowState)
                        {
                            case DataRowState.Deleted:
                                #region 삭제 < BM은 삭제기능 비 활성화 >

                                #endregion
                                break;
                            case DataRowState.Added:
                                #region 추가                            
                                helper.ExecuteNoneQuery("USP_PP0215_I1"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_OPSEQ", DBHelper.nvlString(drRow["OPSEQ"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_LASTFLAG", DBHelper.nvlString(drRow["LASTFLAG"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                                #endregion
                                break;
                            case DataRowState.Modified:
                                #region 수정
                                helper.ExecuteNoneQuery("USP_PP0215_U1"
                                                         , CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_OPSEQ", DBHelper.nvlString(drRow["OPSEQ"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_LASTFLAG", DBHelper.nvlString(drRow["LASTFLAG"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                                #endregion
                                break;
                        }
                    }
                    if (helper.RSCODE == "S")
                    {
                        this.ClosePrgFormNew();
                        grid2.SetAcceptChanges();
                        helper.Commit();
                    }
                    else if (helper.RSCODE == "E")
                    {
                        this.ClosePrgFormNew();
                        helper.Rollback();
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }

                sOPCODE = grid2.ActiveRow.Cells["OPCODE"].Value.ToString();
                sSEQ = grid2.ActiveRow.Cells["OPSEQ"].Value.ToString();

                if (rtnDtTemp2 != null)
                {
                    foreach (DataRow drRow in rtnDtTemp2.Rows)
                    {
                        //필수입력항목이 입력되었는지 확인
                        if (drRow.RowState != DataRowState.Deleted)
                        {
                            if (Convert.ToString(drRow["ITEMCODE"]) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("품목은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (Convert.ToString(drRow["BASEQTY"]) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("생산수량은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (Convert.ToString(drRow["COMPONENT"]) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("하위품목은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (Convert.ToString(drRow["COMPONENTQTY"]) == string.Empty)
                            {
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("하위품목수량은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            #endregion
                        }
                        switch (drRow.RowState)
                        {
                            case DataRowState.Deleted:
                                #region 삭제 < BM은 삭제기능 비 활성화 >

                                #endregion
                                break;
                            case DataRowState.Added:
                                #region 추가                            
                                helper.ExecuteNoneQuery("USP_PP0215_I2"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_OPCODE", sOPCODE, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_OPSEQ", sSEQ, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_COMPONENT", DBHelper.nvlString(drRow["COMPONENT"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AF_BASEQTY", DBHelper.nvlString(drRow["BASEQTY"]), DbType.Double, ParameterDirection.Input)
                                                        , helper.CreateParameter("AF_COMPONENTQTY", DBHelper.nvlString(drRow["COMPONENTQTY"]), DbType.Double, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_COMPONENTUNIT", DBHelper.nvlString(drRow["COMPONENTUNIT"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                                #endregion
                                break;
                            case DataRowState.Modified:
                                #region 수정
                                helper.ExecuteNoneQuery("USP_PP0215_U2"
                                                         , CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_OPCODE", sOPCODE, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_COMPONENT", DBHelper.nvlString(drRow["COMPONENT"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AF_BASEQTY", DBHelper.nvlString(drRow["BASEQTY"]), DbType.Double, ParameterDirection.Input)
                                                         , helper.CreateParameter("AF_COMPONENTQTY", DBHelper.nvlString(drRow["COMPONENTQTY"]), DbType.Double, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_COMPONENTUNIT", DBHelper.nvlString(drRow["COMPONENTUNIT"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                                #endregion
                                break;
                        }
                    }
                    if (helper.RSCODE == "S")
                    {
                        this.ClosePrgFormNew();
                        grid3.SetAcceptChanges();
                        helper.Commit();
                    }
                    else if (helper.RSCODE == "E")
                    {
                        this.ClosePrgFormNew();
                        helper.Rollback();
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {
            base.DoImportExcel();

            BM0120_EXCEL BM0120_excel = new BM0120_EXCEL();
            BM0120_excel.ShowDialog();

            base.DoInquire();
        }

        #region < EVENT AREA >


        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;

            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid2);

            if (grid1.Rows.Count <= 0)
                return;

            try
            {
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sContractNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value).Trim();

                if (sPlantCode == string.Empty || sContractNo == string.Empty)
                    return;

                dtGrid2 = helper.FillTable("USP_PP0215_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", grid1.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CONTRACTNO", grid1.ActiveRow.Cells["CONTRACTNO"].Value, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", grid1.ActiveRow.Cells["ITEMCODE"].Value, DbType.String, ParameterDirection.Input)
                       );

                grid2.DataSource = dtGrid2;
                grid2.DataBinds(dtGrid2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);

            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;

            DBHelper helper = new DBHelper(false);

            if (grid2.Rows.Count <= 0)
                return;

            try
            {
                _GridUtil.Grid_Clear(grid3);

                //string sPlantCode = DBHelper.nvlString(this.grid2.ActiveRow.Cells["PLANTCODE"].Value);              //공장

                string sOrderNo = DBHelper.nvlString(this.grid2.ActiveRow.Cells["ORDERNO"].Value);

                string sPlanNo = DBHelper.nvlString(cbo_PLANTCODE_H.Text);

                if (sPlanNo == string.Empty || sOrderNo == string.Empty)
                    return;

                rtnDtTemp = helper.FillTable("USP_PP0215_S5", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlanNo, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ORDERNO", this.grid2.ActiveRow.Cells["ORDERNO"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("PC_CODE", "S1", DbType.String, ParameterDirection.Input));

                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
    }
}
#endregion