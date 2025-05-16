#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD0460
//   Form Name    : 금형이동현황
//   Name Space   : WIZ.MD
//   Created Date : 2014-04-30
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MD
{
    public partial class MD0460 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public MD0460()
        {
            InitializeComponent();

        }
        #endregion

        #region < MD0460_Load >
        private void MD0460_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid3, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMTYPE", "품목유형", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMGROUP", "품목종류", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "PROCESSGROUP", "공정그룹", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "MAXSTOCK", "적정재고", true, GridColDataType_emu.Double, 80, 140, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "SAFESTOCK", "안전재고", true, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "PALLETQTY", "팔레트단위수량", true, GridColDataType_emu.Double, 110, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "BOXQTY", "박스단위수량", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "TANKQTY", "탱크단위수량", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCOST", "단가", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "COLORNAME", "색상명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, !true, true);
            //_GridUtil.InitColumnUltraGrid(gr3d1, "BACKCOLOR",        "색상",           true, GridColDataType_emu.VarChar,   100, 130, Infragistics.Win.HAlign.Right,  true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITWGT", "단위중량", true, GridColDataType_emu.Double, 100, 130, Infragistics.Win.HAlign.Right, true, true, "n,nnn.nnnn");
            _GridUtil.InitColumnUltraGrid(grid3, "UNITWGT_UNIT", "단위중량단위", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITPACK", "포장단위", true, GridColDataType_emu.Integer, 100, 130, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPFLAG", "수입검사여부", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITLENGTH", "길이", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, !true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITTHICK", "두께", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Right, !true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITWIDTH", "폭", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Right, !true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, !true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "GRADE", "강종", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, !true, true);
            //_GridUtil.InitColumnUltraGrid(gr3d1, "ITEMSPEC", "규격", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "MATERIALGRADE", "재질", true, GridColDataType_emu.VarChar, 100, 50, Infragistics.Win.HAlign.Left, !true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "CARTYPE", "차종", true, GridColDataType_emu.VarChar, 100, 10, Infragistics.Win.HAlign.Left, !true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "BASE_LIMIT", "유효기간", true, GridColDataType_emu.Float, 100, 10, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 80, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "REMARK", "비고", true, GridColDataType_emu.VarChar, 500, 90, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);


            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion

            #region --- POP-UP Setting ---
            // pop up 화면(gird POP-UP)
            // 2014.6.25 임영조 맊음
            //bizGrid = new BizGridManager(grid1);
            //bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });     //  품목POP_UP grid
            //bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });      // 금형 POP_UP grid

            ////조회용 POP 
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" }); //품목
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "BM0010", new object[] { cboPlantCode_H, "" }); //금형
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");     //위치
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0000_CODE("MoldInType");  //입고구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldInType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_BM0000_CODE("OutReqType");     //출구분
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutReqType", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();  //사업장, 품목, 금형 
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sItemCode = DBHelper.nvlString(txtMoldCode.Text.Trim());
                string sItemName = DBHelper.nvlString(txtMoldName.Text.Trim());
                string sItemType = "";
                string sUseFlag = "";

                DataTable rtnDtTemp = helper.FillTable("USP_BM0010_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds(rtnDtTemp);
                }
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

        public override void DoSave()
        {
            base.DoSave();


        }
        #endregion

        #region <METHOD AREA>

        private void Gird2_Search(UltraGridRow dr)
        {
            DBHelper helper = new DBHelper(false);

            string sMajorCode = DBHelper.nvlString(dr.Cells["ITEMCODE"].Value);
            string sSystemID = WIZ.Common.SystemID;
            string sLang = WIZ.Common.Lang;

            DataTable dt = helper.FillTable("UDP_MD0450_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_ITEMCODE", sMajorCode, DbType.String, ParameterDirection.Input)
                                                         );

            grid2.DataSource = dt;
            grid2.DataBinds();
        }

        private void grid3_ClickCell(object sender, ClickCellEventArgs e)
        {
            Gird2_Search(e.Cell.Row);
        }
        #endregion

    }
}

