#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0070
//   Form Name    : 설비마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-05
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 설비정보 관리
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
    public partial class BM0070 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0070()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0070_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 품목
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHTYPE", "설비타입", true, GridColDataType_emu.VarChar, 180, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 150, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODFLAG", "실적수집\r\n장비여부", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델명", true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼번호", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "수명", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTACT", "연락처", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHCASE", "설비구분", true, GridColDataType_emu.VarChar, 100, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MACHLOC", "설치장소", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER1", "작업담당자-정", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER2", "작업담당자-부", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TECHWORKER", "장비기술담당자", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BUYDATE", "도입일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BUYCOST", "도입가격", true, GridColDataType_emu.Double, 100, 90, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "상태", true, GridColDataType_emu.VarChar, 80, 10, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종검사일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LIMITDATE", "유효일수", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "CAVITY", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DESIGNSHOT", "디자인쇼트", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKSHOT", "작업쇼트", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TOTSHOT", "전체쇼트", true, GridColDataType_emu.Integer, 80, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MOLDUSECNT", "금형사용횟수", true, GridColDataType_emu.Integer, 100, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LASTUSEDATE", "최종사용일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "FAILURFLAG", "고장실적등록\r\n사용여부", true, GridColDataType_emu.VarChar, 100, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPCYCLE", "설비점검주기", true, GridColDataType_emu.Integer, 100, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ALRAMCYCLE", "점검알람주기", true, GridColDataType_emu.Integer, 100, 80, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MACHCODE"].Header.Appearance.ForeColor = Color.SkyBlue;


                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("MACHTYPE"); //설비타입
                WIZ.Common.FillComboboxMaster(this.cbo_MACHTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MACHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRODFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FAILURFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");


                #endregion

                #region POPUP SETTING

                //설비
                btbManager.PopUpAdd(txt_MACHCODE_H, txt_MACHNAME_H, "BM0070", new object[] { cbo_PLANTCODE_H, "", "" });
                //작업장
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });

                BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성
                //작업장
                gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });

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
                string sWorkcenter = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());
                string sMachName = DBHelper.nvlString(txt_MACHNAME_H.Text.Trim());
                string sMachCode = DBHelper.nvlString(txt_MACHCODE_H.Text.Trim());
                string sMachType = DBHelper.nvlString(cbo_MACHTYPE_H.Value);
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0070_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenter, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHNAME", sMachName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHTYPE", sMachType, DbType.String, ParameterDirection.Input)
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
                this.grid1.ActiveRow.Cells["MACHCODE"].Value = Common.getLangText("자동채번", "TEXT");

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["MACHCODE"].Activation = Activation.NoEdit;
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
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM0070_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("MACHCODE", Convert.ToString(drRow["MACHCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0070_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHNAME", DBHelper.nvlString(drRow["MACHNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHTYPE", DBHelper.nvlString(drRow["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PRODFLAG", DBHelper.nvlString(drRow["PRODFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(drRow["MAKECOMPANY"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(drRow["MODELNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(drRow["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_LIFETIME", DBHelper.nvlString(drRow["LIFETIME"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(drRow["CONTACT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCASE", DBHelper.nvlString(drRow["MACHCASE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHLOC", DBHelper.nvlString(drRow["MACHLOC"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(drRow["MAWORKER1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(drRow["MAWORKER2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(drRow["TECHWORKER"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(drRow["BUYDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AF_BUYCOST", DBHelper.nvlString(drRow["BUYCOST"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(drRow["STATUS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPLASTDATE", DBHelper.nvlString(drRow["INSPLASTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(drRow["LIMITDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_CAVITY", DBHelper.nvlString(drRow["CAVITY"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_DESIGNSHOT", DBHelper.nvlString(drRow["DESIGNSHOT"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_WORKSHOT", DBHelper.nvlString(drRow["WORKSHOT"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_TOTSHOT", DBHelper.nvlString(drRow["TOTSHOT"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_MOLDUSECNT", DBHelper.nvlString(drRow["MOLDUSECNT"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LASTUSEDATE", DBHelper.nvlString(drRow["LASTUSEDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FAILURFLAG", DBHelper.nvlString(drRow["FAILURFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_INSPCYCLE", DBHelper.nvlString(drRow["INSPCYCLE"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_ALRAMCYCLE", DBHelper.nvlString(drRow["ALRAMCYCLE"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0070_U1"
                                                     , CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHCODE", DBHelper.nvlString(drRow["MACHCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHNAME", DBHelper.nvlString(drRow["MACHNAME"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHTYPE", DBHelper.nvlString(drRow["MACHTYPE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_PRODFLAG", DBHelper.nvlString(drRow["PRODFLAG"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(drRow["MAKECOMPANY"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(drRow["MODELNAME"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(drRow["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_LIFETIME", DBHelper.nvlString(drRow["LIFETIME"]), DbType.Int32, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(drRow["CONTACT"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHCASE", DBHelper.nvlString(drRow["MACHCASE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MACHLOC", DBHelper.nvlString(drRow["MACHLOC"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(drRow["MAWORKER1"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(drRow["MAWORKER2"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(drRow["TECHWORKER"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(drRow["BUYDATE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_BUYCOST", DBHelper.nvlString(drRow["BUYCOST"]), DbType.Double, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(drRow["STATUS"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_INSPLASTDATE", DBHelper.nvlString(drRow["INSPLASTDATE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(drRow["LIMITDATE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_CAVITY", DBHelper.nvlString(drRow["CAVITY"]), DbType.Int32, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_DESIGNSHOT", DBHelper.nvlString(drRow["DESIGNSHOT"]), DbType.Int32, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_WORKSHOT", DBHelper.nvlString(drRow["WORKSHOT"]), DbType.Int32, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_TOTSHOT", DBHelper.nvlString(drRow["TOTSHOT"]), DbType.Int32, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_MOLDUSECNT", DBHelper.nvlString(drRow["MOLDUSECNT"]), DbType.Int32, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_LASTUSEDATE", DBHelper.nvlString(drRow["LASTUSEDATE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_FAILURFLAG", DBHelper.nvlString(drRow["FAILURFLAG"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_INSPCYCLE", DBHelper.nvlString(drRow["INSPCYCLE"]), DbType.Int32, ParameterDirection.Input)
                                                     , helper.CreateParameter("AI_ALRAMCYCLE", DBHelper.nvlString(drRow["ALRAMCYCLE"]), DbType.Int32, ParameterDirection.Input)
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

            BM0070_EXCEL bm0070_excel = new BM0070_EXCEL();
            bm0070_excel.ShowDialog();

            base.DoInquire();

        }

        #endregion

        #region < EVENT AREA >
        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sMachCode = Convert.ToString(grid1.ActiveRow.Cells["MACHCODE"].Value);

                BM0071_POP BM0071_POP = new BM0071_POP(sPlantCode, sMachCode);
                BM0071_POP.ShowDialog();
            }
        }

        #endregion

    }
}