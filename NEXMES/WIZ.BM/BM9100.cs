#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>


using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
#endregion

namespace WIZ.BM
{

    public partial class BM9100 : WIZ.Forms.BaseMDIChildForm
    {
        #region [ 선언자 ]
        DataTable rtnDtTemp = new DataTable();         // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string sPlantCode = string.Empty;
        #endregion

        #region [ 생성자 ]
        public BM9100()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Form Load ]
        private void BM9100_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 140, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITTYPE", "장비유형ⓒ", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TERMINALID", "장비ID", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TERMINALNM", "장비명", true, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOCATION", "장비위치", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPADDRESS", "장비IP", true, GridColDataType_emu.IPv4Address, 140, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRINTER", "프린터유무", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", true, GridColDataType_emu.VarChar, 170, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["ITTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["TERMINALID"].Header.Appearance.ForeColor = Color.SkyBlue;

            ///////MERGE 
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region 콤보박스
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ITTYPE");     //현장장비유형
            WIZ.Common.FillComboboxMaster(this.cboITType_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRINTER", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            sPlantCode = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.Value = sPlantCode;

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

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sITType = Convert.ToString(cboITType_H.Value);
                string sTerminalID = txtTerminalID.Text;
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM9100_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("@AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("@AS_ITTYPE", sITType, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("@AS_TERMINALID", sTerminalID, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("@AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));


                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds(rtnDtTemp);

                        grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["ITTYPE"].CellActivation = Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["TERMINALID"].CellActivation = Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                    }
                    else
                    {
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }

                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);

                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                helper.Close();
            }
        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();
                this.grid1.InsertRow();
                this.grid1.SetDefaultValue("PLANTCODE", this.sPlantCode);
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
                this.grid1.ActiveRow.Cells["PRINTER"].Value = "N";

                grid1.ActiveRow.Cells["TERMINALID"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        /// 
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

            try
            {
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

                        #region [ Insert & Update 시 Validation Check ]
                        string sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
                        string sITType = Convert.ToString(drRow["ITTYPE"]);
                        string sTerminalID = Convert.ToString(drRow["TERMINALID"]);
                        string sTerminalNM = Convert.ToString(drRow["TERMINALNM"]);
                        string sLocation = Convert.ToString(drRow["LOCATION"]);
                        string sIPAddress = Convert.ToString(drRow["IPADDRESS"]);

                        if (sPlantCode == string.Empty)
                        {
                            this.ShowDialog(Common.getLangText("공장을 선택하세요. 필수 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        if (sITType == string.Empty)
                        {
                            this.ShowDialog(Common.getLangText("장비유형을 선택하세요. 필수 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (sTerminalID == string.Empty)
                        {
                            this.ShowDialog(Common.getLangText("장비ID를 입력하세요. 필수 항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;

                            if (sTerminalID.Length > 20)
                            {
                                this.ShowDialog(Common.getLangText("장비ID를 확인하세요. 20자리까지 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                return;
                            }
                        }
                        if (sTerminalNM.Length > 50)
                        {
                            this.ShowDialog(Common.getLangText("장비명을 확인하세요. 50자리까지 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (sLocation.Length > 20)
                        {
                            this.ShowDialog(Common.getLangText("장비위치를 확인하세요. 20자리까지 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (sIPAddress.Length > 20)
                        {
                            this.ShowDialog(Common.getLangText("IP주소를 확인하세요. 20자리까지 입력 가능합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                    }

                    #endregion

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM9100_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_ITTYPE", Convert.ToString(drRow["ITTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_TERMINALID", Convert.ToString(drRow["TERMINALID"]), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_BM9100_I1", CommandType.StoredProcedure
                                                        , helper.CreateParameter("@AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_ITTYPE", Convert.ToString(drRow["ITTYPE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_TERMINALID", Convert.ToString(drRow["TERMINALID"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_TERMINALNM", Convert.ToString(drRow["TERMINALNM"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_LOCATION", Convert.ToString(drRow["LOCATION"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_IPADDRESS", Convert.ToString(drRow["IPADDRESS"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_PRINTER", Convert.ToString(drRow["PRINTER"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("@AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_BM9100_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_ITTYPE", Convert.ToString(drRow["ITTYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_TERMINALID", Convert.ToString(drRow["TERMINALID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_TERMINALNM", Convert.ToString(drRow["TERMINALNM"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_LOCATION", Convert.ToString(drRow["LOCATION"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_IPADDRESS", Convert.ToString(drRow["IPADDRESS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_PRINTER", Convert.ToString(drRow["PRINTER"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));

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
                helper.Rollback();
                throw (ex);
            }
            finally
            {
                helper.Close();

                this.DoInquire();
            }
        }
        #endregion

        #region [ METHOD AREA ]
        /// <summary>
        /// 터미널 ID 부여
        /// </summary>
        /// <param name="sPlantCode"></param>
        /// <param name="sITType"></param>
        private void GetTerminalID(string sPlantCode, string sITType, ref string TerminalID)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable dtTemp = new DataTable();

                dtTemp = helper.FillTable("USP_GET_TERMINALID", CommandType.StoredProcedure
                                            , helper.CreateParameter("@AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("@AS_ITTYPE", sITType, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    return;
                }
                else
                {
                    if (dtTemp.Rows.Count > 0)
                    {
                        TerminalID = Convert.ToString(dtTemp.Rows[0][0]);
                    }
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        private void grid1_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            try
            {
                grid1.UpdateData();

                if (e.Cell.Column.ToString() == "PLANTCODE" || e.Cell.Column.ToString() == "ITTYPE")
                {
                    string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sITType = Convert.ToString(grid1.ActiveRow.Cells["ITTYPE"].Value);


                    string sTerminalID = Convert.ToString(grid1.ActiveRow.Cells["TERMINALID"].Value);
                    string nTerminalID = string.Empty;

                    //if (sTerminalID != string.Empty)
                    //    return;

                    if (sPlantCode != string.Empty && sITType != string.Empty)
                    {
                        GetTerminalID(sPlantCode, sITType, ref nTerminalID);
                        grid1.ActiveRow.Cells["TERMINALID"].Value = nTerminalID;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {

            }
        }
        #endregion


    }
}
