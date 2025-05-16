using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.MM
{
    public partial class MM9900 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        private string sPlant = string.Empty;
        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();

        private string plantCode = string.Empty;

        #endregion

        #region [ 생성자 ]
        public MM9900()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Form Load ]
        private void MM9900_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "업무구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTNAME", "업무구분", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CLOSEYEAR", "마감년도", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CLOSEMONTH", "마감월", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CLOSEDATE", "마감일자", true, GridColDataType_emu.YearMonthDay, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region [ ComboBox Setting ]
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DEPTCODE");
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("MONTH");
            WIZ.Common.FillComboboxMaster(this.cboCloseMonth, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_ID"].ColumnName, "ALL", "");

            #endregion

            plantCode = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.Value = plantCode;
        }

        #endregion

        #region [ Tool Bar Area ]
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sDeptCode = Convert.ToString(this.cboDeptCode.Value);
                string sCloseYear = Convert.ToString(this.cboCloseYear.Value);
                string sCloseMonth = Convert.ToString(this.cboCloseMonth.Value);

                base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_MM9900_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@CLOSEYEAR", sCloseYear, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@CLOSEMONTH", sCloseMonth, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();

                        grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid1.DisplayLayout.Bands[0].Columns["DEPTCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid1.DisplayLayout.Bands[0].Columns["DEPTNAME"].MergedCellStyle = MergedCellStyle.Always;
                        grid1.DisplayLayout.Bands[0].Columns["CLOSEYEAR"].MergedCellStyle = MergedCellStyle.Always;


                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            if (Convert.ToString(grid1.Rows[i].Cells["DEPTCODE"].Value) != "MM")
                            {
                                //자재관리가 아닐 경우 일자 변경 안되도록..
                                //grid1.DisplayLayout.Bands[0].Columns["CLOSEDATE"].CellActivation = Activation.NoEdit;
                                grid1.Rows[i].Cells["CLOSEDATE"].Activation = Activation.NoEdit;
                            }
                            else
                            {
                                grid1.Rows[i].Cells["CLOSEDATE"].Activation = Activation.AllowEdit;
                            }
                        }
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }

        }

        public override void DoDelete()
        {
            base.DoDelete();

            DBHelper helper = new DBHelper(false);

            try
            {
                if (grid1.Rows.Count == 0) return;

                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sDeptCode = "MM";
                string sCloseYear = Convert.ToString(DateTime.Now.Year);
                string sCloseMonth = Convert.ToString(DateTime.Now.Month);


                DialogResult result = this.ShowDialog(sCloseYear + "년" + sCloseMonth + "월 이후의 마감일자 정보를 모두 삭제하시겠습니까?", Forms.DialogForm.DialogType.YESNO);

                if (result.ToString().ToUpper() == "OK")
                {
                    helper.ExecuteNoneQuery("USP_MM9900_D1"
                                           , CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("@DEPTCODE", sDeptCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("@NOWYEAR", sCloseYear, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("@NOWMONTH", sCloseMonth, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        this.DoInquire();
                    }
                    else if (helper.RSMSG == "E")
                    {
                        helper.Rollback();
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }

        }

        public override void DoSave()
        {
            base.DoSave();


            DBHelper helper = new DBHelper(false);

            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;

            try
            {
                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:


                            helper.ExecuteNoneQuery("USP_MM9900_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@DEPTCODE", Convert.ToString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@CLOSEYEAR", Convert.ToString(drRow["CLOSEYEAR"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@CLOSEMONTH", Convert.ToString(drRow["CLOSEMONTH"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@CLOSEDATE", Convert.ToString(drRow["CLOSEDATE"]).Substring(0, 10), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            break;
                    }
                }

                helper.Commit();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion



        #region [ User Method Area ]
        private void ComboBoxCloseYear()
        {
            DBHelper helper = new DBHelper(false);

            string sPlantCode = string.Empty;
            string sDeptCode = string.Empty;

            try
            {
                sPlantCode = Convert.ToString(cboPlantCode_H.Value);

                DataTable dtComboBox = helper.FillTable("USP_MM9900_S2", CommandType.StoredProcedure
                                                               , helper.CreateParameter("@PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                               , helper.CreateParameter("@DEPTCODE", "MM", DbType.String, ParameterDirection.Input));

                WIZ.Common.FillComboboxMaster(this.cboCloseYear, dtComboBox, dtComboBox.Columns["CLOSEYEAR"].ColumnName, dtComboBox.Columns["CLOSEYEAR"].ColumnName, "ALL", "");

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region [ Event Area ]
        /// <summary>
        /// 공장 변경 시 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPlantCode_H_ValueChanged(object sender, EventArgs e)
        {
            ComboBoxCloseYear();
        }

        /// <summary>
        /// 날짜변경 시 달의 이전 일자는 선택불가...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            string sCloseYear = string.Empty;
            string sCloseMonth = string.Empty;
            string sCloseYearMonth = string.Empty;
            string sCloseDate = string.Empty;

            if (e.Cell.Column.ToString() == "CLOSEDATE")
            {
                grid1.UpdateData();

                sCloseYear = Convert.ToString(grid1.ActiveRow.Cells["CLOSEYEAR"].Value);               //YYYY
                sCloseMonth = Convert.ToString(grid1.ActiveRow.Cells["CLOSEMONTH"].Value);              //MM
                sCloseYearMonth = sCloseYear + sCloseMonth;                                                 //YYYYMM
                sCloseDate = Convert.ToString(e.Cell.Value).Substring(0, 8).Replace("-", "");               //YYYYMM

                if (Convert.ToInt32(sCloseYearMonth) > Convert.ToInt32(sCloseDate))
                {
                    //기준 년 월보다 선택된 날짜가 이전일 경우..
                    this.ShowDialog(sCloseYear + "년" + sCloseMonth + "월의 이전 날짜는 선택할 수 없습니다.", Forms.DialogForm.DialogType.OK);
                    e.Cell.Value = e.Cell.OriginalValue;
                    return;
                }
            }

        }
        #endregion

        private void btnEndDate_Click(object sender, EventArgs e)
        {
            string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
            string sDeptCode = "MM";

            POP_MM9900 POP_MM9900 = new POP_MM9900(sPlantCode, sDeptCode);
            POP_MM9900.ShowDialog();
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("DEPTCODE", "CLOSEYEAR");
            e.Layout.Bands[0].Columns["CLOSEYEAR"].MergedCellEvaluator = CM1;
        }

        /// <summary>
        /// 커스텀 머지..
        /// </summary>
        public class CustomMergedCellEvalutor : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            string Col1 = string.Empty;
            string Col2 = string.Empty;

            public CustomMergedCellEvalutor(string pCol1, string pCol2)
            {
                Col1 = pCol1;
                Col2 = pCol2;
            }

            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1,
                                      Infragistics.Win.UltraWinGrid.UltraGridRow row2,
                                      Infragistics.Win.UltraWinGrid.UltraGridColumn col)
            {
                try
                {
                    if (row1.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                        && row2.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                        && row1.GetCellValue(Col2).GetType().ToString() != "System.DBNull"
                        && row2.GetCellValue(Col2).GetType().ToString() != "System.DBNull")
                    {
                        string value1 = (string)row1.GetCellValue(Col1);
                        string value2 = (string)row2.GetCellValue(Col1);

                        string value3 = (string)row1.GetCellValue(Col2);
                        string value4 = (string)row2.GetCellValue(Col2);

                        return (value1 + value3) == (value2 + value4);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Appearance.BackColor = Color.White;
        }
    }
}
