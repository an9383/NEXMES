#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0401
//   Form Name    : 자재 재고 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Configuration;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0401 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();
        private string plantCode = string.Empty; //plantcode default 설정

        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp1 = new DataTable(); // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >

        public MM0401()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // TBM0100 : 품목
            // 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, cboItemType_H });

            this.plantCode = CModule.GetAppSetting("Site", "10");

            lblLotNo.Visible = false;
            txtLotNo.Visible = false;
            lblInDate.Visible = false;
            cboStartInDate_H.Visible = false;
            sLabel2.Visible = false;
            cboEndInDate_H.Visible = false;



        }
        #endregion

        #region  < FORM LOAD >
        private void MM0400_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            #region ▶ GRID

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CNTITEM", "LOT 수량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY", "중(수)량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY1", "재고 중(수)량\r\n(ⓐ)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, false, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUMQTY2", "상차 대기 중(수)량\r\n(ⓑ)", false, GridColDataType_emu.Double, 140, 100, Infragistics.Win.HAlign.Right, false, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STOCKQTY", "중(수)량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTLOTNO", "업체 LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTSTATUS", "LOT상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region ▶ COMBOBOX
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboPlantCode_H.Value = plantCode;
            string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  // 제품구분
            WIZ.Common.FillComboboxMaster(this.cboItemType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sITEMTYPE = Convert.ToString(cboItemType_H.Value);
                string sItemCode = this.txtItemCode.Text;
                string sLOTNO = this.txtLotNo.Text;
                string srtInDate = Convert.ToString(cboStartInDate_H.Value);
                string endInDate = Convert.ToString(cboEndInDate_H.Value);
                string LS_TABIDX = string.Empty;

                if (tabControl1.SelectedTab.Index == 0)
                    LS_TABIDX = "TAB1";
                else
                    LS_TABIDX = "TAB2";

                rtnDtTemp = helper.FillTable("USP_MM0400_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMTYPE", sITEMTYPE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", srtInDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", endInDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TAB", LS_TABIDX, DbType.String, ParameterDirection.Input));
                if (LS_TABIDX == "TAB1")
                {
                    if (helper.RSCODE == "S")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid1.DataSource = rtnDtTemp;
                            grid1.DataBinds(rtnDtTemp);
                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid1);
                            this.ShowDialog("조회할 데이터가 없습니다.", Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    if (helper.RSCODE == "S")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid2.DataSource = rtnDtTemp;
                            grid2.DataBinds(rtnDtTemp);
                        }
                        else
                        {
                            _GridUtil.Grid_Clear(grid2);
                            this.ShowDialog("조회할 데이터가 없습니다.", Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }
                    else
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
        }
        #endregion

        #region < EVENT AREA >
        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                lblLotNo.Visible = false;
                txtLotNo.Visible = false;
                lblInDate.Visible = false;
                cboStartInDate_H.Visible = false;
                sLabel2.Visible = false;
                cboEndInDate_H.Visible = false;

            }
            else
            {
                lblLotNo.Visible = true;
                txtLotNo.Visible = true;
                lblInDate.Visible = true;
                cboStartInDate_H.Visible = true;
                sLabel2.Visible = true;
                cboEndInDate_H.Visible = true;

            }
        }

        #endregion

        #region < METHOD AREA >

        #endregion


    }
}


