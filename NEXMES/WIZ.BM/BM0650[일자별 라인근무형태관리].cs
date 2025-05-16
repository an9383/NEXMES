#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0650
//   Form Name    : 일자별 라인근무형태 관리
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 일자별 라인근무형태를 관리
// *---------------------------------------------------------------------------------------------*                                                                                                   
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{
    public partial class BM0650 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        // 변수나 Form에서 사용될 Class를 정의
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        DataTable DtChange = new DataTable();


        #endregion

        #region < CONSTRUCTOR >
        public BM0650()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0650_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WRKDATE", "근무일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WEEK", "요일", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인코드", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DWRKTYPECODE", "주간근무형태코드", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DTWORKTIME", "주간총근무시간", true, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DTEXTWORKTIME", "주간총잔업시간", true, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DTSTOPTIME", "주간총부하시간", true, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DHOLIDAY", "주간휴무여부", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "NWRKTYPECODE", "야간근무형태코드", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "NTWORKTIME", "야간총근무시간", true, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "NTEXTWORKTIME", "야간총잔업시간", true, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "NTSTOPTIME", "야간총부하시간", true, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "NHOLIDAY", "야간휴무여부", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 100, Infragistics.Win.HAlign.Left, true, true);


            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["WRKDATE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["LINECODE"].Header.Appearance.ForeColor = Color.SkyBlue;


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region < COMBOBOX SETTING >

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0050_CODE("");
            WIZ.Common.FillComboboxMaster(this.cbo_LINECODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요::", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LINECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE", "MINORCODE LIKE 'D%'");  //주간근무형태                                                                                                                        
            WIZ.Common.FillComboboxMaster(this.cbo_DWRKTYPECODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요::", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DWRKTYPECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE", "MINORCODE LIKE 'N%'");  //야간근무형태                                                                                                                        
            WIZ.Common.FillComboboxMaster(this.cbo_NWRKTYPECODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요::", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NWRKTYPECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DHOLIDAY", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NHOLIDAY", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
            DtChange = (DataTable)grid1.DataSource;
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            try
            {
                DtChange.Clear();

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sWrkDate = string.Format("{0:yyyy-MM}", cbo_WRKDATE_H.Value);
                string sLineCode = DBHelper.nvlString(cbo_LINECODE_H.Value);
                string sDwrktypeCode = DBHelper.nvlString(cbo_DWRKTYPECODE_H.Value);
                string sNwrktypeCode = DBHelper.nvlString(cbo_NWRKTYPECODE_H.Value);


                rtnDtTemp = helper.FillTable("USP_BM0650_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WRKDATE", sWrkDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DWRKTYPECODE", sDwrktypeCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_NWRKTYPECODE", sNwrktypeCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
                    }
                    else
                    {
                        this.ClosePrgForm();
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    this.ClosePrgForm();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }

            catch (Exception ex)
            {
                this.ClosePrgForm();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                this.ClosePrgForm();
                base.DoInquire();
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

            rtnDtTemp = (DataTable)grid1.DataSource;

            DateTime dtNow = DateTime.Now;

            if (rtnDtTemp == null)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["WRKDATE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("근무일자는 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["LINECODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("라인코드는 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }

                    #region 추가                            
                    helper.ExecuteNoneQuery("USP_BM0650_I1", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WRKDATE", DBHelper.nvlString(drRow["WRKDATE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_LINECODE", DBHelper.nvlString(drRow["LINECODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_WEEK", DBHelper.nvlString(drRow["WEEK"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_DWRKTYPECODE", DBHelper.nvlString(drRow["DWRKTYPECODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_DHOLIDAY", DBHelper.nvlString(drRow["DHOLIDAY"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AF_DTWORKTIME", DBHelper.nvlInt(drRow["DTWORKTIME"]), DbType.Double, ParameterDirection.Input)
                                                           , helper.CreateParameter("AF_DTEXTWORKTIME", DBHelper.nvlInt(drRow["DTEXTWORKTIME"]), DbType.Double, ParameterDirection.Input)
                                                           , helper.CreateParameter("AF_DTSTOPTIME", DBHelper.nvlInt(drRow["DTSTOPTIME"]), DbType.Double, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_NWRKTYPECODE", DBHelper.nvlString(drRow["NWRKTYPECODE"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_NHOLIDAY", DBHelper.nvlString(drRow["NHOLIDAY"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AF_NTWORKTIME", DBHelper.nvlInt(drRow["NTWORKTIME"]), DbType.Double, ParameterDirection.Input)
                                                           , helper.CreateParameter("AF_NTEXTWORKTIME", DBHelper.nvlInt(drRow["NTEXTWORKTIME"]), DbType.Double, ParameterDirection.Input)
                                                           , helper.CreateParameter("AF_NTSTOPTIME", DBHelper.nvlInt(drRow["NTSTOPTIME"]), DbType.Double, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                    #endregion

                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
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

                if (cbo_LINECODE_H.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("라인 정보를 선택하세요", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (cbo_DWRKTYPECODE_H.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("주간 근무 형태를 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (cbo_NWRKTYPECODE_H.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("야간 근무 형태를 선택하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                string sMonth = string.Format("{0:yyyy-MM}", this.cbo_WRKDATE_H.Value);
                string sLineCode = DBHelper.nvlString(cbo_LINECODE_H.Value);
                string sDwrktypeCode = DBHelper.nvlString(cbo_DWRKTYPECODE_H.Value);
                string sNwrktypeCode = DBHelper.nvlString(cbo_NWRKTYPECODE_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0650_S2", CommandType.StoredProcedure
                                 , helper.CreateParameter("AS_MONTH", sMonth, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("AS_LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("AS_DWRKTYPECODE", sDwrktypeCode, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("AS_NWRKTYPECODE", sNwrktypeCode, DbType.String, ParameterDirection.Input));

                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                this.ClosePrgForm();
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

                if (sColumnName == "DWRKTYPECODE")
                {
                    string sDay = Convert.ToString(this.grid1.Rows[iRow].Cells["DWRKTYPECODE"].Value);

                    query.AppendLine(" SELECT ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sDay + "'), '|', 1), 0) AS 'DTWORKTIME', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sDay + "'), '|', 3), 0) AS 'DTEXTWORKTIME', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sDay + "'), '|', 4), 0) AS 'DTSTOPTIME'  ");

                    rtnDtTemp = helper.FillTable(query.ToString(), CommandType.Text);

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        this.grid1.Rows[iRow].Cells["DTWORKTIME"].Value = Convert.ToString(rtnDtTemp.Rows[0]["DTWORKTIME"]);
                        this.grid1.Rows[iRow].Cells["DTEXTWORKTIME"].Value = Convert.ToString(rtnDtTemp.Rows[0]["DTEXTWORKTIME"]);
                        this.grid1.Rows[iRow].Cells["DTSTOPTIME"].Value = Convert.ToString(rtnDtTemp.Rows[0]["DTSTOPTIME"]);
                    }

                }

                if (sColumnName == "NWRKTYPECODE")
                {
                    string sNight = Convert.ToString(this.grid1.Rows[iRow].Cells["NWRKTYPECODE"].Value);

                    query.AppendLine(" SELECT ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sNight + "'), '|', 1), 0) AS 'NTWORKTIME', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sNight + "'), '|', 3), 0) AS 'NTEXTWORKTIME', ");
                    query.AppendLine("       ISNULL(DBO.FN_ARRSPLIT(DBO.FN_GETWRKTIME('" + sNight + "'), '|', 4), 0) AS 'NTSTOPTIME'  ");

                    rtnDtTemp = helper.FillTable(query.ToString(), CommandType.Text);

                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        this.grid1.Rows[iRow].Cells["N2NTWORKTIME"].Value = Convert.ToString(rtnDtTemp.Rows[0]["NTWORKTIME"]);
                        this.grid1.Rows[iRow].Cells["NTEXTWORKTIME"].Value = Convert.ToString(rtnDtTemp.Rows[0]["NTEXTWORKTIME"]);
                        this.grid1.Rows[iRow].Cells["NTSTOPTIME"].Value = Convert.ToString(rtnDtTemp.Rows[0]["NTSTOPTIME"]);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgForm();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }


        #endregion

        #region < USER METHOD AREA >

        #endregion
    }
}
