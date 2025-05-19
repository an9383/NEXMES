using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;

namespace WIZ.Control
{
    public partial class GridSetUpForm : Form
    {
        private string[] sListNumerType = new string[] { "STRING", "INT", "INTEGER", "INT32", "INT64", "LONG", "DOUBLE", "FLOAT", "DECIMAL", "UNIT", "ULONG", "SHORT", "USHORT", "NUMERIC" };
        UltraGridUtil _GridUtil = new UltraGridUtil();

        public WIZ.Control.Grid grid = null;

        public string sScreenID;
        public string sUserID;
        public string sGridID;
        public GridSetUpForm(WIZ.Control.Grid g)
        {
            InitializeComponent();

            grid = g;

            SetInit();
        }

        private void SetInit()
        {
            _GridUtil.InitializeGrid(grid1, false, true, true, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "COL_KEY", "컬럼_KEY", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COL_NAME", "컬럼 기본명", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COL_CHGNAME", "현재 컬럼명", false, GridColDataType_emu.VarChar, 130, 0, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "COL_TYPE", "데이터타입", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "GROUP_SUM", "부분합계", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTAL_SUM", "합계", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ALIGN", "정렬", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "HIDDEN", "숨기기", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);

            _GridUtil.SetInitUltraGridBind(grid1);

            DataTable rtnDtTemp = new DataTable();
            rtnDtTemp.Columns.Add("CODE_ID", typeof(string));
            rtnDtTemp.Columns.Add("CODE_NAME", typeof(string));

            rtnDtTemp.Rows.Add(new string[] { "Left", "왼쪽 정렬" });
            rtnDtTemp.Rows.Add(new string[] { "Center", "가운데 정렬" });
            rtnDtTemp.Rows.Add(new string[] { "Right", "오른쪽 정렬" });

            UltraGridUtil.SetComboUltraGrid(this.grid1, "ALIGN", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp.Rows.Clear();

            rtnDtTemp.Rows.Add(new string[] { "True", "숨기기" });
            rtnDtTemp.Rows.Add(new string[] { "False", "보이기" });

            UltraGridUtil.SetComboUltraGrid(this.grid1, "HIDDEN", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp.Rows.Clear();
            rtnDtTemp.Rows.Add(new string[] { "", "" });

            for (int i = 0; i < grid.sListColumnsUse.Count; i++)
            {
                if (!(grid.Columns.Exists(grid.sListColumnsUse[i].key)))
                {
                    continue;
                }

                UltraGridColumn uc = grid.Columns[grid.sListColumnsUse[i].key];

                rtnDtTemp.Rows.Add(new string[] { uc.Key, grid.sListColumnsUse[i].name });
            }

            UltraGridUtil.SetComboUltraGrid(this.grid1, "GROUP_SUM", rtnDtTemp, "CODE_ID", "CODE_NAME");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "TOTAL_SUM", rtnDtTemp, "CODE_ID", "CODE_NAME");
        }

        public void SetData()
        {
            txtGridID.Text = sGridID;
            txtScreenID.Text = sScreenID;
            txtLoginID.Text = sUserID;

            DoInquire();
        }

        private void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            for (int i = 0; i < grid.sListColumnsUse.Count; i++)
            {
                if (!(grid.Columns.Exists(grid.sListColumnsUse[i].key)))
                {
                    continue;
                }

                UltraGridColumn uc = grid.Columns[grid.sListColumnsUse[i].key];

                grid1.InsertRow();

                grid1.ActiveRow.Cells["COL_KEY"].Value = uc.Key;
                grid1.ActiveRow.Cells["COL_NAME"].Value = grid.sListColumnsUse[i].name;
                grid1.ActiveRow.Cells["COL_TYPE"].Value = uc.DataType.Name;
                grid1.ActiveRow.Cells["ALIGN"].Value = grid.sListColumnsUse[i].align;
                grid1.ActiveRow.Cells["HIDDEN"].Value = grid.sListColumnsUse[i].Hidden;

                grid1.ActiveRow.Cells["COL_KEY"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["COL_NAME"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["COL_TYPE"].Activation = Activation.NoEdit;

                grid1.ActiveRow.Cells["GROUP_SUM"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["TOTAL_SUM"].Activation = Activation.AllowEdit;
            }

            // 조회
            // 
            DBHelper helper = new DBHelper();

            DataTable dtGrid = helper.FillTable("USP_ZA0003_S2", CommandType.StoredProcedure
                   , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_SCREEN_ID", sScreenID, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_USER_ID", sUserID, DbType.String, ParameterDirection.Input)
                   , helper.CreateParameter("AS_GRID_ID", sGridID, DbType.String, ParameterDirection.Input)
                   );

            if (dtGrid.Rows.Count > 0)
            {
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    string sCol = CModule.ToString(dtGrid.Rows[i]["COLKEY"]);

                    for (int j = 0; j < grid1.Rows.Count; j++)
                    {
                        if (CModule.ToString(grid1.Rows[j].Cells["COL_KEY"].Value) == sCol)
                        {
                            // 해당 컬럼의 정보가 있을 경우
                            grid1.Rows[j].Cells["COL_CHGNAME"].Value = CModule.ToString(dtGrid.Rows[i]["COL_NAME"]);
                            grid1.Rows[j].Cells["GROUP_SUM"].Value = CModule.ToString(dtGrid.Rows[i]["GROUP_SUM"]);
                            grid1.Rows[j].Cells["TOTAL_SUM"].Value = CModule.ToString(dtGrid.Rows[i]["TOTAL_SUM"]);
                            grid1.Rows[j].Cells["ALIGN"].Value = CModule.ToString(dtGrid.Rows[i]["ALIGN"]);
                            grid1.Rows[j].Cells["HIDDEN"].Value = CModule.ToString(dtGrid.Rows[i]["HIDDEN"]) == "Y";
                            grid1.Rows[j].Cells["REMARK"].Value = CModule.ToString(dtGrid.Rows[i]["REMARK"]);

                            break;
                        }
                    }
                }
            }
        }

        private void DoInit()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {

                helper.ExecuteNoneQuery("USP_ZA0003_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "D1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SCREEN_ID", sScreenID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER_ID", sUserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_GRID_ID", sGridID, DbType.String, ParameterDirection.Input)
                    );

                if (helper.RSCODE != "S")
                {
                    throw new Exception(helper.RSMSG);
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.Message);
            }

            // 삭제 후 재조회
            DoInquire();
        }

