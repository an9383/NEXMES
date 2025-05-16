#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5820
//   Form Name    : 라우터마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-04
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 라우트 정보를 관리                                     
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM5820 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp3 = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM5820()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM5820_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                // GRID1 SHELL MASTER 
                _GridUtil.InitializeGrid(this.grid1, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "FileID", "FILE ID", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FileName", "FILD 명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FILEString", "파일내용", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                // Grid2 SHELL DETAIL
                _GridUtil.InitializeGrid(this.grid2, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "FileID", "FILE ID", true, GridColDataType_emu.VarChar, 80, 50, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SEQ", "순번", true, GridColDataType_emu.Integer, 150, 50, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "FindString", "찾을 문자열", true, GridColDataType_emu.VarChar, 150, 50, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ChgString", "변경 문자열", true, GridColDataType_emu.VarChar, 150, 50, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 20, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ROWSTATUS", "ROWSTATUS", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, false, false);

                _GridUtil.SetInitUltraGridBind(grid2);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.Common.FillComboboxMaster(this.cboUseFlag2, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("SHELL_FILE"); // SHELL 종류
                WIZ.Common.FillComboboxMaster(this.cboCommonList, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                #endregion

                #region POPUP SETTING

                #endregion

                Common.DoInit(splitContainer2.Panel1);
                Common.DoInit(splitContainer3.Panel1);

                // 그리드와 컨트롤을 동기화 시킨다.
                Control.GridExtendUtil.SetLink(splitContainer2.Panel1, grid1, Grid_Search2);
                Control.GridExtendUtil.SetLink(splitContainer3.Panel1, grid2, null, "ROWSTATUS");
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
            Common.DoInit(this.splitContainer2.Panel1);
            Common.DoInit(this.splitContainer3.Panel1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM5820_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_FILE_ID", DBHelper.nvlString(txtSHELLID_H.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_FILE_NAME", DBHelper.nvlString(txt_SHELLNAME_H.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(cbo_USEFLAG_H.Value), DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);

                foreach (UltraGridRow ugr in grid1.Rows)
                {
                    ugr.Activation = Activation.NoEdit;
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

                this.grid1.InsertRow();

                grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
                grid1.ActiveRow.Activation = Activation.NoEdit;

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                Common.DoInit(this.splitContainer2.Panel1);
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

            if (this.grid1.Focused)
            {
                if (this.ShowDialog(Common.getLangText("선택된 항목을 삭제하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                DBHelper helper = new DBHelper("", true);

                try
                {
                    helper.ExecuteNoneQuery("USP_BM5820_I1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PCODE", "D", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_FILE_ID", DBHelper.nvlString(txt_FileID.Text.Trim()), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SEQ", "-1", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                }
            }

            if (this.grid2.Focused)
            {
                this.grid2.DeleteRow();
            }
            //this.grid1.DeleteRow(); //BM은 삭제기능 비활성화
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                helper.ExecuteNoneQuery("USP_BM5820_I1"
                                        , CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PCODE", "U1", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_FILE_ID", DBHelper.nvlString(txt_FileID.Text.Trim()), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_SEQ", "", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_FILE_NAME", DBHelper.nvlString(txt_FileName.Text.Trim()), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_FILE_STRING", DBHelper.nvlString(txtFileString.Text.Trim()), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(txtRemark1.Text.Trim()), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                foreach (UltraGridRow drRow in grid2.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    string sRowStatus = CModule.ToString(drRow.Cells["ROWSTATUS"].Value);

                    if (sRowStatus != "")
                    {
                        #region [ validation 체크 ]
                        #endregion
                    }
                    switch (sRowStatus)
                    {
                        case "D":
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            helper.ExecuteNoneQuery("USP_BM5820_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PCODE", "D1", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FILE_ID", DBHelper.nvlString(drRow.Cells["FILE_ID"].Value).Trim(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEQ", DBHelper.nvlString(drRow.Cells["SEQ"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case "A":
                        case "U":
                            #region 수정/추가
                            helper.ExecuteNoneQuery("USP_BM5820_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PCODE", "U2", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FILE_ID", DBHelper.nvlString(txt_FileID.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEQ", DBHelper.nvlString(drRow.Cells["SEQ"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FindString", DBHelper.nvlString(drRow.Cells["FindString"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ChgString", DBHelper.nvlString(drRow.Cells["ChgString"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow.Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow.Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
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

            //BM5820_EXCEL BM5820_excel = new BM5820_EXCEL();
            //BM5820_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        private void Grid_Search2()
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화

            try
            {
                string sFileID = DBHelper.nvlString(grid1.ActiveRow.Cells["FileID"].Value);

                rtnDtTemp = helper.FillTable("USP_BM5820_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_FILE_ID", sFileID, DbType.String, ParameterDirection.Input)
                                                            );

                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds(rtnDtTemp);

                foreach (UltraGridRow ugr in grid2.Rows)
                {
                    ugr.Activation = Activation.NoEdit;
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.grid2.InsertRow();

            grid2.ActiveRow.Cells["SEQ"].Value = "Y";
            grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
            grid2.ActiveRow.Cells["FindString"].Value = "";
            grid2.ActiveRow.Cells["ChgString"].Value = "";
            grid2.ActiveRow.Cells["REMARK"].Value = "";
            grid2.ActiveRow.Cells["ROWSTATUS"].Value = "U";
            grid2.ActiveRow.Activation = Activation.NoEdit;

            Common.DoInit(splitContainer3.Panel1);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.grid1.InsertRow();
            grid1.ActiveRow.Activation = Activation.NoEdit;

            Common.DoInit(splitContainer2.Panel1);
        }

        private void btnChgString_Click(object sender, EventArgs e)
        {
            txt_ChgString.Text = "[" + CModule.ToString(cboCommonList.Value) + "]";
        }
        #endregion

    }
}