#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0220
//   Form Name    : 작업장별 구성 설비관리
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-08
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업장에 구성되어있는 설비 관련 정보를 관리
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
    public partial class BM0220 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0220()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0220_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업장별 설비 (GRID1은 우측에 위치한 MAIN GRID!)
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DISPLAYNO", "표시순번", true, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WCPRODFLAG", "작업장실적반영여부", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHNAME"].Header.Appearance.ForeColor = Color.SkyBlue;


                //GRID2 작업장 (GRID2는 좌측 상단 첫번쨰 GRID) (MAIN GRID를 제외한 GRID는 사업장 / 코드 / 코드명 만 출력) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid2, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);


                //GRID3 설비 (GRID3는 좌측 상단 두번쨰 GRID, GRID를 추가시 좌측상단부터 GRID 채번) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid3, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MACHCODE", "설비코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MACHNAME", "설비명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("WCPRODFLAG"); //작업장실적반영 여부              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WCPRODFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", cbo_USEFLAG_H });

                //설비
                btbManager.PopUpAdd(txt_MACHCODE_H, txt_MACHNAME_H, "BM0070", new object[] { cbo_PLANTCODE_H, "", "", cbo_USEFLAG_H });

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

            //조회항목에서 선택된 값 GET
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
            string sMachCode = DBHelper.nvlString(txt_MACHCODE_H.Text.Trim());
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

            DBHelper helper = new DBHelper(false);

            //GRID2 거래처 조회
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM0220_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }

            //GRID3 품목 조회
            try
            {

                rtnDtTemp = helper.FillTable("USP_BM0220_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds(rtnDtTemp);
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            // 좌측 매칭할 정보들이 선택되어 있는지 확인
            if (grid2.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("작업장을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            else if (grid3.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("설비를 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                //해당 TABLE의 기본키및 명칭은 좌측 GRID에서 선택된 정보들을 GRID1의 해당 컬럼에 BINDING
                //GRID2의 정보
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["WORKCENTERCODE"].Value);
                this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Value = DBHelper.nvlString(grid2.ActiveRow.Cells["WORKCENTERNAME"].Value);
                //GRID3의 정보
                this.grid1.ActiveRow.Cells["MACHCODE"].Value = DBHelper.nvlString(grid3.ActiveRow.Cells["MACHCODE"].Value);
                this.grid1.ActiveRow.Cells["MACHNAME"].Value = DBHelper.nvlString(grid3.ActiveRow.Cells["MACHNAME"].Value);

                //사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                grid1.UpdateData();

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치 (좌측에서 받아온 값도 수정이 안되도록 해야함)
                grid1.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["WORKCENTERCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["WORKCENTERNAME"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MACHCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MACHNAME"].Activation = Activation.NoEdit;

                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
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

            this.grid1.DeleteRow(); //신규로 추가된 행을 제거하는 용도로 사용
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();

            DateTime dtNow = DateTime.Now;

            if (rtnDtTemp == null)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["WORKCENTERCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("작업장은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["MACHCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("설비는 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
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
                            helper.ExecuteNoneQuery("USP_BM0220_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCODE", DBHelper.nvlString(drRow["MACHCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_DISPLAYNO", DBHelper.nvlString(drRow["DISPLAYNO"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WCPRODFLAG", DBHelper.nvlString(drRow["WCPRODFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0220_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCODE", DBHelper.nvlString(drRow["MACHCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_DISPLAYNO", DBHelper.nvlString(drRow["DISPLAYNO"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WCPRODFLAG", DBHelper.nvlString(drRow["WCPRODFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
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

            BM0220_EXCEL bm0220_excel = new BM0220_EXCEL();
            bm0220_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        //GRID1 조회 (GRID1은 항상 GRID2의 ROW를 더블클릭할때 바인딩함)
        private void grid2_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {

            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화        

            DBHelper helper = new DBHelper(false);

            //GRID1 고객사별 공급품목 조회
            try
            {
                //GRID2에서 정보 GET
                string sPlantCode = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = DBHelper.nvlString(grid2.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);


                //조회조건에서 정보 GET
                string sMachCode = DBHelper.nvlString(txt_MACHCODE_H.Text.Trim());



                rtnDtTemp = helper.FillTable("USP_BM0220_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
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
                helper.Close();
            }
        }

        //GRID1 신규행 추가
        private void btn_ROWINSERT_B_Click(object sender, EventArgs e)
        {
            DoNew();
        }

        //GRID1 추가된 행 삭제(이미 DB에 저장된 정보는 삭제해도 DB상에서 삭제안됨. 재조회시 조회됨)
        private void btn_ROWDELETE_B_Click(object sender, EventArgs e)
        {
            DoDelete();
        }
        #endregion


    }
}