#region < USING AREA >
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion
namespace WIZ.QM
{
    public partial class QM1600 : WIZ.Forms.BaseMDIChildForm
    {
        #region< MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();


        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region< CONSTRUCTOR >
        public QM1600()
        {
            InitializeComponent();
        }
        #endregion

        #region< FORM EVENT >
        private void QM1600_Load(object sender, EventArgs e)
        {
            #region ▶ GRID
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 250, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPTYPE", "검사주체", false, GridColDataType_emu.VarChar, 70, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHAR_NO", "측정항목", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "SPEC\r\n적용기준", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT01", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG01", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE01", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT02", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG02", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE02", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT03", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG03", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE03", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT04", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG04", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE04", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT05", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG05", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE05", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT06", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG06", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE06", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT07", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG07", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE07", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT08", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG08", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE08", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT09", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG09", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE09", "일시", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT10", "측정값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTOKNG10", "판정", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTDATE10", "일시", false, GridColDataType_emu.VarChar, 150, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "CHAR_NO", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECNOL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECLSL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECUSL", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT01", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT02", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT03", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT04", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT05", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT06", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT07", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT08", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT09", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "RESULT10", Infragistics.Win.HAlign.Right);

            string[] arrMerCol01 = { "RESULT01", "RESULTOKNG01", "RESULTDATE01" };
            string[] arrMerCol02 = { "RESULT02", "RESULTOKNG02", "RESULTDATE02" };
            string[] arrMerCol03 = { "RESULT03", "RESULTOKNG03", "RESULTDATE03" };
            string[] arrMerCol04 = { "RESULT04", "RESULTOKNG04", "RESULTDATE04" };
            string[] arrMerCol05 = { "RESULT05", "RESULTOKNG05", "RESULTDATE05" };
            string[] arrMerCol06 = { "RESULT06", "RESULTOKNG06", "RESULTDATE06" };
            string[] arrMerCol07 = { "RESULT07", "RESULTOKNG07", "RESULTDATE07" };
            string[] arrMerCol08 = { "RESULT08", "RESULTOKNG08", "RESULTDATE08" };
            string[] arrMerCol09 = { "RESULT09", "RESULTOKNG09", "RESULTDATE09" };
            string[] arrMerCol10 = { "RESULT10", "RESULTOKNG10", "RESULTDATE10" };

            _GridUtil.GridHeaderMerge(grid1, "A", "검사(1차)", arrMerCol01, null);
            _GridUtil.GridHeaderMerge(grid1, "B", "검사(2차)", arrMerCol02, null);
            _GridUtil.GridHeaderMerge(grid1, "C", "검사(3차)", arrMerCol03, null);
            _GridUtil.GridHeaderMerge(grid1, "D", "검사(4차)", arrMerCol04, null);
            _GridUtil.GridHeaderMerge(grid1, "E", "검사(5차)", arrMerCol05, null);
            _GridUtil.GridHeaderMerge(grid1, "F", "검사(6차)", arrMerCol06, null);
            _GridUtil.GridHeaderMerge(grid1, "G", "검사(7차)", arrMerCol07, null);
            _GridUtil.GridHeaderMerge(grid1, "H", "검사(8차)", arrMerCol08, null);
            _GridUtil.GridHeaderMerge(grid1, "I", "검사(9차)", arrMerCol09, null);
            _GridUtil.GridHeaderMerge(grid1, "J", "검사(10차)", arrMerCol10, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region --- Combobox & Popup Setting ---
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });

            cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;

            CboEndDate_H.Value = DateTime.Now;
            CboStartDate_H.Value = DateTime.Now.AddDays(-7);

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
            _GridUtil.SetInitUltraGridBind(grid1);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sItemCode = DBHelper.nvlString(txtItemCode_H.Text.Trim());
                string sStartDate = Convert.ToDateTime(CboStartDate_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = Convert.ToDateTime(CboEndDate_H.Value).ToString("yyyy-MM-dd");

                rtnDtTemp = helper.FillTable("USP_QM1600_S1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBind();
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                }

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG01"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG01"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG01"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG01"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG01"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG01"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG02"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG02"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG02"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG02"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG02"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG02"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG03"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG03"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG03"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG03"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG03"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG03"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG04"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG04"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG04"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG04"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG04"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG04"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG05"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG05"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG05"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG05"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG05"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG05"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG06"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG06"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG06"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG06"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG06"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG06"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG07"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG07"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG07"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG07"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG07"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG07"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG08"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG08"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG08"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG08"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG08"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG08"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG09"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG09"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG09"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG09"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG09"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG09"].Appearance.ForeColor = Color.White;
                    }

                    if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG10"].Value) == "NG")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG10"].Appearance.BackColor = Color.Red;
                        grid1.Rows[i].Cells["RESULTOKNG10"].Appearance.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grid1.Rows[i].Cells["RESULTOKNG10"].Value) == "OK")
                    {
                        grid1.Rows[i].Cells["RESULTOKNG10"].Appearance.BackColor = Color.ForestGreen;
                        grid1.Rows[i].Cells["RESULTOKNG10"].Appearance.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
            finally
            {
                this.ClosePrgForm();
                helper.Close();
            }

        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 클릭
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 클릭
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion
    }
}
