#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :   QM0910
//   Form Name    : 수입검사 실적  정보 조회
//   Name Space   : WIZ.QM
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
    public partial class QM0910 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        PopUp_Biz _biz = new PopUp_Biz();//비지니스 로직 객체 생성
        #endregion

        #region < CONSTRUCTOR >

        public QM0910()
        {
            InitializeComponent();
        }
        #endregion

        #region   QM0910_Load
        private void QM0910_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspMatLotNo", "Lot번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoNo", "P/O번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PoSeqNo", "P/O순번", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "업체명", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspWaitDate", "대기일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TotInspQty", "총검사수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "검사일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TSampleQty", "샘플수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TInspResult", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDesc", "항목상세", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SampleQty", "시료수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResultDesc", "검사결과", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResultVal", "검사값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspResult", "합/불", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "NextInspDate", "다음검사일시", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WaitTime", "대기시간", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspVer", "스펙버전", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecLSL", "하한치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SpecUSL", "상한치", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspWorker", "검사자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspResult");  //검사결과
            WIZ.Common.FillComboboxMaster(this.cboInspResult_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion

            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["InspMatLotNo"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["InspMatLotNo"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["InspMatLotNo"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["PoNo"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PoNo"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PoNo"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["PoSeqNo"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PoSeqNo"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PoSeqNo"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["CustCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["CustCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["CustCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["CustName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["CustName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["CustName"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["InspWaitDate"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["InspWaitDate"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["InspWaitDate"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["TotInspQty"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["TotInspQty"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["TotInspQty"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["InspDate"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["InspDate"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["InspDate"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["TSampleQty"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["TSampleQty"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["TSampleQty"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["TInspResult"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["TInspResult"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["TInspResult"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ItemCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["itemCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["itemCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ItemName"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ItemName"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ItemName"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE
        }
        #endregion   QM0910_Load

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

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                                                               // 사업장 공장코
                DateTime sStartDate = Convert.ToDateTime(((DateTime)this.CboStartdate_H.Value).ToString("yyyy-MM-dd") + " 00:00:00.00");    // 검사일자(시) 
                DateTime sEndDate = Convert.ToDateTime(((DateTime)this.CboEnddate_H.Value).ToString("yyyy-MM-dd") + " 23:59:59.99");        // 검사일자(종) 
                string sItemCode = this.txtItemCode.Text;                                                                                   // 품목     
                string sCustCode = this.txtCustCode.Text.Trim();                                                                            // 업체코드            	
                string sInspResult = DBHelper.nvlString(cboInspResult_H.Value);                                                             // 검사결과     
                string sPoNo = this.txtPoNo.Text.Trim();                                                                                    // 발주번호     

                grid1.DataSource = helper.FillTable("USP_QM0910_S1N", CommandType.StoredProcedure
                                                                     , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)                   // 공장(사업장) 
                                                                     , helper.CreateParameter("StartDate", sStartDate, DbType.DateTime, ParameterDirection.Input)                 // 검사일자(시) 
                                                                     , helper.CreateParameter("EndDate", sEndDate, DbType.DateTime, ParameterDirection.Input)                     // 검사일자(종) 
                                                                     , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)                     // 품목     
                                                                     , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input)               	  // 업체코드     
                                                                     , helper.CreateParameter("InspResult", sInspResult, DbType.String, ParameterDirection.Input)           	  // 검사결과     
                                                                     , helper.CreateParameter("PoNo", sPoNo, DbType.String, ParameterDirection.Input));
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


        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        #region 텍스트 박스에서 팝업창에서 값 가져오기

        private void Search_Pop_Item()
        {
            //임시로 사용할 데이터테이블 생성
            DataTable _DtTemp = new DataTable();
            string sitem_cd = this.txtItemCode.Text.Trim();    // 품목
            string sitem_name = this.txtItemName.Text.Trim();  // 품목명
            string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);
            // string splantcd = "820";
            string sitemtype = "";


            try
            {

                //_DtTemp = _biz.SEL_BM0100(sPlantCode, sitem_cd, sitem_name, sitemtype);

                if (_DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    _DtTemp = pu.OpenPopUp("Item", new string[] { sPlantCode, sitemtype, sitem_cd, sitem_name }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

                    if (_DtTemp != null && _DtTemp.Rows.Count > 0)
                    {
                        txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                }
                else
                {
                    if (_DtTemp.Rows.Count == 1)
                    {
                        txtItemCode.Text = Convert.ToString(_DtTemp.Rows[0]["ItemCode"]);
                        txtItemName.Text = Convert.ToString(_DtTemp.Rows[0]["Itemname"]);
                    }
                    else
                    {
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                        txtItemCode.Text = string.Empty;
                        txtItemName.Text = string.Empty;
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
            this.txtItemName.Text = string.Empty;
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_Item();
            }
        }

        private void txtItemCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_Item();
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtItemCode.Text = string.Empty;
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_Item();
            }
        }

        private void txtItemName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_Item();
        }
        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustName.Text = string.Empty;
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustCode.Text = string.Empty;
        }

        private void txtCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0300();
            }
        }

        private void txtCustCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0300();
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0300();
            }
        }

        private void txtCustName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0300();
        }

        #endregion

        #region  업체 찾기(조회조전)
        private void Search_Pop_TBM0300()
        {
            string sCustCode = txtCustCode.Text.Trim();       //업체코드
            string sCustName = txtCustName.Text.Trim();       //업체명 
            string sCustType = "V";                         //업체구부(V=Vendor) 
            string sUseFlag = "Y";                          //사용여부         

            try
            {
                //_biz.BM0030_POP(sCustCode, sCustName, sCustType, sUseFlag, txtCustCode, txtCustName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion  업체 찾기(조회조전)
    }
}

