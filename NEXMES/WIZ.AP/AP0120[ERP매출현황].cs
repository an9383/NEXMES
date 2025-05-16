/*
  Form Name    : 금형 점검/조치항목
  Created Date : 2020-06-17
  Made By      : 윤석현
  Description  : 금형, 노즐 등 설비에 장착하여 사용 하는 기구에 대한 점검/조치 항목
*/

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0120 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataSet rtnDsTemp = new DataSet();

        string sUserID = WIZ.LoginInfo.UserID;
        DateTime dtNow = DateTime.Now;

        #endregion

        #region < CONSTRUCTOR >

        public AP0120()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0070_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "GOALDATE", "목표일자", true, GridColDataType_emu.YearMonthDay, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "GOALQTY", "목표수량", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            //grid2
            _GridUtil.InitializeGrid(grid2, true, true, true, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "RESULT", "출하상태", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "지시번호", false, GridColDataType_emu.VarChar, 250, 0, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid2, "PACKNO", "박스번호", false, GridColDataType_emu.VarChar, 300, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PACKQTY", "출하수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPDATE", "출하일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid2);


            grid1.Columns["GOALQTY"].Format = "#,##0";
            grid2.Columns["PACKQTY"].Format = "#,##0";

            #endregion

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #region COMBO BOX

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });                    //품목

            #endregion

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼
        /// </summary>
        public override void DoInquire()
        {
            this._GridUtil.Grid_Clear(grid1);
            this._GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);
            try
            {

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());


                rtnDsTemp = helper.FillDataSet("USP_AP0120_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SDATE ", sStartDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_EDATE ", sEndDate, DbType.String, ParameterDirection.Input));


                //목표
                grid1.DataSource = rtnDsTemp.Tables[0];
                grid1.DataBinds();

                //매출
                //grid2.DataSource = rtnDsTemp.Tables[1];
                //grid2.DataBinds();

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

        }

        #endregion

        #region < EVENT AREA >
        private void grid1_ClickCell(object sender, CellEventArgs e)
        {
            _GridUtil.Grid_Clear(grid2);
            string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
            string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

            //DBHelper helper = new DBHelper(false);
            DBHelper db = new DBHelper();
            try
            {
                DataTable dtGrid = null;
                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);

                dtGrid = db.FillTable("USP_WM0150_S2", CommandType.StoredProcedure
                    , db.CreateParameter("PCODE", "S1", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    //, db.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                    , db.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));
                //, db.CreateParameter("AS_LOTNO", "", DbType.String, ParameterDirection.Input)
                //, db.CreateParameter("AS_PACKNO", "", DbType.String, ParameterDirection.Input)
                //, db.CreateParameter("AS_CUSTCODE", DBHelper.nvlString(grid1.ActiveRow.Cells["CUSTCODE"].Value), DbType.String, ParameterDirection.Input));
                //, db.CreateParameter("AS_RESULT", DBHelper.nvlString(cbo_SHIPSTATE_H.Value), DbType.String, ParameterDirection.Input)

                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                db.Close();
            }
        }

        //private void grid1_ClickCellButton(object sender, CellEventArgs e)
        //{
        //    string sFinishFlag = string.Empty;
        //    string sPoNo = string.Empty;
        //    string sItemCode = string.Empty;

        //    try
        //    {
        //        sFinishFlag = Convert.ToString(e.Cell.Row.Cells["FINISHFLAG"].Value);

        //        if (e.Cell.Column.ToString() == "SAVEBUTTON")
        //        {
        //            if (sFinishFlag == "D" || sFinishFlag == "I")
        //            {
        //                sPoNo = Convert.ToString(e.Cell.Row.Cells["PONO"].Value);

        //                DataTable dtTarget = ((DataTable)this.grid1.DataSource);
        //                DataRow[] drRow = dtTarget.Select("PONO = '" + sPoNo + "'");

        //                if (bPop2)
        //                {
        //                    MM0000_POP2 mm0000_pop = new MM0000_POP2(drRow[0], subData["RELCODE1"] != "", subData["RELCODE2"]);
        //                    mm0000_pop.ShowDialog();
        //                }
        //                else
        //                {
        //                    MM0000_POP mm0000_pop = new MM0000_POP(drRow[0]);
        //                    mm0000_pop.ShowDialog();
        //                }

        //                this.DoInquire();
        //            }
        //        }

        //        string strQty = string.Empty;
        //        if (e.Cell.Column.ToString() == "UNITBUTTON")
        //        {
        //            if (sFinishFlag == "")
        //            {
        //                sItemCode = Convert.ToString(e.Cell.Row.Cells["ITEMCODE"].Value);
        //                DataTable dtTarget = ((DataTable)this.grid1.DataSource);
        //                DataRow[] drRow = dtTarget.Select("ITEMCODE = '" + sItemCode + "'");

        //                if (string.IsNullOrEmpty(sItemCode))
        //                {
        //                    this.ShowDialog(Common.getLangText("품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
        //                    return;
        //                }

        //                MM0000_POP_UNIT mm0000_pop_unit = new MM0000_POP_UNIT(drRow[0]);
        //                mm0000_pop_unit.ShowDialog();
        //                strQty = mm0000_pop_unit.m_strQty;
        //                e.Cell.Row.Cells["POQTY"].Value = strQty;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //    }
        //}

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
        #endregion




    }
}


