#region <USING AREA>
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP9120 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        public string sWorkerID = string.Empty;
        #endregion

        #region<CONSTRUCTOR>
        public PP9120()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkerid, txtWorkerName, "TBM0200", new object[] { "", "", "", "", "" });
        }
        #endregion

        #region 폼 로더
        private void PP9120_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "사용자ID", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "사용자명", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ALARMFLAG", "알람구분", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ETCCODE", "ETCCODE", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "발생일자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주/야구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHTNAME", "주/야구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ALARMON", "알람확인여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ALARMMSG", "알람메세지", false, GridColDataType_emu.VarChar, 500, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "발생일시", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "알람확인일시", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("WALARMFLAG");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ALARMFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");     //문제/보류 여부
            WIZ.Common.FillComboboxMaster(this.cboAlarmflag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ALARMON", rtnDtTemp, "CODE_ID", "CODE_NAME");     //문제/보류 여부
            WIZ.Common.FillComboboxMaster(this.cboAlarmOn, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");     //문제/보류 여부

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");     //문제/보류 여부

            #endregion
        }


        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();

                sWorkerID = txtWorkerid.Text.Trim();
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", CboEnddate_H.Value);
                string sAlarmflag = cboAlarmflag.Value.ToString();
                string sAlarmon = cboAlarmOn.Value.ToString();
                string sPLANTCODE = cboPlantCode_H.Value.ToString();

                grid1.DataSource = helper.FillTable("USP_PP9120_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("WORKID", sWorkerID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ALARMFLAG", sAlarmflag, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ALARMON", sAlarmon, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARAM1", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARAM2", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PARAM3", "", DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();


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

        public override void DoSave()
        {

        }
        #endregion
    }
}