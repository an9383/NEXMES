#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0060
//   Form Name    : 입출고 이력
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-19
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 자재 입출고 이력 조회
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0060 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();

        string _ChkFlag = string.Empty;
        #endregion

        #region < CONSTRUCTOR >

        public MM0060()
        {
            InitializeComponent();

            _ChkFlag = "A";
        }

        #endregion

        #region  < FORM LOAD >
        private void MM0060_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTDATE", "입출일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고 수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTQTY", "출고 수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INQTY", "입고 수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "OUTQTY", "출고 수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "QTY", "수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid4, "INOUTDATE", "입출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TYPECODE", "입출고구분", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TYPENAME", "입출고구분명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "QTY", "수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "WHCODE", "FROM 창고", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "LOCCODE", "FROM 위치코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TOWHCODE", "TO 창고", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "TOLOCCODE", "TO 위치코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid4);

            #endregion

            #region < COMBO BOX SETTING >
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0080_CODE("");  //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "TOWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0090_CODE(""); // 저장위치
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "LOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "TOLOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  // 제품구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-5);
            cbo_ENDDATE_H.Value = DateTime.Now;

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

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());
                string sTabIdx = string.Empty;

                if (tabControl1.SelectedTab.Index == 0) sTabIdx = "TAB1";
                else if (tabControl1.SelectedTab.Index == 1) sTabIdx = "TAB2";
                else sTabIdx = "TAB3";

                rtnDtTemp = helper.FillTable("USP_MM0060_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_TAB", sTabIdx, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("AS_INOUTFLAG",    _ChkFlag,    DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    if (sTabIdx == "TAB1")
                    {
                        //for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        //{
                        //    if (rtnDtTemp.Rows[i]["INQTY"].ToString() == "")
                        //    {
                        //        rtnDtTemp.Rows[i].BeginEdit();
                        //        rtnDtTemp.Rows[i]["INQTY"] = "0";
                        //        rtnDtTemp.Rows[i].EndEdit();
                        //    }
                        //    if (rtnDtTemp.Rows[i]["OUTQTY"].ToString() == "")
                        //    {
                        //        rtnDtTemp.Rows[i].BeginEdit();
                        //        rtnDtTemp.Rows[i]["OUTQTY"] = "0";
                        //        rtnDtTemp.Rows[i].EndEdit();
                        //    }
                        //}

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

                        _GridUtil.Grid_Clear(grid1);
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                    else if (sTabIdx == "TAB2")
                    {
                        //for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        //{
                        //    if (rtnDtTemp.Rows[i]["INQTY"].ToString() == "")
                        //    {
                        //        rtnDtTemp.Rows[i].BeginEdit();
                        //        rtnDtTemp.Rows[i]["INQTY"] = "0";
                        //        rtnDtTemp.Rows[i].EndEdit();
                        //    }
                        //    if (rtnDtTemp.Rows[i]["OUTQTY"].ToString() == "")
                        //    {
                        //        rtnDtTemp.Rows[i].BeginEdit();
                        //        rtnDtTemp.Rows[i]["OUTQTY"] = "0";
                        //        rtnDtTemp.Rows[i].EndEdit();
                        //    }
                        //}

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

                        _GridUtil.Grid_Clear(grid2);
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid3);
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds(rtnDtTemp);
                    }
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);
                    _GridUtil.Grid_Clear(grid4);
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

                rtnDtTemp = helper.FillTable("USP_MM0060_S2", CommandType.StoredProcedure
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
                    _GridUtil.Grid_Clear(grid4);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

            if (tabControl1.SelectedTab.Index == 0 || tabControl1.SelectedTab.Index == 1)
            {
                txt_LOTNO_H.Visible = false;
                lbl_LOTNO_H.Visible = false;
            }
            else
            {
                txt_LOTNO_H.Visible = true;
                lbl_LOTNO_H.Visible = true;
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


