#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM2140
//   Form Name    : 수입검사등록 관리자
//   Name Space   : WIZ.WM
//   Created Date : 2020-05-06
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 제품검사 일괄등록
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM2140 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable Grid1D = new DataTable();
        DataTable Grid2D = new DataTable();

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        private string RS_CODE = string.Empty;
        private string RS_MSG = string.Empty;

        string BARCODE = "";
        string LASTFLAG = "";
        int INSPNUM = 0;
        #endregion

        #region < CONSTRUCTOR >
        public WM2140()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void WM2140_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 품목
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);
                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", true, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 20, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "진행상태", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMSTATS", "진행상태", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PONO",      "발주번호",     true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",  "업체코드",     true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Center, false, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME",  "업체명",       true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 250, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "거래처 LOTNO", true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "수량", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);


                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid2, "CHK",        "최종",       true, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "SEQ",        "차수",       true, GridColDataType_emu.VarChar, 60, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", true, GridColDataType_emu.VarChar, 140, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사명", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "VALUETYPE", "측정구분", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "VALUENAME", "측정구분명", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECTYPE", "관리타입", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECNAME", "관리명", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECLSL", "하한", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECNOL", "기준", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "INPUTVALUE", "측정치", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECUSL", "상한", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OKNG", "판정", true, GridColDataType_emu.VarChar, 80, 90, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.SetInitUltraGridBind(grid2);

                string format1 = "#,###.#";
                grid2.Columns["SPECLSL"].Format = format1;
                grid2.Columns["SPECNOL"].Format = format1;
                grid2.Columns["SPECUSL"].Format = format1;

                //_GridUtil.InitColumnUltraGrid(grid1, "WHCODE",           "창고위치",       true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE",   "저장소위치",     true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, false, false);

                #endregion

                ////콤보박스 셋팅
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //rtnDtTemp = _Common.GET_BM0000_CODE("INSPTYPE"); //수입검사여부               
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "INSPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("OKNG"); //수입검사여부               
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "OKNG", rtnDtTemp, "CODE_ID", "CODE_NAME_ORG");

                BizGridManager bizGridManager;
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "Y" }); //품목마스터 POP-UP 제품유형 기본 [1]완제품 설정

                cbo_SEQ.Value = 1;

                GetWhCode();
                cboWhCode_SelectedValueChanged("WH0003");
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


                rtnDtTemp = helper.FillTable("USP_WM2140_S2"
                                           , CommandType.StoredProcedure
                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input));


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

                //선택한 차수의 수에 따라 for(int i = 1 ; i < 차수 + 1 ; i++)

                this.grid1.InsertRow();
                //품목별 측정항목 자동 생성....

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
            Grid1D = grid1.chkChange();
            Grid2D = grid2.chkChange();

            string sResult = "";

            DateTime dtNow = DateTime.Now;

            if (Grid2D == null)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            //foreach (DataRow drRow1 in Grid1D.Rows)
            for (int grid1rowNUM = 0; grid1rowNUM < grid1.Rows.Count; grid1rowNUM++)
            {
                try
                {
                    if (grid1.Rows[grid1rowNUM].Cells["CHK"].Value.ToString() == "1")
                    {
                        BARCODE = grid1.Rows[grid1rowNUM].Cells["LOTNO"].Value.ToString();

                        for (int i = 0; i < grid2.Rows.Count; i++)
                        {
                            if (grid2.Rows[i].Cells["OKNG"].Text == "NG")   //검사항목 중 NG가 있을 경우..
                            {
                                sResult = "NG";
                                break;
                            }
                            else
                                sResult = "OK";
                        }

                        if (sResult == string.Empty)
                        {
                            //검사항목이 없을 경우..자동 OK처리..
                            sResult = "OK";
                        }

                        if (chkLastInsp.Checked == true)
                        {
                            LASTFLAG = "Y";
                        }
                        else
                        {
                            LASTFLAG = "N";
                        }

                        helper.ExecuteNoneQuery("USP_WM2140_I1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_BARCODE", BARCODE, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_WHCODE", cbo_WHCODE_H.Value, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_STORAGELOCCODE", cbo_LOCCODE_H.Value, DbType.String, ParameterDirection.Input)
                                        //, helper.CreateParameter("AS_ITEMCNT", DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["LOTQTY"].Value), DbType.Int32, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_RESULT", sResult, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LASTFLAG", LASTFLAG, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input));



                        foreach (DataRow drRow2 in Grid2D.Rows)
                        {
                            //DBHelper.nvlString(drRow2["PLANTCODE"])
                            helper.ExecuteNoneQuery("USP_WM2140_I2", CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_BARCODE", BARCODE, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(grid1.Rows[grid1rowNUM].Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_INSPCODE", DBHelper.nvlString(drRow2["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_INSPRESULTVAL", DBHelper.nvlString(drRow2["INPUTVALUE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_INSPRESULT", DBHelper.nvlString(drRow2["OKNG"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SPECLSL", DBHelper.nvlString(drRow2["SPECLSL"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SPECUSL", DBHelper.nvlString(drRow2["SPECUSL"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        }

                        if (helper.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper.Commit();
                        }

                        else if (helper.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            helper.Rollback();
                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    //DoInquire();
                }
                catch (Exception ex)
                {
                    CancelProcess = true;
                    helper.Rollback();
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
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
                _dt = USP_PDA_GETWHCODE("WH003", ref RS_CODE, ref RS_MSG); //PP0030 공정창고 재고 -> 검사 -> 제품창고

                if (RS_CODE == "S")
                {
                    if (_dt.Rows.Count > 0)
                    {
                        WIZ.Common.FillComboboxMaster(cbo_WHCODE_H, _dt, "WHCODE", "WHNAME", null, "");
                        //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", _dt, "WHCODE", "WHNAME");
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
                    WIZ.Common.FillComboboxMaster(cbo_LOCCODE_H, _dt, "STORAGELOCCODE", "STORAGELOCNAME", null, "");
                    //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STORAGELOCCODE", _dt, "STORAGELOCCODE", "STORAGELOCNAME");
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




        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            Grid2AddRow();
        }

        private void Grid2AddRow()
        {
            DBHelper helper = new DBHelper(false);

            DataTable grid2DT = new DataTable();

            string PlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string ItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string Lotno = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTNO"].Value);
            int Seq = Convert.ToInt16(cbo_SEQ.Value);

            _GridUtil.Grid_Clear(grid2);

            //품목별 수입검사 항목
            //for (int i = 1; i < Seq + 1 ; i++)
            //{
            //    rtnDtTemp = helper.FillTable("USP_WM2140_S1", CommandType.StoredProcedure
            //                                                    , helper.CreateParameter("AS_PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
            //                                                    , helper.CreateParameter("AS_ITEMCODE", ItemCode, DbType.String, ParameterDirection.Input));
            //                                                    //, helper.CreateParameter("AS_SEQ"      , i,         DbType.Int16, ParameterDirection.Input));
            //    grid2DT.Merge(rtnDtTemp);
            //}

            grid2DT = helper.FillTable("USP_WM2140_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", ItemCode, DbType.String, ParameterDirection.Input));
            //, helper.CreateParameter("AS_SEQ", i, DbType.Int16, ParameterDirection.Input)
            grid2.DataSource = grid2DT;
            grid2.DataBinds(grid2DT);

            string query = "";
            query = @"  SELECT COUNT(1) + 1 AS INSPNUM
                        FROM WM0040 WITH(NOLOCK)";
            query += "WHERE PLANTCODE = '" + PlantCode + "' ";
            query += "AND LOTNO = '" + Lotno + "' ";

            rtnDtTemp = helper.FillTable(query);
            INSPNUM = Convert.ToInt16(rtnDtTemp.Rows[0]["INSPNUM"].ToString());
            txtInspNum.Text = rtnDtTemp.Rows[0]["INSPNUM"].ToString();
        }

        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                try
                {
                    string sSpecType = DBHelper.nvlString(grid2.ActiveRow.Cells["SPECTYPE"].Value);
                    double iStdValue = Convert.ToDouble(grid2.ActiveRow.Cells["SPECNOL"].Value); //기준값
                    double iUslValue = Convert.ToDouble(grid2.ActiveRow.Cells["SPECUSL"].Value); //상한값
                    double iLslValue = Convert.ToDouble(grid2.ActiveRow.Cells["SPECLSL"].Value); //하한값
                    double iInputValue = Convert.ToDouble(((WIZ.Control.Grid)(sender)).ActiveRow.Cells["INPUTVALUE"].Text); //측정값


                    //입력 후 로직..
                    if (sSpecType == "B")
                    {
                        #region [ Spec 양쪽 관리 ]
                        if (iUslValue >= iInputValue && iLslValue <= iInputValue)
                        {
                            //정상범위..
                            grid2.ActiveRow.Cells["OKNG"].Value = "OK";
                            grid2.ActiveRow.Cells["OKNG"].Appearance.ForeColor = Color.Blue;
                        }
                        else
                        {
                            //비정상범위일 경우..

                            grid2.ActiveRow.Cells["OKNG"].Value = "NG";
                            grid2.ActiveRow.Cells["OKNG"].Appearance.ForeColor = Color.Red;
                        }
                        #endregion
                    }
                    else if (sSpecType == "U")
                    {
                        #region [ Spec 상한관리 ]
                        if (iUslValue >= iInputValue)
                        {
                            //정상범위일 경우..
                            grid2.ActiveRow.Cells["OKNG"].Value = "OK";
                            grid2.ActiveRow.Cells["OKNG"].Appearance.ForeColor = Color.Blue;
                        }
                        else
                        {
                            //비정상범위
                            grid2.ActiveRow.Cells["OKNG"].Value = "NG";
                            grid2.ActiveRow.Cells["OKNG"].Appearance.ForeColor = Color.Red;
                        }
                        #endregion
                    }
                    else if (sSpecType == "L")
                    {
                        #region [ Spec 하한관리 ]
                        if (iLslValue <= iInputValue)
                        {
                            //정상범위
                            grid2.ActiveRow.Cells["OKNG"].Value = "OK";
                            grid2.ActiveRow.Cells["OKNG"].Appearance.ForeColor = Color.Blue;
                        }
                        else
                        {
                            //비정상범위일 경우..
                            grid2.ActiveRow.Cells["OKNG"].Value = "NG";
                            grid2.ActiveRow.Cells["OKNG"].Appearance.ForeColor = Color.Red;
                        }

                        #endregion
                    }
                }

                catch (Exception ex)
                {
                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }

            }


        }

        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            string sITEMCODE = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            object chk = "";

            if (grid1.ActiveRow.Cells["CHK"].Value.ToString() == "1")
            {
                chk = 0;
            }
            else if (grid1.ActiveRow.Cells["CHK"].Value.ToString() == "0")
            {
                chk = 1;
            }

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (grid1.Rows[i].Cells["ITEMCODE"].Value.ToString() == sITEMCODE)
                {
                    grid1.Rows[i].Cells["CHK"].Value = chk;
                }
            }

        }

        /*private void grid2_CellChange(object sender, CellEventArgs e)
        {
            string LASTFLAG = DBHelper.nvlString(grid2.ActiveRow.Cells["SEQ"].Value);
            object chk = "";

            if (grid2.ActiveRow.Cells["CHK"].Value.ToString() == "1")
            {
                chk = 0;
            }
            else if (grid2.ActiveRow.Cells["CHK"].Value.ToString() == "0")
            {
                chk = 1;
            }

            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                if (grid2.Rows[i].Cells["SEQ"].Value.ToString() == LASTFLAG)
                {
                    grid2.Rows[i].Cells["CHK"].Value = chk;
                }
            }
        }*/
        #endregion
    }
}