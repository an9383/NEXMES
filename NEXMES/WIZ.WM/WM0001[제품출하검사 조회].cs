#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0001
//   Form Name    : 제품입고 등록
//   Name Space   : WIZ.WM
//   Created Date : 2018-04-10
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 제품입고 시, 라벨 교체 및 박스당 수량 입력
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0001 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string _sItemCode;
        string _sItemName;
        int _iChkCnt;
        double _dLotQty;

        string _sFlag; // "Y" = 검사 후 입고, "N" = 입고 후 검사

        #endregion

        #region < CONSTRUCTOR >
        public WM0001()
        {
            InitializeComponent();

            SearchFlag();
        }
        #endregion

        #region < FORM LOAD >
        private void WM0001_Load(object sender, EventArgs e)
        {
            #region GRID SETTING

            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO", "프레임수주번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "수량", false, GridColDataType_emu.Float, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생산일시", false, GridColDataType_emu.DateTime24, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "작업자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion

            #region POPUP SETTING
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });  // 품목

            #endregion

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
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_WM0001_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

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
        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "CHK")
            {
                bool chk = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "TRUE" ? true : false;

                if (chk == true)
                {
                    this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = false;
                }
                else
                {
                    this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = true;
                }
            }
        }

        private void btnBoxIn_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0)
            {
                ShowDialog(Common.getLangText("입고 할 제품이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sItemCode1 = string.Empty;
            string sItemCode2 = string.Empty;
            int iNg = 0;

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper() == "TRUE")
                {
                    sItemCode1 = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);

                    if (sItemCode2.Trim().Length == 0) { sItemCode2 = sItemCode1.Trim(); }
                    if (sItemCode1 != sItemCode2)
                    {
                        iNg++;
                        break;
                    }
                }
            }

            if (iNg > 0)
            {
                ShowDialog(Common.getLangText("한 종류 이상의 품번이 선택 되었습니다. 한 종류의 품번만 한번에 입고 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            int iCnt = 0;

            _dLotQty = 0;
            int iBoxQty = 0;

            string sChkCnt = string.Empty;
            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                sChkCnt = Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper();
                if (sChkCnt == "TRUE")
                {
                    iCnt++;
                    _dLotQty += Convert.ToDouble(grid1.Rows[i].Cells["LOTQTY"].Value);
                }
            }

            if (iCnt == 0)
            {
                ShowDialog(Common.getLangText("입고 할 LOT를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            iBoxQty = Convert.ToInt32(DBHelper.nvlString(txtBoxQty.Text.Trim(), "0"));

            if (iBoxQty == 0)
            {
                ShowDialog(Common.getLangText("입고 박스 수량이 0보다 커야 합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (iBoxQty > _dLotQty)
            {
                ShowDialog(Common.getLangText("입고 박스 수량보다 입고량이 더 작습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText("제품 입고 처리 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel) { return; }

            if ((_dLotQty % iBoxQty) != 0)
            {
                ShowDialog(Common.getLangText("포장 수량만큼 입고 후 잔량이 발생하게 됩니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    string sChkFlag = Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper();

                    if (sChkFlag == "TRUE")
                    {
                        _sItemCode = Convert.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value);
                        _sItemName = Convert.ToString(grid1.Rows[i].Cells["ITEMNAME"].Value);
                        string sLotNo = Convert.ToString(grid1.Rows[i].Cells["LOTNO"].Value);
                        float fQty = Convert.ToSingle(grid1.Rows[i].Cells["LOTQTY"].Value);

                        helper.ExecuteNoneQuery("USP_WM0001_I1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_ITEMCODE", _sItemCode, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AF_LOTQTY", fQty, DbType.String, ParameterDirection.Input)
                                                     , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE != "S")
                        {
                            helper.Rollback();
                            ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                            return;
                        }

                    }
                }

                helper.Commit();
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                return;
            }
            finally
            {
                helper.Close();
            }

            helper = new DBHelper("", true);


            try
            {
                _iChkCnt = 0;

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    string sChkFlag = Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper();

                    if (sChkFlag == "TRUE")
                        _iChkCnt++;
                }

                helper.ExecuteNoneQuery("USP_WM0001_I2", CommandType.StoredProcedure
                                                      , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                      , helper.CreateParameter("AS_ITEMCODE", _sItemCode, DbType.String, ParameterDirection.Input)
                                                      , helper.CreateParameter("AI_BOXQTY", iBoxQty, DbType.String, ParameterDirection.Input)
                                                      , helper.CreateParameter("AI_CHKCNT", _iChkCnt, DbType.String, ParameterDirection.Input)
                                                      , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE != "S")
                {
                    helper.Rollback();
                    ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }


                helper.Commit();

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                return;
            }
            finally
            {
                helper.Close();
                base.DoInquire();
                ShowDialog(Common.getLangText("정상적으로 처리되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            }

            SendPrint();
        }


        #endregion

        #region < USER METHOD AREA >
        private void SearchFlag()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = new DataTable();

                rtnDtTemp = helper.FillTable("USP_WM0001_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));

                _sFlag = Convert.ToString(rtnDtTemp.Rows[0]["FLAG"]);
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

        private void SendPrint()
        {
            string sBoxQty = txtBoxQty.Text.Trim();
            try
            {
                WM0000_POP WM0000_POP = new WM0000_POP(_sItemCode, _sItemName, sBoxQty, _dLotQty, _sFlag);
                WM0000_POP.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                txtBoxQty.Text = string.Empty;
            }

        }

        #endregion 

    }
}