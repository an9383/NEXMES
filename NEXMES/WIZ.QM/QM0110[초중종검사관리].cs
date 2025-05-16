#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : QM0110
//   Form Name    : 초중종관리
//   Name Space   : WIZ.QM
//   Created Date : 2019-12-18
//   Made By      : 기술연구소 최문준
//   Edited Date  : 2020-02-07
//   Edit By      : IFS팀 최문준
//   Description  : 초중종검사관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.QM
{
    public partial class QM0110 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;
        BizGridManager bizGridManager;

        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();

        string sUserID = WIZ.LoginInfo.UserID; // Default 사용자
        #endregion

        #region < CONSTRUCTOR >
        public QM0110()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void QM0110_Load(object sender, EventArgs e)
        {
            #region GRID SETTING

            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "작업지시일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE", "공정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME", "공정명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "검사값구분", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "검사단위", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "관리구분", false, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INITINSP", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INITINSPDATE", "검사일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INITINSPUSER", "검사자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INTERINSP", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INTERINSPDATE", "검사일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INTERINSPUSER", "검사자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FINALINSP", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FINALINSPDATE", "검사일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FINALINSPUSER", "검사자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 500, 100, Infragistics.Win.HAlign.Left, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            string[] arrMerCol1 = { "ORDERNO", "ORDERDATE", "PLANTCODE", "WORKCENTERCODE", "WORKCENTERNAME", "ITEMCODE", "ITEMNAME", "OPCODE", "OPNAME", "INSPCODE", "INSPNAME", "VALUETYPE", "UNITCODE", "SPECTYPE", "SPECNOL", "SPECLSL", "SPECUSL", "INITINSP", "INITINSPDATE", "INITINSPUSER", "INTERINSP", "INTERINSPDATE", "INTERINSPUSER", "FINALINSP", "FINALINSPDATE", "FINALINSPUSER" };

            _GridUtil.GridHeaderMerge(grid1, "A1", "스펙정보", new string[] { "SPECNOL", "SPECLSL", "SPECUSL" }, arrMerCol1);
            _GridUtil.GridHeaderMerge(grid1, "A2", "초물검사", new string[] { "INITINSP", "INITINSPDATE", "INITINSPUSER" }, arrMerCol1);
            _GridUtil.GridHeaderMerge(grid1, "A3", "중물검사", new string[] { "INTERINSP", "INTERINSPDATE", "INTERINSPUSER" }, arrMerCol1);
            _GridUtil.GridHeaderMerge(grid1, "A4", "종물검사", new string[] { "FINALINSP", "FINALINSPDATE", "FINALINSPUSER" }, arrMerCol1);

            _GridUtil.GridHeaderMergeVertical(grid1, arrMerCol1, 0, 11);
            #endregion

            #region COMBOBOX SETTING

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now;

            #endregion

            #region POPUP SETTING
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

            bizGridManager = new BizGridManager(grid1);
            bizGridManager.PopUpAdd("ItemCode", "ItemName", "BM0010", new string[] { "PlantCode", "", "Y" });
            bizGridManager.PopUpAdd("WorkcenterCode", "WorkcenterName", "BM0040", new string[] { "PlantCode", "", "Y" });
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            bNew = false;

            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());

                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_QM0110_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBind();

                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            grid1.Rows[i].Cells["INITINSP"].Appearance.BackColor = Color.DarkCyan;
                            grid1.Rows[i].Cells["INITINSP"].Appearance.ForeColor = Color.White;

                            grid1.Rows[i].Cells["INTERINSP"].Appearance.BackColor = Color.DarkCyan;
                            grid1.Rows[i].Cells["INTERINSP"].Appearance.ForeColor = Color.White;

                            grid1.Rows[i].Cells["FINALINSP"].Appearance.BackColor = Color.DarkCyan;
                            grid1.Rows[i].Cells["FINALINSP"].Appearance.ForeColor = Color.White;

                        }
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ClosePrgForm();
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        public override void DoNew()
        {
            base.DoNew();

            DBHelper helper = new DBHelper(false);

            try
            {
                if (bNew == true)
                {
                    this.ShowDialog(Common.getLangText("생성 할 초중종검사 현황이 있습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                bNew = true;

                _GridUtil.Grid_Clear(grid1);

                string sPlantCode = Convert.ToString(cbo_PLANTCODE_H.Value);

                rtnDtTemp = helper.FillTable("USP_QM0110_S2", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input));

                for (int iRow = 0; iRow < rtnDtTemp.Rows.Count; iRow++)
                {
                    iRow = grid1.InsertRow();

                    grid1.Rows[iRow].Cells["ORDERNO"].Value = rtnDtTemp.Rows[iRow]["ORDERNO"];
                    grid1.Rows[iRow].Cells["PLANTCODE"].Value = rtnDtTemp.Rows[iRow]["PLANTCODE"];

                    grid1.Rows[iRow].Cells["ORDERDATE"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["ITEMNAME"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["OPNAME"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["INSPNAME"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["VALUETYPE"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["UNITCODE"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["SPECTYPE"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["SPECNOL"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["SPECLSL"].Activation = Activation.Disabled;
                    grid1.Rows[iRow].Cells["SPECUSL"].Activation = Activation.Disabled;

                    grid1.UpdateData();
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

        public override void DoDelete()
        {
            base.DoDelete();

            this.grid1.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dtChange = grid1.chkChange();

            if (dtChange == null)
                return;

            string sPlantCode = LoginInfo.PlantCode.Trim();
            string sContractNO = string.Empty;
            string sItemCode = string.Empty;
            string sContractDate = string.Empty;
            string sDueDate = string.Empty;
            string sCloseDate = string.Empty;
            string sCloseFlag = string.Empty;
            string sCloser = string.Empty;
            string sRemark = string.Empty;
            string sUser = LoginInfo.UserID;

            double dContractQty;

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (DataRow drChange in dtChange.Rows)
                {
                    switch (drChange.RowState)
                    {
                        case DataRowState.Deleted:
                            #region --- 삭제 ---
                            drChange.RejectChanges();

                            sContractNO = Convert.ToString(drChange["CONTRACTNO"]);

                            helper.ExecuteNoneQuery("USP_AP0110_D1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region --- 추가 ---                            
                            sItemCode = Convert.ToString(drChange["ITEMCODE"]);
                            sContractNO = Convert.ToString(drChange["CONTRACTNO"]);
                            sContractDate = string.Format("{0:yyyy-MM-dd}", drChange["CONTRACTDATE"]);
                            dContractQty = DBHelper.nvlDouble(drChange["CONTRACTQTY"]);
                            sDueDate = string.Format("{0:yyyy-MM-dd}", drChange["DUEDATE"]);
                            sCloseFlag = Convert.ToString(drChange["CLOSEFLAG"]);
                            sRemark = Convert.ToString(drChange["REMARK"]);

                            helper.ExecuteNoneQuery("USP_AP0110_I1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region --- 수정 ---
                            sItemCode = Convert.ToString(drChange["ITEMCODE"]);
                            sContractNO = Convert.ToString(drChange["CONTRACTNO"]);
                            sContractDate = string.Format("{0:yyyy-MM-dd}", drChange["CONTRACTDATE"]);
                            dContractQty = DBHelper.nvlDouble(drChange["CONTRACTQTY"]);
                            sDueDate = string.Format("{0:yyyy-MM-dd}", drChange["DUEDATE"]);
                            sCloseDate = string.Format("{0:yyyy-MM-dd}", drChange["CLOSEDATE"]);
                            sCloseFlag = Convert.ToString(drChange["CLOSEFLAG"]);
                            sCloser = Convert.ToString(drChange["CLOSER"]);
                            sRemark = Convert.ToString(drChange["REMARK"]);

                            helper.ExecuteNoneQuery("USP_AP0110_U1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CONTRACTNO", sContractNO, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AF_CONTRACTQTY", dContractQty, DbType.Double, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CONTRACTDATE", sContractDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_DUEDATE", sDueDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CLOSEDATE", sCloseDate, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CLOSEFLAG", sCloseFlag, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_CLOSER", sCloser, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_REMARK", sRemark, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_USER", sUser, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                        return;
                    }
                }

                grid1.SetAcceptChanges();

                helper.Commit();

                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();

                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

                ClosePrgFormNew();
            }
        }
        #endregion
    }
}
