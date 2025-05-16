#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0018
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
using System.Text;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0018 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();

        DataTable dtGrid;
        DataTable dtGrid2;

        EnumMethod sMethodCode1 = EnumMethod.NONE;
        EnumMethod sMethodCode2 = EnumMethod.NONE;
        //EnumMethod sMethodCode3 = EnumMethod.NONE;

        string sDef_WC = "";

        enum EnumMethod { LINK, REMIND_CHK, ITEMCODE, NOTLINK_OPCODE, NONE };
        #endregion

        #region < CONSTRUCTOR >
        public AP0018()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0018_Load(object sender, EventArgs e)
        {
            GridInitialize();
        }

        /// <summary>
        /// SetSubData 는 SetGridHead 이후에 실행
        /// </summary>
        protected override void SetSubData()
        {
            //btnLink.Enabled = (((WIZ.MAIN.ZA0003)this.MdiParent).GetToolBarStatus("NewFunc"));
            DataRow dr = subData["METHOD_TYPE", "BASE"];

            splitContainer2.Panel2Collapsed = true;

            if (dr != null)
            {
                sMethodCode1 = CModule.ToString(dr["RELCODE1"]) == "LINK" ? EnumMethod.LINK : EnumMethod.NONE;
                sMethodCode2 = CModule.ToString(dr["RELCODE2"]) == "ITEMCODE" ? EnumMethod.ITEMCODE : EnumMethod.NONE;
                //sMethodCode3 = CModule.ToString(dr["RELCODE3"]) == "N" ? EnumMethod.NOTLINK_OPCODE : EnumMethod.NONE;

                if (sMethodCode1 == EnumMethod.LINK)
                {
                    splitContainer2.Panel2Collapsed = false;

                    rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
                    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RELCODE2", rtnDtTemp, "CODE_ID", "CODE_NAME");

                    grid2.Columns["REMARK"].CellActivation = Activation.NoEdit;

                    //GridExtendUtil.SetLink(splitContainer2.Panel2, grid2, null, "ROW_STATUS");
                }

            }

            //if (sMethodCode3 == EnumMethod.NOTLINK_OPCODE)
            //{
            //    bizGridManager = new BizGridManager(grid2);
            //    bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });

            //} 
            //else if (sMethodCode3 == EnumMethod.NONE)
            //{
            //    bizGridManager = new BizGridManager(grid2);
            //    bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "OPCODE", "Y" });
            //}

            dr = subData["METHOD_TYPE", "INIT_WC"];

            if (dr != null)
            {
                sDef_WC = CModule.ToString(dr["RELCODE1"]);
            }
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
                _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산계획번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "생산계획일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "작업지시일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE2", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "SETQTY", "지시편성수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "WORKQTY", "작업수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "FRAMEID", "프레임ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MASKID", "마스크ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);
                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                //grid2
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANNO", "생산계획번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERDATE", "작업지시일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE2", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERQTY", "지시편성수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "작업수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "FRAMEID", "프레임ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "MASKID", "마스크ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ROW_STATUS", "상태", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);

                grid2.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid2);

                #region --- Combobox & Popup Setting ---

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-3);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
                //Common.FillComboboxMaster(this.cbo_ORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                ////Common.FillComboboxMaster(this.cbo_NEWORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("ORDERSTATUS");
                //UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //2109.11.20 추가로 함
                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                bizGridManager = new BizGridManager(grid2);
                //bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "OPCODE", "Y" });
                bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

                //GridExtendUtil.SetLink(null, grid1, Grid_Search);
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
                _GridUtil.Grid_Clear(grid2);

                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sItemName = txt_ITEMNAME_H.Text.Trim();

                base.DoInquire();

                dtGrid = helper.FillTable("USP_AP0018_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       );

                // grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, dtGrid, "ORDERDATE", Common.getLangText("[일자별 합계]","TEXT"), "ORDERDATE", "ORDERQTY,PRODQTY", "SUM,SUM");
                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);

                dtGrid = helper.FillTable("USP_AP0018_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       );

                grid2.DataSource = dtGrid;
                grid2.DataBinds(dtGrid);
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
                _GridUtil.Grid_Clear(grid2);
                if (grid1.IsActivate || grid2.IsActivate)
                {
                    if (grid1.ActiveRow == null)
                    {
                        this.ShowDialog(Common.getLangText("편성할 품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    //string sCLOSEFLAG = DBHelper.nvlString(grid1.ActiveRow.Cells["CLOSEFLAG"].Value);

                    //if (sCLOSEFLAG == "Y")
                    //{
                    //    SetStatusMessage("이미 편성 완료된 수주입니다.");
                    //    return;
                    //}

                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                    string sUnitCode = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                    string sItemCode2 = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE2"].Value);
                    string sPlanNo = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANNO"].Value);
                    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sOrderqty = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANQTY"].Value);

                    this.grid2.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid2.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
                    this.grid2.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
                    this.grid2.ActiveRow.Cells["ITEMCODE2"].Value = sItemCode2;
                    this.grid2.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
                    this.grid2.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;
                    this.grid2.ActiveRow.Cells["PLANNO"].Value = sPlanNo;
                    this.grid2.ActiveRow.Cells["WORKCENTERCODE"].Value = "";
                    this.grid2.ActiveRow.Cells["WORKCENTERNAME"].Value = "";
                    this.grid2.ActiveRow.Cells["ORDERNO"].Value = "";
                    this.grid2.ActiveRow.Cells["ORDERDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    this.grid2.ActiveRow.Cells["OPCODE"].Value = DBHelper.nvlString(grid1.ActiveRow.Cells["OPCODE"].Value);
                    this.grid2.ActiveRow.Cells["ORDERQTY"].Value = sOrderqty;
                    this.grid2.ActiveRow.Cells["FRAMEID"].Value = "";
                    this.grid2.ActiveRow.Cells["MASKID"].Value = "";

                    grid2.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ITEMCODE2"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["PLANNO"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ORDERNO"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["LOTQTY"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["OPCODE"].Activation = Activation.NoEdit;
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "WORKCENTERCODE");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "ORDERQTY");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "FRAMEID");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "MASKID");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "ORDERDATE");

                    this.grid2.ActiveRow.Cells["REMARK"].Activation = splitContainer2.Panel2Collapsed ? Activation.AllowEdit : Activation.NoEdit;

                    this.grid2.ActiveRow.Cells["WORKCENTERCODE"].Value = sDef_WC;
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

            this.grid2.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid2.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = string.Empty;
            string sOrderNO = string.Empty;
            string sItemCode = string.Empty;
            string sOrderDate = string.Empty;
            string sUser = LoginInfo.UserID;
            string sWCCD = string.Empty;
            string sPlanNo = "";
            string sFrameID = "";
            string sMaskID = "";

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
                        case DataRowState.Deleted:

                            drChange.RejectChanges();

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sPlanNo = DBHelper.nvlString(drChange["PLANNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sOrderDate = DBHelper.nvlString(drChange["ORDERDATE"]);
                            sWCCD = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sOrderNO = DBHelper.nvlString(drChange["ORDERNO"]);
                            sFrameID = DBHelper.nvlString(drChange["FRAMEID"]);
                            sMaskID = DBHelper.nvlString(drChange["MASKID"]);

                            helper.ExecuteNoneQuery("USP_AP0018_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", sWCCD, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", sUser, DbType.String, ParameterDirection.Input));

                            break;

                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region --- 추가/수정/삭제 ---
                            string sPlanQty = "0";

                            sPlanQty = Convert.ToString(drChange["ORDERQTY"]);
                            sFrameID = Convert.ToString(drChange["FRAMEID"]);
                            sMaskID = Convert.ToString(drChange["MASKID"]);

                            if (drChange.RowState == DataRowState.Deleted || sPlanQty == "0")
                            {
                                sPlanQty = "";
                            }

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sPlanNo = DBHelper.nvlString(drChange["PLANNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);
                            sOrderDate = DBHelper.nvlString(drChange["ORDERDATE"]);
                            sWCCD = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sOrderNO = DBHelper.nvlString(drChange["ORDERNO"]);

                            if (sWCCD == "")
                            {
                                throw new Exception("작업장코드가 없는 항목이 있습니다.");
                            }

                            helper.ExecuteNoneQuery("USP_AP0018_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", sWCCD, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", sOrderNO, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SETQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("FRAMEID", sFrameID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("MASKID", sMaskID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", sUser, DbType.String, ParameterDirection.Input));
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

                grid2.SetAcceptChanges();

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

                DoInquire();
            }
        }
        #endregion

        #region < EVENT AREA >

        /* 2019.11.15 수정 */
        //private void Grid_Search()
        //{
        //    if (btnLink.Text == "클릭시 조회")
        //    {
        //        DBHelper helper = new DBHelper(false);

        //        try
        //        {
        //            _GridUtil.Grid_Clear(grid2);

        //            if (sMethodCode2 == EnumMethod.ITEMCODE)
        //            {
        //                // 서브는 품목을 기준으로 조회
        //                string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
        //                string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);

        //                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
        //                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

        //                if (sPlantCode == string.Empty || sItemCode == string.Empty)
        //                    return;

        //                dtGrid2 = helper.FillTable("USP_AP0018_S2", CommandType.StoredProcedure
        //                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));
        //            }
        //            else
        //            {
        //                // 기본은 생산계획번호를 기준으로 조회
        //                string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
        //                string sPlanNo = Convert.ToString(this.grid1.ActiveRow.Cells["PLANNO"].Value);         //실적일자

        //                if (sPlantCode == string.Empty || sPlanNo == string.Empty)
        //                    return;

        //                dtGrid2 = helper.FillTable("USP_AP0018_S2", CommandType.StoredProcedure
        //                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input));
        //            }

        //            if (dtGrid2.Rows.Count > 0)
        //            {
        //                grid2.DataSource = dtGrid2;
        //                grid2.DataBinds(dtGrid2);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //        finally
        //        {
        //            helper.Close();
        //            this.ClosePrgFormNew();
        //        }
        //    }
        //}

        //private void btnLink_Click(object sender, EventArgs e)
        //{
        //    if (btnLink.Text == "클릭시 조회")
        //    {
        //        btnLink.Text = "더블 클릭시 추가";
        //    }
        //    else
        //    {
        //        btnLink.Text = "클릭시 조회";
        //    }
        //}
        #endregion

        #region < METHOD AREA >

        #endregion

        //private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        //{
        //    if (btnLink.Text == "더블 클릭시 추가")
        //    {
        //        if (((WIZ.MAIN.ZA0003)this.MdiParent).GetToolBarStatus("NewFunc"))
        //        {
        //            ((WIZ.MAIN.ZA0003)this.MdiParent).tlbMain_Click_ByTag("NewFunc");
        //        }
        //    }
        //}

        //private void AP0018_Shown(object sender, EventArgs e)
        //{
        //    btnLink.Enabled = (((WIZ.MAIN.ZA0003)this.MdiParent).GetToolBarStatus("NewFunc"));
        //}

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;

            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid2);

            if (grid1.Rows.Count <= 0)
                return;


            try
            {
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sPlanNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PLANNO"].Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value).Trim();

                if (sPlantCode == string.Empty || sPlanNo == string.Empty)
                    return;

                dtGrid2 = helper.FillTable("USP_AP0018_S3", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", grid1.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_PLANNO", grid1.ActiveRow.Cells["PLANNO"].Value, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", grid1.ActiveRow.Cells["ITEMCODE"].Value, DbType.String, ParameterDirection.Input)
                       );

                grid2.DataSource = dtGrid2;
                grid2.DataBinds(dtGrid2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);

            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }


    }
}
