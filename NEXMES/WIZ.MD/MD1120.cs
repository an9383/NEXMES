// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD1120
//   Form Name    : 금형 점검 실적등록
//   Name Space   : WIZ.PP
//   Created Date : 2014-06-20
//   Made By      : WIZCORE
//   Description  :
// *---------------------------------------------------------------------------------------------*

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MD
{

    public partial class MD1120 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        private string PLANTCODE; //공장(사업장)
        private string MoldCode;  //금형코드(금형 P/no(25) )
        private string MoldName;  //금형명
        private string ItemCode;  //품목
        private string ItemName;  //품목명
        private string PlanReqNo; //점검계획번호
        private string InspDate;  //점검일자

        #endregion

        #region < CONSTRUCTOR >

        public MD1120(string _PLANTCODE, string _MoldCode, string _MoldName, string _ItmCode, string _ItmName, string _PlanReqNo, string _InspDate)
        {
            InitializeComponent();

            BizGridManager bizGrid = new BizGridManager(grid1);
            bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });    // 품목POP_UP grid
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });    // 금형POP_UP grid

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0000", new object[] { cboPlantCode, "" });    //품목
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode, "" });    //금형

            PLANTCODE = _PLANTCODE;
            MoldCode = _MoldCode;
            MoldName = _MoldName;
            ItemCode = _ItmCode;
            ItemName = _ItmName;
            PlanReqNo = _PlanReqNo;
            InspDate = _InspDate;

        }
        #endregion

        #region  MD1120_Load
        private void MD1120_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅

            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 103, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "정검항목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "정검항목명", false, GridColDataType_emu.VarChar, 134, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "규격상한", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "규격하한", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사정보구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "수집장비", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResultVal", "검사", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "검사결과", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion


            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode"); //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspResult");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //rtnDtTemp = _Common.GET_TBM0000_1_CODE("");  //판정
            //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            txtItemCode.Text = ItemCode.ToString();   // 품목 
            txtItemName.Text = ItemName.ToString();   // 품목명 
            txtMoldCode.Text = MoldCode.ToString();   // 금형
            txtMoldName.Text = MoldName.ToString();   // 금형명
            txtPlanReqNo.Text = PlanReqNo.ToString(); // 계획번호
            cboPlantCode.Value = PLANTCODE.ToString(); // 사업장 공장코드


            BtnSearch_Click(null, null);
        }
        #endregion  MD1120_Load

        #region<Event>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntInitialize_Click(object sender, EventArgs e)
        {
            //입력값초기화
            cboPlantCode.Value = "";
            txtMoldCode.Text = "";
            txtMoldName.Text = "";
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtItemName.Text = "";
            txtPlanReqNo.Text = "";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                //base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode.Value.ToString());  // 사업장 공장코드
                string sMoldCode = this.txtMoldCode.Text.Trim();                      // 금형        	
                string sPlanReqNo = this.txtPlanReqNo.Text.Trim();                    // 계획번호
                string sItemCode = this.txtItemCode.Text;                             // 품목     


                grid1.DataSource = helper.FillTable("USP_MD1120_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)      // 공장(사업장) 
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)        // 금형
                                                                   , helper.CreateParameter("PlanReqNo", sPlanReqNo, DbType.String, ParameterDirection.Input));    // 계획번호
                //         , helper.CreateParameter("ItemCode",  sItemCode,  DbType.String, ParameterDirection.Input));  // 품목 



                grid1.DataBinds();


                //for (int i = 0; i < grid1.Rows.Count; i++) // 그리드 전체를 읽기위해
                //{
                //    string type = grid1.Rows[i].Cells["InspValType"].Value.ToString(); 
                //   // 검사정보구분에 따라 검사값 입력방법을 변경하기 위해 검사정보구분(InspValType,3680)을 type에 넣는다.

                //    switch (type) // 검사정보구분을 비교하기 위해
                //    {
                //        case "양호/불량":
                //            rtnDtTemp = _Common.GET_TBM0000_2_CODE("1");  //양호/불량                      
                //            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResultVal", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //            break;

                //        case "OK/NG":
                //            rtnDtTemp = _Common.GET_TBM0000_2_CODE("2");  //OK/NG                        
                //            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResultVal", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //            break;

                //        case "확인":
                //            rtnDtTemp = _Common.GET_TBM0000_2_CODE("3");  //확인                        
                //            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResultVal", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //            break;

                //        case "수치":

                //            break;

                //        case "O/X":
                //            rtnDtTemp = _Common.GET_TBM0000_2_CODE("5");  //O/X                        
                //            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResultVal", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //            break;

                //        case "H/L":
                //            rtnDtTemp = _Common.GET_TBM0000_2_CODE("6");  //H/L                        
                //            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResultVal", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //            break;
                //    }
                //}
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                UltraGridUtil.DataRowDelete(this.grid1);
                this.grid1.UpdateData();
                string RS_CODE = string.Empty;
                string RS_MSG = string.Empty;

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:   //Added:


                            #region 추가

                            helper.ExecuteNoneQuery("USP_MD1120_I2", CommandType.StoredProcedure//, ref RS_CODE, ref RS_MSG

                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)         //사업장
                                                    , helper.CreateParameter("MoldCode", MoldCode.ToString(), DbType.String, ParameterDirection.Input)                   //금형코드
                                                    , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input)          //점검항목코드
                                                    , helper.CreateParameter("InspResultVal", drRow["InspResultVal"].ToString(), DbType.String, ParameterDirection.Input) //검사값
                                                    , helper.CreateParameter("InspResult", drRow["InspResult"].ToString(), DbType.String, ParameterDirection.Input)       //검사결과
                                                    , helper.CreateParameter("SpecUSL", drRow["SpecUSL"].ToString(), DbType.String, ParameterDirection.Input)          //규격상한
                                                    , helper.CreateParameter("SpecLSL", drRow["SpecLSL"].ToString(), DbType.String, ParameterDirection.Input)          //규격하한
                                                    , helper.CreateParameter("PlanReqNo", PlanReqNo.ToString(), DbType.String, ParameterDirection.Input)                 //계획번호
                                                    , helper.CreateParameter("InspWorker ", this.WorkerID, DbType.String, ParameterDirection.Input));                     //점검자


                            if (helper.RSCODE == "E") MessageBox.Show(helper.RSMSG);
                            else if (helper.RSCODE == "S")
                            {
                                MessageBox.Show(helper.RSMSG);
                                this.Close();
                            }

                            #endregion
                            break;
                    }
                }
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
                BtnSearch_Click(null, null);
            }

        }
        #endregion
    }
}

