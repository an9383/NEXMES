using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP6150 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        #endregion

        #region < CONSTRUCTOR >
        public PP6150()
        {
            InitializeComponent();
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            //DBHelper helper = new DBHelper(false);
            //List<SqlParameter> sList = new List<SqlParameter>();
            DBHelper helper = new DBHelper(false);

            //if (txtItemCode.Text.Trim() == "") //2013-06-21 조회를 위해 백두산이 임시로 막음
            //{
            //    ShowDialog("C:I00003", Windows.Forms.DialogForm.DialogType.OK);
            //    CancelProcess = true;
            //    return;
            //}
            //if (txtLotNo.Text.Trim() == "")
            //{
            //    ShowDialog("C:I00010", Windows.Forms.DialogForm.DialogType.OK);
            //    CancelProcess = true;
            //    return;
            //}

            try
            {
                base.DoInquire();
                string ERCODE = string.Empty;
                string ERMSG = string.Empty;
                grid1.DataSource = helper.FillTable("USP_PP6100_" + ultraOptionSet1.CheckedItem.Tag.ToString(), CommandType.StoredProcedure//,ref ERCODE, ref ERMSG
                                                                                                              , helper.CreateParameter("pPlantCode", Convert.ToString(cboPlantCode_H.Value), DbType.String, ParameterDirection.Input)
                                                                                                              , helper.CreateParameter("pItemCode", Convert.ToString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
                                                                                                              , helper.CreateParameter("pLotNo", Convert.ToString(txtLotNo.Text), DbType.String, ParameterDirection.Input));


                grid1.DataBinds();



                //grid1.DataSource = MultiGridRelations(ds.Tables[0], true);
                //grid1.DataBinds();

                for (int i = 1; i < grid1.DisplayLayout.Bands.Count; i++)
                {
                    foreach (UltraGridColumn ugc in grid1.DisplayLayout.Bands[i].Columns)
                    {
                        if (ugc.Key.Contains("MultiGrid"))
                        {
                            ugc.Hidden = true;
                        }
                        else
                        {
                            ugc.Header.Caption = grid1.DisplayLayout.Bands[0].Columns[ugc.Key].Header.Caption;
                            ugc.Header.Appearance = grid1.DisplayLayout.Bands[0].Columns[ugc.Key].Header.Appearance;
                            ugc.CellAppearance = grid1.DisplayLayout.Bands[0].Columns[ugc.Key].CellAppearance;
                            ugc.Hidden = grid1.DisplayLayout.Bands[0].Columns[ugc.Key].Hidden;
                            ugc.CellActivation = Activation.NoEdit;
                        }
                    }
                    //grid1.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
                    grid1.DisplayLayout.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
                    grid1.DisplayLayout.Bands[i].ColHeadersVisible = false;
                }

                grid1.Rows.ExpandAll(true);
            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("선택한 폼의 정보를 찾을 수 없습니다.\r\n 관리자에게 문의하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);


                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void PP6150_Load(object sender, EventArgs e)
        {
            #region 그리드
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "RecDate", "일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "LOTNO", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotQty", "생산수량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InPlantCode", "투입공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InItemCode", "투입품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InItemName", "투입품목명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InLotNo", "투입 Lot", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InLotQty", "투입 수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "일시", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Company", "공급처", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WLot", "자재LOT", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LEVEL", "LEVEL", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORTCOL", "정렬", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PARSORTCOL", "정렬1", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            //gridRowSelectorColor = this.grid1.DisplayLayout.Override.RowSelectorAppearance.BackColor;

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion

            #region 팝업 설정

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            #endregion
        }

        public static DataSet MultiGridRelations(DataTable DtTemp, bool Relations)
        {
            DataSet set = new DataSet();
            int level = 1;

            for (int i = 1; i < DtTemp.Rows.Count; i++)
            {
                if (level < Convert.ToInt32(DtTemp.Rows[i]["LEVEL"]))
                {
                    level = Convert.ToInt32(DtTemp.Rows[i]["LEVEL"]);
                }
            }

            DataTable[] tableArray = new DataTable[level];

            for (int j = 0; j < tableArray.Length; j++)
            {
                tableArray[j] = DtTemp.Clone();

                foreach (DataRow row in DtTemp.Select("LEVEL= '" + (j + 1) + "'"))
                {
                    tableArray[j].ImportRow(row);
                    tableArray[j].TableName = j.ToString();
                }

                set.Tables.Add(tableArray[j]);
            }

            int relation = level - 1;

            for (int k = 0; k < level; k++)
            {
                if (relation != k)
                {
                    set.Relations.Add("MultiGrid" + k, set.Tables[k].Columns["SORTCOL"], set.Tables[k + 1].Columns["PARSORTCOL"], Relations);
                }
            }

            return set;
        }

        #endregion

        #region <METHOD AREA>

        #endregion
    }
}
