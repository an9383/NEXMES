#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0014
//   Form Name    : 수주 현황
//   Name Space   : WIZ.AP
//   Created Date : 2019-11-11
//   Made By      : 기술연구소 최문준
//   Description  : 수주 현황 정보를 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0014 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        //BizGridManager bizGrid1Manager;
        BizGridManager bizGrid2Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        DataTable dtGrid2 = new DataTable();

        string sColorType = "";

        #endregion

        #region < CONSTRUCTOR >
        public BM0014()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0014_Load(object sender, EventArgs e)
        {
            GridInitialize();
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-31);
            cbo_ENDDATE_H.Value = DateTime.Now.AddDays(-1);
            DateTime date1 = DateTime.Parse(cbo_STARTDATE_H.Value.ToString());
            DateTime date2 = DateTime.Parse(cbo_ENDDATE_H.Value.ToString());
            //string sSdate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
            //string sEdate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

            //ExchangeQuery(date1,date2);
            //string sEdate = string.Format("{0:yyyyMMdd}", cbo_ENDDATE_H.Value);
            ExchangeQuery(date1, date2);
        }

        private void ExchangeQuery(DateTime date1, DateTime date2)
        {
            TimeSpan timeSpan = date1 - date2;

            for (int i = 0; i > -1; i--) //for (int i = 0; i >= timeSpan.Days; i--)
            {
                DateTime date3 = date2.AddDays(i);
                string sDate = string.Format("{0:yyyyMMdd}", date3);
                string sDate2 = string.Format("{0:yyyyMMdd}", date2);
                string yourkey = "kXhRLwed59ex0EC6scLiQfCgd1SDczuj";
                //string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&searchdate=20220623&data=AP01";
                string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&searchdate=" + sDate2 + "&data=AP01";

                //request를 openapi 서버로 전송해보자!
                WebRequest wr = WebRequest.Create(query);
                wr.Method = "GET";

                WebResponse wrs = wr.GetResponse();
                Stream s = wrs.GetResponseStream();
                StreamReader sr = new StreamReader(s);

                string response = sr.ReadToEnd();

                List<exchange> exchange_data = JsonConvert.DeserializeObject<List<exchange>>(response);

                for (int j = 0; j < exchange_data.Count; j++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = exchange_data[j].cur_nm;
                    if (lvi.Text == "미국 달러")
                    {
                        lvi.Text = exchange_data[j].cur_nm + " [" + sDate2 + "]";
                        lvi.SubItems.Add(exchange_data[j].cur_unit);
                        lvi.SubItems.Add(exchange_data[j].tts);
                        lvi.SubItems.Add(exchange_data[j].ttb);
                        Save(date2.ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        //Save(date1.AddDays(i).ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        grid1.Items.Add(lvi);
                    }
                    else if (lvi.Text == "유로")
                    {
                        lvi.Text = exchange_data[j].cur_nm + " [" + sDate2 + "]";
                        lvi.SubItems.Add(exchange_data[j].cur_unit);
                        lvi.SubItems.Add(exchange_data[j].tts);
                        lvi.SubItems.Add(exchange_data[j].ttb);
                        Save(date2.ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        //Save(date1.AddDays(i).ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        grid1.Items.Add(lvi);
                    }
                    else if (lvi.Text == "일본 옌")
                    {
                        lvi.Text = exchange_data[j].cur_nm + " [" + sDate2 + "]";
                        lvi.SubItems.Add(exchange_data[j].cur_unit);
                        lvi.SubItems.Add(exchange_data[j].tts);
                        lvi.SubItems.Add(exchange_data[j].ttb);
                        Save(date2.ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        //Save(date1.AddDays(i).ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        grid1.Items.Add(lvi);
                    }
                    else if (lvi.Text == "위안화")
                    {
                        lvi.Text = exchange_data[j].cur_nm + " [" + sDate2 + "]";
                        lvi.SubItems.Add(exchange_data[j].cur_unit);
                        lvi.SubItems.Add(exchange_data[j].tts);
                        lvi.SubItems.Add(exchange_data[j].ttb);
                        Save(date2.ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        //Save(date1.AddDays(i).ToString("yyyyMMdd"), exchange_data[j].cur_unit.ToString(), exchange_data[j].tts.ToString(), exchange_data[j].ttb.ToString());
                        grid1.Items.Add(lvi);
                    }
                }
            }
        }

        private void Save(string date, string cur_unit, string tts, string ttb)
        {
            DBHelper helper = new DBHelper(false);

            StringBuilder sSQL = new StringBuilder();
            string plantcode = "10";
            sSQL.Append("exec USP_BM0014_I1 ");
            sSQL.Append(" @AS_PLANTCODE = '" + plantcode + "' ");
            sSQL.Append(", @AS_ITEMCD = '" + date + "' ");
            sSQL.Append(", @AS_ITEMCODE = '" + cur_unit + "' ");
            sSQL.Append(", @AS_RELCODE1 = '" + tts + "' ");
            sSQL.Append(", @AS_RELCODE2 = '" + ttb + "' ");

            helper.ExecuteNoneQuery(sSQL.ToString());
            helper.Close();

        }

        //private void ExchangeQuery(DateTime date1, DateTime date2)
        //{
        //    TimeSpan timeSpan = date2 - date1;

        //    for (int i = 0; i <= timeSpan.Days; i++)
        //    {
        //        DateTime date3 = date1.AddDays(i);
        //        string sDate = string.Format("{0:yyyyMMdd}", date3);
        //        string yourkey = "kXhRLwed59ex0EC6scLiQfCgd1SDczuj";
        //        //string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&searchdate=20220623&data=AP01";
        //        string query = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" + yourkey + "&searchdate=" + sDate + "&data=AP01";

        //        //request를 openapi 서버로 전송해보자!
        //        WebRequest wr = WebRequest.Create(query);
        //        wr.Method = "GET";

        //        WebResponse wrs = wr.GetResponse();
        //        Stream s = wrs.GetResponseStream();
        //        StreamReader sr = new StreamReader(s);

        //        string response = sr.ReadToEnd();

        //        List<exchange> exchange_data = JsonConvert.DeserializeObject<List<exchange>>(response);

        //        for (int j = 0; j < exchange_data.Count; j++)
        //        {
        //            ListViewItem lvi = new ListViewItem();
        //            lvi.SubItems.Clear();
        //            lvi.Text = exchange_data[j].cur_nm;
        //            if (lvi.Text == "미국 달러")
        //            {
        //                lvi.SubItems.Clear();
        //                lvi.Text = exchange_data[j].cur_nm + " [" + sDate + "]";
        //                lvi.SubItems.Add(exchange_data[j].cur_unit);
        //                lvi.SubItems.Add(exchange_data[j].tts);
        //                lvi.SubItems.Add(exchange_data[j].ttb);
        //                grid1.Items.Add(lvi);
        //            }
        //            else if (lvi.Text == "유로")
        //            {
        //                lvi.SubItems.Clear();
        //                lvi.Text = exchange_data[j].cur_nm + " [" + sDate + "]";
        //                lvi.SubItems.Add(exchange_data[j].cur_unit);
        //                lvi.SubItems.Add(exchange_data[j].tts);
        //                lvi.SubItems.Add(exchange_data[j].ttb);
        //                grid1.Items.Add(lvi);
        //            }
        //            else if (lvi.Text == "일본 옌")
        //            {
        //                lvi.SubItems.Clear();
        //                //lvi.Text = sEdate;
        //                lvi.Text = exchange_data[j].cur_nm + " [" + sDate + "]";
        //                lvi.SubItems.Add(exchange_data[j].cur_unit);
        //                lvi.SubItems.Add(exchange_data[j].tts);
        //                lvi.SubItems.Add(exchange_data[j].ttb);
        //                grid1.Items.Add(lvi);
        //            }
        //            else if (lvi.Text == "위안화")
        //            {
        //                lvi.SubItems.Clear();
        //                //lvi.Text = sEdate;
        //                lvi.Text = exchange_data[j].cur_nm + " [" + sDate + "]";
        //                lvi.SubItems.Add(exchange_data[j].cur_unit);
        //                lvi.SubItems.Add(exchange_data[j].tts);
        //                lvi.SubItems.Add(exchange_data[j].ttb);
        //                grid1.Items.Add(lvi);
        //            }
        //            j++;
        //        }
        //        i++;
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //string sEdate = string.Format("{0:yyyyMMdd}", this.cbo_EXCHANGEDATE.Value);
            //ExchangeQuery(sEdate);

            //for (int i = 0; i < exchange_data.Count; i++)
            //{
            //    ListViewItem lvi = new ListViewItem();

            //    lvi.Text = exchange_data[i].cur_nm;
            //    lvi.SubItems.Add(exchange_data[i].cur_unit);
            //    lvi.SubItems.Add(exchange_data[i].tts);
            //    lvi.SubItems.Add(exchange_data[i].ttb);
            //    //richTextBox1.Text += exchange_data[i].cur_nm + "\n";
            //    grid1.Items.Add(lvi);
            //}
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
                //_GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "SEQ", "수주번호", false, GridColDataType_emu.VarChar, 130, false, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CONTRACTDATE", "수주일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 120, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 200, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 200, true, false);
                ////_GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, true, true);
                //_GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 200, true, false);
                ////_GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, true, true);

                //_GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Center);
                //_GridUtil.SetColumnTextHAlign(grid1, "CUSTCODE", Infragistics.Win.HAlign.Center);
                //_GridUtil.SetColumnTextHAlign(grid1, "CUSTNAME", Infragistics.Win.HAlign.Center);

                //_GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSEFLAG", "완료여부", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SEQ", "수주순번", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "고객번호", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "고객사", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "FRAMEID", "프레임ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "MASKID", "마스크ID", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTQTY", "수주수량", false, GridColDataType_emu.Double, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "OUTQTY", "출하수량", false, GridColDataType_emu.Double, 150, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "재고", false, GridColDataType_emu.Double, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "DUEDATE", "예정일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSEDATE", "완료일자", false, GridColDataType_emu.YearMonthDay, 100, 0, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSER", "완료자", false, GridColDataType_emu.VarChar, 80, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", false, GridColDataType_emu.VarChar, 140, 0, Infragistics.Win.HAlign.Center, true, false);
                grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Fixed = true;
                grid2.DisplayLayout.Bands[0].Columns["FRAMEID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["MASKID"].Header.Appearance.ForeColor = Color.LightSkyBlue; _GridUtil.SetInitUltraGridBind(grid2);


                //grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

                #region --- Combobox & Popup Setting ---
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-31);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(-1);
                //cbo_EXCHANGEDATE.Value = DateTime.Now;
                cbo_NEWCONTRACTDATE_H.Value = DateTime.Now.AddDays(1);

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("BM0014_FLAG");
                Common.FillComboboxMaster(this.cbo_CLOSEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "CLOSEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0130_CODE("Y");
                UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

                //bizGrid1Manager = new BizGridManager(grid1);
                //bizGrid1Manager.PopUpAdd("CustCode", "CustName", "BM0030", new string[] { "PlantCode", "ALL", "Y" });

                bizGrid2Manager = new BizGridManager(grid2);
                bizGrid2Manager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "1", "Y" });

                bizGrid2Manager.PopUpClosed += BizGridManager_PopUpClosed;

                #endregion

                //dtGrid = (DataTable)grid1.DataSource;
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

                DataSet ds = helper.FillDataSet("USP_BM0014_S4", CommandType.StoredProcedure
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
            DateTime date1 = DateTime.Parse(cbo_STARTDATE_H.Value.ToString());
            DateTime date2 = DateTime.Parse(cbo_ENDDATE_H.Value.ToString());

            ExchangeQuery(date1, date2);

            //bNew = false;

            //DBHelper helper = new DBHelper(false);

            ////grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            ////grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            ////grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            //grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid2.DisplayLayout.Bands[0].Columns["CONTRACTQTY"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid2.DisplayLayout.Bands[0].Columns["FRAMEID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid2.DisplayLayout.Bands[0].Columns["MASKID"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            ////grid2.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            ////grid2.DisplayLayout.Bands[0].Columns["CLOSEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            //try
            //{
            //    string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
            //    string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
            //    string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
            //    string sCloseFlag = CModule.ToString(cbo_CLOSEFLAG_H.Value);
            //    string sItemCode = txt_ITEMCODE_H.Text.Trim();
            //    string sitemName = txt_ITEMNAME_H.Text.Trim();

            //    //_GridUtil.Grid_Clear(grid1);
            //    _GridUtil.Grid_Clear(grid2);

            //    base.DoInquire();

            //    string sCHECKLIST = chk1.Checked ? CModule.ToString(chk1.Tag) : "";
            //    sCHECKLIST += "|" + (chk2.Checked ? CModule.ToString(chk2.Tag) : "");
            //    sCHECKLIST += "|" + (chk3.Checked ? CModule.ToString(chk3.Tag) : "");
            //    sCHECKLIST += "|" + (chk4.Checked ? CModule.ToString(chk4.Tag) : "");

            //    dtGrid = helper.FillTable("USP_BM0014_S1", CommandType.StoredProcedure
            //           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_ITEMNAME", sitemName, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input)
            //           );

            //    if (dtGrid.Rows.Count > 0)
            //    {
            //        //grid1.DataSource = dtGrid;
            //        //grid1.DataBinds(dtGrid);
            //    }


            //    dtGrid = helper.FillTable("USP_BM0014_S2", CommandType.StoredProcedure
            //           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CONTRACTNO", "", DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_ITEMNAME", sitemName, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CUSTCODE", txt_CUSTCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CUSTNAME", txt_CUSTNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input)
            //           );

            //    if (dtGrid.Rows.Count > 0)
            //    {
            //        grid2.DataSource = dtGrid;
            //        grid2.DataBinds(dtGrid);
            //    }

            //    SetColor(grid2);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    ClosePrgFormNew();

            //    helper.Close();
            //}
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
            base.DoNew();

            try
            {
                //if (grid1.IsActivate)
                //{
                //    if (bNew)
                //    {
                //        this.ShowDialog(Common.getLangText("입력 중인 수주가 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                //        return;
                //    }

                //    AddGrid1Row();
                //}
                //else if (grid2.IsActivate)
                //{
                //    //grid2.DisplayLayout.Bands[0].Columns["DUEDATE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                //    //grid2.DisplayLayout.Bands[0].Columns["CLOSEFLAG"].Header.Appearance.ForeColor = Color.White;
                //    //grid2.DisplayLayout.Bands[0].Columns["CLOSEDATE"].Header.Appearance.ForeColor = Color.White;

                //    if (grid1.ActiveRow == null)
                //    {
                //        this.ShowDialog(Common.getLangText("수주번호를 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                //        return;
                //    }

                //    int iRow = grid2.InsertRow();
                //    grid2.Rows[iRow].Cells["CONTRACTNO"].Value = CModule.ToString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);
                //    grid2.Rows[iRow].Cells["DUEDATE"].Value = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                //    grid2.Rows[iRow].Cells["CLOSEFLAG"].Value = "D";
                //    grid2.Rows[iRow].Cells["PLANTCODE"].Value = CModule.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                //    grid2.Rows[iRow].Cells["CLOSEFLAG"].Activation = Activation.Disabled;
                //    grid2.Rows[iRow].Cells["FRAMEID"].Activation = Activation.AllowEdit;
                //    grid2.Rows[iRow].Cells["MASKID"].Activation = Activation.AllowEdit;
                //    grid2.Rows[iRow].Cells["UNITCODE"].Activation = Activation.Disabled;
                //    grid2.Rows[iRow].Cells["NOWQTY"].Activation = Activation.Disabled;
                //    grid2.Rows[iRow].Cells["OUTQTY"].Activation = Activation.Disabled;
                //}
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
            }
        }

        private void AddGrid1Row()
        {
            //_GridUtil.Grid_Clear(grid1);
            //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            //bNew = true;

            //string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);

            //int iRow = grid1.InsertRow();

            //grid1.Rows[iRow].Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            ////grid1.Rows[iRow].Cells["CONTRACTNO"].Value = "[ NEW CONTRACT ]";
            //grid1.Rows[iRow].Cells["CONTRACTDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            //grid1.Rows[iRow].Cells["CONTRACTNO"].Activation = Activation.Disabled;
            //if(!chk5.Checked)
            //{
            //    grid1.Rows[iRow].Cells["CONTRACTNO"].Value = "[ NEW CONTRACT ]";
            //    grid1.UpdateData();
            //    _GridUtil.Grid_Clear(grid2);
            //}
            //else
            //{
            //    grid1.Rows[iRow].Cells["CONTRACTNO"].Value = "[ TEST CONTRACT ]";
            //    grid1.UpdateData();
            //    _GridUtil.Grid_Clear(grid2);
            //}

        }

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid2.DeleteRow();
        }

        public override void DoSave()
        {
            //DataTable dtChange = grid1.chkChange();
            DataTable dtChange2 = grid2.chkChange();

            //if (dtChange2 == null && dtChange == null)
            //{
            //    return;
            //}

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
            string sFrameID = string.Empty;
            string sMASKID = string.Empty;
            string sCloseDate = string.Empty;
            string sCloseFlag = string.Empty;
            string sCloser = string.Empty;
            string sRemark = string.Empty;
            string sSeq = "";
            string sUser = LoginInfo.UserID;

            double dContractQty;

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

                                helper.ExecuteNoneQuery("USP_BM0014_D1", CommandType.StoredProcedure
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
                                //sContractDate = CModule.ToString(string.Format("{0:yyyy-MM-dd}", grid1.ActiveRow.Cells["CONTRACTDATE"].Value));
                                //sCustCode = CModule.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
                                //sRemark = CModule.ToString(grid1.ActiveRow.Cells["REMARK"].Value);
                                sFrameID = CModule.ToString(grid2.ActiveRow.Cells["FRAMEID"].Value);
                                sMASKID = CModule.ToString(grid2.ActiveRow.Cells["MASKID"].Value);

                                sItemCode = CModule.ToString(drChange["ITEMCODE"]);
                                dContractQty = DBHelper.nvlDouble(drChange["CONTRACTQTY"]);

                                sDueDate = string.Format("{0:yyyy-MM-dd}", drChange["DUEDATE"]);
                                sCloseFlag = CModule.ToString(drChange["CLOSEFLAG"]);
                                sSeq = CModule.ToString(drChange["SEQ"]);

                                helper.ExecuteNoneQuery("USP_BM0014_I1", CommandType.StoredProcedure
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
                              , helper.CreateParameter("AS_FRAMEID", sFrameID, DbType.String, ParameterDirection.Input)
                              , helper.CreateParameter("AS_MASKID", sMASKID, DbType.String, ParameterDirection.Input)
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
                //if (dtChange != null)
                //{
                //    foreach (DataRow drChange in dtChange.Rows)
                //    {

                //        switch (drChange.RowState)
                //        {
                //            case DataRowState.Deleted:
                //                #region --- 삭제 ---
                //                drChange.RejectChanges();

                //                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                //                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);

                //                helper.ExecuteNoneQuery("USP_BM0014_D1", CommandType.StoredProcedure
                //              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_SEQ", sContractNO, DbType.String, ParameterDirection.Input));
                //                #endregion
                //                break;
                //            case DataRowState.Added:
                //            case DataRowState.Modified:
                //                #region --- 추가 ---

                //                sContractNO = sRT_ContractNo == "" ? CModule.ToString(drChange["CONTRACTNO"]) : sRT_ContractNo;

                //                sPlantCode = CModule.ToString(drChange["PLANTCODE"]);
                //                sContractDate = CModule.ToString(string.Format("{0:yyyy-MM-dd}", grid1.ActiveRow.Cells["CONTRACTDATE"].Value));
                //                sCustCode = CModule.ToString(drChange["CUSTCODE"]);
                //                sRemark = CModule.ToString(drChange["REMARK"]);

                //                sItemCode = "";
                //                dContractQty = 0;
                //                sDueDate = "";
                //                sCloseFlag = "";
                //                sSeq = CModule.ToString(grid1.ActiveRow.Cells["SEQ"].Value);

                //                helper.ExecuteNoneQuery("USP_BM0014_U2", CommandType.StoredProcedure
                //              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_SEQ", sSeq, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                //              , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));

                //                if (helper.RSCODE == "E")
                //                {
                //                    throw new Exception(helper.RSMSG);
                //                }

                //                if (helper.RSMSG.StartsWith("CONNO"))
                //                {
                //                    sRT_ContractNo = helper.RSMSG.Split('|')[1];
                //                }
                //                #endregion
                //                break;
                //        }
                //    }
                //}

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
        //private void btn_COPY_H_Click(object sender, EventArgs e)
        //{
        //    DBHelper helper;

        //    try
        //    {
        //        helper = new DBHelper("", true);

        //        string sMakeDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWCONTRACTDATE_H.Value);

        //        try
        //        {
        //            helper.ExecuteNoneQuery("USP_BM0014_C1", CommandType.StoredProcedure
        //          , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_STANDDATE", "", DbType.String, ParameterDirection.Input)
        //          , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

        //            if (helper.RSCODE == "S")
        //            {
        //                helper.Commit();

        //                DoInquire();
        //            }
        //            else if (helper.RSCODE == "C")
        //            {
        //                string sStandDate = helper.RSMSG;

        //                helper = new DBHelper("", true);

        //                try
        //                {
        //                    DialogResult result = MessageBox.Show("금일 생성 된 수주정보가 없습니다." + Environment.NewLine + sStandDate + " 일 수주정보가 존재 합니다. 복사 하시겠습니까?", "수주정보 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

        //                    if (result.ToString().ToUpper() == "YES")
        //                    {
        //                        helper.ExecuteNoneQuery("USP_BM0014_C1", CommandType.StoredProcedure
        //                      , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_MAKEDATE", sMakeDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_STANDDATE", sStandDate, DbType.String, ParameterDirection.Input)
        //                      , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

        //                        if (helper.RSCODE == "S")
        //                        {
        //                            helper.Commit();

        //                            DoInquire();
        //                        }
        //                        else
        //                        {
        //                            helper.Rollback();

        //                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

        //                            return;
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    helper.Rollback();

        //                    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //                }
        //                finally
        //                {
        //                    helper.Close();
        //                }
        //            }
        //            else if (helper.RSCODE == "E")
        //            {
        //                helper.Rollback();

        //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            helper.Rollback();

        //            this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //        }
        //        finally
        //        {
        //            helper.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        ClosePrgFormNew();
        //    }
        //}
        #endregion

        #region < METHOD AREA >

        #endregion
        private void btn_COPY_ITEM_Click(object sender, EventArgs e)
        {
            DBHelper helper;

            try
            {
                helper = new DBHelper("", true);

                //string sItemCode = CModule.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sContractDate = string.Format("{0:yyyy-MM-dd}", cbo_NEWCONTRACTDATE_H.Value);
                //double dContractQty = Convert.ToDouble(grid1.ActiveRow.Cells["CONTRACTQTY"].Value);

                //try
                //{
                //    helper.ExecuteNoneQuery("USP_BM0014_C2", CommandType.StoredProcedure
                //  , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                //  , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                //  , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                //  , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                //  , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                //    grid1.SetAcceptChanges();

                //    helper.Commit();

                //    DoInquire();
                //}
                //catch (Exception ex)
                //{
                //    helper.Rollback();

                //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                //}
                //finally
                //{
                //    helper.Close();
                //}

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            //if (grid1.ActiveCell == null)
            //{
            //    this.ShowDialog("셀 선택을 정확하게 하세요.", WIZ.Forms.DialogForm.DialogType.OK);
            //    return;
            //}
            //try
            //{
            //    _GridUtil.Grid_Clear(grid2);

            //    DBHelper helper;
            //    helper = new DBHelper(false);

            //    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            //    string sCONTRACTNO = DBHelper.nvlString(grid1.ActiveRow.Cells["CONTRACTNO"].Value);

            //    string sCHECKLIST = chk1.Checked ? CModule.ToString(chk1.Tag) : "";
            //    sCHECKLIST += "|" + (chk2.Checked ? CModule.ToString(chk2.Tag) : "");
            //    sCHECKLIST += "|" + (chk3.Checked ? CModule.ToString(chk3.Tag) : "");
            //    sCHECKLIST += "|" + (chk4.Checked ? CModule.ToString(chk4.Tag) : "");

            //    dtGrid = helper.FillTable("USP_BM0014_S2", CommandType.StoredProcedure
            //           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CONTRACTNO", sCONTRACTNO, DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_SDATE", "", DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_EDATE", "", DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CLOSEFLAG", "", DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
            //           , helper.CreateParameter("AS_CHECKLIST", sCHECKLIST, DbType.String, ParameterDirection.Input));

            //    grid2.DataSource = dtGrid;
            //    grid2.DataBinds(dtGrid);

            //    SetColor(grid2);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            //}
        }
        public class exchange
        {
            public string cur_unit { get; set; }
            public string ttb { get; set; }
            public string tts { get; set; }
            public string cur_nm { get; set; }

        }
    }
}
