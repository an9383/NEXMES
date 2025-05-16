#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM3670
//   Form Name    : 설비정검항목 작업장별 스펙 관리
//   Name Space   : WIZ.BM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM3670 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable();        // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();//그리드 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();             //비지니스 로직 객체 생성
        DataTable _DtTemp = new DataTable();          //임시로 사용할 데이터테이블 생성
        #endregion

        #region < CONSTRUCTOR >

        public BM3670()
        {
            InitializeComponent();
            BizGridManager BIZPOP = new BizGridManager(grid1);

            BIZPOP.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "MC", "", "Y" });



            BIZPOP.PopUpAdd("MachCode", "Machname", "TBM0700", new string[] { "", "", "", "Y" });

        }
        #endregion

        #region BM3670_Load
        private void BM3670_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            // InitColumnUltraGrid

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Machname", "설비명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "점검항목", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "점검항목명", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCMETHOD", "점검방법코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCMETHODNAME", "점검방법명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCRUNSTOP", "운/휴", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCINSTRUMENT", "측정기구코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCINSTRUMENTNAME", "측정기구명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCSTANDARD", "판정기준코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCSTANDARDNAME", "판정기준명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCCHECKCYLE", "교환,점검주기", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            #region Grid MERGE
            //grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            //grid1.Columns["MachCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["MachCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["MachCode"].MergedCellStyle = MergedCellStyle.Always;

            //grid1.Columns["Machname"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //grid1.Columns["Machname"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            //grid1.Columns["Machname"].MergedCellStyle = MergedCellStyle.Always;

            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion Grid MERGE



            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion



            //   운/휴 : MCRUNSTOP,  "점검방법", "MCMETHOD", 측정기구 : MCINSTRUMENT, 판정기준, MCSTANDARD, 검사정보구분 : INSPVALTYPE, 사용유무 : USEFLAG

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCRUNSTOP");  //운/휴
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCRUNSTOP", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType");  //검사정보구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");



            rtnDtTemp = _Common.GET_BM0000_CODE("MCMETHOD");  //검사정보구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCMETHOD", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCINSTRUMENT");  //검사정보구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCINSTRUMENT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCSTANDARD");  //검사정보구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCSTANDARD", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion BM3670_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                  // 사업장코드 
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);                      // 사용여부    
                string sMachCode = txtMachCode.Text.Trim();                                    // 설비코드                                                          
                string sInspCode = txtInspCode.Text.Trim();                                    // 검사항목                                                          
                string sInspCodeNM = txtInspCodeNM.Text.Trim();                                // 관리항목  

                grid1.DataSource = helper.FillTable("USP_BM3670_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("MachCode", sMachCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("InspCode", sInspCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));


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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                _GridUtil.AddRow(this.grid1);
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");    // 사업장
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MachCode");     // 설비코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Machname");     // 설비  
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCode");     // 점검항목
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspName");     // 점검항목명	
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MCMETHOD");     // 점검방법
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MCRUNSTOP");    // 운/휴
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MCINSTRUMENT"); // 측정기구
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MCSTANDARD");   // 판정기준
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MCCHECKCYLE");  // 교환점검주기
                UltraGridUtil.ActivationAllowEdit(this.grid1, "InspValType");  // 검사구분
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DisplayNo");    // 표시순서
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");      // 사용유무
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

            base.DoDelete();
            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                base.DoSave();
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "공장(사업장) error!");
                            continue;
                        }
                    }

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM3670_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)         // 공장코드
                            , helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input)           // 설비코드
                            , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input));           // 관리항목
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM3670_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)     // 공장코드
                            , helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input)     // 설비코드
                            , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input)     // 검사항목코드
                            , helper.CreateParameter("MCMETHOD", drRow["MCMETHOD"].ToString(), DbType.String, ParameterDirection.Input)     // 점검방법
                            , helper.CreateParameter("MCRUNSTOP", drRow["MCRUNSTOP"].ToString(), DbType.String, ParameterDirection.Input)     // 운/휴
                            , helper.CreateParameter("MCINSTRUMENT", drRow["MCINSTRUMENT"].ToString(), DbType.String, ParameterDirection.Input)     // 측정기구
                            , helper.CreateParameter("MCSTANDARD", drRow["MCSTANDARD"].ToString(), DbType.String, ParameterDirection.Input)     // 판정기준
                            , helper.CreateParameter("MCCHECKCYLE", drRow["MCCHECKCYLE"].ToString(), DbType.String, ParameterDirection.Input)     // 교환,점검주기
                            , helper.CreateParameter("InspValType", drRow["InspValType"].ToString(), DbType.String, ParameterDirection.Input)     // 검사정보구분(양호/불량, OK/NOK, 확인, 값입력)
                            , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)     // 표시순서
                            , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)     // 사용유무
                            , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));     // 등록자

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM3670_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)     // 공장코드
                            , helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input)     // 설비코드
                            , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input)     // 검사항목코드
                            , helper.CreateParameter("MCMETHOD", drRow["MCMETHOD"].ToString(), DbType.String, ParameterDirection.Input)     // 점검방법
                            , helper.CreateParameter("MCRUNSTOP", drRow["MCRUNSTOP"].ToString(), DbType.String, ParameterDirection.Input)     // 운/휴
                            , helper.CreateParameter("MCINSTRUMENT", drRow["MCINSTRUMENT"].ToString(), DbType.String, ParameterDirection.Input)     // 측정기구
                            , helper.CreateParameter("MCSTANDARD", drRow["MCSTANDARD"].ToString(), DbType.String, ParameterDirection.Input)     // 판정기준
                            , helper.CreateParameter("MCCHECKCYLE", drRow["MCCHECKCYLE"].ToString(), DbType.String, ParameterDirection.Input)     // 교환,점검주기
                            , helper.CreateParameter("InspValType", drRow["InspValType"].ToString(), DbType.String, ParameterDirection.Input)     // 검사정보구분(양호/불량, OK/NOK, 확인, 값입력)
                            , helper.CreateParameter("DisplayNo", drRow["DisplayNo"].ToString(), DbType.String, ParameterDirection.Input)     // 표시순서
                            , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)     // 사용유무
                            , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));              // 수정자

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();

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
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {

                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        //////////////////     
        #region 설비정보
        private void Search_Pop_TBM0700()
        {

            string sMachCode = txtMachCode.Text.Trim();       //설비코드
            string sMachName = txtMachName.Text.Trim();      //설비명 


            try
            {
                //_biz.TBM0700_POP(sMachCode, sMachName, "", "", "", "", txtMachCode, txtMachName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion        //설비

        private void txtMachCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtMachName.Text = string.Empty;
        }

        private void txtMachCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0700();
            }
        }

        private void txtMachCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0700();
        }

        private void txtMachName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtMachCode.Text = string.Empty;
        }

        private void txtMachName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0700();
            }
        }

        private void txtMachName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0700();
        }

        #endregion

        #region 텍스트 박스에서 팝업창에서 값 가져오기
        private void Search_Insp_Item()
        {
            string sInspCase = "QC";
            string sInspType = "";
            string sInspCode = txtInspCode.Text.ToUpper();
            string sInspName = txtInspCodeNM.Text;
            string sUseFlag = "Y";

            try
            {
                // _DtTemp = _biz.SEL_TBM1500(sInspCase, sInspType, sInspCode, sInspName, sUseFlag);

                if (_DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    _DtTemp = pu.OpenPopUp("TBM1500", new string[] { sInspCase, sInspType, sInspCode, sInspName, sUseFlag }); // 

                    if (_DtTemp != null && _DtTemp.Rows.Count > 0)
                    {
                        txtInspCode.Text = Convert.ToString(_DtTemp.Rows[0]["InspCode"]);
                        txtInspCodeNM.Text = Convert.ToString(_DtTemp.Rows[0]["InspName"]);
                    }
                }
                else
                {
                    if (_DtTemp.Rows.Count == 1)
                    {
                        txtInspCode.Text = Convert.ToString(_DtTemp.Rows[0]["InspCode"]);
                        txtInspCodeNM.Text = Convert.ToString(_DtTemp.Rows[0]["InspName"]);
                    }
                    else
                    {
                        MessageBox.Show(Common.getLangText("입력하신 정보는 없는 정보입니다.", "MSG"), "ERROR");
                        txtInspCode.Text = string.Empty;
                        txtInspCodeNM.Text = string.Empty;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion

        #region<Event>
        private void btn3671_Click(object sender, EventArgs e)
        {
            string[] para = new string[3];

            int idx = this.grid1.ActiveRow == null ? 0 : this.grid1.ActiveRow.Index;

            // 행이 없을 경우 SKIP
            if (this.grid1.Rows.Count == 0)
            {
                this.IsShowDialog = false;
                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                return;
            }



            // 정보 넘김(사업장, 공정, 명, 설비, 명)
            string sPlantCode = this.grid1.ActiveRow.Cells["PlantCode"].Value.ToString();
            string sMachCode = this.grid1.ActiveRow.Cells["MachCode"].Value.ToString();
            string sMachName = this.grid1.ActiveRow.Cells["MachName"].Value.ToString();
            if (sPlantCode != "" && sMachCode != "")
            {
                para[0] = sPlantCode;
                para[1] = sMachCode;
                para[2] = sMachName;
                BM3671 Form = new BM3671(para);
                Form.ShowDialog();
            }
            else
            {
                this.ShowDialog(Common.getLangText("정보가 선택되지 않았습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            }



        }

        private void txtInspCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Insp_Item();
            }
        }

        private void txtInspCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Insp_Item();
        }

        private void txtInspCodeNM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Insp_Item();
        }

        private void txtInspCodeNM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Insp_Item();
            }

        }

        private void txtInspCode_KeyDown(object sender, KeyEventArgs e)
        {
            txtInspCodeNM.Text = string.Empty;
        }

        private void txtInspCodeNM_KeyDown(object sender, KeyEventArgs e)
        {
            txtInspCode.Text = string.Empty;
        }
        #endregion


    }
}

