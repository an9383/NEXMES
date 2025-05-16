#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5050
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
    public partial class BM5050 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp3 = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        string sMethodType = "";
        #endregion

        #region < CONSTRUCTOR >
        public BM5050()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        protected override void SetSubData()
        {
            DataRow dr = subData["METHOD_TYPE", "FORM_TYPE"];

            if (dr != null)
            {
                PopUp_Common.SetPop(new object[] { grid1, "ITEMCODE", "ITEMNAME" }, "TEST04");

            }
        }

        private void BM5050_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

                //GRID1 품목
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목유형", true, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 300, 90, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                // Grid2 라우팅
                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);

                //GRID1 라우터
                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKNO", "공정순서", true, GridColDataType_emu.Integer, 100, 140, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPNAME", "공정명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 300, 90, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);


                // grid3 작업조건
                _GridUtil.InitializeGrid(this.grid3, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MethodCode", "작업조건코드", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "MethodName", "작업조건이름", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "AccessPoint", "처리시점", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "Amount", "적용수치", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "Require", "추가정보0", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "Require1", "추가정보1", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "Require2", "추가정보2", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "Require3", "추가정보3", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "UseAlarm", "알람사용여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "IsAlarm", "알람존재여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "InterLock", "진행불가여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "AlarmPoint", "알람시점", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);

                //필수입력 항목에 대한 음영
                grid3.DisplayLayout.Bands[0].Columns["MethodCode"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["MethodName"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("ACCESSPOINT"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "AccessPoint", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("INTERLOCK"); //진행불가여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "InterLock", rtnDtTemp, "CODE_ID", "CODE_NAME");

                DBHelper helper = new DBHelper(false);

                try
                {
                    //string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                    //string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                    //string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());
                    //string sOpCode = DBHelper.nvlString(txt_OPCODE_H.Text.Trim());
                    //string sOpName = DBHelper.nvlString(txt_OPNAME_H.Text.Trim());
                    //string sMethodCode = DBHelper.nvlString(txt_METHODCODE_H.Text.Trim());
                    //string sMethodName = DBHelper.nvlString(txt_METHODNAME_H.Text.Trim());
                    //string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                    //rtnDtTemp = helper.FillTable("USP_BM5050_S1", CommandType.StoredProcedure
                    //                                            , helper.CreateParameter("PTYPE", "S4", DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_OPNAME", sOpName, DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_METHODCODE", "", DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_METHODNAME", sMethodName, DbType.String, ParameterDirection.Input)
                    //                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                    //WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["METHODCODE"].ColumnName, rtnDtTemp.Columns["METHODNAME"].ColumnName, "ALL", "");
                    //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "MethodCode", rtnDtTemp, "METHODCODE", "METHODNAME");

                    PopUp.PopUp_Common.SetPop(new object[] { txt_METHODCODE_H, txt_METHODNAME_H }, "METHOD_POP");
                    PopUp.PopUp_Common.SetPop(new object[] { this.grid3, "METHODCODE", "METHODNAME" }, "METHOD_POP", null, PopupClosed);
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


                #endregion

                #region POPUP SETTING

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });


                //btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });
                //PopUp_Common.SetPop(new object[] { this.txt_ITEMCODE_H, this.txt_ITEMNAME_H }, new string[] {  }, "TEST04", this.Name, new object[] { this.grid1 }, new string[] { "ITEMCODE", "ITEMNAME" });
                //PopUp_Common.SetPop(new object[] { this.txt_ITEMCODE_H, this.txt_ITEMNAME_H }, "TEST04");
                //PopUp_Common.SetPop(new object[] { grid1, "ITEMCODE", "ITEMNAME" }, "TEST04", new object[] { grid1, "ITEMCODE", "ITEMNAME", "ITEMTYPE" });


                //공정
                btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });
                #endregion
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        //void delePopupCloseMethod(UltraGrid grid, UltraGridRow udr, CellEventArgs e);
        public void PopupClosed(UltraGrid grid, UltraGridRow udr, CellEventArgs e)
        {
            string key = e.Cell.Column.Key;

            if (key == "METHODCODE" || key == "METHODNAME")
            {
                grid3.UpdateData();
                string sMethodCode = Convert.ToString(grid3.ActiveRow.Cells["MethodCode"].Value);

                DBHelper helper = new DBHelper(false);

                try
                {
                    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    rtnDtTemp = helper.FillTable("USP_BM5050_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("PTYPE", "S4", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_OPCODE", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_OPNAME", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_METHODCODE", sMethodCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_METHODNAME", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));


                    DataRow[] rows = rtnDtTemp.Select();

                    grid3.ActiveRow.Cells["AccessPoint"].Value = rows[0]["ACCESSPOINT"];
                    grid3.ActiveRow.Cells["Require"].Value = rows[0]["REQUIRE"];
                    grid3.ActiveRow.Cells["Amount"].Value = rows[0]["AMOUNT"];
                    grid3.ActiveRow.Cells["UseAlarm"].Value = rows[0]["USEALARM"];
                    grid3.ActiveRow.Cells["InterLock"].Value = rows[0]["INTERLOCK"];
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

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());
                string sOpCode = DBHelper.nvlString(txt_OPCODE_H.Text.Trim());
                string sOpName = DBHelper.nvlString(txt_OPNAME_H.Text.Trim());
                string sMethodCode = DBHelper.nvlString(txt_METHODCODE_H.Text.Trim());
                string sMethodName = DBHelper.nvlString(txt_METHODNAME_H.Text.Trim());
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM5050_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPNAME", sOpName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODCODE", sMethodCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODNAME", sMethodName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);
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

                this.grid3.InsertRow();

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid3.ActiveRow.Cells["ITEMCODE"].Value = grid1.ActiveRow.Cells["ITEMCODE"].Value;
                this.grid3.ActiveRow.Cells["OPCODE"].Value = grid2.ActiveRow.Cells["OPCODE"].Value;
                this.grid3.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid3.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid3.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid3.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid3.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid3.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
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
            rtnDtTemp = grid3.chkChange();

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
                        if (Convert.ToString(drRow["ITEMCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["MethodCode"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("작업조건은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["OPCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("공정은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
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
                        case DataRowState.Modified:
                            #region 수정/추가           
                            helper.ExecuteNoneQuery("USP_BM5050_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_METHODCDOE", DBHelper.nvlString(drRow["MethodCode"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ACCESSPOINT", DBHelper.nvlString(drRow["AccessPoint"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEALARM", DBHelper.nvlString(drRow["UseAlarm"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INTERLOCK", DBHelper.nvlString(drRow["InterLock"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REQUIRE", DBHelper.nvlString(drRow["Require"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REQUIRE1", DBHelper.nvlString(drRow["Require1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REQUIRE2", DBHelper.nvlString(drRow["Require2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REQUIRE3", DBHelper.nvlString(drRow["Require3"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_AMOUNT", DBHelper.nvlString(drRow["Amount"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
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

            //BM5050_EXCEL BM5050_excel = new BM5050_EXCEL();
            //BM5050_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >


        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);

                rtnDtTemp = helper.FillTable("USP_BM5050_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S2", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODCODE", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));


                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds(rtnDtTemp);


                rtnDtTemp = helper.FillTable("USP_BM5050_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S5", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODCODE", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));


                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds(rtnDtTemp);
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

        private void btn_COPY_R_Click(object sender, EventArgs e)
        {
            try
            {
                base.DoNew();

                this.grid3.InsertRow();

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid3.ActiveRow.Cells["ITEMCODE"].Value = grid1.ActiveRow.Cells["ITEMCODE"].Value;
                this.grid3.ActiveRow.Cells["OPCODE"].Value = grid2.ActiveRow.Cells["OPCODE"].Value;
                this.grid3.ActiveRow.Cells["PLANTCODE"].Value = grid1.ActiveRow.Cells["PLANTCODE"].Value;
                //this.grid3.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid3.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid3.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid3.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid3.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid3.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void btn_COPY_L_Click(object sender, EventArgs e)
        {
            this.grid3.DeleteRow();
        }

        private void grid3_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            //string key = e.Type.Name;

            string key = e.Cell.Column.Key;
            if (key == "METHODCODE")
            {
                grid3.UpdateData();
                string sMethodCode = Convert.ToString(grid3.ActiveRow.Cells["MethodCode"].Value);

                DBHelper helper = new DBHelper(false);

                try
                {
                    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    rtnDtTemp = helper.FillTable("USP_BM5050_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("PTYPE", "S4", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_OPCODE", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_OPNAME", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_METHODCODE", sMethodCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_METHODNAME", "", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));


                    DataRow[] rows = rtnDtTemp.Select();

                    grid3.ActiveRow.Cells["AccessPoint"].Value = rows[0]["ACCESSPOINT"];
                    grid3.ActiveRow.Cells["Require"].Value = rows[0]["REQUIRE"];
                    grid3.ActiveRow.Cells["Amount"].Value = rows[0]["AMOUNT"];
                    grid3.ActiveRow.Cells["UseAlarm"].Value = rows[0]["USEALARM"];
                    grid3.ActiveRow.Cells["InterLock"].Value = rows[0]["INTERLOCK"];
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
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sOpCode = DBHelper.nvlString(grid2.ActiveRow.Cells["OPCODE"].Value);

                rtnDtTemp = helper.FillTable("USP_BM5050_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PTYPE", "S5", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OPNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODCODE", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_METHODNAME", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "", DbType.String, ParameterDirection.Input));


                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds(rtnDtTemp);
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

        private void grid3_ClickCell(object sender, EventArgs e)
        {
            string sMethodCode = DBHelper.nvlString(grid3.ActiveRow.Cells["MethodCode"].Value);

            BizGridManager gridManager = new BizGridManager(grid3); //그리드 콤보박스 객체 생성

            switch (sMethodCode)
            {
                case "MC0006":
                    // 스크랩 처리일 경우 Require 에서 품목마스터를 팝업으로 띄워줘야 한다.
                    {
                        gridManager.PopUpAdd("Require", "", "BM0010", new string[] { "PLANTCODE", "", "Y" });
                    }
                    break;
                default:
                    // 기본적으로는 Require 에서는 팝업이 따로 뜨지 않는다.
                    {
                        gridManager.PopUpRemove("Require");
                    }
                    break;
            }
        }

        private void btn_COPY_Click(object sender, EventArgs e)
        {
            string itemcode = (grid1.ActiveRow != null) ? grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString() : "";
            string itemname = (grid1.ActiveRow != null) ? grid1.ActiveRow.Cells["ITEMNAME"].Value.ToString() : "";
            string opcode = (grid2.ActiveRow != null) ? grid2.ActiveRow.Cells["OPCODE"].Value.ToString() : "OP0001";

            BM5050_POP bM5050_POP = new BM5050_POP(itemcode, itemname, opcode);
            bM5050_POP.ShowDialog();
        }

        #endregion

    }
}