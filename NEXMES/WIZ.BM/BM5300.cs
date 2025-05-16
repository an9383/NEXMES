#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5300
//   Form Name    : 데이터 수집정보 관리
//   Name Space   : WIZ.BM
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

namespace WIZ.BM
{
    using WIZ.Forms;

    public partial class BM5300 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public BM5300()
        {
            InitializeComponent();

        }

        private void BM5300_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCase", "검사대상", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목ⓟ", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목명ⓟ", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCode", "작업장ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPName", "작업장명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드ⓟ", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachName", "설비명ⓟ", false, GridColDataType_emu.VarChar, 167, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPAddr", "IP", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLCType", "PLC타입", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ComType", "통신방법", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ComPort", "통신포트", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "BaudRate", "통신속도", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DataBit", "데이터비트", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ParityBit", "패러티비트", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "StopBit", "Stop비트", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FlowControl", "흐름제어", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Channel", "MUX통신\n채널", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Cavity", "보정수치\n(곱)", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RoundNum", "소수점\n자리수", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "trmInterval", "수신대기(초)", false, GridColDataType_emu.Integer, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SocketServerIP", "소켓서버IP", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SocketServerPort", "소켓서버\nPort", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.InitColumnUltraGrid(grid1, "DisplayNo", "표시순서", false, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLCTYPE");  //PLC타입
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLCTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspCase");  //PLC타입
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspCase", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("COMTYPE");  //통신방법
            WIZ.Common.FillComboboxMaster(this.cboComType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "COMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("COMPORT");  //
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ComPort", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("BAUDRATE");  //
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "BAUDRATE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DataBit");  //DataBit
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DataBit", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ParityBit");  //ParityBit
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ParityBit", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("StopBit");  //StopBit
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "StopBit", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("FlowControl");  //FlowControl
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FlowControl", rtnDtTemp, "CODE_ID", "CODE_NAME");


            BizGridManager BIZPOP = new BizGridManager(grid1);
            BIZPOP.PopUpAdd("InspCode", "InspName", "TBM3600", new string[] { "PlantCode", "QC", "", "", "Y", "ItemCode" }, null, null);
            BIZPOP.PopUpAdd("InspCode", "InspName", "TBM3600", new string[] { "InspCase", "", "", "Y" }, null, null);
            BIZPOP.PopUpAdd("MachCode", "MachName", "TBM0700", new string[] { "", "", "", "Y" });
            BIZPOP.PopUpAdd("OPCode", "OPName", "TBM0400", new string[] { "PlantCode", "Y" });

            BIZPOP.PopUpAdd("ItemCode", "Itemname", "TBM0100", new string[] { "PlantCode", "" });

            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtInspCode, txtInspCodeNM, "TBM1500", new object[] { "", "", "Y" });

        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[5];

            try
            {
                string sInspCode = txtInspCode.Text.Trim();
                string sInspCodeNM = txtInspCodeNM.Text.Trim();
                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sPLANTCODE = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sComType = DBHelper.nvlString(this.cboComType_H.Value);

                base.DoInquire();

                param[0] = helper.CreateParameter("@PlantCode", sPLANTCODE, DbType.String, ParameterDirection.Input);
                param[1] = helper.CreateParameter("@InspCode", sInspCode, DbType.String, ParameterDirection.Input);
                param[2] = helper.CreateParameter("@InspName", sInspCodeNM, DbType.String, ParameterDirection.Input);
                param[3] = helper.CreateParameter("@ComType", sComType, DbType.String, ParameterDirection.Input);
                param[4] = helper.CreateParameter("@UseFlag", sUseFlag, DbType.String, ParameterDirection.Input);

                grid1.DataSource = helper.FillTable("USP_BM5300_S1", CommandType.StoredProcedure, param);
                grid1.DataBinds();


            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }

        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            _GridUtil.AddRow(this.grid1);
            this.grid1.SetDefaultValue("PlantCode", "820");

            UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCase");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemCode");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "ItemName");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "InspCode");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "InspName");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "OPCode");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "OPName");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "MachCode");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "MachName");
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
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            System.Data.Common.DbParameter[] param = null;

            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            // Validate 체크
                            if (DBHelper.nvlString(dr["PlantCode"]) == "" || DBHelper.nvlString(dr["InspCode"]) == "")
                            {
                                ShowDialog(Common.getLangText("필수 입력항목 데이터 입력하십시오", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                                CancelProcess = true;
                                return;
                            }
                            break;
                    }
                }

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();



                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
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

                            param = new System.Data.Common.DbParameter[7];


                            param[0] = helper.CreateParameter("@PlantCode", drRow["PlantCode"], DbType.String, ParameterDirection.Input);         // 공장코드
                            param[1] = helper.CreateParameter("@ItemCode", drRow["ItemCode"], DbType.String, ParameterDirection.Input);         // 공장코드
                            param[2] = helper.CreateParameter("@InspCode", drRow["InspCode"], DbType.String, ParameterDirection.Input);         // 공장코드
                            param[3] = helper.CreateParameter("@OpCode", drRow["OpCode"], DbType.String, ParameterDirection.Input);         // 공장코드
                            param[4] = helper.CreateParameter("@MachCode", drRow["MachCode"], DbType.String, ParameterDirection.Input);         // 공장코드

                            param[5] = helper.CreateParameter("@pRetCode", DbType.String, ParameterDirection.Output, null, 1);
                            param[6] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            helper.ExecuteNoneQuery("USP_BM5300_D1", CommandType.StoredProcedure, param);

                            if (param[5].Value.ToString() == "E") throw new Exception(param[6].Value.ToString());
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            param = new System.Data.Common.DbParameter[24];

                            param[0] = helper.CreateParameter("@PlantCode", drRow["PlantCode"], DbType.String, ParameterDirection.Input);
                            param[1] = helper.CreateParameter("@ItemCode", drRow["ItemCode"], DbType.String, ParameterDirection.Input);
                            param[2] = helper.CreateParameter("@InspCode", drRow["InspCode"], DbType.String, ParameterDirection.Input);
                            param[3] = helper.CreateParameter("@OpCode", drRow["OpCode"], DbType.String, ParameterDirection.Input);
                            param[4] = helper.CreateParameter("@MachCode", drRow["MachCode"], DbType.String, ParameterDirection.Input);
                            param[5] = helper.CreateParameter("@IPAddr", drRow["IPAddr"], DbType.String, ParameterDirection.Input);
                            param[6] = helper.CreateParameter("@PLCType", drRow["PLCType"], DbType.String, ParameterDirection.Input);
                            param[7] = helper.CreateParameter("@ComType", drRow["ComType"], DbType.String, ParameterDirection.Input);
                            param[8] = helper.CreateParameter("@ComPort", drRow["ComPort"], DbType.String, ParameterDirection.Input);
                            param[9] = helper.CreateParameter("@BaudRate", drRow["BaudRate"], DbType.String, ParameterDirection.Input);
                            param[10] = helper.CreateParameter("@DataBit", drRow["DataBit"], DbType.String, ParameterDirection.Input);
                            param[11] = helper.CreateParameter("@ParityBit", drRow["ParityBit"], DbType.String, ParameterDirection.Input);
                            param[12] = helper.CreateParameter("@StopBit", drRow["StopBit"], DbType.String, ParameterDirection.Input);
                            param[13] = helper.CreateParameter("@Channel", drRow["Channel"], DbType.Int32, ParameterDirection.Input);
                            param[14] = helper.CreateParameter("@FlowControl", drRow["FlowControl"], DbType.String, ParameterDirection.Input);
                            param[15] = helper.CreateParameter("@Cavity", drRow["Cavity"], DbType.Decimal, ParameterDirection.Input);
                            param[16] = helper.CreateParameter("@RoundNum", drRow["RoundNum"], DbType.Int32, ParameterDirection.Input);
                            param[17] = helper.CreateParameter("@SocketServerIP", drRow["SocketServerIP"], DbType.String, ParameterDirection.Input);
                            param[18] = helper.CreateParameter("@SocketServerPort", drRow["SocketServerPort"], DbType.String, ParameterDirection.Input);
                            param[19] = helper.CreateParameter("@UseFlag", drRow["UseFlag"], DbType.String, ParameterDirection.Input);
                            param[20] = helper.CreateParameter("@Displayno", drRow["Displayno"], DbType.Int32, ParameterDirection.Input);

                            param[21] = helper.CreateParameter("@pMaker", this.WorkerID, DbType.String, ParameterDirection.Input);

                            param[22] = helper.CreateParameter("@pRetCode", DbType.String, ParameterDirection.Output, null, 1);
                            param[23] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            helper.ExecuteNoneQuery("USP_BM5300_I1", CommandType.StoredProcedure, param);

                            if (param[22].Value.ToString() == "E") throw new Exception(param[23].Value.ToString());

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            param = new System.Data.Common.DbParameter[24];

                            param[0] = helper.CreateParameter("@PlantCode", drRow["PlantCode"], DbType.String, ParameterDirection.Input);
                            param[1] = helper.CreateParameter("@ItemCode", drRow["ItemCode"], DbType.String, ParameterDirection.Input);
                            param[2] = helper.CreateParameter("@InspCode", drRow["InspCode"], DbType.String, ParameterDirection.Input);
                            param[3] = helper.CreateParameter("@OpCode", drRow["OpCode"], DbType.String, ParameterDirection.Input);
                            param[4] = helper.CreateParameter("@MachCode", drRow["MachCode"], DbType.String, ParameterDirection.Input);
                            param[5] = helper.CreateParameter("@IPAddr", drRow["IPAddr"], DbType.String, ParameterDirection.Input);
                            param[6] = helper.CreateParameter("@PLCType", drRow["PLCType"], DbType.String, ParameterDirection.Input);
                            param[7] = helper.CreateParameter("@ComType", drRow["ComType"], DbType.String, ParameterDirection.Input);
                            param[8] = helper.CreateParameter("@ComPort", drRow["ComPort"], DbType.String, ParameterDirection.Input);
                            param[9] = helper.CreateParameter("@BaudRate", drRow["BaudRate"], DbType.String, ParameterDirection.Input);
                            param[10] = helper.CreateParameter("@DataBit", drRow["DataBit"], DbType.String, ParameterDirection.Input);
                            param[11] = helper.CreateParameter("@ParityBit", drRow["ParityBit"], DbType.String, ParameterDirection.Input);
                            param[12] = helper.CreateParameter("@StopBit", drRow["StopBit"], DbType.String, ParameterDirection.Input);
                            param[13] = helper.CreateParameter("@Channel", drRow["Channel"], DbType.Int32, ParameterDirection.Input);
                            param[14] = helper.CreateParameter("@FlowControl", drRow["FlowControl"], DbType.String, ParameterDirection.Input);
                            param[15] = helper.CreateParameter("@Cavity", drRow["Cavity"], DbType.Decimal, ParameterDirection.Input);
                            param[16] = helper.CreateParameter("@RoundNum", drRow["RoundNum"], DbType.Int32, ParameterDirection.Input);
                            param[17] = helper.CreateParameter("@SocketServerIP", drRow["SocketServerIP"], DbType.String, ParameterDirection.Input);
                            param[18] = helper.CreateParameter("@SocketServerPort", drRow["SocketServerPort"], DbType.String, ParameterDirection.Input);
                            param[19] = helper.CreateParameter("@UseFlag", drRow["UseFlag"], DbType.String, ParameterDirection.Input);
                            param[20] = helper.CreateParameter("@Displayno", drRow["Displayno"], DbType.Int32, ParameterDirection.Input);

                            param[21] = helper.CreateParameter("@pEditor", this.WorkerID, DbType.String, ParameterDirection.Input);

                            param[22] = helper.CreateParameter("@pRetCode", DbType.String, ParameterDirection.Output, null, 1);
                            param[23] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            helper.ExecuteNoneQuery("USP_BM5300_U1", CommandType.StoredProcedure, param);

                            if (param[22].Value.ToString() == "E") throw new Exception(param[23].Value.ToString());

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
                CancelProcess = true;
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        /// <summary>
        /// Form이 Close 되기전에 발생
        /// e.Cancel을 true로 설정 하면, Form이 close되지 않음
        /// 수정 내역이 있는지를 확인 후 저장여부를 물어보고 저장, 저장하지 않기, 또는 화면 닫기를 Cancel 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion

    }
}