#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM0060
//   Form Name    : 3차원 SPC분석
//   Name Space   : WIZ.QM
//   Created Date : 2018-03-26
//   Made By      : WIZCORE 남부사무소 개발팀 사원 최수정
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.QM
{
    public partial class QM0060 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();                //그리드 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();       //POP-UP 객체 생성
        Common _Common = new Common();                                //COMMON 객체 생성

        DataTable rtnDtTemp = new DataTable();                        //retrun datatable 공통

        DataTable DtChk = new DataTable();                            //UC_SPC 표시 체크여부확인

        bool sMode = false;                                            //True:Auto, False:Manual
        bool bStop = true;                                             //모니터링 Timer STOP Flag
        System.Windows.Forms.Timer _timer;                             //모니터링 조회 Timer

        UC_SPC[] Uc_Spc = new UC_SPC[0];                              //UC_SPC 배열객체 생성
        int iDisplayNum = 0;                                          //Display번호


        #endregion

        #region < CONSTRUCTOR >
        public QM0060()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM3200_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region < COMBOBOX >

            //사업장
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            //일자
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion

            #region < POP-UP >

            //팝업 셋팅
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });  // 품목

            #endregion

            #region < Timer >
            gbx_MAS_H.Visible = true;
            bStop = true;

            if (_timer == null)
            {
                _timer = new System.Windows.Forms.Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = Convert.ToInt32(nup_SEARCHTIME_H.Value) * 1000;
            }

            _timer.Enabled = true;
            #endregion
        }

        #region < GRID >
        private void GridInitialize()
        {
            try
            {
                DtChk.Columns.Add("PLANTCODE");
                DtChk.Columns.Add("ITEMCODE");
                DtChk.Columns.Add("ITEMNAME");
                DtChk.Columns.Add("INSPCODE");
                DtChk.Columns.Add("INSPNAME");

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
        #endregion

        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            //조회 필수 항목 확인
            if (Convert.ToString(cbo_PLANTCODE_H.Value) == "")
            {
                this.ShowDialog(Common.getLangText("사업장을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (Convert.ToDateTime(cbo_STARTDATE_H.Value) > Convert.ToDateTime(cbo_ENDDATE_H.Value))
            {
                this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            pnl_MAIN_B.Controls.Clear();
            DtChk.Clear();

            DBHelper helper = new DBHelper(false);


            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Value);

                rtnDtTemp = helper.FillTable("USP_QM0060_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE == "S")
                {
                    tv_INSPLIST_B.Nodes.Clear();
                    QueryResultToTreeView(tv_INSPLIST_B, rtnDtTemp);
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();

                this.ClosePrgFormNew();
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion

        #region < EVENT AREA >

        //타이머
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (Uc_Spc != null && Uc_Spc.Length > 0)
            {
                try
                {
                    if (bStop == false)
                    {
                        pnl_MAIN_B.Controls.Clear();
                        Control_Display();
                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrorMessage(ex);
                }
            }
            else
            {
                return;
            }
        }

        //타이머상태변경
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (chk_AUTO_H.Checked == true)
            {
                if (_timer.Enabled == false)
                {
                    _timer.Enabled = true;
                }

                bStop = false;
                _timer.Interval = Convert.ToInt32(nup_SEARCHTIME_H.Value) * 1000 * 60;

            }
            else
            {
                if (_timer.Enabled == true)
                {
                    bStop = true;
                    _timer.Enabled = false;
                }
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

            for (int i = 0; i < Uc_Spc.Length; i++)
            {
                if (Uc_Spc[i] == null)
                {
                    break; ;
                }

                Uc_Spc[i].Width = pnl_MAIN_B.Width;
            }
        }

        private void QM3200_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Dispose();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (lbl_CNT_H.Text.Substring(0, 1) == "1")
            {
                this.ShowDialog(Common.getLangText("첫번째 화면입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            else
            {
                lbl_CNT_H.Text = (Convert.ToInt32(lbl_CNT_H.Text.Substring(0, 1)) - 1).ToString() + lbl_CNT_H.Text.Remove(0, 1);
                iDisplayNum = iDisplayNum - 2;

                Control_Display();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lbl_CNT_H.Text.Substring(0, 1) == lbl_CNT_H.Text.Substring(2, 1))
            {
                this.ShowDialog(Common.getLangText("마지막 화면입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            else
            {
                lbl_CNT_H.Text = (Convert.ToInt32(lbl_CNT_H.Text.Substring(0, 1)) + 1).ToString() + lbl_CNT_H.Text.Remove(0, 1);
                iDisplayNum = iDisplayNum + 2;

                Control_Display();
            }
        }

        private void cboStartDate_H_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(cbo_STARTDATE_H.Value) > Convert.ToDateTime(cbo_ENDDATE_H.Value) && Uc_Spc.Length > 0)
            {
                this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }


            for (int i = 0; i < Uc_Spc.Length; i++)
            {
                Uc_Spc[i].StartDate = Convert.ToString(cbo_STARTDATE_H.Value).Substring(0, 10);
                Uc_Spc[i].EndDate = Convert.ToString(cbo_ENDDATE_H.Value).Substring(0, 10);
            }
        }

        private void cboEndDate_H_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(cbo_STARTDATE_H.Value) > Convert.ToDateTime(cbo_ENDDATE_H.Value) && Uc_Spc.Length > 0)
            {
                this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }


            for (int i = 0; i < Uc_Spc.Length; i++)
            {
                Uc_Spc[i].StartDate = Convert.ToString(cbo_STARTDATE_H.Value).Substring(0, 10);
                Uc_Spc[i].EndDate = Convert.ToString(cbo_ENDDATE_H.Value).Substring(0, 10);
            }
        }

        private void tvMesr_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                string[] sPathCode = new string[2];
                string[] sPathSplit = e.Node.FullPath.Split('[');

                for (int i = 1; i < sPathSplit.Length; i++)
                {
                    string[] sPathSplit2 = sPathSplit[i].Split(']');
                    sPathCode[i - 1] = sPathSplit2[0];
                }

                if (DtChk.Rows.Count > 0 && sPathSplit[1] != DtChk.Rows[0][1].ToString())
                {
                    pnl_MAIN_B.Controls.Clear();
                    DtChk.Clear();
                }
            }


            if (e.Node.Level == 2)
            {
                string[] sPathCode = new string[6];
                string[] sPathSplit = e.Node.FullPath.Split('[');

                int ArrayIndex = 0;
                for (int i = 1; i < sPathSplit.Length; i++)
                {
                    string[] sPathSplit2 = sPathSplit[i].Split(']');
                    sPathCode[ArrayIndex] = sPathSplit2[0].Trim();
                    if (i == sPathSplit.Length - 1)
                    {
                        sPathCode[ArrayIndex + 1] = sPathSplit2[1].Substring(0, sPathSplit2[1].Length).Trim();
                    }
                    else
                    {
                        sPathCode[ArrayIndex + 1] = sPathSplit2[1].Substring(0, sPathSplit2[1].Length - 1).Trim();
                    }
                    ArrayIndex = ArrayIndex + 2;
                }

                DataRow[] arrRows = null;
                arrRows = DtChk.Select("PLANTCODE = '" + sPathCode[0] + "' AND ITEMCODE = '" + sPathCode[2] + "'" + " AND INSPCODE = '" + sPathCode[4] + "'");

                if (arrRows.Length > 0)
                {
                    for (int i = 0; i < Uc_Spc.Length; i++)
                    {
                        if (Uc_Spc[i].PlantCode == sPathCode[0] && Uc_Spc[i].ItemCode == sPathCode[2] && Uc_Spc[i].InspCode == sPathCode[4])
                        {
                            Uc_Spc[i].PerformAction_btnMesrCnt();
                        }
                    }
                }
                else
                {
                    DataRow dr = DtChk.NewRow();

                    dr["PLANTCODE"] = sPathCode[0];
                    dr["ITEMCODE"] = sPathCode[2];
                    dr["ITEMNAME"] = sPathCode[3];
                    dr["INSPCODE"] = sPathCode[4];
                    dr["INSPNAME"] = sPathCode[5];

                    DtChk.Rows.Add(dr);
                }

                Binding_UC_SPC();

                Control_Display();
            }
        }

        private void ultraSplitter1_Click(object sender, EventArgs e)
        {
            Control_Display();
        }

        private void ultraSplitter1_Move(object sender, EventArgs e)
        {
            Control_Display();
        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MANUAL_H.Checked == true)
            {
                chk_AUTO_H.Checked = false;
            }

        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AUTO_H.Checked == true)
            {
                chk_MANUAL_H.Checked = false;
            }
        }
        #endregion

        #region < METHOD AREA >
        private void Binding_UC_SPC()
        {
            int Chk_Cnt = 0;

            for (int i = 0; i < DtChk.Rows.Count; i++)
            {
                Chk_Cnt++;
            }

            if (Chk_Cnt == 0)
            {
                Uc_Spc = null;
                return;
            }


            lbl_CNT_H.Text = "1/" + ((Chk_Cnt / 2) + (Chk_Cnt % 2)).ToString();
            iDisplayNum = 0;

            Uc_Spc = new UC_SPC[Chk_Cnt];
            Chk_Cnt = 0;


            for (int j = 0; j < DtChk.Rows.Count; j++)
            {
                Chk_Cnt++;

                string sPlantCode = DBHelper.nvlString(DtChk.Rows[j]["PLANTCODE"].ToString());
                string sItemCode = DBHelper.nvlString(DtChk.Rows[j]["ITEMCODE"].ToString());
                string sItemName = DBHelper.nvlString(DtChk.Rows[j]["ITEMNAME"].ToString());
                string sInspCode = DBHelper.nvlString(DtChk.Rows[j]["INSPCODE"].ToString());
                string sInspName = DBHelper.nvlString(DtChk.Rows[j]["INSPNAME"].ToString());


                int x = 0;
                int y = 0;

                UC_SPC uc = new UC_SPC();
                uc.PlantCode = sPlantCode;
                uc.ItemCode = sItemCode;
                uc.ItemName = sItemName;
                uc.InspCode = sInspCode;
                uc.InspName = sInspName;
                uc.StartDate = Convert.ToString(cbo_STARTDATE_H.Value).Substring(0, 10);
                uc.EndDate = Convert.ToString(cbo_ENDDATE_H.Value).Substring(0, 10);
                uc.InspType = "3차원측정";

                if (Chk_Cnt > 1)
                {
                    if ((Chk_Cnt - 1) % 2 != 0)
                    {
                        y = Uc_Spc[Chk_Cnt - 2].Location.Y + Uc_Spc[Chk_Cnt - 2].Height;
                    }
                }

                uc.Width = pnl_MAIN_B.Width;
                uc.Height = pnl_MAIN_B.Height / 2;
                uc.Location = new Point(x, y);

                Uc_Spc[Chk_Cnt - 1] = uc;
            }
        }


        private void Control_Display()
        {
            pnl_MAIN_B.Refresh();
            pnl_MAIN_B.Controls.Clear();

            if (Uc_Spc != null)
            {
                for (int i = iDisplayNum; i < Uc_Spc.Length; i++)
                {
                    pnl_MAIN_B.Controls.Add(Uc_Spc[i]);
                }
            }
        }

        public void QueryResultToTreeView(TreeView tv, DataTable dt)
        {
            Dictionary<string, TreeNode> DicTn = new Dictionary<string, TreeNode>();
            for (int i = 1; i <= dt.Columns.Count; i++)
            {
                DataTable TempDT = getDistinct(dt, i);
                for (int k = 0; k < TempDT.Rows.Count; k++)
                {
                    string TreeNodeName = getRowName(TempDT, k, i);
                    DicTn[TreeNodeName] = new TreeNode(TempDT.Rows[k][i - 1].ToString());
                    if (i > 1)
                    {
                        string ParentName = getRowName(TempDT, k, i - 1);
                        if (string.IsNullOrEmpty(ParentName)) continue;
                        if (ParentName == TreeNodeName) continue;
                        DicTn[ParentName].Nodes.Add(DicTn[TreeNodeName]);
                    }

                    else tv.Nodes.Add(DicTn[TreeNodeName]);
                }
            }
        }

        private string getRowName(DataTable dt, int rowCnt, int colCnt)
        {
            string str = null;
            for (int i = 0; i < colCnt; i++) str += dt.Rows[rowCnt][i].ToString();
            return str;
        }

        private DataTable getDistinct(DataTable dt, int level)
        {
            string[] str = new string[level];
            for (int i = 0; i < level; i++) str[i] = dt.Columns[i].ColumnName;
            return dt.DefaultView.ToTable(true, str);
        }

        #endregion
    }
}