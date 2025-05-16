#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  QM0300
//   Form Name    : 불량유형별 불량발생이력
//   Name Space   : WIZ.MM
//   Created Date : 
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

namespace WIZ.QM
{
    public partial class QM0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        PopUp_Biz _biz = new PopUp_Biz();//비지니스 로직 객체 생성
        #endregion

        #region<CONSTRUCTOR>
        public QM0300()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            //   * TBM0400 : 작업장 
            //*          - 1 : OPCode, 2 : OPName, param[0] : PlantCode, param[1] : UseFlag 
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region<TOOL BAR AREA>
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
                string sStartDate = DBHelper.nvlDateTime(CboStartdate_H.Value).ToString("yyyy-MM-dd");                            // 생산시작일자
                string sEndDate = DBHelper.nvlDateTime(CboEnddate_H.Value).ToString("yyyy-MM-dd");                                // 생산  끝일자
                string sErrorClassCode = DBHelper.nvlString(this.cboErrorClass.Value);
                string sOPCode = this.txtOPCode.Text.Trim();                                                                      // 공정 코드
                string sLineCode = this.txtLineCode.Text.Trim();                                                                  // 라인 코드

                grid1.DataSource = helper.FillTable("USP_QM0300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("ErrorClassCode", sErrorClassCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region 폼 로더
        private void QM0300_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorType", "불량구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClass", "불량유형", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorCode", "불량코드", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorDesc", "불량내역", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수량", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "작업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "작업장명", false, GridColDataType_emu.VarChar, 175, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineCode", "라인", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RecDate", "일자", false, GridColDataType_emu.YearMonthDay, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DayNight", "주야", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PlanNo", "계획번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OrderNo", "지시번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MItemCode", "모품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNO", "LotNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ERRORCLASS");
            WIZ.Common.FillComboboxMaster(this.cboErrorClass, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ErrorType", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ErrorClass", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region Grid MERGE

            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ErrorClass"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ErrorClass"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ErrorClass"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ErrorType"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ErrorType"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ErrorType"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ErrorCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ErrorCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ErrorCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ErrorDesc"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ErrorDesc"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ErrorDesc"].MergedCellStyle = MergedCellStyle.Always;




            #endregion Grid MERGE
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #region 텍스트 박스에서 팝업창에서 값 가져오기

        private void Search_Pop_Item()
        {
            //임시로 사용할 데이터테이블 생성
            DataTable _DtTemp = new DataTable();
            string sitem_cd = "";// this.txtItemCode.Text.Trim();    // 품목
            string sitem_name = ""; // this.txtItemName.Text.Trim();  // 품목명
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
            // string splantcd = "820";
            string sitemtype = "";


            try
            {

                _DtTemp = _biz.SEL_BM0010(sPlantCode, sitem_cd, sitem_name, sitemtype, "");

                if (_DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

                    if (_DtTemp != null && _DtTemp.Rows.Count > 0)
                    {
                        //txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        //txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                }
                else
                {
                    if (_DtTemp.Rows.Count == 1)
                    {
                        //txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        //txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                    else
                    {
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                        // txtItemCode.Text = string.Empty;
                        //txtItemName.Text = string.Empty;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            //  this.txtItemName.Text = string.Empty;
        }
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            //this.txtItemCode.Text = string.Empty;
        }

        #region 텍스트 박스에서 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM0400()
        {

            string sPlantCode = string.Empty;             //사업장코드
            string sOPCode = txtOPCode.Text.Trim();       //공정코드
            string sOPName = txtOPName.Text.Trim();       //공정명 
            string sUseFlag = string.Empty;               //사용여부         


            if (this.cboPlantCode_H.SelectedValue != null)
                sPlantCode = cboPlantCode_H.SelectedValue.ToString() == "ALL" ? "" : cboPlantCode_H.SelectedValue.ToString();         ///사업장코드 

            //            if (this.cboUseFlag_H.SelectedValue != null)
            //                sUseFlag = cboUseFlag_H.SelectedValue.ToString() == "ALL" ? "" : cboUseFlag_H.SelectedValue.ToString();                 // 사용여부

            sUseFlag = "";                 // 사용여부

            try
            {
                _biz.BM0040_POP(sOPCode, sOPName, sPlantCode, "", sUseFlag, txtOPCode, txtOPName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion        //공정(작업장)
        private void txtOPCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtOPName.Text = string.Empty;
        }

        private void txtOPNAME_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtOPCode.Text = string.Empty;
        }

        private void txtOPCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0400();
            }
        }

        private void txtOPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0400();
            }

        }

        #region 라인 (TBM0500) 팝업창에서 값 가져오기
        private void Search_Pop_TBM0500()
        {

            string sPlantCode = string.Empty;                             //사업장코드
            string sLineCode = txtLineCode.Text.Trim();                   //라인코드
            string sLineName = txtLineName.Text.Trim();                   //라인명명 
            string sUseFlag = string.Empty;                              //사용여부      


            if (this.cboPlantCode_H.SelectedValue != null)
                sPlantCode = cboPlantCode_H.SelectedValue.ToString() == "ALL" ? "" : cboPlantCode_H.SelectedValue.ToString();         ///사업장코드 

            //            if (this.cboUseFlag_H.SelectedValue != null)
            //                sUseFlag = cboUseFlag_H.SelectedValue.ToString() == "ALL" ? "" : cboUseFlag_H.SelectedValue.ToString();                 // 사용여부

            sUseFlag = "";                 // 사용여부

            try
            {
                _biz.BM0050_POP(sPlantCode, "", sLineCode, sLineName, sUseFlag, txtLineCode, txtLineName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion 라인 (TBM0500) 팝업창에서 값 가져오기

        private void txtLineName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtLineCode.Text = string.Empty;
        }


        private void txtLineCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0500();
            }
        }

        private void txtLineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0500();
        }



        private void txtLineName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0500();
            }
        }

        private void txtLineName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0500();
        }



