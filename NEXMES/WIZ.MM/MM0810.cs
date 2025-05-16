#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MM0810
//   Form Name    : 수입검사 대기  정보 조회
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM0810 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();

        private DataTable DtChange = null;

        private string ItemCode;
        private string LotNo;
        private string SampleQty;
        private string InspQty;
        private string InspDate;

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        BizTextBoxManager btbManager;
        #endregion

        #region < CONSTRUCTOR >

        public MM0810(string _ItmCode, string _LotNo, string _SampleQty, string _InspQty, string _InspDate)
        {
            InitializeComponent();
            btbManager = new BizTextBoxManager();
            // TBM0100 : 품목
            // 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            ItemCode = _ItmCode;
            LotNo = _LotNo;
            SampleQty = _SampleQty;
            InspQty = _InspQty;
            InspDate = _InspDate;
        }
        #endregion

        #region  MM0810_Load
        private void MM0810_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목코드", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDesc", "검사항목상세", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMatLotNo", "LotNo", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SampleQty", "샘플수량", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WaitTime", "대기일", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspRequired", "검사필수여부", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사정보구분", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMethod", "검사수집장비", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResultVal", "검사값", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "검사결과", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            DtChange = (DataTable)grid1.DataSource;

            #region 콤보박스
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_TBM0000_1_CODE("");  //판정
            WIZ.Common.FillComboboxMaster(this.cboInspResult_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            //"InspResult", "검사결과"
            rtnDtTemp = _Common.GET_BM0000_CODE("InspResult");  //검사결과
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            txtItemCode.Text = ItemCode.ToString();
            txtLotNo.Text = LotNo.ToString();
            txtTSampleQty.Text = SampleQty.ToString();
            txtTotInspQty.Text = InspQty.ToString();
            cboStartDate.Value = InspDate.ToString();

            BtnSearch_Click(null, null);
        }
        #endregion  MM0810_Load

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DtChange.Clear();

                //base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value.ToString());                                                   // 사업장 공장코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cboStartDate.Value);                                                 // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate.Value);                                                     // 일자 TO           
                string sItemCode = this.txtItemCode.Text;                                                                                // 품목     
                string TotInspQty = this.txtTotInspQty.Text.Trim();                                                                      // 검사대기수        	
                string TSampleQty = this.txtTSampleQty.Text.Trim();                                                                      // 샘플수
                string sInspResult = Convert.ToString(cboInspResult_H.Value);                                                            // 판정(검사결과)
                string LotNo = this.txtLotNo.Text.Trim();                                                                                // LOT NO  


                rtnDtTemp = helper.FillTable("USP_MM0810_S2N", CommandType.StoredProcedure
                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)        // 공장(사업장) 
                                            , helper.CreateParameter("StartDate", sStartDate, DbType.DateTime, ParameterDirection.Input)      // 대기일(시) 
                                            , helper.CreateParameter("EndDate", sEndDate, DbType.DateTime, ParameterDirection.Input)          // 대기일(종) 
                                            , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)          // 품목     
                                            , helper.CreateParameter("TotInspQty", TotInspQty, DbType.String, ParameterDirection.Input)       // 검사대기수 
                                            , helper.CreateParameter("TSampleQty", TSampleQty, DbType.String, ParameterDirection.Input)       // 샘플수
                                            , helper.CreateParameter("InspResult", sInspResult, DbType.String, ParameterDirection.Input)      // 검사결과     
                                            , helper.CreateParameter("LotNo", LotNo, DbType.String, ParameterDirection.Input));               // 발주번호           



                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                DtChange = rtnDtTemp;

                //for (int i = 0; i < grid1.Rows.Count; i++) // 그리드 전체를 읽기위해
                //{
                //    string type = grid1.Rows[i].Cells["InspValType"].Value.ToString(); // 검사정보구분에 따라 검사값 입력방법을 변경하기 위해 검사정보구분을 type에 넣는다.

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
                //helper.Transaction = helper._sConn.BeginTransaction();
                string RS_CODE = string.Empty;
                string RS_MSG = string.Empty;

                foreach (DataRow drRow in ((DataTable)grid1.DataSource).Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:

                            #region 수정
                            helper.ExecuteNoneQuery("USP_MM0810_U2N", CommandType.StoredProcedure//, ref RS_CODE, ref RS_MSG
                                                    , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspMatLotNo", drRow["InspMatLotNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SampleQty", drRow["SampleQty"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspResultVal", drRow["InspResultVal"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspResult", drRow["InspResult"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WaitTime", drRow["WaitTime"].ToString(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspWorker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

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
    }
}

