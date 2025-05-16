#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1430
//   Form Name    : 자재 외주 유무상 사급 출고 정보 조회
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
    public partial class MM1430 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();
        #endregion

        #region < CONSTRUCTOR >

        public MM1430()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "", "" });
        }
        #endregion

        #region  MM1430_Load
        private void MM1430_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅 //100 130 100 196 165 100 87 123 123 100 201 100 100 191 228 100 100
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutDate", "출고(투입)일자", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MatLotNo", "자재Lot번호", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutQty", "출고량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutSeqNo", "출고SeqNo", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutReqNo", "출고요청번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "불출업체코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustName", "불출업체", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "출고관련사항(비고)", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutWorker", "출고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutStemp", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

        }
        #endregion  MM1430_Load

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

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);                            // 사업장 공장코드
                string sOUTDATE_FROM = string.Format("{0:yyyy-MM-dd}", cboPlanIndate1_H.Value);          // 라벨발행일자(시)
                string sOUTDATE_TO = string.Format("{0:yyyy-MM-dd}", cboPlanIndate2_H.Value);            // 라밸발행일자(종)
                string sCustCode = this.txtCustCode.Text.Trim();                                         // 업체코드              	
                string sItemCode = this.txtItemCode.Text;                                                // 품목

                grid1.DataSource = helper.FillTable("USP_MM1430_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)            //사업부(공장)
                                                                    , helper.CreateParameter("OUTDATE_FROM", sOUTDATE_FROM, DbType.String, ParameterDirection.Input)      //라벨발행일자(시)
                                                                    , helper.CreateParameter("OUTDATE_TO", sOUTDATE_TO, DbType.String, ParameterDirection.Input)          //라밸발행일자(종)
                                                                    , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)              //품목
                                                                    , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input));            //업체코드   

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
            string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
            // string splantcd = "820";
            string sitemtype = "";


            try
            {

                //_DtTemp = _biz.SEL_BM0010(sPlantCode, sitem_cd, sitem_name, sitemtype, "");

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
                        MessageBox.Show(Common.getLangText("입력하신 정보는 없는 정보입니다.", "MSG"), "ERROR");
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

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustName.Text = string.Empty;
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtCustCode.Text = string.Empty;
        }
        private void txtItemName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_Item();
        }

        #endregion

        #region  업체 찾기(조회조전)
        private void Search_Pop_TBM0300()
        {
            string sCustCode = txtCustCode.Text.Trim();       //업체코드
            string sCustName = txtCustName.Text.Trim();       //업체명 
            string sCustType = "V";                           //업체구부(V=Vendor) 
            string sUseFlag = "Y";                            //사용여부         

            try
            {
                _biz.BM0030_POP(sCustCode, sCustName, sCustType, sUseFlag, "", "", "", "");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion  업체 찾기(조회조전)
    }
}

