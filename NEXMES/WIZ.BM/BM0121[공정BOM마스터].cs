#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0121
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
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0121 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성


        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0121()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0121_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //grid1 품목 (grid1는 좌측 상단 두번쨰 GRID, GRID를 추가시 좌측상단부터 GRID 채번) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid1, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 90, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 40, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "단가", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, false, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 150, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPNAME", "공정명", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPSEQ", "공정순번", true, GridColDataType_emu.VarChar, 100, 150, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "LASTFLAG", "최종공정", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);

                _GridUtil.SetInitUltraGridBind(grid2);


                //grid3
                _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "생산품목", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "생산품명", true, GridColDataType_emu.VarChar, 200, 150, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "COMPONENT", "품목", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "COMPONENTNAME", "품명", true, GridColDataType_emu.VarChar, 200, 150, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "BASEQTY", "생산수량", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "생산단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "COMPONENTQTY", "소요수량", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "COMPONENTUNIT", "소요단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "REMARK", "비고", true, GridColDataType_emu.VarChar, 300, 200, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 180, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 180, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);


                //필수입력 항목에 대한 음영

                grid2.DisplayLayout.Bands[0].Columns["OPCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["OPSEQ"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["LASTFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["USEFLAG"].Header.Appearance.ForeColor = Color.SkyBlue;


                grid3.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["BASEQTY"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["COMPONENT"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["COMPONENTNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["COMPONENTQTY"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("YESNO"); //사용여부
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LASTFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("SEQ"); //사용여부
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "OPSEQ", rtnDtTemp, "CODE_ID", "CODE_ID");


                rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "COMPONENTUNIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

                BizGridManager bizGridManager = null;

                bizGridManager = new BizGridManager(grid2);
                bizGridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });

                bizGridManager = new BizGridManager(grid3);
                bizGridManager.PopUpAdd("COMPONENT", "COMPONENTNAME", "BM0010", new string[] { "PLANTCODE", "4", "Y" });




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

            base.DoInquire();

            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);
            string sTabIdx = string.Empty;

            try
            {
                //grid1 품목 조회
                try
                {

                    rtnDtTemp = helper.FillTable("USP_BM0121_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMNAME", CModule.ToString(txt_ITEMNAME_H.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                }
                catch (Exception ex)
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    this.ClosePrgFormNew(); // GRID가 2개이므로 마지막으로 바인딩 되는 GRID 종료시 PrgForm Close
                    helper.Close();
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
            //BM은 삭제기능 비활성화
            else if (grid3.IsActivate)
            {
                dr = (grid3.ActiveRow.ListObject as DataRowView).Row;

                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Detached)
                {
                    grid3.ActiveRow.Delete();
                }

                else
                {
                    this.grid3.DeleteRow();
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
                                //drRow.RejectChanges();

                                //helper.ExecuteNoneQuery("USP_BM0121_D1", CommandType.StoredProcedure
                                //                        , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                //                        , helper.CreateParameter("AS_INSPCODE", DBHelper.nvlString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input));

                                #endregion
                                break;
                            case DataRowState.Added:
                                #region 추가                            
                                helper.ExecuteNoneQuery("USP_BM0121_I1"
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
                                helper.ExecuteNoneQuery("USP_BM0121_U1"
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
                                helper.ExecuteNoneQuery("USP_BM0121_I2"
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
                                helper.ExecuteNoneQuery("USP_BM0121_U2"
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
            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);


            //grid2 공정 조회
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM0121_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }

                else
                {
                    this.grid2.Selected.Rows.AddRange((UltraGridRow[])this.grid2.Rows.All);
                    this.grid2.DeleteSelectedRows(false);
                }

                this.grid3.Selected.Rows.AddRange((UltraGridRow[])this.grid3.Rows.All);
                this.grid3.DeleteSelectedRows(false);

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew(); // GRID가 2개이므로 마지막으로 바인딩 되는 GRID 종료시 PrgForm Close
                helper.Close();
            }
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);
            string sOpCode = this.grid2.ActiveRow.Cells["OPCODE"].Value.ToString();

            //grid2 공정 조회
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM0121_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds(rtnDtTemp);
                }

                else
                {
                    this.grid3.Selected.Rows.AddRange((UltraGridRow[])this.grid3.Rows.All);
                    this.grid3.DeleteSelectedRows(false);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew(); // GRID가 2개이므로 마지막으로 바인딩 되는 GRID 종료시 PrgForm Close
                helper.Close();
            }
        }
    }
}
#endregion