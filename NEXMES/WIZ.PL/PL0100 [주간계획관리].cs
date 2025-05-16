#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PL0100
//   Form Name    : 금형수리현황
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형수리현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

using WIZ;
using WIZ.PopUp;

#endregion

namespace WIZ.PL
{
    public partial class PL0100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        string click_Moldcode = "";

        #endregion

        #region < CONSTRUCTOR >
        public PL0100()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PL0100_Load(object sender, EventArgs e)
        {
            #region GRID SETTING  
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PL1_date",        "수주일자",       true, GridColDataType_emu.VarChar,       90, 100, Infragistics.Win.HAlign.Center, true, false); // 고객사       
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Vend",        "고객사"  ,       true, GridColDataType_emu.VarChar,       70, 100, Infragistics.Win.HAlign.Center, true, false); // 등록일자 
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_LotNo",       "수주LOT",        true, GridColDataType_emu.VarChar,      130, 100, Infragistics.Win.HAlign.Center, true, false); // 수주고유번호
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_PartName",    "제품명",         true, GridColDataType_emu.VarChar,      150, 100, Infragistics.Win.HAlign.Left,   true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_OrderQTY",    "발주수량",       true, GridColDataType_emu.VarChar,       70, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Jego",        "재고수량",       true, GridColDataType_emu.VarChar,       70, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Order",       "계획수량",       true, GridColDataType_emu.VarChar,       70, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Residual",    "수주잔량",       true, GridColDataType_emu.VarChar,       70, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid1, "PL1_Chk",         "상태",           true, GridColDataType_emu.VarChar,       40, 100, Infragistics.Win.HAlign.Center, true, false); // 등록상태

            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PL2_State",        "상태",           true, GridColDataType_emu.VarChar,       50, 100, Infragistics.Win.HAlign.Center, true, false); // 등록상태
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_LotNo",        "생산계획일",     true, GridColDataType_emu.VarChar,      130, 100, Infragistics.Win.HAlign.Center, true, false); // 수주고유번호         
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_Gubun",        "구분",           true, GridColDataType_emu.VarChar,       80, 100, Infragistics.Win.HAlign.Center, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_Ho",           "호기",           true, GridColDataType_emu.VarChar,       50, 100, Infragistics.Win.HAlign.Center, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_Ton",          "Ton",            true, GridColDataType_emu.VarChar,       50, 100, Infragistics.Win.HAlign.Center, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_Vend",         "고객사",         true, GridColDataType_emu.VarChar,       70, 100, Infragistics.Win.HAlign.Center, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_PartName",     "제품명",         true, GridColDataType_emu.VarChar,      200, 100, Infragistics.Win.HAlign.Left,   true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_ChaSu",        "차수",           true, GridColDataType_emu.VarChar,       50, 100, Infragistics.Win.HAlign.Center, true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_Material",     "원재료명",       true, GridColDataType_emu.VarChar,      200, 100, Infragistics.Win.HAlign.Left,   true, false); // 사용자 입력
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_OrderQTY",     "수주수량",       true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_JegoQTY",      "재고량",         true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_LackQTY",      "부족량",         true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_WPLQTY",       "주단위계획량",   true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_DPLQTY",       "일생산가능수량", true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_UnitQTY",      "단위소요량",     true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_DIVTQTY",      "투입원재료",     true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            _GridUtil.InitColumnUltraGrid(grid2, "PL2_TIVTQTY",      "총투입재료",     true, GridColDataType_emu.VarChar,      100, 100, Infragistics.Win.HAlign.Right,  true, false); // 발주일
            
            _GridUtil.SetInitUltraGridBind(grid2);


            _GridUtil.InitializeGrid(this.grid4, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid4, "PL4_date",        "수주일자",       true, GridColDataType_emu.VarChar,        90, 100, Infragistics.Win.HAlign.Center, true, false); // 고객사       
            _GridUtil.InitColumnUltraGrid(grid4, "PL4_Vend",        "고객사",         true, GridColDataType_emu.VarChar,        70, 100, Infragistics.Win.HAlign.Center, true, false); // 등록일자 
            _GridUtil.InitColumnUltraGrid(grid4, "PL4_PartName",    "제품명",         true, GridColDataType_emu.VarChar,       170, 100, Infragistics.Win.HAlign.Left,   true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid4, "PL4_FixedDate",   "납기일자",       true, GridColDataType_emu.VarChar,       100, 100, Infragistics.Win.HAlign.Center, true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid4, "PL4_OrderQTY",    "발주수량",       true, GridColDataType_emu.VarChar,        70, 100, Infragistics.Win.HAlign.Right,  true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid4, "PL4_Jego",        "재고수량",       true, GridColDataType_emu.VarChar,        70, 100, Infragistics.Win.HAlign.Right,  true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid4, "PL4_Order",       "계획수량",       true, GridColDataType_emu.VarChar,        70, 100, Infragistics.Win.HAlign.Right,  true, false); // 등록 차수
            _GridUtil.InitColumnUltraGrid(grid4, "PL4_Residual",    "수주잔량",       true, GridColDataType_emu.VarChar,        70, 100, Infragistics.Win.HAlign.Right,  true, false); // 등록 차수


            _GridUtil.SetInitUltraGridBind(grid4);
 


            DTP1.Value = DateTime.Today.AddDays(-30);
            DTP2.Value = DateTime.Today;

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
                rtnDtTemp = helper.FillTable("USP_PL0100_S1", CommandType.StoredProcedure) ;


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
                            helper.ExecuteNoneQuery("USP_PL0100_TEST_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]),   DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MOLDCODE",  DBHelper.nvlString(drRow["MOLDCODE"]),    DbType.String, ParameterDirection.Input)                                                                                                                                                            
                                                    , helper.CreateParameter("AI_MOLDSEQ",   DBHelper.nvlString(drRow["MOLDSEQ"]),     DbType.String, ParameterDirection.Input)                                                                                                                                                            
                                                    , helper.CreateParameter("AS_REPDATE",   DBHelper.nvlString(drRow["REPDATE"]),     DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REPCODE",   DBHelper.nvlString(drRow["REPCODE"]),     DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REPSEQ",    DBHelper.nvlString(drRow["REPSEQ"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKETYPE",  DBHelper.nvlString(drRow["TAKETYPE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKECODE",  DBHelper.nvlString(drRow["TAKECODE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEDESC",  DBHelper.nvlString(drRow["TAKEDESC"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEYN",    DBHelper.nvlString(drRow["TAKEYN"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEGB",    DBHelper.nvlString(drRow["TAKEGB"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEDATE",  DBHelper.nvlString(drRow["TAKEDATE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TAKEUSER",  DBHelper.nvlString(drRow["TAKEUSER"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SHOTINIT",  DBHelper.nvlString(drRow["SHOTINIT"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK",    DBHelper.nvlString(drRow["REMARK"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_EDITOR",    LoginInfo.UserID,                         DbType.String, ParameterDirection.Input));
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
            string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["PL1_LotNo"].Value);
            string sWorkGB = CModule.ToString(grid1.ActiveRow.Cells["PL1_PartName"].Value);




            PL0100_POP mbp = new PL0100_POP(sMoldCode, sWorkGB);
            mbp.Show();
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


            // 그리드2번에 등록된 수주현황 보여주기 
            _GridUtil.Grid_Clear(grid2);
            DBHelper helper = new DBHelper(false);

            if (grid1.ActiveCell == null)
            {
                return;
            }

            try
            {
                //DBHelper helper;
                //helper = new DBHelper(false);

                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sMoldCode = CModule.ToString(grid1.ActiveRow.Cells["OD1_LotNo"].Value);

                if (sMoldCode == "[ NEW LotCode ]")
                {
                    //CLEAN();
                }

                else
                {

                    try
                    {
                        rtnDtTemp = helper.FillTable("USP_PL0100_S2", CommandType.StoredProcedure
                            , helper.CreateParameter("RS_LotNo", sMoldCode, DbType.String, ParameterDirection.Input));


                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid2.DataSource = rtnDtTemp;
                            grid2.DataBinds();
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
            }
            catch (Exception ex)
            {
                //this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }



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

        private void grid1_Click(object sender, EventArgs e)
        {

            // 그리드4번에 등록된 수주현황 상세 보여주기 
            _GridUtil.Grid_Clear(grid4);
            DBHelper helper = new DBHelper(false);

            if (grid1.ActiveCell == null)
            {
                return;
            }

            try
            {
                //DBHelper helper;
                //helper = new DBHelper(false);

                string sPlantCode = CModule.ToString(cbo_PLANTCODE_H.Value);
                string sLotNo = CModule.ToString(grid1.ActiveRow.Cells["PL1_LotNo"].Value);
                string sPartName = CModule.ToString(grid1.ActiveRow.Cells["PL1_PartName"].Value);

                if (sLotNo == "[ NEW LotCode ]")
                {
                    //CLEAN();
                }

                else
                {

                    try
                    {
                        rtnDtTemp = helper.FillTable("USP_PL0100_S4", CommandType.StoredProcedure
                            , helper.CreateParameter("RS_LotNo", sLotNo, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("RS_PartName", sPartName, DbType.String, ParameterDirection.Input));


                        if (rtnDtTemp.Rows.Count > 0)
                        {
                            grid4.DataSource = rtnDtTemp;
                            grid4.DataBinds();
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
            }
            catch (Exception ex)
            {
                //this.ShowDialog(ex.Message, WIZ.Forms.DialogForm.DialogType.OK);
            }






        }
    }
}
