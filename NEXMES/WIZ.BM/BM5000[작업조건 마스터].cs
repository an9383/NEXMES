#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5000
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
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM5000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM5000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM5000_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업조건 메인
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "MethodCode", "작업조건코드", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MethodName", "작업조건이름", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "AccessPoint", "처리시점", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "Require", "적용내용", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "Amount", "적용수치", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UseAlarm", "알람사용여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "IsAlarm", "알람존재여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "InterLock", "진행불가여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "AlarmPoint", "알람시점", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["MethodCode"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MethodName"].Header.Appearance.ForeColor = Color.SkyBlue;

                //_GridUtil.InitializeGrid(this.grid2, false, true, true, "", false);
                //_GridUtil.InitColumnUltraGrid(grid2, "MethodItem", "작업항목코드", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "MethodName", "작업항목이름", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "AccessPoint", "처리시점", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "AlarmPoint", "알람시점", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                //_GridUtil.SetInitUltraGridBind(grid2);

                ////필수입력 항목에 대한 음영
                //grid2.DisplayLayout.Bands[0].Columns["MethodCode"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid2.DisplayLayout.Bands[0].Columns["MethodName"].Header.Appearance.ForeColor = Color.SkyBlue;


                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("ACCESSPOINT"); //접속여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "AccessPoint", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //알람사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseAlarm", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("INTERLOCK"); //진행불가여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InterLock", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //품목
                //btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                ////공정
                //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });

                ////라인
                //btbManager.PopUpAdd(txt_LINECODE_H, txt_LINENAME_H, "BM0050", new object[] { cbo_PLANTCODE_H, txt_OPCODE_H, cbo_USEFLAG_H });

                ////작업장
                //btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, txt_OPCODE_H, txt_LINECODE_H, cbo_USEFLAG_H });

                BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성

                gridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });
                gridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });
                gridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "OPCODE", "Y" });
                gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "OPCODE", "LINECODE", "Y" });

                gridManager.PopUpClosed += GridManager_PopUpClosed;
                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void GridManager_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
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
                //string sPlantCode      = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                //string sItemCode       = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                //string sOpCode         = DBHelper.nvlString(txt_OPCODE_H.Text.Trim());
                //string sLineCode       = DBHelper.nvlString(txt_LINECODE_H.Text.Trim());
                //string sWorkCenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                string sConCode = DBHelper.nvlString(tbConditionCode.Text.Trim());
                string sConName = DBHelper.nvlString(tbConditionName.Text.Trim());
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM5000_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CODE", sConCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_NAME", sConName, DbType.String, ParameterDirection.Input));

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

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                //this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid1.ActiveRow.Cells["MethodCode"].Value = "New Code";
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["MethodCode"].Activation = Activation.NoEdit;
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

            //this.grid1.DeleteRow(); //BM은 삭제기능 비활성화
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

            DBHelper helper = new DBHelper("", false);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                //helper.DBConnect.BeginTransaction();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        //if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("사업장은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK); 
                        //    return;
                        //}                      
                        //if (Convert.ToString(drRow["ITEMCODE"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("품목은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK); 
                        //    return;
                        //}
                        //if (Convert.ToString(drRow["ITEMNAME"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("품명은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK); 
                        //    return;
                        //}
                        //if (Convert.ToString(drRow["ROUTERTYPE"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("공정방법은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}
                        //if (Convert.ToString(drRow["WORKNO"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("공정순서는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            //drRow.RejectChanges();

                            //helper.ExecuteNoneQuery("USP_BM0010_D1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_PLANTCODE",       DBHelper.nvlString(drRow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_ITEMCODE",        DBHelper.nvlString(drRow["ITEMCODE"]),   DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                   


                            helper.ExecuteNoneQuery("USP_BM5000_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_METHODCDOE", DBHelper.nvlString(drRow["MethodCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_METHODNAME", DBHelper.nvlString(drRow["MethodName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ACCESSPOINT", DBHelper.nvlString(drRow["AccessPoint"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INTERLOCK", DBHelper.nvlString(drRow["InterLock"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REQUIRE", DBHelper.nvlString(drRow["Require"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_AMOUNT", DBHelper.nvlString(drRow["Amount"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEALARM", DBHelper.nvlString(drRow["UseAlarm"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM5000_U1"
                                                     , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_METHODCDOE", DBHelper.nvlString(drRow["MethodCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_METHODNAME", DBHelper.nvlString(drRow["MethodName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ACCESSPOINT", DBHelper.nvlString(drRow["AccessPoint"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INTERLOCK", DBHelper.nvlString(drRow["InterLock"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REQUIRE", DBHelper.nvlString(drRow["Require"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_AMOUNT", DBHelper.nvlString(drRow["Amount"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEALARM", DBHelper.nvlString(drRow["UseAlarm"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }   // foreach

                //if (helper.RSCODE == "S")
                //{
                this.ClosePrgFormNew();
                //helper.Commit();
                DoInquire(); //성공적으로 수행되었을 경우에만 조회
                //}
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

            //BM5000_EXCEL BM5000_excel = new BM5000_EXCEL();
            //BM5000_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion

    }
}