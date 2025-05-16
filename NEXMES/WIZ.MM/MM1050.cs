#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1050
//   Form Name    : 블록재고 부적합 처리
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
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM1050 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        private DataTable DtChange = null;

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string sTraNo = string.Empty;
        private string sTraType = string.Empty;
        private string sTraPlanDate = string.Empty;
        #endregion

        #region < CONSTRUCTOR >

        public MM1050()
        {
            InitializeComponent();
            this.plantCode = CModule.GetAppSetting("Site", "10");

        }
        #endregion

        #region  < MM1050_Load >
        private void MM1050_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CNTLOT", "수량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SUMQTY", "중량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ORDERNO", "반출증번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "OUTQTY", "중량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "OUTDATE", "반출일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "OUTWORKER", "반출등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region 콤보박스
            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "", "Y", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            cboPlantCode_H.Value = plantCode;
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (!CheckData())
            {
                return;
            }
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                      // 사업장 공장코드
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                    // 종료일자
                string sCustCode = this.txtCustCode.Text.Trim();                                 // 업체코드      
                string sItemCode = this.txtItemCode.Text.Trim();                                 // 업체코드 

                rtnDtTemp = helper.FillTable("USP_MM1050_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)         //사업부(공장)
                                                                    , helper.CreateParameter("STARTDATE", sSrart, DbType.String, ParameterDirection.Input)        //시작일자(시)
                                                                    , helper.CreateParameter("ENDDATE", sEnd, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   );

                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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

        #endregion

        private void grid1_ClickCell(object sender, EventArgs e)
        {

            if (this.grid1.Rows.Count == 0) return;

            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPLANTCODE = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();      //GRID1.공장 
                string sTRANO = grid1.ActiveRow.Cells["CUSTCODE"].Value.ToString();            //GRID1.반출번호 
                string STARTDATE = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                // 시작일자
                string ENDDATE = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                    // 종료일자

                rtnDtTemp = helper.FillTable("USP_MM1050_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("CUSTCODE", sTRANO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                DtChange = rtnDtTemp;
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

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            if (this.grid2.Rows.Count == 0) return;

            _GridUtil.Grid_Clear(grid3);

            DBHelper helper = new DBHelper(false);

            try
            {
                //         string sPLANTCODE = grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString();    //GRID2.공장
                string sTRANO = grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString();                //GRID2.반출번호   
                string CUSTCODE = grid1.ActiveRow.Cells["CUSTCODE"].Value.ToString();                 //GRID1.반출번호 
                string sITEMCODE = grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();                 //GRID2.품목명   
                string STARTDATE = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                   // 시작일자
                string ENDDATE = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                     // 종료일자

                rtnDtTemp = helper.FillTable("USP_MM1050_S3", CommandType.StoredProcedure
                                                            // , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("PLANTCODE", sTRANO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("CUSTCODE", CUSTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("STARTDATE", STARTDATE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ENDDATE", ENDDATE, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();


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

                //   DtChange = rtnDtTemp;
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
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtStart_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
    }
}
