#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0020
//   Form Name    : 4분할 모니터링
//   Name Space   : WIZ.MT
//   Created Date : 
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using Infragistics.Win;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0020 : Forms.BaseMDIChildForm
    {
        UC_WorkCenterProdStatus[] ArrUcWc2 = new UC_WorkCenterProdStatus[24];

        #region [ MEMBER AREA ]
        private string sPlantCode = LoginInfo.PlantCode;
        private int iRowCnt = 1; // 화면 Row 생성 기준
        private int iColCnt = 1; // 화면 Column 생성 기준
        bool bStart = false;

        DataTable rtnDtTemp = new DataTable();
        DataTable dtNotice = new DataTable();

        DataSet dsData = new DataSet();

        Timer _timerTabChange = new Timer();
        Timer _timerDataSearch = new Timer();

        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        UC_SPC[] _ucSPC;
        UC_CheckSheet[] _ucCheckSheet;
        UC_WorkCenterStatus[] _ucWCStatus;
        UC_WorkCenterCheck[] _ucWCCheck;

        Hashtable hashXAXIS = new Hashtable();
        Hashtable hashYAXIS = new Hashtable();
        Hashtable hashWCData = new Hashtable();
        #endregion

        #region [ CONSTRUCTOR ]
        public MT0020()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            bPopUp = true;

            tcMonitoring.Appearance = TabAppearance.FlatButtons;
            tcMonitoring.ItemSize = new Size(0, 1);
            tcMonitoring.SizeMode = TabSizeMode.Fixed;

            tcMonitoring.SelectedTab = tcMonitoring.TabPages[0];

            _timerTabChange.Tick += new EventHandler(_timerTabChange_Tick);
            _timerTabChange.Interval = Convert.ToInt32(nudChange.Value) * 1000;

            _timerDataSearch.Tick += new EventHandler(_timerDataSearch_Tick);
            _timerDataSearch.Interval = Convert.ToInt32(nudSearch.Value) * 1000;
        }
        #endregion

        #region [ FORMLOAD EVENT ]
        private void MT0020_Load(object sender, EventArgs e)
        {
            #region [ 생산현황]
            ArrUcWc2[0] = WC0001;
            ArrUcWc2[1] = WC0002;
            ArrUcWc2[2] = WC0003;
            ArrUcWc2[3] = WC0004;
            ArrUcWc2[4] = WC0005;
            ArrUcWc2[5] = WC0006;
            ArrUcWc2[6] = WC0007;
            ArrUcWc2[7] = WC0008;
            ArrUcWc2[8] = WC0009;
            ArrUcWc2[9] = WC0010;
            ArrUcWc2[10] = WC0011;
            ArrUcWc2[11] = WC0012;
            ArrUcWc2[12] = WC0013;
            ArrUcWc2[13] = WC0014;
            ArrUcWc2[14] = WC0015;
            ArrUcWc2[15] = WC0016;
            ArrUcWc2[16] = WC0017;
            ArrUcWc2[17] = WC0018;
            ArrUcWc2[18] = WC0019;
            ArrUcWc2[19] = WC0020;
            ArrUcWc2[20] = WC0021;
            ArrUcWc2[21] = WC0022;
            ArrUcWc2[22] = WC0023;
            ArrUcWc2[23] = WC0024;
            #endregion

            #region [ 자주검사 현황 ]
            _GridUtil.InitializeGrid(this.grid1, false, false, true, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "검사일자", true, GridColDataType_emu.VarChar, 0, 100, HAlign.Center, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WCINFO", "호기", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "07H", "07H", true, GridColDataType_emu.Image, 100, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "09H", "09H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "11H", "11H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "13H", "13H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "15H", "15H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "17H", "17H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "19H", "19H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "21H", "21H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "23H", "23H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "01H", "01H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "03H", "03H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "05H", "05H", true, GridColDataType_emu.Image, 111, 100, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ING", "진행률", true, GridColDataType_emu.VarChar, 182, 100, HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTAL", "종합진행률", true, GridColDataType_emu.VarChar, 182, 100, HAlign.Right, true, false);

            grid1.Columns["07H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["09H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["11H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["13H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["15H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["17H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["19H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["21H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["23H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["01H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["03H"].CellAppearance.ImageHAlign = HAlign.Center;
            grid1.Columns["05H"].CellAppearance.ImageHAlign = HAlign.Center;

            grid1.Columns["07H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["09H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["11H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["13H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["15H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["17H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["19H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["21H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["23H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["01H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["03H"].CellAppearance.ImageVAlign = VAlign.Middle;
            grid1.Columns["05H"].CellAppearance.ImageVAlign = VAlign.Middle;

            grid1.Columns["INSPDATE"].CellAppearance.FontData.SizeInPoints = 30;
            grid1.Columns["WCINFO"].CellAppearance.FontData.SizeInPoints = 30;
            grid1.Columns["ING"].CellAppearance.FontData.SizeInPoints = 30;
            grid1.Columns["TOTAL"].CellAppearance.FontData.SizeInPoints = 30;

            grid1.Columns["INSPDATE"].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            grid1.Columns["WCINFO"].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            grid1.Columns["ING"].CellAppearance.FontData.Bold = DefaultableBoolean.True;
            grid1.Columns["TOTAL"].CellAppearance.FontData.Bold = DefaultableBoolean.True;

            grid1.UseAppStyling = false;
            grid1.DisplayLayout.Override.DefaultRowHeight = 95;
            grid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            grid1.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightGray;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            grid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            grid1.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Default;
            grid1.DisplayLayout.Override.HeaderAppearance.FontData.SizeInPoints = 20;

            _GridUtil.SetInitUltraGridBind(grid1);

            bStart = true;

            int i = gbxBody.Width;
            int y = gbxBody.Height;
            #endregion

            DoSetting();

            picLoading.Image = (Image)Properties.Resources.ResourceManager.GetObject("MT_Loading");
        }
        #endregion

        #region [ METHOD AREA ]
        private void InitInfo()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MT0020_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S" && rtnDtTemp.Rows.Count > 0)
                {
                    iRowCnt = Convert.ToInt16(rtnDtTemp.Rows[0]["ROWCNT"]);
                    iColCnt = Convert.ToInt16(rtnDtTemp.Rows[0]["COLCNT"]);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void DoSetting()
        {
            InitInfo();

            pnlSPC.Controls.Clear();
            pnlCS.Controls.Clear();
            pnlWorkcenter.Controls.Clear();
            pnlFACheck.Controls.Clear();

            if (_ucSPC != null)
            {
                Array.Clear(_ucSPC, 0, _ucSPC.Length);
            }

            if (_ucCheckSheet != null)
            {
                Array.Clear(_ucCheckSheet, 0, _ucCheckSheet.Length);
            }

            if (_ucWCStatus != null)
            {
                Array.Clear(_ucWCStatus, 0, _ucWCStatus.Length);
            }

            if (_ucWCCheck != null)
            {
                Array.Clear(_ucWCCheck, 0, _ucWCCheck.Length);
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                dsData = helper.FillDataSet("USP_MT0020_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S" && dsData.Tables.Count == 5)
                {
                    Data_SPC(true, dsData.Tables[0], dsData.Tables[1]);
                    Data_CheckSheet(true, dsData.Tables[2]);
                    Data_WorkCenter(true, dsData.Tables[3]);
                    Data_FacilityCheck(true, dsData.Tables[4]);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                if (_timerTabChange.Enabled == false)
                    _timerTabChange.Enabled = true;

                if (_timerDataSearch.Enabled == false)
                    _timerDataSearch.Enabled = true;
            }
        }

        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                dsData = helper.FillDataSet("USP_MT0020_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S" && dsData.Tables.Count == 5)
                {
                    Data_SPC(false, dsData.Tables[0], dsData.Tables[1]);
                    Data_CheckSheet(false, dsData.Tables[2]);
                    Data_WorkCenter(false, dsData.Tables[3]);
                    Data_FacilityCheck(false, dsData.Tables[4]);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        private void Data_SPC(bool bSetting, DataTable dtTemp01, DataTable dtTemp02)
        {
            DataSet dsSPC = new DataSet();

            dsSPC.Tables.Add(dtTemp01.Copy());
            dsSPC.Tables.Add(dtTemp02.Copy());

            System.Windows.Forms.Control _cnl = new System.Windows.Forms.Control();
            _cnl = pnlSPC;

            if (bSetting == true)
            {
                int iAxisX = 0;
                int iAxisY = 0;
                int iWidth = _cnl.Width;
                int iHeight = _cnl.Height / 2;

                _ucSPC = new UC_SPC[2];

                for (int i = 0; i < 2; i++)
                {
                    iAxisY = 0 + (iHeight * i);

                    UC_SPC _uc = new UC_SPC();

                    _uc.DtData = dsSPC.Tables[i];
                    _uc.Location = new Point(iAxisX, iAxisY);
                    _uc.Size = new Size(iWidth, iHeight);

                    _ucSPC[i] = _uc;

                    _cnl.Controls.Add(_uc);
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    _ucSPC[i].DtData = dsSPC.Tables[i];
                }
            }

            _cnl.Refresh();
        }

        private void Data_CheckSheet(bool bSetting, DataTable dtTemp)
        {
            DataTable dtData = dtTemp;

            System.Windows.Forms.Control _cnl = new System.Windows.Forms.Control();
            _cnl = pnlCS;

            if (bSetting == true)
            {
                string sWorkCenter = string.Empty;

                int iRowST = 0;
                int iColST = 0;
                int iAxisX = 0;
                int iAxisY = 0;
                int iWidth = _cnl.Width / iColCnt;
                int iHeight = _cnl.Height / iRowCnt;
                int iWorkCenterCnt = dtData.Rows.Count;

                _ucCheckSheet = new UC_CheckSheet[iWorkCenterCnt];

                for (int i = 0; i < iWorkCenterCnt; i++)
                {
                    sWorkCenter = Convert.ToString(dtData.Rows[i]["WORKCENTERCODE"]);

                    int iX = iColST / iColCnt;
                    int iY = iRowST / iRowCnt;

                    if (iX > 0)
                    {
                        iRowST++;
                        iColST = 0;
                    }

                    iAxisX = 0 + (iWidth * iColST);
                    iAxisY = 0 + (iHeight * iRowST);

                    UC_CheckSheet _uc = new UC_CheckSheet();

                    _uc.Name = sWorkCenter;
                    _uc.WCData = dtData.Rows[i];
                    _uc.Location = new Point(iAxisX, iAxisY);
                    _uc.Size = new Size(iWidth, iHeight);

                    _ucCheckSheet[i] = _uc;

                    _cnl.Controls.Add(_uc);

                    iColST++;
                }
            }
            else
            {
                for (int i = 0; i < _ucWCStatus.Length; i++)
                {
                    _ucCheckSheet[i].WCData = dtData.Rows[i];
                }
            }

            _cnl.Refresh();
        }

        private void Data_WorkCenter(bool bSetting, DataTable dtTemp)
        {
            DataTable dtData = dtTemp;

            System.Windows.Forms.Control _cnl = new System.Windows.Forms.Control();
            _cnl = pnlWorkcenter;

            if (bSetting == true)
            {
                string sWorkCenter = string.Empty;

                int iRowST = 0;
                int iColST = 0;
                int iAxisX = 0;
                int iAxisY = 0;
                int iWidth = _cnl.Width / iColCnt;
                int iHeight = _cnl.Height / iRowCnt;
                int iWorkCenterCnt = dtData.Rows.Count;

                _ucWCStatus = new UC_WorkCenterStatus[iWorkCenterCnt];

                for (int i = 0; i < iWorkCenterCnt; i++)
                {
                    sWorkCenter = Convert.ToString(dtData.Rows[i]["WORKCENTERCODE"]);

                    int iX = iColST / iColCnt;
                    int iY = iRowST / iRowCnt;

                    if (iX > 0)
                    {
                        iRowST++;
                        iColST = 0;
                    }

                    iAxisX = 0 + (iWidth * iColST);
                    iAxisY = 0 + (iHeight * iRowST);

                    UC_WorkCenterStatus _uc = new UC_WorkCenterStatus();

                    _uc.Name = sWorkCenter;
                    _uc.WCData = dtData.Rows[i];
                    _uc.Location = new Point(iAxisX, iAxisY);
                    _uc.Size = new Size(iWidth, iHeight);

                    _ucWCStatus[i] = _uc;

                    _cnl.Controls.Add(_uc);

                    iColST++;
                }
            }
            else
            {
                for (int i = 0; i < _ucWCStatus.Length; i++)
                {
                    _ucWCStatus[i].WCData = dtData.Rows[i];
                }
            }

            _cnl.Refresh();
        }

        private void Data_FacilityCheck(bool bSetting, DataTable dtTemp)
        {
            DataTable dtData = dtTemp;

            System.Windows.Forms.Control _cnl = new System.Windows.Forms.Control();
            _cnl = pnlFACheck;

            if (bSetting == true)
            {
                string sWorkCenter = string.Empty;

                int iRowST = 0;
                int iColST = 0;
                int iAxisX = 0;
                int iAxisY = 0;
                int iWidth = _cnl.Width / iColCnt;
                int iHeight = _cnl.Height / iRowCnt;
                int iWorkCenterCnt = dtData.Rows.Count;

                _ucWCCheck = new UC_WorkCenterCheck[iWorkCenterCnt];

                for (int i = 0; i < iWorkCenterCnt; i++)
                {
                    sWorkCenter = Convert.ToString(dtData.Rows[i]["WORKCENTERCODE"]);

                    int iX = iColST / iColCnt;
                    int iY = iRowST / iRowCnt;

                    if (iX > 0)
                    {
                        iRowST++;
                        iColST = 0;
                    }

                    iAxisX = 0 + (iWidth * iColST);
                    iAxisY = 0 + (iHeight * iRowST);

                    UC_WorkCenterCheck _uc = new UC_WorkCenterCheck();

                    _uc.Name = sWorkCenter;
                    _uc.WCData = dtData.Rows[i];
                    _uc.Location = new Point(iAxisX, iAxisY);
                    _uc.Size = new Size(iWidth, iHeight);

                    _ucWCCheck[i] = _uc;

                    _cnl.Controls.Add(_uc);

                    iColST++;
                }
            }
            else
            {
                for (int i = 0; i < _ucWCCheck.Length; i++)
                {
                    _ucWCCheck[i].WCData = dtData.Rows[i];
                }
            }

            _cnl.Refresh();
        }
        #endregion

        #region [ EVENT AREA ]
        private void pnlCI_DoubleClick(object sender, EventArgs e)
        {
            _timerTabChange.Enabled = false;
            _timerDataSearch.Enabled = false;

            DoSetting();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            _timerTabChange.Enabled = false;
            _timerDataSearch.Enabled = false;

            _timerTabChange.Dispose();
            _timerDataSearch.Dispose();

            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _timerTabChange.Enabled = false;
            _timerDataSearch.Enabled = false;

            _timerTabChange.Interval = Convert.ToInt32(nudChange.Value * 1000);
            _timerDataSearch.Interval = Convert.ToInt32(nudSearch.Value * 1000);

            _timerTabChange.Enabled = true;
            _timerDataSearch.Enabled = true;
        }

        private void tcMonitoring_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBHelper helper = new DBHelper(false);

                switch (tcMonitoring.SelectedIndex)
                {
                    case 0:
                        lblTitle.Text = "MONITORING";
                        break;
                    case 1:
                        lblTitle.Text = "생 산 현 황";

                        rtnDtTemp = helper.FillTable("USP_MT0020_S3", CommandType.StoredProcedure
                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                        for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                        {
                            for (int j = 0; j < ArrUcWc2.Length; j++)
                            {
                                if (ArrUcWc2[j].Name == rtnDtTemp.Rows[i]["WORKCENTERCODE"].ToString())
                                {
                                    ArrUcWc2[j].WCData = rtnDtTemp.Rows[i];
                                    ArrUcWc2[j].Refresh();
                                }
                            }
                        }
                        rtnDtTemp.Clear();

                        break;
                    case 2:
                        lblTitle.Text = "자 주 검 사 현 황";

                        try
                        {
                            _GridUtil.Grid_Clear(grid1);

                            rtnDtTemp = helper.FillTable("USP_MT0020_S4", CommandType.StoredProcedure
                                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                            grid1.DataSource = rtnDtTemp;
                            grid1.DataBinds();
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

                        break;
                    case 3:
                        lblTitle.Text = "공 지 사 항";

                        try
                        {
                            dtNotice = helper.FillTable("USP_BM0580_S1", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                            if (helper.RSCODE == "S" && dtNotice.Rows.Count > 0)
                            {
                                rtxNotice.Text = Convert.ToString(dtNotice.Rows[0]["MTTEXT"]);
                                rtxNotice.Rtf = Convert.ToString(dtNotice.Rows[0]["MTRTF"]);
                            }
                            else
                            {
                                rtxNotice.Text = string.Empty;
                                rtxNotice.Rtf = string.Empty;
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                        }
                        finally
                        {
                            helper.Close();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                if (_timerDataSearch.Enabled == false)
                {
                    _timerDataSearch.Enabled = true;
                }
            }
        }

        private void _timerTabChange_Tick(object sender, EventArgs e)
        {
            _timerTabChange.Enabled = false;

            try
            {
                return;
                if (tcMonitoring.SelectedIndex == 0)
                {
                    _timerDataSearch.Enabled = false;
                    tcMonitoring.SelectedTab = tcMonitoring.TabPages[1];  // 생산현황으로 변경

                    _timerTabChange.Interval = Convert.ToInt32(nudChange.Value) * 1000;
                }
                else if (tcMonitoring.SelectedIndex == 1)
                {
                    _timerDataSearch.Enabled = false;
                    tcMonitoring.SelectedTab = tcMonitoring.TabPages[2];  // 자주검사로 변경

                    _timerTabChange.Interval = Convert.ToInt32(nudChange.Value) * 1000;
                }
                else if (tcMonitoring.SelectedIndex == 2)
                {
                    _timerDataSearch.Enabled = false;
                    tcMonitoring.SelectedTab = tcMonitoring.TabPages[3];  // 공지사항으로 변경

                    _timerTabChange.Interval = (Convert.ToInt32(nudChange.Value) / 5) * 1000;
                }
                else
                {
                    _timerDataSearch.Enabled = true;
                    tcMonitoring.SelectedTab = tcMonitoring.TabPages[0];  // 모니터링으로 변경

                    _timerTabChange.Interval = Convert.ToInt32(nudChange.Value) * 1000;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                _timerTabChange.Enabled = true;
            }
        }

        private void _timerDataSearch_Tick(object sender, EventArgs e)
        {

            _timerDataSearch.Enabled = false;

            try
            {
                DBHelper helper = new DBHelper(false);

                if (tcMonitoring.SelectedIndex == 0)
                {
                    DoFind();
                }
                else if (tcMonitoring.SelectedIndex == 1)
                {
                    rtnDtTemp = helper.FillTable("USP_MT0020_S3", CommandType.StoredProcedure
                                  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        for (int j = 0; j < ArrUcWc2.Length; j++)
                        {
                            if (ArrUcWc2[j].Name == rtnDtTemp.Rows[i]["WORKCENTERCODE"].ToString())
                            {
                                ArrUcWc2[j].WCData = rtnDtTemp.Rows[i];
                                ArrUcWc2[j].Refresh();
                            }
                        }
                    }
                    rtnDtTemp.Clear();
                }
                else if (tcMonitoring.SelectedIndex == 2)
                {
                    try
                    {
                        _GridUtil.Grid_Clear(grid1);

                        rtnDtTemp = helper.FillTable("USP_MT0020_S4", CommandType.StoredProcedure
                                  , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
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
                else if (tcMonitoring.SelectedIndex == 3)
                {
                    try
                    {
                        dtNotice = helper.FillTable("USP_BM0580_S1", CommandType.StoredProcedure
                                 , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S" && dtNotice.Rows.Count > 0)
                        {
                            rtxNotice.Text = Convert.ToString(dtNotice.Rows[0]["MTTEXT"]);
                            rtxNotice.Rtf = Convert.ToString(dtNotice.Rows[0]["MTRTF"]);
                        }
                        else
                        {
                            rtxNotice.Text = string.Empty;
                            rtxNotice.Rtf = string.Empty;
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                _timerDataSearch.Enabled = true;
            }
        }
        #endregion

        private void MT0020_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timerTabChange.Stop();
            _timerDataSearch.Stop();
            _timerTabChange.Enabled = false;
            _timerDataSearch.Enabled = false;
        }
    }
}