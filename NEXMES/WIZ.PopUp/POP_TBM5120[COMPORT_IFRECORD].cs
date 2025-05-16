using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;


namespace WIZ.PopUp
{
    public partial class POP_TBM5120 : WIZ.Forms.BasePopupForm
    {
        string[] argument;

        #region ▶ 선언자         
        UltraGridUtil _GridUtil = new UltraGridUtil();
        PopUp_Biz _biz = new PopUp_Biz();
        Common _Common = new Common();

        DataTable _DtTemp = new DataTable();
        DataTable rtnDtTemp = new DataTable();
        private string plantCode = string.Empty; //plantcode default 설정

        string ls_custcode = string.Empty;
        string ls_custname = string.Empty;
        string ls_useflag = string.Empty;
        #endregion

        public POP_TBM5120(string DaPointCode, string DaPointName)
        {
            InitializeComponent();
            this.plantCode = CModule.GetAppSetting("Site", "10");
            this.txtDaPointCode.Text = DaPointCode;
            this.txtDaPointName.Text = DaPointName;

        }

        private void POP_TBM5120_Load(object sender, EventArgs e)
        {
            //--사용여부
            GridInit();
            BizGridManager bizGrid = new BizGridManager(Grid1);
            bizGrid.PopUpAdd("IFDATAID", "IFDATANAME", "TBM6400", new string[] { "", "" }); //IFDATAID
            bizGrid.PopUpAdd("MEASUREEQUID", "MEASUREEQUNAME", "TBM6320", new string[] { "", "" }); // 측정기
            DoFind();
        }

        private void GridInit()
        {
            try
            {
                _GridUtil.InitializeGrid(this.Grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(Grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "DAPOINTID", "DAPOINTID", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "DAPOINTNAME", "DAPOINTNAME", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "COMPORT", "COMPORT", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "CHANNEL", "CHANNEL", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "BAUDRATE", "통신속도", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "DATABIT", "DATABIT", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "PARITYBIT", "PARITYBIT", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "STOPBIT", "STOPBIT", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "IFDATAID", "IFRECORDID", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "IFDATANAME", "IFRECORDNAME", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "MEASUREEQUID", "측정기", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "MEASUREEQUNAME", "측정기명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime24, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(Grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(Grid1);

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


                rtnDtTemp = _Common.GET_BM0000_CODE("STOPBIT");  //STOPBIT
                WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "STOPBIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("PARITYBIT");  //PARITYBIT
                WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "PARITYBIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("BAUDRATE");  //BAUDRATE
                WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "BAUDRATE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            }
            catch
            {
            }
        }



        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(plantCode);
                string sDaDAtaid = DBHelper.nvlString(this.txtDaPointCode.Text);
                Grid1.DataSource = helper.FillTable("USP_POP_TBM5120_S1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DAPOINTID", sDaDAtaid, DbType.String, ParameterDirection.Input));
                Grid1.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void txtCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DoFind();
            }
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DoFind();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.Grid1.InsertRow();

            if (Grid1.Rows.Count > 1)
            {
                int iRows = Grid1.ActiveRow.Index;

                Grid1.SetDefaultValue("PLANTCODE", Grid1.Rows[iRows - 1].Cells["PLANTCODE"].Value.ToString());
                Grid1.SetDefaultValue("DAPOINTID", this.txtDaPointCode.Text);
            }
            else
            {
                Grid1.SetDefaultValue("PLANTCODE", this.plantCode);
                Grid1.SetDefaultValue("DAPOINTID", this.txtDaPointCode.Text);
            }
            Grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            Grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            Grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
            Grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Grid1.Rows.Count == 0) return;
            for (int i = 0; i < this.Grid1.Rows.Count; i++)
            {
                if (this.Grid1.Rows[i].Cells["COMPORT"].Value.ToString() == "")
                {
                    MessageBox.Show("COMPORT 는 필수 입력항목 입니다.");
                    this.Grid1.Rows[i].Activated = true;
                    return;
                }
                else if (this.Grid1.Rows[i].Cells["CHANNEL"].Value.ToString() == "")
                {
                    MessageBox.Show("CHANNEL 은 필수 입력항목 입니다.");
                    this.Grid1.Rows[i].Activated = true;
                    return;
                }
            }

            Grid1.UpdateData();
            DataTable dt = Grid1.chkChange();
            if (dt == null)
                return;
            DialogResult result = MessageBox.Show("해당 COMPORT 정보를 등록하시겠습니까?", "COMPORT 등록", MessageBoxButtons.YesNo);
            if (result.ToString().ToUpper() == "NO") return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                string sPlantCode = string.Empty;
                string sItemCode = string.Empty;


                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_POP_TBM5120_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DAPOINTID", Convert.ToString(drRow["DAPOINTID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_COMPORT", Convert.ToString(drRow["COMPORT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CHANNEL", Convert.ToString(drRow["CHANNEL"]), DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_POP_TBM5120_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DAPOINTID", Convert.ToString(drRow["DAPOINTID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_COMPORT", Convert.ToString(drRow["COMPORT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CHANNEL", Convert.ToString(drRow["CHANNEL"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BAUDRATE", Convert.ToString(drRow["BAUDRATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DATABIT", Convert.ToString(drRow["DATABIT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PARITYBIT", Convert.ToString(drRow["PARITYBIT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPBIT", Convert.ToString(drRow["STOPBIT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_IFDATAID", Convert.ToString(drRow["IFDATAID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                   );
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_POP_TBM5120_U1", CommandType.StoredProcedure, false, true
                                                    , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DAPOINTID", Convert.ToString(drRow["DAPOINTID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_COMPORT", Convert.ToString(drRow["COMPORT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CHANNEL", Convert.ToString(drRow["CHANNEL"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BAUDRATE", Convert.ToString(drRow["BAUDRATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DATABIT", Convert.ToString(drRow["DATABIT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_PARITYBIT", Convert.ToString(drRow["PARITYBIT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_STOPBIT", Convert.ToString(drRow["STOPBIT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_IFDATAID", Convert.ToString(drRow["IFDATAID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MEASUREEQUID", Convert.ToString(drRow["MEASUREEQUID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                    );
                            #endregion
                            break;
                    }
                    Grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                Grid1.SetAcceptChanges();
                helper.Commit();
                // 데이터가 저장 되었습니다.
                MessageBox.Show("데이터가 저장되었습니다.");
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();

                throw ex;
            }
            finally
            {
                helper.Close();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Grid1.DeleteRow();
        }
    }
}
