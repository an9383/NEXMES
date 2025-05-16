#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DG0100
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
using System.Drawing;
#endregion

namespace WIZ.BM
{
    public partial class DG0100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        //BizTextBoxManager btbManager = new BizTextBoxManager(); 

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public DG0100()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void DG0100_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업장
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TYPE_NO", "분류NO", true, GridColDataType_emu.VarChar, 200, 230, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "IDX", "인덱스", true, GridColDataType_emu.Integer, 60, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ColName", "컬럼명", true, GridColDataType_emu.VarChar, 150, 180, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CAPTION", "주석", true, GridColDataType_emu.VarChar, 230, 300, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DATA_TYPE", "데이터타입", true, GridColDataType_emu.VarChar, 150, 180, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DIVISION", "DIVISION", false, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Left, true, true);

                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 70, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 190, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 70, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 190, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);


                //필수입력 항목에 대한 음영                
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["TYPE_NO"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["IDX"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ColName"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["CAPTION"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["DATA_TYPE"].Header.Appearance.ForeColor = Color.SkyBlue;


                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("DG_DATA_TYPE"); //DG 데이터타입
                WIZ.Common.FillComboboxMaster(this.cbo_DataType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DATA_TYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");


                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                rtnDtTemp = _Common.GET_DG0000_CODE(sPlantCode); //분류NO
                WIZ.Common.FillComboboxMaster(this.cbo_TypeNo_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TYPE_NO", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sTYPE_NO = DBHelper.nvlString(cbo_TypeNo_H.Value);
                string sDATA_TYPE = DBHelper.nvlString(cbo_DataType_H.Value);

                rtnDtTemp = helper.FillTable("USP_DG0100_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TYPE_NO", sTYPE_NO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("DATA_TYPE", sDATA_TYPE, DbType.String, ParameterDirection.Input)

                                            );

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

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["IDX"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                //this.grid1.ActiveRow.Cells["USEFLAG"].Value   = "Y";
                //this.grid1.ActiveRow.Cells["IDX"].Value = Common.getLangText("자동채번", "TEXT");


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
            if (this.grid1.IsActivate)
            {
                this.grid1.DeleteRow();
            }


        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();

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
                            this.ShowDialog(Common.getLangText("분류NO는 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["ColName"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("컬럼명은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["CAPTION"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("주석은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["DATA_TYPE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("데이터타입은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }


                        #endregion
                    }

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제   
                            drRow.RejectChanges();  //2020-09-14 add

                            helper.ExecuteNoneQuery("USP_DG0100_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("TYPE_NO", DBHelper.nvlString(drRow["TYPE_NO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("IDX", DBHelper.nvlString(drRow["IDX"]), DbType.Int32, ParameterDirection.Input)

                                                    , helper.CreateParameter("UserID", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    );

                            #endregion
                            break;

                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region 추가 또는 수정
                            helper.ExecuteNoneQuery("USP_DG0100_SAVE1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("TYPE_NO", DBHelper.nvlString(drRow["TYPE_NO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("IDX", DBHelper.nvlString(drRow["IDX"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("COLNAME", DBHelper.nvlString(drRow["COLNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CAPTION", DBHelper.nvlString(drRow["CAPTION"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DATA_TYPE", DBHelper.nvlString(drRow["DATA_TYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DIVISION", DBHelper.nvlString(drRow["DIVISION"]), DbType.Int32, ParameterDirection.Input)

                                                    , helper.CreateParameter("UserID", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                    }

                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);  //2020-09-14
                }

                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();

                    grid1.SetAcceptChanges();   //2020-09-10

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

        private void DG0100_Activated(object sender, EventArgs e)
        {

            //2020-09-14 ADD
            try
            {
                if (rtnDtTemp.Rows.Count > 0 && grid1 != null)
                {

                    //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                    grid1.ActiveRow.Cells["IDX"].Activation = Activation.NoEdit;

                }

            }
            catch (Exception)
            {
                //
            }
        }



    }
}