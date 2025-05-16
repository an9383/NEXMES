#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM4200                                                                                                                                                                          
//   Form Name    : 전달사항 및 인수인계내역 등록                                                                                                                                                                     
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19(2013-12-05 전면수정)                                                                                                                                                                      
//   Made By      : WIZCORE                                                                                                                                               
//   Description  : 각종 전달사항 및 인수인계를 등록  관리 화면                                                                                                                                                                
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

#region <USING AREA>


using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{

    public partial class BM4200 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>
        // 변수나 Form에서 사용될 Class를 정의
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        //private DataTable DtChange = null;

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        // POP-UP 처리를 위한 관리용
        BizGridManager gridManager;
        BizTextBoxManager btbManager;

        #endregion

        #region < CONSTRUCTOR >
        public BM4200()
        {
            InitializeComponent();

            // POP-UP 처리 필요 ( 조회창 : 품목, grid : 품목, 검사항목 : InspCode)
            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode, "", "", "" });

            //grid pop-up 처리를 위한 정의
            gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "", "", "" });    //작업장
        }

        #endregion

        #region BM4200_Load
        private void BM4200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid  93 125 125 125 125 128 104 125 125 125 125 125 116 125 125 125 125 125 73 125           
            _GridUtil.InitColumnUltraGrid(grid1, "SeqNo", "순번", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StdDate", "기준일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", true, GridColDataType_emu.VarChar, 220, 220, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", true, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PDayTM", "주야", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ViewSeq", "표시순번", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CommInfo", "공통사항", true, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProError", "공정불량", true, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SendInfo", "전달사항", true, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OtherInfo", "기타", true, GridColDataType_emu.VarChar, 200, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            grid1.DisplayLayout.Bands[0].Columns["CommInfo"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Bands[0].Columns["ProError"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Bands[0].Columns["SendInfo"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Bands[0].Columns["OtherInfo"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;

            grid1.DisplayLayout.Override.DefaultRowHeight = 100;

            #region 콤보박스

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //공장                                                                                                                              
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0060_CODE("WorkCenterCode");  //라인
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WorkCenterCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");            //주야구분                                                                                                                 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PDayTM", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion BM4200_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sDate = string.Format("{0:yyyy-MM-dd}", cbo_date.Value);
                string sDate_to = string.Format("{0:yyyy-MM-dd}", cbo_dateto.Value);
                string sPlantCode = DBHelper.nvlString(cboPlantCode.Value, "");
                string sLineCode = txtWorkCenterCode.Text.Trim();
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value, "");

                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM4200_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("sDate", sDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("sDate_to", sDate_to, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WorkCenterCode", sLineCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

                grid1.DataBind();
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                int iRow = grid1.InsertRow();
                this.grid1.SetDefaultValue("PlantCode", WIZ.LoginInfo.PlantCode);
                UltraGridUtil.ActivationAllowEdit(this.grid1, "StdDate", iRow);         // 제목                  
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode", iRow);       // 내용                  
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode", iRow);  // 전체계시             
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterName", iRow);  // 전체계시    
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PDayTM", iRow);          // 적용사업장(공장)       
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ViewSeq", iRow);         // 적용공정코드 
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CommInfo", iRow);        // 적용공정명
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ProError", iRow);        // 적용 라인 코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "SendInfo", iRow);        // 적용 라인 명              
                UltraGridUtil.ActivationAllowEdit(this.grid1, "OtherInfo", iRow);       // WorkCenter코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag", iRow);         // WorkCenter명

                grid1.Rows[iRow].Cells["StdDate"].SetValue(System.DateTime.Now.ToString("yyyy-MM-dd"), true);
            }
            catch (Exception ex)
            {
                throw ex;
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
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

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

                            helper.ExecuteNoneQuery("USP_BM4200_D1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("SeqNo", drRow["SeqNo"].ToString(), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM4200_I1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("StdDate", drRow["StdDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PDayTM", drRow["PDayTM"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ViewSeq", drRow["ViewSeq"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CommInfo", drRow["CommInfo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ProError", drRow["ProError"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SendInfo", drRow["SendInfo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OtherInfo", drRow["OtherInfo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;

                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM4200_U1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("SeqNo", drRow["SeqNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("StdDate", drRow["StdDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PDayTM", drRow["PDayTM"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ViewSeq", drRow["ViewSeq"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CommInfo", drRow["CommInfo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ProError", drRow["ProError"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SendInfo", drRow["SendInfo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OtherInfo", drRow["OtherInfo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                helper.Commit();

            }
            catch (Exception ex)
            {
                helper.Rollback();
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion
    }
}
