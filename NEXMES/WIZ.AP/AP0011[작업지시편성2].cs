#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0011
//   Form Name    : 작업지시 생성 및 확정
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
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

namespace WIZ.AP
{
    public partial class AP0011 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public AP0011()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0011_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;
            cbo_NEWORDERDATE_H.Value = DateTime.Now.AddDays(1);

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
            Common.FillComboboxMaster(this.cbo_ORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            Common.FillComboboxMaster(this.cbo_NEWORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERSTATUS");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0060_CODE("");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TIMETYPE");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "TIMETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });

            bizGridManager.PopUpClosed += BizGridManager_PopUpClosed;
            //bizGridManager.PopUpAdded += BizGridManager_PopUpAdded;
            #endregion

            dtGrid = (DataTable)grid1.DataSource;
        }

        private void BizGridManager_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
            if (bFindOK)
            {
                DBHelper helper = new DBHelper(false);

                try
                {
                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sWcCode = DBHelper.nvlString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);


                    rtnDtTemp = helper.FillTable("USP_AP0011_S3", CommandType.StoredProcedure
                                                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                              , helper.CreateParameter("AS_WORKCENTERCODE", sWcCode, DbType.String, ParameterDirection.Input));

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        DataRow[] rows = rtnDtTemp.Select();

                        grid1.ActiveRow.Cells["CYCLETIME"].Value = rows[0]["CYCLETIME"];
                        grid1.ActiveRow.Cells["TIMETYPE"].Value = DBHelper.nvlString(rows[0]["TIMETYPE"]).Trim();
                        grid1.ActiveRow.Cells["DEFAULTTIME"].Value = rows[0]["DEFAULTTIME"];
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

            //throw new NotImplementedException();
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERSTATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERTYPE", "지시구분", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 100, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CYCLETIME", "싸이클타임", false, GridColDataType_emu.Double, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "TIMETYPE", "시간타입", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DEFAULTTIME", "기준시간(시간)", false, GridColDataType_emu.Double, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITINFO", "단위", false, GridColDataType_emu.VarChar, 80, true, false);

                _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(grid1, "PRODQTY", Infragistics.Win.HAlign.Right);

                grid1.Columns["ORDERQTY"].Format = "#,##0";
                grid1.Columns["PRODQTY"].Format = "#,##0";

                grid1.DisplayLayout.Bands[0].Columns["ORDERSTATUS"].Header.Fixed = true;

