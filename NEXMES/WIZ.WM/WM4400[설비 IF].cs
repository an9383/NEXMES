/*
  Form Name    : 설비 IF
  Created Date : 2020-07-22
  Made By      : 윤석현
  Description  : 일렉트로엠 설비 I/F
*/

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM4400 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataSet rtnDsTemp = new DataSet();

        string sUserID = WIZ.LoginInfo.UserID;
        DateTime dtNow = DateTime.Now;

        #endregion

        #region < CONSTRUCTOR >

        public WM4400()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void WM4400_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            //_GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, false, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "GOALDATE", "목표일자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목코드", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "GOALQTY", "목표수량", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Right, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.SetInitUltraGridBind(grid1);


            //grid1.Columns["GOALQTY"].Format = "#,##0";
            //grid2.Columns["QTY"].Format = "#,##0";

            #endregion

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #region COMBO BOX

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion



            #region POPUP

            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });                    //품목

            #endregion



        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼
        /// </summary>
        public override void DoInquire()
        {
            this._GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);
            try
            {

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", cbo_ENDDATE_H.Value);
                //string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());


                rtnDsTemp = helper.FillDataSet("USP_WM4400_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    //, helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_SDATE ", sStartDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_EDATE ", sEndDate, DbType.String, ParameterDirection.Input));


                //목표
                grid1.DataSource = rtnDsTemp.Tables[0];
                grid1.DataBinds();

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

        }






        #endregion
    }
}


