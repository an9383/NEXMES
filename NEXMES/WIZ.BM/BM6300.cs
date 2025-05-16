#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM6300
//   Form Name    : 수집지점 관리
//   Name Space   : WIZ.BM
//   Created Date : 
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM6300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM6300()
        {
            InitializeComponent();

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOpCode, txtOpName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtLineCode, txtLineName, "TBM0500", new object[] { cboPlantCode_H, cboOpCodeHidden, "" });
            btbManager.PopUpAdd(txtWorkcenterCode_B, txtWorkcenterName_B, "TBM0600Y", new object[] { cboPlantCode_H, cboOpCodeHidden, cboLineHidden, "" });  //작업장 POP_UP

            btbManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600Y", new object[] { cboPlantCode_H, "", "", "" });  //작업장 POP_UP
            btbManager.PopUpAdd(txtIFDataID, txtIFDataName, "TBM6400", new object[] { cboPlantCode_H });  //IF RECORD 팝업
            //btbManager.PopUpAdd(txtUsrMeasureEquID , txtMeasureEquCnt,    "TBM6310",  new object[] { cboPlantCode_H, cboOpCodeHidden, cboLineHidden, cboWorkcenterHidden,cboReceiverHidden });
            btbManager.PopUpAdd(txtUsrMeasureEquID, txtMeasureEquCnt, "TBM6320", new object[] { cboPlantCode_H, "" });

        }
        #endregion

        #region 폼 초기화

        private void BM6300_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME", "라인명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAPOINTID", "데이터수집지점", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAPOINTNAME", "데이터수집지점명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "RECEIVER", "측정기그룹", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPADDR", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DASTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECORDTYPE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COMPORT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BAUDRATE", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DATABIT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PARITYBIT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPBIT", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHANNEL", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FLOWCONTROL", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORKETSERVERIP", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORKETSERVERPORT", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEPATH", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHECKFILE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IOSERVERPROGID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODEGB", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPERCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "TOOLCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATAID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATANAME", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREEQUID", "", false, GridColDataType_emu.Integer, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USRMEASUREEQUID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREEQUNAME", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "", false, GridColDataType_emu.DateTime24, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "", false, GridColDataType_emu.DateTime24, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HOPCODE", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "HMACHID", "", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GRP_OPCODE", "공정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MEASUREEQUCNT", "계측기수", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            this.cboPlantCode_H.Value = CModule.GetAppSetting("Site", "10");
            this.cboPlantCode_B.Value = CModule.GetAppSetting("Site", "10");

            rtnDtTemp = _Common.GET_BM0000_CODE("COMTYPE");  // 통신방식
            WIZ.Common.FillComboboxMaster(this.cboComType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboComType.Value = "CT01";
            rtnDtTemp = _Common.GET_BM0000_CODE("PLCTYPE");  //PLC 종류
            WIZ.Common.FillComboboxMaster(this.cboPLCType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("DASTYPE");  //검사 구분
            WIZ.Common.FillComboboxMaster(this.cboDASType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("ITEMCODEGB");  // 품목 처리 구분
            WIZ.Common.FillComboboxMaster(this.cboItemCodeGB, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("STOPBIT");  //STOPBIT
            WIZ.Common.FillComboboxMaster(this.cboParityBit, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("PARITYBIT");  //PARITYBIT
            WIZ.Common.FillComboboxMaster(this.cboStopBit, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("BAUDRATE");  //BAUDRATE
            WIZ.Common.FillComboboxMaster(this.cboBaudRate, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

            #endregion
        }
        #endregion

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
                DoInsertData();
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string stxtWorkcenterCode = txtWorkCenterCode_H.Text;
                string sDaPointCode = txtDaPointCode.Text;

                grid1.DataSource = helper.FillTable("USP_BM6300_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", stxtWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_DAPOINTID", sDaPointCode, DbType.String, ParameterDirection.Input)
                                                                    );

                grid1.DataBinds();
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                if (this.grid1.Rows.Count == 0) DoInputEnable();

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;


                grid1.DisplayLayout.Bands[0].Columns["LINENAME"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["LINENAME"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;


                grid1.DisplayLayout.Bands[0].Columns["OPNAME"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["OPNAME"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

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

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            if (this.grid1.Rows.Count == 0)
            {
                DoInputEnable();
                return;
            }
            SetControl();
            DoInputable();
        }
        private void SetControl()
        {
            this.cboPlantCode_B.Value = this.grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();      // 공장
            this.txtOpCode.Text = this.grid1.ActiveRow.Cells["OPERCODE"].Value.ToString();         // 공정
            this.txtOpName.Text = this.grid1.ActiveRow.Cells["OPNAME"].Value.ToString();           // 공정명
            this.txtLineCode.Text = this.grid1.ActiveRow.Cells["LINECODE"].Value.ToString();       // 라인코드
            this.txtLineName.Text = this.grid1.ActiveRow.Cells["LINENAME"].Value.ToString();       // 라인명
            this.txtDaPointID.Text = this.grid1.ActiveRow.Cells["DAPOINTID"].Value.ToString();      // 데이터 수집지점
            this.txtDaPointName.Text = this.grid1.ActiveRow.Cells["DAPOINTNAME"].Value.ToString();    // 데이터 수집지점 명
            this.txtIPaddr.Text = this.grid1.ActiveRow.Cells["IPADDR"].Value.ToString();         // IP 주소
            this.cboPLCType.Value = this.grid1.ActiveRow.Cells["PLCTYPE"].Value.ToString();        // PLC 종류
            this.cboComType.Value = this.grid1.ActiveRow.Cells["COMTYPE"].Value.ToString();        // 인터페이스타입
            this.cboDASType.Value = this.grid1.ActiveRow.Cells["DASTYPE"].Value.ToString();        // 검사구분
            this.txtComPort.Text = this.grid1.ActiveRow.Cells["COMPORT"].Value.ToString();        // COMPORT
            this.cboBaudRate.Value = this.grid1.ActiveRow.Cells["BAUDRATE"].Value.ToString();       // 통신속도
            this.txtDataBit.Text = this.grid1.ActiveRow.Cells["DATABIT"].Value.ToString();        // DATABIT
            this.cboParityBit.Value = this.grid1.ActiveRow.Cells["PARITYBIT"].Value.ToString();      // PARITY BIT
            this.cboStopBit.Value = this.grid1.ActiveRow.Cells["STOPBIT"].Value.ToString();        // STOP BIT
            this.txtChannel.Text = this.grid1.ActiveRow.Cells["CHANNEL"].Value.ToString();        // 채널
            this.txtWorkcenterCode_B.Text = this.grid1.ActiveRow.Cells["WORKCENTERCODE"].Value.ToString(); // 작업장
            this.txtWorkcenterName_B.Text = this.grid1.ActiveRow.Cells["WORKCENTERNAME"].Value.ToString(); // 작업장 명
            this.txtIFDataID.Text = this.grid1.ActiveRow.Cells["IFDATAID"].Value.ToString();       // RECORD ID
            this.txtIFDataName.Text = this.grid1.ActiveRow.Cells["IFDATANAME"].Value.ToString();     // RECORD NAME
            this.cboItemCodeGB.Value = this.grid1.ActiveRow.Cells["ITEMCODEGB"].Value.ToString();     // 품목처리방식
            this.txtUsrMeasureEquID.Text = this.grid1.ActiveRow.Cells["USRMEASUREEQUID"].Value.ToString();       // Sub Acqusition Code
            this.txtMeasureEquCnt.Text = this.grid1.ActiveRow.Cells["MEASUREEQUCNT"].Value.ToString();  // 계측기 수
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {

                for (int i = 0; i < this.grid1.Rows.Count; i++)
                {
                    if (this.grid1.Rows[i].Cells["DAPOINTID"].Value.ToString() == "")
                    {
                        this.grid1.Rows[i].Activated = true;
                        DoInsertData();
                        return;
                    }
                }
                base.DoNew();
                this.grid1.InsertRow();
                DoInsertData();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DoInputable();
            }
        }
        private void DoInsertData()
        {
            txtDaPointID.Text = "";
            txtDaPointName.Text = "";
            cboPlantCode_B.Value = CModule.GetAppSetting("Site", "10");
            txtIPaddr.Text = "";
            txtOpCode.Text = "";
            txtOpName.Text = "";
            txtLineCode.Text = "";
            txtLineName.Text = "";
            txtWorkcenterCode_B.Text = "";
            txtWorkcenterName_B.Text = "";
            cboComType.Value = "CT01";
            cboPLCType.Value = "";
            txtIFDataID.Text = "";
            txtIFDataName.Text = "";
            txtUsrMeasureEquID.Text = "";
            txtMeasureEquCnt.Text = "";
            cboDASType.Value = "";
            cboItemCodeGB.Value = "";
            txtComPort.Text = "";
            txtChannel.Text = "";
            cboBaudRate.Value = "";
            txtDataBit.Text = "";
            cboParityBit.Value = "";
            cboStopBit.Value = "";
            txtFlowControl.Text = "";
        }
        private void DoInputable()
        {
            txtDaPointName.Enabled = true;
            cboPlantCode_B.Enabled = true;
            txtIPaddr.Enabled = true;
            txtOpCode.Enabled = true;
            txtOpName.Enabled = true;
            txtLineCode.Enabled = true;
            txtLineName.Enabled = true;
            txtWorkcenterCode_B.Enabled = true;
            txtWorkcenterName_B.Enabled = true;
            cboComType.Enabled = true;
            cboPLCType.Enabled = true;
            txtIFDataID.Enabled = true;
            txtIFDataName.Enabled = true;
            txtUsrMeasureEquID.Enabled = true;
            cboDASType.Enabled = true;
            cboItemCodeGB.Enabled = true;
            txtComPort.Enabled = true;
            txtChannel.Enabled = true;
            cboBaudRate.Enabled = true;
            txtDataBit.Enabled = true;
            cboParityBit.Enabled = true;
            cboStopBit.Enabled = true;
            txtFlowControl.Enabled = true;
            btnInit.Enabled = true;
            btnComportSet.Enabled = true;
            txtMeasureEquCnt.Enabled = true;
        }
        private void DoInputEnable()
        {
            txtDaPointName.Enabled = false;
            cboPlantCode_B.Enabled = false;
            txtIPaddr.Enabled = false;
            txtOpCode.Enabled = false;
            txtOpName.Enabled = false;
            txtLineCode.Enabled = false;
            txtLineName.Enabled = false;
            txtWorkcenterCode_B.Enabled = false;
            txtWorkcenterName_B.Enabled = false;
            cboComType.Enabled = false;
            cboPLCType.Enabled = false;
            txtIFDataID.Enabled = false;
            txtIFDataName.Enabled = false;
            txtUsrMeasureEquID.Enabled = false;
            cboDASType.Enabled = false;
            cboItemCodeGB.Enabled = false;
            txtComPort.Enabled = false;
            txtChannel.Enabled = false;
            cboBaudRate.Enabled = false;
            txtDataBit.Enabled = false;
            cboParityBit.Enabled = false;
            cboStopBit.Enabled = false;
            txtFlowControl.Enabled = false;
            btnInit.Enabled = false;
            btnComportSet.Enabled = false;
            txtMeasureEquCnt.Enabled = false;
        }

        // 초기화 버튼 클릭
        private void btnComPortInfo_Click(object sender, EventArgs e)
        {

            if (this.grid1.Rows.Count == 0) DoInsertData();
            else
            {
                // 선택한 행의 정보를 다시 보여줌
                grid1_ClickCell(null, null);
            }
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
            Grid1ToolAct();
        }
        #endregion

        #region<Grid1ToolAct>
        private void Grid1ToolAct()
        {
            DataTable dt = grid1.chkChange();
            DBHelper helper = new DBHelper("", true);
            string sPlantCode = Convert.ToString(this.cboPlantCode_B.Value);
            string sOPCode = this.txtOpCode.Text;
            string sLinrCode = this.txtLineCode.Text;
            string sLineName = this.txtLineName.Text;
            string sWorkcenterCode = this.txtWorkcenterCode_B.Text;
            string sWorkcenterName = this.txtWorkcenterName_B.Text;
            string sDaPointId = this.txtDaPointID.Text;
            string sDapointName = this.txtDaPointName.Text;
            string sIpAddr = this.txtIPaddr.Text;
            string sPlcType = Convert.ToString(this.cboPLCType.Value);
            string sComType = Convert.ToString(this.cboComType.Value);
            string sDasType = Convert.ToString(this.cboDASType.Value);
            string sComport = this.txtComPort.Text;
            string sBadrudRate = Convert.ToString(this.cboBaudRate.Value);
            string sDataBit = this.txtDataBit.Text;
            string sParityBit = Convert.ToString(this.cboParityBit.Value);
            string sStopBit = Convert.ToString(this.cboStopBit.Value);
            string sChannel = this.txtChannel.Text;
            string sIfData = this.txtIFDataID.Text;
            string sIdDataName = this.txtIFDataName.Text;
            string sItemCodeGb = Convert.ToString(this.cboItemCodeGB.Value);
            string sSubAcqusition = this.txtUsrMeasureEquID.Text;

            if (sPlantCode == "")
            {
                this.ShowDialog(Common.getLangText("공장을 입력하지 않았습니다. 선택후 등록 가능합니다..", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            else if (sOPCode == "")
            {
                this.ShowDialog(Common.getLangText("공정을 입력하지 않았습니다. 선택후 등록 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            else if (sLinrCode == "")
            {
                this.ShowDialog(Common.getLangText("라인을 입력하지 않았습니다. 선택후 등록 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            else if (sWorkcenterCode == "")
            {
                this.ShowDialog(Common.getLangText("작업장을 입력하지 않았습니다. 선택후 등록 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }

            else if (dt == null && sDaPointId != "")
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                if (sDaPointId != "")
                {
                    try
                    {



                        helper.ExecuteNoneQuery("USP_BM6300_U1N", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_DAPOINTID", sDaPointId, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DAPOINTNAME", sDapointName, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IPADDR", sIpAddr, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_PLCTYPE", sPlcType, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_COMTYPE", sComType, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DASTYPE", sDasType, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_RECORDTYPE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_COMPORT", sComport, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_BAUDRATE", sBadrudRate, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DATABIT", sDataBit, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_PARITYBIT", sParityBit, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_STOPBIT", sStopBit, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_CHANNEL", sChannel, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_FLOWCONTROL", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SORKETSERVERIP", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SORKETSERVERPORT", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_FILEPATH", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_CHECKFILE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_FILEID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IOSERVERPROGID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_LINECODE", sLinrCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_ITEMCODEGB", sItemCodeGb, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_OPERCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_TOOLCODE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IFDATAID", sIfData, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IFDATANAME", sIdDataName, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_MEASUREEQUID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_USRMEASUREEQUID", sPlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_HOPCODE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_HMACHID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_GRP_OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SUBACQUSITION", sSubAcqusition, DbType.String, ParameterDirection.Input)
                                                );
                        if (helper.RSCODE == "S")
                        {
                            helper.Commit();
                            this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            DoInquire();
                            for (int i = 0; i < this.grid1.Rows.Count; i++)
                            {
                                if (this.grid1.Rows[i].Cells["DAPOINTID"].Value.ToString() == sDaPointId)
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
                            this.ShowDialog(Common.getLangText("데이터 저장에 실패 하였습니다.", "MSG"), DialogForm.DialogType.OK);
                            string a = helper.RSMSG;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        helper.Close();
                    }
                }
            }


            try
            {
                if (dt == null) return;
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }
                base.DoSave();


                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM6300_D1N", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DAPOINTID", Convert.ToString(drRow["DAPOINTID"]), DbType.String, ParameterDirection.Input)
                                                    );

                            drRow.Delete();
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM6300_I1N", CommandType.StoredProcedure
                                                , helper.CreateParameter("AS_DAPOINTID", sDaPointId, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DAPOINTNAME", sDapointName, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IPADDR", sIpAddr, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_PLCTYPE", sPlcType, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_COMTYPE", sComType, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DASTYPE", sDasType, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_RECORDTYPE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_COMPORT", sComport, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_BAUDRATE", sBadrudRate, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_DATABIT", sDataBit, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_PARITYBIT", sParityBit, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_STOPBIT", sStopBit, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_CHANNEL", sChannel, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_FLOWCONTROL", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SORKETSERVERIP", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SORKETSERVERPORT", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_FILEPATH", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_CHECKFILE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_FILEID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IOSERVERPROGID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_LINECODE", sLinrCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_ITEMCODEGB", sItemCodeGb, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_OPERCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_TOOLCODE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IFDATAID", sIfData, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_IFDATANAME", sIdDataName, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_MEASUREEQUID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_USRMEASUREEQUID", sPlantCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_HOPCODE", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_HMACHID", "", DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_GRP_OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("AS_SUBACQUSITION", sSubAcqusition, DbType.String, ParameterDirection.Input)
                                                );
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ClosePrgFormNew();

                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    DoInquire();
                    for (int i = 0; i < this.grid1.Rows.Count; i++)
                    {
                        if (this.grid1.Rows[i].Cells["DAPOINTID"].Value.ToString() == helper.RSMSG)
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
                    string a = helper.RSMSG;
                    return;
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void txtOpCode_TextChanged(object sender, EventArgs e)
        {
            this.cboOpCodeHidden.Value = txtOpCode.Text;
        }

        private void txtLineCode_TextChanged(object sender, EventArgs e)
        {
            this.cboLineHidden.Value = txtLineCode.Text;
        }

        private void txtWorkcenterCode_B_TextChanged(object sender, EventArgs e)
        {
            this.cboWorkcenterHidden.Value = txtWorkcenterCode_B.Text;
        }
        private void txtUsrMeasureEquID_TextChanged(object sender, EventArgs e)
        {
            this.cboReceiverHidden.Value = txtUsrMeasureEquID.Text;
        }
        private void txtComPort_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                // 숫자입력 메시지창 표현.
                MessageBox.Show(Common.getLangText("숫자만 입력가능합니다.", "MSG"));
                e.Handled = true;
            }
        }


        /// <summary>
        /// COMPORT 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComportSet_Click(object sender, EventArgs e)
        {
            if (this.txtDaPointID.Text == "")
            {
                MessageBox.Show(Common.getLangText("데이터 수집지점 저장 후 등록 가능합니다.", "MSG"));
                return;
            }
            POP_TBM5120 pop_tbm5120 = new POP_TBM5120(txtDaPointID.Text, txtDaPointName.Text);
            pop_tbm5120.ShowDialog();
        }
    }
}