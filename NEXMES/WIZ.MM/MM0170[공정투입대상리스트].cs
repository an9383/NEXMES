#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0170
//   Form Name    : 수입검사대기현황조회
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-21
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0170 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public MM0170()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0170_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "총필요수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPQTY", "공정창고수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMQTY", "출고대상수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MMQTY", "자재창고수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCOUNT", "품목건수", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMEA", "출고수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);

            _GridUtil.SetInitUltraGridBind(grid2);


            _GridUtil.InitializeGrid(this.grid3, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "OUTQTY", "현장출고수량", true, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "USERID", "작업자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid3);
            #endregion

            #region < COMBOBOX SETTING >
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_TSY0030_CODE("");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "USERID", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            #endregion

            #region < POPUP SETTING >
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" }); // 품목
            btbManager.PopUpAdd(txt_CustCode_H, txt_CustName_H, "BM0030", new object[] { cbo_PLANTCODE_H, "", "", "Y" }); // 거래처
            btbManager.PopUpAdd(txt_UserID_H, txt_UserName_H, "TSY0030", new object[] { cbo_PLANTCODE_H, "Y" });
            #endregion

            #region 기타
            cbo_STARTDATE_H.Value = DateTime.Now;
            cbo_ENDDATE_H.Value = DateTime.Now;

            WIZ.Control.GridExtendUtil.SetLink(null, grid2, Grid_Search2);


            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid3); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());
                string sCustCode = DBHelper.nvlString(txt_CustCode_H.Text.Trim());
                string sCustName = DBHelper.nvlString(txt_CustName_H.Text.Trim());

                string sUserID = DBHelper.nvlString(txt_UserID_H.Text.Trim());
                string sUserName = DBHelper.nvlString(txt_UserName_H.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_MM0170_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USERNAME", sUserName, DbType.String, ParameterDirection.Input)
                    );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    if (tabControl1.SelectedIndex == 0)
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                        return;
                    }
                }

                rtnDtTemp = helper.FillTable("USP_MM0170_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USERNAME", sUserName, DbType.String, ParameterDirection.Input)
                    );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }
                else
                {
                    if (tabControl1.SelectedIndex == 1)
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion

        private void Grid_Search2()
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid3); // 조회전 그리드 초기화

            try
            {
                string sPlantCode = DBHelper.nvlString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sRecDate = DBHelper.nvlString(grid2.ActiveRow.Cells["RECDATE"].Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());
                string sCustCode = DBHelper.nvlString(txt_CustCode_H.Text.Trim());
                string sCustName = DBHelper.nvlString(txt_CustName_H.Text.Trim());

                string sUserID = DBHelper.nvlString(txt_UserID_H.Text.Trim());
                string sUserName = DBHelper.nvlString(txt_UserName_H.Text.Trim());

                rtnDtTemp = helper.FillTable("USP_MM0170_S1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "S3", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", sRecDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USERNAME", sUserName, DbType.String, ParameterDirection.Input)
                    );

                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds(rtnDtTemp);
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        private void MM0170_Shown(object sender, EventArgs e)
        {
            btnOut.Enabled = (((WIZ.MAIN.ZA0003)this.MdiParent).GetToolBarStatus("SaveFunc"));
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (this.ShowDialog(Common.getLangText("현재 조회 조건으로 일괄 현장출고 하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sItemName = DBHelper.nvlString(txt_ITEMNAME_H.Text.Trim());
                string sCustCode = DBHelper.nvlString(txt_CustCode_H.Text.Trim());
                string sCustName = DBHelper.nvlString(txt_CustName_H.Text.Trim());

                string sUserID = WIZ.LoginInfo.UserID;

                helper.ExecuteNoneQuery("USP_MM0170_I1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PCODE", "I1", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("AS_USER", sUserID, DbType.String, ParameterDirection.Input)
                    );

                if (helper.RSCODE != "S")
                {
                    throw new Exception(helper.RSMSG);
                }

                helper.Commit();

                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
    }
}