#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  WM2000
//   Form Name    :  제품창고 입고
//   Name Space   :  WIZ.WM
//   Created Date :  2013.7.23
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
    public partial class WM2000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        #endregion

        #region < CONSTRUCTOR >
        public WM2000()
        {
            InitializeComponent();
        }
        #endregion

        #region  < WM2000_Load >
        private void WM2000_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명,    1. 칼럼명,     2. caption    3. colNotNullable,  4.colDataType,     5.columnWidth,
            // 6. maxLength,  7. HAlign,    8. visible,   9. editable,       10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);    // 공장(사업장)
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);           // 품목
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);             // 품목명
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "제품Lot 번호", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);      // 제품Lot 번호
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고수량", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);            // 입고수량
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);            // 단위
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);         // 창고코드
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고명", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);             // 창고명
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);  // 저장위치
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "저장위치명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null); // 저장위치명
            _GridUtil.InitColumnUltraGrid(grid1, "INTYPE", "입고구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);           // 입고구분 
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);            // 입고일
            _GridUtil.InitColumnUltraGrid(grid1, "INWORKER", "입고자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);         // 입고자
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);            // 등록자
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "등록자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);       // 등록자명 
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);       // 등록일자
            _GridUtil.InitColumnUltraGrid(grid1, "PROCFLAG", "반영 여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);      // 반영 여부(ERP I/F TABLE등)
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "참조", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);               // 참조(ERP 전송 SEQ NO등)   

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

            rtnDtTemp = _Common.GET_BM0000_CODE("InType"); //입고구분
            WIZ.Common.FillComboboxMaster(this.cboInType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
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

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);               // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);     // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);         // 일자 TO                                                                                       
                string sItemCode = txtItemCode.Text.Trim();                               // 품목  
                string sInType = Convert.ToString(cboInType_H.Value);                     // 입고구분     

                grid1.DataSource = helper.FillTable("USP_WM2000_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input) // 사업장 공장코드    
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input) // 일자 FROM          
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)     // 일자 TO            
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)   // 품목            
                                                                    , helper.CreateParameter("AS_INTYPE", sInType, DbType.String, ParameterDirection.Input));     // 입고구분   
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
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }
        #endregion
    }
}
