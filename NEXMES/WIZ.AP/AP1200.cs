#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : AP1200                                                                                                                                                                        
//   Form Name    : 라인 작업 캘린더                                                                                                                                                                   
//   Name Space   : WIZ.AP                                                                                                                                                               
//   Created Date :                                                                                                                                                                     
//   Made By      : WIZ                                                                                                                                                 
//   Description  : 라인기준 작업 카렌다 생성 및 조회                                                                                                                                                                
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP1200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        // 변수나 Form에서 사용될 Class를 정의
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();

        #endregion

        #region < CONSTRUCTOR >
        public AP1200()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Event);
        }
        #endregion

        #region < FORM LOAD >
        private void AP1200_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "WRKDATE", "근무일자", true, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인코드", true, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WEEK", "요일", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "D1", "주간근무형태", true, GridColDataType_emu.VarChar, 120, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "D2", "주간근무", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "D3", "주간잔업", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "D4", "부하시간", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DHOLIDAY", "주간휴무여부", true, GridColDataType_emu.VarChar, 100, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "N1", "야간근무형태", true, GridColDataType_emu.VarChar, 120, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "N2", "야간근무", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "N3", "야간잔업", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "N4", "부하시간", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NHOLIDAY", "야간휴무여부", true, GridColDataType_emu.VarChar, 100, true, true);

            _GridUtil.SetColumnTextHAlign(grid1, "LINECODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "D1", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "D2", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "D3", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "D4", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "N1", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "N2", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "N3", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "N4", Infragistics.Win.HAlign.Right);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region < COMBOBOX SETTING >

            rtnDtTemp = _Common.GET_BM0050_CODE("");
            WIZ.Common.FillComboboxMaster(this.cboLineCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboLineCode_M, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요::", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LINECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE", "MINORCODE LIKE 'D%'");  //주간근무형태                                                                                                                        
            WIZ.Common.FillComboboxMaster(this.cboDay, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요::", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "D1", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE", "MINORCODE LIKE 'N%'");  //야간근무형태                                                                                                                        
            WIZ.Common.FillComboboxMaster(this.cboNight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요::", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "N1", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DHOLIDAY", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NHOLIDAY", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("WRKTYPECODE");        //근무형태코드                                                                                                                                                                                 
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WRKTYPECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            this.DataSelect();

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();


                rtnDtTemp = (DataTable)this.grid1.DataSource;

                for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                {
                    helper.ExecuteNoneQuery("USP_AP1200_I1", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_WRKDATE", Convert.ToString(rtnDtTemp.Rows[i]["WRKDATE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_LINECODE", Convert.ToString(rtnDtTemp.Rows[i]["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_WEEK", Convert.ToString(rtnDtTemp.Rows[i]["WEEK"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DWRKTYPECODE", Convert.ToString(rtnDtTemp.Rows[i]["D1"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DHOLIDAY", Convert.ToString(rtnDtTemp.Rows[i]["DHOLIDAY"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_NWRKTYPECODE", Convert.ToString(rtnDtTemp.Rows[i]["N1"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_NHOLIDAY", Convert.ToString(rtnDtTemp.Rows[i]["NHOLIDAY"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_Maker", this.WorkerID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    helper.ExecuteNoneQuery("USP_AP1250_I1", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_WRKDATE", Convert.ToString(rtnDtTemp.Rows[i]["WRKDATE"]), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_LINECODE", Convert.ToString(rtnDtTemp.Rows[i]["LINECODE"]), DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }

                helper.Commit();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void btn_Create_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);

                if (cboLineCode_M.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("라인 정보를 선택하세요", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (cboDay.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("주간 근무 형태를 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (cboNight.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("야간 근무 형태를 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                string sMonth = string.Format("{0:yyyy-MM}", this.dtSMonth_M.Value);
                string sLineCode = cboLineCode_M.Value.ToString();
                string sDay = cboDay.Value.ToString();
                string sNight = cboNight.Value.ToString();

                rtnDtTemp = helper.FillTable("USP_AP1200_S2", CommandType.StoredProcedure
                                 , helper.CreateParameter("V_MONTH", sMonth, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("V_LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("V_DAY", sDay, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("V_NIGHT", sNight, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
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


        private void grid1_CellListSelect(object sender, CellEventArgs e)
        {
            //그리드 내 근무형태 변경시 해당 근무형태 값으로 셋팅
            if ((this.grid1.Rows.Count == 0) || (this.grid1.ActiveCell == null)) { return; }

            DBHelper helper = new DBHelper(false);

            StringBuilder query = new StringBuilder();

            try
            {
                // 선택 데이터 그리드 업데이트
                grid1.UpdateData();

                string sColumnName = this.grid1.ActiveCell.Column.ToString();
                int iRow = this.grid1.ActiveRow.Index;

                if (sColumnName == "D1")
                {
                    string sDay = Convert.ToString(this.grid1.Rows[iRow].Cells["D1"].Value);

                    query.AppendLine(" SELECT ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sDay + "'), '|', 1), 0) AS 'D2', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sDay + "'), '|', 3), 0) AS 'D3', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sDay + "'), '|', 4), 0) AS 'D4'  ");

                    rtnDtTemp = helper.FillTable(query.ToString(), CommandType.Text);

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        this.grid1.Rows[iRow].Cells["D2"].Value = Convert.ToString(rtnDtTemp.Rows[0]["D2"]);
                        this.grid1.Rows[iRow].Cells["D3"].Value = Convert.ToString(rtnDtTemp.Rows[0]["D3"]);
                        this.grid1.Rows[iRow].Cells["D4"].Value = Convert.ToString(rtnDtTemp.Rows[0]["D4"]);
                    }

                }

                if (sColumnName == "N1")
                {
                    string sNight = Convert.ToString(this.grid1.Rows[iRow].Cells["N1"].Value);

                    query.AppendLine(" SELECT ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sNight + "'), '|', 1), 0) AS 'N2', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sNight + "'), '|', 3), 0) AS 'N3', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sNight + "'), '|', 4), 0) AS 'N4'  ");

                    rtnDtTemp = helper.FillTable(query.ToString(), CommandType.Text);

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        this.grid1.Rows[iRow].Cells["N2"].Value = Convert.ToString(rtnDtTemp.Rows[0]["N2"]);
                        this.grid1.Rows[iRow].Cells["N3"].Value = Convert.ToString(rtnDtTemp.Rows[0]["N3"]);
                        this.grid1.Rows[iRow].Cells["N4"].Value = Convert.ToString(rtnDtTemp.Rows[0]["N4"]);
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
            }
        }

        #endregion

        private void KeyPress_Event(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.DataSelect();
                e.Handled = true;
            }
        }

        #region < USER METHOD AREA >
        private void DataSelect()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);

                // base.DoInquire();

                this.ShowProgressForm("C00004");

                string sPlantCode = LoginInfo.PlantCode;
                string sMonth = string.Format("{0:yyyy-MM}", this.dtSMonth_H.Value);
                string sLineCode = this.cboLineCode_H.Value.ToString();

                grid1.DataSource = helper.FillTable("USP_AP1200_S1", CommandType.StoredProcedure
                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_MONTH", sMonth, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("AS_LINECODE", sLineCode, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();
                //this.grid1.DisplayLayout.Bands[0].PerformAutoResizeColumns(true, PerformAutoSizeType.AllRowsInBand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.ClosePrgForm();
                helper.Close();
            }
        }

        #endregion
    }
}
