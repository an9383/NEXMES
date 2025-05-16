#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM4800
//   Form Name    : 지그비게이트웨이 관리
//   Name Space   : WIZ.BM
//   Created Date : 2012-03-19
//   Made By      : WIZCORE CO.,LTD
//   Description  : 작업라인(Workcenter) 관리 화면
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{
    public partial class BM4800 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil(); //비지니스 로직 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM4800()
        {
            InitializeComponent();

        }

        private void BM4800_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "GATEWAYID", "게이트웨이ID", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IP", "게이트웨이IP", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SERVERIP", "접속서버IP", true, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SERVERPORT", "접속서버PORT", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SERIALID", "게이트웨이SERIAL", false, GridColDataType_emu.VarChar, 100, 255, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LASTTIME", "최종처리일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USAGE", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장(사업장)", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생성시간", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정시간", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USAGE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


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

                string sUseFlag = DBHelper.nvlString(this.cboUseFlag_H.Value);
                string sPLANTCODE = DBHelper.nvlString(this.cboPlantCode_H.Value);
                string sID = txtID.Text.Trim();


                base.DoInquire();


                grid1.DataSource = helper.FillTable("USP_BM4800_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("ID", sID, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("PLANTCODE", sPLANTCODE, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();


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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();

            _GridUtil.AddRow(this.grid1);
            //this.grid1.SetDefaultValue("PlantCode", "SY");

            UltraGridUtil.ActivationAllowEdit(this.grid1, "GATEWAYID");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "IP");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "SERVERIP");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "SERVERPORT");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "SERIALID");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "USAGE");
            UltraGridUtil.ActivationAllowEdit(this.grid1, "PLANTCODE");



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
                        if (drRow["GATEWAYID"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "게이트웨이ID error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            //param = new System.Data.Common.DbParameter[3];


                            //param[0] = helper.CreateParameter("@pID", DBHelper.nvlString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input);         // 공장코드

                            //param[1] = helper.CreateParameter("@pRetCode", DbType.String, ParameterDirection.Output, null, 1);
                            //param[2] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM4800_D1", CommandType.StoredProcedure, param);

                            //if (param[1].Value.ToString() == "E") throw new Exception(param[2].Value.ToString());
                            helper.ExecuteNoneQuery("USP_BM4800_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("pID", Convert.ToString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input));
                            //, helper.CreateParameter("pRetCode",                                          DbType.String, ParameterDirection.Input)
                            //, helper.CreateParameter("pRetMessage",                                       DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            //param = new System.Data.Common.DbParameter[10];

                            //param[0] = helper.CreateParameter("@GATEWAYID", DBHelper.nvlString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input);
                            //param[1] = helper.CreateParameter("@IP", DBHelper.nvlString(drRow["IP"]), DbType.String, ParameterDirection.Input);
                            //param[2] = helper.CreateParameter("@SERVERIP", DBHelper.nvlString(drRow["SERVERIP"]), DbType.String, ParameterDirection.Input);
                            //param[3] = helper.CreateParameter("@SERVERPORT", DBHelper.nvlString(drRow["SERVERPORT"]), DbType.String, ParameterDirection.Input);
                            //param[4] = helper.CreateParameter("@SERIALID", DBHelper.nvlString(drRow["SERIALID"]), DbType.String, ParameterDirection.Input);
                            //param[5] = helper.CreateParameter("@USAGE", DBHelper.nvlString(drRow["USAGE"]), DbType.String, ParameterDirection.Input);
                            //param[6] = helper.CreateParameter("@PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input);
                            //param[7] = helper.CreateParameter("@pMaker", this.WorkerID, DbType.String, ParameterDirection.Input);

                            //param[8] = helper.CreateParameter("@pRetCode", DbType.String, ParameterDirection.Output, null, 1);
                            //param[9] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);

                            //helper.ExecuteNoneQuery("USP_BM4800_I1", CommandType.StoredProcedure, param);

                            //if (param[8].Value.ToString() == "E") throw new Exception(param[9].Value.ToString());
                            helper.ExecuteNoneQuery("USP_BM4800_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("GATEWAYID", Convert.ToString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("IP", Convert.ToString(drRow["IP"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SERVERIP", Convert.ToString(drRow["SERVERIP"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SERVERPORT", Convert.ToString(drRow["SERVERPORT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("SERIALID", Convert.ToString(drRow["SERIALID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USAGE", Convert.ToString(drRow["USAGE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("pMaker", this.WorkerID, DbType.String, ParameterDirection.Input));
                            //,helper.CreateParameter("pRetCode",     Convert.ToString, ParameterDirection.Output, null, 1)
                            //,helper.CreateParameter("pRetMessage",  Convert.ToString, ParameterDirection.Output, null, 200));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //param = new System.Data.Common.DbParameter[6];

                            // param[0] = helper.CreateParameter("@GATEWAYID", DBHelper.nvlString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input);
                            // param[1] = helper.CreateParameter("@PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input);
                            // param[2] = helper.CreateParameter("@USAGE", DBHelper.nvlString(drRow["USAGE"]), DbType.String, ParameterDirection.Input);
                            // param[3] = helper.CreateParameter("@pMaker", this.WorkerID, DbType.String, ParameterDirection.Input);

                            // param[4] = helper.CreateParameter("@pRetCode", DbType.String, ParameterDirection.Output, null, 1);
                            // param[5] = helper.CreateParameter("@pRetMessage", DbType.String, ParameterDirection.Output, null, 200);


                            // helper.ExecuteNoneQuery("USP_BM4800_U1", CommandType.StoredProcedure, param);

                            // if (param[4].Value.ToString() == "E") throw new Exception(param[5].Value.ToString());
                            helper.ExecuteNoneQuery("USP_BM4800_U1", CommandType.StoredProcedure
                                                   , helper.CreateParameter("GATEWAYID", Convert.ToString(drRow["GATEWAYID"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("USAGE", Convert.ToString(drRow["USAGE"]), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("pMaker", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("GATEWAYID");
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