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
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.MD
{
    public partial class MD0070_POP2 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet DSGrid1 = new DataSet();
        Common _Common = new Common();

        DataTable dtBARCORE = new DataTable();

        string LOAD = "";

        #endregion

        #region < CONSTRUCTOR >
        public MD0070_POP2()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MD0070_POP2_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBARCODE;
            txtBARCODE.Focus();

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDCLEANTYPE"); //금형세척종류
            WIZ.Common.FillComboboxMaster(this.cbo_Clean, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >
        public void SetMoldInfo(DataTable DTinfo)
        {
            if (DTinfo.Rows.Count > 0)
            {
                txtMOLDPRODLIST.Text = CModule.ToString(DTinfo.Rows[0]["MOLDPROD"]);
                txtMOLDNAME.Text = CModule.ToString(DTinfo.Rows[0]["MOLDNAME"]);
                txtRPLOTNO.Text = CModule.ToString(DTinfo.Rows[0]["RP_LotNo"]);
                txtMOLDCODE.Text = CModule.ToString(DTinfo.Rows[0]["MOLDCODE"]);

                for (int i = 0; i < Convert.ToInt32(CModule.ToString(DTinfo.Rows[0]["CAVITYNUM"])); i++)
                {
                    if (i == Convert.ToInt32(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYNUM"])) - 1)
                        cbo_CVTLIST.Items.Add(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i));
                    else
                        cbo_CVTLIST.Items.Add(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i, 1));
                }
            }
            else
            {

            }
        }
        #endregion

        #region < METHOD AREA >
        private void CallBeforeWork()
        {
            for (int i = 0; i < DSGrid1.Tables[2].Rows.Count; i++)
            {
                for (int j = 0; j < grid1.Rows.Count; j++)
                {
                    if (CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_CoreName"]) == CModule.ToString(grid1.Rows[j].Cells[1].Value))
                    {
                        grid1.Rows[j].Cells[CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_CVT"])].Value = CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_UseCnt"]);
                    }
                }
            }

            for (int j = 0; j < grid1.Rows.Count; j++)
            {
                grid1.Rows[j].Cells["SUMCOUNT"].Value = 0;
                for (int i = 4; i < grid1.Columns.Count - 1; i++)
                {
                    grid1.Rows[j].Cells["SUMCOUNT"].Value = DBHelper.nvlDouble(grid1.Rows[j].Cells["SUMCOUNT"].Value) + CModule.ToDouble(grid1.Rows[j].Cells[i].Value);
                }
            }
        }
        #endregion

        private void txtBARCODE_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    #region < GRID SETTING >

                    grid1.DataSource = null;
                    listBox1.Items.Clear();

                    _GridUtil.InitializeGrid(grid1, true, true, false, "", false);

                    DBHelper helper = new DBHelper(false);
                    DSGrid1 = helper.FillDataSet("USP_MD0070_POP2_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_QRCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input));

                    if (Convert.ToString(DSGrid1.Tables[0].Rows[0]["RP_LotNo"]) == "")
                    {
                        this.ShowDialog("수리등록이 되어있지 않은 금형입니다.", Forms.DialogForm.DialogType.OK);
                    }
                    else
                    {
                        if (DSGrid1.Tables.Count >= 2)
                        {
                            _GridUtil.InitColumnUltraGrid(grid1, "Core_Code", "코어코드", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
                            _GridUtil.InitColumnUltraGrid(grid1, "Core_CoreName", "코어명", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
                            _GridUtil.InitColumnUltraGrid(grid1, "Core_Count", "코어잔량", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
                            _GridUtil.InitColumnUltraGrid(grid1, "SUMCOUNT", "사용량합계", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
                            for (int i = 0; i < Convert.ToInt32(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYNUM"])); i++)
                            {
                                int CAV = Convert.ToInt32(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Length);

                                if (CAV / Convert.ToInt32(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYNUM"])) == 1)
                                    if (i == Convert.ToInt32(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYNUM"])) - 1)
                                        //_GridUtil.InitColumnUltraGrid(grid1, "CAVITY." + i, CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i), true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Left, true, true);
                                        _GridUtil.InitColumnUltraGrid(grid1, CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i), CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i), true, GridColDataType_emu.VarChar, 50, 120, Infragistics.Win.HAlign.Center, true, true);
                                    else
                                        //_GridUtil.InitColumnUltraGrid(grid1, "CAVITY." + i, CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i, 1), true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Left, true, true);
                                        _GridUtil.InitColumnUltraGrid(grid1, CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i, 1), CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYSTRING"]).Substring(i, 1), true, GridColDataType_emu.VarChar, 50, 120, Infragistics.Win.HAlign.Center, true, true);
                            }

                            #endregion

                            SetMoldInfo(DSGrid1.Tables[0]);

                            grid1.DataSource = DSGrid1.Tables[1];
                            grid1.DataBinds();

                            for (int i = 0; i < DSGrid1.Tables[2].Rows.Count; i++)
                            {
                                for (int j = 0; j < grid1.Rows.Count; j++)
                                {
                                    if (CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_CoreName"]) == CModule.ToString(grid1.Rows[j].Cells[1].Value))
                                    {
                                        grid1.Rows[j].Cells[CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_CVT"])].Value = CModule.ToString(DSGrid1.Tables[2].Rows[i]["RPc_UseCnt"]);
                                    }
                                }
                            }

                            for (int j = 0; j < grid1.Rows.Count; j++)
                            {
                                grid1.Rows[j].Cells["SUMCOUNT"].Value = 0;
                                for (int i = 4; i < grid1.Columns.Count - 1; i++)
                                {
                                    grid1.Rows[j].Cells["SUMCOUNT"].Value = DBHelper.nvlDouble(grid1.Rows[j].Cells["SUMCOUNT"].Value) + CModule.ToDouble(grid1.Rows[j].Cells[i].Value);
                                }
                            }

                            for (int i = 0; i < DSGrid1.Tables[3].Rows.Count; i++)
                            {
                                listBox1.Items.Add(DSGrid1.Tables[3].Rows[i]["CAVITYNAME"]);
                            }
                        }

                        LOAD = "S";
                    }
                }
            }
            catch
            {

            }
        }

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_CLOSE_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(cbo_CVTLIST.Text))
                listBox1.Items.Add(cbo_CVTLIST.Text);
        }

        private void btn_OPEN_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(cbo_CVTLIST.Text);
        }

        private void grid1_AfterCellUpdate(object sender, CellEventArgs e)
        {

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_MD0070_POP2_D", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_RPc_MOLDCODE", txtMOLDCODE.Text, DbType.String, ParameterDirection.Input));

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    for (int j = 4; j < grid1.Columns.Count - 1; j++)
                    {
                        if (Convert.ToString(grid1.Rows[i].Cells[j].Value) != "")
                        {
                            helper.ExecuteNoneQuery("USP_MD0070_POP2_I", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                                , helper.CreateParameter("AS_RPc_Date", DateTime.Today.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RPc_LotNo", txtRPLOTNO.Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RPc_CoreCode", Convert.ToString(grid1.Rows[i].Cells[0].Value), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RPc_CoreName", Convert.ToString(grid1.Rows[i].Cells[1].Value), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RPc_MOLDCODE", txtMOLDCODE.Text, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RPc_CVT", Convert.ToString(grid1.Columns[j]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RPc_UseCnt", Convert.ToString(grid1.Rows[i].Cells[j].Value), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RPc_Status", "N", DbType.String, ParameterDirection.Input));
                        }
                    }
                }

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    helper.ExecuteNoneQuery("USP_MD0070_POP2_U", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", txtMOLDCODE.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CAVITYNAME", listBox1.Items[i].ToString(), DbType.String, ParameterDirection.Input));
                }

                helper.ExecuteNoneQuery("USP_MD0070_POP2_U2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_RPLOT", txtRPLOTNO.Text, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CLEANTYPE", cbo_Clean.Value, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", DTP1.Value.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_RPMEMO", txtMEMO.Text, DbType.String, ParameterDirection.Input));

                helper.Commit();
                this.Close();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {

            }
        }

        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            int sum = 0;
            try
            {
                if (LOAD == "S")
                {
                    for (int i = 4; i < Convert.ToInt32(CModule.ToString(DSGrid1.Tables[0].Rows[0]["CAVITYNUM"])) + 3; i++)
                    {
                        //grid1.ActiveRow.Cells["SUMCOUNT"].Value;
                        sum += CModule.ToInt32(grid1.ActiveRow.Cells[i].Text);
                    }
                    grid1.ActiveRow.Cells["SUMCOUNT"].Value = sum;


                    if (CModule.ToDouble(grid1.ActiveRow.Cells["Core_Count"].Value) < CModule.ToDouble(grid1.ActiveRow.Cells["SUMCOUNT"].Value) ||
                        CModule.ToDouble(grid1.ActiveRow.Cells["Core_Count"].Value) < CModule.ToDouble(e.Cell.Text))
                    {
                        this.ShowDialog("코어의 현재수량보다 많습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                        grid1.ActiveRow.Cells["SUMCOUNT"].Value = CModule.ToDouble(grid1.ActiveRow.Cells["SUMCOUNT"].Value) - CModule.ToDouble(grid1.ActiveRow.Cells[e.Cell.Column].Text);
                        grid1.ActiveRow.Cells[e.Cell.Column].Value = 0;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
