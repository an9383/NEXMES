#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM3700                                                                                                                                                                          
//   Form Name    : 운행차량관리                                                                                                                                                                      
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19(2013-07-02 전면수정)                                                                                                                                                                     
//   Made By      : WIZCORE                                                                                                                                               
//   Description  : 입출고 운반 차량 정보 관리                                                                                                                                                               
// *---------------------------------------------------------------------------------------------*                                                                                                  
#endregion

#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{

    public partial class BM3700 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); //return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM3700()
        {
            InitializeComponent();


        }

        #endregion

        #region BM3700_Load
        private void BM3700_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            // InitColumnUltraGrid    103 110 100 98 98 92 133 93 163 152 158 80 80 120 80 80    


            _GridUtil.InitColumnUltraGrid(grid1, "CarNo", "차량번호", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);                      //차량번호           
            _GridUtil.InitColumnUltraGrid(grid1, "CarDesc", "차량내역", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                      //차량내역           
            _GridUtil.InitColumnUltraGrid(grid1, "CarGubun", "자차구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                      //자차구분(자차,용차)
            _GridUtil.InitColumnUltraGrid(grid1, "CarWgt", "차량중량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);                      //자량중량           
            _GridUtil.InitColumnUltraGrid(grid1, "CarEmpWgt", "공차중량", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);                      //공차중량           
            _GridUtil.InitColumnUltraGrid(grid1, "CarMaxWgt", "최대적재중량", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);                      //최대적재중량       
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "용차업체", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                      //용차업체           
            _GridUtil.InitColumnUltraGrid(grid1, "CarClass", "차종", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                      //차종               
            _GridUtil.InitColumnUltraGrid(grid1, "CarMaker", "제조사", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);                      //제조사             
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);



            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            grid1.DisplayLayout.Bands[0].Columns["CarNo"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["CarDesc"].Header.Appearance.ForeColor = Color.Yellow;
            grid1.DisplayLayout.Bands[0].Columns["CarGubun"].Header.Appearance.ForeColor = Color.Yellow;

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE

            #endregion Grid MERGE

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("CARGUBUN");  //차량구분                                                                                                                            
            WIZ.Common.FillComboboxMaster(this.cboCarGubun_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CarGubun", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion

        }
        #endregion BM3700_Load

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
                string sCarGubun = DBHelper.nvlString(this.cboCarGubun_H.Value);           // 차종구분
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);             //사용여부                                                                                                           

                grid1.DataSource = helper.FillTable("USP_BM3700_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("@CarGubun", sCarGubun, DbType.String, ParameterDirection.Input)                     // PLC 코드                                                                 
                                                                    , helper.CreateParameter("@UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));                     //사용여부                                                                    

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
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarNo");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarDesc");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarGubun");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarWgt");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarEmpWgt");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarMaxWgt");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CustCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarClass");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "CarMaker");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");

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
                        if (drRow["CarNo"].ToString().Trim() == "" || drRow["CarDesc"].ToString().Trim() == "" || drRow["CarGubun"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "차량번호, 차량내역, 자차구분은 필수 입력 항목입니다.");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM3700_D1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("CarNo", drRow["CarNo"].ToString(), DbType.String, ParameterDirection.Input));         // CarNo  

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM3700_I1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("CarNo", drRow["CarNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CarDesc", drRow["CarDesc"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CarGubun", drRow["CarGubun"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CarWgt", drRow["CarWgt"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CarEmpWgt", drRow["CarEmpWgt"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CarMaxWgt", drRow["CarMaxWgt"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CustCode", drRow["CustCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CarClass", drRow["CarClass"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CarMaker", drRow["CarMaker"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM3700_U1N"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("CarNo", drRow["CarNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CarDesc", drRow["CarDesc"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CarGubun", drRow["CarGubun"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CarWgt", drRow["CarWgt"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CarEmpWgt", drRow["CarEmpWgt"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CarMaxWgt", drRow["CarMaxWgt"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CustCode", drRow["CustCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CarClass", drRow["CarClass"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CarMaker", drRow["CarMaker"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));                         // 수정자

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("CarNo");
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

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의

        #endregion

    }
}
