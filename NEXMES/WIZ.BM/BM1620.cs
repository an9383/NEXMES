#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM1620
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
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM1620 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM1620()
        {
            InitializeComponent();

            // pop up 화면(gird POP-UP)

            BizGridManager bizGrid = new BizGridManager(grid1);

            bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });      //  품목POP_UP grid
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });      // 금형 POP_UP grid


            ////조회용 POP 
            BizTextBoxManager btbManager = new BizTextBoxManager();

            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" }); //품목
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형
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
                base.DoInquire();                                                   //사업장, 품목, 금형 
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);  // 사업장 
                string sItemCode = txtItemCode.Text;                                //품목
                string sMoldCode = txtMoldCode.Text;                                //금형코드

                grid1.DataSource = helper.FillTable("USP_BM1620_S2" //2014.6.30 임영조 USP_BM1620_S1 => USP_BM1620_S2
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input));
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

                int iRow = _GridUtil.AddRow(this.grid1);

                //16-09-30 최재형 820 -> 1100으로 공장코드 변경
                //this.grid1.SetDefaultValue("PlantCode", "820");
                this.grid1.SetDefaultValue("PlantCode", "1100");


                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MoldCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Moldname");
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
                            grid1.SetRowError(drRow, "금형코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM1620_D1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)          // 공장(사업부)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)            // 금형코드(금형 P/no(25) )
                                                   , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input));          // 품목코드                                                         

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM1620_I2" //2014.6.30 임영조 USP_BM1620_I1 => USP_BM1620_I2
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("NcrNo", drRow["NcrNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Cavity", drRow["Cavity"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정


                            helper.ExecuteNoneQuery("USP_BM1620_U2" //2014.6.30 임영조 USP_BM1620_U1 => USP_BM1620_U2
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("NcrNo", drRow["NcrNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Cavity", drRow["Cavity"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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



        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            //if (e.Row.RowState == DataRowState.Modified)
            //{
            //    e.Command.Parameters["@Editor"].Value = this.WorkerID;
            //    return;
            //}

            //if (e.Row.RowState == DataRowState.Added)
            //{
            //    e.Command.Parameters["@Editor"].Value = this.WorkerID;
            //    e.Command.Parameters["@Maker"].Value = this.WorkerID;
            //    return;
            //}
        }


        #endregion

        #region<BM1620_Load>
        private void BM1620_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NcrNo", "Ncr No", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Cavity", "Cavity", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerID", "등록자ID", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorID", "수정자 ID", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);


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

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

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

