#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0465
//   Form Name    : 설비점검항목 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-24
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      : 
//   Description  : 설비점검항목 관리
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
    public partial class BM0465 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0465()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0465_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 설비점검항목 마스터
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKCODE", "점검항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKNAME", "점검항목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHKTYPE", "값/판정구분", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STANDVALUE", "기준값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LSLVALUE", "하한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USLVALUE", "상한값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHKCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHKNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHKTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["STANDVALUE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["LSLVALUE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["USLVALUE"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE"); //점검기준
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHKTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //점검항목
                btbManager.PopUpAdd(txt_MACHKCODE_H, txt_MACHKNAME_H, "BM0465", new object[] { cbo_PLANTCODE_H, "" });

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
                string sMachkCode = DBHelper.nvlString(txt_MACHKCODE_H.Text.Trim());
                string sMachkName = DBHelper.nvlString(txt_MACHKNAME_H.Value);
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0465_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHKCODE", sMachkCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHKNAME", sMachkName, DbType.String, ParameterDirection.Input)
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
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["MACHKCODE"].Activation = Activation.NoEdit;

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

            this.grid1.DeleteRow(); //BM은 삭제기능 비활성화
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

                        if (Convert.ToString(drRow["MACHKNAME"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("점검항목명은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (DBHelper.nvlString(drRow["MACHKTYPE"]) == "")
                        {
                            this.ShowDialog(Common.getLangText("값/판정구분은 필수항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        //값/판정구분이 값일경우
                        if (DBHelper.nvlString(drRow["MACHKTYPE"]) != "J")
                        {
                            if (DBHelper.nvlString(drRow["STANDVALUE"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("기준값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["USLVALUE"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("상한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["LSLVALUE"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("하한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (Convert.ToDouble(drRow["USLVALUE"]) < Convert.ToDouble(drRow["STANDVALUE"]))
                            {
                                this.ShowDialog(Common.getLangText("상한값은 기준값보다 작을수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (Convert.ToDouble(drRow["LSLVALUE"]) > Convert.ToDouble(drRow["STANDVALUE"]))
                            {
                                this.ShowDialog(Common.getLangText("하한값은 기준값보다 클수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }
                        }
                        else
                        {
                            drRow["STANDVALUE"] = DBNull.Value;
                            drRow["USLVALUE"] = DBNull.Value;
                            drRow["LSLVALUE"] = DBNull.Value;
                        }

                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM0465_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MACHKCODE", Convert.ToString(drRow["MACHKCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0465_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHKNAME", DBHelper.nvlString(drRow["MACHKNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHKTYPE", DBHelper.nvlString(drRow["MACHKTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_STANDVALUE", drRow["STANDVALUE"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_LSLVALUE", drRow["LSLVALUE"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_USLVALUE", drRow["USLVALUE"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0465_U1"
                                                     , CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHKCODE", DBHelper.nvlString(drRow["MACHKCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHKNAME", DBHelper.nvlString(drRow["MACHKNAME"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHKTYPE", DBHelper.nvlString(drRow["MACHKTYPE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_STANDVALUE", drRow["STANDVALUE"], DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_LSLVALUE", drRow["LSLVALUE"], DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_USLVALUE", drRow["USLVALUE"], DbType.String, ParameterDirection.Input)
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

            BM0460_EXCEL BM0460_excel = new BM0460_EXCEL();
            BM0460_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            if (grid1.ActiveRow.Cells["MACHKTYPE"].Value.ToString() != "J")
            {
                grid1.ActiveRow.Cells["STANDVALUE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["USLVALUE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["LSLVALUE"].Activation = Activation.AllowEdit;
            }
            else
            {
                grid1.ActiveRow.Cells["STANDVALUE"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["USLVALUE"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["LSLVALUE"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["STANDVALUE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["USLVALUE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["LSLVALUE"].Activation = Activation.NoEdit;
            }
        }

        //GRID1 각종 구분별 컬럼 편집여부 결정
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.ActiveRow.Cells["MACHKTYPE"].Value.ToString() != "J")
            {
                grid1.ActiveRow.Cells["STANDVALUE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["USLVALUE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["LSLVALUE"].Activation = Activation.AllowEdit;
            }
            else
            {
                grid1.ActiveRow.Cells["STANDVALUE"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["USLVALUE"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["LSLVALUE"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["STANDVALUE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["USLVALUE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["LSLVALUE"].Activation = Activation.NoEdit;
            }
        }
        #endregion
    }
}