        private void DoSave()
        {
            // 저장 후 처리
            DBHelper helper = new DBHelper("", true);

            try
            {
                // 루프 타면서 처리
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    UltraGridRow ur = grid1.Rows[i];

                    helper.ExecuteNoneQuery("USP_ZA0003_S2", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PCODE", "I1", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_SCREEN_ID", sScreenID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_USER_ID", sUserID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_GRID_ID", sGridID, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_COLKEY", ur.Cells["COL_KEY"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_COLNAME", ur.Cells["COL_CHGNAME"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_GROUP_SUM", ur.Cells["GROUP_SUM"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TOTAL_SUM", ur.Cells["TOTAL_SUM"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_HIDDEN", CModule.ToString(ur.Cells["HIDDEN"].Value) == "True" ? "Y" : "N", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ALIGN", ur.Cells["ALIGN"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_REMARK", ur.Cells["REMARK"].Value, DbType.String, ParameterDirection.Input)
                        );

                    if (helper.RSCODE != "S")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                helper.Commit();

                SetGrid();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void SetGrid()
        {
            // 적용
            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                UltraGridRow ur = grid1.Rows[i];

                string sCol = CModule.ToString(ur.Cells["COL_KEY"].Value);

                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    if (CModule.ToString(grid.Columns[j].Key) == sCol)
                    {
                        grid.Columns[j].Header.Caption = CModule.ToString(ur.Cells["COL_CHGNAME"].Value).Trim() == "" ? CModule.ToString(ur.Cells["COL_NAME"].Value) : CModule.ToString(ur.Cells["COL_CHGNAME"].Value);
                        //ur.Cells["GROUP_SUM"].Value;
                        //ur.Cells["TOTAL_SUM"].Value;
                        switch (CModule.ToString(ur.Cells["ALIGN"].Value))
                        {
                            case "Left":
                                grid.Columns[j].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                                break;
                            case "Right":
                                grid.Columns[j].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                                break;
                            case "Center":
                                grid.Columns[j].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                                break;
                        }

                        grid.Columns[j].Hidden = CModule.ToString(ur.Cells["HIDDEN"].Value) == "True";

                        break;
                    }
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            DoInit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
