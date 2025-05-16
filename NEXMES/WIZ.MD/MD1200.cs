#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MD1200
//   Form Name    : 수리/보수 의뢰
//   Name Space   : WIZ.MD
//   Created Date : 2014-05-08
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MD
{
    public partial class MD1200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >
        public MD1200()
        {
            InitializeComponent();
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
                base.DoInquire();  //사업장, 금형 , 수리의뢰일
                string sMoldCode = txtMoldCode.Text;                                           //금형코드
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode_H.Value);             // 공장코드     
                string sStartDate = string.Format("{0:yyyy-MM-dd}", CboStartDate_H.Value);     // 일자 FROM                                                                                                                                                                    
                string sEnddate = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);         // 일자 TO 


                grid1.DataSource = helper.FillTable("USP_MD1200_S2", CommandType.StoredProcedure    // 2014.7.1 임영조 USP_MD1200_S1 => USP_MD1200_S2
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MoldCode", sMoldCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("StartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EndDate", sEnddate, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                int iRow = _GridUtil.AddRow(this.grid1);
                //this.grid1.SetDefaultValue("PlantCode", "SY");

                UltraGridUtil.ActivationAllowEdit(this.grid1, "PlantCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "MoldCode");
                UltraGridUtil.ActivationAllowEdit(this.grid1, "Moldname");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(false);

            try
            {
                this.Focus();

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

                            helper.ExecuteNoneQuery("USP_MD1200_D1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input)          // 공장(사업부)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)            // 금형코드(금형 P/no(25) )
                                                   , helper.CreateParameter("RepReqNo", drRow["RepReqNo"].ToString(), DbType.String, ParameterDirection.Input));          // 품목코드                                                         

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            /* helper.ExecuteNoneQuery("USP_MD1200_I2"   //2014.7.1 Lim Y.J. USP_MD1200_I1 ==> USP_MD1200_I2, 정리
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                // , helper.CreateParameter("RepReqNo", drRow["RepReqNo"].ToString(), DbType.String, ParameterDirection.Input)          
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("RepairReqDate", drRow["RepairReqDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input));
                                //  , helper.CreateParameter("ReqWorker", drRow["ReqWorker"].ToString(), DbType.String, ParameterDirection.Input)        
                                                //   , helper.CreateParameter("RepDate", drRow["RepDate"].ToString(), DbType.String, ParameterDirection.Input)        
                                                   //, helper.CreateParameter("RepWoker", drRow["RepWoker"].ToString(), DbType.String, ParameterDirection.Input));  
                            */
                            helper.ExecuteNoneQuery("USP_MD1200_I2"   //2014.7.1 Lim Y.J. USP_MD1200_I1 ==> USP_MD1200_I2, 정리
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("RepairReqDate", drRow["RepairReqDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ReqWorker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            //2014.7.1 Lim Y.J. USP_MD1200_U1 ==> USP_MD1200_U2, 정리
                            /*  helper.ExecuteNoneQuery("USP_MD1200_U1"
                               , CommandType.StoredProcedure
                               , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                 , helper.CreateParameter("REPREQNO", drRow["REPREQNO"].ToString(), DbType.String, ParameterDirection.Input)           
                               , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("RepairReqDate", drRow["RepairReqDate"].ToString(), DbType.String, ParameterDirection.Input)
                                  //   , helper.CreateParameter("REPAIRFLAG", drRow["REPAIRFLAG"].ToString(), DbType.String, ParameterDirection.Input)       
                               , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)
                               //, helper.CreateParameter("ReqWorker", drRow["ReqWorker"].ToString(), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("RepDate", drRow["RepDate"].ToString(), DbType.String, ParameterDirection.Input)
                               , helper.CreateParameter("RepWoker", drRow["RepWoker"].ToString(), DbType.String, ParameterDirection.Input));           
                                                      //, helper.CreateParameter("Editor", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                             */
                            helper.ExecuteNoneQuery("USP_MD1200_U2" //2014.7.1 Lim Y.J. USP_MD1200_U1 ==> USP_MD1200_U2, 정리
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("REPREQNO", drRow["REPREQNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("MoldCode", drRow["MoldCode"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("RepairReqDate", drRow["RepairReqDate"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("Remark", drRow["Remark"].ToString(), DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("ReqWorker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));


                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PLANTCODE");
                helper.Commit();
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region < EVENT AREA >
        #endregion

        #region < MD1200_Load >
        private void MD1200_Load(object sender, EventArgs e)
        {
            #region 그리드
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepairReqDate", "수리의뢰일", true, GridColDataType_emu.YearMonthDay, 200, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MoldCode", "금형코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Moldname", "금형명", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목코드", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepReqNo", "수리의뢰번호", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "참조", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepairFlag", "수리여부", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepDate", "수리일자", true, GridColDataType_emu.YearMonthDay, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepWoker", "수리작업자", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepResult", "수리결과", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RepDesc", "수리내역", true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion
            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");     //수리여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RepairFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepResult");     //수리결과
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RepResult", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("RepDesc");     //수리내역
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RepDesc", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
            #region --- POP-UP Setting ---
            // pop up 화면(gird POP-UP)
            BizGridManager bizGrid = new BizGridManager(grid1);
            //     bizGrid.PopUpAdd("ItemCode", "ItemName", "TBM0100", new string[] { "PlantCode", "" });     //  품목POP_UP grid
            bizGrid.PopUpAdd("MoldCode", "MoldName", "TBM1600", new string[] { "PlantCode", "" });      // 금형 POP_UP grid
            ////조회용 POP 
            //팝업 매니저
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMoldCode, txtMoldName, "TBM1600", new object[] { cboPlantCode_H, "" }); //금형
            #endregion
        }
        #endregion

        #region <METHOD AREA>*/
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}

