#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PL0000
//   Form Name    : 월간 계획정보
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 월간 계획정보
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.PL
{
    public partial class PL0000 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        string click_Moldcode = "";

        #endregion

        #region < CONSTRUCTOR >
        public PL0000()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PL0000_Load(object sender, EventArgs e)
        {
            #region GRID SETTING  
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLM_MM", "계획연월", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false); // 계획 년월
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_Ho", "호기", true, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Center, true, false); // 생산호기    
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_Ton", "Ton", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false); // 가용톤수 
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_DEL", "삭제", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false); // 삭제
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_Vend", "고객", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false); // 고객사
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_PartName", "제품명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false); // 제품명
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_MDChaSu", "차수", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 생산차수
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_PLQTY", "계획량", true, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false); // 계획량
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_01", "01", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 당월 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_02", "02", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_03", "03", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_04", "04", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_05", "05", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_06", "06", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_07", "07", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_08", "08", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_09", "09", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_10", "10", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_11", "11", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_12", "12", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_13", "13", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_14", "14", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_15", "15", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_16", "16", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_17", "17", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_18", "18", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_19", "19", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_20", "20", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_21", "21", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_22", "22", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_23", "23", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_24", "24", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_25", "25", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_26", "26", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_27", "27", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_28", "28", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_29", "29", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_30", "30", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자
            _GridUtil.InitColumnUltraGrid(grid1, "PLM_31", "31", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false); // 등록 일자

            _GridUtil.SetInitUltraGridBind(grid1);



            #endregion

            #region COMBOBOX SETTING 

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            #endregion

            #region POPUP SETTING

            //BizGridManager bizGridManager = new BizGridManager(grid1);

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {

            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_PL0000", CommandType.StoredProcedure
                    , helper.CreateParameter("RS_Vend", "", DbType.String, ParameterDirection.Input)
                    , helper.CreateParameter("RS_date", DTP1.Value.ToString("yyyyMM"), DbType.String, ParameterDirection.Input));


                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
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

        public override void DoNew()
        {
            try
            {
                base.DoNew();

                this.grid1.InsertRow();

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                this.grid1.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.ActiveRow.Cells["REPSEQ"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
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

                        #endregion
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            //drRow.RejectChanges();

                            //helper.ExecuteNoneQuery("USP_BM0010_D1"
                            //                        , CommandType.StoredProcedure
                            //                        , helper.CreateParameter("AS_PLANTCODE",       DBHelper.nvlString(drRow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                            //                        , helper.CreateParameter("AS_ITEMCODE",        DBHelper.nvlString(drRow["ITEMCODE"]),   DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_PL0000_TEST_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDCODE", DBHelper.nvlString(drRow["MOLDCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AI_MOLDSEQ", DBHelper.nvlString(drRow["MOLDSEQ"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REPDATE", DBHelper.nvlString(drRow["REPDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REPCODE", DBHelper.nvlString(drRow["REPCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REPSEQ", DBHelper.nvlString(drRow["REPSEQ"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKETYPE", DBHelper.nvlString(drRow["TAKETYPE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKECODE", DBHelper.nvlString(drRow["TAKECODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEDESC", DBHelper.nvlString(drRow["TAKEDESC"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEYN", DBHelper.nvlString(drRow["TAKEYN"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEGB", DBHelper.nvlString(drRow["TAKEGB"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEDATE", DBHelper.nvlString(drRow["TAKEDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEUSER", DBHelper.nvlString(drRow["TAKEUSER"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SHOTINIT", DBHelper.nvlString(drRow["SHOTINIT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
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
                base.DoInquire();
            }
        }

        public override void DoImportExcel()
        {
            base.DoImportExcel();
            base.DoInquire();
        }

        #endregion

        #region < METHOD AREA >

        #endregion

        private void gbxBody_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {

        }

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["RP_MDCode"].Value);
            string sWorkGB = CModule.ToString(grid1.ActiveRow.Cells["RP_WorkGB"].Value);

            if (sWorkGB == "완료")
            {

            }
            else
            {

            }
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (click_Moldcode == "")
            {
                this.ShowDialog("타입을 변경 할 금형을 선택해주세요.", WIZ.Forms.DialogForm.DialogType.OK);
            }
            else
            {

            }
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            //click_Moldcode = CModule.ToString(grid1.ActiveRow.Cells["OD2_LotNo"].Value);




        }

        private void ultraButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_MSave_Click(object sender, EventArgs e)
        {

        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

    }
}
