#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP3510
//   Form Name    : 외주가공 입고처리
//   Name Space   : WIZ.MM
//   Created Date : 2017-04-19
//   Made By      : WIZCORE 남부사무소 개발팀 사원 윤근욱
//   Description  : 외주가공 입고처리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP3510 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        BizTextBoxManager btbManager = new BizTextBoxManager();

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자

        Common _Common = new Common();

        string sPlantCode = "";
        #endregion

        #region < CONSTRUCTOR >
        public PP3510()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM_LOAD >
        private void PP3510_Load(object sender, EventArgs e)
        {
            #region < GRID >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "외주PONO", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTSOURCING", "외주 종류", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주날짜", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANINDATE", "계획날짜", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, false, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "고객코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 0, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);

            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장",         false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "외주LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATETIME", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",  "품목",           false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",  "품명",           false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",  "출고거래처",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "NOWQTY",    "출고수량",       false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right,  true, false);           
            //_GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",  "단위",           false, GridColDataType_emu.VarChar, 80,  100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX >
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = "10";

            rtnDtTemp = _Common.GET_BM0030_CODE(""); //거래처
            WIZ.Common.FillComboboxMaster(this.cboCustCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboCustCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CUSTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");    //창고
            WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-999);
            cbo_ENDDATE_H.Value = DateTime.Now;  //입고일자

            cboRecDate_H.Value = DateTime.Now;
            cboRecDate.Value = DateTime.Now;  //입고일자
            #endregion

            #region < POP-UP >
            //btbManager.PopUpAdd(txt_ITEMCODE_H, txtItemName_H, "POP_TBM0100", new object[] { cboPlantCode_H, "" });
            //btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { cbo_PLANTCODE_H, "" });
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txtPONO, txtPONO, "MM0020", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "BM0030", new object[] { cbo_PLANTCODE_H, "", "" });

            #endregion
        }


        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sItemCode = this.txt_ITEMCODE_H.Text.Trim();
                string sPoNo = this.txt_PONO_H.Text.Trim();
                string sLotNo = this.txtLOTNO_H.Text.Trim();
                string sCustCode = this.cboCustCode_H.Value.ToString();
                string sRecDate = this.cboRecDate_H.Value.ToString().Substring(0, 10);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                //rtnDtTemp = helper.FillTable("USP_PP3510_S1", CommandType.StoredProcedure
                //                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                //                                                   , helper.CreateParameter("ITEMCODE",  sItemCode,  DbType.String, ParameterDirection.Input)
                //                                                   , helper.CreateParameter("LOTNO",     sLotNo,     DbType.String, ParameterDirection.Input)
                //                                                   , helper.CreateParameter("CUSTCODE",  sCustCode,  DbType.String, ParameterDirection.Input)
                //                                                   , helper.CreateParameter("RECDATE",   sRecDate,   DbType.String, ParameterDirection.Input));

                rtnDtTemp = helper.FillTable("USP_PP3510_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_OUTDATE", sRecDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count <= 0)
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }

                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
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
            //try
            //{
            //    base.DoNew();

            //    this.grid1.InsertRow();

            //    //사업장과 사용여부는 행 추가시 기본으로 세팅
            //    this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            //    //this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
            //    this.grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.AllowEdit;

            //    //if (sAutoItemCode)
            //    //{
            //    //    this.grid1.ActiveRow.Cells["ITEMCODE"].Value = "[New Code]";
            //    //    this.grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.AllowEdit;
            //    //}
            //    //else
            //    //{
            //    //    this.grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.AllowEdit;
            //    //}

            //    //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
            //    //grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            //    //grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            //    //grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
            //    //grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
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

            if (grid1.ActiveRow == null)
                return;
            else
            {
                this.grid1.DeleteRow();
            }

            //string sFinishFlag = Convert.ToString(grid1.ActiveRow.Cells["FINISHFLAG"].Value);

            //if (sFinishFlag != "D" && sFinishFlag != string.Empty)
            //{
            //    this.ClosePrgFormNew();
            //    this.ShowDialog(Common.getLangText("발주정보 상태가 대기가 아닙니다. 삭제할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            //    return;
            //}


            //_GridUtil.Grid_Clear(grid1);


        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();
            if (rtnDtTemp == null)
                return;

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoSave();

                //string ssub = subData["RELCODE1"];

                string sPoDate = string.Empty;
                string sPlanInDate = string.Empty;
                string sFinishFlag = string.Empty;

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        //if (drRow["PODATE"].ToString().Trim() == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("발주일자를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}
                        //if (drRow["PLANINDATE"].ToString().Trim() == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("입고예정일을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}

                        if (drRow["ITEMCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("품목을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["CUSTCODE"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("거래처를 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (drRow["INQTY"].ToString().Trim() == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("발주수량을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                    }
                }

                this.ClosePrgFormNew();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_PP0021_D1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_PONO", DBHelper.nvlString(drRow["PONO"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //sFinishFlag = DBHelper.nvlString(drRow["FINISHFLAG"]);

                            //if (sFinishFlag != "D")
                            //{
                            //    this.ClosePrgFormNew();
                            //    throw new Exception(Common.getLangText("발주정보 상태가 대기가 아닙니다. 수정 할 수 없습니다.", "MSG"));
                            //}

                            //sPoDate = DBHelper.nvlString(drRow["PODATE"]).Substring(0, 10);
                            //sPlanInDate = DBHelper.nvlString(drRow["PLANINDATE"]).Substring(0, 10);

                            helper.ExecuteNoneQuery("USP_PP3510_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PONO", DBHelper.nvlString(drRow["PONO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_OUTDATETIME", DBHelper.nvlString(drRow["OUTDATETIME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_LOTNO", DBHelper.nvlString(drRow["LOTNO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(drRow["CUSTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INQTY", Convert.ToDouble(drRow["INQTY"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                this.ClosePrgFormNew();
                helper.Commit();
                DoInquire(); //성공적으로 수행되었을 경우에만 조회
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        //더블클릭시 클릭된 Row 품목 정보가 입고처리의 항목에 INPUT
        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            sPlantCode = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
            txtItemCode.Text = grid1.ActiveRow.Cells["ITEMCODE"].Text;
            txtLOTNO.Text = grid1.ActiveRow.Cells["LOTNO"].Text;
            txtPONO.Text = grid1.ActiveRow.Cells["ITEMCODE"].Text;
            txtCustCode.Text = grid1.ActiveRow.Cells["CUSTCODE"].Value.ToString();
            //cboCustCode.Value = grid1.ActiveRow.Cells["CUSTCODE"].Value.ToString();
            txtNowQty.Text = grid1.ActiveRow.Cells["INQTY"].Value.ToString();

            //txtUnitCode.Text = grid1.ActiveRow.Cells["UNITCODE"].Value.ToString();
        }

        //버튼 클릭시 TPP0520의 외주출고 이력 OUT시키고, TPP0510Y에 입고이력 남기고, TPP0510Y에 재고+ 시키기
        private void btnInsert_Click(object sender, EventArgs e)
        {
            sPlantCode = cbo_PLANTCODE_H.Value.ToString();

            if (txtLOTNO.Text.ToString() == "")
            {
                this.ShowDialog(Common.getLangText("입고할 LOT가 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (txtItemCode.Text == "")
            {
                this.ShowDialog(Common.getLangText("입고할 품목이 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (cboWhCode.Value.ToString() == "")
            {
                this.ShowDialog(Common.getLangText("재고가 입고될 창고가 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (txtCustCode.Value.ToString() == "")
            {
                this.ShowDialog(Common.getLangText("입고시킬 거래처가 선택되지 않았습니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            //if (cboCustCode.Value.ToString() == "")
            //{
            //    this.ShowDialog("입고시킬 거래처가 선택되지 않았습니다!");
            //    return;
            //}

            if (Convert.ToInt32(txtNowQty.Text) <= 0)
            {
                this.ShowDialog(Common.getLangText("입고수량을 확인해주세요!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (cboWhCode.Value.ToString() != "WH003" && cboWhCode.Value.ToString() != "WH004" && cboWhCode.Value.ToString() != "WH005" && cboWhCode.Value.ToString() != "WH001")
            {
                this.ShowDialog(Common.getLangText("입고대상 창고가 공정창고가 아닙니다!", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog("LOTNO : " + txtLOTNO.Text + "\n품목 : " + txt_ITEMCODE_H.Text + "\n입고량 : " + txtNowQty.Text + "\n위의 항목을 창고로 입고 등록 하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                base.DoSave();

                helper.ExecuteNoneQuery("USP_PP3510_I1", CommandType.StoredProcedure
              , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(sPlantCode), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("AS_PONO", DBHelper.nvlString(txtPONO.Text), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("AS_OUTDATETIME", DBHelper.nvlString(cboRecDate.Value), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("AS_LOTNO", DBHelper.nvlString(txtLOTNO.Text), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(txtCustCode.Text), DbType.String, ParameterDirection.Input)
              , helper.CreateParameter("AS_INQTY", Convert.ToDouble(txtNowQty.Text), DbType.Double, ParameterDirection.Input)
              , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("입고 되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                this.ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();

                txtLOTNO.Clear();
                txt_ITEMCODE_H.Clear();
                txtCustCode.Clear();
                txtCustName.Clear();
                cboWhCode.Clear();
                txtNowQty.Clear();
                txtUnitCode.Clear();
                DoInquire();


            }
        }


        #endregion

        #region < METHOD AREA >
        // Form에서 사용할 함수나 메소드를 정의
        #endregion


    }
}
