#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        : BM0100
//   Form Name      : 메세지 관리
//   Name Space     : STXDNC.BM
//   Created Date   : 2012.03.09
//   Made By        : WIZCORE
//   Description    : 프로그램의 모든 메세지를 관리하는 프로그램이다. 경고, 알림 모든 형식이 가능함.
//   DB Table       : BM0100
//   StoreProcedure : USP_BM0100_S1(I1, D1, U1)
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.BM
{
    public partial class BM5430 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private string PlantCode;
        private DataTable rtnDtTemp = new DataTable();
        private DataTable DtGrid1 = new DataTable();
        private DataTable DtGrid2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        private bool StatusCheck = false;   //DoSearch 시점에 상태값 변경 하기 위해 사용
        #endregion

        #region < CONSTRUCTOR >
        public BM5430()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();


            btbManager.PopUpAdd(txtLineCode, txtLineName, "TBM0500", new object[] { "", "" });
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { "", "" });
            btbManager.PopUpAdd(txtUsrMachID, txtUsrMachName, "TBM0700", new object[] { "", "", "", "" });


            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this.PlantCode = CModule.GetAppSetting("Site", "10");
        }
        #endregion

        #region BM5430_Load
        //폼 로드시 공장코드 설정
        private void BM5430_Load(object sender, EventArgs e)
        {
            this.cboPlantCode_H.Value = this.PlantCode;

            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAPOINTID", "데이터수집지점", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAPOINTNAME", "데이터수집지점명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPADDR", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DASTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECORDTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPORT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BAUDRATE", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DATABIT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PARITYBIT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPBIT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHANNEL", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FLOWCONTROL", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORKETSERVERIP", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORKETSERVERPORT", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEPATH", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHECKFILE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IOSERVERPROGID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODEGB", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPERCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPERNAME", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOOLCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATAID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATANAME", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREEQUID", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USRMEASUREEQUID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREEQUNAME", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "", false, GridColDataType_emu.DateTime24, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "", false, GridColDataType_emu.DateTime24, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HOPCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HMACHID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            DtGrid1 = (DataTable)this.grid1.DataSource;

            //공장
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCTYPE");
            WIZ.Common.FillComboboxMaster(this.cboPLCType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPCASE");
            WIZ.Common.FillComboboxMaster(this.cboDASType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (StatusCheck == false)
            {
                base.DoInquire();

                rtnDtTemp = USP_BM5430_S1(Convert.ToString(cboPlantCode_H.Value), Convert.ToString(this.txtLineCode2.Text));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();

                    DtGrid1 = rtnDtTemp;

                    StatusCheck = true;

                    #region 컨트롤 바인딩
                    txtDaPointID.DataBindings.Clear();
                    txtDaPointID.DataBindings.Add("Value", DtGrid1, "DAPOINTID");
                    txtDaPointName.DataBindings.Clear();
                    txtDaPointName.DataBindings.Add("Value", DtGrid1, "DAPOINTNAME");
                    cboPlantCode.DataBindings.Clear();
                    cboPlantCode.DataBindings.Add("Value", DtGrid1, "PLANTCODE");
                    txtIPaddr.DataBindings.Clear();
                    txtIPaddr.DataBindings.Add("Value", DtGrid1, "IPADDR");
                    txtLineCode.DataBindings.Clear();
                    txtLineCode.DataBindings.Add("Value", DtGrid1, "LINECODE");
                    txtLineName.DataBindings.Clear();
                    txtLineName.DataBindings.Add("Value", DtGrid1, "LINENAME");
                    txtOPCode.DataBindings.Clear();
                    txtOPCode.DataBindings.Add("Value", DtGrid1, "OPERCODE");
                    txtOPName.DataBindings.Clear();
                    txtOPName.DataBindings.Add("Value", DtGrid1, "OPERNAME");
                    cboComType.DataBindings.Clear();
                    cboComType.DataBindings.Add("Value", DtGrid1, "COMTYPE");
                    cboPLCType.DataBindings.Clear();
                    cboPLCType.DataBindings.Add("Value", DtGrid1, "PLCTYPE");
                    txtIFDataID.DataBindings.Clear();
                    txtIFDataID.DataBindings.Add("Value", DtGrid1, "IFDATAID");
                    txtIFDataName.DataBindings.Clear();
                    txtIFDataName.DataBindings.Add("Value", DtGrid1, "IFDATANAME");
                    txtUsrMeasureEquID.DataBindings.Clear();
                    txtUsrMeasureEquID.DataBindings.Add("Value", DtGrid1, "USRMEASUREEQUID");
                    txtMeasureEquName.DataBindings.Clear();
                    txtMeasureEquName.DataBindings.Add("Value", DtGrid1, "MEASUREEQUNAME");
                    cboDASType.DataBindings.Clear();
                    cboDASType.DataBindings.Add("Value", DtGrid1, "DASTYPE");
                    cboItemCodeGB.DataBindings.Clear();
                    cboItemCodeGB.DataBindings.Add("Value", DtGrid1, "ITEMCODEGB");
                    #endregion
                }
                else
                {

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                this.grid1.GetRow();
            }
            else
            {
                #region 그리드 상테에서 삭제 신규나, 수정의 상태 변경을 찾아 메세지 경고를 보여줌
                if (UltraGridUtil.CheckSearchDataGrid(this, this.grid1, this.DtGrid1, false) == true)
                {
                    DialogResult result = MessageBox.Show(Common.getLangText("자료를 저장하지 않았습니다. \n\r\n\r저장하지 않고 검색하겠습니까?", "MSG"), "변경데이터 있음", MessageBoxButtons.OKCancel);
                    if (result != DialogResult.OK)
                    {
                        StatusCheck = true;
                    }
                    else
                    {
                        StatusCheck = false;
                        DoInquire();
                    }
                }
                else
                {
                    StatusCheck = false;
                    DoInquire();
                }
                #endregion

            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            int iRow = _GridUtil.AddRow(this.grid1);
            this.grid1.SetDefaultValue("PlantCode", "820");

            // 초기값 설정
            this.cboPlantCode.Value = this.PlantCode;
            this.txtDaPointID.Text = "AUTO";
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            base.DoSave();

            this.grid1.SetRow();

            this.grid1.PerformAction(UltraGridAction.DeactivateCell);

            if (UltraGridUtil.CheckSaveDataGrid(this, this.grid1, DtGrid1, true) == true)
            {
                USP_BM5430_CRUD(DtGrid1, this.WorkerID);
                StatusCheck = false;
            }
            else
            {
                StatusCheck = true;
            }
        }

        public override void DoDownloadExcel()
        {
            if (this.grid1.Rows.Count == 0)
            {

                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            this.grid1.ExportExcel();
            base.DoDownloadExcel();
        }
        #endregion

        #region < EVENT AREA >

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            string enter = e.KeyCode.ToString();
            if (enter == "Return")
            {
                Infragistics.Win.UltraWinGrid.GridKeyActionMapping KeyMapping1 = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Tab, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0);
                this.grid1.KeyActionMappings.Add(KeyMapping1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
            }
        }

        private void txtLineCode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (this.cboPlantCode.Value.ToString() == "")
            {

                this.ShowDialog(Common.getLangText("사업장을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            string plantcode = (string)this.cboPlantCode.Value;

            string sLineCode = this.txtLineCode.Text;


            if (sLineCode != string.Empty && sLineCode != this.txtLineCode.Text)
            {
                this.txtOPCode.Text = string.Empty;            //공정
                this.txtOPName.Text = string.Empty;
                this.txtUsrMachID.Text = string.Empty;         //설비
                this.txtUsrMachName.Text = string.Empty;
                this.txtMeasureEquID.Text = string.Empty;      //측정기
                this.txtUsrMeasureEquID.Text = string.Empty;
                this.txtMeasureEquName.Text = string.Empty;
            }
        }

        private void txtLineCode_H_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode_H.Value;
            if (plantcode == null) plantcode = "";


        }

        //측정기 팝업창
        private void txtUsrMeasureEquID_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (this.cboPlantCode.Text == "")
            {

                this.ShowDialog(Common.getLangText("사업장을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            if (this.txtLineCode.Text == "")
            {

                this.ShowDialog(Common.getLangText("라인을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            string plantcode = (string)this.cboPlantCode.Value;
            string linecode = (string)this.txtLineCode.Text;
            string opcode = (string)this.txtOPCode.Text;
            if (opcode == null)
                opcode = "";

        }

        //품목 팝업 창
        private void txtItemCode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;
            if (plantcode == null)
                plantcode = "";
            if (this.txtLineCode.Text == "")
            {

                this.ShowDialog(Common.getLangText("라인을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }

        }
        //픔목코드 변경시 품목명 클리어
        private void txtItemCode_ValueChanged(object sender, EventArgs e)
        {
            //this.txtItemName.Text = "";
        }
        //공정코드 팝업창
        private void txtOPCode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            string plantcode = (string)this.cboPlantCode.Value;
            if (plantcode == null)
                plantcode = "";
            string linecode = (string)this.txtLineCode.Text;
            if (linecode == null)
                linecode = "";


        }

        //컴포트 숫자만 입력
        private void txtComPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region <METHOD AREA>
        /// <summary>
        /// 행의 신규 등록시 오류 CHECK
        /// </summary>
        private void DoNewValidate(DataRow row)
        {
            // 입력항목에 대한 VALIDATION CHECK
            /*
            if (row["DaPointID"].ToString() == "")
            {
                row.RowError = this.FormInformation.GetMessage("R00000");

                throw (new SException(grid1.DisplayLayout.Bands[0].Columns["DaPointID"].Header.Caption, "R00000", null));
            }
            if (row["IFDataID"].ToString() == "")
            {
                row.RowError = this.FormInformation.GetMessage("R00000");

                throw (new SException(grid1.DisplayLayout.Bands[0].Columns["IFDataID"].Header.Caption, "R00000", null));
            }
             */
        }
        #endregion

        #region < 품목선택 >
        private void btnItemCode_Click(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0)
                return;

            if (this.cboItemCodeGB.Text == null)
            {

                this.ShowDialog(Common.getLangText("품목처리방식을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                return;
            }

        }
        #endregion

        #region < IFDataID POPUP >
        private void txtIFDataID_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            //WIZ.POPUP.PP1900 pp1900 = new POPUP.PP1900(this.txtIFDataID);
            //pp1900.ShowDialog();
            //if (this.txtIFDataID.Text == "AUTO")
            //    this.txtIFDataID.ReadOnly = true;
            //else
            //    this.txtIFDataID.ReadOnly = false;
        }
        #endregion

        #region < 측정기 키 누를 때 >
        private void txtUsrMeasureEquID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region < DB 연결 TEST >
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (this.txtServerName.Text == "")
            {

                this.ShowDialog(Common.getLangText("서버이름을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;

            }
            if (this.txtDB_Name.Text == "")
            {

                this.ShowDialog(Common.getLangText("DB명을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                return;
            }
            if (this.txtDB_ID.Text == "")
            {

                this.ShowDialog(Common.getLangText("DB ID를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            if (this.txtDB_Password.Text == "")
            {

                this.ShowDialog(Common.getLangText("DB PASSWORD를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
        }
        #endregion

        #region < Progress >
        private void bgprogress_DoWork(object sender, DoWorkEventArgs e)
        {

            ProgressForm = new WIZ.Forms.BaseProgressForm(this.MdiParent.Location, this.MdiParent.Width, this.MdiParent.Height);
            ProgressForm.Activated += new EventHandler(ProgressForm_Activated);
            ProgressForm.indProgress.SetMessage(e.Argument.ToString());
            ProgressForm.ShowDialog();
        }
        #endregion

        #region < Progress >
        void ProgressForm_Activated(object sender, EventArgs e)
        {
            this.AutoReset.Set();
        }
        #endregion

        #region < METHOD AREA >
        delegate void ClosePrgFormCallBack();
        private void ClosePrgForm()
        {
            this.IsShowDialog = false;
            try
            {
                if (this.ProgressForm.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        System.Threading.Thread.Sleep(200);
                        this.ProgressForm.Close();
                    })
                               );
                    return;
                }

                this.ProgressForm.Close();
            }
            catch (Exception ex)
            {
                // To Do : 여기서 어떤 오류가 나는지 확인이 필요.
                //WIZ.Windows.Forms.CheckForm checkform = new WIZ.Windows.Forms.CheckForm(ex.Message);
                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.Message);
                checkform.ShowDialog();
            }
        }
        #endregion

        #region<Event>
        private void txtUsrMachID_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {

            System.Windows.Forms.Control txtCode_H = new System.Windows.Forms.Control();

        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (grid1.Rows.Count > 0)
            {
                gbxDapContent.Enabled = true;
                gbxComDetail.Enabled = true;
            }
            else
            {
                gbxDapContent.Enabled = false;
                gbxComDetail.Enabled = false;
            }
        }
        #endregion

        #region USP_BM5430_S1
        private DataTable USP_BM5430_S1(string AS_PLANTCODE, string AS_LINECODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                return helper.FillTable("USP_BM5430_S1N", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("LINECODE", AS_LINECODE, DbType.String, ParameterDirection.Input));


            }
            catch (Exception ex)
            {

                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();

                return new DataTable();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region 저장/수정/삭제
        public void USP_BM5430_CRUD(DataTable DtChange, string USER_ID)
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PLANTCODE"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM5430_D1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("DAPOINTID", drRow["DAPOINTID"], DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM5430_I1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("DAPOINTID", drRow["DAPOINTID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DAPOINTNAME", drRow["DAPOINTNAME"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IPADDR", drRow["IPADDR"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLCTYPE", drRow["PLCTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("COMTYPE", drRow["COMTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DASTYPE", drRow["DASTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RECORDTYPE", drRow["RECORDTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("COMPORT", drRow["COMPORT"], DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("BAUDRATE", drRow["BAUDRATE"], DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DATABIT", drRow["DATABIT"], DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARITYBIT", drRow["PARITYBIT"], DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("STOPBIT", drRow["STOPBIT"], DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CHANNEL", drRow["CHANNEL"], DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FLOWCONTROL", drRow["FLOWCONTROL"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SORKETSERVERIP", drRow["SORKETSERVERIP"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SORKETSERVERPORT", drRow["SORKETSERVERPORT"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILEPATH", drRow["FILEPATH"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CHECKFILE", drRow["CHECKFILE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILEID", drRow["FILEID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IOSERVERPROGID", drRow["IOSERVERPROGID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LINECODE", drRow["LINECODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODE", drRow["ITEMCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODEGB", drRow["ITEMCODEGB"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPERCODE", drRow["OPERCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TOOLCODE", drRow["TOOLCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFDATANAME", drRow["IFDATANAME"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MEASUREEQUID", drRow["MEASUREEQUID"], DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USRMEASUREEQUID", drRow["USRMEASUREEQUID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HOPCODE", drRow["HOPCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HMACHID", drRow["HMACHID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM5430_U1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("DAPOINTID", drRow["DAPOINTID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DAPOINTNAME", drRow["DAPOINTNAME"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IPADDR", drRow["IPADDR"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLCTYPE", drRow["PLCTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("COMTYPE", drRow["COMTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DASTYPE", drRow["DASTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RECORDTYPE", drRow["RECORDTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("COMPORT", drRow["COMPORT"], DbType.Decimal, ParameterDirection.Input)
                                                                   , helper.CreateParameter("BAUDRATE", drRow["BAUDRATE"], DbType.Decimal, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DATABIT", drRow["DATABIT"], DbType.Decimal, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARITYBIT", drRow["PARITYBIT"], DbType.Decimal, ParameterDirection.Input)
                                                                   , helper.CreateParameter("STOPBIT", drRow["STOPBIT"], DbType.Decimal, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CHANNEL", drRow["CHANNEL"], DbType.Decimal, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FLOWCONTROL", drRow["FLOWCONTROL"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SORKETSERVERIP", drRow["SORKETSERVERIP"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SORKETSERVERPORT", drRow["SORKETSERVERPORT"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILEPATH", drRow["FILEPATH"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CHECKFILE", drRow["CHECKFILE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILEID", drRow["FILEID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IOSERVERPROGID", drRow["IOSERVERPROGID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("LINECODE", drRow["LINECODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODE", drRow["ITEMCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ITEMCODEGB", drRow["ITEMCODEGB"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPERCODE", drRow["OPERCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TOOLCODE", drRow["TOOLCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MEASUREEQUID", drRow["MEASUREEQUID"], DbType.Decimal, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USRMEASUREEQUID", drRow["USRMEASUREEQUID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HOPCODE", drRow["HOPCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("HMACHID", drRow["HMACHID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE");

                helper.Commit();
            }
            catch (Exception ex)
            {

                helper.Rollback();


                WIZ.Forms.MessageForm checkform = new Forms.MessageForm(ex);
                checkform.ShowDialog();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region < Comport 정보 >
        private void btnComPortInfo_Click(object sender, EventArgs e)
        {
            //WIZ.BM.BM2020 bm2020 = new BM2020(this.txtDaPointID.Text, this.txtDaPointName.Text);
            //bm2020.ShowDialog();
        }
        #endregion
    }
}
