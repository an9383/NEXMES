#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0022
//   Form Name    : 품목마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-04
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목과 품목관련 기준정보 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;


using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0022 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        bool sAutoItemCode = false;
        #endregion

        #region < CONSTRUCTOR >
        public AP0022()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0022_Load(object sender, EventArgs e)
        {
            try
            {
                DBHelper helper = new DBHelper(true);

                bool Colvisible_DS = false;

                if (helper.DBConnect.Database.ToString() == "P2001") //대선주조
                {
                    Colvisible_DS = true;
                }

                #region GRID SETTING

                //grid1
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산계획번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "생산계획일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "생산계획일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTSEQ", "SEQ", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "SETQTY", "지시편성수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "WORKQTY", "작업수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLSTATE", "계획상태", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "URGENT", "긴급작업", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "FRAMEID", "프레임ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MASKID", "마스크ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);

                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);
                //grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLSTATE"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["ITEMTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["UNITCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);

                //콤보박스 셋팅
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("PLSTATE"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLSTATE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("URGENT");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "URGENT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //팝업 셋팅
                //btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "AP0022", new object[] { cbo_PLANTCODE_H, cbo_ITEMTYPE_H, cbo_USEFLAG_H });  // 품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });  // 품목

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
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());
                string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                rtnDtTemp = helper.FillTable("USP_AP0012_S7", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
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
            base.DoNew();
            //    this.grid1.InsertRow();
            //try
            //{
            //    base.DoNew();



            //    //사업장과 사용여부는 행 추가시 기본으로 세팅
            //    this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            //    this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

            //    if (sAutoItemCode)
            //    {
            //        this.grid1.ActiveRow.Cells["ITEMCODE"].Value = "[New Code]";
            //        this.grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
            //    }
            //    else
            //    {
            //        this.grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.AllowEdit;
            //    }

            //    //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
            //    grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            //    grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            //    grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
            //    grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
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
                        if (Convert.ToString(drRow["ITEMCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목은 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        //if (Convert.ToString(drRow["ITEMNAME"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("품명은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}
                        //if (Convert.ToString(drRow["ITEMTYPE"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("품목유형은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}
                        if (Convert.ToString(drRow["UNITCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("단위는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_AP0022_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            string sPlanNo = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANNO"].Text);
                            string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Text);
                            string sPlanQty = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANQTY"].Text);
                            string sPlanState = DBHelper.nvlString(grid1.ActiveRow.Cells["PLSTATE"].Text);
                            helper.ExecuteNoneQuery("USP_AP0012_U1"
                                                     , CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_PLANNO", DBHelper.nvlString(drRow["PLANNO"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_PLANQTY", DBHelper.nvlString(drRow["PLANQTY"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_PLSTATE", DBHelper.nvlString(drRow["PLSTATE"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_URGENT", DBHelper.nvlString(drRow["URGENT"]), DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_USER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    );
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

            //AP0022_EXCEL AP0022_excel = new AP0022_EXCEL();
            //AP0022_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion
    }
}