#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TO0100
//   Form Name    : TOOL 마스터 
//   Name Space   : WIZ.CM.DLL
//   Created Date : 2012-12-19
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion
#region
/*-----------------------------
1. 작성자 : 전재현
2. 작성일 : 2012.12.12(목)
3. 기능 : 툴마스터데이터 조회
 ------------------------------*/
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion


namespace WIZ.CM
{
    public partial class TO0100 : WIZ.Forms.BaseMDIChildForm
    {

        #region <MEMBER AREA>

        UltraGridUtil _GridUtil = new UltraGridUtil();

        #endregion

        #region <CLASS CONSTRUCTOR>
        public TO0100()
        {
            InitializeComponent();
            BizTextBoxManager BIZPOP;
            BizGridManager bizGrid = new BizGridManager(grid1);
            BIZPOP = new BizTextBoxManager();
            ////TTO0100 : Tool 마스터
            ////- 1 : Code  2 : CodeName, param[0] : PlantCode, param[1] : Seq, param[2] : 사용여부, param[3] : 장착여부
            //BIZPOP.PopUpAdd(txtToolCode, txtToolName, "TTO0100", new object[] { cboPlantCode_H, "", cboUseFlag_H, "" });          //TOOl 팝업

            //   * TTO0100 : Tool 마스터
            //*          - 1 : Code  2 : CodeName, param[0] : PlantCode, param[1] : Seq, param[2] : 사용여부, param[3] : 장착여부
            //*          */
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtToolCode, txtToolName, "TTO0100", new object[] { cboPlantCode_H, "", cboUseFlag_H, "" });
        }
        #endregion

        #region <폼 초기화>
        private void TO0100_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.Caption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolCode", "TOOL 코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ToolName", "TOOL 이름", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Spec", "규격", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Unit", "단위", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InDate", "입고일자", false, GridColDataType_emu.YearMonthDay, 180, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdLine", "제품군", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PartType", "유형", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Abc", "ABCD", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Shelflife", "수명", false, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Right, true, true, "#,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ReqQty", "월소요량", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, true, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SftyQty", "안전재고", false, GridColDataType_emu.Double, 70, 100, Infragistics.Win.HAlign.Right, true, true, "#,###", "nnn,nnn,nnn", null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Buyer", "구매자", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Vend", "제작처", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PurLead", "구매리드타임", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, true, "#,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Price", "구매단가", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, true, "#,###", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseDate", "구매등록일", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USAGE", "사용여부", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "dec1", "dec1", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "dec2", "dec2", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Char1", "Char1", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Char2", "Char2", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LastDate", "LastDate", false, GridColDataType_emu.YearMonthDay, 180, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Log1", "Log1", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);



