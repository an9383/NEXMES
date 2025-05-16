#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP9996
//   Form Name    : 생산계획편성
//   Name Space   : WIZ.AP
//   Created Date : 2020-09-08
//   Made By      : inho.hwang
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP9996 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataTable rtnDtTemp3 = new DataTable();
        DataTable rtnDtTemp4 = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;
        DataTable dtGrid3;
        DataTable dtGrid4;

        #endregion

        #region < CONSTRUCTOR >
        public AP9996()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP9996_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }

        private void BtbManager_PopUpClosed(object tCode, object tName, bool bFindOK)
        {
            SBtnTextEditor sCode = tCode as SBtnTextEditor;
            SBtnTextEditor sName = tName as SBtnTextEditor;

            if (tCode != null)
            {
                if (sCode.Name == "txt_ITEMCODE_S")
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("Select BACKCOLOR FROM BM0010 with (NOLOCK) where ITEMCODE = '" + sCode.Text.Trim() + "' ");

                    DBHelper db = new DBHelper();

                    DataTable dt = db.FillTable(sSQL.ToString());

                    sCode.Appearance.BackColor = Color.White;
                    sName.Appearance.BackColor = Color.White;

                    if (dt.Rows.Count == 1)
                    {
                        string sBackColor = DBHelper.nvlString(dt.Rows[0]["BACKCOLOR"]);
                        Color _color = ColorTranslator.FromHtml(sBackColor);

                        sCode.Appearance.BackColor = _color;
                        sName.Appearance.BackColor = _color;
                    }
                }
            }
        }

        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTDATE", "수주일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE2", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "생산계획수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산실적수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "만기일자", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEFLAG", "완료여부", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);

                _GridUtil.SetInitUltraGridBind(grid1);
                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                ////grid2
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목유형", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "REMINDQTY", "잔여수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "PLANQTY", "생산계획수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "재고수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);

                _GridUtil.SetInitUltraGridBind(grid2);

                //grid3.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
                //grid3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

                //grid4
                _GridUtil.InitializeGrid(grid4, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANNO", "생산지시번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "RECDATE", "생산지시일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE2", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANQTY", "생산계획수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "SETQTY", "지시편성수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKQTY", "작업수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "CONTRACTSEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);

                grid4.DisplayLayout.Bands[0].Columns["ITEMCODE2"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid4.DisplayLayout.Bands[0].Columns["PLANQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid4);

                #region --- Combobox & Popup Setting ---

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;


                cbo_STARTDATE2_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE2_H.Value = DateTime.Now;

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("COMPLETE_FLAG");
                Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_CLOSEFLAG_H.Value = "N";

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });


                //bizGrid2Manager = new BizGridManager(grid4);
                //bizGrid2Manager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });


                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid4);
                _GridUtil.Grid_Clear(grid2);
                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sItemName = txt_ITEMNAME_H.Text.Trim();
                string sCloseFlag = DBHelper.nvlString(cbo_CLOSEFLAG_H.Value);

                base.DoInquire();

                dtGrid = helper.FillTable("USP_AP9996_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input));

                // grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, dtGrid, "ORDERDATE", Common.getLangText("[일자별 합계]","TEXT"), "ORDERDATE", "ORDERQTY,PRODQTY", "SUM,SUM");
                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);

                dtGrid = helper.FillTable("USP_AP9996_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                grid4.DataSource = dtGrid;
                grid4.DataBinds(dtGrid);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoNew()
        {
            //base.DoNew();

            //DBHelper helper = new DBHelper(false);

            //try
            //{

            //    if (grid1.IsActivate || grid4.IsActivate)
            //    {
            //        if (grid1.ActiveRow == null)
            //        {
            //            this.ShowDialog(Common.getLangText("편성할 품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
            //            return;
            //        }

            //        string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            //        string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            //        string sUnitCode = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
            //        string sItemCode2 = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE2"].Value);
            //        string sConNo = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
            //        string sConSeq = DBHelper.nvlString(grid1.ActiveRow.Cells["SEQ"].Value);

            //        this.grid4.InsertRow();

            //        //사업장과 사용여부는 행 추가시 기본으로 세팅
            //        this.grid4.ActiveRow.Cells["PLANTCODE"].Value = Convert.ToString(cbo_PLANTCODE_H.Value);
            //        this.grid4.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
            //        this.grid4.ActiveRow.Cells["ITEMCODE2"].Value = sItemCode2;
            //        this.grid4.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
            //        this.grid4.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;
            //        this.grid4.ActiveRow.Cells["CONTRACTNO"].Value = sConNo;
            //        this.grid4.ActiveRow.Cells["CONTRACTSEQ"].Value = sConSeq;
            //        this.grid4.ActiveRow.Cells["RECDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid4.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid4.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = string.Empty;
            string sOrderNO = string.Empty;
            string sItemCode = string.Empty;
            string sOrderDate = string.Empty;
            string sUser = LoginInfo.UserID;
            string sConNo = string.Empty;
            string sConSeq = string.Empty;
            string sPlanNo = "";

            //double dOrderQty;



            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        case DataRowState.Deleted:
                            //2020-07-10 삭제처리 추가함
                            if (this.ShowDialog(Common.getLangText("변경된 사항에 대해 삭제처리 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                            {
                                CancelProcess = true;
                                return;
                            }

                            drChange.RejectChanges();

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sPlanNo = DBHelper.nvlString(drChange["PLANNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);

                            helper.ExecuteNoneQuery("USP_AP9996_D1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                grid4.SetAcceptChanges();

                helper.Commit();

                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                ClosePrgFormNew();
            }
        }
        #endregion

        #region < EVENT AREA >

        /* 2019.11.15 수정 */
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {

            if (e.Cell.Row.Index < 0) return;

            DBHelper helper = new DBHelper(false);


            try
            {
                _GridUtil.Grid_Clear(grid2);


                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                string sItemCode = String.Empty;


                string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
                string sContractNo = Convert.ToString(this.grid1.ActiveRow.Cells["CONTRACTNO"].Value);         //실적일자

                if (sPlantCode == string.Empty || sContractNo == string.Empty)
                    return;

                sItemCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);



                dtGrid3 = helper.FillTable("USP_AP9996_S4", CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }
                else
                {
                    grid2.DataSource = dtGrid3;
                    grid2.DataBinds(dtGrid3);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        #endregion

        #region < METHOD AREA >

        #endregion

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dtChange = grid4.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = string.Empty;
            string sOrderNO = string.Empty;
            string sItemCode = string.Empty;
            string sOrderDate = string.Empty;
            string sUser = LoginInfo.UserID;
            string sConNo = string.Empty;
            string sConSeq = string.Empty;
            string sPlanNo = "";

            //double dOrderQty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();
                int iR = 0;
                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        //case DataRowState.Deleted:
                        //    //2020-07-10 삭제처리 추가함
                        //    drChange.RejectChanges();

                        //    sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                        //    sPlanNo = DBHelper.nvlString(drChange["PLANNO"]);
                        //    sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);

                        //    helper.ExecuteNoneQuery("USP_AP0012_D1", CommandType.StoredProcedure
                        //  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                        //  , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                        //  , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                        //  , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                        //    break;
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region --- 추가/수정/삭제 ---
                            string sPlanQty = "0";
                            sPlanQty = Convert.ToString(drChange["PLANQTY"]);

                            if (drChange.RowState == DataRowState.Deleted || sPlanQty == "0")
                            {
                                sPlanQty = "";
                            }

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sPlanNo = DBHelper.nvlString(drChange["PLANNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sOrderDate = DBHelper.nvlString(drChange["RECDATE"]);
                            sConNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            sConSeq = DBHelper.nvlString(drChange["CONTRACTSEQ"]);

                            helper.ExecuteNoneQuery("USP_AP9996_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RECDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sConNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTSEQ", sConSeq, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
                            //}

                            #endregion
                            break;
                    }
                    iR++;
                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                grid4.SetAcceptChanges();

                helper.Commit();

                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                ClosePrgFormNew();
            }
        }




        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (grid2.Rows.Count <= 0)
            {
                this.ShowDialog("품목집계항목 그리드에 값이 없습니다.", Forms.DialogForm.DialogType.OK);
            }
            for (int iRow = 0; iRow < grid2.Rows.Count; iRow++)
            {
                if (DBHelper.nvlBoolean(grid2.Rows[iRow].Cells["CHK"].Value) == true)
                {
                    grid2.Rows[iRow].Cells["CHK"].Value = false;
                }
                else
                {
                    grid2.Rows[iRow].Cells["CHK"].Value = true;
                }

            }
        }

        private void BtnCheck_ADD_Click(object sender, EventArgs e)
        {
            base.DoNew();

            DBHelper helper = new DBHelper(false);
            string sContractNo = string.Empty;
            string sContractSeq = string.Empty;
            try
            {
                for (int iRow = 0; iRow < grid2.Rows.Count; iRow++)
                {
                    if (DBHelper.nvlString(grid2.Rows[iRow].Cells["CONTRACTNO"].Value) != "")
                    {
                        sContractNo = DBHelper.nvlString(grid2.Rows[iRow].Cells["CONTRACTNO"].Value);
                    }
                    if (DBHelper.nvlString(grid2.Rows[iRow].Cells["SEQ"].Value) != "")
                    {
                        sContractSeq = DBHelper.nvlString(grid2.Rows[iRow].Cells["SEQ"].Value);
                    }




                    if (DBHelper.nvlBoolean(grid2.Rows[iRow].Cells["CHK"].Value) == true)
                    {
                        string sItemCode = DBHelper.nvlString(grid2.Rows[iRow].Cells["ITEMCODE"].Value);
                        string sItemName = DBHelper.nvlString(grid2.Rows[iRow].Cells["ITEMNAME"].Value);
                        string sUnitCode = DBHelper.nvlString(grid2.Rows[iRow].Cells["UNITCODE"].Value);
                        string sPlanqty = DBHelper.nvlString(grid2.Rows[iRow].Cells["CONTRACTQTY"].Value);
                        this.grid4.InsertRow();

                        //사업장과 사용여부는 행 추가시 기본으로 세팅
                        this.grid4.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                        this.grid4.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
                        this.grid4.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
                        this.grid4.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;
                        this.grid4.ActiveRow.Cells["PLANQTY"].Value = sPlanqty;
                        this.grid4.ActiveRow.Cells["RECDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                        this.grid4.ActiveRow.Cells["CONTRACTNO"].Value = sContractNo;
                        this.grid4.ActiveRow.Cells["CONTRACTSEQ"].Value = sContractSeq;
                    }
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {

            DBHelper helper = new DBHelper(false);
            try
            {

                _GridUtil.Grid_Clear(grid4);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE2_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE2_H.Value);
                string sItemCode = "";

                dtGrid = helper.FillTable("USP_AP9996_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                grid4.DataSource = dtGrid;
                grid4.DataBinds(dtGrid);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }





        ////자동편성
        //private void BtnAuto_Click(object sender, EventArgs e)
        //{
        //    if (grid4.Rows.Count <= 0)
        //    {
        //        this.ShowDialog("품목집계항목 먼저 실행해 주세요.", Forms.DialogForm.DialogType.OK);
        //    }
        //    else
        //    {
        //        DBHelper helper = new DBHelper(false);

        //        string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
        //        string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

        //        for (int iRow = 0; iRow < grid4.Rows.Count; iRow++)
        //        {
        //            string sPlantCode = grid4.Rows[iRow].Cells["PLANTCODE"].Value.ToString();
        //            string sItemCode = grid4.Rows[iRow].Cells["ITEMCODE"].Value.ToString();

        //            rtnDtTemp3 = helper.FillTable("USP_AP0015_S5", CommandType.StoredProcedure
        //                                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
        //                                      , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
        //                                      , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
        //                                      , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));

        //        }
        //    }

        //}


    }
}
