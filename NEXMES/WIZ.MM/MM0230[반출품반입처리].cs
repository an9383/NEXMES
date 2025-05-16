#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0230
//   Form Name    : 반출품 반입처리(반출증 기준)
//   Name Space   : WIZ.MM
//   Created Date : 2015-09-17
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
    public partial class MM0230 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable dtTemp = new DataTable();
        DataTable DtChange = new DataTable();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil();

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string sTraNo = string.Empty;
        //private string sPlantCode = LoginInfo.PlantCode;
        //private int rowindex;
        #endregion

        #region < CONSTRUCTOR >

        public MM0230()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode_H, txtCustName_H, "TBM0300", new object[] { "", "Y", "" });
            this.plantCode = CModule.GetAppSetting("Site", "10");

        }
        #endregion

        #region  MM0230_Load
        private void MM0230_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            #region Grid 셋팅 //100 130 100 196 165 100 87 123 123 100 201 100 100 191 228 100 100
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //_GridUtil.InitColumnUltraGrid(grid1, "CHK",            "선택",         false, GridColDataType_emu.CheckBox,100, 100, Infragistics.Win.HAlign.Center, false,false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRADATE", "반출증등록일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRAPLNDATE", "반출예정일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRANO", "반출증번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRATYPE", "반출증유형", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRASTATUS", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARCARRYDATE", "상차일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARCARRYPERSON", "상차담당자", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTPERSON", "출고담당자", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TRANO", "반출증번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cboPlantCode.Value = plantCode;
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);

            rtnDtTemp = _Common.GET_BM0000_CODE("LOTSTATUS");  //LOT상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "LOTSTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TRASTATUS");  //LOT상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TRASTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TRATYPE");  //LOT상태
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TRATYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion  MM0230_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            DBHelper helper = new DBHelper(false);
            try
            {

                if (!CheckData())
                {
                    return;
                }
                string sPlantCode = Convert.ToString(cboPlantCode.Value);                   // 공장코드
                string sStartdate = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEnddate = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sCustCode = this.txtCustCode_H.Text.Trim();
                string sTrano = this.txtTraNo_H.Text.Trim();
                string sChktrano = Convert.ToString(lblChkTrano_H.Checked);

                dtTemp = helper.FillTable("USP_MM0230_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("STARTDATE", sStartdate, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("ENDDATE", sEnddate, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("TRANO", sTrano, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("CHKTRANO", sChktrano, DbType.String, ParameterDirection.Input));



                this.ClosePrgFormNew();
                if (dtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = dtTemp;
                    grid1.DataBinds(dtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (grid1.Rows.Count == 0)
            {
                return;
            }

            this.grid2.UpdateData();
            DtChange = (DataTable)grid2.DataSource;

            DBHelper helper = new DBHelper("", true);
            for (int i = 0; i < this.DtChange.Rows.Count; i++)
            {
                if (Convert.ToString(DtChange.Rows[i]["CHK"]) == "False") continue;

                helper.ExecuteNoneQuery("USP_MM0230_I1", CommandType.StoredProcedure
                                        , helper.CreateParameter("PlantCode", Convert.ToString(DtChange.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("TraNo", sTraNo, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("LotNo", Convert.ToString(DtChange.Rows[i]["MATLOTNO"]), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("ItemCode", Convert.ToString(DtChange.Rows[i]["ItemCode"]), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("Qty", Convert.ToDouble(DtChange.Rows[i]["LOTQTY"]), DbType.Double, ParameterDirection.Input)
                                        , helper.CreateParameter("UnitCode", Convert.ToString(DtChange.Rows[i]["UNITCODE"]), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("MakeDate", Convert.ToString(DtChange.Rows[i]["MAKEDATE"]), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                       );

                if (helper.RSCODE == "E")
                {

                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    helper.Rollback();
                    return;
                }
            }

            this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            helper.Commit();
            DoInquire();

        }

        #endregion

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

        private void grid1_ClickCell(object sender, EventArgs e)
        {

            if (this.grid1.Rows.Count == 0) return;

            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPLANTCODE = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();      //GRID1.공장 
                string sTRANO = grid1.ActiveRow.Cells["TRANO"].Value.ToString();             //GRID1.반출번호  

                rtnDtTemp = helper.FillTable("USP_MM0230_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRANO", sTRANO, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();


                if (rtnDtTemp.Rows.Count > 0)
                {
                    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    {
                        rtnDtTemp.Rows[i].BeginEdit();
                        rtnDtTemp.Rows[i]["CHK"] = true;
                        rtnDtTemp.Rows[i].EndEdit();
                    }
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);

                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
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
    }
}

