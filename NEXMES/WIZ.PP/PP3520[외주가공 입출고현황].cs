#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP3520
//   Form Name    : 외주가공 입출고 현황
//   Name Space   : WIZ.MM
//   Created Date : 2017-04-20
//   Made By      : WIZCORE 남부사무소 개발팀 사원 윤근욱
//   Description  : 외주가공 입출고현황  조회화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP3520 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        #endregion

        #region < CONSTRUCTOR >
        public PP3520()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM_LOAD >
        private void PP3520_Load(object sender, EventArgs e)
        {
            #region < GRID >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "공정재고 LOTNO", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "입출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FRWHCODE", "출고위치", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOWHCODE", "입고위치", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "수량", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region < COMBOBOX >
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = "10";

            rtnDtTemp = _Common.GET_BM0030_CODE(""); //거래처
            WIZ.Common.FillComboboxMaster(this.cboCustCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FRWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TOWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE");    //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FRWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TOWHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cboStartDate_H.Value = DateTime.Now.AddDays(-7);
            cboEndDate_H.Value = DateTime.Now;
            #endregion

            #region < POP-UP >
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sItemCode = this.txtItemCode_H.Text.Trim();
                string sLotNo = this.txtLOTNO_H.Text.Trim();
                string sCustCode = this.cboCustCode_H.Value.ToString();
                string sStartDate = this.cboStartDate_H.Value.ToString().Substring(0, 10);
                string sEndDate = this.cboEndDate_H.Value.ToString().Substring(0, 10);

                rtnDtTemp = helper.FillTable("USP_PP3520_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));



                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count <= 0)
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }

                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            base.DoSave();
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #endregion

        #region < METHOD AREA >
        // Form에서 사용할 함수나 메소드를 정의
        #endregion


    }
}
