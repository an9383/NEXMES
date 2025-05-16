#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM750
//   Form Name    : 자재 재고실사 조정
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using WIZ.Forms;
#endregion

namespace WIZ.MM
{
    public partial class MM0750 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable dtGrid = new DataTable();

        DataTable dtExcelImport;

        string sWhCode = string.Empty;

        #endregion

        #region < CONSTRUCTOR >
        public MM0750()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM EVENT >
        private void MM0750_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BARCODE", "LOTNO", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "전산수량", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGQTY", "실사수량", false, GridColDataType_emu.VarChar, 100, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "실사반영사유", false, GridColDataType_emu.VarChar, 350, true, true);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "STOCKQTY", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "REMARK", Infragistics.Win.HAlign.Left);

            grid1.DisplayLayout.Bands[0].Columns["STOCKQTY"].Format = "#,##0";
            grid1.DisplayLayout.Bands[0].Columns["TAKINGQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX SETTING >

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode.Value = LoginInfo.PlantCode;

            GetTakingOrdNo();

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// 조회
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (Convert.ToString(cboTakingOrdNo.Value) == "")
                {
                    this.ShowDialog(Common.getLangText("실사지시번호를 선택한 후 조회하세요."), DialogForm.DialogType.OK);
                    return;
                }

                base.DoInquire();

                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sTakingOrdNo = Convert.ToString(cboTakingOrdNo.Value);

                dtGrid = helper.FillTable("USP_MM0750_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (dtGrid.Rows.Count > 0)
                    {
                        grid1.DataBinds(dtGrid);
                        grid1.DataSource = dtGrid;
                    }
                    else
                    {
                        this.ShowDialog("조회할 데이터가 없습니다.", DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }

        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoSave();

                string sTakingOrdNo = Convert.ToString(cboTakingOrdNo.Value);

                if (this.ShowDialog("변경된 사항을 저장하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
                    return;

                foreach (DataRow drRow in dtGrid.Rows)
                {
                    helper.ExecuteNoneQuery("USP_MM0750_I1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_LOTNO", Convert.ToString(drRow["BARCODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_STOCKQTY", Convert.ToString(drRow["STOCKQTY"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_TAKINGQTY", Convert.ToString(drRow["TAKINGQTY"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_UNITCODE", Convert.ToString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_REMARK", Convert.ToString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                }

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    helper.Rollback();
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
                DoInquire();
            }
        }
        #endregion

        #region < USER METHOD AREA >

        public void GetTakingOrdNo()
        {
            DBHelper helper = new DBHelper(false);
            DataTable dtTemp = new DataTable();

            try
            {
                dtTemp = helper.FillTable("USP_MM0750_S2", CommandType.StoredProcedure);

                if (helper.RSCODE == "S")
                {
                    if (dtTemp.Rows.Count > 0)
                    {
                        WIZ.Common.FillComboboxMaster(cboTakingOrdNo, dtTemp, dtTemp.Columns["CODE_ID"].ColumnName, dtTemp.Columns["CODE_ID"].ColumnName, "", "");
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    return;
                }

                helper.Close();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        private DataTable GetExcel(string sFilePath)
        {
            string oledbConnStr = string.Empty;

            if (sFilePath.IndexOf(".xlsx") > -1)
            {
                // 엑셀 2007 이상
                oledbConnStr = "Provider=Microsoft.JET.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 12.0';HDR=NO;IMEX=1'";
            }
            else
            {
                // 엑셀 2003 및 이하 버전
                //oledbConnStr = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties=\"Excel 8.0\"";
                oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            }

            DataTable dtExcel = null;
            OleDbDataAdapter adt = null;

            using (OleDbConnection con = new OleDbConnection(oledbConnStr))
            {
                con.Open();

                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = dt.Rows[0]["TABLE_NAME"].ToString();             //엑셀 첫 번째 시트명
                string sQuery = string.Format(" SELECT * FROM [{0}] ", sheetName);  //조회 쿼리

                dtExcel = new DataTable();
                adt = new OleDbDataAdapter(sQuery, con);
                adt.Fill(dtExcel);
            }

            return dtExcel;
        }

        #endregion

        #region < EVENT AREA >

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            string sPlantCode = Convert.ToString(cboPlantCode.Value);

            try
            {
                if (Convert.ToString(cboTakingOrdNo.Value) == "")
                {
                    this.ShowDialog("실사지시번호를 선택하세요.", DialogForm.DialogType.OK);
                    return;
                }

                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "EXCEL|*.xls|ALL|*.*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //엑셀 파일 READ
                    dtExcelImport = GetExcel(openfiledialog.FileName);

                    //대상 GRID DataTable 복사(구조o, 데이터x)
                    //DataTable dtTarget = ((DataTable)this.grid1.DataSource).Clone();
                    DataTable dtTarget = new DataTable();

                    dtTarget.Columns.Add("PLANTCODE");
                    dtTarget.Columns.Add("BARCODE");
                    dtTarget.Columns.Add("ITEMCODE");
                    dtTarget.Columns.Add("ITEMNAME");
                    dtTarget.Columns.Add("UNITCODE");
                    dtTarget.Columns.Add("STOCKQTY");
                    dtTarget.Columns.Add("TAKINGQTY");
                    dtTarget.Columns.Add("REMARK");

                    //엑셀파일에서 READ 된 DataTable로 등록할 데이터 DataTable에 저장
                    for (int i = 1; i < dtExcelImport.Rows.Count; i++)
                    {

                        DataRow drTarget = dtTarget.NewRow();

                        rtnDtTemp = helper.FillTable("USP_MM0750_S4"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_BARCODE", Convert.ToString(dtExcelImport.Rows[i][1]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE != "S")
                        {
                            ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                            return;
                        }

                        drTarget["PLANTCODE"] = rtnDtTemp.Rows[0]["PLANTCODE"];
                        drTarget["BARCODE"] = rtnDtTemp.Rows[0]["LOTNO"];
                        drTarget["ITEMCODE"] = rtnDtTemp.Rows[0]["ITEMCODE"];
                        drTarget["ITEMNAME"] = rtnDtTemp.Rows[0]["ITEMNAME"];
                        drTarget["UNITCODE"] = rtnDtTemp.Rows[0]["UNITCODE"];
                        drTarget["STOCKQTY"] = rtnDtTemp.Rows[0]["STOCKQTY"];
                        drTarget["TAKINGQTY"] = Convert.ToString(dtExcelImport.Rows[i][6]);
                        drTarget["REMARK"] = Convert.ToString(dtExcelImport.Rows[i][7]);

                        dtTarget.Rows.Add(drTarget);

                    }

                    grid1.DataSource = dtTarget;
                    grid1.DataBind();
                    dtGrid = dtTarget;
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        private void btnSheetDownload_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0)
            {
                this.ShowDialog("데이터를 조회 한 후 시도하세요.", DialogForm.DialogType.OK);
                return;
            }

            _GridUtil.ExportExcel(this.grid1);
        }

        private void cboTakingOrdNo_ValueChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            if (Convert.ToString(cboTakingOrdNo.Value) == "")
            {
                txtPlantCode.Text = "";
                txtTakingOrdNo.Text = "";
                txtTakingOrdDate.Text = "";
                txtTakingOrdRemark.Text = "";
                return;
            }

            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0750_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", Convert.ToString(cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TAKINGORDNO", Convert.ToString(cboTakingOrdNo.Value), DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    txtPlantCode.Text = Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]);
                    txtTakingOrdNo.Text = Convert.ToString(rtnDtTemp.Rows[0]["TAKINGORDNO"]);
                    txtTakingOrdDate.Text = Convert.ToString(rtnDtTemp.Rows[0]["TAKINGORDDATE"]);
                    txtTakingOrdRemark.Text = Convert.ToString(rtnDtTemp.Rows[0]["TAKINGORDREMARK"]);
                    txtWhCode.Text = "[" + Convert.ToString(rtnDtTemp.Rows[0]["WHCODE"]) + "] " + Convert.ToString(rtnDtTemp.Rows[0]["WHNAME"]);

                    sWhCode = Convert.ToString(rtnDtTemp.Rows[0]["WHCODE"]);
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        #endregion
    }
}
