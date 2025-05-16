#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT012
//   Form Name    : 생산계획 현황판 (대선주조)
//   Name Space   : WIZ.MT
//   Created Date : 2020-07-13
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using WIZ.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0040 : BaseMDIChildForm
    {
        #region < MEMEBER AREA >
        Timer _tabTimer; // 페이징 타이머
        Timer _timer; //  타이머

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();         //COMMON 객체 생성

        DataSet dsData = new DataSet();
        DataTable rtnDtTemp = new DataTable();

        #region 페이지 처리 관련
        private int iTotalRow;
        private int iTotalPage;
        private int iSubTotalPage;

        private List<ClassPage> listPage;

        public class ClassPage
        {
            public string SubCode;
            public string SubName;



            public int iSubPage;
            public int iSubTotalPage;
            public int iSubTotalRow;

            public List<string> listRow;

            public int iTotalPage;



            public ClassPage(string subCode)
            {
                listRow = new List<string>();
                this.SubCode = subCode;
            }
        }

        /// <summary>
        /// 등록한 Page 인지 확인하고, 등록하지 않았으면, 하나를 추가 시킴
        /// 정식으로 해당 기능을 쓰기 전 iTotalPage 를 초기화 해야함
        /// iTotalRow 역시 처리하므로 초기화 필요함
        /// </summary>
        /// <param name="subCode"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public ClassPage PageContain(string subCode, string sItemCode)
        {
            foreach (ClassPage c in listPage)
            {
                if (c.SubCode == subCode)
                {
                    foreach (string s in c.listRow)
                    {
                        if (sItemCode == s)
                        {
                            return c;
                        }
                    }

                    if (c.listRow.Count < m_iPageMove)
                    {
                        c.listRow.Add(sItemCode);
                        iTotalRow++;
                        return c;
                    }
                }
            }

            ClassPage cp = new ClassPage(subCode);
            cp.listRow.Add(sItemCode);
            cp.iTotalPage = ++iTotalPage;
            cp.iSubTotalPage = ++iSubTotalPage;
            listPage.Add(cp);

            iTotalRow++;

            return cp;
        }

        int m_iRowIdx = 0;
        int m_iRowH = 110;
        int m_iPageMove = 6;
        #endregion

        private class ClassSum
        {
            public double Qty1;
            public double Qty2;

            public ClassSum(double qty1, double qty2)
            {
                Qty1 = qty1;
                Qty2 = qty2;
            }
        }

        Dictionary<string, ClassSum> listSum = null;
        #endregion

        public MT0040()
        {
            bPopUp = true;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        /// <summary>
        /// 폼 로드 시  컨트롤 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MT0040_Load(object sender, EventArgs e)
        {
            #region < 초기화 >

            // 회사메인로고
            string fileName = "COMPANYLOGO.PNG";

            if (File.Exists(Application.StartupPath + "\\Resources\\" + fileName) == true)
            {
                Bitmap image = new Bitmap(Application.StartupPath + "\\Resources\\" + fileName);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            int iTabTime = CModule.ToInt32(CModule.GetAppSetting("MT0040|NTERVAL", "10"));
            txtInterval.Text = CModule.ToString(iTabTime);

            #endregion

            #region <그리드>

            grid1.Font = new Font("맑은 고딕", 20, FontStyle.Bold);

            grid1.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;         //스크롤바 없애기
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;  //행선택 없애기                      
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.None;

            grid1.DoReadOnly(true);
            _GridUtil.InitializeGrid(this.grid1, true, false, true, "", false);
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;

            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 400, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTOMERCODE", "거래처코드", false, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 400, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            //_GridUtil.SetColumnMerge(this, grid1, "RECDATE");
            //grid1.DisplayLayout.Bands[0].Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;

            grid1.DisplayLayout.Override.DefaultRowHeight = m_iRowH;

            grid1.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.ColumnLayout;
            grid1.DisplayLayout.Bands[0].Override.AllowRowLayoutLabelSizing = RowLayoutSizing.Both;

            //헤더 크기 변경
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].RowLayoutColumnInfo.MinimumLabelSize = new Size(1, 1);
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].RowLayoutColumnInfo.PreferredLabelSize = new Size(320, 110);
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].RowLayoutColumnInfo.ActualLabelSize = new Size(250, 110);
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region <타이머 초기화>
            if (_tabTimer == null)
            {
                _tabTimer = new Timer();
                _tabTimer.Tick += new EventHandler(_tabTimer_Tick);
                _tabTimer.Interval = iTabTime * 1000;
            }
            _tabTimer.Start();

            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = 1000;
            }
            _timer.Start();

            #endregion
            DoInquire();
        }

        #region < TOOL BAR AREA >
        private void SetDataSet()
        {
            DBHelper helper = new DBHelper(false);
            listSum = new Dictionary<string, ClassSum>();
            listPage = new List<ClassPage>();

            string sPlantCode = DBHelper.nvlString(WIZ.LoginInfo.PlantCode);

            for (; 3 < grid1.Columns.Count;)
            {
                grid1.Columns.RemoveAt(grid1.Columns.Count - 1);
            }

            grid1.DisplayLayout.Bands[0].Groups.Clear();
            _GridUtil.Grid_Clear(grid1);

            //2020-11-16 날짜 데이터 오류로 인해 iDay-1 수정함
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Width = 320;
            grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Width = 250;


            dsData = helper.FillDataSet("USP_WM0162_S1", CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_SDATE", "", DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_EDATE", "", DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_SDATE2", "", DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_EDATE2", "", DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_CUSTCODE", "", DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_CUSTNAME", "", DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                                                        );


            rtnDtTemp = helper.FillTable("USP_WM0162_S2", CommandType.StoredProcedure
                                                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_SDATE", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_EDATE", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_SDATE2", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_EDATE2", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_CUSTCODE", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_CUSTNAME", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ITEMNAME", "", DbType.String, ParameterDirection.Input)
                                                       );


            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0] != null)
                {
                    dsData.Tables[0].Columns.Add("REM_QTY", typeof(double));
                }
            }
            else
            {
                return;
            }

            if (dsData.Tables.Count >= 2)
            {
                for (int i = 0; i < dsData.Tables[2].Rows.Count; i++)
                {
                    string sPreRecDate = CModule.ToString(dsData.Tables[2].Rows[i]["DUEDATE"]);

                    grid1.Columns.Add("PLAN_" + sPreRecDate, "수주수량");
                    grid1.Columns.Add("REM_" + sPreRecDate, "잔여");
                    grid1.Columns["PLAN_" + sPreRecDate].CellAppearance.TextHAlign = HAlign.Right;
                    grid1.Columns["REM_" + sPreRecDate].CellAppearance.TextHAlign = HAlign.Right;
                    grid1.Columns["PLAN_" + sPreRecDate].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns["REM_" + sPreRecDate].Header.Appearance.TextHAlign = HAlign.Center;
                    grid1.Columns["PLAN_" + sPreRecDate].Width = 150;
                    grid1.Columns["REM_" + sPreRecDate].Width = 120;
                    grid1.Columns["PLAN_" + sPreRecDate].CellActivation = Activation.NoEdit;
                    grid1.Columns["REM_" + sPreRecDate].CellActivation = Activation.NoEdit;

                    string[] sArr = { "PLAN_" + sPreRecDate, "REM_" + sPreRecDate };

                    _GridUtil.GridHeaderMerge(grid1, "A" + sPreRecDate, sPreRecDate, sArr, null);
                }
            }
            else
            {
                return;
            }

            // 로직 처리하기 직전에 모두 0으로 맞춰놓고 시작해야함
            iTotalPage = 0;
            iSubTotalPage = 0;
            iTotalRow = 0;



            for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
            {
                double dPlan = CModule.ToDouble(dsData.Tables[0].Rows[i]["PLANQTY"]);
                double dShip = CModule.ToDouble(dsData.Tables[0].Rows[i]["SHIPQTY"]);
                string sItemCode = CModule.ToString(dsData.Tables[0].Rows[i]["ITEMCODE"]);
                string sCustCode = CModule.ToString(dsData.Tables[0].Rows[i]["CUSTOMERCODE"]);

                double dRem = dPlan - dShip;

                if (dRem <= 0)
                {
                    dRem = 0;
                }
                else
                {

                    DataRow[] tdr = rtnDtTemp.Select("ITEMCODE = '" + sItemCode + "' and NOWQTY > 0");

                    if (tdr.Length > 0)
                    {
                        double dValue = CModule.ToDouble(tdr[0]["NOWQTY"]);

                        if (dRem >= dValue)
                        {
                            dRem -= dValue;
                            dValue = 0;
                        }
                        else
                        {
                            dValue -= dRem;
                            dRem = 0;
                        }

                        tdr[0]["NOWQTY"] = dValue;
                    }
                }

                dsData.Tables[0].Rows[i]["REM_QTY"] = dRem;
                string sKey = sCustCode + "|" + sItemCode;


                if (listSum.ContainsKey(sKey))
                {
                    listSum[sKey].Qty1 += dPlan;
                    listSum[sKey].Qty2 += dRem;
                }
                else
                {
                    listSum.Add(sKey, new ClassSum(dPlan, dRem));
                }
            }

            string sPreSubCode = "";

            for (int i = 0; i < dsData.Tables[1].Rows.Count; i++)
            {
                string sItemCode = CModule.ToString(dsData.Tables[1].Rows[i]["ITEMCODE"]);
                string sCustCode = CModule.ToString(dsData.Tables[1].Rows[i]["CUSTOMERCODE"]);

                if (sCustCode != sPreSubCode)
                {
                    iSubTotalPage = 0;
                }

                sPreSubCode = sCustCode;

                ClassPage clsPage = PageContain(sCustCode, sItemCode);
                clsPage.SubName = CModule.ToString(dsData.Tables[1].Rows[i]["CUSTNAME"]);
            }

            grid1.Columns.Add("PLAN_SUM", "수주수량");
            grid1.Columns.Add("REM_SUM", "잔여");
            grid1.Columns["PLAN_SUM"].CellAppearance.TextHAlign = HAlign.Right;
            grid1.Columns["REM_SUM"].CellAppearance.TextHAlign = HAlign.Right;
            grid1.Columns["PLAN_SUM"].Header.Appearance.TextHAlign = HAlign.Center;
            grid1.Columns["REM_SUM"].Header.Appearance.TextHAlign = HAlign.Center;
            grid1.Columns["PLAN_SUM"].Width = 150;
            grid1.Columns["REM_SUM"].Width = 100;

            string[] sArrSum = { "PLAN_SUM", "REM_SUM" };

            _GridUtil.GridHeaderMerge(grid1, "ASUM", "합계", sArrSum, null);

            m_iRowIdx = 0;

            int iSubTPage = 0;
            int iPage = 0;
            int iSubTotalRow = 0;

            for (int i = listPage.Count - 1; i >= 0; i--)
            {
                if (iSubTPage <= listPage[i].iSubTotalPage)
                {
                    iSubTPage = listPage[i].iSubTotalPage;
                    iPage = listPage[i].iSubTotalPage;

                    iSubTotalRow = listPage[i].listRow.Count + ((iSubTPage - 1) * m_iPageMove);
                }

                listPage[i].iSubTotalPage = iSubTPage;
                listPage[i].iSubPage = iPage--;
                listPage[i].iSubTotalRow = iSubTotalRow;
            }

            lblTotalRow.Text = CModule.ToString(iTotalRow);
        }

        /// <summary>
        /// /// ToolBar의 조회 버튼 클릭
        /// /// </summary>
        public override void DoInquire()
        {
            //base.DoInquire();
            _GridUtil.Grid_Clear(grid1);
            grid1.SuspendLayout();
            lblName.Text = "";

            try
            {
                if (listPage == null)
                {
                    SetDataSet();
                }

                if (iTotalPage <= m_iRowIdx)
                {
                    SetDataSet();

                    if (listPage.Count == 0)
                    {
                        return;
                    }
                }

                if (listPage.Count <= m_iRowIdx)
                {
                    m_iRowIdx = 0;
                }

                ClassPage clsPage = listPage[m_iRowIdx++];

                string sCustCode = clsPage.SubCode;

                lblName.Text = clsPage.SubName;
                lblCustPage.Text = CModule.ToString(clsPage.iSubPage) + " / " + CModule.ToString(clsPage.iSubTotalPage);
                lblCustRow.Text = CModule.ToString(clsPage.iSubTotalRow);
                lblTotalPage.Text = CModule.ToString(clsPage.iTotalPage) + " / " + CModule.ToString(iTotalPage);

                for (int ir = 0; ir < clsPage.listRow.Count; ir++)
                {
                    string sItemCode = clsPage.listRow[ir];

                    DataRow[] drArr = dsData.Tables[0].Select("CUSTOMERCODE = '" + sCustCode + "' and ITEMCODE = '" + sItemCode + "' ");

                    if (drArr.Length < 1)
                        continue;

                    foreach (DataRow dr in drArr)
                    {
                        string sRecDate = CModule.ToString(dr["RECDATE"]);

                        double dPlan = CModule.ToDouble(dr["PLANQTY"]);
                        double dRem = CModule.ToDouble(dr["REM_QTY"]);

                        bool bFind = false;
                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            if (CModule.ToString(grid1.Rows[i].Cells["CUSTOMERCODE"].Value) == CModule.ToString(dr["CUSTOMERCODE"])
                                && CModule.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value) == CModule.ToString(dr["ITEMCODE"]))
                            {
                                grid1.ActiveRow = grid1.Rows[i];
                                bFind = true;
                            }
                        }

                        if (!bFind)
                        {
                            grid1.InsertRow();

                            grid1.ActiveRow.Cells["CUSTOMERCODE"].Value = CModule.ToString(dr["CUSTOMERCODE"]);
                            grid1.ActiveRow.Cells["CUSTNAME"].Value = CModule.ToString(dr["CUSTNAME"]);
                            grid1.ActiveRow.Cells["ITEMCODE"].Value = CModule.ToString(dr["ITEMCODE"]);
                            grid1.ActiveRow.Activation = Activation.NoEdit;
                        }

                        grid1.ActiveRow.Cells["PLAN_" + sRecDate].Value = string.Format("{0:#,##0}", CModule.ToDouble(dPlan));
                        grid1.ActiveRow.Cells["REM_" + sRecDate].Value = string.Format("{0:#,##0}", CModule.ToDouble(dRem));
                    }

                    foreach (string sKey in listSum.Keys)
                    {
                        string[] sArr2 = sKey.Split('|');

                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            if (CModule.ToString(grid1.Rows[i].Cells["CUSTOMERCODE"].Value) == sArr2[0]
                                && CModule.ToString(grid1.Rows[i].Cells["ITEMCODE"].Value) == sArr2[1])
                            {
                                grid1.Rows[i].Cells["PLAN_SUM"].Value = string.Format("{0:#,##0}", listSum[sKey].Qty1);
                                grid1.Rows[i].Cells["REM_SUM"].Value = string.Format("{0:#,##0}", listSum[sKey].Qty2);
                                break;
                            }
                        }
                    }
                }

                grid1.ActiveRow = null;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                grid1.ResumeLayout(true);
            }
        }
        #endregion

        #region < 타이머 처리 >
        private void _tabTimer_Tick(object sender, EventArgs e)
        {
            _tabTimer.Stop();
            //_timer.Stop();

            try
            {
                // 페이징
                DoInquire();
            }
            catch
            {
            }
            finally
            {
                _tabTimer.Start();
                // _timer.Start();
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();

            try
            {
                DateTime dtNow = DateTime.Now;
                lblTime.Text = dtNow.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            finally
            {
                _timer.Start();
            }
        }
        #endregion

        #region < METHOD>

        #endregion

        private void MT0040_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tabTimer != null)
            {
                _tabTimer.Stop();
                _tabTimer.Dispose();
            }
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }

        #region < 이벤트 처리 >
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                switch (btn.Name.ToUpper())
                {
                    case "BTNREFRESH":
                        listPage = null;
                        DoInquire();
                        break;
                    case "BTNPRE":
                        if (m_iRowIdx <= 2)
                        {
                            m_iRowIdx = 0;
                        }
                        else
                        {
                            m_iRowIdx -= 2;
                        }

                        DoInquire();
                        break;
                    case "BTNAUTO":
                        if (btn.Text == "자동")
                        {
                            btn.Text = "수동";
                            _tabTimer.Stop();
                        }
                        else
                        {
                            btn.Text = "자동";
                            _tabTimer.Start();
                        }
                        break;
                    case "BTNNEXT":
                        if (m_iRowIdx >= iTotalPage - 1)
                        {
                            m_iRowIdx = iTotalPage - 1;
                        }

                        DoInquire();
                        break;
                }
            }
        }

        private void txtInterval_Leave(object sender, EventArgs e)
        {
            int iValue = CModule.ToInt32(txtInterval.Text.Trim());

            try
            {
                _tabTimer.Interval = iValue * 1000;
            }
            catch (Exception)
            {
                iValue = 10;
                txtInterval.Text = "10";
            }

            _tabTimer.Interval = iValue * 1000;
            CModule.SetAppSetting("MT0040|NTERVAL", txtInterval.Text.Trim());

        }
        #endregion

    }//class
}//namespace
