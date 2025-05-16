#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0013
//   Form Name    :  작업지시 복사
//   Name Space   : WIZ.AP
//   Created Date : 2020-05-04
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
    public partial class AP0013 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public AP0013()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0013_Load(object sender, EventArgs e)
        {
            GridInitialize(grid1);
            GridInitialize(grid2);

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;
            cbo_NEWORDERSTARTDATE_H.Value = DateTime.Now.AddDays(1);
            cbo_NEWORDERENDDATE_H.Value = DateTime.Now.AddMonths(1);

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
            Common.FillComboboxMaster(this.cbo_ORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            Common.FillComboboxMaster(this.cbo_NEWORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ORDERSTATUS");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "ORDERSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0060_CODE("");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid2, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });

            bizGridManager = new BizGridManager(grid2);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });

            #endregion

            dtGrid = (DataTable)grid1.DataSource;
            dtGrid2 = (DataTable)grid2.DataSource;
        }

        private void GridInitialize(UltraGrid oGrid)
        {
            try
            {
                _GridUtil.InitializeGrid(oGrid, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(oGrid, "ORDERSTATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(oGrid, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
                _GridUtil.InitColumnUltraGrid(oGrid, "ORDERDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 100, true, true);
                _GridUtil.InitColumnUltraGrid(oGrid, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, true, true);
                _GridUtil.InitColumnUltraGrid(oGrid, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
                _GridUtil.InitColumnUltraGrid(oGrid, "ORDERTYPE", "지시구분", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(oGrid, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, true, false);
                _GridUtil.InitColumnUltraGrid(oGrid, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, true, false);
                _GridUtil.InitColumnUltraGrid(oGrid, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(oGrid, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, true, false);
                _GridUtil.InitColumnUltraGrid(oGrid, "UNITINFO", "단위", false, GridColDataType_emu.VarChar, 80, true, false);

                _GridUtil.SetColumnTextHAlign(oGrid, "PLANTCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(oGrid, "WORKCENTERCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(oGrid, "ITEMCODE", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(oGrid, "ITEMNAME", Infragistics.Win.HAlign.Left);
                _GridUtil.SetColumnTextHAlign(oGrid, "ORDERQTY", Infragistics.Win.HAlign.Right);
                _GridUtil.SetColumnTextHAlign(oGrid, "PRODQTY", Infragistics.Win.HAlign.Right);

                oGrid.DisplayLayout.Bands[0].Columns["ORDERQTY"].Format = "#,##0";
                oGrid.DisplayLayout.Bands[0].Columns["PRODQTY"].Format = "#,##0";

                oGrid.DisplayLayout.Bands[0].Columns["ORDERSTATUS"].Header.Fixed = true;

                oGrid.DisplayLayout.Bands[0].Columns["ORDERDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                oGrid.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                oGrid.DisplayLayout.Bands[0].Columns["ORDERTYPE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                oGrid.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                oGrid.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(oGrid);

                oGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
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
            if (bNew)
            {
                DialogResult result = MessageBox.Show("저장되지 않은 작업지시가 있습니다. 재조회 하시겠습니까?", "작업지시 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result.ToString().ToUpper() == "NO")
                {
                    return;
                }
            }

            bNew = false;

            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                base.DoInquire();

                dtGrid = helper.FillTable("USP_AP0010_S1", CommandType.StoredProcedure
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
            this.grid2.InsertRow();
        }

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid2.DeleteRow();
        }

        public override void DoSave()
        {
            string sPlantCode = LoginInfo.PlantCode.Trim();
            string sOrderNO = string.Empty;
            string sLotNo = string.Empty;
            string sWorkCenterCode = string.Empty;
            string sItemCode = string.Empty;
            string sOrderDate = string.Empty;
            string sOrderType = string.Empty;
            string sUser = LoginInfo.UserID;

            double dOrderQty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (UltraGridRow dr in grid2.Rows)
                {
                    #region --- 추가 ---                            
                    sWorkCenterCode = Convert.ToString(dr.Cells["WORKCENTERCODE"].Value);
                    sItemCode = Convert.ToString(dr.Cells["ITEMCODE"].Value);
                    sOrderNO = Convert.ToString(dr.Cells["ORDERNO"].Value);
                    sLotNo = "";
                    sOrderDate = string.Format("{0:yyyy-MM-dd}", dr.Cells["ORDERDATE"].Value);
                    sOrderType = Convert.ToString(dr.Cells["ORDERTYPE"].Value);
                    dOrderQty = DBHelper.nvlDouble(dr.Cells["ORDERQTY"].Value);

                    helper.ExecuteNoneQuery("USP_AP0010_I1", CommandType.StoredProcedure
                  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AF_ORDERQTY", dOrderQty, DbType.Double, ParameterDirection.Input)
                  , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                        return;
                    }
                    #endregion
                }

                grid1.SetAcceptChanges();
                grid2.SetAcceptChanges();

                helper.Commit();

                bNew = false;
                DoInquire();

                this.ShowDialog("작업지시 복사 완료", Forms.DialogForm.DialogType.OK);
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
            DBHelper helper = new DBHelper(false);

            try
            {
                if (bNew)
                {
                    DialogResult result = MessageBox.Show("저장되지 않은 작업지시가 있습니다. 재복사 하시겠습니까?", "작업지시 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result.ToString().ToUpper() == "NO")
                    {
                        return;
                    }
                }

                bNew = true;
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sMakeSDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERSTARTDATE_H.Value);
                string sMakeEDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();

                grid2.DataSource = helper.FillTable("USP_AP0013_S3", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_MAKESDATE", sMakeSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_MAKEEDATE", sMakeEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));
                grid2.DataBind();

                // grid2.DisplayLayout.Bands[0].Columns["ORDERSTATUS"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["ORDERNO"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["ORDERDATE"].CellActivation = Activation.Disabled;
                //grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["PRODQTY"].CellActivation = Activation.Disabled;
                // grid2.DisplayLayout.Bands[0].Columns["UNITINFO"].CellActivation = Activation.Disabled;
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

        //일일 작업지시 일괄 복사
        private void btnOrderCopy_Click_OLD(object sender, EventArgs e)
        {
            DBHelper helper;

            string sPlantCode = LoginInfo.PlantCode.Trim();
            string sUser = LoginInfo.UserID.Trim();

            helper = new DBHelper("", true);
            try
            {
                foreach (UltraGridRow dr in grid1.Rows)
                {
                    string sWorkCenterCode = Convert.ToString(dr.Cells["WORKCENTERCODE"].Value);
                    string sItemCode = Convert.ToString(dr.Cells["ITEMCODE"].Value);
                    string sOrderNO = Convert.ToString(dr.Cells["ORDERNO"].Value);
                    string sLotNo = DBHelper.nvlString(dr.Cells["LOTNO"].Value); //실제 프로시져상  사용 X
                    string sMakeDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWORDERSTARTDATE_H.Value); // 작업지시 내릴 일자
                    string sOrderType = Convert.ToString(dr.Cells["ORDERTYPE"].Value);
                    double dOrderQty = DBHelper.nvlDouble(dr.Cells["ORDERQTY"].Value);

                    if (string.IsNullOrEmpty(sOrderNO))
                    {
                        continue;
                    }

                    sOrderNO = Convert.ToString("[ NEW ORDER ]");

                    try
                    {
                        helper.ExecuteNoneQuery("USP_AP0010_I1", CommandType.StoredProcedure
                  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_LOT", sLotNo, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ORDERDATE", sMakeDate, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AF_ORDERQTY", dOrderQty, DbType.Double, ParameterDirection.Input)
                  , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();
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
                        break;
                    }
                } //foreach

                //금일 작업지시 조회
                cbo_STARTDATE_H.Value = cbo_NEWORDERSTARTDATE_H.Value;
                cbo_ENDDATE_H.Value = cbo_NEWORDERSTARTDATE_H.Value;

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

        #region < METHOD AREA >

        #endregion

    }//CLASS
}//NAMESPACE
