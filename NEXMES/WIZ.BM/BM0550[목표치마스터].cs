#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0550
//   Form Name    : 목표치마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 목표치 관리
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
    public partial class BM0550 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0550()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0550_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 목표치관리
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "INDEXNO", "순번", true, GridColDataType_emu.Integer, 60, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TARGETTYPE", "목표치구분", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TARGETCLASS", "폭표치유형", true, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "부서", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BANCODE", "반", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TEAMCODE", "팀", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M01", "1월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M02", "2월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M03", "3월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M04", "4월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M05", "5월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M06", "6월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M07", "7월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M08", "8월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M09", "9월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M10", "10월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M11", "11월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "M12", "12월", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MTOT", "월합계", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAVG", "월평균", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Y00", "년목표치", true, GridColDataType_emu.Double, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["INDEXNO"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("TARGETTYPE"); //목표치구분
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TARGETTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("TARGETCLASS"); //목표치유형
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TARGETCLASS", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE"); //부서
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("BANCODE"); //반
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BANCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("TEAMCODE"); //팀
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TEAMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });

                BizGridManager gridManager = new BizGridManager(grid1);
                //품목
                gridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });
                //공정
                gridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });
                //라인
                gridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "OPCODE", "Y" });
                //작업장
                gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "OPCODE", "LINECODE", "Y" });

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
                string sIndexNo = DBHelper.nvlString(txt_INDEXNO_H.Text.Trim());
                string sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0550_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INDEXNO", sIndexNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
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
                grid1.ActiveRow.Cells["INDEXNO"].Activation = Activation.NoEdit;
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
                            helper.ExecuteNoneQuery("USP_BM0550_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TARGETTYPE", DBHelper.nvlString(drRow["TARGETTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TARGETCLASS", DBHelper.nvlString(drRow["TARGETCLASS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LINECODE", DBHelper.nvlString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DEPTCODE", DBHelper.nvlString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BANCODE", DBHelper.nvlString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TEAMCODE", DBHelper.nvlString(drRow["TEAMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M01", DBHelper.nvlString(drRow["M01"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M02", DBHelper.nvlString(drRow["M02"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M03", DBHelper.nvlString(drRow["M03"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M04", DBHelper.nvlString(drRow["M04"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M05", DBHelper.nvlString(drRow["M05"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M06", DBHelper.nvlString(drRow["M06"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M07", DBHelper.nvlString(drRow["M07"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M08", DBHelper.nvlString(drRow["M08"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M09", DBHelper.nvlString(drRow["M09"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M10", DBHelper.nvlString(drRow["M10"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M11", DBHelper.nvlString(drRow["M11"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M12", DBHelper.nvlString(drRow["M12"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_Y00", DBHelper.nvlString(drRow["Y00"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0550_U1"
                                                   , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AI_INDEXNO", DBHelper.nvlString(drRow["INDEXNO"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TARGETTYPE", DBHelper.nvlString(drRow["TARGETTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TARGETCLASS", DBHelper.nvlString(drRow["TARGETCLASS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OPCODE", DBHelper.nvlString(drRow["OPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LINECODE", DBHelper.nvlString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DEPTCODE", DBHelper.nvlString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BANCODE", DBHelper.nvlString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TEAMCODE", DBHelper.nvlString(drRow["TEAMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M01", DBHelper.nvlString(drRow["M01"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M02", DBHelper.nvlString(drRow["M02"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M03", DBHelper.nvlString(drRow["M03"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M04", DBHelper.nvlString(drRow["M04"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M05", DBHelper.nvlString(drRow["M05"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M06", DBHelper.nvlString(drRow["M06"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M07", DBHelper.nvlString(drRow["M07"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M08", DBHelper.nvlString(drRow["M08"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M09", DBHelper.nvlString(drRow["M09"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M10", DBHelper.nvlString(drRow["M10"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M11", DBHelper.nvlString(drRow["M11"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_M12", DBHelper.nvlString(drRow["M12"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_Y00", DBHelper.nvlString(drRow["Y00"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
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

            BM0550_EXCEL bm0550_excel = new BM0550_EXCEL();
            bm0550_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion
    }
}