using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;

namespace WIZ.PP
{
    public partial class PP3300 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        BizTextBoxManager btbManager;
        PopUp_Biz _biz = new PopUp_Biz();

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region [ 생성자 ]
        public PP3300()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Form Load ]
        private void PP3300_Load(object sender, EventArgs e)
        {
            #region [ Grid1 셋팅 ]
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 110, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGDT", "실사일자", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BARCODE", "LOTNO", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 70, 70, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 70, 70, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "전산수량", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGQTY", "실사수량", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAKINGDATE", "실사반영일시", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //DtChange1 = (DataTable)grid1.DataSource;
            #endregion

            #region [ 콤보박스 및 팝업 ]
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");     //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = "1100";

            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "1000", "", "Y" }); //아이템 POP_UP

            #endregion
        }
        #endregion

        #region [ Tool Bar Area ]
        /// <summary>
        /// 조회
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sTakingDate = string.Format("{0:yyyy-MM-dd}", this.cboTakingDate_H.Value);
                string sItemCode = txtItemCode.Text.Trim();
                string sBarCode = txtBarCode.Text.Trim();

                rtnDtTemp = helper.FillTable("USP_PP3300_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)                                 // 공장
                                            , helper.CreateParameter("AS_TAKINGDT", sTakingDate, DbType.String, ParameterDirection.Input)                                 // 실사일자
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)                                 // 품목
                                            , helper.CreateParameter("AS_BARCODE", sBarCode, DbType.String, ParameterDirection.Input));                                 // 바코드

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["TAKINGDT"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                    //grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Top;
                    grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;

                    grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        #endregion

        #region [ User Method Area ]

        #endregion

        #region [ Event Area ]
        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            try
            {
                e.Row.Appearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion



    }
}
