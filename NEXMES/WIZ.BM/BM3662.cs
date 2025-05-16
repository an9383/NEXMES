using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;

namespace WIZ.BM
{
    public partial class BM3662 : WIZ.Forms.BaseForm
    {
        public int iCount;

        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        public BM3662(string sPlantCode, string sOPCode, string sMachCode, string sInspCode)
        {
            InitializeComponent();

            txtPlantCode.Text = sPlantCode;
            txtOPCode.Text = sOPCode;
            txtMachCode.Text = sMachCode;
            txtInspCode.Text = sInspCode;

            grid1.Error += new ErrorEventHandler(grid1_Error);
        }

        void grid1_Error(object sender, ErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void BM3662_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1);

            grid1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            grid1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            grid1.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            grid1.AllowDrop = false;
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            _GridUtil.InitColumnUltraGrid(grid1, "Value1", "값", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Value2", "값", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Value3", "값", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Value4", "값", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Value5", "값", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            search();
        }

        private void search()
        {
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[4];
            try
            {
                DataSet ds;

                string sPlantCode = txtPlantCode.Text;  // 공장코드
                string sOPCode = txtOPCode.Text;      // 품목
                string sMachCode = txtMachCode.Text;
                string sInspCode = txtInspCode.Text;      // 검사항목

                param[0] = helper.CreateParameter("@pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@pOPCode", sOPCode, DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@pMachCode", sMachCode, DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@pInspCode", sInspCode, DbType.String, ParameterDirection.Input);

                ds = helper.FillDataSet("USP_BM3662_S1", CommandType.StoredProcedure, param);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            txtOPName.Text = DBHelper.nvlString(ds.Tables[i].Rows[0]["OPName"]);
                            txtMachName.Text = DBHelper.nvlString(ds.Tables[i].Rows[0]["MachName"]);
                            txtInspName.Text = DBHelper.nvlString(ds.Tables[i].Rows[0]["InspName"]);
                            txtPlantCode.Text = DBHelper.nvlString(ds.Tables[i].Rows[0]["PlantCode"]);
                            break;
                        case 1:
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Value1", Type.GetType("System.String"));
                            dt.Columns.Add("Value2", Type.GetType("System.String"));
                            dt.Columns.Add("Value3", Type.GetType("System.String"));
                            dt.Columns.Add("Value4", Type.GetType("System.String"));
                            dt.Columns.Add("Value5", Type.GetType("System.String"));

                            string[] iList = new string[25];

                            foreach (DataRow dr in ds.Tables[i].Rows)
                            {
                                int idx = DBHelper.nvlInt(dr["Seq"]);
                                string sValue = DBHelper.nvlString(dr["VALUE"]);

                                iList[idx] = sValue;
                            }

                            for (int j = 0; j < 25; j++)
                            {
                                int iRow = j / 5;
                                int iRem = j % 5;
                                if (iRem == 0)
                                {
                                    dt.Rows.Add(dt.NewRow());
                                }

                                dt.Rows[iRow][iRem] = DBHelper.nvlString(iList[j]);
                            }

                            dt.Rows[4][4] = "직접 입력";

                            grid1.DataSource = dt;
                            grid1.DataBinds();

                            grid1.Rows[4].Cells["Value5"].IgnoreRowColActivation = true;
                            grid1.Rows[4].Cells["Value5"].Activation = Activation.NoEdit;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void DoSave()
        {
            DataTable dt = (DataTable)grid1.DataSource;

            string sArrValue = "";

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string sValue = DBHelper.nvlString(dt.Rows[i][j]);

                    if (i == 4 && j == 4)
                        sArrValue += sValue;
                    else
                        sArrValue += sValue + "|";
                }
            }

            string sPlantCode = DBHelper.gGetCode(txtPlantCode.Text);
            string sOPCode = DBHelper.nvlString(txtOPCode.Text);
            string sMachCode = DBHelper.nvlString(txtMachCode.Text);
            string sInspCode = DBHelper.nvlString(txtInspCode.Text);

            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[10];

            try
            {
                param[0] = helper.CreateParameter("@pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@pOPCode", sOPCode, DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@pMachCode", sMachCode, DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@pInspCode", sInspCode, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@pValue", sArrValue, DbType.String, ParameterDirection.Input);
                param[5] = helper.CreateParameter("@pMaker", this.WorkerID, DbType.String, ParameterDirection.Input);
                param[6] = helper.CreateParameter("@pSeq1", "", DbType.String, ParameterDirection.Input);
                param[7] = helper.CreateParameter("@pSeq2", "", DbType.String, ParameterDirection.Input);
                param[8] = helper.CreateParameter("@pSeq3", "", DbType.String, ParameterDirection.Input);

                param[9] = helper.CreateParameter("@pRetValue", DbType.Int32, ParameterDirection.Output, null, 200);

                helper.ExecuteNoneQuery("USP_BM3662_U1", CommandType.StoredProcedure, param);

                iCount = DBHelper.nvlInt(param[9].Value);

                helper.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }
        }
    }
}
