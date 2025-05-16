#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM4510
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
    public partial class BM4510 : WIZ.Forms.BaseMDIChildForm
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
        public BM4510()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM4510_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                // GRID1 SHELL MASTER 
                _GridUtil.InitializeGrid(this.grid1, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "QueryID", "쿼리 아이디", true, GridColDataType_emu.VarChar, 130, 30, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Title", "팝업 이름", true, GridColDataType_emu.VarChar, 110, 30, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TEXT", "쿼리", true, GridColDataType_emu.VarChar, 200, 1000, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 170, 90, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                // Grid2 SHELL DETAIL
                _GridUtil.InitializeGrid(this.grid2, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "QueryID", "쿼리 아이디", true, GridColDataType_emu.VarChar, 120, 30, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "FormID", "폼 이름", true, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ParamName", "대체 문자", true, GridColDataType_emu.VarChar, 80, 30, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "Seq", "번호", true, GridColDataType_emu.VarChar, 60, 50, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ControlID", "컨트롤 이름", true, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ControlType", "컨트롤 타입", true, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LabelText", "라벨 텍스트", true, GridColDataType_emu.VarChar, 100, 30, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "DetailText", "쿼리", true, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "TextType", "타입", true, GridColDataType_emu.VarChar, 120, 10, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SearchSeq", "컨트롤 위치", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "DefaultValue", "기본값", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OrderSeq", "쿼리 순번", true, GridColDataType_emu.VarChar, 70, 10, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ComboData", "콤보 데이터", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LinkSeqList", "연결 순번", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 120, 10, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ROWSTATUS", "ROWSTATUS", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, false, false);

                _GridUtil.SetInitUltraGridBind(grid2);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_P2, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("POPARGUTYPE"); // 텍스트 타입
                WIZ.Common.FillComboboxMaster(this.cbo_TEXTTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
                WIZ.Common.FillComboboxMaster(this.cbo_TEXTTYPE_P2, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "TextType", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("CONTROLTYPE"); // 텍스트 타입
                WIZ.Common.FillComboboxMaster(this.cbo_CONTROLTYPE_P2, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ControlType", rtnDtTemp, "CODE_ID", "CODE_NAME");
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
                rtnDtTemp = helper.FillTable("USP_BM4510_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_QUERYID", DBHelper.nvlString(txt_QUERYID_H.Text), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TEXT", DBHelper.nvlString(txt_TEXT_H.Text), DbType.String, ParameterDirection.Input)
                                                            );

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

                if (this.grid1.Focused)
                {
                    grid1_InsertRow();
                }
                else if (this.grid2.Focused)
                {
                    grid2_InsertRow();
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

                helper.ExecuteNoneQuery("USP_BM4510_S1"
                                        , CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PCODE", "U1", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_QUERYID", DBHelper.nvlString(txt_QUERYID_P1.Text), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_TITLE", DBHelper.nvlString(txt_TITLE_P1.Text), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_TEXT", DBHelper.nvlString(txt_TEXT_P1.Text), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(txt_REMARK_P1.Text), DbType.String, ParameterDirection.Input)
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
                            //helper.ExecuteNoneQuery("USP_BM4510_S1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_PCODE", "D2", DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_QUERYID", DBHelper.nvlString(drRow.Cells["QueryID"].Value), DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_FORMID", DBHelper.nvlString(drRow.Cells["FormID"].Value), DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_CONTROLID", DBHelper.nvlString(drRow.Cells["ControlID"].Value), DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_SEQ", DBHelper.nvlInt(drRow.Cells["Seq"].Value), DbType.Int32, ParameterDirection.Input));
                            #endregion
                            break;
                        case "A":
                        case "U":
                            #region 수정/추가
                            helper.ExecuteNoneQuery("USP_BM4510_S1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PCODE", "U2", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_QUERYID", DBHelper.nvlString(drRow.Cells["QueryID"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FORMID", DBHelper.nvlString(drRow.Cells["FormID"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PARAMNAME", DBHelper.nvlString(drRow.Cells["ParamName"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTROLID", DBHelper.nvlString(drRow.Cells["ControlID"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTROLTYPE", DBHelper.nvlString(drRow.Cells["ControlType"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LABELTEXT", DBHelper.nvlString(drRow.Cells["LabelText"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEQ", DBHelper.nvlInt(drRow.Cells["Seq"].Value), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DETAILTEXT", DBHelper.nvlString(drRow.Cells["DetailText"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TEXTTYPE", DBHelper.nvlString(drRow.Cells["TextType"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEARCHSEQ", DBHelper.nvlString(drRow.Cells["SearchSeq"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DEFAULTVALUE", DBHelper.nvlString(drRow.Cells["DefaultValue"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ORDERSEQ", DBHelper.nvlString(drRow.Cells["OrderSeq"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_COMBODATA", DBHelper.nvlString(drRow.Cells["ComboData"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LINKSEQLIST", DBHelper.nvlString(drRow.Cells["LinkSeqList"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow.Cells["USEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow.Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(LoginInfo.UserID), DbType.String, ParameterDirection.Input));
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

            //BM4510_EXCEL BM4510_excel = new BM4510_EXCEL();
            //BM4510_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        private void Grid_Search2()
        {
            Common.DoInit(this.splitContainer3.Panel1);

            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화

            try
            {
                string sQueryID = DBHelper.nvlString(grid1.ActiveRow.Cells["QueryID"].Value);

                rtnDtTemp = helper.FillTable("USP_BM4510_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_QUERYID", sQueryID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_FORMID", DBHelper.nvlString(txt_FORMID_H.Text), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PARAMNAME", DBHelper.nvlString(txt_PARAMNAME_H.Text), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CONTROLID", DBHelper.nvlString(txt_CONTROLID_H.Text), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DETAILTEXT", DBHelper.nvlString(txt_DETAILTEXT_H.Text), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TEXTTYPE", DBHelper.nvlString(cbo_TEXTTYPE_H.Value), DbType.String, ParameterDirection.Input)
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

        private void grid1_InsertRow()
        {
            this.grid1.InsertRow();
            grid1.ActiveRow.Activation = Activation.NoEdit;

            Common.DoInit(this.splitContainer2.Panel1);
            Grid_Search2();
        }

        private void grid2_InsertRow()
        {
            this.grid2.InsertRow();
            grid2.ActiveRow.Cells["QueryID"].Value = grid1.ActiveRow.Cells["QueryID"].Text;
            grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";
            grid2.ActiveRow.Cells["ROWSTATUS"].Value = "U";
            grid2.ActiveRow.Activation = Activation.NoEdit;

            Common.DoInit(this.splitContainer3.Panel1);
        }

        private void btnAdd_P1_Click(object sender, EventArgs e)
        {
            grid1_InsertRow();
        }

        private void btnAdd_P2_Click(object sender, EventArgs e)
        {
            grid2_InsertRow();
        }

        private void btnCopy_P2_Click(object sender, EventArgs e)
        {
            grid2.InsertRow(true);
            grid2.ActiveRow.Cells["Seq"].Value = string.Empty;
            grid2.ActiveRow.Activation = Activation.NoEdit;
        }
        #endregion
    }
}