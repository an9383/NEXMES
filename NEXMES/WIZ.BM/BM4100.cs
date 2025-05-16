#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                                                                   
//   Form ID      : BM4100                                                                                                                                                                                                                           
//   Form Name    : 각종사유코드관리                                                                                                                                                                                                                   
//   Name Space   : WIZ.BM                                                                                                                                                                                                                         
//   Created Date : 2012-03-19(2013-07-01전면수정)                                                                                                                                                                                                   
//   Made By      : WIZCORE                                                                                                                                                                                                
//   Description  : 각종 사유에 대해서 코드화 관리 하는  화면                                                                                                                                                                                          
// *---------------------------------------------------------------------------------------------*                                                                                                                                                   
#endregion


#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{

    public partial class BM4100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); //return DataTable 공통                                                                                                                                                                              
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성   
        #endregion

        #region < CONSTRUCTOR >
        public BM4100()
        {
            InitializeComponent();

        }

        #endregion

        #region BM4100_Load
        private void BM4100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //  _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);                                                                                                                                                                   

            // InitColumnUltraGrid  
            _GridUtil.InitColumnUltraGrid(grid1, "ResType", "사유유형", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);   	  	// 사유유형	   
            _GridUtil.InitColumnUltraGrid(grid1, "ResCode", "사유코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);         // 사유코드 	
            _GridUtil.InitColumnUltraGrid(grid1, "ResName", "사유명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);   	      // 사유명	   
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 125, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자명", true, GridColDataType_emu.VarChar, 125, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", true, GridColDataType_emu.VarChar, 125, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorNM", "수정자명", true, GridColDataType_emu.VarChar, 125, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            ///////MERGE                                                                                                                                                                                                                             
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE

            #endregion Grid MERGE

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("ResType");            //사유유형                                                                                                                                                                     
            WIZ.Common.FillComboboxMaster(this.cboResType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ResType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                                                                   
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

        }
        #endregion BM4100_Load

        #region <TOOL BAR AREA >
        /// <summary>                                                                                                                                                                                                                                
        /// ToolBar의 조회 버튼 클릭                                                                                                                                                                                                                 
        /// </summary>                                                                                                                                                                                                                               
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                string sResType = DBHelper.nvlString(this.cboResType_H.Value);
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                base.DoInquire();
                grid1.DataSource = helper.FillTable("USP_BM4100_S1N"
                                                         , CommandType.StoredProcedure
                                                         , helper.CreateParameter("@ResType", sResType, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("@UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));

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

                UltraGridUtil.ActivationAllowEdit(this.grid1, "ResType");        // 사유유형                                                                                                                                                     
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ResCode");        // 사유코드                                                                                                                                                     
                UltraGridUtil.ActivationAllowEdit(this.grid1, "ResName");        // 사유명                                                                                                                                                 
                UltraGridUtil.ActivationAllowEdit(this.grid1, "UseFlag");        // 사용유무                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
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
                        if (drRow["ResCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사유코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM4100_D1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("ResType", drRow["ResType"].ToString(), DbType.String, ParameterDirection.Input)         // ResType                                                                                  
                                                    , helper.CreateParameter("ResCode", drRow["ResCode"].ToString(), DbType.String, ParameterDirection.Input));         // ResCode                                                                                  


                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM4100_I1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("ResType", drRow["ResType"].ToString(), DbType.String, ParameterDirection.Input)              // 사유유형                                                                        
                                                    , helper.CreateParameter("ResCode", drRow["ResCode"].ToString(), DbType.String, ParameterDirection.Input)              // 사유코드                                                                          
                                                    , helper.CreateParameter("ResName", drRow["ResName"].ToString(), DbType.String, ParameterDirection.Input)              // 사유명                                                                          
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM4100_U1N"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("ResType", drRow["ResType"].ToString(), DbType.String, ParameterDirection.Input)              // 사유유형                                                                        
                                                        , helper.CreateParameter("ResCode", drRow["ResCode"].ToString(), DbType.String, ParameterDirection.Input)              // 사유코드                                                                          
                                                        , helper.CreateParameter("ResName", drRow["ResName"].ToString(), DbType.String, ParameterDirection.Input)              // 사유명                                                                          
                                                        , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("ResCode");
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