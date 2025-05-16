
#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MM0280
//   Form Name    : 수입검사 등록
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0280 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private string sPlant = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();

        public string sTest = string.Empty;


        //ActiveRow 활성화로 Dialog를 2번 띄워 1번만 띄우기 위해 숫자 제한 설정
        int cnt = 0;

        //BeforeRow에서 물어본 뒤 ActiveRow에서 처리하기 위해 선언
        private DialogResult mResult;

        //이전 선택한 그리드를 재 선택하기 위해 key 값인 lot번호를 사용
        private string sLot = string.Empty;

        //입력 여부, 입력 시 다른 그리드 선택 불가를 확인하기 위해 변수 선언
        private Boolean changeYN = false;

        #endregion

        #region < CONSTRUCTOR >
        public MM0280()
        {
            InitializeComponent();
        }
        #endregion

        #region < MM0280_Load >
        private void MM0280_Load(object sender, EventArgs e)
        {
            Common _Common = new Common();
            #region Grid 셋팅

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "발행일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRSNSTNO", "거래명세번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRSNSTNOSEQ", "거래명세순번", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE", "품목구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPENAME", "품목구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "수량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURECODE", "측정항목코드", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURENAME", "측정항목명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURETYPE", "측정값구분", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURETYPENAME", "측정값구분", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECTYPE", "SPEC적용기준", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECNAME", "SPEC적용기준", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECVALUE", "기준값", true, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECUSL", "상한값", true, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECLSL", "하한값", true, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASUREVALUE", "측정값", true, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0.##", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OKNG", "판정", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            _GridUtil.InitColumnUltraGrid(grid3, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PRODDATE", "발행일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTCODE", "거래처코드", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRSNSTNO", "거래명세번호", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRSNSTNOSEQ", "거래명세순번", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMTYPE", "품목구분", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "ITEMTYPENAME", "품목구분", true, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "LOTQTY", "수량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPDATE", "수입검사일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPRESULT", "수입검사판정", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "INSPRESULTNAME", "수입검사판정", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            GetITEMTYPE();
            GetOKNG();

            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            BizGridManager bizGridManager;
            //btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "ROH" });
            //btbManager.PopUpAdd(txtCustCode_H, txtCustName_H, "TBM0301", new object[] { cboPlantCode_H, "C", "", "false" });

            //// grid 입력용 POPUP
            //bizGridManager = new BizGridManager(grid1);
            //bizGridManager.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "ROH" });
            //bizGridManager.PopUpAdd("CustCode", "CustName", "TBM0301", new string[] { "PlantCode", "C", "" });

            #endregion

            cboStatrtDate_H.Value = DateTime.Now;
            cboEndDate_H.Value = DateTime.Now;

            sPlant = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.Value = sPlant;

        }
        #endregion



        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            mResult = 0;
            changeYN = false;
            cnt = 0;

            DBHelper helper = new DBHelper(false);

            try
            {
                string sTab = "";
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cboStatrtDate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);
                string sCustCode = txtCustCode_H.Text;
                string sCustName = txtCustName_H.Text;
                string sItemCode = txtItemCode_H.Text;
                string sItemName = txtItemName_H.Text;
                string sPoNo = txtPoNo.Text;
                string sLotNo = txtLotNo_H.Text;
                string sChkFlag = Convert.ToString(chkPoNo_H.Checked).ToUpper();
                string sItemType = Convert.ToString(cboItemType_H.Value);
                string sOkNg = Convert.ToString(cboOKNG_H.Value);

                if (sChkFlag == "TRUE") { sChkFlag = "Y"; } else { sChkFlag = "N"; }
                if (tabControl1.SelectedTab.Index == 0) { sTab = "TAB1"; } else { sTab = "TAB2"; }

                //base.DoInquire();

                rtnDtTemp = helper.FillTable("USP_MM0280_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("@AS_TAB", sTab, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_CUSTNAME", sCustName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_ITEMNAME", sItemName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_OKNG", sOkNg, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_TRSNSTNO", sPoNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@AS_CHK", sChkFlag, DbType.String, ParameterDirection.Input));
                if (helper.RSCODE == "S")
                {

                    if (sTab == "TAB1")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid1.DataSource = rtnDtTemp;
                            grid1.DataBinds();
                        }
                        else
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            setGridClear(sTab);
                            return;
                        }
                    }

                    if (sTab == "TAB2")
                    {
                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid3.DataSource = rtnDtTemp;
                            grid3.DataBinds();
                        }
                        else
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            setGridClear(sTab);
                            return;
                        }
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    setGridClear(sTab);
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                throw ex;
            }
            finally
            {
                helper.Close();
            }

        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew() { }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete() { }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            string sTab = string.Empty;

            if (tabControl1.SelectedTab.Index == 0) { sTab = "TAB1"; } else { sTab = "TAB2"; }

            if (sTab == "TAB1")
            {
                //this.ShowDialog("수입검사 등록 취소 시에 이용가능합니다.", Forms.DialogForm.DialogType.OK);
                btnSave_Click(null, null);
                return;
            }

            if (sTab == "TAB2")
            {
                DBHelper helper = new DBHelper(false);

                try
                {
                    int iCnt = 0;

                    for (int i = 0; i < grid3.Rows.Count; i++)
                    {
                        if (grid3.Rows[i].Cells["CHK"].Value.ToString() == "True")
                            iCnt++;
                    }

                    if (iCnt == 0)
                    {
                        this.ShowDialog(Common.getLangText("체크박스 선택 후 이용가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    }

                    for (int i = 0; i < grid3.Rows.Count; i++)
                    {

                        if (grid3.Rows[i].Cells["CHK"].Value.ToString() == "True")
                        {

                            string sPLANTCODE = Convert.ToString(grid3.Rows[i].Cells["PLANTCODE"].Value);
                            string sLOTNO = Convert.ToString(grid3.Rows[i].Cells["LOTNO"].Value);

                            helper.ExecuteNoneQuery("USP_MM0280_D1", CommandType.StoredProcedure//,ref RS_CODE, ref RS_MSG
                                                                , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                        }

                        if (helper.RSCODE == "E")
                        {
                            helper.Rollback();
                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        DoInquire();
                        //err = "s";
                    }

                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    this.ShowDialog(ex.ToString());
                }
                finally
                {
                    helper.Close();
                }
            }
        }
        #endregion

        #region [ Event Area ]

        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                lblOKNG_H.Visible = false;
                cboOKNG_H.SelectedIndex = 0;
                cboOKNG_H.Visible = false;
            }
            if (tabControl1.SelectedTab.Index == 1)
            {
                lblOKNG_H.Visible = true;
                cboOKNG_H.Visible = true;
            }
        }

        private void grid3_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "CHK")
                return;

            this.grid3.ActiveRow.Cells["CHK"].Value = Convert.ToString(e.Cell.Value).ToUpper() == "TRUE" ? "False" : "True";
        }

        private void grid1_BeforeRowActivate(object sender, RowEventArgs e)
        {
            if (changeYN && cnt == 0)
            {
                mResult = this.ShowDialog(Common.getLangText("수입검사 등록을 완료하지 않은채로 다른 항목 선택 시 입력한 정보가 초기화됩니다. 진행하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO);
                cnt++;
            }
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {

            //mResult = this.ShowDialog("수입검사 등록을 완료하지 않은채로 다른 항목 선택 시 입력한 정보가 초기화됩니다. 진행하시겠습니까?", Forms.DialogForm.DialogType.YESNO);

            if (mResult.ToString().ToUpper() == "CANCEL")
            {
                foreach (UltraGridRow row in grid1.Rows)
                {
                    if (Convert.ToString(row.Cells["LOTNO"].Value) == sLot)
                    {
                        grid1.ActiveRow = row;
                        cnt = 0;
                        break;
                    }
                }

                grid2.DataSource = rtnDtTemp2;
                grid2.DataBinds(rtnDtTemp2);
            }
            else
            {
                DBHelper helper = new DBHelper(false);

                try
                {
                    string sPLANTCODE = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();      //사업장
                    string sLOTNO = grid1.ActiveRow.Cells["LOTNO"].Value.ToString();      //LOTNO

                    _GridUtil.Grid_Clear(grid2);

                    rtnDtTemp = helper.FillTable("USP_MM0280_S2", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input));
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds(rtnDtTemp);

                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid2);
                        // 조회할 데이터가 없습니다.
                        //this.ShowDialog("R00111", WIZ.Forms.DialogForm.DialogType.OK);
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

                cnt = 0;
                changeYN = false;
            }

            sLot = grid1.ActiveRow.Cells["LOTNO"].Value.ToString();

        }


        private void grid2_ClickCell(object sender, EventArgs e)
        {

            ///검사구분에 따른 visible 처리
            if (grid2.ActiveRow == null)
            {
                txtMeasureValue.Enabled = false;
                txtMeasureValue.Visible = false;
                lblMeasureValue.Visible = false;
                cboInspResult.Enabled = false;
                cboInspResult.Visible = false;
                lblInspResult.Visible = false;

            }

            if (grid2.ActiveRow != null)
            {
                string str = Convert.ToString(grid2.ActiveRow.Cells["MEASURETYPE"].Value);

                //검사구분에 따른 visible 처리
                //MEASURETYPE 기준코드가 변경되어 수정 최재형
                //기존 V:값, D:판정, VD:값+판정 -> 변경 V:값, J:판정, D:판정+값
                if (str == "V")
                {
                    txtMeasureValue.Enabled = true;
                    txtMeasureValue.Visible = true;
                    lblMeasureValue.Visible = true;
                    cboInspResult.Enabled = false;
                    cboInspResult.Visible = false;
                    lblInspResult.Visible = false;
                }
                else if (str == "J")
                {
                    txtMeasureValue.Enabled = false;
                    txtMeasureValue.Visible = false;
                    lblMeasureValue.Visible = false;
                    cboInspResult.Enabled = true;
                    cboInspResult.Visible = true;
                    lblInspResult.Visible = true;
                }
                else if (str == "D")
                {
                    txtMeasureValue.Enabled = true;
                    txtMeasureValue.Visible = true;
                    lblMeasureValue.Visible = true;
                    cboInspResult.Enabled = true;
                    cboInspResult.Visible = true;
                    lblInspResult.Visible = true;
                }

                txtInspCode.Text = Convert.ToString(grid2.ActiveRow.Cells["INSPCODE"].Value);        //검사코드
                txtInspName.Text = Convert.ToString(grid2.ActiveRow.Cells["INSPNAME"].Value);        //검사코드명
                txtMeasureCode.Text = Convert.ToString(grid2.ActiveRow.Cells["MEASURECODE"].Value);     //측정항목코드
                txtMeasureName.Text = Convert.ToString(grid2.ActiveRow.Cells["MEASURENAME"].Value);     //측정항목명
                txtMeasureType.Text = Convert.ToString(grid2.ActiveRow.Cells["MEASURETYPE"].Value);     //측정값 구분
                txtMeasureTypeName.Text = Convert.ToString(grid2.ActiveRow.Cells["MEASURETYPENAME"].Value); //측정값 구분명
                txtSpecType.Text = Convert.ToString(grid2.ActiveRow.Cells["SPECTYPE"].Value);        //SPEC 적용기준
                txtSpecName.Text = Convert.ToString(grid2.ActiveRow.Cells["SPECNAME"].Value);        //SPEC 적용기준명
                txtSpecValue.Text = Convert.ToString(grid2.ActiveRow.Cells["SPECVALUE"].Value);       //기준값
                txtSpecUsl.Text = Convert.ToString(grid2.ActiveRow.Cells["SPECUSL"].Value);         //상한값
                txtSpecLsl.Text = Convert.ToString(grid2.ActiveRow.Cells["SPECLSL"].Value);         //하한값
                txtMeasureValue.Text = Convert.ToString(grid2.ActiveRow.Cells["MEASUREVALUE"].Value);    //측정값
                cboInspResult.Value = Convert.ToString(grid2.ActiveRow.Cells["OKNG"].Value);            //판정
            }
        }

        private void txtMeasureValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtMeasureValue.Text == "")
                    txtMeasureValue.Text = "0";

                grid2.ActiveRow.Cells["MEASUREVALUE"].Value = txtMeasureValue.Text;

                rtnDtTemp2 = (DataTable)grid2.DataSource;
                changeYN = true;
            }
        }

        private void txtMeasureValue_Leave(object sender, EventArgs e)
        {
            if (grid2.ActiveRow != null)
            {
                if (txtMeasureValue.Text != "")
                {
                    grid2.ActiveRow.Cells["MEASUREVALUE"].Value = txtMeasureValue.Text;

                    rtnDtTemp2 = (DataTable)grid2.DataSource;
                    changeYN = true;
                }
            }
        }

        private void cboInspResult_SelectionChanged(object sender, EventArgs e)
        {
            if (grid2.ActiveRow != null)
            {
                if (cboInspResult.Value != "")
                {
                    grid2.ActiveRow.Cells["OKNG"].Value = cboInspResult.Value;
                    rtnDtTemp2 = (DataTable)grid2.DataSource;

                    changeYN = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grid2.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("수입검사 등록은 조회 후 이용가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            string sMeasureType = string.Empty;


            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                sMeasureType = grid2.Rows[i].Cells["MEASURETYPE"].Value.ToString();
                string sValue = grid2.Rows[i].Cells["MEASUREVALUE"].Value.ToString();
                string sOKNG = grid2.Rows[i].Cells["OKNG"].Value.ToString();
                Boolean checkErr = false;

                //필수 값 체크
                /*
                    MEASURETYPE = V  => 측정값 필수
                    MEASURETYPE = D  => 판정값 필수
                    MEASURETYPE = VD => 측정값+판정값 필수
                */
                if (sMeasureType == "V" && sValue == "")
                {
                    this.ShowDialog(Common.getLangText("측정값을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    checkErr = true;
                }

                else if (sMeasureType == "J" && sOKNG == "")
                {
                    this.ShowDialog(Common.getLangText("판정결과를 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    checkErr = true;
                }

                else if (sMeasureType == "D")
                {
                    checkErr = true;
                    if (sValue == "")
                    {
                        this.ShowDialog(Common.getLangText("측정값을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    }
                    if (sOKNG == "")
                    {
                        this.ShowDialog(Common.getLangText("판정결과를 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    }
                    else
                        checkErr = false;
                }

                if (checkErr)
                {
                    grid2.ActiveRow = grid2.Rows[i];
                    return;
                }
            }

            DBHelper helper = new DBHelper("", true);
            try
            {
                string sPLANTCODE = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sPREINDATE = Convert.ToString(grid1.ActiveRow.Cells["PRODDATE"].Value);
                string sLOTNO = Convert.ToString(grid1.ActiveRow.Cells["LOTNO"].Value);
                string sCUSTCODE = Convert.ToString(grid1.ActiveRow.Cells["CUSTCODE"].Value);
                string sITEMCODE = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sITEMTYPE = Convert.ToString(grid1.ActiveRow.Cells["ITEMTYPE"].Value);
                double sLOTQTY = Convert.ToDouble(grid1.ActiveRow.Cells["LOTQTY"].Value);
                string sUNITCODE = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);


                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    string sINSPCODE = Convert.ToString(grid2.Rows[i].Cells["INSPCODE"].Value);
                    string sMEASURECODE = Convert.ToString(grid2.Rows[i].Cells["MEASURECODE"].Value);
                    string sMEASURETYPE = Convert.ToString(grid2.Rows[i].Cells["MEASURETYPE"].Value);
                    string sINSPRESULT = Convert.ToString(grid2.Rows[i].Cells["MEASUREVALUE"].Value);
                    string sSPECTYPE = Convert.ToString(grid2.Rows[i].Cells["SPECTYPE"].Value);

                    string sOKNG = string.Empty;
                    double sINSPRESULTVAL = 0;

                    double sSPECUSL = Convert.ToDouble(grid2.Rows[i].Cells["SPECUSL"].Value);
                    double sSPECLSL = Convert.ToDouble(grid2.Rows[i].Cells["SPECLSL"].Value);

                    /* 측정값 */
                    if (sMEASURETYPE == "V")
                    {
                        sINSPRESULTVAL = Convert.ToDouble(grid2.Rows[i].Cells["MEASUREVALUE"].Value);
                        /*  OKNG = 1:OK, 2:NG      */

                        if (sSPECTYPE == "L")
                        {
                            if (sINSPRESULTVAL > sSPECLSL)
                            {
                                sOKNG = "2";
                            }
                            else
                                sOKNG = "1";
                        }
                        else if (sSPECTYPE == "B")
                        {
                            if (sINSPRESULTVAL > sSPECUSL || sINSPRESULTVAL < sSPECLSL)
                            {
                                sOKNG = "2";
                            }
                            else
                                sOKNG = "1";
                        }
                        else if (sSPECTYPE == "U")
                        {
                            if (sINSPRESULTVAL < sSPECUSL)
                            {
                                sOKNG = "2";
                            }
                            else
                                sOKNG = "1";
                        }
                        else
                            sOKNG = "2";
                    }

                    /* 판정 */
                    else if (sMEASURETYPE == "J")
                    {
                        sOKNG = Convert.ToString(grid2.Rows[i].Cells["OKNG"].Value);

                    }
                    /* 측정값 + 판정 */
                    else if (sMEASURETYPE == "D")
                    {
                        sINSPRESULTVAL = Convert.ToDouble(grid2.Rows[i].Cells["MEASUREVALUE"].Value);
                        sOKNG = Convert.ToString(grid2.Rows[i].Cells["OKNG"].Value);

                        if (sSPECTYPE == "L")
                        {
                            if (sINSPRESULTVAL > sSPECLSL)
                            {
                                sOKNG = "2";
                            }
                            else if (sOKNG == "1")
                                sOKNG = "1";
                        }
                        else if (sSPECTYPE == "B")
                        {
                            if (sINSPRESULTVAL > sSPECUSL || sINSPRESULTVAL < sSPECLSL)
                            {
                                sOKNG = "2";
                            }
                            else if (sOKNG == "1")
                                sOKNG = "1";
                        }
                        else if (sSPECTYPE == "U")
                        {
                            if (sINSPRESULTVAL < sSPECUSL)
                            {
                                sOKNG = "2";
                            }
                            else if (sOKNG == "1")
                                sOKNG = "1";
                        }
                        else
                            sOKNG = "2";
                    }



                    helper.ExecuteNoneQuery("USP_MM0280_I1", CommandType.StoredProcedure//,ref RS_CODE, ref RS_MSG
                                                       , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_CUSTCODE", sCUSTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ITEMTYPE", sITEMTYPE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_PREINDATE", sPREINDATE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_INSPCODE", sINSPCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_MEASURECODE", sMEASURECODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_MEASURETYPE", sMEASURETYPE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AF_LOTQTY", sLOTQTY, DbType.Double, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_UNITCODE", sUNITCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_OKNG", sOKNG, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_INSPRESULTVAL", sINSPRESULTVAL, DbType.Double, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_SPECUSL", sSPECUSL, DbType.Double, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_SPECLSL", sSPECLSL, DbType.Double, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                    if (helper.RSCODE == "E")
                    {
                        helper.Rollback();
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }

                helper.ExecuteNoneQuery("USP_MM0280_I2", CommandType.StoredProcedure//,ref RS_CODE, ref RS_MSG
                                                       , helper.CreateParameter("AS_PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_LOTNO", sLOTNO, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_CUSTCODE", sCUSTCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ITEMCODE", sITEMCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_ITEMTYPE", sITEMTYPE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AF_LOTQTY", sLOTQTY, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_UNITCODE", sUNITCODE, DbType.String, ParameterDirection.Input)
                                                       , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    //helper.Commit();
                    DoInquire();
                    //err = "s";
                }
                else if (helper.RSCODE == "E")
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    //err = "e";
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
                //err = "e";
            }
            finally
            {
                helper.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid2.ActiveRow != null)
            {
                grid2.ActiveRow.Cells["MEASUREVALUE"].Value = string.Empty;
                grid2.ActiveRow.Cells["OKNG"].Value = string.Empty;
            }

            txtMeasureValue.Text = string.Empty;   //측정값
            cboInspResult.Value = string.Empty;   //판정

            for (int i = 0; i < grid2.Rows.Count; i++)
            {
                if (grid2.Rows[i].Cells["MEASUREVALUE"].Value.ToString() != "" ||
                    grid2.Rows[i].Cells["OKNG"].Value.ToString() != "")
                {
                    changeYN = true;
                    break;
                }
                else
                {
                    mResult = 0;
                    changeYN = false;
                    cnt = 0;
                }
            }
        }
        #endregion


        #region [ User Method Area ]
        private void GetOKNG()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE  AS CODE_ID,   ");
                command.AppendLine("       CODENAME   AS CODE_NAME  ");
                command.AppendLine("  FROM TBM0000                  ");
                command.AppendLine(" WHERE MAJORCODE = 'OKNG'       ");
                command.AppendLine("   AND MINORCODE IN ('1','2')   ");
                command.AppendLine(" ORDER BY DISPLAYNO             ");


                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(cboOKNG_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "선택", "");
                WIZ.Common.FillComboboxMaster(cboInspResult, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "선택", "");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void GetITEMTYPE()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder command = new StringBuilder();

                command.AppendLine("SELECT MINORCODE  AS CODE_ID,   ");
                command.AppendLine("       CODENAME   AS CODE_NAME  ");
                command.AppendLine("  FROM TBM0000                  ");
                command.AppendLine(" WHERE MAJORCODE = 'ITEMTYPE'       ");
                command.AppendLine("   AND MINORCODE IN ('FERT','HALB')   ");
                command.AppendLine(" ORDER BY DISPLAYNO             ");


                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                WIZ.Common.FillComboboxMaster(cboItemType_H, dttemp, dttemp.Columns["CODE_ID"].ColumnName, dttemp.Columns["CODE_NAME"].ColumnName, "All", "");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        private void setGridClear(string sTab)
        {
            if (sTab == "TAB1")
            {
                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);
            }
            if (sTab == "TAB2")
            {
                _GridUtil.Grid_Clear(grid3);
            }
        }




        #endregion
    }
}