                grid1.DisplayLayout.Bands[0].Columns["ORDERDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ORDERTYPE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
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
                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                base.DoInquire();

                dtGrid = helper.FillTable("USP_AP0011_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, dtGrid, "ORDERDATE", Common.getLangText("[일자별 합계]", "TEXT"), "ORDERDATE", "ORDERQTY,PRODQTY", "SUM,SUM");
                grid1.DataBind();

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["ORDERSTATUS"].Value) == "N")
                    {
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.LightPink;
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["ORDERSTATUS"].Value) == "Y")
                    {
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.LightGreen;
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["ORDERSTATUS"].Value) == "I")
                    {
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.LightYellow;
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Black;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["ORDERSTATUS"].Value) == "C")
                    {
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.BackColor = Color.SkyBlue;
                        grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.Black;
                    }
                }
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
            base.DoNew();

            DBHelper helper = new DBHelper(false);

            try
            {
                if (bNew == true)
                {
                    this.ShowDialog(Common.getLangText("생성 할 작업지시가 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                bNew = true;

                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

                rtnDtTemp = helper.FillTable("USP_AP0011_S2", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                for (int iRow = 0; iRow < rtnDtTemp.Rows.Count; iRow++)
                {
                    iRow = grid1.InsertRow();

                    grid1.Rows[iRow].Cells["ORDERSTATUS"].Value = rtnDtTemp.Rows[iRow]["ORDERSTATUS"];
                    grid1.Rows[iRow].Cells["PLANTCODE"].Value = rtnDtTemp.Rows[iRow]["PLANTCODE"];
                    grid1.Rows[iRow].Cells["ORDERDATE"].Value = rtnDtTemp.Rows[iRow]["ORDERDATE"];
                    grid1.Rows[iRow].Cells["WORKCENTERCODE"].Value = rtnDtTemp.Rows[iRow]["WORKCENTERCODE"];
                    grid1.Rows[iRow].Cells["ORDERNO"].Value = rtnDtTemp.Rows[iRow]["ORDERNO"];
                    grid1.Rows[iRow].Cells["ORDERTYPE"].Value = rtnDtTemp.Rows[iRow]["ORDERTYPE"];
                    grid1.Rows[iRow].Cells["ORDERQTY"].Value = rtnDtTemp.Rows[iRow]["ORDERQTY"];
                    grid1.Rows[iRow].Cells["PRODQTY"].Value = rtnDtTemp.Rows[iRow]["PRODQTY"];
                    grid1.Rows[iRow].Cells["CYCLETIME"].Value = rtnDtTemp.Rows[iRow]["CYCLETIME"];
                    grid1.Rows[iRow].Cells["TIMETYPE"].Value = 'S';


                    grid1.Rows[iRow].Cells["ORDERSTATUS"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["PLANTCODE"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["ORDERNO"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["WORKCENTERCODE"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["PRODQTY"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["UNITINFO"].Activation = Activation.Disabled;

                    grid1.UpdateData();
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

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid1.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid1.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = LoginInfo.PlantCode.Trim();
            string sOrderNO = string.Empty;
            string sWorkCenterCode = string.Empty;
            string sItemCode = string.Empty;
            string sOrderDate = string.Empty;
            string sOrderType = string.Empty;
            string sUser = LoginInfo.UserID;
            string sFrameID = string.Empty;
            string sSheetID = string.Empty;

            double dOrderQty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        case DataRowState.Deleted:
                            #region --- 삭제 ---
                            drChange.RejectChanges();

                            sOrderNO = Convert.ToString(drChange["ORDERNO"]);

                            helper.ExecuteNoneQuery("USP_AP0011_D1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region --- 추가 ---                            
                            sWorkCenterCode = Convert.ToString(drChange["WORKCENTERCODE"]);
                            sItemCode = Convert.ToString(drChange["ITEMCODE"]);
                            sOrderNO = Convert.ToString(drChange["ORDERNO"]);
                            sOrderDate = string.Format("{0:yyyy-MM-dd}", drChange["ORDERDATE"]);
                            sOrderType = Convert.ToString(drChange["ORDERTYPE"]);
                            double sCycleTime = DBHelper.nvlDouble(drChange["CYCLETIME"]);
                            string sTimeType = Convert.ToString(drChange["TIMETYPE"]);
                            double sDefaultTime = DBHelper.nvlDouble(drChange["DEFAULTTIME"]);

                            if (sItemCode == "")
                            {
                                continue;
                            }

                            if (sCycleTime == 0)
                            {
                                this.ShowDialog("싸이클타임을 설정해주세요.", Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (sTimeType == "")
                            {
                                this.ShowDialog("시간타입을 설정해주세요.", Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (sDefaultTime == 0)
                            {
                                this.ShowDialog("기준시간을 설정해주세요.", Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            //시간타입에 따라 계산변경
                            if (sTimeType == "S")
                            {
                                dOrderQty = Math.Truncate(sDefaultTime * 3600 / sCycleTime);
                            }
                            else if (sTimeType == "M")
                            {
                                dOrderQty = Math.Truncate(sDefaultTime * 60 / sCycleTime);
                            }
                            else
                            {
                                dOrderQty = Math.Truncate(sDefaultTime / sCycleTime);
                            }

                            helper.ExecuteNoneQuery("USP_AP0011_I1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AF_ORDERQTY", dOrderQty, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CYCLETIME", sCycleTime, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_TIMETYPE", sTimeType, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_DEFAULTTIME", sDefaultTime, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region --- 수정 ---
                            sWorkCenterCode = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sOrderNO = DBHelper.nvlString(drChange["ORDERNO"]);
                            sOrderDate = string.Format("{0:yyyy-MM-dd}", drChange["ORDERDATE"]);
                            sOrderType = DBHelper.nvlString(drChange["ORDERTYPE"]);
                            dOrderQty = DBHelper.nvlDouble(drChange["ORDERQTY"]);
                            sFrameID = DBHelper.nvlString(drChange["FRAMEID"]);
                            sSheetID = DBHelper.nvlString(drChange["SHEETID"]);

                            helper.ExecuteNoneQuery("USP_AP0011_I1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AF_ORDERQTY", dOrderQty, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_FRAMEID", sFrameID, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SHEETID", sSheetID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                        return;
                    }
                }

                grid1.SetAcceptChanges();

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
        private void btnOrderCopy_Click(object sender, EventArgs e)
        {
            DBHelper helper;

            try
            {
                helper = new DBHelper("", true);

                string sMakeDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERDATE_H.Value);
                string sOrderType = Convert.ToString(cbo_NEWORDERTYPE_H.Value);

                try
                {
                    helper.ExecuteNoneQuery("USP_AP0011_COPY", CommandType.StoredProcedure
                  , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_STANDDATE", "", DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();

                        DoInquire();
                    }
                    else if (helper.RSCODE == "C")
                    {
                        string sStandDate = helper.RSMSG;

                        helper = new DBHelper("", true);

                        try
                        {
                            DialogResult result = MessageBox.Show("금일 생성 된 작업지시가 없습니다." + Environment.NewLine + sStandDate + " 일 작업지시가 존재 합니다. 복사 하시겠습니까?", "작업지시 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            if (result.ToString().ToUpper() == "YES")
                            {
                                helper.ExecuteNoneQuery("USP_AP0011_COPY", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_STANDDATE", sStandDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "S")
                                {
                                    helper.Commit();

                                    DoInquire();
                                }
                                else
                                {
                                    helper.Rollback();

                                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();

                            this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                        }
                        finally
                        {
                            helper.Close();
                        }
                    }
                    else if (helper.RSCODE == "E")
                    {
                        helper.Rollback();

                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                        return;
                    }
                }
                catch (Exception ex)
                {
                    helper.Rollback();

                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                }
                finally
                {
                    helper.Close();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();
            }
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        private void btn_COPY_ITEM_Click(object sender, EventArgs e)
        {
            string itemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string itemName = Convert.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);

            if (itemCode != "")
            {
                int tmp2 = grid1.ActiveRow.Index + 1;
                int tmp = grid1.Rows.Count;

                grid1.Focus();
                grid1.ActiveRow = grid1.Rows[tmp2];
                grid1.ActiveRow.Selected = true;
                grid1.Rows[tmp2].Cells["ITEMCODE"].Value = itemCode;
                grid1.Rows[tmp2].Cells["ITEMNAME"].Value = itemName;
            }

        }
    }
}
