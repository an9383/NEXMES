#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6010
//   Form Name    : 검사항목 별 측정항목 관리
//   Name Space   : WIZ.BM
//   Created Date : 2015-10-19
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6010 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        private string imgPath = string.Empty;
        byte[] imgBuffer = null;

        private string sPlantCode = string.Empty;

        string sGunbun; // 측정값구분자
        string sChk;    // 공차적용여부 체크 구분자
        string b;

        #endregion

        #region < CONSTRUCTOR >
        public BM6010()
        {
            InitializeComponent();

            sPlantCode = CModule.GetAppSetting("Site", "10");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtInspCode, txtInspName, "TBM6000", new object[] { "", "" }); //검사항목
            btbManager.PopUpAdd(txtMeasureCode, txtMeasureName, "TBM6100", new object[] { "", "" }); //측정항목
            btbManager.PopUpAdd(txtMeasureCode1, txtMeasureName1, "TBM6100", new object[] { "", "" }); //측정항목

            //BizGridManager bizGrid = new BizGridManager(grid2);
            //bizGrid.PopUpAdd("PartNo", "PartName", "TBM0100", new string[] { "", "" }); //품목
            //bizGrid.PopUpAdd("MEASURECODE", "MEASURENAME", "TBM6100", new string[] { "", "" }); //측정항목
        }
        #endregion

        #region 폼 초기화

        private void BM6010_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURESEQ", "측정순번", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURECODE", "측정항목코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MEASURENAME", "측정항목명", false, GridColDataType_emu.VarChar, 200, 200, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid2, "MEASURETYPE", "측정값구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECTYPE", "SPEC적용기준", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECVALUE", "규격", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TOLFLAG", "공차적용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UTOLVALUE", "상한공차", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LTOLVALUE", "하한공차", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECUSL", "상한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPECLSL", "하한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(grid2, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cboUseFlag.Value = "Y";

            rtnDtTemp = _Common.GET_BM0000_CODE("MEASURETYPE");  //측정값 구분
            WIZ.Common.FillComboboxMaster(this.cboMEASURETYPE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);

            rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE");     //SPEC 적용기준
            WIZ.Common.FillComboboxMaster(this.cboSEPCTYPE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cboSEPCTYPE.Value = "B";


            #endregion


        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            txtMeasureCode1.Focus();
            // SPEC DATA 초기화
            txtMEASURESEQ.Text = string.Empty;
            txtMeasureCode1.Text = string.Empty;
            txtMeasureName1.Text = string.Empty;
            cboMEASURETYPE.Value = "V";
            cboSEPCTYPE.Value = "B";
            txtSPECVALUE.Text = string.Empty;
            txtUTOLVALUE.Text = string.Empty;
            txtLTOLVALUE.Text = string.Empty;
            txtUSL.Text = string.Empty;
            txtLSL.Text = string.Empty;

            cboUseFlag.Value = "Y";
            cboUseFlag.ReadOnly = true;

            txtMeasureCode1.ReadOnly = false;
            txtMeasureName1.ReadOnly = false;

            if (this.grid2.IsActivate)
            {
                if (this.grid1.Rows.Count == 0)
                {
                    this.ShowDialog(Common.getLangText("먼저 검사항목을 조회하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.grid2.DeleteRow();
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            if (this.grid1.Rows.Count == 0)
            {
                this.ShowDialog(Common.getLangText("먼저 검사항목을 조회하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            // 항목 삭제
            DBHelper helper = new DBHelper(false);
            try
            {
                DataTable dt = grid2.chkChange();
                int ChkDeleteFlag = 0;
                if (dt != null)
                {
                    foreach (DataRow drRow in dt.Rows)
                    {
                        if (drRow.RowState == DataRowState.Deleted)
                        {
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM6010_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MEASURECODE", Convert.ToString(drRow["MEASURECODE"]), DbType.String, ParameterDirection.Input));   //측정 코드   
                            if (helper.RSCODE != "S") break;
                            ChkDeleteFlag++;
                            #endregion
                        }
                    }
                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        this.ShowDialog(Common.getLangText("데이터 삭제를 성공 하였습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        helper.Close();

                        //선택한 행 설정
                        string sInspCode = Convert.ToString(this.grid1.ActiveRow.Cells["INSPCODE"].Value);
                        DoInquire();
                        for (int i = 0; i < this.grid1.Rows.Count; i++)
                        {
                            if (Convert.ToString(this.grid1.Rows[i].Cells["INSPCODE"].Value) == sInspCode)
                            {
                                this.grid1.Rows[i].Activated = true;
                                break;
                            }
                        }
                        return;
                    }
                    else
                    {
                        helper.Rollback();
                        this.ShowDialog(Common.getLangText("데이터 삭제를 실패 하였습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        helper.Close();
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //helper.Close();
            }


            if (txtMeasureCode1.Text == "")
            {
                this.ShowDialog(Common.getLangText("측정항목을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }
            //측정값 구분이 값 또는 값+판정이면 규격, USL, LSL 필수입력
            if (sGunbun == "V" || sGunbun == "D")
            {
                if (txtSPECVALUE.Text == "")
                {
                    this.ShowDialog(Common.getLangText("규격 을 입력하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                // USL 과 LSL 이 규격 에 맞는 값인지 체크
                if (Convert.ToDouble(txtSPECVALUE.Text) < Convert.ToDouble(txtLSL.Text))
                {
                    this.ShowDialog(Common.getLangText("LSL 은 규격보다 클 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                else if (Convert.ToDouble(txtSPECVALUE.Text) > Convert.ToDouble(txtUSL.Text))
                {
                    this.ShowDialog(Common.getLangText("USL 은 규격보다 작을 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                else if (Convert.ToDouble(txtLSL.Text) < 0 || Convert.ToDouble(txtUSL.Text) < 0)
                {
                    //// 온도 등을 제외한 음수값의 기준정보 입력 체크
                    //this.ShowDialog("USL , LSL 은 음수의 값을 가질수 없습니다.", Forms.DialogForm.DialogType.OK);
                    //return;
                }

            }

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                return;

            string sINSPCODE = txtInspCode1.Text;
            string sMEASURESEQ = txtMEASURESEQ.Text;
            string sMEASURECODE = txtMeasureCode1.Text;
            string sMEASURENAME = txtMeasureName1.Text;
            string sMEASURETYPE = Convert.ToString(cboMEASURETYPE.Value);
            string sSEPCTYPE = Convert.ToString(cboSEPCTYPE.Value);
            string sSPECVALUE = txtSPECVALUE.Text;

            string sTOLFLAG = "Y";
            if (!chkTOLFLAG.Checked)
            {
                sTOLFLAG = "N";
            }

            string sUTOLVALUE = txtUTOLVALUE.Text;
            string sLTOLVALUE = txtLTOLVALUE.Text;
            string sUSL = txtUSL.Text;
            string sLSL = txtLSL.Text;
            string sUSEFLAG = Convert.ToString(cboUseFlag.Value);



            try
            {
                helper.ExecuteNoneQuery("USP_BM6010_I1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", sINSPCODE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MEASURESEQ", sMEASURESEQ, DbType.Int16, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MEASURECODE", sMEASURECODE, DbType.String, ParameterDirection.Input)

                                                                    , helper.CreateParameter("MEASURETYPE", sMEASURETYPE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SEPCTYPE", sSEPCTYPE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SPECVALUE", sSPECVALUE, DbType.Int16, ParameterDirection.Input)
                                                                    , helper.CreateParameter("TOLFLAG", sTOLFLAG, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("UTOLVALUE", sUTOLVALUE, DbType.Int16, ParameterDirection.Input)
                                                                    , helper.CreateParameter("LTOLVALUE", sLTOLVALUE, DbType.Int16, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SEPCUSL", sUSL, DbType.Int16, ParameterDirection.Input)
                                                                    , helper.CreateParameter("SPECLSL", sLSL, DbType.Int16, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", sUSEFLAG, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("WORKID", this.WorkerID, DbType.String, ParameterDirection.Input)

                                                                    );

                if (helper.RSCODE == "E")
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                }

                helper.Commit();
                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                //선택한 행 설정
                string sInspCode = Convert.ToString(this.grid1.ActiveRow.Cells["INSPCODE"].Value);
                DoInquire();
                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(this.grid1.Rows[i].Cells["INSPCODE"].Value) == sInspCode)
                    {
                        this.grid1.Rows[i].Activated = true;
                        break;
                    }
                }

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

        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sInspCode = txtInspCode.Text;
                string sInspName = txtInspCode.Text;

                grid1.DataSource = helper.FillTable("USP_BM6010_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("INSPNAME", sInspName, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();

                //if (AFTERSAVE == 1)
                //{
                //    grid1.Rows[GRIDROWID].Activate();
                //    AFTERSAVE = 0;
                //}

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

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {

                string sMeasureCode = txtMeasureCode.Text;
                string sMeasureName = txtMeasureName.Text;
                string sINSPCODE = Convert.ToString(this.grid1.ActiveRow.Cells["INSPCODE"].Value);
                string sUseFlag = DBHelper.nvlString(cboUseFlag_H.Value);  //사용여부

                grid2.DataSource = helper.FillTable("USP_BM6010_S2N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("INSPCODE", sINSPCODE, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MEASURECODE", sMeasureCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("MEASURENAME", sMeasureName, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                    );

                grid2.DataBinds();
                if (grid2.Rows.Count == 0)
                {
                    DoNew();
                }
                else
                {
                    //조회시 미사용은 노란색으로 표시
                    for (int i = 0; i < this.grid2.Rows.Count; i++)
                    {
                        if (Convert.ToString(grid2.Rows[i].Cells["USEFLAG"].Value.ToString()) == "N")
                        {
                            grid2.Rows[i].Appearance.BackColor = Color.FromArgb(254, 255, 100);
                        }

                    }
                }
                txtInspCode1.Text = Convert.ToString(this.grid1.ActiveRow.Cells["INSPCODE"].Value);
                //DoNew();
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

        private void grid2_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {

                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "ALL|*.*";

                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Image image = Image.FromFile(openfiledialog.FileName);
                    string ImgNM = openfiledialog.FileName;

                    imgBuffer = File.ReadAllBytes(ImgNM);

                    grid2.ActiveRow.Cells["ITEMIMAGENM"].Value = ImgNM;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid2_ClickCell(object sender, EventArgs e)
        {
            txtInspCode1.Text = Convert.ToString(this.grid1.ActiveRow.Cells["INSPCODE"].Value);
            txtMEASURESEQ.Text = Convert.ToString(this.grid2.ActiveRow.Cells["MEASURESEQ"].Value);
            txtMeasureCode1.Text = Convert.ToString(this.grid2.ActiveRow.Cells["MEASURECODE"].Value);
            txtMeasureName1.Text = Convert.ToString(this.grid2.ActiveRow.Cells["MEASURENAME"].Value);

            cboMEASURETYPE.Value = Convert.ToString(this.grid2.ActiveRow.Cells["MEASURETYPE"].Value);

            cboSEPCTYPE.Value = Convert.ToString(this.grid2.ActiveRow.Cells["SPECTYPE"].Value);
            txtSPECVALUE.Text = Convert.ToString(this.grid2.ActiveRow.Cells["SPECVALUE"].Value);

            chkTOLFLAG.Checked = true;
            if (Convert.ToString(this.grid2.ActiveRow.Cells["TOLFLAG"].Value) == "N")
            {
                chkTOLFLAG.Checked = false;
            }

            txtUTOLVALUE.Text = Convert.ToString(this.grid2.ActiveRow.Cells["UTOLVALUE"].Value);
            txtLTOLVALUE.Text = Convert.ToString(this.grid2.ActiveRow.Cells["LTOLVALUE"].Value);
            txtUSL.Text = Convert.ToString(this.grid2.ActiveRow.Cells["SPECUSL"].Value);
            txtLSL.Text = Convert.ToString(this.grid2.ActiveRow.Cells["SPECLSL"].Value);

            cboUseFlag.Value = Convert.ToString(this.grid2.ActiveRow.Cells["USEFLAG"].Value);
            cboUseFlag.ReadOnly = false;

            txtMeasureCode1.ReadOnly = true;
            txtMeasureName1.ReadOnly = true;
        }

        private void txtSPECVALUE_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자 그리드 헤더 컬럼명 찾기
            if (e.KeyChar == Convert.ToChar("."))
            {
                // . 만 입력시 0. 으로 처리
                if (txtSPECVALUE.Text == "")
                {
                    e.Handled = true;
                    txtSPECVALUE.Text = "0.";
                    txtSPECVALUE.SelectionStart = 2;
                    return;
                }
                // . 을 두개 이상 입력시 방지
                string InspValue = txtSPECVALUE.Text;
                string[] a = InspValue.Split('.');
                if (a.Length > 1) e.Handled = true;
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == 45))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }
        }

        private void txtUTOLVALUE_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자 그리드 헤더 컬럼명 찾기
            if (e.KeyChar == Convert.ToChar("."))
            {
                // . 만 입력시 0. 으로 처리
                if (txtUTOLVALUE.Text == "")
                {
                    e.Handled = true;
                    txtUTOLVALUE.Text = "0.";
                    txtUTOLVALUE.SelectionStart = 2;
                    return;
                }
                // . 을 두개 이상 입력시 방지
                string InspValue = txtUTOLVALUE.Text;
                string[] a = InspValue.Split('.');
                if (a.Length > 1) e.Handled = true;
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }

        }

        private void txtLTOLVALUE_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자 그리드 헤더 컬럼명 찾기
            if (e.KeyChar == Convert.ToChar("."))
            {
                // . 만 입력시 0. 으로 처리
                if (txtLTOLVALUE.Text == "")
                {
                    e.Handled = true;
                    txtLTOLVALUE.Text = "0.";
                    txtLTOLVALUE.SelectionStart = 2;
                    return;
                }
                // . 을 두개 이상 입력시 방지
                string InspValue = txtLTOLVALUE.Text;
                string[] a = InspValue.Split('.');
                if (a.Length > 1) e.Handled = true;
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }

        }

        private void txtUSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자 그리드 헤더 컬럼명 찾기
            if (e.KeyChar == Convert.ToChar("."))
            {
                // . 만 입력시 0. 으로 처리
                if (txtUSL.Text == "")
                {
                    e.Handled = true;
                    txtUSL.Text = "0.";
                    txtUSL.SelectionStart = 2;
                    return;
                }
                // . 을 두개 이상 입력시 방지
                string InspValue = txtUSL.Text;
                string[] a = InspValue.Split('.');
                if (a.Length > 1) e.Handled = true;
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }
        }

        private void txtLSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자 그리드 헤더 컬럼명 찾기
            if (e.KeyChar == Convert.ToChar("."))
            {
                // . 만 입력시 0. 으로 처리
                if (txtLSL.Text == "")
                {
                    e.Handled = true;
                    txtLSL.Text = "0.";
                    txtLSL.SelectionStart = 2;
                    return;
                }
                // . 을 두개 이상 입력시 방지
                string InspValue = txtLSL.Text;
                string[] a = InspValue.Split('.');
                if (a.Length > 1) e.Handled = true;
            }
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }

        }

        private void txtMEASURESEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력하여 주십시요", "MSG"));
                e.Handled = true;
            }
        }

        private void cboUseFlag_Validated(object sender, EventArgs e)
        {
            //if (grid2.Rows.Count == 0)
            //{
            //    return;
            //}

            //string a = Convert.ToString(sender);
            //if (a == "N")
            //{
            //    if (this.ShowDialog("변경 후 저장시 검사항목별 측정관리, 품목별 검사관리, 작업장 품목별 검사관리의 사용여부가 모두 미사용으로 변경됩니다. 변경하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
            //    {
            //        //this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
            //        return;
            //    }
            //}
            //else
            //{
            //    if (this.ShowDialog("변경 후 저장시 검사항목별 측정관리, 품목별 검사관리, 작업장 품목별 검사관리의 사용여부는 변경되지 않습니다. 변경하시겠습니까?") == System.Windows.Forms.DialogResult.Cancel)
            //    {
            //        //this.grid1.ActiveRow.Cells["USEFLAG"].Value = "N";
            //        return;
            //    }
            //}
        }

        private void cboUseFlag_AfterCloseUp(object sender, EventArgs e)
        {

            string a = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value.ToString();

            if (a != b)
            {
                if (a == "N")
                {
                    if (this.ShowDialog(Common.getLangText("변경 후 저장시 품목별 검사기준 관리에서 측정항목의 사용여부가 모두 미사용으로 변경됩니다. 변경하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value = "N";
                        return;
                    }
                }
                else
                {
                    if (this.ShowDialog(Common.getLangText("변경 후 저장시 품목별 검사관리에서 측정항목의 사용여부는 변경되지 않습니다. 변경하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value = "Y";
                        return;
                    }
                }
            }
        }

        private void cboUseFlag_AfterDropDown(object sender, EventArgs e)
        {
            b = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value.ToString();
        }

        private void cboMEASURETYPE_ValueChanged(object sender, EventArgs e)
        {
            sGunbun = Convert.ToString(((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value);

            //측정값 구분이 판정이면 값 입력 불가
            if (sGunbun == "J")
            {
                txtSPECVALUE.ReadOnly = true;
                txtUTOLVALUE.ReadOnly = true;
                txtLTOLVALUE.ReadOnly = true;
                //txtUSL.ReadOnly       = true;
                //txtLSL.ReadOnly       = true;
                chkTOLFLAG.Checked = false;
                chkTOLFLAG.Enabled = false;
                cboSEPCTYPE.ReadOnly = true;
                cboSEPCTYPE.Enabled = false;
            }

            //측정값 구분이 값 또는 값+판정이면 규격, USL, LSL 필수입력
            if (sGunbun == "V" || sGunbun == "D")
            {
                txtSPECVALUE.ReadOnly = false;
                txtUTOLVALUE.ReadOnly = false;
                txtLTOLVALUE.ReadOnly = false;
                //txtUSL.ReadOnly       = false;
                //txtLSL.ReadOnly       = false;
                chkTOLFLAG.Checked = true;
                chkTOLFLAG.Enabled = true;
                cboSEPCTYPE.ReadOnly = false;
                cboSEPCTYPE.Enabled = true;
            }

        }



        private void txtUTOLVALUE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double stxtSPECVALUE = 0;
                double stxtUTOLVALUE = 0;

                if (txtSPECVALUE.Text == "") stxtSPECVALUE = 0;
                else stxtSPECVALUE = Convert.ToDouble(txtSPECVALUE.Text);
                if (txtUTOLVALUE.Text == "") stxtUTOLVALUE = 0;
                else stxtUTOLVALUE = Convert.ToDouble(txtUTOLVALUE.Text);

                txtUSL.Text = Convert.ToString(stxtSPECVALUE + stxtUTOLVALUE);
            }
            catch
            {
            }
        }

        private void txtLTOLVALUE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double stxtSPECVALUE = 0;
                double stxtLTOLVALUE = 0;

                if (txtSPECVALUE.Text == "") stxtSPECVALUE = 0;
                else stxtSPECVALUE = Convert.ToDouble(txtSPECVALUE.Text);
                if (txtLTOLVALUE.Text == "") stxtLTOLVALUE = 0;
                else stxtLTOLVALUE = Convert.ToDouble(txtLTOLVALUE.Text);

                txtLSL.Text = Convert.ToString(stxtSPECVALUE - stxtLTOLVALUE);
            }
            catch
            {
            }
        }

        private void txtSPECVALUE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double stxtSPECVALUE = 0;
                double stxtUTOLVALUE = 0;
                double stxtLTOLVALUE = 0;

                if (txtSPECVALUE.Text == "") stxtSPECVALUE = 0;
                else stxtSPECVALUE = Convert.ToDouble(txtSPECVALUE.Text);
                if (txtUTOLVALUE.Text == "") stxtUTOLVALUE = 0;
                else stxtUTOLVALUE = Convert.ToDouble(txtUTOLVALUE.Text);

                txtUSL.Text = Convert.ToString(stxtSPECVALUE + stxtUTOLVALUE);

                if (txtLTOLVALUE.Text == "") stxtLTOLVALUE = 0;
                else stxtLTOLVALUE = Convert.ToDouble(txtLTOLVALUE.Text);

                txtLSL.Text = Convert.ToString(stxtSPECVALUE - stxtLTOLVALUE);
            }
            catch
            {
            }
        }
    }
}