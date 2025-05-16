#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM2130
//   Form Name    : 수입검사등록 관리자
//   Name Space   : WIZ.BM
//   Created Date : 2019-10-16
//   Made By      : WIZCORE 양현모
//   Edited Date  : 
//   Edit By      :
//   Description  : 수입검사 등록 및 수량 자동 분할
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM2130 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;
        bool bPop2 = false;
        #endregion

        #region < CONSTRUCTOR >
        public MM2130()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM2130_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 품목
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid1, "SAVEBUTTON", "입고", true, GridColDataType_emu.Button, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "바코드", true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCNT", "수량", true, GridColDataType_emu.Integer, 140, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고위치", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장소위치", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "진행여부", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["LOTNO"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCNT"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                ////콤보박스 셋팅
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE"); //품목유형
                //WIZ.Common.FillComboboxMaster(this.cbo_ITEMTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                //WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("INSPTYPE"); //수입검사여부               
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                BizGridManager bizGridManager = new BizGridManager(grid1);
                bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "", "Y" });
                bizGridManager.PopUpAdd("PONO", "PONO", "MM0020", new string[] { "PLANTCODE", "", "" });

                // grid 입력용 POPUP
                BizGridManager bizGridManager2 = new BizGridManager(grid1);
                //bizGridManager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "4", "" });
                //bizGridManager.PopUpAdd("CUSTCODE", "CUSTNAME", "BM0030", new string[] { "PLANTCODE", "VD", "" });
                bizGridManager2.PopUpAdd("CUSTCODE2", "CUSTNAME2", "BM0030", new string[] { "PLANTCODE", "VD", "" });

                GetWhCode();
                cboWhCode_SelectedValueChanged("WH0001");
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

                rtnDtTemp = helper.FillTable("USP_MM2130_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                //, helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }

                //for (int i = 0; i < grid1.Rows.Count; i++)
                //{
                //    string sFFlag = Convert.ToString(grid1.Rows[i].Cells["USEFLAG"].Value);

                //    if (sFFlag == "Y" )
                //    {
                //        grid1.Rows[i].Cells["SAVEBUTTON"].Activation = Activation.AllowEdit;
                //        //grid1.Rows[i].Cells["UNITBUTTON"].Activation = Activation.NoEdit;
                //        grid1.Rows[i].Activation = Activation.AllowEdit;

                //    }
                //    else
                //    {
                //        grid1.Rows[i].Cells["SAVEBUTTON"].Activation = Activation.NoEdit;
                //        grid1.Rows[i].Activation = Activation.NoEdit;
                //    }
                //}
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
                        if (Convert.ToString(drRow["ITEMNAME"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품명은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["ITEMCNT"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목수량은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["LOTNO"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("바코드는 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            //drRow.RejectChanges();

                            //helper.ExecuteNoneQuery("USP_MM2130_D1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_PLANTCODE",       DBHelper.nvlString(drRow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_ITEMCODE",        DBHelper.nvlString(drRow["ITEMCODE"]),   DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_MM2130_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PONO", DBHelper.nvlString(drRow["PONO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LOTNO", DBHelper.nvlString(drRow["LOTNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WHCODE", DBHelper.nvlString(drRow["WHCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STORAGELOCCODE", DBHelper.nvlString(drRow["STORAGELOCCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCNT", DBHelper.nvlString(drRow["ITEMCNT"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_RESULT", "OK", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LASTFLAG", "Y", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_MM2130_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PONO", DBHelper.nvlString(drRow["PONO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LOTNO", DBHelper.nvlString(drRow["LOTNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WHCODE", DBHelper.nvlString(drRow["WHCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STORAGELOCCODE", DBHelper.nvlString(drRow["STORAGELOCCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCNT", DBHelper.nvlString(drRow["ITEMCNT"]), DbType.Int32, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_RESULT", "OK", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LASTFLAG", "Y", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));
                            //, helper.CreateParameter("AD_EDITDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
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

            //MM2130_EXCEL MM2130_excel = new MM2130_EXCEL();
            //MM2130_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        private DataTable USP_PDA_GETWHCODE(string sWhType, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_GETWHCODE"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        private void GetWhCode()
        {
            try
            {
                DataTable _dt = new DataTable();
                _dt = USP_PDA_GETWHCODE("WH001", ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        //WIZ.Common.FillComboboxMaster(this.grid1, _dt, "WHCODE", "WHNAME", "선택하세요", "");
                        WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", _dt, "WHCODE", "WHNAME");
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("[창고 조회] 창고 정보를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    }
                }
                else if (RS_CODE == "E")
                {
                    this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + RS_MSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[창고 조회] ", "MSG") + ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #region 창고선택후 저장소선택
        private void cboWhCode_SelectedValueChanged(string sWhCode)
        {
            try
            {
                // string sWhCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WHCODE"].Value);
                if (sWhCode == string.Empty || sWhCode == null) sWhCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WHCODE"].Value);
                DataTable _dt = new DataTable();
                _dt = USP_PDA_GETSTORAGECODE(sWhCode, ref RS_CODE, ref RS_MSG);

                if (RS_CODE == "S")
                {
                    //WIZ.Common.FillComboboxMaster(cboStorage, _dt, "STORAGELOCCODE", "STORAGELOCNAME", "선택하세요", "");
                    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", _dt, "STORAGELOCCODE", "STORAGELOCNAME");
                }
                else if (RS_CODE == "E")
                {
                    this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + RS_MSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("[창고 위치 조회] ", "MSG") + ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion
        #region 저장소 가져오기
        private DataTable USP_PDA_GETSTORAGECODE(string sWhCode, ref string RS_CODE, ref string RS_MSG)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PDA_GETSTORAGECODE"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input));

                RS_CODE = Convert.ToString(helper.RSCODE);
                RS_MSG = Convert.ToString(helper.RSMSG);

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                RS_CODE = "E";
                RS_MSG = ex.Message.ToString();
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
        #endregion

        private void btn_itemDivision_Click(object sender, EventArgs e)
        {
            string tPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string tLotNo = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTNO"].Value);
            string tItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string tItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            string tWhCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WHCODE"].Value);
            string tStorageCode = DBHelper.nvlString(grid1.ActiveRow.Cells["STORAGELOCCODE"].Value);
            int tCnt = DBHelper.nvlInt(grid1.ActiveRow.Cells["ITEMCNT"].Value);
            int tItemCnt = 0;

            if (tLotNo == "")
            {
                this.ShowDialog("바코드를 입력해 주세요.", Forms.DialogForm.DialogType.OK);
                return;
            }
            if (tItemCode == "")
            {
                this.ShowDialog("품목을 입력해 주세요.", Forms.DialogForm.DialogType.OK);
                return;
            }
            if (tCnt < 1)
            {
                this.ShowDialog("품목수량을 입력해 주세요.", Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper(false);

            rtnDtTemp = helper.FillTable("USP_BM0010_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", tPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", tItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", tItemName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMTYPE", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", "Y", DbType.String, ParameterDirection.Input));
            if (rtnDtTemp.Rows.Count > 0)
            {
                DataRow[] rows = rtnDtTemp.Select();

                // Print the value one column of each DataRow.
                for (int i = 0; i < rows.Length; i++)
                {
                    tItemCnt = DBHelper.nvlInt(rows[i]["UNITPACK"]); // 포장단위 개수
                }
            }
            if (tItemCnt < 1)
            {
                this.ShowDialog("포장단위 수량이 없습니다. 품목마스터에 수량설정이 필요합니다.", Forms.DialogForm.DialogType.OK);
                return;
            }
            this.grid1.DeleteRow();
            int tmpCnt = tCnt / tItemCnt; // LOT 개수
            int tmpCnt2 = tCnt % tItemCnt; // 나머지 개수
            int t = 0;
            for (int i = 0; i < tmpCnt; i++)
            {
                try
                {
                    base.DoNew();

                    this.grid1.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid1.ActiveRow.Cells["LOTNO"].Value = tLotNo + "-" + string.Format("{0:D3}", i + 1);
                    this.grid1.ActiveRow.Cells["ITEMCODE"].Value = tItemCode;
                    this.grid1.ActiveRow.Cells["ITEMNAME"].Value = tItemName;
                    this.grid1.ActiveRow.Cells["ITEMCNT"].Value = tItemCnt;
                    this.grid1.ActiveRow.Cells["WHCODE"].Value = tWhCode;
                    this.grid1.ActiveRow.Cells["STORAGELOCCODE"].Value = tStorageCode;
                    //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                    grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
                    t++;
                }
                catch (Exception ex)
                {
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
            }

            if (tmpCnt2 > 0)
            {
                try
                {
                    base.DoNew();

                    this.grid1.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid1.ActiveRow.Cells["LOTNO"].Value = tLotNo + "-" + string.Format("{0:D3}", t + 1);
                    this.grid1.ActiveRow.Cells["ITEMCODE"].Value = tItemCode;
                    this.grid1.ActiveRow.Cells["ITEMNAME"].Value = tItemName;
                    this.grid1.ActiveRow.Cells["ITEMCNT"].Value = tmpCnt2;
                    this.grid1.ActiveRow.Cells["WHCODE"].Value = tWhCode;
                    this.grid1.ActiveRow.Cells["STORAGELOCCODE"].Value = tStorageCode;
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
        }

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            string sUseFlag = string.Empty;
            string sPoNo = string.Empty;
            string sItemCode = string.Empty;

            try
            {
                sUseFlag = Convert.ToString(e.Cell.Row.Cells["USEFLAG"].Value);

                if (e.Cell.Column.ToString() == "SAVEBUTTON")
                {
                    if (sUseFlag == "Y" || sUseFlag == "I")
                    {
                        sPoNo = Convert.ToString(e.Cell.Row.Cells["PONO"].Value);

                        DataTable dtTarget = ((DataTable)this.grid1.DataSource);
                        DataRow[] drRow = dtTarget.Select("PONO = '" + sPoNo + "'");

                        if (bPop2)
                        {
                            MM0000_POP4 mm0000_pop = new MM0000_POP4(drRow[0], subData["RELCODE1"] != "", subData["RELCODE2"]);
                            mm0000_pop.ShowDialog();
                        }
                        else
                        {
                            MM0000_POP3 mm0000_pop = new MM0000_POP3(drRow[0]);
                            mm0000_pop.ShowDialog();
                        }

                        this.DoInquire();
                    }
                }

                string strQty = string.Empty;
                if (e.Cell.Column.ToString() == "UNITBUTTON")
                {
                    if (sUseFlag == "")
                    {
                        sItemCode = Convert.ToString(e.Cell.Row.Cells["ITEMCODE"].Value);
                        DataTable dtTarget = ((DataTable)this.grid1.DataSource);
                        DataRow[] drRow = dtTarget.Select("ITEMCODE = '" + sItemCode + "'");

                        if (string.IsNullOrEmpty(sItemCode))
                        {
                            this.ShowDialog(Common.getLangText("품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        MM0000_POP_UNIT mm0000_pop_unit = new MM0000_POP_UNIT(drRow[0]);
                        mm0000_pop_unit.ShowDialog();
                        strQty = mm0000_pop_unit.m_strQty;
                        e.Cell.Row.Cells["POQTY"].Value = strQty;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }

        private void grid1_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString() == "PLANINDATE")
                {
                    //입고예정일 선택일 경우..
                    if (Convert.ToString(e.Cell.Row.Cells["PODATE"].Value) == string.Empty)
                    {
                        //발주일자가 없을 경우..현재 일자를 셋팅해준다.
                        e.Cell.Row.Cells["PODATE"].Value = DateTime.Now;
                    }
                    else
                    {
                        //발주일자가 있을 경우..
                        //발주일자보다 빠른일자를 선택하였을 경우..
                        string sPoOrderDate = Convert.ToString(e.Cell.Row.Cells["PODATE"].Text).Replace("-", "");
                        string sPlanInDate = e.Cell.Text.Replace("-", "");

                        if (sPlanInDate == "________") return;

                        if (Convert.ToInt32(sPoOrderDate) > Convert.ToInt32(sPlanInDate))
                        {
                            this.ShowDialog(Common.getLangText("발주일자 이전의 날짜를 선택 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            e.Cell.Value = e.Cell.OriginalValue;

                        }
                    }
                }
                else if (e.Cell.Column.ToString() == "PODATE")
                {
                    //발주일자 선택일 경우..
                    if (Convert.ToString(e.Cell.Row.Cells["PLANINDATE"].Value) == string.Empty)
                        return;
                    else
                    {
                        string sPoOrderDate = e.Cell.Text.Replace("-", "");
                        string sPlanInDate = Convert.ToString(e.Cell.Row.Cells["PLANINDATE"].Text).Replace("-", "");

                        if (sPoOrderDate == "________") return;

                        if (Convert.ToInt32(sPoOrderDate) > Convert.ToInt32(sPlanInDate))
                        {
                            this.ShowDialog(Common.getLangText("입고예정일자 이후의 날짜를 선택 할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            e.Cell.Value = e.Cell.OriginalValue;
                            e.Cell.Row.Cells["PLANINDATE"].Value = e.Cell.Value;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "ITEMCODE")
            {
                return;
            }

            grid1.ActiveRow.Cells["ITEMTYPE"].Value = string.Empty;

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);

                rtnDtTemp = helper.FillTable("USP_MM0000_S4", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.ActiveRow.Cells["ITEMTYPE"].Value = rtnDtTemp.Rows[0]["ITEMTYPE"].ToString();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void grid1_AfterCellListCloseUp2(object sender, CellEventArgs e)
        {
            string key = e.Cell.Column.Key;
            string value = DBHelper.nvlString(e.Cell.Value);
            if (key == "WHCODE")
            {
                cboWhCode_SelectedValueChanged(null);
            }
        }

        #region 프린트 출력
        private void SendPrint(string sPlantCode, string sPoNo, string sLotno, string sRemark)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_MM0010_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_LOTNO", sLotno, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    //openSerial();

                    //if (!serialPort1.IsOpen)
                    //    return;

                    System.Threading.Thread.Sleep(500);

                    StringBuilder command = new StringBuilder();

                    command.AppendLine("^XA");
                    command.AppendLine("^LH0,0^LL500^XZ");
                    command.AppendLine("^XA");
                    command.AppendLine("^SEE:UHANGUL.DAT^FS");
                    command.AppendLine("^CW1,E:KFONT3.FNT^CI26^FS");


                    command.AppendLine("^FO" + "15, 30" + "^GB" + "680, 920, 3" + "^FS"); //전체 박스

                    command.AppendLine("^FO" + "140, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 1
                    command.AppendLine("^FO" + "300, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 2
                    command.AppendLine("^FO" + "360, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 3
                    command.AppendLine("^FO" + "420, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 4
                    command.AppendLine("^FO" + "480, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 5
                    command.AppendLine("^FO" + "540, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 6
                    command.AppendLine("^FO" + "600, 30" + "^GB" + "1, 920, 2" + "^FS"); //세로줄 7

                    command.AppendLine("^FO" + "15,  220" + "^GB" + "125, 1, 2" + "^FS"); //가로줄 1
                    command.AppendLine("^FO" + "300, 220" + "^GB" + "300, 1, 2" + "^FS"); //가로줄 2
                    command.AppendLine("^FO" + "300, 485" + "^GB" + "60,  1, 2" + "^FS"); //가로줄 3
                    command.AppendLine("^FO" + "480, 485" + "^GB" + "120, 1, 2" + "^FS"); //가로줄 4
                    command.AppendLine("^FO" + "300, 690" + "^GB" + "60,  1, 2" + "^FS"); //가로줄 5
                    command.AppendLine("^FO" + "480, 690" + "^GB" + "120, 1, 2" + "^FS"); //가로줄 6

                    command.AppendLine("^FO" + "625, 45" + "^A1R, 40, 40" + " ^FD" + "원자재 식별표" + "^FS");
                    command.AppendLine("^FO" + "625, 740" + "^A1R, 40, 40" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["PLANTNAME"]) + "^FS");

                    command.AppendLine("^FO" + "555, 70" + "^A1R, 30, 30" + " ^FD" + "LOT No" + "^FS");
                    command.AppendLine("^FO" + "555, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]) + "^FS");

                    command.AppendLine("^FO" + "555, 515" + "^A1R, 30, 30" + " ^FD" + "가입고일자" + "^FS");
                    command.AppendLine("^FO" + "555, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["TMPINDATE"]) + "^FS");

                    command.AppendLine("^FO" + "495, 70" + "^A1R, 30, 30" + " ^FD" + "품목유형" + "^FS");
                    command.AppendLine("^FO" + "495, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMTYPE"]) + "^FS");

                    command.AppendLine("^FO" + "495, 530" + "^A1R, 30, 30" + " ^FD" + "수    량" + "^FS");
                    command.AppendLine("^FO" + "495, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTBASEQTY"]) + "^FS");

                    command.AppendLine("^FO" + "435, 70" + "^A1R, 30, 30" + " ^FD" + "품목코드" + "^FS");
                    command.AppendLine("^FO" + "435, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]) + "^FS");

                    command.AppendLine("^FO" + "375, 70" + "^A1R, 30, 30" + " ^FD" + "품 목 명" + "^FS");

                    if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 30)
                        command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                    else if (Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]).Length < 60)
                        command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");
                    else
                        command.AppendLine("^FO" + "375, 230" + "^A1R, 30, 20" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]) + "^FS");


                    command.AppendLine("^FO" + "315, 70" + "^A1R, 30, 30" + " ^FD" + "발주번호" + "^FS");
                    command.AppendLine("^FO" + "315, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["PONO"]) + "^FS");

                    command.AppendLine("^FO" + "315, 530" + "^A1R, 30, 30" + " ^FD" + "업 체 명" + "^FS");
                    command.AppendLine("^FO" + "315, 700" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["CUSTNAME"]) + "^FS");

                    command.AppendLine("^FO" + "190, 210" + "^BY3,4^BCR," + "80,Y,N,N" + "^FD" + Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]) + "^FS");

                    command.AppendLine("^FO" + "60, 65" + "^A1R, 30, 30" + " ^FD" + "비    고" + "^FS");
                    command.AppendLine("^FO" + "60, 230" + "^A1R, 30, 30" + " ^FD" + Convert.ToString(rtnDtTemp.Rows[0]["REMARK"]) + "^FS");

                    command.AppendLine("^XZ");

                    WIZ.Common.SendStringToBytePrinter("ZT410", command.ToString());

                    //byte[] b = Encoding.Default.GetBytes(command.ToString());
                    //serialPort1.Write(b, 0, b.Length);

                    DBHelper helper2 = new DBHelper("", true);
                    string RS_MSG = string.Empty;
                    string RS_CODE = string.Empty;

                    try
                    {
                        helper2.ExecuteNoneQuery("USP_MM0010_U1", CommandType.StoredProcedure
                                                                , helper2.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(rtnDtTemp.Rows[0]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                , helper2.CreateParameter("AS_LOTNO", DBHelper.nvlString(rtnDtTemp.Rows[0]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                                                , helper2.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                                                , helper2.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                    }
                    catch (Exception ex)
                    {
                        helper2.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        helper2.Close();
                    }
                    //일반프린터로 발행시..
                    //else
                    //{
                    //    if (_printCnt == 1 || _printCnt % 4 == 1)
                    //        dRow = rtnDtTemp2.NewRow();


                    //    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    //    {
                    //        dRow["PLANTNAME" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["PLANTNAME"];
                    //        dRow["LOTNO" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["LOTNO"];
                    //        dRow["TMPINDATE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["TMPINDATE"];
                    //        dRow["ITEMTYPE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["ITEMTYPE"];
                    //        dRow["ITEMCODE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["ITEMCODE"];
                    //        dRow["ITEMNAME" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["ITEMNAME"];
                    //        dRow["PONO" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["PONO"];
                    //        dRow["LOTBASEQTY" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["LOTBASEQTY"];
                    //        dRow["CUSTCODE" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["CUSTCODE"];
                    //        dRow["CUSTNAME" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["CUSTNAME"];
                    //        dRow["REMARK" + Convert.ToString(_columnCnt + 1)] = rtnDtTemp.Rows[0]["REMARK"];

                    //        if (_printCnt == _chkCnt || _printCnt % 4 == 0)
                    //        {
                    //            rtnDtTemp2.Rows.Add(dRow);

                    //            //텔레릭 레포트로 출력시
                    //            //rtnDtTemp 데이터바인딩
                    //            MM0000_POP_TEL = new MM0000_POP_TEL();
                    //            objectDataSource.DataSource = rtnDtTemp2;
                    //            MM0000_POP_TEL.DataSource = objectDataSource;
                    //            viewerInstance.ReportDocument = MM0000_POP_TEL.Report;

                    //            //레포트 뷰어
                    //            //ReportViewer.ReportSource = viewerInstance;
                    //            //ReportViewer.RefreshReport();

                    //            //뷰어 없이 바로 출력
                    //            Telerik.Reporting.IReportDocument myReport = new MM0000_POP_TEL();
                    //            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                    //            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
                    //            Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

                    //            reportProcessor.PrintController = standardPrintController;
                    //            printerSettings.Collate = true;
                    //            reportProcessor.PrintReport(viewerInstance, printerSettings);

                    //            rtnDtTemp2.Rows.RemoveAt(0);
                    //            _columnCnt = -1;
                    //        }

                    //        _printCnt++;
                    //        _columnCnt++;

                    //        DBHelper helper3 = new DBHelper("", true);
                    //        string RS_MSG = string.Empty;
                    //        string RS_CODE = string.Empty;

                    //        try
                    //        {
                    //            helper3.ExecuteNoneQuery("USP_MM0010_U1", CommandType.StoredProcedure
                    //                                                    , helper3.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(rtnDtTemp.Rows[0]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                    //                                                    , helper3.CreateParameter("AS_LOTNO", DBHelper.nvlString(rtnDtTemp.Rows[0]["LOTNO"]), DbType.String, ParameterDirection.Input)
                    //                                                    , helper3.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                    //                                                    , helper3.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            helper3.Rollback();
                    //            MessageBox.Show(ex.Message);
                    //        }
                    //        finally
                    //        {
                    //            helper3.Close();
                    //        }
                    //    }

                    //}
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                serialPort1.Close();
                helper.Close();
            }
        }
        #endregion
        private void openSerial()
        {
            if (serialPort1.IsOpen) serialPort1.Close(); // 시리얼포트가 열려있으면 닫기 위함

            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_GET_SERAILPORT"
                                                          , CommandType.StoredProcedure
                                                          , helper.CreateParameter("@AS_MACHNAME", "ZEBRA", DbType.String, ParameterDirection.Input));

                serialPort1.PortName = Convert.ToString(rtnDtTemp.Rows[0]["PORTNAME"]);
                serialPort1.BaudRate = Convert.ToInt32(rtnDtTemp.Rows[0]["BAUDRATE"]);
                serialPort1.DataBits = Convert.ToInt32(rtnDtTemp.Rows[0]["DATABITS"]);

                if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.None")
                {
                    serialPort1.Parity = System.IO.Ports.Parity.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Even")
                {
                    serialPort1.Parity = Parity.Even;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Mark")
                {
                    serialPort1.Parity = Parity.Mark;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Odd")
                {
                    serialPort1.Parity = Parity.Odd;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["PARITYBITS"]) == "Parity.Space")
                {
                    serialPort1.Parity = Parity.Space;
                }

                if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.None")
                {
                    serialPort1.StopBits = StopBits.None;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.One")
                {
                    serialPort1.StopBits = StopBits.One;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.OnePointFive")
                {
                    serialPort1.StopBits = StopBits.OnePointFive;
                }
                else if (Convert.ToString(rtnDtTemp.Rows[0]["STOPBITS"]) == "StopBits.Two")
                {
                    serialPort1.StopBits = StopBits.Two;
                }

                serialPort1.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                serialPort1.Close();
                return;
            }
        }

    }
}