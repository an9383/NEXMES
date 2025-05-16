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
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using WIZ.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0012 : BaseMDIChildForm
    {
        #region < MEMEBER AREA >

        int m_iTabTime = 10; // 페이징 타임
        int m_iSearchTime = 30; // 재조회 타임

        Timer _tabTimer; // 페이징 타이머
        Timer _timer; //  타이머
        Timer _refreshTimer; // 모니터링 타이머

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();         //COMMON 객체 생성

        DataTable rtnDtTemp = new DataTable();          //return DataTable 공통

        int m_iRowIdx = 1;
        int m_iRowH = 110;
        int m_iPageMove = 6;

        int m_iMode = 0; // 전제 : 0 / 제조실 : 1 /  생산 : 

        #endregion

        public MT0012()
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
        private void MT0012_Load(object sender, EventArgs e)
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

            #endregion

            #region <그리드>

            grid1.Font = new Font("맑은 고딕", 28, FontStyle.Bold);

            grid1.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;         //스크롤바 없애기
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;  //행선택 없애기                      
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.None;

            grid1.DoReadOnly(true);
            _GridUtil.InitializeGrid(this.grid1, true, true, true, "", false);
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산지시번호", false, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 280, 0, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", false, GridColDataType_emu.VarChar, 420, 0, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 900, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY", "계획수량", false, GridColDataType_emu.VarChar, 300, 0, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNIT", "단위", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "단위수량", false, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "RECDATE", Infragistics.Win.HAlign.Center);
            //_GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Left);
            //_GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "PLANQTY", Infragistics.Win.HAlign.Right);

            //_GridUtil.SetColumnMerge(this, grid1, "RECDATE");
            //grid1.DisplayLayout.Bands[0].Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["PLANQTY"].Format = "#,##0";

            grid1.DisplayLayout.Override.DefaultRowHeight = m_iRowH;

            grid1.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.ColumnLayout;
            grid1.DisplayLayout.Bands[0].Override.AllowRowLayoutLabelSizing = RowLayoutSizing.Both;


            //헤더 크기 변경
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].RowLayoutColumnInfo.MinimumLabelSize = new Size(1, 1);
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].RowLayoutColumnInfo.PreferredLabelSize = new Size(470, 110);
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].RowLayoutColumnInfo.ActualLabelSize = new Size(470, 110);
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region <타이머 초기화>
            if (_tabTimer == null)
            {
                _tabTimer = new Timer();
                _tabTimer.Tick += new EventHandler(_tabTimer_Tick);
                _tabTimer.Interval = m_iTabTime * 1000;
            }
            _tabTimer.Start();

            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = 1000;
            }
            _timer.Start();

            if (_refreshTimer == null)
            {
                _refreshTimer = new Timer();
                _refreshTimer.Tick += new EventHandler(_refreshTimer_Tick);
                _refreshTimer.Interval = m_iSearchTime * 1000;
            }
            _refreshTimer.Start();

            #endregion

            SetMode(m_iMode);

            DoInquire();
        }

        //private void lbl_Title_DoubleClick(object sender, EventArgs e)
        //{
        //    this.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    WindowState = FormWindowState.Normal;
        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        #region < TOOL BAR AREA >

        /// <summary>
        /// /// ToolBar의 조회 버튼 클릭
        /// /// </summary>
        public override void DoInquire()
        {
            //base.DoInquire();

            _GridUtil.Grid_Clear(grid1);
            DBHelper helper = new DBHelper(false);

            try
            {
                //GRID
                string sPlantCode = DBHelper.nvlString(WIZ.LoginInfo.PlantCode);
                string sDate = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

                grid1.DataSource = helper.FillTable("USP_MT0012_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MODE", DBHelper.nvlString(m_iMode), DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_DATE", sDate, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
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
                SetNext();
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

        private void _refreshTimer_Tick(object sender, EventArgs e)
        {
            _refreshTimer.Stop();

            try
            {
                //재조회
                DoInquire();

            }
            catch
            {
            }
            finally
            {
                _refreshTimer.Start();
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
        private void SetNext()
        {
            int iPoint = 0;

            if (grid1 == null || grid1.Rows.Count <= 1)
            {
                return;
            }

            try
            {
                if (grid1.ActiveRowScrollRegion.FirstRow.Index + m_iPageMove >= grid1.Rows.Count)
                {
                    iPoint = 0;
                }
                else
                {
                    iPoint = grid1.ActiveRowScrollRegion.FirstRow.Index + m_iPageMove;
                }

                grid1.ActiveRowScrollRegion.FirstRow = grid1.Rows[iPoint];
                grid1.Refresh();
            }
            catch
            {
            }
        }//SetNext

        private void SetMode(int iMode)
        {
            switch (iMode)
            {
                case 0:
                default:
                    lbl_Title.Text = "전체 계획 현황 ";
                    break;
                case 1:
                    lbl_Title.Text = "제조실 계획 현황 ";
                    break;
                case 2:
                    lbl_Title.Text = "생산 계획 현황 ";
                    break;
            }

            DoInquire();

        }//SetMode

        #endregion

        private void MT0012_FormClosing(object sender, FormClosingEventArgs e)
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
            if (_refreshTimer != null)
            {
                _refreshTimer.Stop();
                _refreshTimer.Dispose();
            }
        }

        #region < 이벤트 처리 >

        private void lbl_Title_Click(object sender, EventArgs e)
        {
            m_iMode = (m_iMode + 1) % 3;
            SetMode(m_iMode);
        }
        #endregion

    }//class
}//namespace
