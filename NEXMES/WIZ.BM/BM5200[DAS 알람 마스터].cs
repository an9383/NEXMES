#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5200
//   Form Name    : 메시지정보마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-08
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 메시지 기준정보 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM5200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM5200()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM5200_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 메세지
                _GridUtil.InitializeGrid(this.grid1, false, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장코드", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ALARMID", "알람 ID", true, GridColDataType_emu.VarChar, 90, 110, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MES_TITLE", "알람 제목", true, GridColDataType_emu.VarChar, 250, 250, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MES_CONTENTS", "알람 내용", true, GridColDataType_emu.VarChar, 600, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "등록 일자", true, GridColDataType_emu.VarChar, 130, 200, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", true, GridColDataType_emu.DateTime, 180, 180, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                //필수입력 항목에 대한 음영
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ALARMID"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MES_TITLE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MES_CONTENTS"].Header.Appearance.ForeColor = Color.SkyBlue;

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                #endregion

                #region POPUP SETTING

                BizGridManager gridManager = new BizGridManager(grid1); //그리드 콤보박스 객체 생성
                //작업장
                gridManager.PopUpAdd("WORKCENTERCODE", "WORKCENTERNAME", "BM0060", new string[] { "PLANTCODE", "", "", "Y" });

                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                //string sMessageID    = DBHelper.nvlString(txt_MSGID_H.Value);
                //string sMessageType  = DBHelper.nvlString(cbo_MSGTYPE_H.Value);
                //string sUseFlag      = DBHelper.nvlString(cbo_USEFLAG_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM5200_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            //, helper.CreateParameter("AS_MSGID",     sMessageID,   DbType.String, ParameterDirection.Input)
                                                            //, helper.CreateParameter("AS_MSGTYPE",   sMessageType, DbType.String, ParameterDirection.Input)
                                                            //, helper.CreateParameter("AS_USEFLAG",   sUseFlag,     DbType.String, ParameterDirection.Input)
                                                            );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;

                grid1.ActiveRow.Cells["PLANTCODE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["WORKCENTERCODE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["MES_TITLE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["MES_CONTENTS"].Activation = Activation.AllowEdit;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            //this.grid1.DeleteRow(); //BM은 삭제기능 비활성화
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            rtnDtTemp = grid1.chkChange();

            DateTime dtNow = DateTime.Now;

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
                        //if (Convert.ToString(drRow["PLANTCODE"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("사업장은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK); 
                        //    return;
                        //}

                        //if (Convert.ToString(drRow["MESSAGETYPE"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("메시지 유형은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                        //    return;
                        //}


                        //if (Convert.ToString(drRow["MESSAGEDESC"]) == string.Empty)
                        //{
                        //    this.ClosePrgFormNew();
                        //    this.ShowDialog(Common.getLangText("메시지 내용은 필수 입력항목입니다.", "MSG"), Forms.DialogForm.DialogType.OK); 
                        //    return;
                        //}

                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM5200_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_ALARMID", DBHelper.nvlString(drRow["ALARMID"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM5200_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MES_TITLE", DBHelper.nvlString(drRow["MES_TITLE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MES_CONTENTS", DBHelper.nvlString(drRow["MES_CONTENTS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_RECDATE", DBHelper.nvlString(dtNow.ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", DBHelper.nvlString(sUserID), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AD_MAKEDATE", DBHelper.nvlDateTime(dtNow), DbType.DateTime, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            /*
                            helper.ExecuteNoneQuery("USP_BM5200_U1"
                                                     , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_ALARMID", DBHelper.nvlInt(drRow["ALARMID"]), DbType.Int32,   ParameterDirection.Input)                                                   
                                                   , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_WORKCENTERCODE", DBHelper.nvlString(drRow["WORKCENTERCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MES_TITLE", DBHelper.nvlString(drRow["MES_TITLE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MES_CONTENTS", DBHelper.nvlString(drRow["MES_CONTENTS"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_RECDATE", DBHelper.nvlString(dtNow.ToString("yyyy-MM-dd")), DbType.String, ParameterDirection.Input));
                                                    */
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
        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {
            base.DoImportExcel();
            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >

        #endregion
    }
}