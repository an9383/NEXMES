#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP9995
//   Form Name    : 생산계획편성
//   Name Space   : WIZ.AP
//   Created Date : 2020-09-08
//   Made By      : inho.hwang
//   Description  :
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;

#endregion

namespace WIZ.AP
{
    public partial class AP9995 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        private bool bNew = false;

        UltraGridUtil _GridUtil = new UltraGridUtil();

        BizTextBoxManager btbManager = new BizTextBoxManager();


        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();
        DataTable rtnDtTemp2 = new DataTable();
        DataTable rtnDtTemp3 = new DataTable();
        DataTable rtnDtTemp4 = new DataTable();

        DataTable dtGrid;

        #endregion

        #region < CONSTRUCTOR >
        public AP9995()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP9995_Load(object sender, EventArgs e)
        {
            GridInitialize();

        }


        private void GridInitialize()
        {
            try
            {
                //grid1
                _GridUtil.InitializeGrid(this.grid1, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "SEQ", "순번", true, GridColDataType_emu.VarChar, 50, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "제품코드", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "제품명", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ROWSTATUS", "ROWSTATUS", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, false, false);

                _GridUtil.SetInitUltraGridBind(grid1);


                //grid4
                _GridUtil.InitializeGrid(this.grid2, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "TYPEFLAG", "긴급여부", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "DISPLAYFLAG", "표시여부", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CLOSEFLAG", "완료여부", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CONTRACTDATE", "계약일", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "DELIVERYDATE", "납품기한", true, GridColDataType_emu.VarChar, 120, 0, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SITE", "현장명", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME", "발주처", true, GridColDataType_emu.VarChar, 200, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMSEQ", "SEQ", true, GridColDataType_emu.VarChar, 60, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMQTY", "수량(M2)", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCUST", "단가", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                //_GridUtil.InitColumnUltraGrid(grid2, "AMOUNT", "금액", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "AGENCY", "대리점", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", true, GridColDataType_emu.VarChar, 100, 0, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid2, "ROWSTATUS", "ROWSTATUS", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, false, false);

                grid2.Columns["ITEMQTY"].Format = "#,##0";
                grid2.Columns["UNITCUST"].Format = "#,##0";
                //grid2.Columns["AMOUNT"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid2);

                rtnDtTemp2 = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부        

                WIZ.Common.FillComboboxMaster(this.cboTYPEFLAG, rtnDtTemp2, rtnDtTemp2.Columns["CODE_ID"].ColumnName, rtnDtTemp2.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.Common.FillComboboxMaster(this.cboDISPLAYFLAG, rtnDtTemp2, rtnDtTemp2.Columns["CODE_ID"].ColumnName, rtnDtTemp2.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.Common.FillComboboxMaster(this.cboCLOSEFLAG, rtnDtTemp2, rtnDtTemp2.Columns["CODE_ID"].ColumnName, rtnDtTemp2.Columns["CODE_NAME"].ColumnName, null, null);

                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "TYPEFLAG", rtnDtTemp2, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "DISPLAYFLAG", rtnDtTemp2, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "CLOSEFLAG", rtnDtTemp2, "CODE_ID", "CODE_NAME");
                #region --- Combobox & Popup Setting ---

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;


                Common.DoInit(splitContainer2.Panel1);
                Common.DoInit(splitContainer3.Panel1);

                // 그리드와 컨트롤을 동기화 시킨다.
                Control.GridExtendUtil.SetLink(splitContainer2.Panel1, grid1, Grid_Search2);
                Control.GridExtendUtil.SetLink(splitContainer3.Panel1, grid2, null, "ROWSTATUS");
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion




        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            bNew = false;


            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            Common.DoInit(this.splitContainer2.Panel1);
            Common.DoInit(this.splitContainer3.Panel1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {

                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);


                dtGrid = helper.FillTable("USP_AP9995_S1", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_ITEMCODE", "", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input));


                grid1.DataSource = dtGrid;
                grid1.DataBinds(dtGrid);


                foreach (UltraGridRow ugr in grid1.Rows)
                {
                    ugr.Activation = Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                ClosePrgFormNew();

                helper.Close();
            }
        }

        public override void DoNew()
        {
            try
            {
                base.DoNew();

                this.grid2.InsertRow();

                grid2.ActiveRow.Cells["TYPEFLAG"].Value = "N";
                grid2.ActiveRow.Cells["DISPLAYFLAG"].Value = "Y";
                grid2.ActiveRow.Cells["CLOSEFLAG"].Value = "N";
                grid2.ActiveRow.Cells["ROWSTATUS"].Value = "U";
                grid2.ActiveRow.Activation = Activation.NoEdit;

                foreach (UltraGridRow ugr in grid2.Rows)
                {
                    ugr.Activation = Activation.NoEdit;
                }


                Common.DoInit(splitContainer3.Panel1);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

        }

        public override void DoDelete()
        {
            base.DoDelete();

            if (this.grid2.Focused)
            {
                grid2.ActiveRow.Cells["ROWSTATUS"].Value = "D";
                this.grid2.DeleteRow();
            }

        }

        public override void DoSave()
        {

            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                if (SEQ_PRO.Text.Trim() == "")
                {
                    this.ShowDialog("왼쪽 그리드를 선택해주세요.", Forms.DialogForm.DialogType.OK);
                    return;
                }
                if (ITEMCODE_PRO.Text.Trim() == "")
                {
                    this.ShowDialog("왼쪽 그리드를 선택해주세요.", Forms.DialogForm.DialogType.OK);
                    return;
                }



                foreach (UltraGridRow drRow in grid2.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    string sRowStatus = CModule.ToString(drRow.Cells["ROWSTATUS"].Value);

                    if (sRowStatus != "")
                    {
                        #region [ validation 체크 ]
                        #endregion
                    }
                    switch (sRowStatus)
                    {
                        case "D":
                            #region 

                            helper.ExecuteNoneQuery("USP_AP9995_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PCODE", "D1", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEQ", DBHelper.nvlString(SEQ_PRO.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(ITEMCODE_PRO.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMSEQ", DBHelper.nvlString(drRow.Cells["ITEMSEQ"].Value), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case "A":
                        case "U":

                            #region 수정/추가
                            helper.ExecuteNoneQuery("USP_AP9995_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PCODE", "U1", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SEQ", DBHelper.nvlString(SEQ_PRO.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(ITEMCODE_PRO.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMNAME", DBHelper.nvlString(ITEMNAME__PRO.Text.Trim()), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_TYPEFLAG", DBHelper.nvlString(drRow.Cells["TYPEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DISPLAYFLAG", DBHelper.nvlString(drRow.Cells["DISPLAYFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CLOSEFLAG", DBHelper.nvlString(drRow.Cells["CLOSEFLAG"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CONTRACTDATE", DBHelper.nvlString(drRow.Cells["CONTRACTDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DELIVERYDATE", DBHelper.nvlString(drRow.Cells["DELIVERYDATE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_SITE", DBHelper.nvlString(drRow.Cells["SITE"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CUSTNAME", DBHelper.nvlString(drRow.Cells["CUSTNAME"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMSEQ", DBHelper.nvlString(drRow.Cells["ITEMSEQ"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMQTY", DBHelper.nvlString(drRow.Cells["ITEMQTY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_UNITCUST", DBHelper.nvlString(drRow.Cells["UNITCUST"].Value), DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("AS_AMOUNT", DBHelper.nvlString(drRow.Cells["AMOUNT"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_AGENCY", DBHelper.nvlString(drRow.Cells["AGENCY"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow.Cells["REMARK"].Value), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
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
        #endregion

        #region < EVENT AREA >
        private void Grid_Search2()
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화

            try
            {
                string sSeq = DBHelper.nvlString(grid1.ActiveRow.Cells["SEQ"].Value);
                string sItemcode = DBHelper.nvlString(grid1.ActiveRow.Cells["ITEMCODE"].Value);


                rtnDtTemp = helper.FillTable("USP_AP9995_S1", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SEQ", sSeq, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemcode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_SDATE", "", DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_EDATE", "", DbType.String, ParameterDirection.Input));


                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds(rtnDtTemp);

                foreach (UltraGridRow ugr in grid2.Rows)
                {
                    ugr.Activation = Activation.NoEdit;
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



        #endregion

        #region < METHOD AREA >

        #endregion



    }
}
