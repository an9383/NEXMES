#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0000_POP
//   Form Name    : 코드마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-26
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 코드마스터 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion


namespace WIZ.MD
{
    public partial class MD0050_POP2 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataSet dataset = new DataSet();
        DataTable dT = new DataTable();
        Common _Common = new Common();

        int cal = 0;
        int minus = 0;

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        #endregion

        #region < CONSTRUCTOR >

        public MD0050_POP2()
        {
            InitializeComponent();
            cbo_STARTDATE_H.Value = DateTime.Today.ToString("yyyy-MM-dd");
            cbo_GUBUN.Items.Add("입고");
            cbo_GUBUN.Items.Add("출고");
            cbo_GUBUN.Text = "입고";
        }
        #endregion

        #region < METHOD AREA >

        #endregion

        #region < EVENT AREA >

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                if (txtCAUSE.Text == "")
                {
                    MessageBox.Show("불출사유를 입력해주세요.");
                }
                else
                {
                    dataset = helper.FillDataSet("USP_MD0050_POP2_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_CORECODE", Convert.ToString(grid1.ActiveRow.Cells["Core_Code"].Value), DbType.String, ParameterDirection.Input));

                    minus = Convert.ToInt32(txtCNT.Text);
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
                                , helper.CreateParameter("AS_EX_Type", '1', DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_EX_ETC1", txtCAUSE.Text, DbType.String, ParameterDirection.Input));
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
                                , helper.CreateParameter("AS_EX_Type", '1', DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_EX_ETC1", txtCAUSE.Text, DbType.String, ParameterDirection.Input));

                            minus -= Convert.ToInt32(dataset.Tables[1].Rows[j]["IO_NOWCNT"]);
                        }
                    }
                    helper.Commit();
                    this.Close();
                }
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

        private void MD0050_POP2_Load(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                txtUSER.Text = LoginInfo.UserID;

                _GridUtil.InitializeGrid(this.grid1);

                _GridUtil.InitColumnUltraGrid(grid1, "Core_Code", "코어코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "업체명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "Core_CoreName", "코어명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CORE_CHASU", "차수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "NOWCNT", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                dataset = helper.FillDataSet("USP_MD0050_POP2_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_CORECODE", "", DbType.String, ParameterDirection.Input));

                grid1.DataSource = dataset.Tables[0];
                grid1.DataBind();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            cbo_MOLDNAME.Items.Clear();

            try
            {
                txtCORECODE.Text = CModule.ToString(grid1.ActiveRow.Cells["Core_Code"].Value);
                txtCORENAME.Text = CModule.ToString(grid1.ActiveRow.Cells["Core_CoreName"].Value);
                txtDEGREE.Text = CModule.ToString(grid1.ActiveRow.Cells["Core_Chasu"].Value);

                dataset = helper.FillDataSet("USP_MD0050_POP2_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_CORECODE", txtCORECODE.Text, DbType.String, ParameterDirection.Input));

                for (int i = 0; i < dataset.Tables[1].Rows.Count; i++)
                {
                    cbo_MOLDNAME.Items.Add(dataset.Tables[1].Rows[i]["MOLDNAME"]);
                }
            }
            catch
            {

            }
        }
    }
}
