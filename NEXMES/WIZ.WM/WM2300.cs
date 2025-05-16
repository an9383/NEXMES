#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM2300
//   Form Name    :  제품창고 출고이력
//   Name Space   :  WIZ.WM
//   Created Date :  
//   Made By      :  WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Data.SqlClient;
using WIZ.PopUp;

#endregion

namespace WIZ.WM
{
    public partial class WM2300 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        #endregion

        #region < CONSTRUCTOR >
        public WM2300()
        {
            InitializeComponent();
        }
        #endregion

        #region  < WM2300_Load >
        private void WM2300_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                  // 공장(사업장)                                                             
            _GridUtil.InitColumnUltraGrid(grid1, "OutDate", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                        // 출고일자                                                                 
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                           // 출하품목                                                                 
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                           // 출하품목명             
            _GridUtil.InitColumnUltraGrid(grid1, "ShipQty", "납품예정수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);                      // 납품예정                                                                   
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "제품Lot 번호", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                      // 제품Lot 번호                                                             
            _GridUtil.InitColumnUltraGrid(grid1, "OutType", "출고구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                        // 출고구분                                                                 
            _GridUtil.InitColumnUltraGrid(grid1, "DeliveryNo", "출하번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                     // 출하지시번호                                                             
            _GridUtil.InitColumnUltraGrid(grid1, "DeliverySeqNo", "출하순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                  // 출하지시순번                                                             
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                       // 출고업체코드 
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                         // 업체명                                                                
            _GridUtil.InitColumnUltraGrid(grid1, "OutQty", "출고량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);                           // 출고량                                                                   
            _GridUtil.InitColumnUltraGrid(grid1, "OutWorker", "출고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                        // 출고자  
            _GridUtil.InitColumnUltraGrid(grid1, "OutWorkerNM", "출고자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                    // 출고자명                                                                      
            _GridUtil.InitColumnUltraGrid(grid1, "OutStemp", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                       // 출고일자                                                                 
            _GridUtil.InitColumnUltraGrid(grid1, "CarNo", "차량번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                          // 차량번호 
            _GridUtil.InitColumnUltraGrid(grid1, "CarDesc", "차량상세", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                        // 차량상세                                                                
            _GridUtil.InitColumnUltraGrid(grid1, "OutFlag", "출고완료여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                    // 출고완료여부                                                             
            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlag", "반영 여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);                      // 반영 여부(ERP I/F TABLE등)                                               
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "참조", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);                             // 참조(ERP 전송 SEQ NO등)      

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            #endregion

            #region --- ComboBox Setting ---

            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("OutType"); //출고구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("YesNo");
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProcFlag", rtnDtTemp, "CODE_ID", "CODE_NAME"); //반영 여부
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutFlag", rtnDtTemp, "CODE_ID", "CODE_NAME"); //출고완료여부
            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtSoldCust, txtSoldCustName, "TBM0301", new object[] { cboPlantCode_H, "", "" });
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

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);            // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);    // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);        // 일자 TO                                                                                       
                string sCustCode = txtSoldCust.Text.Trim();                              // 업체코드  
                string sItemCode = txtItemCode.Text.Trim();                              // 품목  

                grid1.DataSource = helper.FillTable("USP_WM2300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input) //사업장 공장코드
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input) //일자 FROM    
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)     //일자 TO      
                                                                    , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)   //업체코드      
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)); //품목  
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
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
                //e.Command.Parameters["@Editor"].Value = this.WorkerID;
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }
        #endregion
    }
}
