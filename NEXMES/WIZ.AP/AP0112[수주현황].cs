#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0112
//   Form Name    : 수주 현황
//   Name Space   : WIZ.AP
//   Created Date : 2019-11-11
//   Made By      : 기술연구소 최문준
//   Description  : 수주 현황 정보를 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace WIZ.AP
{
    public partial class AP0112 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();

        string sColorType = "";

        #endregion

        #region < CONSTRUCTOR >
        public AP0112()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0112_Load(object sender, EventArgs e)
        {
            GridInitialize();
        }

        protected override void SetSubData()
        {
            // 데이터를 통한 추가 처리 기능 구현
            DataRow dr = subData["METHOD_TYPE", "ROWCOLOR"];

            if (dr != null)
            {
                sColorType = CModule.ToString(dr["RELCODE1"]);
            }

            WIZ.Control.GridExtendUtil.SetUnitTrans(subData, grid2);
        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "CUSTCODE", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "CUSTNAME", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "CUSTPONO", Infragistics.Win.HAlign.Center);
                _GridUtil.SetColumnTextHAlign(grid1, "PIMSORDER", Infragistics.Win.HAlign.Center);

                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "수주순번", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTDATE", "수주일자", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", true, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 150, 0, Infragistics.Win.HAlign.Left, false, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSEFLAG", "완료여부", true, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", true, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SEQ", "수주순번", true, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "고객번호", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "고객사", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTPONO", "고객사발주번호", true, GridColDataType_emu.VarChar, 110, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PIMSORDER", "핌스견적서", true, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMEID", "프레임ID", true, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKID", "마스크ID", true, GridColDataType_emu.VarChar, 90, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMENO", "프레임수주번호", true, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SHEETNO", "시트수주번호", true, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OVERSEA", "해외배송", true, GridColDataType_emu.VarChar, 95, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTQTY", "수주수량", true, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKTYPE", "마스크재질", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKSIZE", "마스크사이즈", true, GridColDataType_emu.VarChar, 95, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKTHICK", "마스크두께", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKQTY", "마스크수량", true, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKGEN", "세대구분", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKCHECK", "원자재확인", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMETYPE", "프레임재질", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMESIZE", "프레임사이즈", true, GridColDataType_emu.VarChar, 95, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMETHICK", "프레임두께", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMEQTY", "프레임수량", true, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "OUTQTY", "출하수량", true, GridColDataType_emu.Double, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "재고", true, GridColDataType_emu.Double, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 70, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "DUEDATE", "예정일자", true, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSEDATE", "완료일자", true, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSER", "완료자", true, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                //grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Fixed = true;
                grid2.DisplayLayout.Bands[0].Columns["CUSTPONO"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["PIMSORDER"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAMEID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["OVERSEA"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKTYPE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKSIZE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKTHICK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKGEN"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKCHECK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAMETYPE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAMESIZE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAMETHICK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["FRAMEQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                //grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now;
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);
                //cbo_NEWCONTRACTDATE_H.Value = DateTime.Now.AddDays(1);

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("AP0112_FLAG");
                Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("OVERSEA");
                //Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "OVERSEA", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("MASKTYPE");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "MASKTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                
                rtnDtTemp = _Common.GET_BM0000_CODE("MASKSIZE");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "MASKSIZE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("MASKTHICK");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "MASKTHICK", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("MASKGEN");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "MASKGEN", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("MASKCHECK");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "MASKCHECK", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("FRAMETYPE");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "FRAMETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("FRAMESIZE");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "FRAMESIZE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("FRAMETHICK");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "FRAMETHICK", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                btbManager.PopUpAdd(txt_CUSTCODE_H, txt_CUSTNAME_H, "BM0030", new object[] { cbo_PLANTCODE_H, "CT", "Y" });

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "1", "Y" });

                bizGrid1Manager = new BizGridManager(grid1);
                bizGrid1Manager.PopUpAdd("CUSTCODE", "CUSTNAME", "BM0030", new string[] { "PLANTCODE", "CT", "Y" });

                bizGrid2Manager = new BizGridManager(grid2);
                bizGrid2Manager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "1", "Y" });

                bizGrid1Manager.PopUpClosed += BizGridManager_PopUpClosed;
                bizGrid2Manager.PopUpClosed += BizGridManager_PopUpClosed;

                #endregion

                dtGrid = (DataTable)grid1.DataSource;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        private void BizGridManager_PopUpClosed(Control.Grid grid, string sCode, string sName, bool bFindOK)
        {
            if (bFindOK)
            {
                
                DBHelper helper = new DBHelper(false);

                string sPlantCode = CModule.ToString(grid.ActiveRow.Cells["PLANTCODE"].Value);
                string sContractNo = CModule.ToString(grid.ActiveRow.Cells["CONTRACTNO"].Value);
                string sContractSeq = CModule.ToString(grid.ActiveRow.Cells["SEQ"].Value);

                DataSet ds = helper.FillDataSet("USP_AP0110_S4", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sCode, DbType.String, ParameterDirection.Input));

                if (ds.Tables.Count >= 1)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        grid.ActiveRow.Cells["UNITCODE"].Value = CModule.ToString(ds.Tables[0].Rows[0]["UNITCODE"]);
                        grid.ActiveRow.Cells["NOWQTY"].Value = CModule.ToString(ds.Tables[0].Rows[0]["NOWQTY"]);
                    }
                }

                if (ds.Tables.Count >= 2)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (CModule.ToString(ds.Tables[1].Rows[i]["CONTRACTNO"]) == sContractNo && CModule.ToString(ds.Tables[1].Rows[i]["CONTRACTSEQ"]) == sContractSeq)
                        {
                            grid.ActiveRow.Cells["OUTQTY"].Value = string.Format("{0:#,##0}", CModule.ToDouble(ds.Tables[1].Rows[i]["OUTQTY"]));
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["CONTRACTQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["FRAMEID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["MASKID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["OVERSEA"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["MASKTYPE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["MASKSIZE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["MASKTHICK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["MASKQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["MASKGEN"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["MASKCHECK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["FRAMETYPE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["FRAMESIZE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["FRAMETHICK"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            grid2.DisplayLayout.Bands[0].Columns["FRAMEQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;


            try
            {
                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sCloseFlag = CModule.ToString(cbo_CLOSEFLAG_H.Value);
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sitemName = txt_ITEMNAME_H.Text.Trim();

                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

                base.DoInquire();

                string sCHECKLIST = chk1.Checked ? CModule.ToString(chk1.Tag) : "";
                sCHECKLIST += "|" + (chk2.Checked ? CModule.ToString(chk2.Tag) : "");
                sCHECKLIST += "|" + (chk3.Checked ? CModule.ToString(chk3.Tag) : "");
                sCHECKLIST += "|" + (chk4.Checked ? CModule.ToString(chk4.Tag) : "");

                dtGrid = helper.FillTable("USP_AP0110_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", sitemName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input)
                       );

                if (dtGrid.Rows.Count > 0)
                {
                    grid1.DataSource = dtGrid;
                    grid1.DataBinds(dtGrid);
                }


                dtGrid = helper.FillTable("USP_AP0110_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", sitemName, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input)
                       );

                if (dtGrid.Rows.Count > 0)
                {
                    grid2.DataSource = dtGrid;
                    grid2.DataBinds(dtGrid);
                }

                SetColor(grid2);

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
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                Color coBack = Color.White;
                Color coFore = Color.Black;

                string sClose = CModule.ToString(grid.Rows[i].Cells["CLOSEFLAG"].Value);

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
                        grid2.Rows[i].CellAppearance.BackColor = coBack;
                        grid2.Rows[i].CellAppearance.ForeColor = coFore;
                    }
                    else
                    {
                        grid2.Rows[i].Cells["CLOSEFLAG"].Appearance.BackColor = coBack;
                        grid2.Rows[i].Cells["CLOSEFLAG"].Appearance.ForeColor = coFore;
                    }
                }
            }
        }

    public override void DoNew()
        {

            try
            {
                if (grid1.IsActivate)
                {
                    _GridUtil.Grid_Clear(grid1);

                    base.DoNew();

                    this.grid1.InsertRow();

                    this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid1.ActiveRow.Cells["CONTRACTDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    this.grid1.ActiveRow.Cells["CONTRACTNO"].Activation = Activation.Disabled;

                    if (!chk5.Checked)
                    {
                        this.grid1.ActiveRow.Cells["CONTRACTNO"].Value = "[ NEW CONTRACT ]";
                        grid1.UpdateData();

                        _GridUtil.Grid_Clear(grid2);
                    }
                    else
                    {
                        this.grid1.ActiveRow.Cells["CONTRACTNO"].Value = "[ TEST CONTRACT ]";
                        grid1.UpdateData();

                        _GridUtil.Grid_Clear(grid2);
                    }

                }
                else if (grid2.IsActivate)
                {
                   
                    _GridUtil.Grid_Clear(grid2);

                    base.DoNew();

                    this.grid2.InsertRow();

                    this.grid2.ActiveRow.Cells["CONTRACTNO"].Value = CModule.ToString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                    this.grid2.ActiveRow.Cells["DUEDATE"].Value = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                    this.grid2.ActiveRow.Cells["CLOSEFLAG"].Value = "D";
                    this.grid2.ActiveRow.Cells["OVERSEA"].Value = "N";
                    this.grid2.ActiveRow.Cells["CONTRACTQTY"].Value = 1;
                    this.grid2.ActiveRow.Cells["MASKQTY"].Value = 1;
                    this.grid2.ActiveRow.Cells["FRAMEQTY"].Value = 1;
                    this.grid2.ActiveRow.Cells["MASKTYPE"].Value = "INVAR";
                    this.grid2.ActiveRow.Cells["FRAMETYPE"].Value = "INVAR";
                    this.grid2.ActiveRow.Cells["PLANTCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    this.grid2.ActiveRow.Cells["CUSTCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
                    this.grid2.ActiveRow.Cells["CUSTNAME"].Value = CModule.ToString(grid1.ActiveRow.Cells["CUSTNAME"].Value);

                    this.grid2.ActiveRow.Cells["CUSTPONO"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["PIMSORDER"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["CLOSEFLAG"].Activation = Activation.Disabled;
                    this.grid2.ActiveRow.Cells["FRAMEID"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASKID"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["OVERSEA"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASKTYPE"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASKSIZE"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASKTHICK"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASKQTY"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASKGEN"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["MASKCHECK"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["FRAMETYPE"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["FRAMESIZE"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["FRAMETHICK"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["FRAMEQTY"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["CONTRACTQTY"].Activation = Activation.AllowEdit;
                    this.grid2.ActiveRow.Cells["UNITCODE"].Activation = Activation.Disabled;
                    this.grid2.ActiveRow.Cells["NOWQTY"].Activation = Activation.Disabled;
                    this.grid2.ActiveRow.Cells["OUTQTY"].Activation = Activation.Disabled;

                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid2.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid1.chkChange();
            DataTable dtChange2 = grid2.chkChange();

            if (dtChange2 == null && dtChange == null)
            {
                return;
            }

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            string sPlantCode = "";
            string sContractNO = string.Empty;
            string sItemCode = string.Empty;
            string sContractDate = string.Empty;
            string sDueDate = string.Empty;
            string sCustCode = string.Empty;
            string sCustPono = string.Empty;
            string sPimsOrder = string.Empty;
            string sCloseDate = string.Empty;
            string sCloseFlag = string.Empty;
            string sCloser = string.Empty;
            string sRemark = string.Empty;
            string sFrameID = string.Empty;
            //string sSheetID = string.Empty;
            string sMaskID = string.Empty;
            string sOverSea = string.Empty;
            string sMaskType = string.Empty;
            string sMaskSize = string.Empty;
            string sMaskThick = string.Empty;
            string sMaskGen = string.Empty;
            string sMaskCheck = string.Empty;
            string sFrameType = string.Empty;
            string sFrameSize = string.Empty;
            string sFrameThick = string.Empty;


            string sSeq = "";
            string sUser = LoginInfo.UserID;

            double dContractQty;
            double dMaskQty;
            double dFrameQty;

            string sRT_ContractNo = "";

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                // grid2 - 수주 상세
                if (dtChange2 != null)
                {
                    foreach (DataRow drChange in dtChange2.Rows)
                    {
                        switch (drChange.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- 삭제 ---
                                drChange.RejectChanges();

                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);
                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                                helper.ExecuteNoneQuery("USP_AP0110_D1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SEQ", CModule.ToString(drChange["SEQ"]), DbType.String, ParameterDirection.Input));
                                #endregion
                                break;
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                #region --- 추가 ---
                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;
                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);
                                sContractDate = CModule.ToString(string.Format("{0:yyyy-MM-dd}", grid1.ActiveRow.Cells["CONTRACTDATE"].Value));
                                
                                sCustPono = CModule.ToString(drChange["CUSTPONO"]);
                                sPimsOrder = CModule.ToString(drChange["PIMSORDER"]);
                                sRemark = CModule.ToString(grid1.ActiveRow.Cells["REMARK"].Value);
                                sFrameID = CModule.ToString(drChange["FRAMEID"]);
                                //sSheetID = CModule.ToString(drChange["SHEETID"]);
                                sMaskID = CModule.ToString(drChange["MASKID"]);
                                sOverSea = CModule.ToString(drChange["OVERSEA"]);
                                sMaskType = CModule.ToString(drChange["MASKTYPE"]);
                                sMaskSize = CModule.ToString(drChange["MASKSIZE"]);
                                sMaskThick = CModule.ToString(drChange["MASKTHICK"]);
                                sMaskGen = CModule.ToString(drChange["MASKGEN"]);
                                sMaskCheck = CModule.ToString(drChange["MASKCHECK"]);
                                sFrameType = CModule.ToString(drChange["FRAMETYPE"]);
                                sFrameSize = CModule.ToString(drChange["FRAMESIZE"]);
                                sFrameThick = CModule.ToString(drChange["FRAMETHICK"]);

                                sCustCode = CModule.ToString(drChange["CUSTCODE"]);
                                sItemCode = CModule.ToString(drChange["ITEMCODE"]);
                                dContractQty = DBHelper.nvlDouble(drChange["CONTRACTQTY"]);
                                dMaskQty = DBHelper.nvlDouble(drChange["MASKQTY"]);
                                dFrameQty = DBHelper.nvlDouble(drChange["FRAMEQTY"]);
                                sDueDate = string.Format("{0:yyyy-MM-dd}", drChange["DUEDATE"]);
                                sCloseFlag = CModule.ToString(drChange["CLOSEFLAG"]);
                                sSeq = CModule.ToString(drChange["SEQ"]);

                                helper.ExecuteNoneQuery("USP_AP0110_I1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_SEQ", sSeq, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CUSTPONO", sCustPono, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PIMSORDER", sPimsOrder, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_OVERSEA", sOverSea, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MASKTYPE", sMaskType, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MASKSIZE", sMaskSize, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MASKTHICK", sMaskThick, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AF_MASKQTY", dMaskQty, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MASKGEN", sMaskGen, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MASKCHECK", sMaskCheck, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_FRAMETYPE", sFrameType, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_FRAMESIZE", sFrameSize, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_FRAMETHICK", sFrameThick, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AF_FRAMEQTY", dFrameQty, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_FRAMEID", sFrameID, DbType.String, ParameterDirection.Input)
                                //, helper.CreateParameter("AS_SHEETID", sSheetID, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MASKID", sMaskID, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                if (helper.RSMSG.StartsWith("CONNO"))
                                {
                                    sRT_ContractNo = helper.RSMSG.Split('|')[1];
                                }

                                #endregion
                                break;
                        }
                    }
                }

                // 수주 메인
                if (dtChange != null)
                {
                    foreach (DataRow drChange in dtChange.Rows)
                    {

                        switch (drChange.RowState)
                        {
                            case DataRowState.Deleted:
                                #region --- 삭제 ---
                                drChange.RejectChanges();

                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);

                                helper.ExecuteNoneQuery("USP_AP0110_D1", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SEQ", sContractNO, DbType.String, ParameterDirection.Input));
                                #endregion
                                break;
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                #region --- 추가 ---

                                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);
                                sContractDate = CModule.ToString(string.Format("{0:yyyy-MM-dd}", grid1.ActiveRow.Cells["CONTRACTDATE"].Value));
                                sCustCode = CModule.ToString(drChange["CUSTCODE"]);
                                sRemark = CModule.ToString(drChange["REMARK"]);

                                sItemCode = "";
                                dContractQty = 0;
                                sDueDate = "";
                                sCloseFlag = "";
                                sSeq = CModule.ToString(grid1.ActiveRow.Cells["SEQ"].Value);

                                helper.ExecuteNoneQuery("USP_AP0110_U2", CommandType.StoredProcedure
                              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_SEQ", sSeq, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "E")
                                {
                                    throw new Exception(helper.RSMSG);
                                }

                                if (helper.RSMSG.StartsWith("CONNO"))
                                {
                                    sRT_ContractNo = helper.RSMSG.Split('|')[1];
                                }

                                #endregion
                                break;
                        }
                    }
                }

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


        #region < METHOD AREA >

        #endregion
        private void btn_COPY_ITEM_Click(object sender, EventArgs e)
        {
            DBHelper helper;

            try
            {
                helper = new DBHelper("", true);

                string sItemCode = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                //string sContractDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWCONTRACTDATE_H.Value);
                double dContractQty = Convert.ToDouble(grid1.ActiveRow.Cells["CONTRACTQTY"].Value);

                try
                {
                    helper.ExecuteNoneQuery("USP_AP0110_C2", CommandType.StoredProcedure
                  , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                  //, helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                  , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                  , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (grid1.ActiveCell == null)
            {
                this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            try
            {
                _GridUtil.Grid_Clear(grid2);

                DBHelper helper;
                helper = new DBHelper(false);

                string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sCONTRACTNO = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);

                string sCHECKLIST = chk1.Checked ? CModule.ToString(chk1.Tag) : "";
                sCHECKLIST += "|" + (chk2.Checked ? CModule.ToString(chk2.Tag) : "");
                sCHECKLIST += "|" + (chk3.Checked ? CModule.ToString(chk3.Tag) : "");
                sCHECKLIST += "|" + (chk4.Checked ? CModule.ToString(chk4.Tag) : "");


                dtGrid = helper.FillTable("USP_AP0110_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CONTRACTNO", sCONTRACTNO, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CLOSEFLAG", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input));

                grid2.DataSource = dtGrid;
                grid2.DataBinds(dtGrid);

                SetColor(grid2);

                UltraGridUtil.ActivationAllowEdit(grid2, "CUSTPONO");
                UltraGridUtil.ActivationAllowEdit(grid2, "PIMSORDER");
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }

        }
    }
}
