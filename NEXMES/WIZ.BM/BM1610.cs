#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1610
//   Form Name    : 생산품목별 금형관리
//   Name Space   : WIZ.BM
//   Created Date : 2014-04-28
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1610 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public BM1610()
        {
            InitializeComponent();

            // pop up 화면(gird POP-UP)

            BizGridManager bizGrid = new BizGridManager(grid1);

            bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });     //  품목POP_UP grid
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });      // 금형 POP_UP grid

            ////조회용 POP 
            BizTextBoxManager btbManager = new BizTextBoxManager();

            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" }); //품목

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
                base.DoInquire();  //사업장, 금형 
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);     // 사업장 
                string sMoldType1 = DBHelper.nvlString(this.cboMoldType.Value);        //금형종류  
                string sMoldAssType = DBHelper.nvlString(this.cboMoldAssType.Value);     //자산종류    
                string sMoldType2 = DBHelper.nvlString(this.cboMoldType2.Value);       //재질  
                string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc.Value);         //보관위치
                string sItemCode = txtItemCode.Text;                                  //금형코드

                grid1.DataSource = helper.FillTable("USP_BM1610_S1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldType1", sMoldType1, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldAssType", sMoldAssType, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldType2", sMoldType2, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input));
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
            try
            {
                base.DoNew();

                _GridUtil.AddRow(this.grid1);
                this.grid1.SetDefaultValue("PlantCode", "820");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MoldCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Moldname");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MoldSeq");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


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
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업부 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM1610_D1N"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)          // 공장(사업부)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)            // 금형코드(금형 P/no(25) )
                                                   , helper.CreateParameter("MoldSeq", drRow["MoldSeq"].ToString(), DbType.String, ParameterDirection.Input));          // 품목코드                                                         

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM1610_I1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldSeq", drRow["MoldSeq"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldUseProc", drRow["MoldUseProc"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldCommType", drRow["MoldCommType"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldFamily", drRow["MoldFamily"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldMultPNO", drRow["MoldMultPNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("SubPNO", drRow["SubPNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldPartType", drRow["MoldPartType"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ASPNO", drRow["ASPNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ColorYesNo", drRow["ColorYesNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("SubPNOUsg", drRow["SubPNOUsg"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("SubItemCode", drRow["SubItemCode"].ToString(), DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정


                            helper.ExecuteNoneQuery("USP_BM1610_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldSeq", drRow["MoldSeq"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldUseProc", drRow["MoldUseProc"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldCommType", drRow["MoldCommType"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldFamily", drRow["MoldFamily"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldMultPNO", drRow["MoldMultPNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SubPNO", drRow["SubPNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldPartType", drRow["MoldPartType"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ASPNO", drRow["ASPNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ColorYesNo", drRow["ColorYesNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SubPNOUsg", drRow["SubPNOUsg"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SubItemCode", drRow["SubItemCode"].ToString(), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >

        #endregion

        #region<BM1610_Load>
        private void BM1610_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업부", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldSeq", "금형공정수", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldUseProc", "금형사용공정명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCommType", "전용/공용금형구분", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldFamily", "FAMILY금형", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldMultPNO", "복수금형", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SubPNO", "SUBP/NO", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldPartType", "PART구분", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ASPNO", "ASP/NO(협력사공급단위)", true, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ColorYesNo", "칼라여부(Y,N)", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SubPNOUsg", "USG(SUBPART)", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SubItemCode", "협력사P/NO", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            //     ///row number
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

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldType");     //금형타입
            WIZ.Common.FillComboboxMaster(this.cboMoldType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldAssType");     //자산종류 
            WIZ.Common.FillComboboxMaster(this.cboMoldAssType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldType2");     //재질 
            WIZ.Common.FillComboboxMaster(this.cboMoldType2, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");     //보관장소 
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDCOMMTYPE");     //전용/공용금형구분 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldCommType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDPARTTYPE");     //PART구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldPartType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");     //FAMILY금형,  복수금형,  칼라여부(Y,N)
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldFamily", rtnDtTemp, "CODE_ID", "CODE_NAME");    //FAMILY금형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldMultPNO", rtnDtTemp, "CODE_ID", "CODE_NAME");   //복수금형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ColorYesNo", rtnDtTemp, "CODE_ID", "CODE_NAME");    //칼라여부(Y,N)



            #endregion
        }
        #endregion

        #region grid POP UP 처리
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}

