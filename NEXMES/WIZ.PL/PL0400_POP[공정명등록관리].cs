#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0682
//   Form Name    : 수주 현황
//   Name Space   : WIZ.BM
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
using System.Text;
using System.Net;
#endregion

namespace WIZ.PL
{
    public partial class PL0400_POP : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGrid1Manager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet DSGrid1 = new DataSet();

        DataTable dtBARCORE = new DataTable();

        string btnTag = "";
        string MOLDCODE = "";
        string sSTATE = "";

        int cnt;

        #endregion

        #region < CONSTRUCTOR >
        public PL0400_POP()
        {
            InitializeComponent();
            
        }
        #endregion

        #region < FORM LOAD >
        private void PL0400_POP_Load(object sender, EventArgs e)
        {
            

            #region GRID SETTING  
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLH1_Index",      "정열순서",     true, GridColDataType_emu.VarChar,     100, 100, Infragistics.Win.HAlign.Center,    true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "PLH1_Part",       "공정명",       true, GridColDataType_emu.VarChar,     150, 100, Infragistics.Win.HAlign.Center,    true, false); // 고객사       
            _GridUtil.InitColumnUltraGrid(grid1, "PLH1_Jo",         "Team",         true, GridColDataType_emu.VarChar,     120, 100, Infragistics.Win.HAlign.Center,    true, false); // 등록일자 
            _GridUtil.InitColumnUltraGrid(grid1, "PLH1_Time",       "Time",         true, GridColDataType_emu.VarChar,     120, 100, Infragistics.Win.HAlign.Center,    true, false); // 수주고유번호
            _GridUtil.InitColumnUltraGrid(grid1, "PLH1_Bigo",       "비고",         true, GridColDataType_emu.VarChar,     120, 100, Infragistics.Win.HAlign.Center,    true, false); // 등록 차수
            
            _GridUtil.SetInitUltraGridBind(grid1);



            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0410", CommandType.StoredProcedure);


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }


            #endregion
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >
        public void SetMoldInfo(DataTable DTinfo)
        {
            //if (DTinfo.Rows.Count > 0)
            //{
            //    txtMOLDPRODLIST.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
            //    txtDEGREE.Text       = CModule.ToString(DTinfo.Rows[0]["DEGREE"]);
            //    txtMOLDNAME.Text     = CModule.ToString(DTinfo.Rows[0]["MOLDNAME"]);

            //    checkBox3.Checked = true;

            //    for (int i = 0; i < Convert.ToInt32(CModule.ToString(DTinfo.Rows[0]["CAVITYNUM"])); i++)
            //    {
            //        if (i == Convert.ToInt32(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYNUM"])) - 1)
            //            cbo_CVTLIST.Items.Add("CAVITY." + CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i));
            //        else
            //            cbo_CVTLIST.Items.Add("CAVITY." + CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i, 1));
            //    }
            //}
            //else
            //{

            //}
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        private void txtBARCODE_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_CLOSE_Click(object sender, EventArgs e)
        {
            //if(!listBox1.Items.Contains(cbo_CVTLIST.Text + " 봉쇄"))
            //    listBox1.Items.Add(cbo_CVTLIST.Text + " 봉쇄");
        }

        private void btn_OPEN_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Remove(cbo_CVTLIST.Text + " 봉쇄");
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //if (e.Cell.Column.Key.Contains("CAVITY"))
            //{
            //    grid1.ActiveRow.Cells["SUMCOUNT"].Value = DBHelper.nvlDouble(grid1.ActiveRow.Cells["SUMCOUNT"].Value) + CModule.ToDouble(e.Cell.Value);
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //{
            //    checkBox2.Checked = false;
            //    checkBox3.Checked = false;
            //}
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox2.Checked == true)
            //{
            //    checkBox1.Checked = false;
            //    checkBox3.Checked = false;
            //}
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox3.Checked == true)
            //{
            //    checkBox1.Checked = false;
            //    checkBox2.Checked = false;
            //}
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            //DBHelper helper = new DBHelper("", true);

            //try
            //{
            //    helper.ExecuteNoneQuery("USP_PL0400_POP_D", CommandType.StoredProcedure
            //        , helper.CreateParameter("AS_RPc_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input));

            //    for (int i = 0; i < grid1.Rows.Count; i++)
            //    {
            //        for (int j = 2; j < grid1.Columns.Count - 1; j++)
            //        {
            //            if (Convert.ToString(grid1.Rows[i].Cells[j].Value) != "")
            //            {
            //                helper.ExecuteNoneQuery("USP_PL0400_POP_I", CommandType.StoredProcedure
            //                    , helper.CreateParameter("AS_RPc_LotNo",    "", DbType.String, ParameterDirection.Input)
            //                    , helper.CreateParameter("AS_RPc_CoreName", Convert.ToString(grid1.Rows[i].Cells[0].Value), DbType.String, ParameterDirection.Input)
            //                    , helper.CreateParameter("AS_RPc_MOLDCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input)
            //                    , helper.CreateParameter("AS_RPc_CVT",      Convert.ToString(grid1.Columns[j].ToString()), DbType.String, ParameterDirection.Input)
            //                    , helper.CreateParameter("AS_RPc_UseCnt",   Convert.ToString(grid1.Rows[i].Cells[j].Value), DbType.String, ParameterDirection.Input));
            //            }
            //        }
            //    }

            //    helper.Commit();
            //    this.Close();
            //}
            //catch (SException ex)
            //{
            //    CancelProcess = true;
            //    helper.Rollback();
            //    throw ex;
            //}
            //finally
            //{

            //}
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < DSGrid1.Tables[2].Rows.Count; i++)
            //{
            //    for (int j = 0; j < grid1.Rows.Count; j++)
            //    {
            //        if (CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_CoreName"]) == CModule.ToString(grid1.Rows[j].Cells[0].Value))
            //        {
            //            grid1.Rows[j].Cells[CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_CVT"])].Value = CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_UseCnt"]);
            //        }
            //    }
            //}


            //for (int j = 0; j < grid1.Rows.Count; j++)
            //{
            //    grid1.Rows[j].Cells["SUMCOUNT"].Value = 0;
            //    for (int i = 2; i < grid1.Columns.Count - 1; i++)
            //    {
            //        grid1.Rows[j].Cells["SUMCOUNT"].Value = DBHelper.nvlDouble(grid1.Rows[j].Cells["SUMCOUNT"].Value) + CModule.ToDouble(grid1.Rows[j].Cells[i].Value);
            //    }
            //}
        }
    }
}