#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM1100
//   Form Name    : 수입검사 대기  정보 조회
//   Name Space   : WIZ.WM
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

namespace WIZ.WM
{
    public partial class WM1100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private string ItemCode;
        private string LotNo;
        private string ItemName;
        private string InspQty;
        private string InspDate;
        #endregion

        #region < CONSTRUCTOR >

        public WM1100(string _ItmCode, string _ItmName, string _LotNo, string _InspQty, string _InspDate)
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // TBM0100 : 품목
            // 1 : 품목, 2 : 품목명, param[0] : PlantCode, param[1] : ItemType
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });

            ItemCode = _ItmCode;
            ItemName = _ItmName;
            LotNo = _LotNo;
            InspQty = _InspQty;
            InspDate = _InspDate;
        }
        #endregion

        #region  WM1100_Load
        private void WM1100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목코드", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDesc", "검사항목상세", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "LotNo", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "InspDate", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspRequired", "검사필수여부", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사정보구분", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAStandardName", "검사수집장비", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResultVal", "검사값", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "검사결과", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("");  //판정
            WIZ.Common.FillComboboxMaster(this.cboInspResult_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspResult", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            txtItemCode.Text = ItemCode.ToString();
            txtItemName.Text = ItemName.ToString();
            txtLotNo.Text = LotNo.ToString();
            txtTSampleQty.Text = ItemName.ToString();
            txtTotInspQty.Text = InspQty.ToString();
            cboStartDate.Value = InspDate.ToString();
            BtnSearch_Click(null, null);
        }
        #endregion  WM1100_Load

        #region<METHOD AREA>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());                  // 사업장 공장코드
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cboStartDate.Value);                  // 일자 FROM
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate.Value);                      // 일자 TO           
                string sItemCode = this.txtItemCode.Text;                                                 // 품목     
                string TotInspQty = this.txtTotInspQty.Text.Trim();                                       // 검사대기수        	
                string TSampleQty = this.txtTSampleQty.Text.Trim();                                       // 샘플수
                string sInspResult = DBHelper.nvlString(cboInspResult_H.Value);                           // 판정(검사결과)
                string LotNo = this.txtLotNo.Text.Trim();                                                 // LOT NO  

                grid1.DataSource = helper.FillTable("USP_WM1100_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)             // 공장(사업장) 
                                                                    , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)             // 대기일(시) 
                                                                    , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)                 // 대기일(종) 
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)               // 품목      
                                                                    , helper.CreateParameter("LotNo", LotNo, DbType.String, ParameterDirection.Input));                    // 발주번호           
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                //base.DoSave();


                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:
                            #region 수정
                            string sItemCode = this.txtItemCode.Text;
                            helper.ExecuteNoneQuery("USP_WM1100_U1", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("InspDate", drRow["InspDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("LotNo", drRow["LotNo"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("InspResultVal", drRow["InspResultVal"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("InspResult", drRow["InspResult"].ToString(), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("InspWorker", WIZ.Common.SystemID, DbType.String, ParameterDirection.Input));
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
                BtnSearch_Click(null, null);
            }
        }
        #endregion
    }
}