            _GridUtil.SetInitUltraGridBind(grid1);

            ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion
            #region 콤보박스

            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USAGE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);  //공장코드
                string sToolCode = txtToolCode.Text;
                string sToolName = txtToolName.Text;
                string sUseFlag = Convert.ToString(this.cboUseFlag_H.Value);      // 사용여부 

                grid1.DataSource = helper.FillTable("USP_TO0100_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("plantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("toolCode", sToolCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("toolName", sToolName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("useFlag", sUseFlag, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

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
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            int iRow = _GridUtil.AddRow(this.grid1);
            this.grid1.SetDefaultValue("PlantCode", "820");

            UltraGridUtil.ActivationAllowEdit(grid1, "PlantCode");
            UltraGridUtil.ActivationAllowEdit(grid1, "ToolCode");
            UltraGridUtil.ActivationAllowEdit(grid1, "ToolName");
            UltraGridUtil.ActivationAllowEdit(grid1, "Spec");
            UltraGridUtil.ActivationAllowEdit(grid1, "Unit");
            UltraGridUtil.ActivationAllowEdit(grid1, "UseDate");
            UltraGridUtil.ActivationAllowEdit(grid1, "ProdLine");
            UltraGridUtil.ActivationAllowEdit(grid1, "PartType");
            UltraGridUtil.ActivationAllowEdit(grid1, "ReqQty");
            UltraGridUtil.ActivationAllowEdit(grid1, "SftyQty");
            UltraGridUtil.ActivationAllowEdit(grid1, "Buyer");
            UltraGridUtil.ActivationAllowEdit(grid1, "Vend");
            UltraGridUtil.ActivationAllowEdit(grid1, "PurLead");
            UltraGridUtil.ActivationAllowEdit(grid1, "Price");
            UltraGridUtil.ActivationAllowEdit(grid1, "USAGE");
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>

        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                //string sPlantCode = "";
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["plantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            //param = new System.Data.Common.DbParameter[4];

                            //param[0] = helper.CreateParameter("@PLANTCODE", DBHelper.nvlString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input);
                            //param[1] = helper.CreateParameter("@TOOLCODE",  DBHelper.nvlString(drRow["ToolCode"].ToString()), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("@pRetCode",    DbType.String, ParameterDirection.Output, null, 1);
                            //param[3] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            //DBHelper.ExecuteNoneQuery("USP_TO0100_D1", CommandType.StoredProcedure, param);

                            //if (param[2].Value.ToString() == "E") throw new Exception(param[3].Value.ToString());

                            helper.ExecuteNoneQuery("USP_TO0100_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("TOOLCODE", Convert.ToString(drRow["ToolCode"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[29];
                            //param[0]  = helper.CreateParameter("@PlantCode", DBHelper.nvlString(drRow["PlantCode"]),  DbType.String, ParameterDirection.Input);
                            //param[1]  = helper.CreateParameter("@ToolCode",  DBHelper.nvlString(drRow["ToolCode"]),   DbType.String, ParameterDirection.Input);
                            //param[2]  = helper.CreateParameter("@ToolName",  DBHelper.nvlString(drRow["ToolName"]),   DbType.String, ParameterDirection.Input);
                            //param[3]  = helper.CreateParameter("@Spec",      DBHelper.nvlString(drRow["Spec"]),       DbType.String, ParameterDirection.Input);
                            //param[4]  = helper.CreateParameter("@Unit",      DBHelper.nvlString(drRow["Unit"]),       DbType.String, ParameterDirection.Input);
                            //param[5]  = helper.CreateParameter("@InDate",    DBHelper.nvlDateTime(drRow["InDate"]),   SqlDbType.DateTime, ParameterDirection.Input);
                            //param[6]  = helper.CreateParameter("@ProdLine",  DBHelper.nvlString(drRow["ProdLine"]),   DbType.String, ParameterDirection.Input);
                            //param[7]  = helper.CreateParameter("@PartType",  DBHelper.nvlString(drRow["PartType"]),   DbType.String, ParameterDirection.Input);
                            //param[8]  = helper.CreateParameter("@Status",    DBHelper.nvlString(drRow["Status"]),     DbType.String, ParameterDirection.Input);
                            //param[9]  = helper.CreateParameter("@Abc",       DBHelper.nvlString(drRow["Abc"]),        DbType.String, ParameterDirection.Input);
                            //param[10] = helper.CreateParameter("@Loc",       DBHelper.nvlString(drRow["STORAGELOCCODE"]),        DbType.String, ParameterDirection.Input);
                            //param[11] = helper.CreateParameter("@Shelflife", DBHelper.nvlInt(drRow["Shelflife"]),     DbType.String, ParameterDirection.Input);
                            //param[12] = helper.CreateParameter("@ReqQty",    DBHelper.nvlString(drRow["ReqQty"]),     DbType.String, ParameterDirection.Input);
                            //param[13] = helper.CreateParameter("@SftyQty",   DBHelper.nvlString(drRow["SftyQty"]),    DbType.String, ParameterDirection.Input);
                            //param[14] = helper.CreateParameter("@Buyer",     DBHelper.nvlString(drRow["Buyer"]),      DbType.String, ParameterDirection.Input);
                            //param[15] = helper.CreateParameter("@Vend",      DBHelper.nvlString(drRow["Vend"]),       DbType.String, ParameterDirection.Input);
                            //param[16] = helper.CreateParameter("@USAGE",     DBHelper.nvlString(drRow["USAGE"]),      DbType.String, ParameterDirection.Input);
                            //param[17] = helper.CreateParameter("@PurLead",   DBHelper.nvlInt(drRow["PurLead"]),       DbType.String, ParameterDirection.Input);
                            //param[18] = helper.CreateParameter("@Price",     DBHelper.nvlString(drRow["Price"]),      DbType.String, ParameterDirection.Input);
                            //param[19] = helper.CreateParameter("@UseDate",   DBHelper.nvlDateTime(drRow["UseDate"]),  SqlDbType.DateTime, ParameterDirection.Input);
                            //param[20] = helper.CreateParameter("@dec1",      DBHelper.nvlString(drRow["dec1"]),       DbType.String, ParameterDirection.Input);
                            //param[21] = helper.CreateParameter("@dec2",      DBHelper.nvlString(drRow["dec2"]),       DbType.String, ParameterDirection.Input);
                            //param[22] = helper.CreateParameter("@Char1",     DBHelper.nvlString(drRow["Char1"]),      DbType.String, ParameterDirection.Input);
                            //param[23] = helper.CreateParameter("@Char2",     DBHelper.nvlString(drRow["Char2"]),      DbType.String, ParameterDirection.Input);
                            //param[24] = helper.CreateParameter("@LastDate",  DBHelper.nvlDateTime(drRow["LastDate"]), SqlDbType.DateTime, ParameterDirection.Input);
                            //param[25] = helper.CreateParameter("@Log1",      DBHelper.nvlString(drRow["Log1"]),       DbType.String, ParameterDirection.Input);
                            //param[26] = helper.CreateParameter("@Maker",     this.WorkerID,                              DbType.String, ParameterDirection.Input);


                            //param[27] = helper.CreateParameter("@pRetCode",    DbType.String, ParameterDirection.Output, null, 1);
                            //param[28] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            //DBHelper.ExecuteNoneQuery("USP_TO0100_I1", CommandType.StoredProcedure, param);

                            //if (param[27].Value.ToString() == "E") throw new Exception(param[28].Value.ToString());

                            helper.ExecuteNoneQuery("USP_TO0100_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ToolCode", Convert.ToString(drRow["ToolCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ToolName", Convert.ToString(drRow["ToolName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Spec", Convert.ToString(drRow["Spec"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Unit", Convert.ToString(drRow["Unit"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InDate", drRow["InDate"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ProdLine", Convert.ToString(drRow["ProdLine"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PartType", Convert.ToString(drRow["PartType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Status", Convert.ToString(drRow["Status"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Abc", Convert.ToString(drRow["Abc"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STORAGELOCCODE", Convert.ToString(drRow["STORAGELOCCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Shelflife", Convert.ToString(drRow["Shelflife"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ReqQty", Convert.ToString(drRow["ReqQty"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SftyQty", Convert.ToString(drRow["SftyQty"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Buyer", Convert.ToString(drRow["Buyer"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Vend", Convert.ToString(drRow["Vend"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USAGE", Convert.ToString(drRow["USAGE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PurLead", Convert.ToString(drRow["PurLead"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Price", Convert.ToString(drRow["Price"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseDate", drRow["UseDate"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("dec1", Convert.ToString(drRow["dec1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("dec2", Convert.ToString(drRow["dec2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Char1", Convert.ToString(drRow["Char1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Char2", Convert.ToString(drRow["Char2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LastDate", drRow["LastDate"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Log1", Convert.ToString(drRow["Log1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[28];

                            //param[0]  = helper.CreateParameter("@PlantCode", DBHelper.nvlString(drRow["PlantCode"]),  DbType.String,  ParameterDirection.Input);
                            //param[1]  = helper.CreateParameter("@ToolCode",  DBHelper.nvlString(drRow["ToolCode"]),   DbType.String,  ParameterDirection.Input);
                            //param[2]  = helper.CreateParameter("@Spec",      DBHelper.nvlString(drRow["Spec"]),       DbType.String,  ParameterDirection.Input);
                            //param[3]  = helper.CreateParameter("@Unit",      DBHelper.nvlString(drRow["Unit"]),       DbType.String,  ParameterDirection.Input);
                            //param[4]  = helper.CreateParameter("@InDate",    DBHelper.nvlDateTime(drRow["InDate"]),   SqlDbType.DateTime, ParameterDirection.Input);
                            //param[5]  = helper.CreateParameter("@ProdLine",  DBHelper.nvlString(drRow["ProdLine"]),   DbType.String,  ParameterDirection.Input);
                            //param[6]  = helper.CreateParameter("@PartType",  DBHelper.nvlString(drRow["PartType"]),   DbType.String,  ParameterDirection.Input);
                            //param[7]  = helper.CreateParameter("@Status",    DBHelper.nvlString(drRow["Status"]),     DbType.String,  ParameterDirection.Input);
                            //param[8]  = helper.CreateParameter("@Abc",       DBHelper.nvlString(drRow["Abc"]),        DbType.String,  ParameterDirection.Input);
                            //param[9]  = helper.CreateParameter("@Loc",       DBHelper.nvlString(drRow["STORAGELOCCODE"]),        DbType.String,  ParameterDirection.Input);
                            //param[10] = helper.CreateParameter("@Shelflife", DBHelper.nvlString(drRow["Shelflife"]),  DbType.String,  ParameterDirection.Input);
                            //param[11] = helper.CreateParameter("@ReqQty",    DBHelper.nvlString(drRow["ReqQty"]),     DbType.String,  ParameterDirection.Input);
                            //param[12] = helper.CreateParameter("@SftyQty",   DBHelper.nvlString(drRow["SftyQty"]),    DbType.String,  ParameterDirection.Input);
                            //param[13] = helper.CreateParameter("@Buyer",     DBHelper.nvlString(drRow["Buyer"]),      DbType.String,  ParameterDirection.Input);
                            //param[14] = helper.CreateParameter("@Vend",      DBHelper.nvlString(drRow["Vend"]),       DbType.String,  ParameterDirection.Input);
                            //param[15] = helper.CreateParameter("@USAGE",     DBHelper.nvlString(drRow["USAGE"]),      DbType.String,  ParameterDirection.Input);
                            //param[16] = helper.CreateParameter("@PurLead",   DBHelper.nvlString(drRow["PurLead"]),    DbType.String,  ParameterDirection.Input);
                            //param[17] = helper.CreateParameter("@Price",     DBHelper.nvlString(drRow["Price"]),      DbType.String,  ParameterDirection.Input);
                            //param[18] = helper.CreateParameter("@UseDate",   DBHelper.nvlDateTime(drRow["UseDate"]),  SqlDbType.DateTime, ParameterDirection.Input);
                            //param[19] = helper.CreateParameter("@dec1",      DBHelper.nvlString(drRow["dec1"]),       DbType.String,  ParameterDirection.Input);
                            //param[20] = helper.CreateParameter("@dec2",      DBHelper.nvlString(drRow["dec2"]),       DbType.String,  ParameterDirection.Input);
                            //param[21] = helper.CreateParameter("@Char1",     DBHelper.nvlString(drRow["Char1"]),      DbType.String,  ParameterDirection.Input);
                            //param[22] = helper.CreateParameter("@Char2",     DBHelper.nvlString(drRow["Char2"]),      DbType.String,  ParameterDirection.Input);
                            //param[23] = helper.CreateParameter("@LastDate",  DBHelper.nvlDateTime(drRow["LastDate"]), SqlDbType.DateTime, ParameterDirection.Input);
                            //param[24] = helper.CreateParameter("@Log1",      DBHelper.nvlString(drRow["Log1"]),       DbType.String,  ParameterDirection.Input);
                            //param[25] = helper.CreateParameter("@Editor",    this.WorkerID,                              DbType.String,  ParameterDirection.Input);

                            //param[26] = helper.CreateParameter("@pRetCode",    DbType.String, ParameterDirection.Output, null, 1);
                            //param[27] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            //DBHelper.ExecuteNoneQuery("USP_TO0100_U1", CommandType.StoredProcedure, param);


                            //if (param[26].Value.ToString() == "E") throw new Exception(param[27].Value.ToString());

                            helper.ExecuteNoneQuery("USP_TO0100_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", Convert.ToString(drRow["PlantCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ToolCode", Convert.ToString(drRow["ToolCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Spec", Convert.ToString(drRow["Spec"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Unit", Convert.ToString(drRow["Unit"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InDate", drRow["InDate"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ProdLine", Convert.ToString(drRow["ProdLine"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PartType", Convert.ToString(drRow["PartType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Status", Convert.ToString(drRow["Status"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Abc", Convert.ToString(drRow["Abc"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("STORAGELOCCODE", Convert.ToString(drRow["STORAGELOCCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Shelflife", Convert.ToString(drRow["Shelflife"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ReqQty", Convert.ToString(drRow["ReqQty"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SftyQty", Convert.ToString(drRow["SftyQty"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Buyer", Convert.ToString(drRow["Buyer"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Vend", Convert.ToString(drRow["Vend"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USAGE", Convert.ToString(drRow["USAGE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PurLead", Convert.ToString(drRow["PurLead"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Price", Convert.ToString(drRow["Price"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseDate", drRow["UseDate"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("dec1", Convert.ToString(drRow["dec1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("dec2", Convert.ToString(drRow["dec2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Char1", Convert.ToString(drRow["Char1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Char2", Convert.ToString(drRow["Char2"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("LastDate", drRow["LastDate"], DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Log1", Convert.ToString(drRow["Log1"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();
                helper.Commit();
            }
            catch (Exception ex)
            {
                CancelProcess = true; // DO SAVE 진행중 오류시 조회 호출 안함
                helper.Rollback();
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region<btnERPDownLoad_Click>
        private void btnERPDownLoad_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_IF0100_I1", CommandType.StoredProcedure
                                                       , helper.CreateParameter("pProgID", "ERPDownLoader", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("pReqMessage", "Download", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("pParam1", "TTO0100", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("pParam2", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("pParam3", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("pParam4", "", DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("pUser", this.WorkerID, DbType.String, ParameterDirection.Input));
                helper.Commit();

                this.ShowDialog(Common.getLangText("정상적으로 처리되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                //if (param != null) { param = null; }
            }

        }
        #endregion

        #region<DoBaseSum>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "Price" });

        }
        #endregion


    }
}