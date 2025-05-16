#region ▶ HEADER AREA 
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM1100Y
//   Form Name    : 불량실적 등록/판정
//   Name Space   : WIZ.QM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region ▶ USING AREA 
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabs;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.QM
{
    public partial class QM1100Y : WIZ.Forms.BaseMDIChildForm
    {
        #region ▶ MEMBER AREA 
        DataSet rtnDsTemp = new DataSet();
        DataTable rtnDtTemp = new DataTable();
        DataTable _DtTemp = new DataTable();    //임시로 사용할 데이터테이블 생성

        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager _PopUp = new BizTextBoxManager();
        BizGridManager gridManager;

        Common _Common = new Common();

        Configuration appconfig;
        string LS_ITEMCODE = string.Empty;
        #endregion

        public QM1100Y()
        {
            InitializeComponent();
        }

        private void QM1100Y_Load(object sender, System.EventArgs e)
        {
            appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            GridInit();

            //사업장
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("PLANTCODE", "10");
            //--

            rtnDtTemp = _Common.GET_BM0000_CODE("JUDGEFLAG");
            WIZ.Common.FillComboboxMaster(this.cboResFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");

            //-- 귀책구분 (자체/외주)
            rtnDtTemp = _Common.GET_BM0000_CODE("NOTFITDIV");
            WIZ.Common.FillComboboxMaster(this.cboNotfitdiv, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");

            //-- 부적합 판정결과
            rtnDtTemp = _Common.GET_BM0000_CODE("NOTFITRES");
            WIZ.Common.FillComboboxMaster(this.cboJudgeRes, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");


            CboStartdate_H.Value = DateTime.Now;
            CboEnddate_H.Value = DateTime.Now;

            cboPlantCode_H.Select();

            _PopUp.PopUpAdd(txtErrorItemCode, txtErrorItemName, "BM0010", new object[] { cboPlantCode_H, "", "" });
            _PopUp.PopUpAdd(txtItemCode, txtItemName, "BM0010", new object[] { cboPlantCode_H, "1", "" });                  //품목                
            _PopUp.PopUpAdd(txtWcCode, txtWcName, "BM0060", new object[] { cboPlantCode_H, "", "", "" });
            //_PopUp.PopUpAdd(txtErrorItemCode, txtErrorItemName, "BM1000", new object[] { "", "", "", "" });
            //_PopUp.PopUpAdd(txtAttCust, txtAttCustName, "BM0030", new object[] { "V", "" });
            _PopUp.PopUpAdd(txtCauseItem, txtCauseItemName, "BM0010", new object[] { cboPlantCode_H, "1", "" });
            _PopUp.PopUpAdd(txtNotfitLine, txtNotfitLineName, "BM0060", new object[] { cboPlantCode_H, "", "", "", "Y" });
            gridManager = new BizGridManager(grid1);

        }

        private void GridInit()
        {
            try
            {
                _GridUtil.InitializeGrid(this.grid1);
                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "수불일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "생산품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "생산품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORITEMCODE", "불량품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORITEMNAME", "불량품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCAUSEITEMCODE", "불량원인품목", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORGROUP", "불량그룹", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORCODE", "불량코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORNAME", "불량사유", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량발생수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ERRORDATE", "발생일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITQTY", "불량판정수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, "#,###", "nnn,nnn,nnn", null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITRES", "판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITDIV", "귀책구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITLINE", "귀책공정(업체)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITRESDESC", "불량내용", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITRESWORKER", "판 정 자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITYN", "판정여부", false, GridColDataType_emu.VarChar, 10, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "NOTFITSTATUS", "부적합처리상태", false, GridColDataType_emu.VarChar, 10, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid1);
            }
            catch
            {
            }
        }

        #region ▶ TOOL BAR AREA 
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string ls_plantcode = DBHelper.nvlString(cboPlantCode_H.Value);                         //공장                
                string ls_startdate = Convert.ToDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");  //조회일자(시작)
                string ls_enddate = Convert.ToDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");    //조회일자(종료)
                string ls_resflag = DBHelper.nvlString(cboResFlag.Value);                             //판정결과
                string ls_erroritem = Convert.ToString(txtErrorItemCode.Tag);                           //불량품목                
                string ls_wccode = DBHelper.nvlString(txtWcCode.Tag);                                //작업장
                string ls_itemcode = Convert.ToString(txtItemCode.Tag);                                //생산품목                
                string ls_errorresult = "";

                if (DateCheck.CheckDate(ls_startdate, ls_enddate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //시작일자를 종료일자보다 이전으로 선택해주십시오.
                    return;
                }

                base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_QM1100Y_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STARTDATE", ls_startdate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ENDDATE", ls_enddate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", ls_wccode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ITEMCODE", ls_itemcode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ERRORITEMCODE", ls_erroritem, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_NOTFITRES", ls_errorresult, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RESFLAG", ls_resflag, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBind();
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    // 조회할 데이터가 없습니다.
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (grid1.Rows.Count > 0)
            {
                bool bSelect = false;


                if (Convert.ToString(cboNotfitdiv.Value).Trim().Length == 0)
                {
                    this.ShowDialog(Common.getLangText("귀책 구분은 반드시 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    cboNotfitdiv.Focus();
                    return;
                }

                if (Convert.ToString(cboJudgeRes.Value).Trim().Length == 0)
                {
                    this.ShowDialog(Common.getLangText("판정결과는 반드시 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    cboJudgeRes.Focus();
                    return;
                }

                if (Convert.ToString(cboNotfitdiv.Value).Trim() == "B" && txtNotfitLine.Text.Trim().Length == 0)
                {
                    this.ShowDialog(Common.getLangText("귀책구분이 외주업체 일 경우 외주업체 코드를 반드시 선택 하셔야 합니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                foreach (DataRow dr in ((DataTable)grid1.DataSource).Rows)
                {
                    if (Convert.ToBoolean(dr["CHK"])) { bSelect = true; }
                }

                if (!bSelect)
                {
                    this.ShowDialog(Common.getLangText("선택된 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            else
            {
                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                base.DoSave();
                grid1.UpdateData();

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                string sAtt = string.Empty;
                string ls_plantcode = string.Empty, ls_seq = string.Empty;
                string ls_recdate = string.Empty, ls_errorqty = string.Empty;
                string ls_notfitline = string.Empty, ls_notfitdiv = string.Empty;
                string ls_notfititem = string.Empty, ls_notfitresdesc = string.Empty;
                string ls_notfitres = string.Empty, ls_maker = string.Empty;
                string ls_notfitqty = string.Empty, ls_lotno = string.Empty;
                string ls_orderno = string.Empty;

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).GetChanges().Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;

                        case DataRowState.Added:
                            break;

                        case DataRowState.Modified:

                            if (Convert.ToBoolean(drRow["CHK"]))
                            {
                                sAtt = string.Empty;

                                //자체 불량
                                if (cboNotfitdiv.Value.ToString() == "A" && txtNotfitLine.Text.Trim().Length == 0)
                                {
                                    //귀책공정을 선택하지 않을 경우 불량 발생공정이 해당 귀책공정으로 처리
                                    sAtt = Convert.ToString(drRow["WORKCENTERCODE"]);
                                }

                                ls_plantcode = Convert.ToString(drRow["PLANTCODE"]);
                                
                                ls_seq = Convert.ToString(drRow["SEQNO"]);
                                ls_recdate = Convert.ToString(drRow["RECDATE"]);
                                ls_orderno = Convert.ToString(drRow["ORDERNO"]);
                                ls_lotno = Convert.ToString(drRow["LOTNO"]);
                                ls_errorqty = Convert.ToString(drRow["ERRORQTY"]);
                                ls_notfitqty = Convert.ToString(drRow["NOTFITQTY"]);
                                ls_notfitline = txtNotfitLine.Text.Trim();
                                ls_notfitdiv = Convert.ToString(cboNotfitdiv.Value);
                                ls_notfitresdesc = Convert.ToString(drRow["NOTFITRESDESC"]);
                                ls_notfitres = Convert.ToString(cboJudgeRes.Value);
                                ls_maker = WIZ.LoginInfo.UserID.Trim();

                                //원인품목을 선택하지 않을 경우 불량품목이 원인품목으로 처리
                                if (txtCauseItem.Text.Trim().Length == 0) { ls_notfititem = Convert.ToString(drRow["ERRORITEMCODE"]); }
                                else { ls_notfititem = txtCauseItem.Text.Trim(); }

                                helper.ExecuteNoneQuery("USP_QM1100Y_I1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", ls_plantcode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SEQNO", ls_seq, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_RECDATE", ls_recdate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ORDERNO", ls_orderno, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_LOTNO", ls_lotno, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ERRORQTY", ls_errorqty, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_NOTFITLINE", ls_notfitline, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_NOTFITDIV", ls_notfitdiv, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_NOTFITITEM", ls_notfititem, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_NOTFITRESDESC", ls_notfitresdesc, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_NOTFITRES", ls_notfitres, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAKER", ls_maker, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_NOTFITQTY", ls_notfitqty, DbType.String, ParameterDirection.Input));
                            }
                            break;
                    }
                }
                ((DataTable)grid1.DataSource).AcceptChanges();
                helper.Commit();

                cboJudgeRes.SelectedIndex = 0;
                cboNotfitdiv.SelectedIndex = 0;
                txtCauseItem.Text = string.Empty;
                txtCauseItemName.Text = string.Empty;
                txtNotfitLine.Text = string.Empty;
                txtNotfitLineName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                DoInquire();
            }
        }

        public override void DoDownloadExcel()
        {
            //base.DoDownloadExcel();
            WIZ.REPORT.ExcelManager excel = new WIZ.REPORT.ExcelManager();
            excel.DownloadExcel(this.grid1, this.Name, false);
        }
        #endregion

        /// <summary>
        /// 불량판정 - 원인품목 선택 팝업창.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCauseItem_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                string ls_notfitdiv = Convert.ToString(cboNotfitdiv.Value).Trim();
                //switch (ls_notfitdiv)
                //{
                //    case "A": //사내불량(반제품 조회)
                //        string[] values = { Convert.ToString(cboPlantCode_H.Value), "HALB" };
                //        POP_TBM0100 _frmA = new POP_TBM0100( values );
                //        _frmA.ShowDialog();
                //        rtnDtTemp = (DataTable)_frmA.Tag;
                //        if (rtnDtTemp.Rows.Count > 0)
                //        {
                //            txtCauseItem.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
                //            txtCauseItemName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
                //        }
                //        _frmA.Dispose();
                //        break;
                //    case "B": //외주불량(원자재 조회)
                //        string[] values2 = { Convert.ToString(cboPlantCode_H.Value), "ROH" };
                //        POP_TBM0100 _frmB = new POP_TBM0100( values2 );
                //        _frmB.ShowDialog();
                //        rtnDtTemp = (DataTable)_frmB.Tag;
                //        if (rtnDtTemp.Rows.Count > 0)
                //        {
                //            txtCauseItem.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
                //            txtCauseItemName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
                //        }
                //        _frmB.Dispose();                        
                //        break;
                //    default:
                //        this.ShowDialog(Common.getLangText("귀책 구분은 반드시 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK); //귀책 구분은 반드시 선택하세요.
                //        cboNotfitdiv.Focus();
                //        break;
                //}

            }
            catch
            {
                txtCauseItem.Text = string.Empty;
                txtCauseItemName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 불량판정 - 원인공정 선택 팝업창.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNotfitLine_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                string ls_notfitdiv = Convert.ToString(cboNotfitdiv.Value).Trim();

                //switch (ls_notfitdiv)
                //{
                //    case "A": //사내불량(공정선택)
                //        string[] VAL1 = { Convert.ToString(cboPlantCode_H.Value), "" };
                //        POP_TBM0600 _frm600 = new POP_TBM0600( VAL1 );
                //        _frm600.ShowDialog();
                //        rtnDtTemp = (DataTable)_frm600.Tag;
                //        if (rtnDtTemp.Rows.Count > 0)
                //        {
                //            txtNotfitLine.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
                //            txtNotfitLineName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
                //        }
                //        _frm600.Dispose();    
                //        break;
                //    case "B": //외주불량(업체선택)
                //        string[] VAL2 = { "", "" };
                //        POP_TBM0310Y _frm300 = new POP_TBM0310Y( VAL2 );
                //        _frm300.ShowDialog();
                //        rtnDtTemp = (DataTable)_frm300.Tag;
                //        if (rtnDtTemp.Rows.Count > 0)
                //        {
                //            txtNotfitLine.Text = Convert.ToString(rtnDtTemp.Rows[0][0]);
                //            txtNotfitLineName.Text = Convert.ToString(rtnDtTemp.Rows[0][1]);
                //        }
                //        _frm300.Dispose();
                //        break;
                //    default:
                //        this.ShowDialog(Common.getLangText("귀책 구분은 반드시 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK); 
                //        cboNotfitdiv.Focus();
                //        break;
                //}                
            }
            catch
            {
                txtNotfitLine.Text = string.Empty;
                txtNotfitLineName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 판정수량 변경시 불량발생 수량과 비교하여 많이 등록 하지 못하게 처리.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            string ls_Column = Convert.ToString(e.Cell.Column.Key);

            if (ls_Column.Trim() == "NOTFITQTY")
            {
                string ls_errorqty = DBHelper.nvlString(Convert.ToString(grid1.ActiveRow.Cells["ERRORQTY"].Value), "0");
                string ls_notfitqty = DBHelper.nvlString(Convert.ToString(grid1.ActiveRow.Cells["NOTFITQTY"].Value), "0");

                if (Convert.ToInt32(ls_errorqty) < Convert.ToInt32(ls_notfitqty))
                {
                    this.ShowDialog(Common.getLangText("불량판정 수량이 불량발생 수량보다 많을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    grid1.ActiveRow.Cells["NOTFITQTY"].Value = grid1.ActiveRow.Cells["ERRORQTY"].Value;
                    return;
                }
            }
        }

        /// <summary>
        /// 원인품목 판정데이터 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCauseItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtCauseItem.Text = string.Empty;
                txtCauseItemName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 원인공정(업체) 정보 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNotfitLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txtNotfitLine.Text = string.Empty;
                txtNotfitLineName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 판정 완료된 정보 체크 했을 경우 경고 메세지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            string ls_Column = Convert.ToString(e.Cell.Column.Key);

            if (ls_Column.Trim() == "CHK")
            {
                string ls_errorqty = DBHelper.nvlString(Convert.ToString(grid1.ActiveRow.Cells["ERRORQTY"].Value), "0");
                string ls_notfitqty = DBHelper.nvlString(Convert.ToString(grid1.ActiveRow.Cells["NOTFITQTY"].Value), "0");

                if (Convert.ToInt32(ls_errorqty) <= Convert.ToInt32(ls_notfitqty))
                {
                    if (Convert.ToString(grid1.ActiveRow.Cells["NOTFITRES"].Value).Trim().Length > 0)
                    {
                        this.ShowDialog(Common.getLangText("판정이 완료된 불량 정보 입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        grid1.ActiveRow.Cells["CHK"].Value = "Fasle";
                        return;
                    }
                }
            }
        }

        private void grid1_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (DBHelper.nvlString(e.Cell.Column).Equals("CHK"))
            {
                string ls_errorqty = DBHelper.nvlString(Convert.ToString(grid1.ActiveRow.Cells["ERRORQTY"].Value), "0");
                string ls_notfitqty = DBHelper.nvlString(Convert.ToString(grid1.ActiveRow.Cells["NOTFITQTY"].Value), "0");

                if (Convert.ToInt32(ls_errorqty) <= Convert.ToInt32(ls_notfitqty))
                {
                    if (Convert.ToString(grid1.ActiveRow.Cells["NOTFITRES"].Value).Trim().Length > 0)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (DBHelper.nvlString(e.Row.Cells["NOTFITRES"].Value).Trim() != "")
                e.Row.Appearance.BackColor = Color.LightPink; //불량 판정
            else
                e.Row.Appearance.BackColor = Color.White; //불량 미판정 
        }

        private void gbxHeader_Click(object sender, EventArgs e)
        {

        }
    }

    public class DateCheck
    {
        public DateCheck()
        {
        }

        public static bool CheckDate(string sDate, string eDate)
        {
            int Start = int.Parse(string.Format("{0:yyyyMMdd}", sDate.Replace("-", "")));
            int End = int.Parse(string.Format("{0:yyyyMMdd}", eDate.Replace("-", "")));

            if (Start > End)
                return false;
            else
                return true;
        }
    }
}
