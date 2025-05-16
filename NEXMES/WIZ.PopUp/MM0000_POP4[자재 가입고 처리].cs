#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0000_POP
//   Form Name    : 자재 가입고 처리
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-03-21
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Description  : MM0000에서 가입고 버튼 Click시 POPUP 호출
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


#endregion

namespace WIZ.PopUp
{
    public partial class MM0000_POP4 : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >
        private string sPlantCode = string.Empty;                   //사업장
        private string sPoNo = string.Empty;                   //거래번호(PONO)  
        private string sPoSeqNo = string.Empty;                   //거래순번(POSEQ)     
        private string sCustCode = string.Empty;                   //거래처
        private string sCustName = string.Empty;                   //거래처명
        private string sItemCode = string.Empty;                   //품목
        private string sItemName = string.Empty;                   //품목명
        private string sPoQty = string.Empty;                   //발주량(A)
        private string sPoDate = string.Empty;                   //발주일
        private string sPlanInDate = string.Empty;                   //입고예정일자
        private string sMaterialgrade = string.Empty;                   //재질
        private string sItemSpec = string.Empty;                   //규격
        private string sItemType = string.Empty;                   //품목분류
        private string sUnitCode = string.Empty;                   //단위     
        private string sTmpInQty = string.Empty;                   //총 가입고 중량(B)
        private string sInQty = string.Empty;                   //입고 중량
        private string sReInQty = string.Empty;                   //입고 잔량(A-B)
        private string sTmpInGroupNo = string.Empty;

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();

        Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        Telerik.Reporting.InstanceReportSource viewerInstance = new Telerik.Reporting.InstanceReportSource();

        DataTable dt;
        #endregion

        #region < CONSTRUCTOR >
        public MM0000_POP4()
        {
            InitializeComponent();
        }

        public MM0000_POP4(DataRow drRow, bool bCheckPackQty = false, string sDate = "")
        {
            InitializeComponent();

            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
            sPoNo = Convert.ToString(drRow["PONO"]);
            //sPoDate        = Convert.ToString(drRow["PODATE"]);
            //sPoSeqNo       = Convert.ToString(drRow["POSEQNO"]);
            sPlanInDate = Convert.ToString(drRow["PLANINDATE"]);
            sCustCode = Convert.ToString(drRow["CUSTCODE"]);
            sCustName = Convert.ToString(drRow["CUSTNAME"]);
            sItemCode = Convert.ToString(drRow["ITEMCODE"]);
            sItemName = Convert.ToString(drRow["ITEMNAME"]);
            sMaterialgrade = Convert.ToString(drRow["MATERIALGRADE"]);
            sItemSpec = Convert.ToString(drRow["ITEMSPEC"]);
            sItemType = Convert.ToString(drRow["ITEMTYPENAME"]);
            sUnitCode = Convert.ToString(drRow["UNITCODE"]);
            sPoQty = Convert.ToString(drRow["POQTY"]);
            sTmpInQty = Convert.ToString(drRow["TMPINQTY"]);
            sInQty = Convert.ToString(drRow["INQTY"]);
            sReInQty = Convert.ToString(drRow["REINQTY"]);


            txt_PONO_B.Text = sPoNo;
            txt_POSEQ_B.Text = sPoSeqNo;
            txt_PLANINDATE_B.Text = sDate == "TODAY" ? DateTime.Now.ToString("yyyy-MM-dd") : sPlanInDate;
            txt_CUSTNAME_B.Text = sCustName;
            txt_ITEMCODE_B.Text = sItemCode;
            txt_ITEMNAME_B.Text = sItemName;
            txt_MATERIAL_B.Text = sMaterialgrade;
            txt_ITEMSPEC_B.Text = sItemSpec;
            txt_ITEMTYPE_B.Text = sItemType;
            txt_UNITCODE_B.Text = sUnitCode;
            txt_POQTY_B.Text = sPoQty;         //발주수량(A)
            txt_STOCKQTY_B.Text = sInQty;         //입고수량
            txt_TMPINQTY_B.Text = sTmpInQty;      //총 가입고 수량(B)
            txt_REINQTY_B.Text = sReInQty;       //입고잔량(A-B)

            lbl_NOTICE_B.ForeColor = Color.Red;

            DBHelper db = new DBHelper(false);

            dt = db.FillTable("SELECT * FROM BM0010 with (NOLOCK) where ITEMCODE = '" + sItemCode + "' and PlantCode = '" + sPlantCode + "' ");

            if (dt.Rows.Count == 1)
            {
                txtPackQty.Text = CModule.ToString(dt.Rows[0]["UNITPACK"]);
            }

            if (txtPackQty.Text == "")
            {
                if (bCheckPackQty)
                {
                    btn_SAVE_B.Enabled = false;
                    MessageBox.Show("포장 단위를 입력해야 사용 가능합니다.");
                }
            }
        }
        #endregion

