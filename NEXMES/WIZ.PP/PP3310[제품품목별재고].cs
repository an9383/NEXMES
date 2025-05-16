#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP3300
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
using System.Drawing;
using WIZ.PopUp;

#endregion

namespace WIZ.PP
{
    public partial class PP3310 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public PP3310()
        {
            InitializeComponent();
        }
        #endregion

        #region  < PP3300_Load >
        private void PP3300_Load(object sender, EventArgs e)
        {
            #region --- Grid Setting ---
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITWGT", "단위중량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "재고수량(A)", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SAFESTOCK", "안전재고수량(B)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAXSTOCK", "적정재고수량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SHORTSTOCK", "과부족수량(A-B)", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region --- ComboBox Setting ---

            Common _Common = new Common();
            //        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("OVERNSHORT"); //조회구분
            WIZ.Common.FillComboboxMaster(this.cboOVERNSHORT_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion

            #region --- POP-Up Setting ---
            // 팝업창 생성
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            #endregion
        }
        #endregion  PP3300_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                     // 사업장 공장코드
                string sOVERNSHORT = Convert.ToString(cboOVERNSHORT_H.Value);                   // 조회구분
                string sItemCode = this.txtItemCode.Text;                                       // 품목           

                rtnDtTemp = helper.FillTable("USP_PP3310_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("OVERNSHORT", sOVERNSHORT, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(grid1.Rows[i].Cells["SHORTSTOCK"].Value) < 0)
                        {
                            // grid1.Rows[i].Cells["SHORTSTOCK"].Appearance.BackColor = Color.Red;
                            grid1.Rows[i].Appearance.BackColor = Color.Red;
                        }
                    }
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog(Common.getLangText("R00111", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
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