        #region 에러코트(TBM1000) 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM1000()
        {

            string sPlantCode = string.Empty;                                      //사업장코드
            string sErrorCode = string.Empty;
            string sErrorClass = string.Empty;                                    //공정명 
            string sErrorType = string.Empty;                                    //라인코드
            string sErrorDesc = string.Empty;                                   //작업호기(라인)코드

            string sUseFlag = string.Empty;                                     //사용여부         

            if (this.cboPlantCode_H.SelectedValue != null)
                sPlantCode = cboPlantCode_H.SelectedValue.ToString() == "ALL" ? "" : cboPlantCode_H.SelectedValue.ToString();         ///사업장코드 

            if (this.cboErrorClass.SelectedValue != null)
                sErrorClass = cboErrorClass.SelectedValue.ToString() == "ALL" ? "" : cboErrorClass.SelectedValue.ToString();         //불량유형
            sUseFlag = "";                 // 사용여부: 전체


            //try
            //{
            //    _biz.TBM1000_POP(sErrorType, sErrorClass, sErrorCode, sErrorDesc, sUseFlag, cboErrorClass,);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ERROR", ex.Message);
            //}

        }
        #endregion

        private void txtErrorCode_KeyDown(object sender, KeyEventArgs e)
        {
            //this.cb.Text = string.Empty;
        }

        private void txtErrorName_KeyDown(object sender, KeyEventArgs e)
        {
            //this.txtErrorCode.Text = string.Empty;
        }

        private void txtErrorCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM1000();
            }
        }

        private void txtErrorCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM1000();
        }



        private void txtErrorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM1000();
            }
        }

        private void txtErrorName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM1000();
        }
        private void txtOPCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //폼이 로드 될 때 이미 btbManager에 등록되므로 필요 없는 이벤트
            //Search_Pop_TBM0400();
        }

        private void txtOPName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //폼이 로드 될 때 이미 btbManager에 등록되므로 필요 없는 이벤트
            //Search_Pop_TBM0400();
        }

        private void txtLineCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtLineName.Text = string.Empty;
        }

        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "ErrorQty" });

        }

        #endregion
    }
}

