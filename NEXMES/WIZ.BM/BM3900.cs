#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM3900                                                                                                                                                                          
//   Form Name    : PLC 주소 관리                                                                                                                                                                      
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19(2013-07-02 전면수정)                                                                                                                                                                     
//   Made By      : WIZCORE CO.,LTD                                                                                                                                                
//   Description  : 정보수집용 PLC 주소 관리                                                                                                                                                                
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{

    public partial class BM3900 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); //return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM3900()
        {
            InitializeComponent();
            // grid pop-up 처리를 위한 정의
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "", "", "", "" });  //작업장(WC)

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { "", "", "", "Y" });

        }

        #endregion

        #region BM3900_Load
        private void BM3900_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //  _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // InitColumnUltraGrid  190 174 102 111 141 198 175 122 139 86 136 121 107 83 86 105 92 92 158 154 132 188 80 120 80 80 120 80 80         
            _GridUtil.InitColumnUltraGrid(grid1, "PLCCode", "PLC 코드", true, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCAddr", "PLC 메모리 번지", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장코드", true, GridColDataType_emu.VarChar, 115, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장", true, GridColDataType_emu.VarChar, 141, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCAddrName", "PLC 메모리 번지 내용", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GetType", "항목코드", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProtoCol", "PLC 연결 프로토콜", true, GridColDataType_emu.VarChar, 125, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPAddress", "PLC IP 주소", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCPort", "PLC Port", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DataType", "PLC 읽기/쓰기구분", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LENGTH", "PLC Data 길이", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SeqNo", "INI순번", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ConvRule", "변환규칙", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TimeInterval", "수집간격(초)", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LastVal", "PLC 최근값", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LastDate", "최근갱신일시", true, GridColDataType_emu.DateTime24, 160, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LastRealVal", "최근 가치 정보 변환값", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PrevVal", "PLC 최근앞값", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PrevDate", "최근앞 갱신일시", true, GridColDataType_emu.DateTime24, 160, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PrevRealVal", "최근앞 가치 정보 변환값", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.DateTime, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.DateTime, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorNM", "수정자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE

            #endregion Grid MERGE

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                              
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("GetType");     //수집항목
            WIZ.Common.FillComboboxMaster(this.cboGetType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "GetType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCCode");     //PLC 코드
            WIZ.Common.FillComboboxMaster(this.cboPLCCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLCCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ProtoCol");     //PLC 연결 프로토콜
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProtoCol", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DataType");     //PLC 읽기/쓰기구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DataType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion

        }
        #endregion BM3900_Load

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
                string sPLCCode = DBHelper.nvlString(this.cboPLCCode_H.Value);           // PLC 코드
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);       // 사업장(공장)                                                                                                         
                string sWorkCenterCode = txtWorkCenterCode.Text.Trim();                  // 작업장코드
                string sGetType = DBHelper.nvlString(this.cboGetType_H.Value);           // 항목코드
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);           //사용여부                                                                                        



                grid1.DataSource = helper.FillTable("USP_BM3900_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLCCode", sPLCCode, DbType.String, ParameterDirection.Input)                     // PLC 코드                                                                 
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                 // 사업장(공장)                                                                 
                                                                    , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)       // 작업장코드                                                                             
                                                                    , helper.CreateParameter("GetType", sGetType, DbType.String, ParameterDirection.Input)                     // 항목코드                                                                 
                                                                    , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));                   //사용여부                                                                                                                                                                                                                                                                                                                       
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

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PLCCode");          // PLC 코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PLCAddr");          // PLC 메모리 번지
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");        // 사업장(공장)
                UltraGridUtil.ActivationAllowEdit(this.grid1, "WorkCenterCode");   // 작업장코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PLCAddrName");      // PLC 메모리 번지 내용
                UltraGridUtil.ActivationAllowEdit(this.grid1, "GetType");          // 항목코드
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ProtoCol");         // PLC 연결 프로토콜
                UltraGridUtil.ActivationAllowEdit(this.grid1, "IPAddress");        // PLC IP 주소
                UltraGridUtil.ActivationAllowEdit(this.grid1, "PLCPort");          // PLC Port
                UltraGridUtil.ActivationAllowEdit(this.grid1, "DataType");         // PLC 읽기/쓰기구분
                UltraGridUtil.ActivationAllowEdit(this.grid1, "LENGTH");           // PLC Data 길이
                UltraGridUtil.ActivationAllowEdit(this.grid1, "SeqNo");            // INI순번
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ConvRule");         // 변환규칙
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UnitCode");         // 단위
                UltraGridUtil.ActivationAllowEdit(this.grid1, "TimeInterval");     // 수집간격(초)

                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");          // 사용여부

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
                        if (drRow["PLCCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "PLC 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM3900_D1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLCCode", Convert.ToString(drRow["PLCCode"]), DbType.String, ParameterDirection.Input)         // PLC 코드
                                                                    , helper.CreateParameter("PLCAddr", Convert.ToString(drRow["PLCAddr"]), DbType.String, ParameterDirection.Input));         // PLC 메모리 번지

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM3900_I1N", CommandType.StoredProcedure
                            , helper.CreateParameter("PLCCode", Convert.ToString(drRow["PLCCode"]), DbType.String, ParameterDirection.Input)             // PLC 코드
                            , helper.CreateParameter("PLCAddr", Convert.ToString(drRow["PLCAddr"]), DbType.String, ParameterDirection.Input)             // PLC 메모리 번지
                            , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)           // 사업장(공장)
                            , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)      // 작업장코드
                            , helper.CreateParameter("PLCAddrName", Convert.ToString(drRow["PLCAddrName"]), DbType.String, ParameterDirection.Input)         // PLC 메모리 번지 내용
                            , helper.CreateParameter("GetType", Convert.ToString(drRow["GetType"]), DbType.String, ParameterDirection.Input)             // 항목코드
                            , helper.CreateParameter("ProtoCol", Convert.ToString(drRow["ProtoCol"]), DbType.String, ParameterDirection.Input)            // PLC 연결 프로토콜
                            , helper.CreateParameter("IPAddress", Convert.ToString(drRow["IPAddress"]), DbType.String, ParameterDirection.Input)           // PLC IP 주소
                            , helper.CreateParameter("PLCPort", Convert.ToString(drRow["PLCPort"]), DbType.String, ParameterDirection.Input)             // PLC Port
                            , helper.CreateParameter("DataType", Convert.ToString(drRow["DataType"]), DbType.String, ParameterDirection.Input)            // PLC 읽기/쓰기구분
                            , helper.CreateParameter("LENGTH", Convert.ToString(drRow["LENGTH"]), DbType.String, ParameterDirection.Input)              // PLC Data 길이
                            , helper.CreateParameter("SeqNo", (drRow["SeqNo"] == DBNull.Value) ? 0 : Convert.ToInt32(drRow["SeqNo"]), DbType.Int32, ParameterDirection.Input)               // INI순번
                            , helper.CreateParameter("ConvRule", Convert.ToString(drRow["ConvRule"]), DbType.String, ParameterDirection.Input)            // 변환규칙
                            , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)            // 단위
                            , helper.CreateParameter("TimeInterval", (drRow["TimeInterval"] == DBNull.Value) ? 0 : Convert.ToInt32(drRow["TimeInterval"]), DbType.Int32, ParameterDirection.Input)        // 수집간격(초)
                                                                                                                                                                                                          //    , helper.CreateParameter("LastVal", Convert.ToString(drRow["LastVal"]), DbType.String, ParameterDirection.Input)             // PLC 최근값
                                                                                                                                                                                                          //   , helper.CreateParameter("LastDate", (drRow["LastDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["LastDate"]), DbType.DateTime, ParameterDirection.Input)
                                                                                                                                                                                                          //, helper.CreateParameter("LastDate", Convert.ToDateTime(drRow["LastDate"]), DbType.Date, ParameterDirection.Input)            // 최근갱신일시
                                                                                                                                                                                                          //  , helper.CreateParameter("LastRealVal", Convert.ToString(drRow["LastRealVal"]), DbType.String, ParameterDirection.Input)         // 최근 가치 정보 변환값
                                                                                                                                                                                                          //  , helper.CreateParameter("PrevVal", Convert.ToString(drRow["PrevVal"]), DbType.String, ParameterDirection.Input)            // PLC 최근앞값
                                                                                                                                                                                                          //   , helper.CreateParameter("PrevDate", (drRow["PrevDate"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(drRow["PrevDate"]), DbType.DateTime, ParameterDirection.Input)
                                                                                                                                                                                                          //, helper.CreateParameter("PrevDate", Convert.ToDateTime(drRow["PrevDate"]), DbType.Date, ParameterDirection.Input)            // 최근앞 갱신일시
                                                                                                                                                                                                          //    , helper.CreateParameter("PrevRealVal", Convert.ToString(drRow["PrevRealVal"]), DbType.String, ParameterDirection.Input)         // 최근앞 가치 정보 변환값 
                            , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)                   // 사용유무 
                            , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));                         //                     

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_BM3900_U1N", CommandType.StoredProcedure
                           , helper.CreateParameter("PLCCode", Convert.ToString(drRow["PLCCode"]), DbType.String, ParameterDirection.Input)             // PLC 코드
                           , helper.CreateParameter("PLCAddr", Convert.ToString(drRow["PLCAddr"]), DbType.String, ParameterDirection.Input)             // PLC 메모리 번지
                           , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)           // 사업장(공장)
                           , helper.CreateParameter("WorkCenterCode", Convert.ToString(drRow["WorkCenterCode"]), DbType.String, ParameterDirection.Input)      // 작업장코드
                           , helper.CreateParameter("PLCAddrName", Convert.ToString(drRow["PLCAddrName"]), DbType.String, ParameterDirection.Input)         // PLC 메모리 번지 내용
                           , helper.CreateParameter("GetType", Convert.ToString(drRow["GetType"]), DbType.String, ParameterDirection.Input)             // 항목코드
                           , helper.CreateParameter("ProtoCol", Convert.ToString(drRow["ProtoCol"]), DbType.String, ParameterDirection.Input)            // PLC 연결 프로토콜
                           , helper.CreateParameter("IPAddress", Convert.ToString(drRow["IPAddress"]), DbType.String, ParameterDirection.Input)           // PLC IP 주소
                           , helper.CreateParameter("PLCPort", Convert.ToString(drRow["PLCPort"]), DbType.String, ParameterDirection.Input)             // PLC Port
                           , helper.CreateParameter("DataType", Convert.ToString(drRow["DataType"]), DbType.String, ParameterDirection.Input)            // PLC 읽기/쓰기구분
                           , helper.CreateParameter("LENGTH", Convert.ToString(drRow["LENGTH"]), DbType.String, ParameterDirection.Input)              // PLC Data 길이
                           , helper.CreateParameter("SeqNo", (drRow["SeqNo"] == DBNull.Value) ? 0 : Convert.ToInt32(drRow["SeqNo"]), DbType.Int32, ParameterDirection.Input)               // INI순번
                           , helper.CreateParameter("ConvRule", Convert.ToString(drRow["ConvRule"]), DbType.String, ParameterDirection.Input)            // 변환규칙
                           , helper.CreateParameter("UnitCode", Convert.ToString(drRow["UnitCode"]), DbType.String, ParameterDirection.Input)            // 단위
                           , helper.CreateParameter("TimeInterval", (drRow["TimeInterval"] == DBNull.Value) ? 0 : Convert.ToInt32(drRow["TimeInterval"]), DbType.Int32, ParameterDirection.Input)        // 수집간격(초)
                           , helper.CreateParameter("UseFlag", Convert.ToString(drRow["UseFlag"]), DbType.String, ParameterDirection.Input)                   // 사용유무 
                           , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));                         // 수정자                          

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLCCode");
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

        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의

        #endregion

    }
}
