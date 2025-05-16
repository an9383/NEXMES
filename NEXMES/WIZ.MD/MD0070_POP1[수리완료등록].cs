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
using System.Windows.Forms;
#endregion

namespace WIZ.MD
{
    public partial class MD0070_POP1 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        //DBHelper helper = new DBHelper("", true);

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataSet DSGrid1 = new DataSet();
        DataSet dataset = new DataSet();
        string MDCODE = "";

        int cal = 0;
        int minus = 0;

        #endregion

        #region < CONSTRUCTOR >
        public MD0070_POP1(string MOLDCODE)
        {
            InitializeComponent();
            MDCODE = MOLDCODE;
        }
        #endregion

        #region < FORM LOAD >
        private void MD0070_POP1_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CORE_CODE", "코어코드", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "업체명", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CORE_CORENAME", "코어명", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CORE_CHASU", "차수", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USECNT", "사용량", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Right, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "CAVITYNAME", "캐비티", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "STATUS", "봉쇄", true, GridColDataType_emu.VarChar, 80, 120, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "RPC_CoreCode", "코어코드", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTNAME", "업체명", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "RPc_CoreName", "코어명", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "Core_ChaSu", "차수", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "RPc_CVT", "캐비티", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "RPc_UseCnt", "사용량", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.SetInitUltraGridBind(grid3);
        }

        #endregion

        #region < TOOL BAR AREA >

        #endregion

        #region < EVENT AREA >
        public void SetMoldInfo(DataTable DTinfo)
        {
            if (DTinfo.Rows.Count > 0)
            {

            }
            else
            {

            }
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);
            if (checkBox1.Checked == false)
            {
                this.ShowDialog("코어사용 내역을 체크해주세요.", Forms.DialogForm.DialogType.OK);
            }
            else if (checkBox3.Checked == false)
            {
                this.ShowDialog("캐비티상태 내역을 체크해주세요.", Forms.DialogForm.DialogType.OK);
            }
            else if (checkBox2.Checked == false)
            {
                this.ShowDialog("세척상태를 체크해주세요.", Forms.DialogForm.DialogType.OK);
            }
            else if (checkBox1.Checked == true && checkBox3.Checked == true && checkBox2.Checked == true)
            {
                try
                {
                    // 코어단가
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        dataset = helper.FillDataSet("USP_MD0050_POP2_S1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_CORECODE", Convert.ToString(grid1.Rows[i].Cells["CORE_CODE"].Value), DbType.String, ParameterDirection.Input));

                        minus = Convert.ToInt32(grid1.Rows[i].Cells["USECNT"].Value);
                        for (int j = 0; j < dataset.Tables[1].Rows.Count; j++)
                        {
                            cal = Convert.ToInt32(dataset.Tables[1].Rows[j]["IO_NOWCNT"]) - minus;

                            if (cal >= 0)
                            {
                                helper.ExecuteNoneQuery("USP_MD0050_POP2_SAVE", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                                    , helper.CreateParameter("AS_IO_LOTNO", Convert.ToString(dataset.Tables[1].Rows[j]["IO_LOTNO"]), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_IO_NOWCNT", cal, DbType.Int32, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_IO_COST", Convert.ToInt32(dataset.Tables[1].Rows[j]["IO_COST"]), DbType.Int32, ParameterDirection.Input)

                                    , helper.CreateParameter("AS_EX_PRODDATE", DateTime.Now, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_CoreCode", Convert.ToString(dataset.Tables[1].Rows[j]["IO_CORECODE"]), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_Count", minus, DbType.Int32, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_Type", "0", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_ETC1", txtETC.Text, DbType.String, ParameterDirection.Input));
                                break;
                            }
                            else if (cal < 0)
                            {
                                helper.ExecuteNoneQuery("USP_MD0050_POP2_SAVE", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                                    , helper.CreateParameter("AS_IO_LOTNO", Convert.ToString(dataset.Tables[1].Rows[j]["IO_LOTNO"]), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_IO_NOWCNT", 0, DbType.Int32, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_IO_COST", Convert.ToInt32(dataset.Tables[1].Rows[j]["IO_COST"]), DbType.Int32, ParameterDirection.Input)

                                    , helper.CreateParameter("AS_EX_PRODDATE", DateTime.Now, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_CoreCode", Convert.ToString(dataset.Tables[1].Rows[j]["IO_CORECODE"]), DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_Count", Convert.ToInt32(dataset.Tables[1].Rows[j]["IO_NOWCNT"]), DbType.Int32, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_Type", "0", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EX_ETC1", txtETC.Text, DbType.String, ParameterDirection.Input));

                                minus -= Convert.ToInt32(dataset.Tables[1].Rows[j]["IO_NOWCNT"]);
                            }
                        }
                    }

                    helper.ExecuteNoneQuery("USP_MD0070_POP1_I", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_RPLOT", txtRPLOTNO.Text, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_CLEANTYPE", CBO_CLEAN.Text, DbType.String, ParameterDirection.Input));

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
        }

        private void txtBARCODE_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DBHelper helper = new DBHelper(false);
                    DSGrid1 = helper.FillDataSet("USP_MD0070_POP1_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_QRCODE", txtBARCODE.Text, DbType.String, ParameterDirection.Input));

                    if (Convert.ToString(DSGrid1.Tables[2].Rows[0]["RP_LotNo"]) == "")
                    {
                        this.ShowDialog("수리중이 아닌 금형입니다.", Forms.DialogForm.DialogType.OK);
                    }
                    else
                    {
                        grid1.DataSource = DSGrid1.Tables[3];
                        grid1.DataBind();

                        grid2.DataSource = DSGrid1.Tables[1];
                        grid2.DataBind();

                        grid3.DataSource = DSGrid1.Tables[0];
                        grid3.DataBind();

                        txtMOLDNAME.Text = CModule.ToString(DSGrid1.Tables[2].Rows[0]["MOLDNAME"]);
                        txtRPLOTNO.Text = CModule.ToString(DSGrid1.Tables[2].Rows[0]["RP_LotNo"]);
                        CBO_CLEAN.Text = CModule.ToString(DSGrid1.Tables[2].Rows[0]["CODENAME"]);
                        txtETC.Text = CModule.ToString(DSGrid1.Tables[2].Rows[0]["RP_MEMO"]);
                    }
                }
                else
                {

                }
            }
            catch
            {

            }

        }
    }
}
