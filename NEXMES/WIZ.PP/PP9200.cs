
#region <USING AREA>
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP9200 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        #endregion

        #region<CONSTRUCTOR>
        public PP9200()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region PP9200_Load
        private void PP9200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DeptCode", "팀구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StopM", "비가동공수(H)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdQTy", "실적수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StandardUPH", "표준공수(H)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InUPH", "투입공수(H)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Effect", "작업효율(%)", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

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
        #endregion PP9200_Load

        #region 조회
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.Value.ToString();
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

                grid1.DataSource = helper.FillTable("USP_PP9200_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 사업장(공장)    
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)             // 생산시작일자    
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                 // 생산  끝일자    
                                                                   , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)                   // 공정 코드       
                                                                   , helper.CreateParameter("CHK", sCHK, DbType.String, ParameterDirection.Input)                         // 공정 코드       
                                                                   , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)               // 공정 코드       
                                                                   , helper.CreateParameter("DeptCode", sDeptCode, DbType.String, ParameterDirection.Input)               // 라인 코드       
                                                                   , helper.CreateParameter("PARAM1", "", DbType.String, ParameterDirection.Input)                        // 라인 코드       
                                                                   , helper.CreateParameter("PARAM2", "", DbType.String, ParameterDirection.Input)                        // 라인 코드       
                                                                   , helper.CreateParameter("PARAM3", "", DbType.String, ParameterDirection.Input));                      // 라인 코드       
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

        //public override void DoBaseSum()
        //{
        //    base.DoBaseSum();
        //    UltraGridRow ugr = grid1.DoSummaries(new string[] { "ProdQTy", "StopM", "StandardUPH", "InUPH" });

        //    try
        //    {
        //        double dInUPH = Convert.ToDouble(ugr.Cells["InUPH"].Value());
        //        double dStandard = Convert.ToDouble(ugr.Cells["StandardUPH"].Value);
        //        if (dInUPH > 0)
        //            ugr.Cells["Effect"].Value = string.Format("{0:#,#.00}", dStandard / dInUPH * 100);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
