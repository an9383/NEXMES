#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0290
//   Form Name    : 입출고 이력
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-19
//   Made By      : 
//   Edited Date  : 
//   Edit By      :
//   Description  : 자재 입출고 이력 조회
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0290 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();

        string _ChkFlag = string.Empty;
        #endregion

        #region < CONSTRUCTOR >

        public PP0290()
        {
            InitializeComponent();
        }

        #endregion

        #region  < FORM LOAD >
        private void PP0290_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECTIME", "시각", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Temperature", "온도", false, GridColDataType_emu.Double, 120, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Humidity", "습도", false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CODE1", "참조1", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CODE2", "참조2", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CODE3", "참조3", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CODE4", "참조4", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CODE5", "참조5", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region < COMBO BOX SETTING >
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-5);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                rtnDtTemp = helper.FillTable("USP_PP0290_S1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                        );
                //, helper.CreateParameter("AS_INOUTFLAG",    _ChkFlag,    DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);

                    foreach (UltraGridRow dr in grid1.Rows)
                    {
                        dr.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                        dr.Cells["RECDATE"].Activation = Activation.NoEdit;
                        dr.Cells["RECTIME"].Activation = Activation.NoEdit;
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();

            if (rtnDtTemp == null)
            {
                return;
            }

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in rtnDtTemp.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("사업장은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["RECDATE"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("일자는 필수 입력항목입니다..", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        if (Convert.ToString(drRow["RECTIME"]) == string.Empty)
                        {
                            this.ClosePrgFormNew();
                            this.ShowDialog(Common.getLangText("시각은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            return;
                        }
                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_PP0290_I1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PCODE", "D1", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RECDATE", DBHelper.nvlString(drRow["RECDATE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RECTIME", DBHelper.nvlString(drRow["RECTIME"]), DbType.String, ParameterDirection.Input)
                                );
                            break;
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_PP0290_I1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PCODE", "U1", DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RECDATE", DBHelper.nvlString(drRow["RECDATE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_RECTIME", DBHelper.nvlString(drRow["RECTIME"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_Temperature", DBHelper.nvlDouble(drRow["Temperature"]), DbType.Double, ParameterDirection.Input)
                                , helper.CreateParameter("AS_Humidity", DBHelper.nvlDouble(drRow["Humidity"]), DbType.Double, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CODE1", DBHelper.nvlString(drRow["CODE1"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CODE2", DBHelper.nvlString(drRow["CODE2"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CODE3", DBHelper.nvlString(drRow["CODE3"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CODE4", DBHelper.nvlString(drRow["CODE4"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_CODE5", DBHelper.nvlString(drRow["CODE5"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            );
                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
                }
                else if (helper.RSCODE == "E")
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
            this.grid1.InsertRow();

            //사업장과 사용여부는 행 추가시 기본으로 세팅
            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            this.grid1.ActiveRow.Cells["RECDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd");
            this.grid1.ActiveRow.Cells["RECTIME"].Value = DateTime.Now.ToString("HH:mm:ss");
        }

        public override void DoDelete()
        {
            this.grid1.DeleteRow();


        }
        #endregion

        #region < EVENT AREA >

        #endregion
    }
}


