#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0680
//   Form Name    : 금형 마스터
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형 마스터
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
    public partial class BM0680 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public BM0680()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0680_Load(object sender, EventArgs e)
        {
            #region GRID SETTING 
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSEQ", "금형순번", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHCODE", "설비", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MACHNAME", "설비명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE", "금형타입", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE1", "분류1", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDTYPE2", "분류2", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDWH", "창고코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDWHNAME", "창고명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDLOC", "위치코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDLOCNAME", "위치명", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKECOMPANY", "제조사", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MODELNAME", "모델명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALNO", "시리얼번호", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LIFETIME", "수명", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTACT", "연락처", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER1", "작업담당자1", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAWORKER2", "작업담당자2", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TECHWORKER", "장비기술담당자", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYDATE", "도입일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BUYCOST", "도입가격", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "상태", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPLASTDATE", "최종검사일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "LIMITDATE", "유효일자", true, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CAVITY", "CAVITY", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DESIGNSHOT", "설계쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OVERMNGCNT", "관리쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDSUMCNT", "누적쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDUSECNT", "현재쇼트수", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDGRADE", "금형등급", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTUSEDATE", "최종사용일자", true, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", true, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", true, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["MOLDCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion


            #region COMBOBOX SETTING 

            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDSTATE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDGRADE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MOLDGRADE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP SETTING
            btbManager.PopUpAdd(txt_MOLDCODE_H, txt_MOLDNAME_H, "BM0680", new object[] { cbo_PLANTCODE_H, cbo_USEFLAG_H });
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });  // 품목

            //btbManager.PopUpAdd(txt_MOLDWHCODE_H, txt_MOLDWHNAME_H, "MD0020", new object[] { cbo_PLANTCODE_H, "", cbo_USEFLAG_H });
            //btbManager.PopUpAdd(txt_MOLDLOCCODE_H, txt_MOLDLOCNAME_H, "MD0030", new object[] { cbo_PLANTCODE_H, txt_MOLDWHCODE_H, txt_MOLDWHNAME_H, "N", cbo_USEFLAG_H });

            BizGridManager bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });
            bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "BM0030", new string[] { "PLANTCODE", "", "Y" });
            bizGridManager.PopUpAdd("MACHCODE", "MACHNAME", "BM0070", new string[] { "PLANTCODE", "", "Y" });
            //bizGridManager.PopUpAdd("MOLDWHCODE", "MOLDWHNAME", "MD0020", new string[] { "PLANTCODE", "", "Y" });
            //bizGridManager.PopUpAdd("MOLDLOCCODE", "MOLDLOCNAME", "MD0030", new string[] { "PLANTCODE", "MOLDWHCODE", "MOLDWHNAME", "Y", "Y" });

            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sMoldCode = txt_MOLDCODE_H.Text.Trim();
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sMoldWhCode = txt_MOLDWHCODE_H.Text.Trim();
                string sMoldLocCode = txt_MOLDLOCCODE_H.Text.Trim();
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0680_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MOLDCODE", sMoldCode, DbType.String, ParameterDirection.Input)
                                                            //, helper.CreateParameter("AS_MOLDWHCODE",  sMoldWhCode,  DbType.String, ParameterDirection.Input)
                                                            //, helper.CreateParameter("AS_MOLDLOCCODE", sMoldLocCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                            );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    SetRowColor();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

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
                grid1.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MOLDGRADE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["LASTUSEDATE"].Activation = Activation.NoEdit;
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

                        if (Convert.ToString(drRow["MOLDCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("금형코드는 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (Convert.ToString(drRow["USEFLAG"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사용여부는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
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
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0680_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDNAME", DBHelper.nvlString(drRow["MOLDNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCODE", DBHelper.nvlString(drRow["MACHCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE", DBHelper.nvlString(drRow["MOLDTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE1", DBHelper.nvlString(drRow["MOLDTYPE1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE2", DBHelper.nvlString(drRow["MOLDTYPE2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDWHCODE", DBHelper.nvlString(drRow["MOLDWH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDLOCCODE", DBHelper.nvlString(drRow["MOLDLOC"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(drRow["MAKECOMPANY"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(drRow["MODELNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(drRow["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIFETIME", DBHelper.nvlString(drRow["LIFETIME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(drRow["CONTACT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(drRow["MAWORKER1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(drRow["MAWORKER2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(drRow["TECHWORKER"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(drRow["BUYDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYCOST", DBHelper.nvlString(drRow["BUYCOST"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(drRow["STATUS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPLASTDATE", DBHelper.nvlString(drRow["INSPLASTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(drRow["LIMITDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CAVITY", DBHelper.nvlString(drRow["CAVITY"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DESIGNSHOT", DBHelper.nvlString(drRow["DESIGNSHOT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OVERMNGCNT", DBHelper.nvlString(drRow["OVERMNGCNT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDSUMCNT", DBHelper.nvlString(drRow["MOLDSUMCNT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDUSECNT", DBHelper.nvlString(drRow["MOLDUSECNT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM0680_U1"
                                                     , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDSEQ", DBHelper.nvlString(drRow["MOLDSEQ"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDNAME", DBHelper.nvlString(drRow["MOLDNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MACHCODE", DBHelper.nvlString(drRow["MACHCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE", DBHelper.nvlString(drRow["MOLDTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE1", DBHelper.nvlString(drRow["MOLDTYPE1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDTYPE2", DBHelper.nvlString(drRow["MOLDTYPE2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDWH", DBHelper.nvlString(drRow["MOLDWH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDLOC", DBHelper.nvlString(drRow["MOLDLOC"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKECOMPANY", DBHelper.nvlString(drRow["MAKECOMPANY"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MODELNAME", DBHelper.nvlString(drRow["MODELNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SERIALNO", DBHelper.nvlString(drRow["SERIALNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIFETIME", DBHelper.nvlString(drRow["LIFETIME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTACT", DBHelper.nvlString(drRow["CONTACT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER1", DBHelper.nvlString(drRow["MAWORKER1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAWORKER2", DBHelper.nvlString(drRow["MAWORKER2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TECHWORKER", DBHelper.nvlString(drRow["TECHWORKER"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYDATE", DBHelper.nvlString(drRow["BUYDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BUYCOST", DBHelper.nvlString(drRow["BUYCOST"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STATUS", DBHelper.nvlString(drRow["STATUS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LIMITDATE", DBHelper.nvlString(drRow["LIMITDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CAVITY", DBHelper.nvlString(drRow["CAVITY"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DESIGNSHOT", DBHelper.nvlString(drRow["DESIGNSHOT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OVERMNGCNT", DBHelper.nvlString(drRow["OVERMNGCNT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDSUMCNT", DBHelper.nvlString(drRow["MOLDSUMCNT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDUSECNT", DBHelper.nvlString(drRow["MOLDUSECNT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
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

        public override void DoImportExcel()
        {
            base.DoImportExcel();

            BM0680_EXCEL BM0680_EXCEL = new BM0680_EXCEL();
            BM0680_EXCEL.ShowDialog();

            base.DoInquire();
        }


        #endregion

        #region < METHOD AREA >

        private void SetRowColor()
        {
            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToString(grid1.Rows[i].Cells["MOLDGRADE"].Value) == "A")
                    grid1.Rows[i].Appearance.BackColor = Color.WhiteSmoke;
                else if (Convert.ToString(grid1.Rows[i].Cells["MOLDGRADE"].Value) == "B")
                    grid1.Rows[i].Appearance.BackColor = Color.Green;
                else if (Convert.ToString(grid1.Rows[i].Cells["MOLDGRADE"].Value) == "C")
                    grid1.Rows[i].Appearance.BackColor = Color.Orange;
                else if (Convert.ToString(grid1.Rows[i].Cells["MOLDGRADE"].Value) == "D")
                    grid1.Rows[i].Appearance.BackColor = Color.Red;
                else
                    grid1.Rows[i].Appearance.BackColor = Color.WhiteSmoke;
            }
        }

        #endregion
    }
}
