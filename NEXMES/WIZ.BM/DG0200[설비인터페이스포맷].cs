#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DG0200
//   Form Name    : 설비 키컬럼 리스트
//   Name Space   : WIZ.BM
//   Created Date : 2020-09-07
//   Made By      : WIZCORE IFS2팀 차장 신효철
//   Edited Date  : 
//   Edit By      :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
#endregion

namespace WIZ.BM
{
    public partial class DG0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        //BizTextBoxManager btbManager = new BizTextBoxManager(); 

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public DG0200()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void DG0200_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업장
                _GridUtil.InitializeGrid(this.Grid1, false, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(Grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(Grid1, "TYPE_NO", "분류NO", true, GridColDataType_emu.VarChar, 200, 230, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(Grid1, "IDX", "인덱스", true, GridColDataType_emu.Integer, 60, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "ColName", "컬럼명", true, GridColDataType_emu.VarChar, 150, 180, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(Grid1, "CAPTION", "주석", true, GridColDataType_emu.VarChar, 230, 300, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(Grid1, "Format_NO", "형식NO", true, GridColDataType_emu.VarChar, 200, 230, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(Grid1, "SEQ", "순서", true, GridColDataType_emu.Integer, 60, 90, Infragistics.Win.HAlign.Center, true, true);

                _GridUtil.InitColumnUltraGrid(Grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 70, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 190, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 70, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 190, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(Grid1);


                //필수입력 항목에 대한 음영                
                Grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                Grid1.DisplayLayout.Bands[0].Columns["TYPE_NO"].Header.Appearance.ForeColor = Color.SkyBlue;
                Grid1.DisplayLayout.Bands[0].Columns["ColName"].Header.Appearance.ForeColor = Color.SkyBlue;
                Grid1.DisplayLayout.Bands[0].Columns["Format_NO"].Header.Appearance.ForeColor = Color.SkyBlue;
                Grid1.DisplayLayout.Bands[0].Columns["IDX"].Header.Appearance.ForeColor = Color.SkyBlue;
                Grid1.DisplayLayout.Bands[0].Columns["SEQ"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.Cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                Cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("DG_DATA_TYPE"); //DG 데이터타입
                WIZ.Common.FillComboboxMaster(this.Cbo_DataType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DATA_TYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                string sPlantCode = DBHelper.nvlString(Cbo_PLANTCODE_H.Value);
                rtnDtTemp = _Common.GET_DG0000_CODE(sPlantCode); //분류NO
                WIZ.Common.FillComboboxMaster(this.Cbo_TypeNo_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "TYPE_NO", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //1. Cbo_TypeNo_H_ValueChanged          /// 콤보의 값이 변경될때 이벤트로 데이터 셋팅시에도 발생함(화면 _Load시에  부적합함)
                //2. Cbo_TypeNo_H_AfterCloseUp




                //Grid1 이벤트 순서
                //1. Grid1_ClickCell
                //2. Grid1_CellListSelect
                //3. Grid1_AfterCellListCloseUp
                //4. Grid1_AfterCellListCloseUp - cell.Column.Key = SPECCODE


                #endregion

                #region POPUP SETTING

                //작업장명
                //btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });  
                //공정명
                //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });
                //라인명
                //btbManager.PopUpAdd(txt_LINECODE_H, txt_LINENAME_H, "BM0050", new object[] { cbo_PLANTCODE_H, "", "" });

                //BizGridManager bizGridManager = new BizGridManager(grid1);
                //bizGridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "", "Y" });
                //bizGridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });

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
            _GridUtil.Grid_Clear(Grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(Cbo_PLANTCODE_H.Value);
                string sTYPE_NO = DBHelper.nvlString(Cbo_TypeNo_H.Value);
                string sDATA_TYPE = DBHelper.nvlString(Cbo_DataType_H.Value);
                string sSpecCode = DBHelper.nvlString(Cbo_SpecCode_H.Value);

                rtnDtTemp = helper.FillTable("USP_DG0200_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TYPE_NO", sTYPE_NO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("DATA_TYPE", sDATA_TYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("SpecCode", sSpecCode, DbType.String, ParameterDirection.Input)

                                            );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    Grid1.DataSource = rtnDtTemp;
                    Grid1.DataBinds(rtnDtTemp);

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

                this.Grid1.InsertRow();

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                Grid1.ActiveRow.Cells["ColName"].Activation = Activation.NoEdit;
                Grid1.ActiveRow.Cells["CAPTION"].Activation = Activation.NoEdit;
                Grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                Grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                Grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                Grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;

                //사업장과 기타 정보를... 행 추가시 기본으로 세팅
                this.Grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.Grid1.ActiveRow.Cells["TYPE_NO"].Value = DBHelper.nvlString(Cbo_TypeNo_H.Value);

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

            //this.grid1.DeleteRow(); //BM은 삭제기능 비활성화 
            if (this.Grid1.IsActivate)
            {
                this.Grid1.DeleteRow();
            }


        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = Grid1.chkChange();

            //DateTime dtNow = DateTime.Now;

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
                        if (Convert.ToString(drRow["TYPE_NO"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("분류NO는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }


                        if (Convert.ToString(drRow["Format_NO"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("형식NO는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }


                        if (Convert.ToString(drRow["SEQ"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("순서는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["COLNAME"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("항목은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["IDX"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("인덱스는 필수 입력항목입니다. \\N규격코드를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        #endregion
                    }

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제   
                            drRow.RejectChanges();  //2020-09-14 add

                            helper.ExecuteNoneQuery("USP_DG0200_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("TYPE_NO", DBHelper.nvlString(drRow["TYPE_NO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Format_NO", DBHelper.nvlString(drRow["Format_NO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("IDX", DBHelper.nvlString(drRow["IDX"]), DbType.Int32, ParameterDirection.Input)

                                                    , helper.CreateParameter("UserID", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    );

                            #endregion
                            break;

                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region 추가 또는 수정
                            helper.ExecuteNoneQuery("USP_DG0200_SAVE1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("TYPE_NO", DBHelper.nvlString(drRow["TYPE_NO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Format_NO", DBHelper.nvlString(drRow["Format_NO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("IDX", DBHelper.nvlString(drRow["IDX"]), DbType.Int32, ParameterDirection.Input)

                                                    , helper.CreateParameter("SEQ", DBHelper.nvlString(drRow["SEQ"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("SpecCode", DBHelper.nvlString(drRow["ColName"]), DbType.String, ParameterDirection.Input)

                                                    , helper.CreateParameter("UserID", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                    }

                    Grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);  //2020-09-14
                }

                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();

                    Grid1.SetAcceptChanges();   //2020-09-10

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
            //base.DoImportExcel();

            //BM0060_EXCEL bm0060_excel = new BM0060_EXCEL();
            //bm0060_excel.ShowDialog();

            //base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        //private DataTable selectPrinterList()
        //{
        //    DBHelper helper = new DBHelper(false);
        //    DataTable tmpTable = new DataTable();
        //    try
        //    {
        //        tmpTable = helper.FillTable("USP_PRINTERADD_S1", CommandType.StoredProcedure
        //                                                    , helper.CreateParameter("PRINTERNAME", "", DbType.String, ParameterDirection.Input)
        //                                                    , helper.CreateParameter("CIP", "", DbType.String, ParameterDirection.Input)
        //                                                    , helper.CreateParameter("USEFLAG", "Y", DbType.String, ParameterDirection.Input));       
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ClosePrgFormNew();
        //        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        this.ClosePrgFormNew();
        //        helper.Close();
        //    }

        //    return tmpTable;
        //}


        #endregion

        private void DG0200_Activated(object sender, EventArgs e)
        {
            ////2020-09-14 ADD
            //try
            //{
            //    if (rtnDtTemp.Rows.Count > 0 && grid1 != null)
            //    {
            //        //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
            //        grid1.ActiveRow.Cells["IDX"].Activation = Activation.NoEdit;
            //    }
            //}
            //catch (Exception)
            //{
            //    //
            //}
        }

        private void Grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //콤보의 값을 선택이 끝난 후에
            Debug.WriteLine("Grid1_AfterCellListCloseUp");

            string ColumnKey = e.Cell.Column.Key.Trim().ToUpper();//get column key
            if (ColumnKey != "TYPE_NO".ToUpper() && ColumnKey != "IDX".ToUpper())
            {
                //Debug.WriteLine("Grid1_AfterCellListCloseUp - Cell.Column.Key = " + ColumnKey);                                     //get column key
                //Debug.WriteLine("Grid1_AfterCellListCloseUp - Cell.Column.Header.Caption = " + e.Cell.Column.Header.Caption);   // get column caption 
                //Debug.WriteLine("Grid1_AfterCellListCloseUp - return");
                return;
            }
            //Debug.WriteLine("Grid1_AfterCellListCloseUp - Cell.Column.Key = " + ColumnKey);
            //Debug.WriteLine("Grid1_AfterCellListCloseUp - Cell.Column.Header.Caption = " + e.Cell.Column.Header.Caption);

            //foreach (UltraGridCell cell in Grid1.Rows[0].Cells)
            //{
            //    ColumnKey = cell.Column.Key;
            //}

            try
            {
                string sPlantCode = CModule.ToString(Grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sTypeNo = CModule.ToString(Grid1.ActiveRow.Cells["TYPE_NO"].Value);
                string sIdx = CModule.ToString(Grid1.ActiveRow.Cells["IDX"].Value);

                DBHelper dBHelper = new DBHelper();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);

                DataTable rtnDtTemp2;

                //규격코드 선택으로 인해 부수정보를 그리드에 채우기 용도
                stringBuilder.AppendLine(" SELECT ColName , Caption ");
                stringBuilder.AppendLine(" FROM   DG0100 WITH(NOLOCK)  ");
                stringBuilder.AppendLine(" WHERE  PlantCode = '" + sPlantCode.Trim() + "'");
                if (sTypeNo != "")
                {
                    stringBuilder.AppendLine("   AND  TYPE_NO = '" + sTypeNo.Trim() + "'");
                }
                if (sIdx != "")
                {
                    stringBuilder.AppendLine("   AND  IDX = '" + sIdx.Trim() + "'");
                }

                rtnDtTemp2 = dBHelper.FillTable(stringBuilder.ToString());

                if (rtnDtTemp2.Rows.Count > 0)
                {
                    DataRow row = rtnDtTemp2.Rows[0];

                    this.Grid1.ActiveRow.Cells["ColName"].Value = row["ColName"].ToString();
                    this.Grid1.ActiveRow.Cells["CAPTION"].Value = row["CAPTION"].ToString();
                }

                dBHelper.Close();

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
    }
}