#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  HH0200
//   Form Name    :  
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class HH0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataSet rtnDsTemp = new DataSet(); // return DataSet 공통
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        #endregion

        #region < CONSTRUCTOR >

        public HH0200()
        {
            InitializeComponent();
        }
        #endregion

        #region  HH0200_Load
        private void HH0200_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "작업일자", false, GridColDataType_emu.VarChar, 95, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "시작시간", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "종료시간", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RUNTIME", "가동시간(M)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTIME", "비가동시간(M)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTIME_G", "고정비가동시간(M)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPTIME_N", "비가동시간(M)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "설비카운트", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULTQTY", "입고수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STATIME", "S/T", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GOODPRODRATE", "합격율", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STANDARDUPH", "표준\nUPH", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REALUPH", "달성\nUPH", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 220, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;

            string[] sMergeColumn = { "STARTDATE", "ENDDATE", "RUNTIME", "STOPTIME_N" };
            string[] sMergeColumn2 = { "PRODQTY", "RESULTQTY", "ERRORQTY" };
            string[] sHeadColumn = { "PlantCode", "RECDATE", "DAYNIGHT", "OPCODE", "OPNAME", "WORKCENTERCODE", "WORKCENTERNAME"
                                       , "ITEMCODE", "STARTDATE", "ENDDATE", "RUNTIME", "STOPTIME_N"
                                       , "PRODQTY", "RESULTQTY", "ERRORQTY", "STATIME", "GOODPRODRATE", "STANDARDUPH", "REALUPH"
                                       , "WORKERNAME", "REMARK", "EDITDATE", "EDITOR" };

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion



            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("PlantCode");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboDayNight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            #endregion

            //그리드 머지
            _GridUtil.GridHeaderMerge(grid1, "G1", "작업시간(분)", sMergeColumn, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "수량", sMergeColumn2, sHeadColumn);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 7);
            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 15, 22);

            //팝업창
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
            btbManager.PopUpAdd(txtWorkCenterCode, txtWorkCenterName, "TBM0600", new object[] { cboPlantCode_H, txtOPCode, "", "" });

        }
        #endregion  HH0200_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[8];

            try
            {

                base.DoInquire();
                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value.ToString());                  // 사업장 공장코드
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);                         // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);                             // 종료일자
                string sWorkCenterCode = this.txtWorkCenterCode.Text;                                     // 작업장
                string sOPCode = this.txtOPCode.Text.Trim();                                              // 공정 
                string sDayNight = DBHelper.nvlString(cboDayNight.Value.ToString());

                param[0] = helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input);                  //사업부(공장)
                param[1] = helper.CreateParameter("StartDate", sSrart, DbType.String, ParameterDirection.Input);                      //시작일자(시)
                param[2] = helper.CreateParameter("EndDate", sEnd, DbType.String, ParameterDirection.Input);                          //종료일자(종)
                param[3] = helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input);        //작업장
                param[4] = helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input);
                param[5] = helper.CreateParameter("DayNight", sDayNight, DbType.String, ParameterDirection.Input);
                param[6] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                param[7] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                grid1.DataSource = helper.FillTable("USP_HH0200_S1", CommandType.StoredProcedure, param);
                grid1.DataBinds();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                helper.Close();
                if (param != null) { param = null; }
            }
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);
            System.Data.Common.DbParameter[] param = null;

            try
            {
                this.Select();

                //if (this.ShowDialog("Q00009") == System.Windows.Forms.DialogResult.Cancel)
                //    return;

                base.DoSave();

                // UltraGridUtil.DataRowDelete(this.grid1);
                //this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "PlantCode error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;
                        case DataRowState.Added:
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            param = new System.Data.Common.DbParameter[9];

                            param[0] = helper.CreateParameter("@PLANTCODE", DBHelper.gGetCode(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input);
                            param[1] = helper.CreateParameter("@RECDATE", drRow["RECDATE"], DbType.String, ParameterDirection.Input);
                            param[2] = helper.CreateParameter("@DAYNIGHT", DBHelper.gGetCode(drRow["DAYNIGHT"]), DbType.String, ParameterDirection.Input);     // 등록자\
                            param[3] = helper.CreateParameter("@WORKCENTERCODE", drRow["WORKCENTERCODE"], DbType.String, ParameterDirection.Input);
                            param[4] = helper.CreateParameter("@ITEMCODE", drRow["ITEMCODE"], DbType.String, ParameterDirection.Input);
                            param[5] = helper.CreateParameter("@REMARK", drRow["REMARK"], DbType.String, ParameterDirection.Input);
                            param[6] = helper.CreateParameter("@EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input);
                            param[7] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            param[8] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            helper.ExecuteNoneQuery("USP_HH0200_U1", CommandType.StoredProcedure, param);

                            if (param[7].Value.ToString() == "E") throw new Exception(param[8].Value.ToString());
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
                if (param != null) { param = null; }
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
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                //                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                //             e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "데이터가 중복입니다.";
                    throw (new SException("C:S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "RUNTIME", "STOPTIME", "STOPTIME", "PRODQTY", "RESULTQTY", "ERRORQTY", });

        }

        #endregion
    }
}
