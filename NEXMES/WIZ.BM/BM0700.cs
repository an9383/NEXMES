#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZ
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >

using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0700 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();

        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        int SAVEFLAG = 0;        // 1: 추가, 2: 수정, 3: 삭제
        byte[] bImage = null;    // 이미지
        string ImgNM;
        #endregion

        #region < CONSTRUCTOR >
        public BM0700()
        {
            InitializeComponent();

            this.plantCode = CModule.GetAppSetting("Site", "10");

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMachCode_H, txtMachName_H, "TBM0700", new object[] { "", "", "", "", cboUseFlag_H });
            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "", "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600Y", new object[] { cboPlantCode, "", "" });

            imgPanel.AutoScroll = true;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

        }

        #endregion

        #region < FORM LOAD >
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BM0700_Load(object sender, EventArgs e)
        {
            #region < GRID >
            _GridUtil.InitializeGrid(this.lblMachCode1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(lblMachCode1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 160, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 230, false, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MACHTYPE", "설비구분", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MACHCODE", "설비코드", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MACHNAME", "설비명", false, GridColDataType_emu.VarChar, 130, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MAKECOMPANY", "제조사", false, GridColDataType_emu.VarChar, 150, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MODELNAME", "모델명", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "SERIALNO", "제조시리얼번호", false, GridColDataType_emu.VarChar, 220, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "CONTACT", "연락처", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MAWORKER1", "설비관리담당자\r\n(정)", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MAWORKER2", "설비관리담당자\r\n(부)", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "TECHWORKER", "설비기술담당자", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "BUYDATE", "구매일자", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "BUYCOST", "구매가격", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 250, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "USEFLAG", "사용유무", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "MAKEDATE", "등록일시", false, GridColDataType_emu.VarChar, 170, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(lblMachCode1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 170, true, false);

            _GridUtil.SetColumnTextHAlign(lblMachCode1, "PLANTCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "WORKCENTERCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MACHTYPE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MACHCODE", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MACHNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MAKECOMPANY", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MODELNAME", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "SERIALNO", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "CONTACT", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MAWORKER1", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MAWORKER2", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "TECHWORKER", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "BUYCOST", Infragistics.Win.HAlign.Right);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "REMARK", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "USEFLAG", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "MAKER", Infragistics.Win.HAlign.Left);
            _GridUtil.SetColumnTextHAlign(lblMachCode1, "EDITOR", Infragistics.Win.HAlign.Left);



            //Grid Data Binding                         
            _GridUtil.SetInitUltraGridBind(lblMachCode1);

            lblMachCode1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            lblMachCode1.DisplayLayout.Override.RowSelectorWidth = 50;
            lblMachCode1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            lblMachCode1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            lblMachCode1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            lblMachCode1.DisplayLayout.Bands[0].Columns["MACHCODE"].Header.Appearance.ForeColor = Color.SkyBlue;

            lblMachCode1.DisplayLayout.Bands[0].Columns["BUYCOST"].Format = "#,###";
            #endregion

            #region < COMBOBOX >
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.lblMachCode1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MachType");
            WIZ.Common.FillComboboxMaster(this.cboMachType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.lblMachCode1, "MACHTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0060_CODE("");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.lblMachCode1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //사용여부
            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "선택하세요", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.lblMachCode1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.lblMachCode1);

            cboPlantCode_H.Value = plantCode;

            txtBuyDate.Value = DateTime.Now;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// 조회
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                SAVEFLAG = 0;
                ControlSetting("VIEW");

                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sWorkcenter = txtWorkCenterCode_H.Text.Trim();
                string sMachName = txtMachName_H.Text.Trim();
                string sMachCode = txtMachCode_H.Text.Trim();
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM0700_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("FLAG", "S", DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("WORKCENTERCODE", sWorkcenter, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("MACHNAME", sMachName, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));



                if (rtnDtTemp.Rows.Count > 0)
                {
                    lblMachCode1.DataSource = rtnDtTemp;
                    lblMachCode1.DataBinds(rtnDtTemp);
                    lblMachCode1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                    lblMachCode1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    lblMachCode1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;

                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                }

                lblMachCode1.Refresh();


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                helper.Rollback();

            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            ControlSetting("NEW");
            SAVEFLAG = 1;
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.lblMachCode1.DeleteRow();
            SAVEFLAG = 3;
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            ((CurrencyManager)(lblMachCode1.BindingContext[lblMachCode1.DataSource])).EndCurrentEdit();

            if (SAVEFLAG == 1)
            {
                INSERT_SAVE();
                return;
            }
            else if (SAVEFLAG == 2)
            {
                UPDATE_SAVE();
                return;
            }
            else if (SAVEFLAG == 3)
            {
                DELETE_SAVE();
                return;
            }
            else return;

        }

        #endregion

        #region < USER METHOD AREA >

        private void INSERT_SAVE()
        {
            DBHelper helper = new DBHelper("", true);

            if (this.ShowDialog(Common.getLangText("해당 데이터를 등록하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                return;

            if (DBHelper.nvlString(this.cboPlantCode.Value) == "" || DBHelper.nvlString(this.txtMachCode.Text) == "")
            {
                this.ShowDialog(Common.getLangText("사업장, 설비코드는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_BM0700_I1", CommandType.StoredProcedure
                         , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(this.cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MACHCODE", DBHelper.nvlString(this.txtMachCode.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MACHNAME", DBHelper.nvlString(this.txtMachName.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MACHTYPE", DBHelper.nvlString(this.cboMachType.Value), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MAKECOMPANY", DBHelper.nvlString(this.txtMakeCompany.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MODELNAME", DBHelper.nvlString(this.txtModelName.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("SERIALNO", DBHelper.nvlString(this.txtSerialNo.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("CONTACT", DBHelper.nvlString(this.txtTelNo.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MAWORKER1", DBHelper.nvlString(this.txtMachSupername.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MAWORKER2", DBHelper.nvlString(this.txtMachSuper2Name.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("TECHWORKER", DBHelper.nvlString(this.txtTechWorker.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("BUYDATE", DBHelper.nvlString(this.txtBuyDate.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("BUYCOST", DBHelper.nvlString(txtBuyCost.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("REMARK", DBHelper.nvlString(this.txtRemark.Text), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("USEFLAG", DBHelper.nvlString(this.cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("WORKCENTERCODE", DBHelper.nvlString(this.txtWorkCenterCode.Text), DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 등록되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    SAVEFLAG = 0;

                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                SAVEFLAG = 1;
                return;
            }
            finally
            {
                helper.Close();
            }
        }
        private void UPDATE_SAVE()
        {
            DBHelper helper = new DBHelper(false);

            if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                return;

            if (DBHelper.nvlString(this.cboPlantCode.Value) == "" || DBHelper.nvlString(this.txtMachCode.Text) == "")
            {
                this.ShowDialog(Common.getLangText("사업장, 설비코드는 필수 입력 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_BM0700_U1", CommandType.StoredProcedure
                     , helper.CreateParameter("MACHCODE", DBHelper.nvlString(this.txtMachCode.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("MACHNAME", DBHelper.nvlString(this.txtMachName.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("MACHTYPE", DBHelper.nvlString(this.cboMachType.Value), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("MAKECOMPANY", DBHelper.nvlString(this.txtMakeCompany.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("MODELNAME", DBHelper.nvlString(this.txtModelName.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("SERIALNO", DBHelper.nvlString(this.txtSerialNo.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("CONTACT", DBHelper.nvlString(this.txtTelNo.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("MAWORKER1", DBHelper.nvlString(this.txtMachSupername.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("MAWORKER2", DBHelper.nvlString(this.txtMachSuper2Name.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("TECHWORKER", DBHelper.nvlString(this.txtTechWorker.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("BUYDATE", DBHelper.nvlString(this.txtBuyDate.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("BUYCOST", DBHelper.nvlString(txtBuyCost.Text.Replace(",", "")), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("REMARK", DBHelper.nvlString(this.txtRemark.Text), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("PLANTCODE", DBHelper.nvlString(this.cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("USEFLAG", DBHelper.nvlString(this.cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                     , helper.CreateParameter("EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 수정되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    SAVEFLAG = 0;
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }


            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                SAVEFLAG = 1;
                return;
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
                base.DoInquire();

            }

        }

        private void DELETE_SAVE()
        {
            DBHelper helper = new DBHelper(false);

            if (txtMachCode.Text == string.Empty)
            {
                this.ShowDialog(Common.getLangText("삭제할 설비가 없습니다. 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            if (this.ShowDialog(Common.getLangText("설비코드 [" + txtMachCode.Text + "] 를 삭제하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            {
                CancelProcess = true;
                return;
            }

            try
            {
                helper.ExecuteNoneQuery("USP_BM0700_D1", CommandType.StoredProcedure
                     , helper.CreateParameter("MACHCODE", txtMachCode.Text, DbType.String, ParameterDirection.Input) // 공장코드
                     , helper.CreateParameter("PLANTCODE", Convert.ToString(cboPlantCode.Value), DbType.String, ParameterDirection.Input)); // 품목

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    SAVEFLAG = 0;

                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    txtImgName.Text = "";
                    txtImgDate.Text = "";
                    DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
                SAVEFLAG = 2;
                return;
            }
            finally
            {
                helper.Close();
            }
        }

        ///// <summary>
        ///// 컨트롤 셋팅
        ///// </summary>
        ///// <param name="State"></param>
        private void ControlSetting(string State)
        {
            //State : New, Edit, View

            if (State == "NEW")
            {
                gbxInfo.Enabled = true;

                //초기화 및 기본값 셋팅
                cboPlantCode.SelectedIndex = 0;
                cboPlantCode.Value = plantCode;

                txtWorkCenterCode.Text = string.Empty;
                txtWorkCenterName.Text = string.Empty;
                cboMachType.SelectedIndex = 0;
                txtMachCode.Text = string.Empty;
                txtMachName.Text = string.Empty;
                txtMakeCompany.Text = string.Empty;
                txtModelName.Text = string.Empty;
                txtSerialNo.Text = string.Empty;
                txtTechWorker.Text = string.Empty;
                txtTelNo.Text = string.Empty;
                txtMachSupername.Text = string.Empty;
                txtMachSuper2Name.Text = string.Empty;
                txtBuyDate.Value = DateTime.Now;
                txtBuyCost.Text = string.Empty;
                txtRemark.Text = string.Empty;
                cboUseFlag.SelectedIndex = 0;

                cboPlantCode.Enabled = true;
                txtWorkCenterCode.Enabled = true;
                txtWorkCenterName.Enabled = true;
                cboMachType.Enabled = true;
                txtMachCode.Enabled = true;
                txtMachName.Enabled = true;
                txtMakeCompany.Enabled = true;
                txtModelName.Enabled = true;
                txtSerialNo.Enabled = true;
                txtTechWorker.Enabled = true;
                txtTelNo.Enabled = true;
                txtMachSupername.Enabled = true;
                txtMachSuper2Name.Enabled = true;
                txtBuyDate.Enabled = true;
                txtBuyCost.Enabled = true;
                txtRemark.Enabled = true;
                cboUseFlag.Enabled = true;

                lblMachCode1.ForeColor = Color.Blue;
                lblPlantCode1.ForeColor = Color.Blue;

                pictureBox1.Enabled = true;
                pictureBox1.Image = null;
                pictureBox2.Enabled = true;
                pictureBox2.Image = null;

                txtImgName.Text = "";
                txtImgDate.Text = "";
            }
            else if (State == "EDIT")
            {
                cboMachType.Enabled = true;
                txtMakeCompany.Enabled = true;
                txtModelName.Enabled = true;
                txtSerialNo.Enabled = true;
                txtTechWorker.Enabled = true;
                txtTelNo.Enabled = true;
                txtMachSupername.Enabled = true;
                txtMachSuper2Name.Enabled = true;
                txtBuyDate.Enabled = true;
                txtBuyCost.Enabled = true;
                txtRemark.Enabled = true;
                cboUseFlag.Enabled = true;

                gbxInfo.Enabled = true;
                lblMachCode1.ForeColor = Color.Blue;
                lblPlantCode1.ForeColor = Color.Blue;

                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
            }
            else if (State == "VIEW")
            {
                cboPlantCode.Enabled = false;
                txtWorkCenterCode.Enabled = false;
                txtWorkCenterName.Enabled = false;
                cboMachType.Enabled = false;
                txtMachName.Enabled = false;
                txtMakeCompany.Enabled = false;
                txtModelName.Enabled = false;
                txtSerialNo.Enabled = false;
                txtTechWorker.Enabled = false;
                txtTelNo.Enabled = false;
                txtMachSupername.Enabled = false;
                txtMachSuper2Name.Enabled = false;
                txtBuyDate.Enabled = false;
                txtBuyCost.Enabled = false;
                txtRemark.Enabled = false;
                cboUseFlag.Enabled = false;

                gbxInfo.Enabled = false;
                lblMachCode1.ForeColor = Color.Blue;
                lblPlantCode1.ForeColor = Color.Blue;
            }
        }
        #endregion

        #region < EVENT AREA >
        ///// <summary>
        ///// 더블클릭 시 설비마스터 수정모드로 변경
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            ControlSetting("EDIT");
            SAVEFLAG = 2;
        }

        /// <summary>
        /// grid1 선택 시 내용 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            txtImgName.Text = "";
            txtImgDate.Text = "";
            try
            {
                string sPlantCode = Convert.ToString(lblMachCode1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenter = Convert.ToString(lblMachCode1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sMachType = Convert.ToString(lblMachCode1.ActiveRow.Cells["MACHTYPE"].Value);
                string sMachCode = Convert.ToString(lblMachCode1.ActiveRow.Cells["MACHCODE"].Value);
                string sMachName = Convert.ToString(lblMachCode1.ActiveRow.Cells["MACHNAME"].Value);
                string sMakeCompany = Convert.ToString(lblMachCode1.ActiveRow.Cells["MAKECOMPANY"].Value);
                string sModelName = Convert.ToString(lblMachCode1.ActiveRow.Cells["MODELNAME"].Value);
                string sSerialNo = Convert.ToString(lblMachCode1.ActiveRow.Cells["SERIALNO"].Value);
                string sContact = Convert.ToString(lblMachCode1.ActiveRow.Cells["CONTACT"].Value);
                string sMAWorker1 = Convert.ToString(lblMachCode1.ActiveRow.Cells["MAWORKER1"].Value);
                string sMAWorker2 = Convert.ToString(lblMachCode1.ActiveRow.Cells["MAWORKER2"].Value);
                string sTechWorker = Convert.ToString(lblMachCode1.ActiveRow.Cells["TECHWORKER"].Value);
                string sBuyDate = Convert.ToString(lblMachCode1.ActiveRow.Cells["BUYDATE"].Value);
                string sBuyCost = Convert.ToString(lblMachCode1.ActiveRow.Cells["BUYCOST"].Value);
                string sRemark = Convert.ToString(lblMachCode1.ActiveRow.Cells["REMARK"].Value);
                string sUseFlag = Convert.ToString(lblMachCode1.ActiveRow.Cells["USEFLAG"].Value);

                cboPlantCode.Value = sPlantCode;
                txtWorkCenterCode.Text = sWorkcenter;
                cboMachType.Value = sMachType;
                txtMachCode.Text = sMachCode;
                txtMachName.Text = sMachName;
                txtMakeCompany.Text = sMakeCompany;
                txtModelName.Text = sModelName;
                txtSerialNo.Text = sSerialNo;
                txtTelNo.Text = sContact;
                txtMachSupername.Text = sMAWorker1;
                txtMachSuper2Name.Text = sMAWorker2;
                txtTechWorker.Text = sTechWorker;
                txtBuyDate.Text = sBuyDate;
                txtBuyCost.Text = sBuyCost;
                txtRemark.Text = sRemark;
                cboUseFlag.Value = sUseFlag;

                ControlSetting("VIEW");
                SAVEFLAG = 0;

                DataTable _TmpDt = helper.FillTable("USP_BM0700_S2", CommandType.StoredProcedure
                                 , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("MACHCODE", sMachCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (_TmpDt.Rows.Count > 0)
                    {
                        byte[] imageArr;
                        imageArr = (byte[])_TmpDt.Rows[0]["MACHIMG"];
                        MemoryStream ms = new MemoryStream(imageArr);
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox2.Image = Image.FromStream(ms);

                        txtImgName.Visible = true;
                        txtImgDate.Visible = true;

                        txtImgName.Text = "< 이미지 파일 이름 >\r\n" + _TmpDt.Rows[0]["IMGNAME"];
                        txtImgDate.Text = "< 이미지 등록 일자 >\r\n" + _TmpDt.Rows[0]["MAKEDATE"];
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// 설비마스터 엑셀 업로드 팝업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            POP_TBM0700_EXCEL pop_tbm0700_excel = new POP_TBM0700_EXCEL();
            pop_tbm0700_excel.ShowDialog();
        }

        private void btnImageIn_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (pictureBox1.Image == null || pictureBox2.Image == null)
                {
                    this.ShowDialog(Common.getLangText("이미지를 불러온 후 저장을 시도해 주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    helper.Close();
                    return;
                }

                rtnDtTemp2 = helper.FillTable("USP_BM0700_S2", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE", Convert.ToString(lblMachCode1.ActiveRow.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("MACHCODE", Convert.ToString(lblMachCode1.ActiveRow.Cells["MACHCODE"].Value), DbType.String, ParameterDirection.Input));


                if (rtnDtTemp2.Rows.Count > 0)
                {   //해당 설비에 이미 등록된 이미지가 존재합니다. \r\n다른 이미지를 추가 하시겠습니까?
                    DialogResult result = this.ShowDialog(Common.getLangText("해당 설비에 이미 등록된 이미지가 존재합니다. \r\n다른 이미지를 추가 하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO);
                    if (result == DialogResult.OK)
                    {
                        helper.ExecuteNoneQuery("USP_BM0710Y_D1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("PLANTCODE", Convert.ToString(lblMachCode1.ActiveRow.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("MACHCODE", Convert.ToString(lblMachCode1.ActiveRow.Cells["MACHCODE"].Value), DbType.String, ParameterDirection.Input));
                    }
                    else
                        return;
                }
                else
                {
                    if (this.ShowDialog(Common.getLangText("해당 이미지로 등록하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO) == DialogResult.Cancel)
                    {
                        bImage = null;
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                        return;
                    }
                }

                try
                {
                    helper.ExecuteNoneQuery("USP_BM0710Y_I2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", this.lblMachCode1.ActiveRow.Cells["PLANTCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMIMAGE", (bImage == null) ? SqlBinary.Null : bImage, DbType.Binary, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_MACHCODE", this.lblMachCode1.ActiveRow.Cells["MACHCODE"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_IMGNAME", ImgNM, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                        this.ShowDialog(Common.getLangText("이미지가 등록 되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        txtImgName.Text = "< 이미지 파일 이름 >\r\n" + ImgNM;
                        txtImgDate.Text = "< 이미지 등록 일자 >\r\n" + this.lblMachCode1.ActiveRow.Cells["MAKEDATE"].Value.ToString();
                        this.DoInquire();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// 설비이미지 삭제
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void btnImageDel_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {
                if (pictureBox1.Image == null || pictureBox2.Image == null)
                {
                    this.ShowDialog(Common.getLangText("등록된 이미지가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                DialogResult result = this.ShowDialog(Common.getLangText("등록된 이미지를 삭제하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO); //등록된 이미지를 삭제하시겠습니까?

                if (result == DialogResult.OK)
                {
                    helper.ExecuteNoneQuery("USP_BM0710Y_D1", CommandType.StoredProcedure
                         , helper.CreateParameter("PLANTCODE", Convert.ToString(cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                         , helper.CreateParameter("MACHCODE", txtMachCode.Text, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "S")
                    {
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                        txtImgName.Text = "";
                        txtImgDate.Text = "";
                        helper.Commit();

                        DoInquire();
                    }
                    else if (helper.RSCODE == "E")
                    {
                        this.ShowDialog(Common.getLangText("설비 이미지 삭제 중 오류가 발생하였습니다.", "MSG") + Environment.NewLine + helper.RSMSG, Forms.DialogForm.DialogType.OK); //설비 이미지 삭제 중 오류가 발생하였습니다.
                        helper.Rollback();
                    }

                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            if (this.lblMachCode1.Rows.Count == 0)
            {
                this.ShowDialog(Common.getLangText("이미지를 등록 할 대상이 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK); //이미지를 등록할 대상이 없습니다.
                return;
            }

            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp";

            if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image image = Image.FromFile(openfiledialog.FileName);
                string ImgPath = openfiledialog.FileName;
                ImgNM = openfiledialog.SafeFileName;

                FileStream stream = new FileStream(ImgPath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                bImage = reader.ReadBytes((int)stream.Length);
                reader.Close();
                stream.Close();

                // 이미지 표현
                if (bImage != null)
                {
                    pictureBox1.Image = new Bitmap(new MemoryStream(bImage));
                    pictureBox2.Image = new Bitmap(new MemoryStream(bImage));
                }

                pictureBox1.BringToFront();

            }
        }
        private void btnImageFull_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            if (pictureBox1.Image == null || pictureBox2.Image == null)
            {
                this.ShowDialog(Common.getLangText("등록된 이미지가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return;
            }

            rtnDtTemp = helper.FillTable("USP_BM0700_S2", CommandType.StoredProcedure
                                                        , helper.CreateParameter("PLANTCODE", Convert.ToString(lblMachCode1.ActiveRow.Cells["PLANTCODE"].Value), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("MACHCODE", Convert.ToString(lblMachCode1.ActiveRow.Cells["MACHCODE"].Value), DbType.String, ParameterDirection.Input));

            if (rtnDtTemp.Rows[0]["MACHIMG"] != null)
            {
                byte[] bImage = (byte[])rtnDtTemp.Rows[0]["MACHIMG"];


            }
        }

    }
}