#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1300
//   Form Name    : 재고실사지시
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;

#endregion

namespace WIZ.MM
{
    public partial class MM1300 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataTable rtnDtTemp = new DataTable();

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        #endregion


        #region < CONSTRUCTOR >

        public MM1300()
        {
            InitializeComponent();
        }

        #endregion

        #region  < FORM EVENT >
        private void MM1300_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "진행상태", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDNO", "지시번호", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDDATE", "지시일자", false, GridColDataType_emu.YearMonthDay, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGORDREMARK", "재고실사사유", false, GridColDataType_emu.VarChar, 300, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGSTARTDATE", "실사시작일", false, GridColDataType_emu.YearMonthDay, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGENDDATE", "실사완료일", false, GridColDataType_emu.YearMonthDay, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "지시창고", false, GridColDataType_emu.VarChar, 150, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 100, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 100, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, false, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "TAKINGORDREMARK", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "WHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Left);
            #endregion

            #region < COMBOBOX SETTING >
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;
            this.cboPlantCode.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("STOCKSTATUS");   //진행상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME_ORG"].ColumnName);
            WIZ.Common.FillComboboxMaster(this.cboStatus_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboUseFlag.Value = "Y";

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");
            WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            // 콤보박스 시간설정
            dtStart_H.Value = DateTime.Now.AddDays(-7);
            dtEnd_H.Value = DateTime.Now;
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

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                  // 공장코드     
                string sTakingORDDate1 = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);        // 일자 FROM
                string sTakingORDDate2 = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);          // 일자 TO                                                                                       
                string sStatus = Convert.ToString(cboStatus_H.Value);                     // 상태(진행, 완료)     
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);                    // 사용여부     

                rtnDtTemp = helper.FillTable("USP_MM1300_S1N"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)     // 사업장 공장코드    
                                            , helper.CreateParameter("AS_TAKINGORDDATE_FROM", sTakingORDDate1, DbType.String, ParameterDirection.Input)     // 일자 FROM          
                                            , helper.CreateParameter("AS_TAKINGORDDATE_TO", sTakingORDDate2, DbType.String, ParameterDirection.Input)     // 일자 TO            
                                            , helper.CreateParameter("AS_STATUS", sStatus, DbType.String, ParameterDirection.Input)     // 상태          
                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));   // 사용여부 

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();
                    }
                    else
                    {
                        this.ShowDialog("조회할 데이터가 없습니다.", Forms.DialogForm.DialogType.OK);
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
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
        }

        public override void DoSave()
        {
        }
        #endregion

        #region < EVENT AREA >

        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
        }

        private void btnmake_Click(object sender, EventArgs e)
        {
            // 지시번호 생성
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode.Value);

                if (sPlantCode == "")
                {
                    this.ShowDialog("선택된 사업장이 없습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_TAKINGORDNOCREATE"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("TAKINGORDNO", DbType.String, ParameterDirection.Output, null, 200));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    txtOrderNo.Text = Convert.ToString(rtnDtTemp.Rows[0]["COLUMN1"]);
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
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                this.cboPlantCode.Value = grid1.ActiveRow.Cells["PLANTCODE"].Value;
                this.txtOrderNo.Text = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDNO"].Value);
                this.cboWhCode.Value = grid1.ActiveRow.Cells["WHCODE"].Value;
                this.cboUseFlag.Value = grid1.ActiveRow.Cells["USEFLAG"].Value;
                this.txtTakingORDRemark.Text = Convert.ToString(grid1.ActiveRow.Cells["TAKINGORDREMARK"].Value);
            }
        }

        #endregion

        #region < USER METHOD AREA >
        private void DoInsert()
        {
            // 재고실사 등록 처리
            DBHelper helper = new DBHelper(false);

            string sTakingORDNo = txtOrderNo.Text.Trim();                            // 재고실사지시번호
            string sPlantCode = Convert.ToString(cboPlantCode.Value).Trim();       // 사업장 
            string sWHCode = Convert.ToString(cboWhCode.Value).Trim();          // 창고코드  
            string sTakingORDDate = string.Format("{0:yyyy-MM-dd}", dtStart.Value);    // 재고실사 지시일자
            string sTakingORDRemark = txtTakingORDRemark.Text.Trim();                    // 재고실사사유 
            string sUseFlag = Convert.ToString(cboUseFlag.Value).Trim();         // 사용여부



            if (sPlantCode == "")
            {
                this.ShowDialog("선택된 사업장이 없습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (sTakingORDNo == "")
            {
                this.ShowDialog("자재 재고실사 지시 번호를 생성하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (sWHCode == "")
            {
                this.ShowDialog("선택된 지시창고가 없습니다.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            if (sUseFlag == "")
            {
                this.ShowDialog("실사 사용여부를 선택 하십시오.", WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                //대상 창고, 사용여부, 지시일자, 실사사유 수정가능. (실사시작일 NULL일때까지)     
                helper.ExecuteNoneQuery("USP_MM1300_I1N"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_TAKINGORDNO", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_WHCODE", sWHCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_TAKINGORDDATE", sTakingORDDate, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_TAKINGORDREMARK", sTakingORDRemark, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE == "S")
                {
                    this.ShowDialog("데이터가 저장되었습니다.", Forms.DialogForm.DialogType.OK);
                    helper.Commit();
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
                DoInquire();
            }
        }

        #endregion
    }
}
