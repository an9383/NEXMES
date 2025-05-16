#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0020
//   Form Name    : 제품 재고 이력 조회
//   Name Space   : WIZ.WM
//   Created Date : 
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0020 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        Common _Common = new Common();

        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public WM0020()
        {
            InitializeComponent();
        }
        #endregion

        #region  < FORM LOAD >
        private void WM0020_Load(object sender, EventArgs e)
        {
            #region GRID SETTING

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWQTY", "재고량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

            grid1.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목유형", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWQTY", "재고량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);

            grid2.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMTYPE", "구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "STORAGELOCCODE", "저장위치", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "NOWQTY", "재고량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);

            grid3.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "NOWQTY", "재고량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid4, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

            grid4.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid4);

            _GridUtil.InitializeGrid(this.grid5, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid5, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "NOWQTY", "재고량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid5, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);

            grid5.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid5);

            _GridUtil.InitializeGrid(this.grid6, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid6, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid6, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid6, "NOWQTY", "재고량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid6, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false);

            grid6.Columns["NOWQTY"].Format = "#,##0";

            _GridUtil.SetInitUltraGridBind(grid6);




            #endregion

            #region COMBOBOX SETTING

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0080_CODE(""); //창고
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid5, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            GetWhCode();

            rtnDtTemp = _Common.GET_BM0090_CODE(""); //저장위치
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "STORAGELOCCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE");  //제품구분
            WIZ.Common.FillComboboxMaster(this.cbo_ITEMTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP SETTING

            //품목
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

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

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sWhCode = Convert.ToString(cbo_WHCODE_H.Value);
                string sItemType = Convert.ToString(cbo_ITEMTYPE_H.Value);
                string sItemCode = this.txt_ITEMCODE_H.Text.Trim();
                string sLotNo = this.txt_LOTNO_H.Text.Trim();
                string sTabIdx = string.Empty;

                if (tabControl1.SelectedTab.Index == 0)
                    sTabIdx = "TAB1";
                else if (tabControl1.SelectedTab.Index == 1)
                    sTabIdx = "TAB2";
                else
                    sTabIdx = "TAB3";

                rtnDtTemp = helper.FillTable("USP_WM0020_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_TAB", sTabIdx, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {

                    if (sTabIdx == "TAB1")
                    {
                        grid1.DataSource = rtnDtTemp;
                        //grid1.DataSource = WIZ.UltraGridUtil.SetSubTotalUltraGrid(grid1, rtnDtTemp, "ITEMTYPE", "[ 총 합계 ]", "PLANTCODE", "NOWQTY", "SUM");
                        grid1.DataBinds(rtnDtTemp);

                    }
                    else if (sTabIdx == "TAB2")
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds(rtnDtTemp);
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    return;
                }

                if (rtnDtTemp.Rows.Count > 0)
                {
                    if (sTabIdx == "TAB2")
                    {
                        rtnDtTemp = helper.FillTable("USP_WM0020_S2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                        grid4.DataSource = rtnDtTemp;
                        grid4.DataBinds(rtnDtTemp);

                        rtnDtTemp = helper.FillTable("USP_WM0020_S3", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                        grid5.DataSource = rtnDtTemp;
                        grid5.DataBinds(rtnDtTemp);
                    }
                    else if (sTabIdx == "TAB3")
                    {
                        rtnDtTemp = helper.FillTable("USP_WM0020_S2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WHCODE", sWhCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                        grid6.DataSource = rtnDtTemp;
                        grid6.DataBinds(rtnDtTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        #endregion

        #region < USER METHOD AREA >
        private void GetWhCode()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_WM0020_S4", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));

                WIZ.Common.FillComboboxMaster(this.cbo_WHCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region < EVENT AREA >
        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);
            _GridUtil.Grid_Clear(grid4);
            _GridUtil.Grid_Clear(grid5);
            _GridUtil.Grid_Clear(grid6);

            if (tabControl1.SelectedTab.Index == 0) // 품목별 재고
            {
                lbl_WHCODE_H.Visible = false;
                cbo_WHCODE_H.Visible = false;
                lbl_LOTNO_H.Visible = false;
                txt_LOTNO_H.Visible = false;
            }
            else if (tabControl1.SelectedTab.Index == 1) // 창고별 재고
            {
                lbl_WHCODE_H.Visible = true;
                cbo_WHCODE_H.Visible = true;
                lbl_LOTNO_H.Visible = false;
                txt_LOTNO_H.Visible = false;
            }
            else //LOTNO 별 재고
            {
                lbl_WHCODE_H.Visible = true;
                cbo_WHCODE_H.Visible = true;
                lbl_LOTNO_H.Visible = true;
                txt_LOTNO_H.Visible = true;
            }
        }

        #endregion 
    }
}
