#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0450
//   Form Name    : 공정검사항목 품목별 스펙관리(Excel)
//   Name Space   : WIZ.BM
//   Created Date : 2020-11-22
//   Made By      : inho.hwang
//   Edited Date  : 
//   Edit By      :
//   Description  : 공정 검사항목 작업장 스펙 및 Excel 파일 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0450 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalut 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0450()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0450_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 공정검사항목 품목/ 작업장별 스펙관리 (GRID1은 우측에 위치한 MAIN GRID!)
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPECT_SEQ", "순서", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "검사값구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "관리구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "검사단위", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "Excel_X", "엑셀 X축", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "Excel_Y", "엑셀 Y축", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "Excel_Caption", "체크박스 내용", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;


                //GRID2 품목 (GRID2는 좌측 상단 첫번쨰 GRID) (MAIN GRID를 제외한 GRID는 사업장 / 코드 / 코드명 만 출력) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid2, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);


                //GRID4 작업장 (GRID4는 좌측 상단 두번쨰 GRID, GRID를 추가시 좌측상단부터 GRID 채번) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid4, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid4);

                //Grid5 Excel 파일(좌측 맨 하단)
                _GridUtil.InitializeGrid(this.grid5, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid5, "SEQ", "SEQ", false, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid5, "EXCEL", "EXCEL", false, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid5, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid5, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid5, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid5, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid5, "Require1", "엑셀파일명", true, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid5);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid5, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("INSPECT_SEQ"); //순서              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPECT_SEQ", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE"); //검사값구분              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "VALUETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE");  //관리구분             
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "SPECTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //검사단위              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME"); ;


                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", cbo_USEFLAG_H });

                //검사항목
                btbManager.PopUpAdd(txt_INSPCODE_H, txt_INSPNAME_H, "BM0170", new object[] { cbo_PLANTCODE_H, cbo_USEFLAG_H });

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
            base.DoInquire();

            DoFind(null);
        }

        private void DoFind(Control.Grid grid)
        {
            //조회항목에서 선택된 값 GET
            string sPlantCode = "";
            string sItemCode = "";
            string sInspCode = "";
            string sWorkcenterCode = "";
            string sUseFlag = "";

            string sEXCEL_TITLE = "";

            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            List<string> listString = new List<string>();

            if (grid == null)
            {
                // DoInquire()
                _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
                _GridUtil.Grid_Clear(grid4); // 조회전 그리드 초기화
                _GridUtil.Grid_Clear(grid5); // 조회전 그리드 초기화

                sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());

                listString.Add("grid1");
                listString.Add("grid2");
                listString.Add("grid4");
            }
            else if (grid.Name == "grid2" || grid.Name == "grid4")
            {
                _GridUtil.Grid_Clear(grid5); // 조회전 그리드 초기화
                if (grid2.ActiveRow != null)
                {
                    sPlantCode = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                    sItemCode = DBHelper.nvlString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
                }

                if (grid4.ActiveRow != null)
                {
                    sWorkcenterCode = DBHelper.nvlString(grid4.ActiveRow.Cells["WORKCENTERCODE"].Value);
                }
                listString.Add("grid1");
                listString.Add("grid5");
            }
            else if (grid.Name == "grid5")
            {
                if (grid5.ActiveRow != null)
                {
                    if (DBHelper.nvlString(grid5.ActiveRow.Cells["SEQ"].Value) == "0")
                    {
                        sEXCEL_TITLE = "";
                    }
                    else
                    {
                        sEXCEL_TITLE = DBHelper.nvlString(grid5.ActiveRow.Cells["TYPE"].Value);
                    }
                }

                if (grid2.ActiveRow != null)
                {
                    sPlantCode = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                    sItemCode = DBHelper.nvlString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
                }

                if (grid4.ActiveRow != null)
                {
                    sWorkcenterCode = DBHelper.nvlString(grid4.ActiveRow.Cells["WORKCENTERCODE"].Value);
                }
                listString.Add("grid1");
            }

            sInspCode = DBHelper.nvlString(txt_INSPCODE_H.Text.Trim());
            sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

            DBHelper helper = new DBHelper(false);

            //GRID1 품목별 검사항목 조회
            try
            {
                if (listString.Contains("grid1"))
                {
                    rtnDtTemp = helper.FillTable("USP_BM0450_S2", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_EXCEL_TITLE", sEXCEL_TITLE, DbType.String, ParameterDirection.Input));

                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }

                if (listString.Contains("grid2"))
                {
                    rtnDtTemp = helper.FillTable("USP_BM0440_S2", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }

                if (listString.Contains("grid4"))
                {
                    rtnDtTemp = helper.FillTable("USP_BM0440_S5", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                    grid4.DataSource = rtnDtTemp;
                    grid4.DataBinds(rtnDtTemp);
                }

                if (listString.Contains("grid5"))
                {
                    rtnDtTemp = helper.FillTable("USP_BM0450_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                    grid5.DataSource = rtnDtTemp;
                    grid5.DataBinds(rtnDtTemp);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew(); // GRID가 4개이므로 마지막으로 바인딩 되는 GRID 종료시 PrgForm Close
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();

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

                string sEXCEL_TITLE = "";
                if (grid5.ActiveRow != null)
                {
                    if (DBHelper.nvlString(grid5.ActiveRow.Cells["SEQ"].Value) == "0")
                    {
                        sEXCEL_TITLE = "";
                    }
                    else
                    {
                        sEXCEL_TITLE = DBHelper.nvlString(grid5.ActiveRow.Cells["TYPE"].Value);
                    }
                }

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]

                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >

                            #endregion
                            break;
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0450_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EXCEL_TITLE", sEXCEL_TITLE, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPECT_SEQ", DBHelper.nvlString(drRow["INSPECT_SEQ"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPCODE", DBHelper.nvlString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_VALUETYPE", DBHelper.nvlString(drRow["VALUETYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_Excel_X", DBHelper.nvlInt(drRow["Excel_X"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_Excel_Y", DBHelper.nvlInt(drRow["Excel_Y"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_Excel_Caption", DBHelper.nvlString(drRow["Excel_Caption"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));
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

        }

        #endregion

        #region < EVENT AREA >

        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_CellChange(object sender, CellEventArgs e)
        {
        }

        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_ClickCell(object sender, EventArgs e)
        {
        }

        #endregion

        #region < METHOD AREA >
        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {

        }

        private void grid_ClickCell(object sender, ClickCellEventArgs e)
        {
            Control.Grid g = sender as Control.Grid;

            if (g != null)
            {
                DoFind(g);
            }
        }
    }
}