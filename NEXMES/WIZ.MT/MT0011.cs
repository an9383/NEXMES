#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT011
//   Form Name    : 작업장별 생산현황 ( 대화산업 요청 사항)
//   Name Space   : WIZ.MT
//   Created Date : 2020-04-10
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

using WIZ.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0011 : BaseMDIChildForm
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

        #endregion

        public MT0011()
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
        private void MT0011_Load(object sender, EventArgs e)
        {
            #region < 초기화 >

            lblTotDef.Text = "";
            lblTotPlan.Text = "";
            lblTotProd.Text = "";

            // 회사메인로고
            string fileName = "COMPANYLOGO.PNG";

            Bitmap image = new Bitmap(Application.StartupPath + "\\Resources\\" + fileName);
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            #endregion

            #region <그리드>

            grid1.Font = new Font("맑은 고딕", 28, FontStyle.Bold);

            grid1.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;         //스크롤바 없애기
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;  //행선택 없애기                      
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.None;

            grid1.DoReadOnly(true);
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERSTATUS", "상태", false, GridColDataType_emu.VarChar, 10, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 100, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 300, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 470, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATGRADE", "재질", false, GridColDataType_emu.VarChar, 240, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COLORNAME", "색상", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시\r\n수량", false, GridColDataType_emu.VarChar, 170, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산\r\n수량", false, GridColDataType_emu.VarChar, 170, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "QTYPERCENT", "진행률", false, GridColDataType_emu.VarChar, 160, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DEFQTY", "불량\r\n수량", false, GridColDataType_emu.VarChar, 170, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DEFPERCENT", "불량률", false, GridColDataType_emu.VarChar, 160, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERNAME", Infragistics.Win.HAlign.Center);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "PRODQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "QTYPERCENT", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "DEFQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "DEFPERCENT", Infragistics.Win.HAlign.Right);

            grid1.Columns["ORDERQTY"].Format = "#,##0";
            grid1.Columns["PRODQTY"].Format = "#,##0";
            grid1.Columns["DEFQTY"].Format = "#,##0";
            grid1.Columns["QTYPERCENT"].Format = "0%";
            grid1.Columns["DEFPERCENT"].Format = "0%";

            //헤더 스타일 변경
            //grid1.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.FontData.SizeInPoints = 40F;
            //grid1.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor = System.Drawing.Color.Red;

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

                grid1.DataSource = helper.FillTable("USP_MT0011_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_DATE", sDate, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

                //완료된 지시 글자색상 수정
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["ORDERSTATUS"].Value) == "완료")
                    {
                        //grid1.Rows[i].Cells["ORDERSTATUS"].Appearance.ForeColor = Color.LightGray;
                        grid1.Rows[i].Appearance.ForeColor = Color.LightGray;
                    }
                }

                //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;

                DataTable rtnDtTemp = new DataTable();
                rtnDtTemp = helper.FillTable("USP_MT0011_S2", CommandType.StoredProcedure
                         , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("AS_DATE", sDate, DbType.String, ParameterDirection.Input));

                lblTotPlan.Text = rtnDtTemp.Rows[0]["ORDERQTY"].ToString();
                lblTotProd.Text = rtnDtTemp.Rows[0]["PRODQTY"].ToString();
                lblTotDef.Text = rtnDtTemp.Rows[0]["DEFQTY"].ToString();

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

        #endregion

        private void MT0011_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tabTimer.Stop();
            _timer.Stop();
            _refreshTimer.Stop();
            _tabTimer.Dispose();
            _timer.Dispose();
            _refreshTimer.Dispose();
        }
    }//class
}//namespace
