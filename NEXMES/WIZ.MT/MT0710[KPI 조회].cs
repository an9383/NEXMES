#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MT0710
//   Form Name    : 작업지시 생성 및 확정
//   Name Space   : WIZ.AP
//   Created Date : 2017-01-01
//   Made By      :
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.MT
{
    public partial class MT0710 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();
        BizGridManager bizGridManager;

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable dtGrid = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public MT0710()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MT0710_Load(object sender, EventArgs e)
        {
            GridInitialize();

            #region --- Combobox & Popup Setting ---
            cbo_STARTDATE_H.Value = DateTime.Now;



            //cbo_ENDDATE_H.Value      = DateTime.Now;
            //cbo_NEWORDERDATE_H.Value = DateTime.Now.AddDays(1);

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion


        }

        private void GridInitialize()
        {
            try
            {
                _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "월", false, GridColDataType_emu.YearMonth, 120, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MO_DAY_PROD_AVG", "일별 평균 생산량", false, GridColDataType_emu.VarChar, 200, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MO_DAY_WORK_AVG", "일별 평균 작업시간", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MO_CYCLE_TIME", "사이클타임 (초/개)", false, GridColDataType_emu.VarChar, 200, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MO_DAY_ERROR_COUNT", "일별 평균 불량수량", false, GridColDataType_emu.VarChar, 200, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UV_DAY_PROD_AVG", "일별 평균 생산량", false, GridColDataType_emu.VarChar, 200, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UV_DAY_WORK_AVG", "일별 평균 작업시간", false, GridColDataType_emu.VarChar, 100, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UV_CYCLE_TIME", "사이클타임 (초/개)", false, GridColDataType_emu.VarChar, 200, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UV_DAY_ERROR_COUNT", "일별 평균 불량수량", false, GridColDataType_emu.VarChar, 200, true, true);

                string[] arrMerCol1 = { "MO_DAY_PROD_AVG", "MO_DAY_WORK_AVG", "MO_CYCLE_TIME", "MO_DAY_ERROR_COUNT" };
                string[] arrMerCol2 = { "UV_DAY_PROD_AVG", "UV_DAY_WORK_AVG", "UV_CYCLE_TIME", "UV_DAY_ERROR_COUNT" };
                _GridUtil.GridHeaderMerge(grid1, "A", "몰더 라인", arrMerCol1, null);
                _GridUtil.GridHeaderMerge(grid1, "B", "UV도장 라인", arrMerCol2, null);

                //_GridUtil.SetColumnTextHAlign(grid1, "PLANTCODE",      Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "WORKCENTERCODE", Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "ITEMCODE",       Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME",       Infragistics.Win.HAlign.Left);
                //_GridUtil.SetColumnTextHAlign(grid1, "ORDERQTY",       Infragistics.Win.HAlign.Right);
                //_GridUtil.SetColumnTextHAlign(grid1, "PRODQTY",        Infragistics.Win.HAlign.Right);

                //grid1.Columns["ORDERQTY"].Format = "#,##0";
                //grid1.Columns["PRODQTY"].Format  = "#,##0";

                //grid1.DisplayLayout.Bands[0].Columns["ORDERSTATUS"].Header.Fixed = true;

                //grid1.DisplayLayout.Bands[0].Columns["ORDERDATE"].Header.Appearance.ForeColor      = Color.LightSkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["ORDERTYPE"].Header.Appearance.ForeColor      = Color.LightSkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor       = Color.LightSkyBlue;
                //grid1.DisplayLayout.Bands[0].Columns["ORDERQTY"].Header.Appearance.ForeColor       = Color.LightSkyBlue;

                grid1.DisplayLayout.Bands[0].Columns["RECDATE"].CellActivation = Activation.Disabled;

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;

            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);
                string sDate = string.Format("{0:yyyy}", cbo_STARTDATE_H.Value);

                base.DoInquire();

                dtGrid = helper.FillTable("USP_MT0700_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("PC_CODE", "S2", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_DATE", sDate, DbType.String, ParameterDirection.Input));


                grid1.DisplayLayout.Bands[0].Columns["RECDATE"].CellActivation = Activation.Disabled;


                grid1.DataSource = dtGrid;
                grid1.DataBind();


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoNew()
        {
            //base.DoNew();

            //DBHelper helper = new DBHelper(false);
            //_GridUtil.Grid_Clear(grid1);
            //try
            //{
            //    if (bNew == true)
            //    {
            //        this.ShowDialog(Common.getLangText("작업하는 지시가 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
            //        return;
            //    }

            //    //_GridUtil.Grid_Clear(grid1);
            //    //grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //    //grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //    //grid1.DisplayLayout.Bands[0].Columns["CUSTNAME"].Header.Appearance.ForeColor = Color.LightSkyBlue;
            //    //grid1.DisplayLayout.Bands[0].Columns["REMARK"].Header.Appearance.ForeColor = Color.LightSkyBlue;

            //    //bNew = true;

            //    //string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);

            //    //int iRow = grid1.InsertRow();


            //    this.grid1.InsertRow();

            //    this.grid1.ActiveRow.Cells["MO_CYCLE_TIME"].Activation = Activation.Disabled;
            //    this.grid1.ActiveRow.Cells["UV_CYCLE_TIME"].Activation = Activation.Disabled;

            //    //사업장과 사용여부는 행 추가시 기본으로 세팅
            //    //this.grid1.ActiveRow.Cells["PLANTCODE"].Value = CModule.ToString(cbo_PLANTCODE_H.Value);


            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }

        public override void DoDelete()
        {
            //base.DoDelete();

            //this.grid1.DeleteRow();
        }

        public override void DoSave()
        {
            //DataTable dtChange = grid1.chkChange();

            //if (dtChange == null)
            //    return;

            //string sPlantCode = LoginInfo.PlantCode.Trim();
            //string sMONPROQTY = string.Empty;
            //string sWORKDAY = string.Empty;
            //string sDAYPROQTY = string.Empty;
            //string sTIMEPROQTY = string.Empty;
            //string sMONERRORQTY = string.Empty;
            //string sMONERORYEILD = string.Empty;
            //string sHRMIN = string.Empty;
            //string sHRHOUR = string.Empty;
            //string sRECDATE = string.Empty;


            //DBHelper helper = new DBHelper("", true);

            //try
            //{
            //    base.DoSave();

            //    foreach (DataRow drChange in dtChange.Rows)
            //    {
            //        switch (drChange.RowState)
            //        {
            //            case DataRowState.Deleted:
            //                #region --- 삭제 ---

            //                drChange.RejectChanges();

            //                sMONPROQTY = DBHelper.nvlString(drChange["MO_DAY_PROD_AVG"]);
            //                sWORKDAY = DBHelper.nvlString(drChange["MO_DAY_WORK_AVG"]);
            //                sDAYPROQTY = DBHelper.nvlString(drChange["MO_DAY_ERROR_COUNT"]);
            //                sTIMEPROQTY = DBHelper.nvlString(drChange["UV_DAY_PROD_AVG"]);
            //                sMONERRORQTY = DBHelper.nvlString(drChange["UV_DAY_WORK_AVG"]);                        
            //                sHRMIN = DBHelper.nvlString(drChange["UV_DAY_ERROR_COUNT"]);
            //                sRECDATE = string.Format("{0:yyyy-MM}", drChange["RECDATE"]);

            //                helper.ExecuteNoneQuery("USP_MT0710_I1", CommandType.StoredProcedure
            //              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("PC_CODE", "D1", DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_DATE", sRECDATE, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_PROD_AVG", sMONPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_WORK_AVG", sWORKDAY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_ERROR_COUNT", sDAYPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_PROD_AVG", sTIMEPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_WORK_AVG", sMONERRORQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_ERROR_COUNT", sMONERORYEILD, DbType.String, ParameterDirection.Input));
            //                #endregion
            //                break;
            //            case DataRowState.Added:

            //                #region --- 추가 ---                            
            //                sMONPROQTY = DBHelper.nvlString(drChange["MO_DAY_PROD_AVG"]);
            //                sWORKDAY = DBHelper.nvlString(drChange["MO_DAY_WORK_AVG"]);
            //                sDAYPROQTY = DBHelper.nvlString(drChange["MO_DAY_ERROR_COUNT"]);
            //                sTIMEPROQTY = DBHelper.nvlString(drChange["UV_DAY_PROD_AVG"]);
            //                sMONERRORQTY = DBHelper.nvlString(drChange["UV_DAY_WORK_AVG"]);
            //                sHRMIN = DBHelper.nvlString(drChange["UV_DAY_ERROR_COUNT"]);
            //                sRECDATE = string.Format("{0:yyyy-MM}", drChange["RECDATE"]);

            //                helper.ExecuteNoneQuery("USP_MT0710_I1", CommandType.StoredProcedure
            //              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("PC_CODE", "I1", DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_DATE", sRECDATE, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_PROD_AVG", sMONPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_WORK_AVG", sWORKDAY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_ERROR_COUNT", sDAYPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_PROD_AVG", sTIMEPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_WORK_AVG", sMONERRORQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_ERROR_COUNT", sMONERORYEILD, DbType.String, ParameterDirection.Input));
            //                #endregion
            //                break;
            //            case DataRowState.Modified:
            //                #region --- 수정 ---
            //                sMONPROQTY = DBHelper.nvlString(drChange["MO_DAY_PROD_AVG"]);
            //                sWORKDAY = DBHelper.nvlString(drChange["MO_DAY_WORK_AVG"]);
            //                sDAYPROQTY = DBHelper.nvlString(drChange["MO_DAY_ERROR_COUNT"]);
            //                sTIMEPROQTY = DBHelper.nvlString(drChange["UV_DAY_PROD_AVG"]);
            //                sMONERRORQTY = DBHelper.nvlString(drChange["UV_DAY_WORK_AVG"]);
            //                sHRMIN = DBHelper.nvlString(drChange["UV_DAY_ERROR_COUNT"]);
            //                sRECDATE = string.Format("{0:yyyy-MM}", drChange["RECDATE"]);

            //                helper.ExecuteNoneQuery("USP_MT0710_I1", CommandType.StoredProcedure
            //              , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("PC_CODE", "U1", DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_DATE", sRECDATE, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_PROD_AVG", sMONPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_WORK_AVG", sWORKDAY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_MO_DAY_ERROR_COUNT", sDAYPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_PROD_AVG", sTIMEPROQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_WORK_AVG", sMONERRORQTY, DbType.String, ParameterDirection.Input)
            //              , helper.CreateParameter("AS_UV_DAY_ERROR_COUNT", sMONERORYEILD, DbType.String, ParameterDirection.Input));
            //                #endregion
            //                break;
            //        }

            //        if (helper.RSCODE != "S")
            //        {
            //            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

            //            return;
            //        }
            //    }

            //    grid1.SetAcceptChanges();

            //    helper.Commit();

            //    DoInquire();
            //}
            //catch (Exception ex)
            //{
            //    helper.Rollback();

            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();

            //    ClosePrgFormNew();
            //}
        }
        #endregion

        #region < EVENT AREA >

        #endregion

        #region < METHOD AREA >

        #endregion


    }
}
