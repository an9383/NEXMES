#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0200 
//   Form Name    : 금형불출의뢰
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
    public partial class MD0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >

        public MD0200()
        {
            InitializeComponent();

            //그리드 객체 생성
            BizGridManager bizGrid;
            bizGrid = new BizGridManager(grid1);

            bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });      // 9품목POP_UP grid
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });      // 금형 POP_UP grid

            //조회용 POP 
            //비지니스 로직 객체 생성
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode_H, txtMoldName_H, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형
            //등록용 POP 
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode, "" });       //금형
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "" });       //품목

        }
        #endregion

        #region  MD0200_Load
        private void MD0200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqDate", "불출의뢰일", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqNo", "불출의뢰번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldName", "금형명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqType", "불출구분", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutFlag", "불출처리여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutWorker", "출고자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutDate", "불출일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "불출업체코드", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "불출업체명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InWorkCenterCode", "투입작업장코드", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "투입작업장명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OrderNo", "지시번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion



            #region 콤보박스

            //사업장(조회)
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();   // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //사업장(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //불출구분(조회)
            rtnDtTemp = _Common.GET_BM0000_CODE("OutReqType");
            WIZ.Common.FillComboboxMaster(this.cboOutReqType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutReqType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //불출구분(등록)
            rtnDtTemp = _Common.GET_BM0000_CODE("OutReqType");
            WIZ.Common.FillComboboxMaster(this.cboOutReqType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutReqType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //출고처리여부
            rtnDtTemp = _Common.GET_BM0000_CODE("OutFlag");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion  MD0200_Load

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

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);          //공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);  //시작일자                                                                                                                           
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);      //종료일자 
                string sOutReqType = DBHelper.nvlString(this.cboOutReqType_H.Value);        //불출구분                                                                                                 
                string sMoldCode = this.txtMoldCode_H.Text.Trim();                          //금형코드     

                grid1.DataSource = helper.FillTable("USP_MD0200_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)     //사업장 공장코드    
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)     //일자 FROM          
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)         //일자 TO  
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)       //금형코드             
                                                                   , helper.CreateParameter("OutReqType", sOutReqType, DbType.String, ParameterDirection.Input)); //불출구분           

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
            //try
            //{
            //    base.DoNew();

            //    int iRow = _GridUtil.AddRow(this.grid1, DtChange);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
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
            DBHelper helper = new DBHelper(false);

            try
            {
                this.txtOutReqNo.Focus();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                //2014.06.25 START 저장버튼 클릭시 등록버튼 누름과 같은 처리
                //if  ((DBHelper.nvlString(this.cboPlantCode.Value) != "")
                //  && (this.txtOutReqNo.Text.Trim() != "")
                //  && (this.txtMoldCode.Text.Trim() != ""))
                if ((this.txtOutReqNo.Text.Trim() != "")
                  && (this.txtMoldCode.Text.Trim() != ""))
                    DoInsert();
                //  return;
                //2014.06.25 END

                base.DoSave();

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제

                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_TMD0200_D1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)     // 사업장 공장코드    
                          , helper.CreateParameter("OutReqNo", drRow["OutReqNo"].ToString(), DbType.String, ParameterDirection.Input)       // 출고의뢰번호 
                          , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input));     // 금형코드(금형 P/no(25) )         

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_MD0200_U1", CommandType.StoredProcedure
                          , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)     // 사업장 공장코드    
                          , helper.CreateParameter("OutReqDate", drRow["OutReqDate"].ToString(), DbType.String, ParameterDirection.Input)    // 출고의뢰일   
                          , helper.CreateParameter("OutReqNo", drRow["OutReqNo"].ToString(), DbType.String, ParameterDirection.Input)      // 출고의뢰번호   
                          , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)      // 금형코드   
                          , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)      // 품목   
                          , helper.CreateParameter("OutReqType", drRow["OutReqType"].ToString(), DbType.String, ParameterDirection.Input)    // 출고구분  
                          , helper.CreateParameter("OutFlag", drRow["OutFlag"].ToString(), DbType.String, ParameterDirection.Input)       // 출고처리여부   
                          , helper.CreateParameter("OutWorker", drRow["OutWorker"].ToString(), DbType.String, ParameterDirection.Input)     // 출고자OutDate 
                          , helper.CreateParameter("OutDate", drRow["OutDate"].ToString(), DbType.String, ParameterDirection.Input));     // 출고일

                            #endregion
                            break;
                    }
                }

                if (helper.RSCODE != "S")
                {
                    SException ex = new SException(helper.RSCODE, null);
                    throw ex;
                }
                helper.Commit();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                DoInquire();   //재조회 처리
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

        #region<METHOD AREA>
        private void bntInitialize_Click(object sender, EventArgs e)
        {
            //입력값초기화
            cboPlantCode.Value = "";
            cboOutReqType.Value = "";
            txtMoldCode.Text = "";
            txtMoldName.Text = "";
            txtOutReqNo.Text = "";
            txtItemCode.Text = "";
            txtItemName.Text = "";
        }

        private void bntInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
            //DoInquire(); //재 조회 처리
        }

        private void DoInsert()
        {
            //금형불출의뢰 등록 처리
            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);            //사업장 
            string sOutReqNo = this.txtOutReqNo.Text.Trim();                           //불출의뢰번호
            string sOutReqType = DBHelper.nvlString(this.cboOutReqType.Value);           //불출구분 
            string sMoldCode = this.txtMoldCode.Text.Trim();                           //금형코드 
            string sItemCode = this.txtItemCode.Text.Trim();                           //품목
            string sOutReqDate = string.Format("{0:yyyy-MM-dd}", CboOutReqDate.Value); ;  //불출의뢰일

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            if (sOutReqNo == "")
            {
                MessageBox.Show(Common.getLangText("불출의뢰번호를 먼저 생성 하세요", "MSG"));
                return;
            }

            if (sMoldCode == "")
            {
                MessageBox.Show(Common.getLangText("금형코드를 생성 하세요", "MSG"));
                return;
            }

            try
            {

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();

                helper.ExecuteNoneQuery("USP_MD0200_I1N", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)    // 공장(사업장)  
                                                        , helper.CreateParameter("OutReqNo", sOutReqNo, DbType.String, ParameterDirection.Input)     // 불출의뢰번호  
                                                        , helper.CreateParameter("OutReqType", sOutReqType, DbType.String, ParameterDirection.Input)   // 불출구분 
                                                        , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)     // 금형코드(금형 P/no(25) )          
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)     // 품목           
                                                        , helper.CreateParameter("OutReqDate", sOutReqDate, DbType.String, ParameterDirection.Input)); // 불출의뢰일
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
                //등록항목 초기화
                cboPlantCode.Value = "";
                cboOutReqType.Value = "";
                txtMoldCode.Text = Convert.ToString(null);
                txtMoldName.Text = Convert.ToString(null);
                txtOutReqNo.Text = Convert.ToString(null);
                txtItemCode.Text = Convert.ToString(null);
                txtItemName.Text = Convert.ToString(null);
                //DoInquire(); //재조회 처리

            }
        }

        private void btnmake_Click(object sender, EventArgs e)
        {
            //불출의뢰번호
            DBHelper helper = new DBHelper(false);

            string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);
            string TakingORDNo = string.Empty;
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;

            if (sPlantCode == "")
            {
                MessageBox.Show(Common.getLangText("사업장 정보를 입력하세요", "MSG"));
                return;
            }

            this.grid1.UpdateData();

            try
            {
                helper.ExecuteNoneQuery("USP_OutReqNoCreate_P1"
                                        , CommandType.StoredProcedure, ref RS_CODE, ref RS_MSG, ref TakingORDNo
                                        , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input));

                if (RS_CODE == "E") MessageBox.Show(RS_MSG);
                txtOutReqNo.Text = TakingORDNo.ToString();
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
                cboPlantCode.Value = Convert.ToString(grid1.ActiveRow.Cells["PlantCode"].Value);
                cboOutReqType.Value = Convert.ToString(grid1.ActiveRow.Cells["OutReqType"].Value);
                txtMoldCode.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldCode"].Value);
                txtMoldName.Text = Convert.ToString(grid1.ActiveRow.Cells["MoldName"].Value);
                txtItemCode.Text = Convert.ToString(grid1.ActiveRow.Cells["ItemCode"].Value);
                txtItemName.Text = Convert.ToString(grid1.ActiveRow.Cells["ItemName"].Value);
                //this.txtOutReqNo.Text = Convert.ToString(grid1.ActiveRow.Cells["OutReqNo"].Value);

            }
        }
        #endregion

    }
}
