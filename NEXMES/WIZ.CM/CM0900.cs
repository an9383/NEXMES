
#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class CM0900 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region<CONSTRUCTOR>
        public CM0900()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region <CM0900_Load>
        private void CM0900_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "작업장코드", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Availibility", "시간가동율(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GOODPRODRATE", "양품율(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Productivity", "성능가동율(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OEE", "종합효율(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STANDUPH", "표준UPH", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REALUPH", "생산UPH", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ST", "S/T", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");  //팀구분
            //rtnDtTemp = _Common.GET_TBM0000_CODE("DeptCode", @"ISNULL(RELCODE1, '') != '' ");  //팀구분
            WIZ.Common.FillComboboxMaster(this.cboDeptCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion


        }
        #endregion CM0900_Load

        #region <DoInquire>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString();                                         // 사업장(공장)
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sOPCode = this.txtOPCode.Text.Trim();
                string sCHK = string.Empty;
                string sItemCode = this.txtItemCode.Text.Trim();
                string sDeptCode = cboDeptCode.Value.ToString();
                switch (Convert.ToString(ultraOptionSet1.CheckedItem.Tag))
                {
                    case "L":
                        sCHK = "Y";

                        grid1.Columns["ITEMCODE"].Hidden = true;
                        grid1.Columns["ITEMNAME"].Hidden = true;

                        break;

                    case "I":
                        sCHK = "N";

                        grid1.Columns["ITEMCODE"].Hidden = false;
                        grid1.Columns["ITEMNAME"].Hidden = false;

                        break;
                }
                grid1.DataSource = helper.FillTable("USP_CM0900_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CHK", sCHK, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DeptCode", sDeptCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARAM1", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARAM2", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARAM3", "", DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 조회

        #region <METHOD AREA>



        #endregion

        #region<DoBaseSum>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(null, new string[] { "Availibility", "GOODPRODRATE", "Productivity", "OEE", "STANDUPH", "REALUPH", "ST" });
            //try
            //{
            //    double dAva = DBHelper.nvlDouble(ugr.Cells["Availibility"].Value);
            //    double dGood = DBHelper.nvlDouble(ugr.Cells["GOODPRODRATE"].Value);
            //    double dProd = DBHelper.nvlDouble(ugr.Cells["Productivity"].Value);
            //    ugr.Cells["OEE"].Value = string.Format("{0:#,#.00}", dAva * dGood * dProd * 100);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        #endregion

    }
}
