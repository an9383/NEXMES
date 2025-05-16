#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD3210

//   Form Name    : 금형실사이력
//   Name Space   : WIZ.BM
//   Created Date : 2014-05-08
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;

#endregion

namespace WIZ.MD
{
    public partial class MD3210 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        #endregion

        #region < CONSTRUCTOR >
        public MD3210()
        {
            InitializeComponent();
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
                base.DoInquire();  //사업장, 지시번호, 보관장소, 재고실사실 시작일

                string sTakingORDNo = txtTakingORDNo.Text.Trim();                              //지시번호
                string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc_H.Value);                 // 보관장소
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);             // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);     // 일자 FROM                                                                                                                                                                    
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);         // 일자 TO 

                grid1.DataSource = helper.FillTable("USP_MD3210_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input));
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

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (grid1.ActiveRow != null)
            {
                DoInquire1();  //실사 이력정보
                txtTakingORDNo.Text = Convert.ToString(grid1.ActiveRow.Cells["TakingORDNo"].Value);
            }
        }

        private void DoInquire1()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                string sTakingORDNo = txtTakingORDNo.Text.Trim();                               //지시번호
                string sMoldLoc = DBHelper.nvlString(this.cboMoldLoc_H.Value);                  // 보관장소
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);              // 공장코드     
                string sStartdate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);      // 일자 FROM                                                                                                                                                                    
                string sEnddate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);          // 일자 TO 

                if (sMoldLoc == "ALL") sMoldLoc = "";
                grid2.DataSource = helper.FillTable("USP_MD3210_S3", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TakingORDNo", sTakingORDNo, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldLoc", sMoldLoc, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartdate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEnddate, DbType.String, ParameterDirection.Input));
                grid2.DataBinds();
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


        #endregion

        #region < EVENT AREA >

        #endregion

        #region<MD3210_Load>
        private void MD3210_Load(object sender, EventArgs e)
        {

            #region 그리드
            //   _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingORDNo", "실사지시번호", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldLoc", "저장위치 ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingStartDate", "실사 시작일", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TakingEndDate", "실사 완료일", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Status", "상태", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자 ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MoldLoc", "저장위치", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "품목명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TakingType", "실사구분", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "Status", "상태", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MakeDate", "생성일자 ", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);



            #endregion

            #region 콤보박스

            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MoldLoc");
            WIZ.Common.FillComboboxMaster(this.cboMoldLoc_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "MoldLoc", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TakingType");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "TakingType", rtnDtTemp, "CODE_ID", "CODE_NAME");
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

