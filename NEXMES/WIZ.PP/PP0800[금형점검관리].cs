#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0600
//   Form Name    : 품목별 표준시간마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목별 표준시간 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0800 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public PP0800()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0600_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 60, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAXCOUNT", "한계수명", true, GridColDataType_emu.Double, 60, 100, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CYCLECOUNT", "점검주기SHOT", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NOWCOUNT", "누적SHOT", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NEXTINSPCOUNT", "점검예정SHOT", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종점검날짜", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPCOUNT", "최종점검SHOT", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCOUNT", "점검 후 SHOT", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMAINCOUNT", "점검 전 허용 SHOT", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NEXTINSPREMAIN", "진척율(%)", true, GridColDataType_emu.Double, 60, 50, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "MODINSPNUM", "점검번호", true, GridColDataType_emu.VarChar, 60, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 60, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MOLDCODE", "금형코드", true, GridColDataType_emu.VarChar, 60, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MODINSPCODE", "점검코드", true, GridColDataType_emu.VarChar, 300, 300, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MODINSPNAME", "점검항목", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ACTIONCODE", "조치코드", true, GridColDataType_emu.VarChar, 300, 300, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ACTIONNAME", "조치항목", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPCOUNT", "누적SHOT", true, GridColDataType_emu.Double, 140, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPDATE", "점검일자", true, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일자", true, GridColDataType_emu.DateTime, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일자", true, GridColDataType_emu.DateTime, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid2);




                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                rtnDtTemp = _Common.GET_BM0685_CODE("", "Y"); //점검코드
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "MODINSPCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0686_CODE("", "Y"); //조치코드
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ACTIONCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });



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

            base.DoInquire();

            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);
            //string sItemCode       = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
            //string sOpCode         = DBHelper.nvlString(txt_OPCODE_H.Text.Trim());

            DBHelper helper = new DBHelper(false);

            try
            {

                rtnDtTemp = helper.FillTable("USP_PP0800_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            if (grid1.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("점검 리스트를 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                base.DoNew();

                this.grid2.InsertRow();

                grid2.ActiveRow.Cells["INSPDATE"].Value = DateTime.Now;
                string sNowCount = DBHelper.nvlString(grid1.ActiveRow.Cells["NOWCOUNT"].Value);

                this.grid2.ActiveRow.Cells["PLANTCODE"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                this.grid2.ActiveRow.Cells["MOLDCODE"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                this.grid2.ActiveRow.Cells["INSPCOUNT"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["NOWCOUNT"].Value);

                //grid2.UpdateData();

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치 (좌측에서 받아온 값도 수정이 안되도록 해야함)
                grid2.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["MOLDCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["INSPCOUNT"].Activation = Activation.NoEdit;

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
            rtnDtTemp = grid2.chkChange();

            DateTime dtNow = DateTime.Now;
            if (rtnDtTemp == null)
            {
                return;
            }

            string sInspDate = "";
            string sModInspNum = "";
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
                        if (Convert.ToString(drRow["MODINSPCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("검사항목 미선택.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["ACTIONCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("조치항목 미선택.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        #endregion
                    }
                    switch (drRow.RowState)
                    {

                        case DataRowState.Deleted:
                            #region 삭제
                            helper.ExecuteNoneQuery("USP_PP0800_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MODINSPNUM", DBHelper.nvlString(drRow["MODINSPNUM"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가  
                            sInspDate = DBHelper.nvlString(drRow["INSPDATE"]).Substring(0, 10);
                            sModInspNum = DateTime.Now.ToString("yyyyMMddHHmmss");
                            //sModInspNum = sModInspNum.Replace("-","");
                            helper.ExecuteNoneQuery("USP_PP0800_I1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_MODINSPNUM", sModInspNum, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MODINSPCODE", DBHelper.nvlString(drRow["MODINSPCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ACTIONCODE", DBHelper.nvlString(drRow["ACTIONCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_INSPCOUNT", DBHelper.nvlString(drRow["INSPCOUNT"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_INSPDATE", sInspDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            sInspDate = DBHelper.nvlString(drRow["INSPDATE"]).Substring(0, 10);

                            //점검번호(수정x, 조건 조회용), 사업장코드, 금형번호, 점검코드, 점검항목, 점검일자 
                            helper.ExecuteNoneQuery("USP_PP0800_U1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_MODINSPNUM", DBHelper.nvlString(drRow["MODINSPNUM"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MODINSPCODE", DBHelper.nvlString(drRow["MODINSPCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ACTIONCODE", DBHelper.nvlString(drRow["ACTIONCODE"]), DbType.String, ParameterDirection.Input)
                                //, helper.CreateParameter("AS_INSPCOUNT",    DBHelper.nvlString(drRow["INSPDATE"]),    DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_INSPDATE", sInspDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();

                    //DoInquire(); //성공적으로 수행되었을 경우에만 조회
                    //grid2만 재조회 예정
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(Common.getLangText(helper.RSMSG, "TEXT"), Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(Common.getLangText(ex.Message, "TEXT"), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화        

            DBHelper helper = new DBHelper(false);

            //GRID1 품목별 불량항목 조회
            try
            {
                //GRID2에서 정보 GET
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sMoldCode = DBHelper.nvlString(grid1.ActiveRow.Cells["MOLDCODE"].Value);

                rtnDtTemp = helper.FillTable("USP_PP0800_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input));

                //if (rtnDtTemp.Rows.Count > 0)
                //{
                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds();
                //}
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(Common.getLangText(ex.Message, "TEXT"), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion


    }
}