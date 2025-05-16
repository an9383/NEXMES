#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MM0800
//   Form Name    : 수입검사 대기  정보 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM0800 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable[] DtGrid3;
        DataTable DtChange = null;
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        #endregion

        #region < CONSTRUCTOR >

        public MM0800()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "ROH" });
            //   btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { cboPlantCode_H, "" });

        }
        #endregion

        #region  MM0800_Load
        private void MM0800_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRTDATE", "라벨발행일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "POSEQNO", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "업체", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "업체명", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PREINGROUPNO", "발행그룹번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "자재번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ISSUELOTSIZE", "수량(EA)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ISSUELOTBASEQTY", "중량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPLOTSIZE", "수량(EA)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPLOTBASEQTY", "중량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WAITINGLOTSIZE", "수량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WAITINGLOTBASEQTY", "중량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            DtChange = (DataTable)grid1.DataSource;

            string[] arrMerCol1 = { "ISSUELOTSIZE", "ISSUELOTBASEQTY" };
            string[] arrMerCol2 = { "INSPLOTSIZE", "INSPLOTBASEQTY" };
            string[] arrMerCol3 = { "WAITINGLOTSIZE", "WAITINGLOTBASEQTY" };

            _GridUtil.GridHeaderMerge(grid1, "A", "발행ⓐ", arrMerCol1, null);
            _GridUtil.GridHeaderMerge(grid1, "B", "수입검사대기ⓑ", arrMerCol2, null);
            _GridUtil.GridHeaderMerge(grid1, "C", "수입검사대기잔량ⓐ-ⓑ", arrMerCol3, null);
            // DtChange = (DataTable)grid1.DataSource;

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PRTDATE", "라벨발행일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PREINDATE", "가입고일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "POSEQNO", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PREINGROUPNO", "발행그룹번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTLOTNO", "자재번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTSIZE", "수량(EA)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, false, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTBASEQTY", "중량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPDATE", "검사일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPRESULT", "판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INDATE", "입고일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTSTATUS", "LOT 상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);
            // DtChange = (DataTable)grid2.DataSource;

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PREINDATE", "가입고일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PRTDATE", "라벨발행일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "POSEQNO", "순번", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PREINGROUPNO", "발행그룹번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTCODE", "업체", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTNAME", "업체명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTLOTNO", "자재번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTSIZE", "수량(EA)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, false, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTBASEQTY", "중량", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPDATE", "검사일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPRESULT", "판정결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INDATE", "입고일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTSTATUS", "LOT 상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid3);

            //string[] arrMerCol111 = { "INSPDATE", "INSPRESULT" };

            //_GridUtil.GridHeaderMerge(grid3, "B", "수입검사", arrMerCol111, null);


            #endregion


            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE_1("C", "Y");  // 단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //"InspResult", "검사결과"
            rtnDtTemp = _Common.GET_BM0000_CODE("InspResult");  //검사결과
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //"lotSTATUS",
            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //검사결과
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            cboPlantCode_H.Value = plantCode;
            sLabel4.Visible = false;
            System.DateTime datetoday = System.DateTime.Now;
            cboStartDate_H.Value = datetoday.AddDays(1 - datetoday.Day);
            DoInquire();

        }
        #endregion  MM0800_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DoFind();
        }

        private void DoFind()
        {
            if (!CheckData())
            {
                return;
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                //  base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                              // 공장코드     
                string sSrart = string.Format("{0:yyyy-MM-dd}", cboStartDate_H.Value);               // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);
                string sItemCode = this.txtItemCode_H.Text;                                             // 품목
                string sCOILNO = this.lblCoilNo.Text;                                               // 자재번호(코일번호에서 자재번호로 수정)
                string sPoNo = this.txtPoNo_H.Text.Trim();                                          // 발주번호
                string LS_TABIDX = string.Empty;
                if (tabControl1.SelectedTab.Index == 0) { LS_TABIDX = "TAB1"; } else { LS_TABIDX = "TAB2"; }

                rtnDtTemp = helper.FillTable("USP_MM0800_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("TAB", LS_TABIDX, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("STARTDATE", sSrart, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ENDDATE", sEnd, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PoNo", sPoNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("COILNO", sCOILNO, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (LS_TABIDX == "TAB1")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);
                        DtChange = rtnDtTemp;
                        DtGrid3 = new DataTable[rtnDtTemp.Rows.Count];
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        _GridUtil.Grid_Clear(grid2);


                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds(rtnDtTemp);
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid3);


                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
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
        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboStartDate_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", cboEndDate_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0) return;

            //   _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPONO = grid1.ActiveRow.Cells["PONO"].Value.ToString();      //GRID1.발행 그룹 번호 
                string sPREINGROUPNO = grid1.ActiveRow.Cells["PREINGROUPNO"].Value.ToString();      //GRID1.발행 그룹 번호   

                rtnDtTemp = helper.FillTable("USP_MM0800_S3", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PONO", sPONO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PREINGROUPNO", sPREINGROUPNO, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();


                if (rtnDtTemp.Rows.Count > 0)
                {
                    if (DtGrid3[grid1.ActiveRow.Index] == null)
                    {
                        DtGrid3[grid1.ActiveRow.Index] = rtnDtTemp;

                        grid2.DataSource = DtGrid3[grid1.ActiveRow.Index];
                        grid2.DataBinds();
                    }
                    else
                    {
                        grid2.DataSource = DtGrid3[grid1.ActiveRow.Index];
                        grid2.DataBinds();
                    }


                }
                else
                {
                    if (grid1.ActiveRow.Cells["ISSUELOTSIZE"].Value.ToString() == grid1.ActiveRow.Cells["INSPLOTSIZE"].Value.ToString())
                    {
                        grid1.DisplayLayout.ActiveRow.Cells["WHCODE"].Activation = Activation.NoEdit;
                        grid1.DisplayLayout.ActiveRow.Cells["STORAGE"].Activation = Activation.NoEdit;
                        _GridUtil.Grid_Clear(grid2);
                        if (this.ShowDialog(Common.getLangText("수입 검사 대기 신청이 완료된 품목입니다.\n수입 검사 대기 신청 취소하시겠습니까?", "MSG")) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            tabControl1.SelectedTab = tabControl1.Tabs[1];
                            DoInquire();
                            return;
                        }
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid2);
                        this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
                    }
                    return;
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


        #region
        /*   /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt;
            string TAB = string.Empty;
            string TTT = string.Empty;

            if (tabControl1.SelectedTab.Index == 0)
            {
                if (grid1.chkChange() != null)
                {
                    int j = 0;
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        if (grid1.Rows[i].Cells["CHK"].Value.ToString() != "True")
                        {
                            j++;
                        }
                    }

                    if (j == grid1.Rows.Count)
                    {
                        dt = grid2.chkChange();
                        TAB = "TAB1";
                    }
                    else
                    {
                        dt = grid1.chkChange();
                        TAB = "TAB0";
                    }
                    if (grid2.chkChange() != null)
                    {
                        TTT = "TAB1";
                    }
                }
                else
                {
                    dt = grid2.chkChange();
                    TAB = "TAB1";
                }
            }
            else
            {
                dt = grid3.chkChange();
                TAB = "TAB2";
            }

            if (dt == null) return;

            Save_1(dt, TAB, 0);

            if (TTT == "TAB1")
            {
                dt = grid2.chkChange();
                Save_1(dt, TTT, 1);
            }
            DoInquire();
        }

        public void Save_1(DataTable dt, string tab, int NUM)
        {
            int T = 0;
            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();
                if (NUM != 1)
                    if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                    {
                        CancelProcess = true;
                        return;
                    }

                //  base.DoSave();
                string RS_CODE = string.Empty;
                string RS_MSG = string.Empty;

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["CHK"].ToString().Trim() == "False")
                        {
                            T++;
                            this.ClosePrgFormNew();
                            if (T == dt.Rows.Count)
                            {
                                if (NUM == 0)
                                    this.ShowDialog("선택된 품목이 없습니다. 확인 후 다시 진행하세요.", WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            continue;

                        }

                        if (tab == "TAB2")
                        {
                            if (drRow["LOTSTATUS"].ToString().Trim() == "20")
                            {
                                this.ShowDialog("수입검사가 완료된 품목이 있습니다. Lot상태를 확인 후, 삭제해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            if (drRow["LOTSTATUS"].ToString().Trim() != "20" && drRow["LOTSTATUS"].ToString().Trim() != "10")
                            {
                                this.ShowDialog("입고 완료된 품목이 있습니다. Lot상태를 확인 후, 삭제해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                        }

                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            string lotno;
                            if (tab == "TAB0")
                                lotno = "";
                            else
                                lotno = drRow["LOTNO"].ToString();
                            helper.ExecuteNoneQuery("USP_MM0800_U3", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PREINGROUPNO", drRow["PREINGROUPNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LOTNO", lotno, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PONO", drRow["PONO"].ToString(), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TAB", tab, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
       }
*/
        #endregion
        #endregion

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                sLabel4.Visible = false;
                DoInquire();
            }
            else
            {
                sLabel4.Visible = true;
                DoInquire();
            }
        }


        private void grid1_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "CHK")
                return;

            this.grid1.ActiveRow.Cells["CHK"].Value = Convert.ToString(e.Cell.Value).ToUpper() == "TRUE" ? "False" : "True";
        }

        private void grid2_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "CHK")
                return;

            this.grid2.ActiveRow.Cells["CHK"].Value = Convert.ToString(e.Cell.Value).ToUpper() == "TRUE" ? "False" : "True";
        }

        private void grid1_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this.grid1.UpdateData();

            if (e.Cell.Column.ToString() != "CHK") { return; }

            try
            {
                string pValue = Convert.ToString(e.Cell.Row.Cells["CHK"].Value);

                if (this.DtGrid3[e.Cell.Row.Index] == null)
                {
                    DBHelper helper = new DBHelper(false);

                    try
                    {

                        string sPONO = grid1.ActiveRow.Cells["PONO"].Value.ToString();      //GRID1.발행 그룹 번호 
                        string sPREINGROUPNO = grid1.ActiveRow.Cells["PREINGROUPNO"].Value.ToString();      //GRID1.발행 그룹 번호   

                        rtnDtTemp = helper.FillTable("USP_MM0800_S3", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PONO", sPONO, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PREINGROUPNO", sPREINGROUPNO, DbType.String, ParameterDirection.Input));


                        if (helper.RSCODE == "E")
                        {
                            this.ShowDialog(helper.RSMSG);
                            return;
                        }

                        DtGrid3[e.Cell.Row.Index] = rtnDtTemp;
                    }
                    catch (Exception ex)
                    {
                        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                    }
                    finally
                    {
                        helper.Close();
                    }
                }

                for (int i = 0; i < this.DtGrid3[e.Cell.Row.Index].Rows.Count; i++)
                {
                    DtGrid3[e.Cell.Row.Index].Rows[i]["CHK"] = pValue;
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid2_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this.grid2.UpdateData();

            if (e.Cell.Column.ToString() != "CHK") { return; }

            try
            {
                bool bChk = false;
                int CNT = 0;
                for (int i = 0; i < this.grid2.Rows.Count; i++)
                {
                    if (Convert.ToString(DtGrid3[grid1.ActiveRow.Index].Rows[i]["CHK"]).ToUpper() == "TRUE")
                    {
                        bChk = true;
                        break;
                        //CNT++;
                    }
                }
                //if(CNT == this.grid2.Rows.Count)
                //    bChk = true;
                if (bChk == true)
                {
                    DtChange.Rows[this.grid1.ActiveRow.Index]["CHK"] = "True";

                }
                else
                {
                    DtChange.Rows[this.grid1.ActiveRow.Index]["CHK"] = "False";
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            string CHKINSP1 = string.Empty;
            DBHelper helper = new DBHelper(false);
            int UNINSP = 0;
            int INSP = 0;
            int cnt = 0;
            int unsave = 0;
            int unsave1 = 0;
            if (tabControl1.SelectedTab.Index == 0)
            {
                #region
                /*
                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    if (grid2.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    {
                        DataTable CHKINSP = helper.FillTable("USP_CHKINSP_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@ITEMCODE", grid2.Rows[i].Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            if (CHKINSP.Rows.Count > 0)
                            {
                                CHKINSP1 = Convert.ToString(CHKINSP.Rows[0]["INSPFLAG"]);
                            }
                        }

                        if (CHKINSP1 == "I") // 수입검사 대기
                        {
                            string PREINGROUPNO = grid2.Rows[i].Cells["PREINGROUPNO"].Value.ToString();
                            string LOTNO = grid2.Rows[i].Cells["LOTNO"].Value.ToString();
                            string PONO = grid2.Rows[i].Cells["PONO"].Value.ToString();
                            string TAB = "TAB1";

                            UPDATE_SAVE2(PREINGROUPNO, LOTNO, PONO, TAB);
                            INSP++;
                        }
                        else  // 재고 처리
                        {
                            string PLANTCODE = grid2.Rows[i].Cells["PLANTCODE"].Value.ToString();
                            string CUSTCODE = grid1.ActiveRow.Cells["CUSTCODE"].Value.ToString();
                            string ITEMCODE = grid2.Rows[i].Cells["ITEMCODE"].Value.ToString();
                            string PONO = grid2.Rows[i].Cells["PONO"].Value.ToString();
                            string LOTNO = grid2.Rows[i].Cells["LOTNO"].Value.ToString();
                            string PREINGROUPNO = grid2.Rows[i].Cells["PREINGROUPNO"].Value.ToString();
                            string WHCODE = grid1.ActiveRow.Cells["WHCODE"].Value.ToString();
                            string STORAGE = grid1.ActiveRow.Cells["STORAGE"].Value.ToString();
                            string UNITCODE = grid1.ActiveRow.Cells["UNITCODE"].Value.ToString();
                            string GRID = "grid2";
                            int index = grid1.ActiveRow.Index + 1;
                            if (WHCODE == "")
                            {
                                this.ShowDialog(Convert.ToString(index) + "번 행, 창고 코드를 입력해주세요.", Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            if (STORAGE == "")
                            {
                                this.ShowDialog(Convert.ToString(index) + "번 행, 위치 코드를 입력해주세요.", Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            UPDATE_SAVE1(PLANTCODE, CUSTCODE, ITEMCODE, PONO, LOTNO, PREINGROUPNO, WHCODE, STORAGE, UNITCODE, GRID);
                            UNINSP++;
                        }
                    }
                    else
                    {
                        unsave1++;
                    }
                    
                }
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    {
                        DataTable CHKINSP = helper.FillTable("USP_CHKINSP_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("@ITEMCODE", grid1.Rows[i].Cells["ITEMCODE"].Value.ToString(), DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            if (CHKINSP.Rows.Count > 0)
                            {
                                CHKINSP1 = Convert.ToString(CHKINSP.Rows[0]["INSPFLAG"]);
                            }
                        }

                        if (CHKINSP1 == "I") // 수입검사 대기
                        {
                            string PREINGROUPNO = grid1.Rows[i].Cells["PREINGROUPNO"].Value.ToString();
                            string LOTNO = "";
                            string PONO = grid1.Rows[i].Cells["PONO"].Value.ToString();
                            string TAB = "TAB0";

                            UPDATE_SAVE2(PREINGROUPNO, LOTNO, PONO, TAB);
                            INSP++;
                        }
                        else  // 재고 처리
                        {
                            string PLANTCODE = grid1.Rows[i].Cells["PLANTCODE"].Value.ToString();
                            string CUSTCODE = grid1.Rows[i].Cells["CUSTCODE"].Value.ToString();
                            string ITEMCODE = grid1.Rows[i].Cells["ITEMCODE"].Value.ToString();
                            string PONO = grid1.Rows[i].Cells["PONO"].Value.ToString();
                            string LOTNO = "";
                            string PREINGROUPNO = grid1.Rows[i].Cells["PREINGROUPNO"].Value.ToString();
                            string WHCODE = grid1.Rows[i].Cells["WHCODE"].Value.ToString();
                            string STORAGE = grid1.Rows[i].Cells["STORAGE"].Value.ToString();
                            string UNITCODE = grid1.Rows[i].Cells["UNITCODE"].Value.ToString();
                            string GRID = "grid1";

                            if (WHCODE == "" )
                            {
                                this.ShowDialog(i + "번 행, 창고 코드를 입력해주세요.", Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            if (STORAGE == "")
                            {
                                this.ShowDialog(i + "번 행, 위치 코드를 입력해주세요.", Forms.DialogForm.DialogType.OK);
                                return;
                            }
                            UPDATE_SAVE1(PLANTCODE, CUSTCODE, ITEMCODE, PONO, LOTNO, PREINGROUPNO, WHCODE, STORAGE, UNITCODE, GRID);
                            UNINSP++;
                        }
                    }
                    else
                    {
                        unsave++;
                    }
                }
                if (unsave == grid1.Rows.Count && unsave1 == grid2.Rows.Count)
                {
                    this.ShowDialog("처리할 데이터를 선택해주세요.", Forms.DialogForm.DialogType.OK);
                    return;
                }
                else
                    this.ShowDialog("수입검사 대기 : " + INSP + "건\n 재고 : " + UNINSP + "건 \n 처리되었습니다.", Forms.DialogForm.DialogType.OK);
                 */
                #endregion

                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    {
                        for (int j = 0; j < DtGrid3[i].Rows.Count; j++)
                        {
                            if (Convert.ToString(DtGrid3[i].Rows[j]["CHK"]) == "True")
                            {
                                //무검사 유검사 체크
                                DataTable CHKINSP = helper.FillTable("USP_CHKINSP_S1", CommandType.StoredProcedure
                                                                                      , helper.CreateParameter("@ITEMCODE", Convert.ToString(DtGrid3[i].Rows[j]["ITEMCODE"]), DbType.String, ParameterDirection.Input));

                                if (helper.RSCODE == "S")
                                {
                                    if (CHKINSP.Rows.Count > 0)
                                    {
                                        CHKINSP1 = Convert.ToString(CHKINSP.Rows[0]["INSPFLAG"]);
                                    }
                                }

                                if (CHKINSP1 == "I") // 유검사
                                {
                                    string PREINGROUPNO = Convert.ToString(DtGrid3[i].Rows[j]["PREINGROUPNO"]);
                                    string LOTNO = Convert.ToString(DtGrid3[i].Rows[j]["LOTNO"]);
                                    string PONO = Convert.ToString(DtGrid3[i].Rows[j]["PONO"]);
                                    string TAB = "TAB1";

                                    UPDATE_SAVE2(PREINGROUPNO, LOTNO, PONO, TAB);
                                    INSP++;
                                }
                                else  // 무검사 재고 처리
                                {
                                    string PLANTCODE = Convert.ToString(DtGrid3[i].Rows[j]["PLANTCODE"]);
                                    string CUSTCODE = grid1.Rows[i].Cells["CUSTCODE"].Value.ToString();
                                    string ITEMCODE = Convert.ToString(DtGrid3[i].Rows[j]["ITEMCODE"]);
                                    string PONO = Convert.ToString(DtGrid3[i].Rows[j]["PONO"]);
                                    string LOTNO = Convert.ToString(DtGrid3[i].Rows[j]["LOTNO"]);
                                    string PREINGROUPNO = Convert.ToString(DtGrid3[i].Rows[j]["PREINGROUPNO"]);
                                    string WHCODE = grid1.Rows[i].Cells["WHCODE"].Value.ToString();
                                    string STORAGE = grid1.Rows[i].Cells["STORAGE"].Value.ToString();
                                    string UNITCODE = grid1.Rows[i].Cells["UNITCODE"].Value.ToString();
                                    string GRID = "grid2";
                                    if (WHCODE == "")
                                    {
                                        this.ShowDialog((i + 1) + Common.getLangText("번 행, 창고 코드를 입력해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                                        return;
                                    }
                                    if (STORAGE == "")
                                    {
                                        this.ShowDialog((i + 1) + Common.getLangText("번 행, 위치 코드를 입력해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                                        return;
                                    }
                                    UPDATE_SAVE1(PLANTCODE, CUSTCODE, ITEMCODE, PONO, LOTNO, PREINGROUPNO, WHCODE, STORAGE, UNITCODE, GRID);
                                    UNINSP++;
                                }
                            }
                        }
                    }
                }
                if (UNINSP == 0 && INSP == 0)
                    this.ShowDialog(Common.getLangText("수입검사 대기 등록할 데이터를 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                else
                    this.ShowDialog("유검사 : " + INSP + "건\n무검사 : " + UNINSP + "건\n처리되었습니다.", Forms.DialogForm.DialogType.OK);
            }
            else
            {
                for (int i = 0; i < grid3.Rows.Count; i++)
                {
                    if (grid3.Rows[i].Cells["CHK"].Value.ToString() == "True")
                    {
                        if (grid3.Rows[i].Cells["LOTSTATUS"].Value.ToString() == "20")
                        {
                            this.ShowDialog(Common.getLangText("수입검사가 완료된 품목이 있습니다. Lot상태를 확인 후, 삭제해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (grid3.Rows[i].Cells["LOTSTATUS"].Value.ToString() != "20" && grid3.Rows[i].Cells["LOTSTATUS"].Value.ToString() != "10")
                        {
                            this.ShowDialog(Common.getLangText("입고 완료된 품목이 있습니다. Lot상태를 확인 후, 삭제해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        string PREINGROUPNO = grid3.Rows[i].Cells["PREINGROUPNO"].Value.ToString();
                        string LOTNO = grid3.Rows[i].Cells["LOTNO"].Value.ToString();
                        string PONO = grid3.Rows[i].Cells["PONO"].Value.ToString();
                        string TAB = "TAB2";

                        UPDATE_SAVE2(PREINGROUPNO, LOTNO, PONO, TAB);
                        cnt++;
                    }
                    else
                    {
                        unsave++;
                    }
                }

                if (unsave == grid3.Rows.Count)
                {
                    this.ShowDialog(Common.getLangText("처리할 데이터를 선택해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                }
                else
                    this.ShowDialog(cnt + Common.getLangText("건이 취소되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

            }

            DoInquire();

        }

        private void UPDATE_SAVE2(string PREINGROUPNO, string LOTNO, string PONO, string TAB)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                helper.ExecuteNoneQuery("USP_MM0800_U3", CommandType.StoredProcedure
                                                       , helper.CreateParameter("PREINGROUPNO", PREINGROUPNO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("LOTNO", LOTNO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("PONO", PONO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("TAB", TAB, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ThrowError(ex);
                MessageBox.Show(Convert.ToString(ex));
                return;
            }
            finally
            {
                helper.Close();
            }

        }
        private void UPDATE_SAVE1(string PLANTCODE, string CUSTCODE, string ITEMCODE, string PONO, string LOTNO, string PREINGROUPNO, string WHCODE, string STORAGE, string UNITCODE, string GRID)
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                helper.ExecuteNoneQuery("USP_MM0800_U4", CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE", PLANTCODE, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("CUSTCODE", CUSTCODE, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMCODE", ITEMCODE, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("PONO", PONO, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("LOTNO", LOTNO, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("PREINGROUPNO", PREINGROUPNO, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("WHCODE", WHCODE, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("STORAGE", STORAGE, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("UNITCODE", UNITCODE, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("GRID", GRID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ThrowError(ex);
                MessageBox.Show(Convert.ToString(ex));
                return;
            }
            finally
            {
                helper.Close();
            }

        }


    }
}
