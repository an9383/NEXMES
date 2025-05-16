#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0030
//   Form Name    : 거래처마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-05
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 거래처와 협력사 기준정보 관리
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
    public partial class BM0030 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0030()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0030_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 품목
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTTYPE", "거래처구분", false, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTENAME", "업체명", false, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTOMER", "거래처\r\n주고객사", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BIZSTARTDATE", "거래시작일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BIZENDDATE", "거래종료일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BIZREQNO", "사업자\r\n등록번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CMPPOSTNO", "회사 우편번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BIZPOSTNO", "사업장\r\n우편번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BIZCLASS", "업태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BIZTYPE", "종목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CURNM", "통화단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CURNAME", "외환", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TAXTYPE", "세금유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TERM", "대금회수기간", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PHONE", "전화번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ADDRESS", "주소", false, GridColDataType_emu.VarChar, 330, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ASGNNAME", "담당자 이름", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ASGNPSTN", "담당자 직위", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ASGNFAXNO", "담당자\r\nFAX번호", false, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ASGNSPHONE", "담당자\r\n휴대폰번호", false, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "OUTCOSTFLAG", "유상사급유무", false, GridColDataType_emu.VarChar, 50, 50, Infragistics.Win.HAlign.Left, false, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime, 130, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["CUSTTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;


                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("CUSTTYPE"); //거래처유형
                WIZ.Common.FillComboboxMaster(this.cbo_CUSTTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CUSTTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("CURNM"); //통화유형
                WIZ.Common.FillComboboxMaster(this.cbo_TAXTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CURNM", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("TAXTYPE"); //품목유형
                WIZ.Common.FillComboboxMaster(this.cbo_TAXTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TAXTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //거래처
                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "" });

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
                string sCustCode = DBHelper.nvlString(txt_CUSTCODE_H.Text.Trim());
                string sCustName = DBHelper.nvlString(txt_CUSTNAME_H.Text.Trim());
                string sCustType = DBHelper.nvlString(cbo_CUSTTYPE_H.Value);
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0030_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTTYPE", sCustType, DbType.String, ParameterDirection.Input)
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
                this.grid1.ActiveRow.Cells["CUSTCODE"].Value = Common.getLangText("자동채번", "TEXT");

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
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
                        if (Convert.ToString(drRow["CUSTTYPE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("거래처구분은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            //drRow.RejectChanges();

                            //helper.ExecuteNoneQuery("USP_BM0030_D1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0030_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTTYPE", DBHelper.nvlString(drRow["CUSTTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTNAME", DBHelper.nvlString(drRow["CUSTNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTENAME", DBHelper.nvlString(drRow["CUSTENAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTOMER", DBHelper.nvlString(drRow["CUSTOMER"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZSTARTDATE", DBHelper.nvlString(drRow["BIZSTARTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZENDDATE", DBHelper.nvlString(drRow["BIZENDDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZREQNO", DBHelper.nvlString(drRow["BIZREQNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CMPPOSTNO", DBHelper.nvlString(drRow["CMPPOSTNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZPOSTNO", DBHelper.nvlString(drRow["BIZPOSTNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZCLASS", DBHelper.nvlString(drRow["BIZCLASS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BIZTYPE", DBHelper.nvlString(drRow["BIZTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CURNM", DBHelper.nvlString(drRow["CURNM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAXTYPE", DBHelper.nvlString(drRow["TAXTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TERM", DBHelper.nvlDouble(drRow["TERM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PHONE", DBHelper.nvlString(drRow["PHONE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ADDRESS", DBHelper.nvlString(drRow["ADDRESS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNNAME", DBHelper.nvlString(drRow["ASGNNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNPSTN", DBHelper.nvlString(drRow["ASGNPSTN"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNFAXNO", DBHelper.nvlString(drRow["ASGNFAXNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ASGNSPHONE", DBHelper.nvlString(drRow["ASGNSPHONE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OUTCOSTFLAG", DBHelper.nvlString(drRow["OUTCOSTFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0030_U1"
                                                     , CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_CUSTTYPE", DBHelper.nvlString(drRow["CUSTTYPE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_CUSTNAME", DBHelper.nvlString(drRow["CUSTNAME"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_CUSTENAME", DBHelper.nvlString(drRow["CUSTENAME"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_CUSTOMER", DBHelper.nvlString(drRow["CUSTOMER"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_BIZSTARTDATE", DBHelper.nvlString(drRow["BIZSTARTDATE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_BIZENDDATE", DBHelper.nvlString(drRow["BIZENDDATE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_BIZREQNO", DBHelper.nvlString(drRow["BIZREQNO"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_CMPPOSTNO", DBHelper.nvlString(drRow["CMPPOSTNO"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_BIZPOSTNO", DBHelper.nvlString(drRow["BIZPOSTNO"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_BIZCLASS", DBHelper.nvlString(drRow["BIZCLASS"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_BIZTYPE", DBHelper.nvlString(drRow["BIZTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CURNM", DBHelper.nvlString(drRow["CURNM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAXTYPE", DBHelper.nvlString(drRow["TAXTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TERM", DBHelper.nvlDouble(drRow["TERM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PHONE", DBHelper.nvlString(drRow["PHONE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ADDRESS", DBHelper.nvlString(drRow["ADDRESS"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ASGNNAME", DBHelper.nvlString(drRow["ASGNNAME"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ASGNPSTN", DBHelper.nvlString(drRow["ASGNPSTN"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ASGNFAXNO", DBHelper.nvlString(drRow["ASGNFAXNO"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ASGNSPHONE", DBHelper.nvlString(drRow["ASGNSPHONE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_OUTCOSTFLAG", DBHelper.nvlString(drRow["OUTCOSTFLAG"]), DbType.String, ParameterDirection.Input)
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

            BM0030_EXCEL bm0030_excel = new BM0030_EXCEL();
            bm0030_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion
    }
}