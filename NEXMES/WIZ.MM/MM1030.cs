#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1030
//   Form Name    : 월재고 이월 이력 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.MM
{
    public partial class MM1030 : WIZ.Forms.BaseMDIChildForm
    {
        DataSet rtnDsTemp = new DataSet();    //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통
        DataTable _DtTemp = new DataTable();    //임시로 사용할 데이터테이블 생성

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();

        Configuration appconfig;

        public MM1030()
        {
            InitializeComponent();
        }

        private void MM1030_Load(object sender, EventArgs e)
        {
            GridInit();

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("PLANTCODE", "");

            CboStartDate_H.Value = DateTime.Now;
            CboEndDate_H.Value = DateTime.Now;
        }

        private void GridInit()
        {
            try
            {
                // InitColumnUltraGrid
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "처리일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "일련번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "재고이월월", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "월마감기준일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "D_N", "등록자", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "PACKQTY", "등록일시", false, GridColDataType_emu.Double, 180, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid1);
            }
            catch
            {
            }
        }

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {


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

        public override void DoDownloadExcel()
        {
        }
        #endregion < TOOL BAR AREA >
    }
}
