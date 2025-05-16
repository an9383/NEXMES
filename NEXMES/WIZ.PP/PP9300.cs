#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    using System.Configuration;

    public partial class PP9300 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        string sPlantCode = string.Empty;
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion

        #region<CONSTRUCTOR>

        public PP9300()
        {
            InitializeComponent();
        }
        #endregion

        #region <PP9300_Load >
        private void PP9300_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DeptCode", "팀구분", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "minorcode", "비가동구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "codename", "구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;


            grid1.Columns["DeptCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["DeptCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["DeptCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OPCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OPCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OPCODE"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["OPNAME"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["OPNAME"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["OPNAME"].MergedCellStyle = MergedCellStyle.Always;
            #endregion

            #region --- ComboBox Setting ---
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

            sPlantCode = CModule.GetAppSetting("Site", "10");

            cboPlantCode_H.Value = sPlantCode;
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString();
                string sDeptCode = cboDeptCode.Value.ToString();
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sOPCode = this.txtOPCode.Text.Trim();

                DataTable rtnDtTemp = helper.FillTable("USP_PP9300_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("WORKDATETO", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PARAM1", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PARAM2", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PARAM3", "", DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();

                if (rtnDtTemp != null)
                {

                    for (int i = 6; i < rtnDtTemp.Columns.Count; i++)
                    {
                        MessageBox.Show(rtnDtTemp.Columns[i].ToString());
                        _GridUtil.InitColumnUltraGrid(grid1, rtnDtTemp.Columns[i].ToString(), rtnDtTemp.Columns[i].ToString(), false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "0.0#", null, null, null, null);
                    }
                    //sInspDate + " " + sInspDN
                    // 추가 되어야 함.

                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }

                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("PlantCode", typeof(System.String));
                    dt.Columns.Add("DeptCode", typeof(System.String));
                    dt.Columns.Add("OPCODE", typeof(System.String));
                    dt.Columns.Add("OPNAME", typeof(System.String));
                    dt.Columns.Add("minorcode", typeof(System.String));
                    dt.Columns.Add("codename", typeof(System.String));
                    grid1.DataSource = dt;
                    grid1.DataBinds();
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

        #region < METHOD AREA >
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "StopSum" });
        }
        #endregion
    }
}
