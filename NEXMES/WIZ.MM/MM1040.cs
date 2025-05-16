#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM1040
//   Form Name    : 블록재고 부적합 처리
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM1040 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>

        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        private DataTable DtChange = null;

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        private string plantCode = string.Empty; //plantcode default 설정
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string sTraNo = string.Empty;
        private string sTraType = string.Empty;
        private string sTraPlanDate = string.Empty;
        #endregion

        #region < CONSTRUCTOR >

        public MM1040()
        {
            InitializeComponent();
            this.plantCode = CModule.GetAppSetting("Site", "10");

        }
        #endregion

        #region  < MM1040_Load >
        private void MM1040_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRADATE", "반출증등록일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRAPLNDATE", "반출예정일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRANO", "반출증번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRATYPE", "반출증유형", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRASTATUS", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CNTITEM", "총품목수", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARCARRYDATE", "상차일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARCARRYPERSON", "상차담당자", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTPERSON", "출고담당자", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TRANO", "반출증번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SUMLOTOTY", "수량", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SUMWGT", "중량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRANO", "반출증번호", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTQTY", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "RETURNDATE", "반입일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "RETURNFLAG", "반입여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region 콤보박스
            Common _Common = new Common();

            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);

            rtnDtTemp = _Common.GET_BM0000_CODE("TRASTATUS");  //반출상태
            WIZ.Common.FillComboboxMaster(this.cboTraStatus_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TRASTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("TRATYPE");  //반출구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TRATYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "", "Y", "" });

            cboPlantCode_H.Value = plantCode;

            //    DoInquire();
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (!CheckData())
            {
                return;
            }
            DBHelper helper = new DBHelper(false);

            try
            {
                //base.DoInquire();

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                      // 사업장 공장코드
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                    // 종료일자
                string sTrano = this.txtTraNo_H.Text;
                string sTraStatus = Convert.ToString(cboTraStatus_H.Value);
                string sCustCode = this.txtCustCode.Text.Trim();                                 // 업체코드      
                string schkTrano = Convert.ToString(chkTrano_H.Checked);

                rtnDtTemp = helper.FillTable("USP_MM1040_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)   //사업부(공장)
                                                                    , helper.CreateParameter("STARTDATE", sSrart, DbType.String, ParameterDirection.Input)       //시작일자(시)
                                                                    , helper.CreateParameter("ENDDATE", sEnd, DbType.String, ParameterDirection.Input)           //종료일자(종)
                                                                    , helper.CreateParameter("TRANO", sTrano, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TRASTATUS", sTraStatus, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("CHKTRANO", schkTrano, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();
                if (rtnDtTemp.Rows.Count > 0)
                {
                    //grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    _GridUtil.Grid_Clear(grid2);
                    _GridUtil.Grid_Clear(grid3);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
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
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion

        private void grid1_ClickCell(object sender, EventArgs e)
        {

            if (this.grid1.Rows.Count == 0) return;

            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPLANTCODE = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();    //GRID1.공장 
                string sTRANO = grid1.ActiveRow.Cells["TRANO"].Value.ToString();            //GRID1.반출번호  

                rtnDtTemp = helper.FillTable("USP_MM1040_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRANO", sTRANO, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid2);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                DtChange = rtnDtTemp;
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

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            if (this.grid2.Rows.Count == 0) return;

            _GridUtil.Grid_Clear(grid3);

            DBHelper helper = new DBHelper(false);

            try
            {
                //         string sPLANTCODE = grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString();       //GRID2.공장
                string sTRANO = grid2.ActiveRow.Cells["TRANO"].Value.ToString();             //GRID2.반출번호   
                string sITEMCODE = grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();           //GRID2.품목명   

                rtnDtTemp = helper.FillTable("USP_MM1040_S3", CommandType.StoredProcedure
                                                            // , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("TRANO", sTRANO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();


                if (rtnDtTemp.Rows.Count > 0)
                {

                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds(rtnDtTemp);

                }
                else
                {
                    _GridUtil.Grid_Clear(grid3);
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                //   DtChange = rtnDtTemp;
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
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtStart_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        //반출증 재발행
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.grid1.UpdateData();

            int CheckCnt = 0;
            if (grid1.Rows.Count < 1)
            {
                this.ShowDialog(Common.getLangText("조회된 데이터가 없습니다", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            else
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["CHK"].Value.ToString().ToUpper() == "TRUE")
                        CheckCnt++;
                }

                if (CheckCnt == 0)
                {
                    this.ShowDialog(Common.getLangText("선택된 데이터가 없습니다", "MSG"), DialogForm.DialogType.OK);
                    return;
                }

                //for (int i = 0; i < grid3.Rows.Count; i++)
                //{
                //    if (grid3.Rows[i].Cells["RETURNFLAG"].Value.ToString().ToUpper() == "Y")
                //    {
                //        this.ShowDialog("반출품이 반입된 경우로 반출증 재발행이 불가합니다.", DialogForm.DialogType.OK);
                //        return;
                //    }
                //}
            }

            //재발행시
            Print();

        }

        private void Print()
        {
            DataTable dtForPrint = new DataTable();
            DataTable dtGrid = (DataTable)grid1.DataSource;


            dtForPrint.Columns.Add("TRANO", typeof(string));
            dtForPrint.Columns.Add("TRATYPE", typeof(string));


            //출력순번
            //int iPrintNum = Convert.ToInt16(cboNumber.Value);

            //if (iPrintNum > 1)
            //{
            //    for (int i = 0; i < iPrintNum - 1; i++)
            //    {
            //        dtForPrint.Rows.Add("", "", "", "", "", "", "");
            //    }
            //}

            foreach (DataRow dr_Grid in dtGrid.Rows)
            {
                if (dr_Grid["CHK"].ToString().ToUpper() != "TRUE")
                    continue;

                dtForPrint.Rows.Add(dr_Grid["TRANO"].ToString()
                                    , dr_Grid["TRATYPE"].ToString()
                                   );
            }

            POP_MM0300X POP_MM0300X = new POP_MM0300X(dtForPrint, "Y");
            POP_MM0300X.ShowDialog();
        }
        private void Print_Certificating(string sTraNo, string TraTypeName)
        {
            string sPlantCode = Convert.ToString(DtChange.Rows[0]["PLANTCODE"]);

            POP_MM0300X POP_MM0300X = new POP_MM0300X(sPlantCode, sTraNo, TraTypeName, "");
            POP_MM0300X.ShowDialog();
        }


        #region < EVENT AREA >


        #endregion

    }
}
