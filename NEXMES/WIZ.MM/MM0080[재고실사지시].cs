#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0080
//   Form Name    : 재고실사지시
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-28
//   Made By      : WIZCORE 남부사무소 사원 김병수
//   Edited Date  : 
//   Edit By      :
//   Description  : 재고실사지시
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;

#endregion

namespace WIZ.MM
{
    public partial class MM0080 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable();

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        int SAVEFLAG = 0;
        #endregion


        #region < CONSTRUCTOR >

        public MM0080()
        {
            InitializeComponent();
        }

        #endregion

        #region  < FORM EVENT >
        private void MM0080_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDREMARK", "재고실사사유", false, GridColDataType_emu.VarChar, 300, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHTYPE", "창고구분", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGSTARTDATE", "실사시작일", false, GridColDataType_emu.YearMonthDay, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGENDDATE", "실사완료일", false, GridColDataType_emu.YearMonthDay, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "지시창고 & 지시작업장", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 180, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 90, false, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGORDREMARK", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHTYPE", Infragistics.Win.HAlign.Left);

            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            this.cbo_PLANTCODE_B.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("STOCKSTATUS");   //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME_ORG"].ColumnName);
            WIZ.Common.FillComboboxMaster(this.cbo_STATUS_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  //사용여부
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_USEFLAG_B.Value = "Y";

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE"); //창고구분
            WIZ.Common.FillComboboxMaster(this.cbo_WHTYPE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.Common.FillComboboxMaster(this.cbo_WHTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            GetWhCode("");

            // 콤보박스 시간설정
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            cbo_DATE_B.Value = DateTime.Now;

            ControlSetting("VIEW");
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

            try
            {
                base.DoInquire();

                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);                  // 사업장     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);   // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);     // 일자 TO   
                string sWhType = Convert.ToString(cbo_WHTYPE_H.Value);                     // 창고구분
                string sStatus = Convert.ToString(cbo_STATUS_H.Value);                     // 상태(진행, 완료)     
                string sUseFlag = Convert.ToString(cbo_USEFLAG_H.Value);                    // 사용여부     

                rtnDtTemp = helper.FillTable("USP_MM0080_S1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)     // 사업장
                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)     // 일자 FROM          
                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)     // 일자 TO            
                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)     // 창고구분
                                            , helper.CreateParameter("AS_STATUS", sStatus, DbType.String, ParameterDirection.Input)     // 상태          
                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));   // 사용여부 

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
                ControlSetting("VIEW");
            }
        }

        public override void DoNew()
        {
            ControlSetting("NEW");
        }

        public override void DoSave()
        {
            if (SAVEFLAG == 1)
            {
                DoInsert();
            }
            else if (SAVEFLAG == 2)
            {
                DoUpdate();
            }
        }

        public override void DoDelete()
        {
        }

        #endregion

        #region < EVENT AREA >

        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                cbo_PLANTCODE_B.Value = grid1.ActiveRow.Cells["PLANTCODE"].Value;
                cbo_WHTYPE_B.Value = grid1.ActiveRow.Cells["WHTYPE"].Value;
                cbo_WHCODE_B.Value = grid1.ActiveRow.Cells["WHCODE"].Value;
                cbo_USEFLAG_B.Value = grid1.ActiveRow.Cells["USEFLAG"].Value;
                cbo_TAKINGORDREMARK_B.Text = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDREMARK"].Value);

                if (Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value) == "창고 전체")
                    cbo_WHCODE_B.SelectedIndex = 0;
            }

        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            ControlSetting("EDIT");
        }

        #endregion

        #region < USER METHOD AREA >
        private void DoInsert()
        {
            // 재고실사 등록 처리
            DBHelper helper = new DBHelper("", true);

            //string sTakingORDNo = txt_ORDERNO_B.Text.Trim();                            // 실사지시번호
            string sPlantCode = Convert.ToString(cbo_PLANTCODE_B.Value).Trim();       // 사업장 
            string sWhType = Convert.ToString(cbo_WHTYPE_B.Value).Trim();          // 창고구분
            string sWhCode = Convert.ToString(cbo_WHCODE_B.Value).Trim();

            //string sWhCode;
            //if (Convert.ToString(cbo_WHCODE_B.Value).Trim() == "")
            //    sWhCode = "WH0000";
            //else
            //    sWhCode = Convert.ToString(cbo_WHCODE_B.Value).Trim();

            string sTakingORDDate = string.Format("{0:yyyy-MM-dd}", cbo_DATE_B.Value);    // 재고실사 지시일자
            string sTakingORDRemark = cbo_TAKINGORDREMARK_B.Text.Trim();                    // 재고실사사유 
            string sUseFlag = Convert.ToString(cbo_USEFLAG_B.Value).Trim();         // 사용여부

            if (sPlantCode == "")
            {
                this.ShowDialog("선택된 사업장이 없습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (sWhType == "")
            {
                this.ShowDialog("선택된 창고구분이 없습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            //if (sWhCode == "")
            //{
            //    this.ShowDialog("선택된 지시창고가 없습니다.", WIZ.Forms.DialogForm.DialogType.OK);
            //    return;
            //}

            if (sUseFlag == "")
            {
                this.ShowDialog("실사 사용여부를 선택 하십시오.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                //대상 창고, 사용여부, 지시일자, 실사사유 수정가능. (실사시작일 NULL일때까지)     
                helper.ExecuteNoneQuery("USP_MM0080_I1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_TAKINGORDDATE", sTakingORDDate, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_TAKINGORDREMARK", sTakingORDRemark, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog("데이터가 저장되었습니다.", Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
                DoInquire();
                ControlSetting("VIEW");
            }
        }

        private void DoUpdate()
        {
            DBHelper helper = new DBHelper("", true);

            string sPlantCode = Convert.ToString(cbo_PLANTCODE_B.Value);
            string sTakingOrdNo = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);
            string sWhType = Convert.ToString(grid1.ActiveRow.Cells["WHTYPE"].Value);
            string sWhCode = Convert.ToString(cbo_WHCODE_B.Value).Trim();
            string sOrderDate = string.Format("{0:yyyy-MM-dd}", cbo_DATE_B.Value);
            string sRemark = cbo_TAKINGORDREMARK_B.Text.Trim();
            string sUseFlag = Convert.ToString(cbo_USEFLAG_B.Value);

            if (sPlantCode == string.Empty)
            {
                ShowDialog(Common.getLangText("선택된 지시창고가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (sUseFlag == string.Empty)
            {
                ShowDialog(Common.getLangText("사용여부를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_MM0080_U1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_TAKINGORDNO", sTakingOrdNo, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ORDERDATE", sOrderDate, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog("데이터가 저장되었습니다.", Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
                DoInquire();
                ControlSetting("VIEW");
            }
        }

        private void ControlSetting(string sFlag)
        {
            if (sFlag == "VIEW")
            {
                cbo_PLANTCODE_B.Enabled = false;
                cbo_WHTYPE_B.Enabled = false;
                cbo_WHCODE_B.Enabled = false;
                cbo_DATE_B.Enabled = false;
                cbo_USEFLAG_B.Enabled = false;
                cbo_TAKINGORDREMARK_B.Enabled = false;

                SAVEFLAG = 0;
            }
            else if (sFlag == "NEW")
            {
                cbo_PLANTCODE_B.SelectedIndex = 0;
                cbo_WHTYPE_B.SelectedIndex = 0;
                cbo_WHCODE_B.SelectedIndex = 0;
                cbo_USEFLAG_B.SelectedIndex = 0;
                cbo_DATE_B.Value = DateTime.Now;
                cbo_TAKINGORDREMARK_B.Text = string.Empty;

                cbo_PLANTCODE_B.Enabled = true;
                cbo_WHTYPE_B.Enabled = true;
                cbo_WHCODE_B.Enabled = true;
                cbo_DATE_B.Enabled = true;
                cbo_USEFLAG_B.Enabled = true;
                cbo_TAKINGORDREMARK_B.Enabled = true;

                SAVEFLAG = 1;
            }
            else if (sFlag == "EDIT")
            {
                if (grid1.ActiveRow != null)
                {
                    cbo_PLANTCODE_B.Value = grid1.ActiveRow.Cells["PLANTCODE"].Value;
                    cbo_WHTYPE_B.Value = grid1.ActiveRow.Cells["WHTYPE"].Value;

                    if (Convert.ToString(grid1.ActiveRow.Cells["WHCODE"].Value) == "창고 전체")
                        cbo_WHCODE_B.SelectedIndex = 0;
                    else
                        cbo_WHCODE_B.Value = grid1.ActiveRow.Cells["WHCODE"].Value;

                    cbo_DATE_B.Value = grid1.ActiveRow.Cells["TAKINGORDDATE"].Value;
                    cbo_USEFLAG_B.Value = grid1.ActiveRow.Cells["USEFLAG"].Value;
                    cbo_TAKINGORDREMARK_B.Text = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDREMARK"].Value);

                    cbo_PLANTCODE_B.Enabled = true;
                    cbo_WHTYPE_B.Enabled = true;
                    cbo_WHCODE_B.Enabled = true;
                    cbo_DATE_B.Enabled = true;
                    cbo_USEFLAG_B.Enabled = true;
                    cbo_TAKINGORDREMARK_B.Enabled = true;

                    SAVEFLAG = 2;
                }
            }
        }

        #endregion

        private void cbo_WHTYPE_B_ValueChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0080_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHTYPE", Convert.ToString(cbo_WHTYPE_B.Value), DbType.String, ParameterDirection.Input));

                WIZ.Common.FillComboboxMaster(this.cbo_WHCODE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "창고 전체", "");

            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }

        private void GetWhCode(string sWhType)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_MM0100_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WHTYPE", sWhType, DbType.String, ParameterDirection.Input));

                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.Common.FillComboboxMaster(this.cbo_WHCODE_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");


            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
    }
}
