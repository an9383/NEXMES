#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  QM0400
//   Form Name    : 불량 작업장별 TOP10 정보 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM0400 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        PopUp_Biz _biz = new PopUp_Biz();//비지니스 로직 객체 생성
        #endregion

        #region<CONSTRUCTOR>
        public QM0400()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            //            * TBM0400 : 작업장 
            //*          - 1 : OPCode, 2 : OPName, param[0] : PlantCode, param[1] : UseFlag 
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });

            //   * TBM0600 : 작업라인
            //*          - 1 : WorkCenterCode, 2 : WorkCenterName, param[0] : PlantCode, param[1] : OPcode
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode });
        }
        #endregion

        #region QM0400_Load
        private void QM0400_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();


            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "공정", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "공정명", false, GridColDataType_emu.VarChar, 190, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineCode", "라인", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LineName", "라인명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorQty", "불량수량", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitializeGrid(this.grid1);                                                  // 사업장(공장)
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();

            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            CboStartdate_H.Value = DateTime.Now.AddDays(-7);
            CboEnddate_H.Value = DateTime.Now;

            this.ultraChart1.EmptyChartText = string.Empty;
            this.ultraChart2.EmptyChartText = string.Empty;
        }
        #endregion QM0400_Load

        #region 조회
        public override void DoInquire()
        {
            //SqlDBHelper helper = new SqlDBHelper(false);
            //SqlParameter[] param = new SqlParameter[6];
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                        // 사업장(공장)
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sWorkCenterCode = this.txtWorkCenterCode.Text.Trim();                                        // 작업장 코드
                string sOPCode = this.txtOPCode.Text.Trim();                                                        // 공정 코드
                string sLineCode = this.txtLineCode.Text.Trim();                                                  // 라인 코드

                //param[0] = helper.CreateParameter("PlantCode", sPlantCode, SqlDbType.VarChar, ParameterDirection.Input);             // 사업장(공장)    
                //param[1] = helper.CreateParameter("StartDate", sStartDate, SqlDbType.VarChar, ParameterDirection.Input);             // 생산시작일자    
                //param[2] = helper.CreateParameter("EndDate", sEndDate, SqlDbType.VarChar, ParameterDirection.Input);                 // 생산  끝일자    
                //param[3] = helper.CreateParameter("WorkCenterCode", sWorkCenterCode, SqlDbType.VarChar, ParameterDirection.Input);   // 작업장 코드     
                //param[4] = helper.CreateParameter("OPCode", sOPCode, SqlDbType.VarChar, ParameterDirection.Input);                   // 공정 코드       
                //param[5] = helper.CreateParameter("LineCode", sLineCode, SqlDbType.VarChar, ParameterDirection.Input);               // 라인 코드       


                //rtnDtTemp = SqlDBHelper.FillTable("USP_QM0400_S1N", CommandType.StoredProcedure, param);
                grid1.DataSource = helper.FillTable("USP_QM0400_S1N", CommandType.StoredProcedure
                                                                     , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                     , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();
                //_Common.Grid_Column_Width(this.grid1); //grid 정리용   

                if (grid1.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();
                    ultraChart2.Series.Clear();

                    NumericSeries series = new NumericSeries();
                    series.Data.DataSource = grid1.DataSource;
                    series.Data.LabelColumn = "WorkCenterName";
                    series.Data.ValueColumn = "ErrorQty";
                    series.DataBind();

                    ultraChart1.Series.Add(series);
                    ultraChart1.Data.DataBind();

                    ultraChart2.Series.Add(series);
                    ultraChart2.Data.DataBind();

                }

            }
            catch (Exception ex)
            {
                //this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
                throw ex;
            }
            finally
            {
                //helper.Close();
                //if (param != null) { param = null; }
                helper.Close();
            }
        }
        #endregion 조회

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #region 텍스트 박스에서 팝업창에서 값 가져오기

        private void Search_Pop_Item()
        {

            //임시로 사용할 데이터테이블 생성
            DataTable _DtTemp = new DataTable();
            string sitem_cd = "";// this.txtItemCode.Text.Trim();    // 품목
            string sitem_name = ""; // this.txtItemName.Text.Trim();  // 품목명
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());
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
                //_biz.TBM0400_POP(sPlantCode, sOPCode, sOPName, sUseFlag, txtOPCode, txtOPName);

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
                //_biz.TBM0500_POP(sPlantCode, "", sLineCode, sLineName, sUseFlag, txtLineCode, txtLineName);

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



        #region 작업장(TBM0600) 팝업창에서 값 가져오기
        //////////////////     
        private void Search_Pop_TBM0600()
        {

            string sPlantCode = string.Empty;                             //사업장코드
            string sOPCode = txtOPCode.Text.Trim();                       //공정코드
            string sOPName = txtOPName.Text.Trim();                       //공정명 
            string sLineCode = string.Empty;                              //라인코드
            string sWORKCENTERCODE = txtWorkCenterCode.Text.Trim();       //작업호기(라인)코드
            string sWorkCenterName = txtWorkCenterName.Text.Trim();       //작업호기(라인)명 
            string sUseFlag = string.Empty;                               //사용여부         


            if (this.cboPlantCode_H.SelectedValue != null)
                sPlantCode = cboPlantCode_H.SelectedValue.ToString() == "ALL" ? "" : cboPlantCode_H.SelectedValue.ToString();         ///사업장코드 

            //if (this.cboUseFlag_H.SelectedValue != null)
            //    sUseFlag = cboUseFlag_H.SelectedValue.ToString() == "ALL" ? "" : cboUseFlag_H.SelectedValue.ToString();                 // 사용여부
            sUseFlag = "";                 // 사용여부: 전체


            try
            {
                //_biz.BM0600_POP(sPlantCode, sWORKCENTERCODE, sWorkCenterName, sOPCode, sLineCode, sUseFlag, txtWorkCenterCode, txtWorkCenterName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion

        private void txtWorkCenterCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtWorkCenterName.Text = string.Empty;
        }

        private void txtWorkCenterName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtWorkCenterCode.Text = string.Empty;
        }

        private void txtWorkCenterCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0600();
            }
        }

        private void txtWorkCenterCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0600();
        }



        private void txtWorkCenterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0600();
            }
        }

        private void txtWorkCenterName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0600();
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