        #region < FORM EVENT >
        private void MM0000_POP4_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "거래처 LOTNO", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "수량", true, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            this.grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            this.grid1.DisplayLayout.Bands[0].Summaries.Add("합계", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["LOTNO"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[0].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["LOTNO"];
            this.grid1.DisplayLayout.Bands[0].Summaries[0].DisplayFormat = "합계";
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Key = "LOTNO";
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.TextHAlign = HAlign.Center;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.FontData.SizeInPoints = 9;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[0].SummaryDisplayArea = SummaryDisplayAreas.Top;

            this.grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            this.grid1.DisplayLayout.Bands[0].Summaries.Add("", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["CUSTLOTNO"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["CUSTLOTNO"];
            this.grid1.DisplayLayout.Bands[0].Summaries[1].DisplayFormat = " ";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Key = "CUSTLOTNO";
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.TextHAlign = HAlign.Center;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.FontData.SizeInPoints = 9;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryDisplayArea = SummaryDisplayAreas.Top;


            this.grid1.DisplayLayout.Bands[0].Summaries.Add("SUM([LOTBASEQTY])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["LOTBASEQTY"]);
            this.grid1.DisplayLayout.Bands[0].Summaries[2].DisplayFormat = "{0:#,##0}";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["LOTBASEQTY"];
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Key = "LOTBASEQTY";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.TextHAlign = HAlign.Right;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.FontData.SizeInPoints = 10;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.BackColor = Color.FromArgb(255, 228, 225);
            this.grid1.DisplayLayout.Bands[0].Summaries[2].Appearance.ForeColor = Color.Black;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SourceColumn.Format = "#,##0";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryPositionColumn.Format = "#,##0";
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryDisplayArea = SummaryDisplayAreas.Top;
            this.grid1.DisplayLayout.Bands[0].Summaries[2].SummaryType = SummaryType.Sum;


            _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "TMPINDATE", "가입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "거래처명", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SUBLOT", "거래처LOTNO", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTQTY", "가입고수량", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region < COMBOBOX SETTING >

            #endregion

            SetData();
        }

        protected override void SetSubData()
        {
            DataRow dr = subData["METHOD_TYPE", "SUBLOTNAME"];

            if (dr != null)
            {
                string sColName = CModule.ToString(dr["RELCODE1"]);

                lblSubLot.Text = sColName;
            }
        }
        #endregion

        #region < METHOD AREA >
        /// <summary>
        /// 식별표 발행, 닫기 버튼 클릭 시 발주번호 상태 변경 로직 
        /// </summary>
        private void UpdateFinishFlag()
        {
            int iPoQty = Convert.ToInt32(txt_POQTY_B.Text);            //발주수량
            int iTotInQty = Convert.ToInt32(txt_TMPINQTY_B.Text);      //가입고수량
            string sUseFlag = string.Empty;

            //업데이트 시 가입고 수량이 0인 경우..
            if (iTotInQty == 0)
            {
                return;
            }

            if (iPoQty <= iTotInQty)
            {
                //발주수량 <= 가입고 수량일 경우.. 발주완료 처리..
                sUseFlag = "Y";
            }
            else
            {
                //그 외..진행상태
                sUseFlag = "I";
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                helper.ExecuteNoneQuery("USP_MM0000_POP_U1"
                                       , CommandType.StoredProcedure
                                       , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_POSEQNO", sPoSeqNo, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_FINISHFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                       , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                }
                else
                {
                    helper.Rollback();
                    MessageBox.Show(helper.RSMSG);
                }


            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// 발주그룹번호 채번
        /// </summary>
        private void TmpInGroupNo()
        {
            DBHelper helper = new DBHelper(false);

            string sNowDate = txt_PLANINDATE_B.Text;

            try
            {
                StringBuilder command = new StringBuilder();
                command.AppendLine("BEGIN");
                command.AppendLine(" DECLARE @LOTNO NVARCHAR(20), @RS_MSG VARCHAR(100) ");
                command.AppendLine(" EXEC USP_CREATE_NEXTSEQ 'PG', '" + sNowDate + "', '*', @LOTNO OUTPUT, @RS_MSG OUTPUT ");
                command.AppendLine(" SELECT @LOTNO AS LOTNO , @RS_MSG AS RS_MSG;");
                command.AppendLine("END");

                DataTable rtnDtTemp = helper.FillTable(command.ToString());

                if (Convert.ToString(rtnDtTemp.Rows[0][0]) != "NONE")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        sTmpInGroupNo = Convert.ToString(rtnDtTemp.Rows[0]["LOTNO"]);
                    }
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }
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

        private void SetData()
        {
            _GridUtil.Grid_Clear(grid2);

            DBHelper helper = new DBHelper(false);

            try
            {
                grid2.DataSource = helper.FillTable("USP_MM0000_POP_S2"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));



                grid2.DataBinds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        #endregion

        #region < EVENT AREA >
        private void btnClose_Click(object sender, EventArgs e)
        {
            UpdateFinishFlag();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _GridUtil.Grid_Clear(grid1);
            txt_INPUTQTY_B.Text = string.Empty;
            txt_INPUTCNT_B.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                string sLotNo1 = string.Empty;
                string sLotNo2 = string.Empty;

                if (CModule.ToDouble(txt_INPUTQTY_B.Text) <= 0)
                {
                    MessageBox.Show(Common.getLangText("가입고 수(중)량을 입력하세요.", "MSG"));
                    return;
                }

                if (txt_INPUTCNT_B.Text == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("입고수량을 입력하세요.", "MSG"));
                    return;
                }

                if (txt_PLANINDATE_B.Text == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("입고일자를 입력하세요.", "MSG"));
                    return;
                }

                if (Regex.IsMatch(txt_PLANINDATE_B.Text, @"^(19|20)\d{2}" + "-" + "(0[1-9]|1[012])" + "-" + "(0[1-9]|[12][0-9]|3[0-1])$") == false)
                {
                    MessageBox.Show(Common.getLangText("입고일자 형식을 yyyy-MM-dd 형태로 입력하세요", "MSG"));
                    return;
                }

                if (grid1.Rows.Count == 0)
                {
                    MessageBox.Show(Common.getLangText("가입고 버튼을 클릭해 주세요.", "MSG"));
                    return;
                }

                int iPoQty = Convert.ToInt32(txt_POQTY_B.Text);                          //발주량
                int iCnt = Convert.ToInt32(txt_INPUTCNT_B.Text);                         //가입고 수량
                int iInQty = Convert.ToInt32(txt_INPUTQTY_B.Text.Replace(",", ""));      //가입고 중량
                int inqty = iInQty;
                int iGaTotInqty = Convert.ToInt32(txt_TMPINQTY_B.Text.Replace(",", "")); //총가입고량

                if (iPoQty < iGaTotInqty + iInQty)
                {
                    MessageBox.Show(Common.getLangText("가입고량이 발주량을 초과합니다.", "MSG"));
                    return;
                }

                string sInQty = string.Empty;
                string sRemark = string.Empty;
                string sUseFlag = string.Empty;
                string sCustLotNo = string.Empty;

                TmpInGroupNo(); //발주그룹번호 채번

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    sInQty = Convert.ToString(grid1.Rows[i].Cells["LOTBASEQTY"].Value).Replace(",", "");
                    sRemark = Convert.ToString(grid1.Rows[i].Cells["REMARK"].Value);
                    sUseFlag = (i + 1) == grid1.Rows.Count ? "Y" : "N";
                    sCustLotNo = Convert.ToString(grid1.Rows[i].Cells["CUSTLOTNO"].Value);

                    if (CModule.ToInt32(sInQty) <= 0)
                    {
                        continue;
                    }

                    helper.ExecuteNoneQuery("USP_MM0000_POP_I1"
                                           , CommandType.StoredProcedure
                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_PODATE", sPoDate, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_POSEQNO", sPoSeqNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_TMPINGROUPNO", sTmpInGroupNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_CUSTLOTNO", sCustLotNo, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_INQTY", sInQty, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_UNITCODE", sUnitCode, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_INDATE", txt_PLANINDATE_B.Text, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_FINISHFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                                           , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                           );

                    if (i == 0)
                    {
                        sLotNo1 = helper.RSMSG;
                        sLotNo2 = helper.RSMSG;
                        grid1.Rows[i].Cells["LOTNO"].Value = sLotNo1;
                    }
                    else
                    {
                        sLotNo2 = helper.RSMSG;
                        grid1.Rows[i].Cells["LOTNO"].Value = sLotNo2;
                    }

                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        throw new Exception(helper.RSMSG);
                    }
                }

                helper.Commit();

                txt_TMPINQTY_B.Text = Convert.ToString(iGaTotInqty + inqty);
                txt_REINQTY_B.Text = Convert.ToString(Convert.ToInt32(txt_POQTY_B.Text.Replace(",", "")) - iGaTotInqty - inqty);
                UpdateFinishFlag();

                if (chkClose.Checked)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// 가입고 중량 및 입고수량을 입력 했을 시 바코드 발행 수량을 그리드에 표시한다.
        /// 나머지는 마지막 수량에 모두 더 해 준다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void txtInputCnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    WIZ.Control.STextBox s = sender as WIZ.Control.STextBox;

                    if (s != null)
                    {
                        btnProc_Click(s, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_PRINT_B_Click(object sender, EventArgs e)
        {
            if (sPlantCode == string.Empty)
            {
                MessageBox.Show(Common.getLangText("사업장이 선택되지 않았습니다.", "MSG"));
            }
            else if (sPoNo == string.Empty)
            {
                MessageBox.Show(Common.getLangText("발주번호가 올바르지 않습니다.", "MSG"));
            }
            else if (sTmpInGroupNo == string.Empty)
            {
                MessageBox.Show(Common.getLangText("발행그룹번호가 올바르지 않습니다.", "MSG"));
            }

            //SendPrint(sPlantCode, sPoNo, sTmpInGroupNo);
        }
        #endregion

        private void txtInputCnt_TextChanged(object sender, EventArgs e)
        {
            if (txt_INPUTCNT_B.Text.Length > 0)
            {

                string value = txt_INPUTCNT_B.Text.Replace(",", "");

                if (!_IsNumber(value))
                {
                    //입력된 데이터가 존재할 경우....
                    if (txt_INPUTCNT_B.Text.Length > 0)
                    {
                        //한글자씩 뒤에서 부터 삭제
                        txt_INPUTCNT_B.Text = txt_INPUTCNT_B.Text.Remove(txt_INPUTCNT_B.Text.Length - 1, 1);
                        txt_INPUTCNT_B.Select(txt_INPUTCNT_B.Text.Length, 0);
                    }
                }
                Int64 data = Int64.Parse(value);
                txt_INPUTCNT_B.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txt_INPUTCNT_B.SelectionStart = txt_INPUTCNT_B.Text.Length;
            }
        }

        //불필요
        /// <summary>
        /// 숫자입력
        /// </summary>
        /// <param name="_RecVal"></param>
        /// <returns></returns>
        public static bool _IsNumber(string _RecVal)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^\d.]+");

            if (!regex.IsMatch(_RecVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnProc_Click(object sender, EventArgs e)
        {
            Infragistics.Win.Misc.UltraButton btn = sender as Infragistics.Win.Misc.UltraButton;

            if (btn != null)
            {
                double dTotalQty = CModule.ToDouble(txt_INPUTQTY_B.Text);
                int iCnt = CModule.ToInt32(txt_INPUTCNT_B.Text);
                double dPackQty = CModule.ToDouble(txtPackQty.Text);

                bool bDouble = txtPackQty.Text.Contains(".");

                if (dTotalQty <= 0)
                {
                    MessageBox.Show("가입고 수량을 확인해주세요.");
                    return;
                }

                if (btn.Name == "btnProc1")
                {
                    if (iCnt <= 0)
                    {
                        MessageBox.Show("용기 수량을 확인해주세요.");
                        return;
                    }

                    // 실수 입력시
                    dPackQty = (int)(dTotalQty / iCnt);
                    txtPackQty.Text = dPackQty.ToString();
                }

                if (btn.Name == "btnProc2")
                {
                    if (dPackQty <= 0)
                    {
                        MessageBox.Show("포장 단위를 확인해주세요.");
                        return;
                    }

                    iCnt = (int)dTotalQty / (int)dPackQty;
                    txt_INPUTCNT_B.Text = iCnt.ToString();
                }

                _GridUtil.Grid_Clear(grid1);

                //int num_MOD = iInQty % iCnt;             // 가입고중량 / 입고수량 을 나눈 나머지    1000 % 3 = 1
                //int num_share = iInQty / iCnt;           // 가입고중량 / 입고수량                  1000 / 3 = 333

                while (true)
                {
                    if (dTotalQty <= 0)
                    {
                        break;
                    }

                    this.grid1.InsertRow();

                    if (bDouble)
                    {
                        if (dPackQty >= dTotalQty)
                        {
                            grid1.ActiveRow.Cells["LOTBASEQTY"].Value = CModule.ToDouble(dTotalQty);
                        }
                        else
                        {
                            grid1.ActiveRow.Cells["LOTBASEQTY"].Value = CModule.ToDouble(dPackQty);
                        }

                        dTotalQty -= dPackQty;
                    }
                    else
                    {
                        if (dPackQty >= dTotalQty)
                        {
                            grid1.ActiveRow.Cells["LOTBASEQTY"].Value = CModule.ToDouble(dTotalQty);
                        }
                        else
                        {
                            grid1.ActiveRow.Cells["LOTBASEQTY"].Value = CModule.ToInt32(dPackQty);
                        }

                        dTotalQty -= (int)dPackQty;
                    }

                    if (txt_CustLotNo.Text.Trim().Length > 0)
                    {
                        grid1.ActiveRow.Cells["CUSTLOTNO"].Value = txt_CustLotNo.Text.Trim();
                    }

                    grid1.ActiveRow.Cells["REMARK"].Value = txt_REMARK_B.Text.Trim();
                }
            }
        }
    }
}
