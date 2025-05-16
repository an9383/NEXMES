#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : AP1250                                                                                                                                                                        
//   Form Name    : 작업장 작업 캘린더                                                                                                                                                                   
//   Name Space   : WIZ.AP                                                                                                                                                                        
//   Created Date :                                                                                                                                                                     
//   Made By      : WIZCORE                                                                                                                                                
//   Description  : 작업장 기준 작업 카렌다 생성 및 조회                                                                                                                                                                
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP1250 : WIZ.Forms.BaseMDIChildForm
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

        // POP-UP 처리를 위한 관리용
        BizGridManager gridManager;
        BizTextBoxManager btbManager;

        #endregion

        #region < CONSTRUCTOR >
        public AP1250()
        {
            InitializeComponent();

            btbManager = new BizTextBoxManager();
            gridManager = new BizGridManager(grid1);

            //sPlantCode, sOpCode, sLineCode, sUseFlag
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { LoginInfo.PlantCode, "", this.cboLineCode_H, "Y" }); //작업장 POP_UP
        }
        #endregion

        #region < FORM LOAD >
        private void AP1250_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "WRKDATE", "근무일자", true, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인코드", true, GridColDataType_emu.VarChar, 200, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "생산라인", true, GridColDataType_emu.VarChar, 250, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WEEK", "요일", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "D1", "주간근무형태", true, GridColDataType_emu.VarChar, 120, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "D2", "주간근무", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "D3", "주간잔업", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "D4", "부하시간", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DHOLIDAY", "주간휴무여부", true, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "N1", "야간근무형태", true, GridColDataType_emu.VarChar, 120, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "N2", "야간근무", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "N3", "야간잔업", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "N4", "부하시간", true, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NHOLIDAY", "야간휴무여부", true, GridColDataType_emu.VarChar, 100, true, false);

            _GridUtil.SetColumnTextHAlign(grid1, "LINECODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "D1", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "D2", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "D3", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "D4", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "N1", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "N2", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "N3", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "N4", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERCODE", Infragistics.Win.HAlign.Left);

            _GridUtil.SetInitUltraGridBind(this.grid1);

            #endregion

            #region < COMBOBOX SETTING >

            rtnDtTemp = _Common.GET_BM0050_CODE("");
            WIZ.Common.FillComboboxMaster(this.cboLineCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LINECODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE", "MINORCODE LIKE 'D%'");  //주간근무형태                                                                                                                        
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "D1", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WRKTYPECODE", "MINORCODE LIKE 'N%'");  //야간근무형태                                                                                                                        
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "N1", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DHOLIDAY", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NHOLIDAY", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0060_CODE("");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion



        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DataSelect();
        }

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
                this.grid1.UpdateData();
                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {

                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_AP1250_U1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)  //작업장
                                                                   , helper.CreateParameter("LineCode", Convert.ToString(drRow["LineCode"]), DbType.String, ParameterDirection.Input)  //아이템코드
                                                                   , helper.CreateParameter("WrkDate", Convert.ToString(drRow["WrkDate"]), DbType.String, ParameterDirection.Input)  //순번
                                                                   , helper.CreateParameter("D1", Convert.ToString(drRow["D1"]), DbType.String, ParameterDirection.Input)  //주야  
                                                                   , helper.CreateParameter("N1", Convert.ToString(drRow["N1"]), DbType.String, ParameterDirection.Input)  //주야   
                                                                   , helper.CreateParameter("PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)  //공장 
                                                                   , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));//등록자                       //등록지

                            #endregion
                            break;

                    }
                }
                helper.Commit();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
                base.DoInquire();
            }

        }
        #endregion

        #region < USER METHOD AREA >

        private void KeyPress_Event(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.DataSelect();
                e.Handled = true;
            }
        }


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
                string sWorkCenterCode = this.txtWorkCenterCode.Text;
                //    sWorkCenterCode = this.cboWcCd_H.Value.ToString();

                grid1.DataSource = helper.FillTable("USP_AP1250_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MONTH", sMonth, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_LINECODE", sLineCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));

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
