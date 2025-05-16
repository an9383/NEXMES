#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0025
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
    public partial class AP0025 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;
        BizGridManager bizGrid2Manager;

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
        public AP0025()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0025_Load(object sender, EventArgs e)
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
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TMPINDATE", "가입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO2", "재발행발주번호", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "발주순번", true, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TMPINGROUPNO", "발주그룹순번", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "최초수량", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "출하수량", true, GridColDataType_emu.Double, 80, 130, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTSTATUS", "LOT상태", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REORDER", "재발주처리", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, false, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //grid2
                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", true, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERNO", "작업지시번호", true, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERDATE", "작업지시일자", true, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE2", "품목", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 170, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERQTY", "지시편성수량", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMEID", "프레임ID", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKID", "마스크ID", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMENO", "프레임수주번호", true, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHEETNO", "시트수주번호", true, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "작업수량", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ROW_STATUS", "상태", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);

                grid2.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["UNITCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAMEID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAMENO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["SHEETNO"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid2);

                #region --- Combobox & Popup Setting ---

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-15);
                cbo_ENDDATE_H.Value = DateTime.Now;

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //2109.11.20 추가로 함
                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                bizGridManager = new BizGridManager(grid2);
                bizGridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });

                //bizGrid2Manager = new BizGridManager(grid2);
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });
                //bizGrid2Manager.PopUpAdd("ITEMCODE", "ITEMNAME", "BM0010", new string[] { "PLANTCODE", "1", "Y" }); ;
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

                base.DoInquire();

                    string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                            
                    string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");   
                    string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");     
                    string sItemCode = txt_ITEMCODE_H.Text.Trim();

                    rtnDtTemp = helper.FillTable("USP_AP0025_S1", CommandType.StoredProcedure
                                                 , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                 , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                    this.ClosePrgFormNew();

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);

                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
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

                    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                    //string sUnitCode = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                    string sPoNo = DBHelper.nvlString(grid1.ActiveRow.Cells["PONO2"].Value);

                    //string sFrameID = DBHelper.nvlString(grid1.ActiveRow.Cells["FRAMEID"].Value);
                    //string sMaskID = DBHelper.nvlString(grid1.ActiveRow.Cells["MASKID"].Value);
                    //string sFrameNo = DBHelper.nvlString(grid1.ActiveRow.Cells["FRAMENO"].Value);
                    //string sSheetNo = DBHelper.nvlString(grid1.ActiveRow.Cells["SHEETNO"].Value);

                    this.grid2.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid2.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
                    this.grid2.ActiveRow.Cells["CONTRACTNO"].Value = sPoNo;
                    this.grid2.ActiveRow.Cells["ITEMCODE2"].Value = sItemCode;
                    this.grid2.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
                    this.grid2.ActiveRow.Cells["WORKCENTERCODE"].Value = "WC0006";
                    this.grid2.ActiveRow.Cells["WORKCENTERNAME"].Value = "노광작업장";
                    this.grid2.ActiveRow.Cells["ORDERNO"].Value = "";
                    this.grid2.ActiveRow.Cells["ORDERDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    this.grid2.ActiveRow.Cells["ORDERQTY"].Value = "1";
                    this.grid2.ActiveRow.Cells["UNITCODE"].Value = "EA";


                    //this.grid2.ActiveRow.Cells["FRAMENO"].Value = sFrameNo;
                    //this.grid2.ActiveRow.Cells["SHEETNO"].Value = sSheetNo;

                    grid2.ActiveRow.Cells["PLANTCODE"].Activation = Activation.AllowEdit;
                    //grid2.ActiveRow.Cells["ITEMCODE2"].Activation = Activation.NoEdit;
                    //grid2.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.NoEdit;
                    //grid2.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;
                    grid2.ActiveRow.Cells["ORDERNO"].Activation = Activation.NoEdit;
                    //grid2.ActiveRow.Cells["LOTQTY"].Activation = Activation.NoEdit;
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "WORKCENTERCODE");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "FRAMEID");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "MASKID");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "ITEMCODE2");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "ITEMNAME");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "UNITCODE");
                    UltraGridUtil.ActivationAllowEdit(this.grid2, "ORDERDATE");

                    this.grid2.ActiveRow.Cells["REMARK"].Activation = splitContainer2.Panel2Collapsed ? Activation.AllowEdit : Activation.NoEdit;
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
            string sOrderNo = string.Empty;
            string sItemCode = string.Empty;
            string sOrderDate = string.Empty;
            string sUser = LoginInfo.UserID;
            string sWCCD = string.Empty;
            string sPoNo = "";
            string sFrameID = "";
            string sMaskID = "";
            string sFrameNo = "";
            string sSheetNo = "";

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
                            sPoNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE2"]);
                            sOrderDate = DBHelper.nvlString(drChange["ORDERDATE"]);
                            sWCCD = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sOrderNo = DBHelper.nvlString(drChange["ORDERNO"]);
                            sFrameID = DBHelper.nvlString(drChange["FRAMEID"]);
                            sMaskID = DBHelper.nvlString(drChange["MASKID"]);
                            sFrameNo = DBHelper.nvlString(drChange["FRAMENO"]);
                            sSheetNo = DBHelper.nvlString(drChange["SHEETNO"]);

                            helper.ExecuteNoneQuery("USP_AP0025_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", sWCCD, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
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
                            sFrameNo = Convert.ToString(drChange["FRAMENO"]);
                            sSheetNo = Convert.ToString(drChange["SHEETNO"]);

                            if (drChange.RowState == DataRowState.Deleted || sPlanQty == "0")
                            {
                                sPlanQty = "";
                            }

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sPoNo = DBHelper.nvlString(drChange["CONTRACTNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE2"]);
                            sOrderDate = DBHelper.nvlString(drChange["ORDERDATE"]);
                            sWCCD = DBHelper.nvlString(drChange["WORKCENTERCODE"]);
                            sOrderNo = DBHelper.nvlString(drChange["ORDERNO"]);

                            if (sWCCD == "")
                            {
                                throw new Exception("작업장코드가 없는 항목이 있습니다.");
                            }

                            helper.ExecuteNoneQuery("USP_AP0025_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_WORKCENTERCODE", sWCCD, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sPoNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SETQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_FRAMEID", sFrameID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MASKID", sMaskID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_FRAMENO", sFrameNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SHEETNO", sSheetNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", sUser, DbType.String, ParameterDirection.Input));

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

        #endregion

        #region < METHOD AREA >

        #endregion

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
                string sContractNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PONO2"].Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = Convert.ToString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);

                if (sPlantCode == string.Empty || sContractNo == string.Empty)
                    return;

                dtGrid2 = helper.FillTable("USP_AP0025_S3", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CONTRACTNO", sContractNo, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
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
