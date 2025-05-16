#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0500
//   Form Name    : 전수게더링 수집현황
//   Name Space   : WIZ.MT
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0500 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region < CONSTRUCTOR >
        public MT0500()
        {
            InitializeComponent();

        }
        #endregion

        #region < MT0500_Load >
        private void MT0500_Load(object sender, EventArgs e)
        {
            #region --- Grid 셋팅 ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CODENAME", "항목", false, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RELCODE4", "PLC", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RELCODE5", "IP", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수집일시", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TIME", "수집지연시간(분)", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //그리드 라인 색깔 해제
            //grid1.UseAppStyling = false;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;


            #endregion

            #region --- 콤보박스 세팅 ---
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                grid1.DataSource = helper.FillTable("USP_MT0500_S1", CommandType.StoredProcedure);
                grid1.DataBind();

                if (grid1.Rows.Count >= 1)
                {
                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        if (DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) >= 10 && DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) < 20)
                        {
                            grid1.Rows[i].Appearance.BackColor = Color.FromArgb(255, 255, 120);
                        }
                        else if (DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) >= 20 && DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) < 30)
                        {
                            grid1.Rows[i].Appearance.BackColor = Color.FromArgb(255, 210, 200);
                        }
                        else if (DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) >= 30 && DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) < 40)
                        {
                            grid1.Rows[i].Appearance.BackColor = Color.FromArgb(255, 150, 150);
                        }
                        else if (DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) >= 40 && DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) < 50)
                        {
                            grid1.Rows[i].Appearance.BackColor = Color.FromArgb(255, 100, 100);
                        }
                        else if (DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) >= 50 && DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) < 60)
                        {
                            grid1.Rows[i].Appearance.BackColor = Color.FromArgb(255, 0, 0);
                        }
                        else if (DBHelper.nvlInt(rtnDtTemp.Rows[i]["TIME"]) >= 60)
                        {
                            grid1.Rows[i].Appearance.BackColor = Color.DarkRed;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Int32 stimer = 5;
            if (btnStart.Text == "자동조회")
            {
                if (txtinterval.Text.Trim() != string.Empty)
                {
                    stimer = Convert.ToInt32(txtinterval.Text.Trim());
                }

                btnStart.Text = "정지";

                timer1.Interval = stimer * 1000;
                timer1.Tick += new EventHandler(t_Tick);
                timer1.Start();
                btnStart.BackColor = Color.LightSalmon;
            }
            else
            {
                btnStart.Text = "자동조회";
                timer1.Stop();
                timer1.Dispose();
                btnStart.BackColor = Color.White;
            }
        }

        public static bool _IsNumber(string _RecVal)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d.]+");

            if (!regex.IsMatch(_RecVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtinterval_TextChanged(object sender, EventArgs e)
        {
            if (!_IsNumber(this.txtinterval.Text.Trim()))
            {
                //입력된 데이터가 존재할 경우....
                if (txtinterval.Text.Length > 0)
                {
                    //한글자씩 뒤에서 부터 삭제
                    txtinterval.Text = txtinterval.Text.Remove(txtinterval.Text.Length - 1, 1);
                    txtinterval.Select(txtinterval.Text.Length, 0);
                }
            }
        }
        private void t_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                DoInquire();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                timer1.Enabled = true;
            }
        }
        #endregion
    }
}
