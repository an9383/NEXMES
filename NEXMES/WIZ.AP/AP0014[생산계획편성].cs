#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0014
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
    public partial class AP0014 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();

        DataTable dtGrid;

        string sColorType = "";

        EnumMethod sMethodCode1 = EnumMethod.NONE;
        EnumMethod sMethodCode2 = EnumMethod.NONE;

        enum EnumMethod { LINK, REMIND_CHK, NONE };
        #endregion

        #region < CONSTRUCTOR >
        public AP0014()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0014_Load(object sender, EventArgs e)
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
                sMethodCode2 = CModule.ToString(dr["RELCODE2"]) == "REMIND_CHK" ? EnumMethod.REMIND_CHK : EnumMethod.NONE;

                if (sMethodCode1 == EnumMethod.LINK)
                {
                    splitContainer2.Panel2Collapsed = false;

                    rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
                    WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "RELCODE2", rtnDtTemp, "CODE_ID", "CODE_NAME");

                    grid4.Columns["REMARK"].CellActivation = Activation.NoEdit;

                    GridExtendUtil.SetLink(splitContainer2.Panel2, grid4, null, "ROW_STATUS");
                }

                // 데이터를 통한 추가 처리 기능 구현
                DataRow tdr = subData["METHOD_TYPE", "ROWCOLOR"];

                if (tdr != null)
                {
                    sColorType = CModule.ToString(tdr["RELCODE1"]);
                }
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
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTDATE", "수주일자", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE2", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "편성계획수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMQTY", "잔여수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMQTY_HD", "잔여수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DUEDATE", "만기일자", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CLOSEFLAG", "완료여부", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);

                _GridUtil.SetInitUltraGridBind(grid1);
                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                ////grid3
                //_GridUtil.InitializeGrid(grid3, true, false, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Left, false, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);              
                //_GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "ITEMTYPE", "품목유형", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Left, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(grid3, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "REMINDQTY", "잔여수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "PLANQTY", "생산계획수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                //_GridUtil.InitColumnUltraGrid(grid3, "NOWQTY", "재고수량", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);

                //_GridUtil.SetInitUltraGridBind(grid3);

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
                _GridUtil.InitColumnUltraGrid(grid4, "PLANQTY", "생산계획수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "PLANQTY_HD", "생산계획수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "SETQTY", "지시편성수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "WORKQTY", "작업수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Right, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "CONTRACTSEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "ROW_STATUS", "변경", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid4, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, true);

                grid4.DisplayLayout.Bands[0].Columns["ITEMCODE2"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid4.DisplayLayout.Bands[0].Columns["PLANQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;

                _GridUtil.SetInitUltraGridBind(grid4);

                #region --- Combobox & Popup Setting ---

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid4, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("AP0110_FLAG");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE");
                //Common.FillComboboxMaster(this.cbo_ORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                ////Common.FillComboboxMaster(this.cbo_NEWORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //rtnDtTemp = _Common.GET_BM0000_CODE("ORDERSTATUS");
                //UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //2109.11.20 추가로 함
                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid4, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


                rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE"); //품목유형

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

                btbManager.PopUpClosed += BtbManager_PopUpClosed;

                bizGridManager = new BizGridManager(grid4);
                bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });

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

                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sItemName = txt_ITEMNAME_H.Text.Trim();

                base.DoInquire();

                string sCHECKLIST = chk1.Checked ? CModule.ToString(chk1.Tag) : "";
                sCHECKLIST += "|" + (chk2.Checked ? CModule.ToString(chk2.Tag) : "");
                sCHECKLIST += "|" + (chk3.Checked ? CModule.ToString(chk3.Tag) : "");
                sCHECKLIST += "|" + (chk4.Checked ? CModule.ToString(chk4.Tag) : "");

                dtGrid = helper.FillTable("USP_AP0014_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input)
                       );

                // grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, dtGrid, "ORDERDATE", Common.getLangText("[일자별 합계]","TEXT"), "ORDERDATE", "ORDERQTY,PRODQTY", "SUM,SUM");
                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);

                dtGrid = helper.FillTable("USP_AP0014_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       );

                grid4.DataSource = dtGrid;
                grid4.DataBinds(dtGrid);

                SetColor(grid1);

                btnLink.Text = "클릭시 조회";

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

        private void SetColor(WIZ.Control.Grid grid)
        {
            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                Color coBack = Color.White;
                Color coFore = Color.Black;

                string sClose = CModule.ToString(grid1.Rows[i].Cells["CLOSEFLAG"].Value);

                if (sClose != "D")
                {
                    if (sClose == "A")
                    {
                        // 지시완료
                        coBack = Color.LightGreen;
                        coFore = Color.Black;
                    }
                    else if (sClose == "B")
                    {
                        // 지시편성
                        coBack = Color.LemonChiffon;
                        coFore = Color.Black;
                    }
                    else if (sClose == "C")
                    {
                        // 계획편성
                        coBack = Color.LightPink;
                        coFore = Color.Black;
                    }

                    if (sColorType == "COLOR1")
                    {
                        grid1.Rows[i].CellAppearance.BackColor = coBack;
                        grid1.Rows[i].CellAppearance.ForeColor = coFore;
                    }
                    else
                    {
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = coBack;
                        grid1.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = coFore;
                    }
                }
            }
        }

        public override void DoNew()
        {
            base.DoNew();

            DBHelper helper = new DBHelper(false);

            try
            {

                if (grid1.IsActivate || grid4.IsActivate)
                {
                    if (grid1.ActiveRow == null)
                    {
                        this.ShowDialog(Common.getLangText("편성할 품목을 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    if (sMethodCode2 == EnumMethod.REMIND_CHK)
                    {
                        if (DBHelper.nvlDouble(grid1.ActiveRow.Cells["REMQTY"].Value) <= 0)
                        {
                            stsMessage = "잔여 수량이 없습니다.";
                            //SetStatusMessage("이미 편성완료된 수주입니다.");
                            return;
                        }
                    }

                    string sItemCode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sItemName = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
                    string sUnitCode = DBHelper.nvlString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                    string sItemCode2 = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE2"].Value);
                    string sConNo = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    string sConSeq = DBHelper.nvlString(grid1.ActiveRow.Cells["SEQ"].Value);
                    double dRemQty = DBHelper.nvlDouble(grid1.ActiveRow.Cells["REMQTY"].Value);

                    this.grid4.InsertRow();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid4.ActiveRow.Cells["PLANTCODE"].Value = Convert.ToString(cbo_PLANTCODE_H.Value);
                    this.grid4.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
                    this.grid4.ActiveRow.Cells["ITEMCODE2"].Value = sItemCode2;
                    this.grid4.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
                    this.grid4.ActiveRow.Cells["UNITCODE"].Value = sUnitCode;
                    this.grid4.ActiveRow.Cells["CONTRACTNO"].Value = sConNo;
                    this.grid4.ActiveRow.Cells["CONTRACTSEQ"].Value = sConSeq;
                    this.grid4.ActiveRow.Cells["RECDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    this.grid4.ActiveRow.Cells["PLANQTY"].Value = dRemQty;
                    this.grid4.ActiveRow.Cells["PLANQTY_HD"].Value = 0;
                    this.grid4.ActiveRow.Cells["REMARK"].Activation = splitContainer2.Panel2Collapsed ? Activation.AllowEdit : Activation.NoEdit;

                    // 다나와컴퓨터 로직일 경우
                    if (sMethodCode1 == EnumMethod.LINK)
                    {
                        // 비고에서 마스터 번호 추출
                        string sRemark = DBHelper.nvlString(grid1.ActiveRow.Cells["REMARK"].Value);

                        string sResult = "";

                        int iStartIdx = sRemark.IndexOf("생산번호");
                        int iEndIdx = sRemark.IndexOf("마스터");

                        if (iStartIdx >= 0 && iEndIdx >= 0)
                        {
                            if (iStartIdx < iEndIdx)
                            {
                                string sText = sRemark.Substring(iStartIdx, iEndIdx - iStartIdx);

                                for (int i = 0; i < sText.Length; i++)
                                {
                                    if (sText[i] >= '0' && sText[i] <= '9')
                                    {
                                        sResult += sText[i];
                                    }
                                }

                                if (sResult.Trim().Length > 0)
                                {
                                    this.grid4.ActiveRow.Cells["RELCODE1"].Value = sResult;
                                    this.grid4.ActiveRow.Cells["RELCODE2"].Value = "Y";
                                }
                            }
                        }
                    }

                    SetRemQty(sConNo, sConSeq);
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

        private void SetRemQty(string sContractNo, string sContractSeq)
        {
            double dRemQty = 0;
            double dPlanQty = 0;

            foreach (UltraGridRow r in grid4.Rows)
            {
                string sno = CModule.ToString(r.Cells["CONTRACTNO"].Value);
                string sSeq = CModule.ToString(r.Cells["CONTRACTSEQ"].Value);

                if (sContractNo == sno && sContractSeq == sSeq)
                {
                    double dP = CModule.ToDouble(r.Cells["PLANQTY"].Value);
                    double dPH = CModule.ToDouble(r.Cells["PLANQTY_HD"].Value);

                    dPlanQty += dP - dPH;
                }
            }

            foreach (UltraGridRow row in grid1.Rows)
            {
                string sno = CModule.ToString(row.Cells["CONTRACTNO"].Value);
                string sSeq = CModule.ToString(row.Cells["SEQ"].Value);

                if (sContractNo == sno && sContractSeq == sSeq)
                {
                    dRemQty = CModule.ToDouble(row.Cells["REMQTY_HD"].Value);

                    dRemQty -= dPlanQty;

                    if (sMethodCode2 == EnumMethod.REMIND_CHK)
                    {
                        row.Cells["REMQTY"].Value = dRemQty >= 0 ? dRemQty : 0;
                    }
                    else
                    {
                        row.Cells["REMQTY"].Value = dRemQty;
                    }
                    break;
                }
            }
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
                int iR = 0;
                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        case DataRowState.Deleted:
                            //2020-07-10 삭제처리 추가함
                            drChange.RejectChanges();

                            sPlantCode = DBHelper.nvlString(drChange["PLANTCODE"]);
                            sPlanNo = DBHelper.nvlString(drChange["PLANNO"]);
                            sItemCode = DBHelper.nvlString(drChange["ITEMCODE"]);

                            helper.ExecuteNoneQuery("USP_AP0012_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                            break;
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

                            helper.ExecuteNoneQuery("USP_AP0015_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_PLANNO", sPlanNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RECDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AF_PLANQTY", sPlanQty, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTNO", sConNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CONTRACTSEQ", sConSeq, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_REMARK", CModule.ToString(drChange["REMARK"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE1", CModule.ToString(drChange["RELCODE1"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE2", CModule.ToString(drChange["RELCODE2"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RELCODE3", CModule.ToString(drChange["RELCODE3"]), DbType.String, ParameterDirection.Input)
                            );
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
        #endregion

        #region < EVENT AREA >

        /* 2019.11.15 수정 */
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (btnLink.Text == "클릭시 조회")
            {
                if (e.Cell.Row.Index < 0) return;

                DBHelper helper = new DBHelper(false);

                try
                {
                    _GridUtil.Grid_Clear(grid4);

                    string sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);       //공장코드
                    string sCONTRACTNO = Convert.ToString(this.grid1.ActiveRow.Cells["CONTRACTNO"].Value);         //실적일자
                    string sCONTRACTSEQ = DBHelper.nvlString(this.grid1.ActiveRow.Cells["SEQ"].Value);
                    string sItemCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                    string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                    if (sPlantCode == string.Empty || sCONTRACTNO == string.Empty)
                        return;

                    dtGrid = helper.FillTable("USP_AP0014_S2", CommandType.StoredProcedure
                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTNO", sCONTRACTNO, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CONTRACTSEQ", sCONTRACTSEQ, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                           );

                    //dtGrid2 = helper.FillTable("USP_AP0015_S2", CommandType.StoredProcedure
                    //       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    //       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                    //       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                    //       , helper.CreateParameter("AS_CONTRACTNO", sCONTRACTNO, DbType.String, ParameterDirection.Input)
                    //       , helper.CreateParameter("AS_CONTRACTSEQ", sCONTRACTSEQ, DbType.String, ParameterDirection.Input)
                    //       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    //       );

                    if (dtGrid.Rows.Count > 0)
                    {
                        grid4.DataSource = dtGrid;
                        grid4.DataBinds(dtGrid);
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
        }

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (btnLink.Text == "더블 클릭시 추가")
            {
                if (((WIZ.MAIN.ZA0003)this.MdiParent).GetToolBarStatus("NewFunc"))
                {
                    ((WIZ.MAIN.ZA0003)this.MdiParent).tlbMain_Click_ByTag("NewFunc");
                }
            }
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        private void BtnSum_Click(object sender, EventArgs e)
        {
            //_GridUtil.Grid_Clear(grid3);

            //DBHelper helper = new DBHelper(false);

            //string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
            //string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

            //string sItemCode = txt_ITEMCODE_H.Text.Trim();
            //string sPlantCode = String.Empty;

            //if (grid1.Rows.Count <= 0)
            //    return;

            //sPlantCode = DBHelper.nvlString(grid1.Rows[0].Cells["PLANTCODE"].Value);

            //dtGrid3 = helper.FillTable("USP_AP0015_S4", CommandType.StoredProcedure
            //                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
            //                                   , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
            //                                   , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));

            //grid3.DataSource = dtGrid3;
            //grid3.DataBinds(dtGrid3);
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (btnLink.Text == "클릭시 조회")
            {
                btnLink.Text = "더블 클릭시 추가";
            }
            else
            {
                btnLink.Text = "클릭시 조회";

            }
        }

        private void grid4_AfterExitEditMode(object sender, EventArgs e)
        {
            // 계획 수량 수정할 때 
            if (grid4.ActiveCell.Column.Key == "PLANQTY")
            {
                string sNO = CModule.ToString(grid4.ActiveRow.Cells["CONTRACTNO"].Value);
                string sSeq = CModule.ToString(grid4.ActiveRow.Cells["CONTRACTSEQ"].Value);

                SetRemQty(sNO, sSeq);
            }
        }

        private void AP0014_Shown(object sender, EventArgs e)
        {
            btnLink.Enabled = (((WIZ.MAIN.ZA0003)this.MdiParent).GetToolBarStatus("NewFunc"));
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
