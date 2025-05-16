#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        : BM5450
//   Form Name      : 검사항목별 측정항목 관리
//   Name Space     : MHSPC.BM
//   Created Date   : 2012.10.12
//   Made By        : WIZCORE
//   Description    : 검사항목별 측정항목 관리
//   DB Table       : BM1100
//   StoreProcedure : USP_BM5450_S1(S2, I1, D1, U1)
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
    public partial class BM5450 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        private DataTable rtnDtTemp = new DataTable();
        private DataTable rtnDtTemp2 = new DataTable();
        private DataTable DtGrid1 = new DataTable();
        private DataTable DtGrid2 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public BM5450()
        {
            InitializeComponent();

            BizGridManager gridManager = new BizGridManager(grid2);


            gridManager.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "InspCase", "InspType", "Y" }); //TBM1500 : 검사항목
        }
        #endregion

        #region<BM5450_Load>
        private void BM5450_Load(object sender, EventArgs e)    //폼 로드시 공장콤보박스 값 설정
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid1, "IFDATAID", "레코드ID", true, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFDATANAME", "레코드명", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IFRECORDTYPE", "레코드 유형", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECORDLEN", "레코드 길이", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILEHEADERLINE", "헤더라인수", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DELIMITER", "구분자", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TAGID", "TagID", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE", "라인", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "", false, GridColDataType_emu.VarChar, 123, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);

            _GridUtil.SetColumnMerge(this, grid1, "PLANTCODE");
            _GridUtil.SetInitUltraGridBind(grid1);
            DtGrid1 = (DataTable)this.grid1.DataSource;
            #endregion

            #region Grid2 셋팅
            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", true);

            _GridUtil.InitColumnUltraGrid(grid2, "IFDATAID", "레코드ID", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SEQNO", "일련번호", true, GridColDataType_emu.Integer, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DAITEM", "수집항목", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DAITEMNAME", "수집항목", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INSPITEM", "측정항목", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INTERVALS", "시작점", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "INTERVALLEN", "구분길이", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FILETYPE", "파일유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DATATYPE", "데이터유형", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "RCVDATATYPE", "자주검사데이터유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PROCGB", "관리구분", false, GridColDataType_emu.Integer, 100, 130, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PROCTYPE", "계산유형", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DATALEN", "데이터길이", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FORMAT", "형식", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "POSITION", "위치", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PRECISION", "정밀도", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLCADDR", "PLC ADDR", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TAGID", "TAGID", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "", false, GridColDataType_emu.DateTime24, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "", false, GridColDataType_emu.DateTime24, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            this.grid2.DisplayLayout.Bands[0].Columns["INSPCODE"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            this.grid2.DisplayLayout.Bands[0].Columns["INSPITEM"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;

            _GridUtil.SetColumnMerge(this, grid2, "PLANTCODE");

            _GridUtil.SetInitUltraGridBind(grid2);

            DtGrid2 = (DataTable)this.grid2.DataSource;
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("INSPCASE");     // 검사구분
            //WIZ.Common.FillComboboxMaster(this.cboInspCase_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspCase", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            //WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                DtGrid1.Clear();
                base.DoInquire();
                string sIFDataID_H = txtIFDataID_H.Text.Trim();

                grid1.DataSource = helper.FillTable("USP_BM5450_S1N", CommandType.StoredProcedure
                                                             , helper.CreateParameter("IFDataID", sIFDataID_H, DbType.String, ParameterDirection.Input));

                grid1.DataBind();
                DtGrid1 = (DataTable)grid1.DataSource;
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

        public System.Windows.Forms.Control FindControl(System.Windows.Forms.Control.ControlCollection controlcollection, string controlid)
        {
            System.Windows.Forms.Control rsltcontrol;
            // 정상적으로 찾은 경우 컨트롤을 반환
            if (controlcollection[controlid] != null) return controlcollection[controlid];

            // 없을 경우 자식을 변경 한다.
            for (int i = 0; i < controlcollection.Count; i++)
            {
                rsltcontrol = FindControl(controlcollection[i].Controls, controlid);

                if (rsltcontrol != null) return rsltcontrol;
            }

            return null;


        }

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            if (this.grid1.IsActivate)
            {
                int iRow = _GridUtil.AddRow(this.grid1);
                return;
            }

            if (this.grid2.IsActivate)
            {

                if (this.DtGrid1.Rows.Count > 0)
                {
                    base.DoNew();
                    _GridUtil.AddRow(this.grid2);
                    //this.grid1.SetDefaultValue("PlantCode", "SY");

                    this.grid2.ActiveRow.Cells["DAItem"].Value = "*";
                    this.grid2.ActiveRow.Cells["DAItemName"].Value = "*";
                    this.grid2.ActiveRow.Cells["IntervalS"].Value = 0;
                    this.grid2.ActiveRow.Cells["IntervalLen"].Value = 0;
                    this.grid2.ActiveRow.Cells["ProcGB"].Value = 1;
                    this.grid2.ActiveRow.Cells["ProcType"].Value = "VAL";
                    this.grid2.ActiveRow.Cells["DataLen"].Value = 0;
                    this.grid2.ActiveRow.Cells["Position"].Value = 0;
                    this.grid2.ActiveRow.Cells["Precision"].Value = 0;
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

            if (this.grid2.IsActivate)
                this.grid2.DeleteRow();
            else
            {
                if (grid2.Rows.Count > 0)
                {

                    this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                int grid2rowcount = this.grid2.Rows.Count;
                for (int i = 0; i < grid2rowcount; i++)
                {
                    this.grid2.DeleteRow();
                }
                this.grid1.DeleteRow();
            }
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            base.DoSave();

            this.grid1.PerformAction(UltraGridAction.DeactivateCell);

            if (UltraGridUtil.CheckSaveDataGrid(this, this.grid1, DtGrid1, true) == true)
            {
                //주코드
                Ins_Ups_Grid1(DtGrid1, this.WorkerID);
            }

            this.grid2.PerformAction(UltraGridAction.DeactivateCell);
            if (UltraGridUtil.CheckSaveDataGrid(this, this.grid2, DtGrid2, true) == true)
            {
                //부코드
                Ins_Ups_Grid2(DtGrid2, this.WorkerID);
            }
        }

        #region 등록(RECORD)
        public void Ins_Ups_Grid1(DataTable DtChange, string USER_ID)
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);

            try
            {
                //this.grid1.UpdateData();
                //helper._sTran = helper._sConn.BeginTransaction();
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlanNo"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "지시번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM5450_D1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM5450_I1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFRECORDTYPE", drRow["IFRECORDTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFDATANAME", drRow["IFDATANAME"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RECORDLEN", drRow["RECORDLEN"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILEHEADERLINE", drRow["FILEHEADERLINE"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DELIMITER", drRow["DELIMITER"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TAGID", drRow["TAGID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM5450_U1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFRECORDTYPE", drRow["IFRECORDTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("IFDATANAME", drRow["IFDATANAME"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RECORDLEN", drRow["RECORDLEN"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILEHEADERLINE", drRow["FILEHEADERLINE"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DELIMITER", drRow["DELIMITER"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TAGID", drRow["TAGID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();

                helper.Commit();

            }
            catch (Exception ex)
            {


                helper.Rollback();


                WIZ.Forms.CheckForm checkform = new Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region 등록(RECORD 항목 내역)
        public void Ins_Ups_Grid2(DataTable DtChange, string USER_ID)
        {
            DataTable dt = grid2.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);

            try
            {
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlanNo"].ToString().Trim() == "")
                        {
                            grid2.SetRowError(drRow, "지시번호 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM5450_D2N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SEQNO", drRow["SEQNO"], DbType.Double, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM5450_I2N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SEQNO", drRow["SEQNO"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DAITEM", drRow["DAITEM"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCODE", drRow["INSPCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPCODE", drRow["OPCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPITEM", drRow["INSPITEM"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DAITEMNAME", drRow["DAITEMNAME"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INTERVALS", drRow["INTERVALS"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INTERVALLEN", drRow["INTERVALLEN"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILETYPE", drRow["FILETYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DATATYPE", drRow["DATATYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RCVDATATYPE", drRow["RCVDATATYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PROCGB", drRow["PROCGB"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PROCTYPE", drRow["PROCTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DATALEN", drRow["DATALEN"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FORMAT", drRow["FORMAT"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("POSITION", drRow["POSITION"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PRECISION", drRow["PRECISION"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLCADDR", drRow["PLCADDR"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TAGID", drRow["TAGID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("REMARK", drRow["REMARK"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM5450_U2N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("IFDATAID", drRow["IFDATAID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SEQNO", drRow["SEQNO"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DAITEM", drRow["DAITEM"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPCODE", drRow["INSPCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("OPCODE", drRow["OPCODE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INSPITEM", drRow["INSPITEM"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DAITEMNAME", drRow["DAITEMNAME"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INTERVALS", drRow["INTERVALS"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("INTERVALLEN", drRow["INTERVALLEN"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FILETYPE", drRow["FILETYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DATATYPE", drRow["DATATYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("RCVDATATYPE", drRow["RCVDATATYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PROCGB", drRow["PROCGB"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PROCTYPE", drRow["PROCTYPE"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("DATALEN", drRow["DATALEN"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("FORMAT", drRow["FORMAT"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("POSITION", drRow["POSITION"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PRECISION", drRow["PRECISION"], DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLCADDR", drRow["PLCADDR"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("TAGID", drRow["TAGID"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("REMARK", drRow["REMARK"], DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid2.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid2.SetAcceptChanges();

                helper.Commit();

            }
            catch (Exception ex)
            {
                helper.Rollback();

                WIZ.Forms.MessageForm messageform = new Forms.MessageForm(ex);
                messageform.ShowDialog();
            }
            finally
            {
                // if (helper._sConn != null)
                // {
                //     helper._sConn.Close();
                // }
                helper.Close();
            }
        }
        #endregion

        public override void DoDownloadExcel()
        {
            if (this.grid1.Rows.Count == 0)
            {

                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            if (this.grid2.IsActivate)
            {
                if (this.grid2.Rows.Count == 0)
                {

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                this.grid2.ExportExcel();
                base.DoDownloadExcel();
                return;
            }
            this.grid1.ExportExcel();
            base.DoDownloadExcel();
        }
        #endregion

        #region<Event>
        private void grid2_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            e.Row.Cells["IFDataID"].Value = this.grid1.ActiveRow.Cells["IFDataID"].Value;
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            if (DtGrid2 != null)
                DtGrid2.Clear();

            string sIFDataID = Convert.ToString(this.grid1.ActiveRow.Cells["IFDataID"].Value);

            rtnDtTemp2 = helper.FillTable("USP_BM5450_S2N", CommandType.StoredProcedure
                                                          , helper.CreateParameter("IFDATAID", sIFDataID, DbType.String, ParameterDirection.Input));
            if (rtnDtTemp2 != null)
            {
                grid2.DataSource = rtnDtTemp2;
                grid2.DataBind();
                DtGrid2 = rtnDtTemp2;
            }
        }  // grid1의 행을 선택할 때마다 grid1의 코드를 기준으로 grid2의 행이 변함.

        private void grid1_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            //e.Row.Cells["USEFLAG"].Value = 'Y';
        }

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

        private void grid2_KeyDown(object sender, KeyEventArgs e)
        {
            string enter = e.KeyCode.ToString();
            if (enter == "Return")
            {
                Infragistics.Win.UltraWinGrid.GridKeyActionMapping KeyMapping1 = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Tab, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0);
                this.grid2.KeyActionMappings.Add(KeyMapping1);
                this.grid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
            }
        }

        private void grid2_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "INSPCODE")
            {
                System.Windows.Forms.Control txtLineCode = new System.Windows.Forms.Control();
                txtLineCode.Text = grid1.ActiveRow.Cells["LINECODE"].Text;
                System.Windows.Forms.Control txtLineName = new System.Windows.Forms.Control();
                System.Windows.Forms.Control txtInspCode = new System.Windows.Forms.Control();
                System.Windows.Forms.Control txtInspName = new System.Windows.Forms.Control();

                if ("" != txtInspCode.Text)
                    grid2.ActiveRow.Cells["INSPCODE"].Value = txtInspCode.Text;
            }
            else
            {
                if (grid2.ActiveRow.Cells["INSPCODE"].Text == "")
                {


                    this.ShowDialog(Common.getLangText("검사코드를 입력하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }
                System.Windows.Forms.Control txtLineCode = new System.Windows.Forms.Control();

                System.Windows.Forms.Control txtInspCode = new System.Windows.Forms.Control();
                txtInspCode.Text = this.grid2.ActiveRow.Cells["INSPCODE"].Text;
                System.Windows.Forms.Control txtInspName = new System.Windows.Forms.Control();
                System.Windows.Forms.Control txtInspItem = new System.Windows.Forms.Control();
                System.Windows.Forms.Control txtInspItemName = new System.Windows.Forms.Control();

                if ("" != txtInspItem.Text)
                    grid2.ActiveRow.Cells["INSPITEM"].Value = txtInspItem.Text;
            }
        }

        private void grid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((WIZ.Control.Grid)(sender)).ActiveCell.Column.Key == "SEQNO")
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(Keys.Enter)))
                {
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region <METHOD AREA>
        /// <summary>
        /// 행의 신규 등록시 오류 CHECK
        /// </summary>
        private void DoNewValidate(DataRow row)
        {
            /*
            if (row["IFDATAID"].ToString() == "")
            {
                row.RowError = this.FormInformation.GetMessage("R00000");

                throw (new SException(this.grid1.DisplayLayout.Bands[0].Columns["IFDataID"].Header.Caption, "R00000", null));
            }

            if (row["SEQNO"].ToString() == "")
            {
                row.RowError = this.FormInformation.GetMessage("R00000");

                throw (new SException(this.grid1.DisplayLayout.Bands[0].Columns["SeqNO"].Header.Caption, "R00000", null));
            }
             */
        }
        #endregion


    }
}
