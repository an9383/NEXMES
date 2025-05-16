#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1410
//   Form Name    : 자재생산투입이력
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM1410 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        #endregion

        #region < CONSTRUCTOR >
        public MM1410()
        {
            InitializeComponent();
        }
        #endregion

        #region  < MM1410_Load >
        private void MM1410_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "출고(투입)일자", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "자재Lot번호", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTQTY", "출고량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTSEQNO", "출고SeqNo", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTREQNO", "출고요청번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INWORKCENTERCODE", "투입작업라인", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "투입작업라인명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "출고관련사항(비고)", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTWORKER", "출고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTSTEMP", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region --- ComboBox Setting ---

            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region --- POP-Up Setting ---
            // 팝업창 생성
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, "", "", "" });
            #endregion
        }
        #endregion  MM1410_Load

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
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                     // 사업장 공장코드
                string sOUTDATE_FROM = string.Format("{0:yyyy-MM-dd}", cboPlanIndate1_H.Value); // 라벨발행일자(시)
                string sOUTDATE_TO = string.Format("{0:yyyy-MM-dd}", cboPlanIndate2_H.Value);   // 라밸발행일자(종)
                string sItemCode = this.txtItemCode.Text;                                       // 품목           
                string sInWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                  // 투입작업장  

                grid1.DataSource = helper.FillTable("USP_MM1410_S1N", CommandType.StoredProcedure
                                                                     , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                  //사업부(공장)
                                                                     , helper.CreateParameter("OUTDATE_FROM", sOUTDATE_FROM, DbType.String, ParameterDirection.Input)            //라벨발행일자(시)
                                                                     , helper.CreateParameter("OUTDATE_TO", sOUTDATE_TO, DbType.String, ParameterDirection.Input)                //라밸발행일자(종)
                                                                     , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)                    //품목
                                                                     , helper.CreateParameter("INWORKCENTERCODE", sInWorkCenterCode, DbType.String, ParameterDirection.Input));  //투입작업장              	
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
    }
}

