#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0010
//   Form Name    : 제품 입출고이력
//   Name Space   : WIZ.WM
//   Created Date : 
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0010 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();

        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        string _ChkFlag = string.Empty;

        #endregion

        #region < CONSTRUCTOR >
        public WM0010()
        {
            InitializeComponent();

            _ChkFlag = "A";
        }
        #endregion

        #region  < FORM LOAD >
        private void WM0010_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTDATE", "입출일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고 수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTQTY", "출고 수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INQTY", "입고 수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OUTQTY", "출고 수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "QTY", "수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid4, "INOUTDATE", "입출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TYPECODE", "입출고구분", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TYPENAME", "입출고구분명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "QTY", "수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "WHCODE", "FROM 창고", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "LOCCODE", "FROM 위치코드", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TOWHCODE", "TO 창고", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TOLOCCODE", "TO 위치코드", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "CUSTCODE", "출고거래처코드", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "CUSTNAME", "출고거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid4);

            #endregion

            #region < COMBOBOX SETTING >
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid4, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

            rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(grid4, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid4, "TOWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0030_CODE("");
            //WIZ.UltraGridUtil.SetComboUltraGrid(grid4, "CUSTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0090_CODE(""); // 저장위치
            WIZ.UltraGridUtil.SetComboUltraGrid(grid4, "LOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid4, "TOLOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  // 제품구분
            WIZ.UltraGridUtil.SetComboUltraGrid(grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid2, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(grid3, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;
            #endregion

            #region < POPUP SETTING >
            //품목
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });
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
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid3); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid4); // 조회전 그리드 초기화

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                    // 사업장
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);       // 시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);         // 종료일자
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());
                string LS_TABIDX = string.Empty;

                if (tabControl1.SelectedTab.Index == 0) LS_TABIDX = "TAB1";
                else if (tabControl1.SelectedTab.Index == 1) LS_TABIDX = "TAB2";
                else LS_TABIDX = "TAB3";

                rtnDtTemp = helper.FillTable("USP_WM0010_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_INOUTFLAG",    _ChkFlag,    DbType.String, ParameterDirection.Input));
                if (rtnDtTemp.Rows.Count > 0)
                {
                    if (LS_TABIDX == "TAB1")
                    {
                        if (_ChkFlag == "A")
                        {
                            grid1.Columns["INQTY"].Hidden = false;
                            grid1.Columns["OUTQTY"].Hidden = false;
                        }
                        else if (_ChkFlag == "I")
                        {
                            grid1.Columns["INQTY"].Hidden = false;
                            grid1.Columns["OUTQTY"].Hidden = true;
                        }
                        else if (_ChkFlag == "O")
                        {
                            grid1.Columns["INQTY"].Hidden = true;
                            grid1.Columns["OUTQTY"].Hidden = false;
                        }

                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                    else if (LS_TABIDX == "TAB2")
                    {
                        if (_ChkFlag == "A")
                        {
                            grid2.Columns["INQTY"].Hidden = false;
                            grid2.Columns["OUTQTY"].Hidden = false;
                        }
                        else if (_ChkFlag == "I")
                        {
                            grid2.Columns["INQTY"].Hidden = false;
                            grid2.Columns["OUTQTY"].Hidden = true;
                        }
                        else if (_ChkFlag == "O")
                        {
                            grid2.Columns["INQTY"].Hidden = true;
                            grid2.Columns["OUTQTY"].Hidden = false;
                        }

                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds(rtnDtTemp);
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
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
        #endregion

        #region < EVENT AREA >
        private void grid3_ClickCell(object sender, EventArgs e)
        {
            if (this.grid3.Rows.Count == 0) return;

            _GridUtil.Grid_Clear(grid4);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sLotNo = grid3.ActiveRow.Cells["LOTNO"].Value.ToString();              // 사업장
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);       // 시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);         // 종료일자

                rtnDtTemp = helper.FillTable("USP_WM0010_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_INOUTFLAG", _ChkFlag,   DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid4.DataSource = rtnDtTemp;
                    grid4.DataBinds(rtnDtTemp);
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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
        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 2)
            {
                this.txt_LOTNO_H.Visible = true;
                this.lbl_LOTNO_H.Visible = true;
            }
            else
            {
                this.txt_LOTNO_H.Visible = false;
                this.lbl_LOTNO_H.Visible = false;
            }
        }

        private void chkInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIn.Checked == true && chkOut.Checked == true)
                _ChkFlag = "A";
            else if (chkIn.Checked == true && chkOut.Checked == false)
                _ChkFlag = "I";
            else if (chkIn.Checked == false && chkOut.Checked == true)
                _ChkFlag = "O";
            else
                _ChkFlag = "N";

            base.DoInquire();
        }

        #endregion        
    }
}