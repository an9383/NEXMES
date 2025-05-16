#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*                                                                                                  
//   Form ID      : BM4500                                                                                                                                                                          
//   Form Name    : 목표치관리                                                                                                                                                                      
//   Name Space   : WIZ.BM                                                                                                                                                                        
//   Created Date : 2012-03-19                                                                                                                                                                      
//   Made By      : WIZCORE                                                                                                                                                
//   Description  : 목표치 관리 화면                                                                                                                                                                
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

    public partial class BM4500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); //return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM4500()
        {
            InitializeComponent();
            // grid pop-up 처리를 위한 정의
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });	  //품목
            gridManager.PopUpAdd("WorkCenterCode", "WorkCenterName", "TBM0600", new string[] { "PlantCode", "OPCode", "", "" });  //작압장(WC)
            gridManager.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "" });   //공정
            gridManager.PopUpAdd("LineCode", "LineName", "TBM0500", new string[] { "PlantCode", "" });   //라인

        }

        #endregion

        #region BM4500_Load
        private void BM4500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //  _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            // InitColumnUltraGrid           180 120 139 80 80 80 80 80 80 80 80 80 80 80 80 80 117 125 80 131 80 80 113 80 80 


            _GridUtil.InitColumnUltraGrid(grid1, "IndexNo", "순번", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업부)", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TARGETTYPE", "목표치구분(장소)", true, GridColDataType_emu.VarChar, 145, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TARGETCLASS", "목표치 유형", true, GridColDataType_emu.VarChar, 225, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목", true, GridColDataType_emu.VarChar, 155, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정", true, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Linecode", "라인코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DeptCode", "부서", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BanCode", "반", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TeamCode", "팀", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M01", "1월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M02", "2월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M03", "3월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M04", "4월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M05", "5월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M06", "6월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M07", "7월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M08", "8월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M09", "9월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M10", "10월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M11", "11월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "M12", "12월목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Y00", "년목표치", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAVG", "월목표치평균", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MTOT", "월목표치합계", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakerNM", "등록자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditorNM", "수정자명", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;


            #endregion Grid MERGE

            #region 콤보박스

            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장                                                                                                                              
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TARGETTYPE");         //목표치구분                                                                                                                                                                                  
            WIZ.Common.FillComboboxMaster(this.cboTARGETCLASS_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TARGETTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");            //사용여부                                                                                                                 
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TARGETCLASS");        //목표치 유형                                                                                                                                                                                  
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TARGETCLASS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DeptCode");           //부서                                                                                                                                                                                 
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DeptCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("BanCode");            //반                                                                                                                                                                                
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BanCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TeamCode");           //팀                                                                                                                                                                                
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TeamCode", rtnDtTemp, "CODE_ID", "CODE_NAME");



            #endregion

        }
        #endregion BM4500_Load

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
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sTargetclass = DBHelper.nvlString(this.cboTARGETCLASS_H.Value);

                base.DoInquire();

                grid1.DataSource = helper.FillTable("USP_BM4500_S1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@TARGETCLASS", sTargetclass, DbType.String, ParameterDirection.Input)
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
                        if (drRow["IndexNo"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "순번 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM4500_D1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("IndexNo", drRow["IndexNo"].ToString(), DbType.String, ParameterDirection.Input));         // 인텍스


                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM4500_I1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)               // 공장(사업부)코드
                                                    , helper.CreateParameter("TARGETTYPE", drRow["TARGETTYPE"].ToString(), DbType.String, ParameterDirection.Input)               // 목표치구분(장소)
                                                    , helper.CreateParameter("TARGETCLASS", drRow["TARGETCLASS"].ToString(), DbType.String, ParameterDirection.Input)               // 목표치 유형
                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)               // 품목
                                                    , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)         // WorkCenter코드
                                                    , helper.CreateParameter("OPCode", drRow["OPCode"].ToString(), DbType.String, ParameterDirection.Input)               // 적용공정코드
                                                    , helper.CreateParameter("Linecode", drRow["Linecode"].ToString(), DbType.String, ParameterDirection.Input)               // 적용 라인 코드
                                                    , helper.CreateParameter("DeptCode", drRow["DeptCode"].ToString(), DbType.String, ParameterDirection.Input)               // 부서코드
                                                    , helper.CreateParameter("BanCode", drRow["BanCode"].ToString(), DbType.String, ParameterDirection.Input)               // 반코드
                                                    , helper.CreateParameter("TeamCode", drRow["TeamCode"].ToString(), DbType.String, ParameterDirection.Input)               // 팀코드
                                                    , helper.CreateParameter("M01", drRow["M01"].ToString(), DbType.String, ParameterDirection.Input)               // 1월목표치
                                                    , helper.CreateParameter("M02", drRow["M02"].ToString(), DbType.String, ParameterDirection.Input)               // 2월목표치
                                                    , helper.CreateParameter("M03", drRow["M03"].ToString(), DbType.String, ParameterDirection.Input)               // 3월목표치
                                                    , helper.CreateParameter("M04", drRow["M04"].ToString(), DbType.String, ParameterDirection.Input)               // 4월목표치
                                                    , helper.CreateParameter("M05", drRow["M05"].ToString(), DbType.String, ParameterDirection.Input)               // 5월목표치
                                                    , helper.CreateParameter("M06", drRow["M06"].ToString(), DbType.String, ParameterDirection.Input)               // 6월목표치
                                                    , helper.CreateParameter("M07", drRow["M07"].ToString(), DbType.String, ParameterDirection.Input)               // 7월목표치
                                                    , helper.CreateParameter("M08", drRow["M08"].ToString(), DbType.String, ParameterDirection.Input)               // 8월목표치
                                                    , helper.CreateParameter("M09", drRow["M09"].ToString(), DbType.String, ParameterDirection.Input)               // 9월목표치
                                                    , helper.CreateParameter("M10", drRow["M10"].ToString(), DbType.String, ParameterDirection.Input)               // 10월목표치
                                                    , helper.CreateParameter("M11", drRow["M11"].ToString(), DbType.String, ParameterDirection.Input)               // 11월목표치
                                                    , helper.CreateParameter("M12", drRow["M12"].ToString(), DbType.String, ParameterDirection.Input)               // 12월목표치
                                                    , helper.CreateParameter("Y00", drRow["Y00"].ToString(), DbType.String, ParameterDirection.Input)               // 년목표치
                                                    , helper.CreateParameter("MAVG", drRow["MAVG"].ToString(), DbType.String, ParameterDirection.Input)               // 월목표치평균
                                                    , helper.CreateParameter("MTOT", drRow["MTOT"].ToString(), DbType.String, ParameterDirection.Input)               // 월목표치 합계
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM4500_U1N"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("IndexNo", drRow["IndexNo"].ToString(), DbType.String, ParameterDirection.Input)                // 순번(Key) 내부
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)                // 공장(사업부)코드
                                                    , helper.CreateParameter("TARGETTYPE", drRow["TARGETTYPE"].ToString(), DbType.String, ParameterDirection.Input)                // 목표치구분(장소)
                                                    , helper.CreateParameter("TARGETCLASS", drRow["TARGETCLASS"].ToString(), DbType.String, ParameterDirection.Input)                // 목표치 유형
                                                    , helper.CreateParameter("ItemCode", drRow["ItemCode"].ToString(), DbType.String, ParameterDirection.Input)                // 품목
                                                    , helper.CreateParameter("WorkCenterCode", drRow["WorkCenterCode"].ToString(), DbType.String, ParameterDirection.Input)          // WorkCenter코드
                                                    , helper.CreateParameter("OPCode", drRow["OPCode"].ToString(), DbType.String, ParameterDirection.Input)                // 적용공정코드
                                                    , helper.CreateParameter("Linecode", drRow["Linecode"].ToString(), DbType.String, ParameterDirection.Input)                // 적용 라인 코드
                                                    , helper.CreateParameter("DeptCode", drRow["DeptCode"].ToString(), DbType.String, ParameterDirection.Input)                // 부서코드
                                                    , helper.CreateParameter("BanCode", drRow["BanCode"].ToString(), DbType.String, ParameterDirection.Input)                // 반코드
                                                    , helper.CreateParameter("TeamCode", drRow["TeamCode"].ToString(), DbType.String, ParameterDirection.Input)                // 팀코드
                                                    , helper.CreateParameter("M01", drRow["M01"].ToString(), DbType.String, ParameterDirection.Input)                // 1월목표치
                                                    , helper.CreateParameter("M02", drRow["M02"].ToString(), DbType.String, ParameterDirection.Input)                // 2월목표치
                                                    , helper.CreateParameter("M03", drRow["M03"].ToString(), DbType.String, ParameterDirection.Input)                // 3월목표치
                                                    , helper.CreateParameter("M04", drRow["M04"].ToString(), DbType.String, ParameterDirection.Input)                // 4월목표치
                                                    , helper.CreateParameter("M05", drRow["M05"].ToString(), DbType.String, ParameterDirection.Input)                // 5월목표치
                                                    , helper.CreateParameter("M06", drRow["M06"].ToString(), DbType.String, ParameterDirection.Input)                // 6월목표치
                                                    , helper.CreateParameter("M07", drRow["M07"].ToString(), DbType.String, ParameterDirection.Input)                // 7월목표치
                                                    , helper.CreateParameter("M08", drRow["M08"].ToString(), DbType.String, ParameterDirection.Input)                // 8월목표치
                                                    , helper.CreateParameter("M09", drRow["M09"].ToString(), DbType.String, ParameterDirection.Input)                // 9월목표치
                                                    , helper.CreateParameter("M10", drRow["M10"].ToString(), DbType.String, ParameterDirection.Input)                // 10월목표치
                                                    , helper.CreateParameter("M11", drRow["M11"].ToString(), DbType.String, ParameterDirection.Input)                // 11월목표치
                                                    , helper.CreateParameter("M12", drRow["M12"].ToString(), DbType.String, ParameterDirection.Input)                // 12월목표치
                                                    , helper.CreateParameter("Y00", drRow["Y00"].ToString(), DbType.String, ParameterDirection.Input)                // 년목표치
                                                    , helper.CreateParameter("MAVG", drRow["MAVG"].ToString(), DbType.String, ParameterDirection.Input)                // 월목표치평균
                                                    , helper.CreateParameter("MTOT", drRow["MTOT"].ToString(), DbType.String, ParameterDirection.Input)                // 월목표치 합계
                                                    , helper.CreateParameter("UseFlag", drRow["UseFlag"].ToString(), DbType.String, ParameterDirection.Input)                // 사용유무 
                                                    , helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));              // 수정자


                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("IndexNo");
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
