#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MD0810
//   Form Name    : 수리/보수 결과 등록
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MD
{
    public partial class MD0810 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        Common _Common = new Common();
        #endregion

        #region < CONSTRUCTOR >

        public MD0810()
        {
            InitializeComponent();
        }
        #endregion

        #region  MD0810_Load
        private void MD0810_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid 90 187 90 165 165 165 100 165 165 165 165 100 90 90 90 90  
            //_GridUtil.InitColumnUltraGrid(grid1, "MoldRepSeqNo",   "수리순번(횟차)", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"      , "사업장"     , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "MoldCode"       , "금형코드"   , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "MoldName"       , "금형명"     , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE" , "작업장코드" , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME" , "작업장명"   , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "InDate"         , "장착일시"   , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center,  true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "outDate"        , "탈착일시"   , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center,  true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ItemCode"       , "품목"       , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "ItemName"       , "품목명"       , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "UseShot"        , "사용타수"   , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "Cavity"         , "사용타수"   , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRODAMOUNT"     , "생산수량"   , true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            //2014.7.3 Lim Y.j.
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldName", "금형명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OpCode", "공정코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InDate", "장착일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InTime", "장착시간", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "outDate", "탈착일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "outTime", "탈착시간", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdDate", "사용일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldRepSeqNo", "수리횟차", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseShot", "사용타수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Cavity", "Cavity", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdQty", "생산수", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Worker", "작업자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion


            #region 팝업

            ////조회용 POP 
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode_H, txtMoldName_H, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형

            ////등록용 pop
            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode, "" }); //금형
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "" }); //품목
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });//작업장

            #endregion

            #region 콤보박스

            //사업장(조회)
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //사업장(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion  MD0810_Load

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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);           // 공장코드  
                string sMoldCode = txtMoldCode_H.Text;                                       // 금형코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);   // 일자 FROM                                                                                                                                                                    
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);       // 일자 TO     


                //rtnDtTemp = helper.FillTable("USP_MD0810_S1", CommandType.StoredProcedure   2014.7.3 Lim Y.J.
                grid1.DataSource = helper.FillTable("USP_MD0810_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     // 사업장 공장코드    
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)       // 금형
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)     // 일자 FROM          
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input));       // 일자 TO            
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
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            if (grid1.IsActivate) this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    //  CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_MD0810_D2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)     // 사업장(공장) 
                                                                    , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)      // 금형코드
                                                                    , helper.CreateParameter("ProdDate", Convert.ToDateTime(drRow["ProdDate"]), DbType.String, ParameterDirection.Input));     // 일자
                            //                                                       , helper.CreateParameter("ProdDate",  drRow["ProdDate"].ToString(), DbType.String, ParameterDirection.Input));     // 일자

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            // 2014.7.3 Lim y.j. 맊음
                            //helper.ExecuteNoneQuery("USP_MD0810_U1", CommandType.StoredProcedure
                            //                                        , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                            //                                        , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                            //                                        , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                            //                                        , helper.CreateParameter("UseShot", drRow["UseShot"].ToString(), DbType.String, ParameterDirection.Input)
                            //                                        , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)
                            //                                        , helper.CreateParameter("MoldRepSeqNo", drRow["MoldRepSeqNo"].ToString(), DbType.String, ParameterDirection.Input)
                            //                                        , helper.CreateParameter("InDate", drRow["InDate"].ToString(), DbType.String, ParameterDirection.Input)
                            //                                        , helper.CreateParameter("OutDate", drRow["OutDate"].ToString(), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE");
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
                // DoInquire();
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
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> /*
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

        private void DoInsert()
        {
            DBHelper helper = new DBHelper(false);

            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);                 // 사업장 
            string sMoldCode = txtMoldCode.Text.Trim();                                      // 금형코드  
            string sInDate = string.Format("{0:yyyy-MM-dd}", CboInDate.Value);               // 사용일시
            string sInTime = txtStartTime.Text.Trim(); // string.Format("{0:HH:MM}", CboStartTime.Value);                 // 장착시간
            string sOutDate = string.Format("{0:yyyy-MM-dd}", CboOutDate.Value);             // 종요일시
            string sOutTime = txtEndTime.Text.Trim();// string.Format("{0:HH:MM}", cboEndTime.Value);                  // 탈착시간
            string sProdDate = sInDate + " " + sInTime + ":00";
            string sMoldRepSeqNo = txtMoldRepSeqNo.Text.Trim();                              // 수리횟수
            string sUseShot = txtUseShot.Text.Trim();                                        // 사용타수 
            string sWorkCenterCode = txtWorkCenterCode.Text.Trim();                          // 작업장 
            string sItemCode = txtItemCode.Text.Trim();                                      // 품목코드


            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("정보를 선택하거나 입력하세요.", "MSG"));
                return;
            }
            if (sUseShot == "")
            {
                MessageBox.Show(Common.getLangText("사용타수 정보를 입력하세요", "MSG"));
                return;
            }
            if (sMoldCode == "")
            {
                MessageBox.Show("Mold Info.Error");
                return;
            }

            try
            {
                //UltraGridUtil.DataRowDelete(this.grid1);
                //this.grid1.UpdateData();
                //// helper._sTran = helper._sConn.BeginTransaction();
                helper.ExecuteNoneQuery("USP_MD0810_I3", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ProdDate", Convert.ToDateTime(sProdDate), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("InDate", sInDate, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("InTime", sInTime, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("OutDate", sOutDate, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("OutTime", sOutTime, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MoldRepSeqNo", sMoldRepSeqNo, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("UseShot", sUseShot, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("WorkerID", this.WorkerID, DbType.String, ParameterDirection.Input));
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
            //DoInquire();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);


            if (grid1.ActiveRow != null)
            {
                cboPlantCode.Value = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);
                txtMoldCode.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldCode"].Value);
                txtMoldName.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldName"].Value);
                txtWorkCenterCode.Text = Convert.ToString(grid1.ActiveRow.Cells["WorkCenterCode"].Value);
                txtWorkCenterName.Text = Convert.ToString(grid1.ActiveRow.Cells["WorkCenterName"].Value);
                txtItemCode.Text = Convert.ToString(grid1.ActiveRow.Cells["ItemCode"].Value);
                txtItemName.Text = Convert.ToString(grid1.ActiveRow.Cells["ItemName"].Value);
                txtCavity.Text = Convert.ToString(grid1.ActiveRow.Cells["Cavity"].Value);
                txtUseShot.Text = Convert.ToString(grid1.ActiveRow.Cells["UseShot"].Value);             // 사용횟수, 
                txtMoldRepSeqNo.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldRepSeqNo"].Value);  // 수리차수, 
                txtStartTime.Text = Convert.ToString(grid1.ActiveRow.Cells["InTime"].Value);           // 시작시간
                txtEndTime.Text = Convert.ToString(grid1.ActiveRow.Cells["outTime"].Value);            // 종료시간
                // 2014.7. 3 LIM Y.J
                //string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value); 
                //string TakingORDNO = string.Empty;
                //string RS_CODE = string.Empty;
                //string RS_MSG = string.Empty;


                //try
                //{
                //    helper.ExecuteNoneQuery("USP_MoldRepSeqNoCreate_P1"
                //                            , CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNO //ref MoldRepSeqNo
                //                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));

                //    if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                //    txtMoldRepSeqNo.Text = TakingORDNO.ToString();
                //}

                //catch (Exception ex)
                //{
                //    helper.Rollback();
                //    MessageBox.Show(ex.ToString());
                //}
                //finally
                //{
                //    helper.Close();
                //}

            }
        }


        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            //등록화면 초기화//
            txtMoldCode.Text = Convert.ToString(null);
            txtMoldName.Text = Convert.ToString(null);
            txtWorkCenterCode.Text = Convert.ToString(null);
            txtWorkCenterName.Text = Convert.ToString(null);
            txtItemCode.Text = Convert.ToString(null);
            txtItemName.Text = Convert.ToString(null);
            txtUseShot.Text = Convert.ToString(null);
            txtMoldRepSeqNo.Text = Convert.ToString(null);
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  // 등록용 수리유형 초기화
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            //DoInquire();
        }

        private void bntInitializ_Click(object sender, EventArgs e)
        {
            // 초기화
            cboPlantCode.Value = "";
            txtMoldCode.Text = "";
            txtMoldName.Text = "";
            txtWorkCenterCode.Text = "";
            txtWorkCenterName.Text = "";
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtCavity.Text = "";
            txtUseShot.Text = "";             // 사용횟수, 
            txtMoldRepSeqNo.Text = "";        // 수리차수, 
            txtStartTime.Text = "";           // 시작시간
            txtEndTime.Text = "";            //  종료시간
        }

    }
}
