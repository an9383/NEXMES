#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM5900
//   Form Name    : 라우터마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-04
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 라우트 정보를 관리                                     
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM5900 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp2 = new DataTable(); // return DataTable 공통
        DataTable rtnDtTemp3 = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM5900()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM5900_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                // GRID1 SHELL MASTER 
                _GridUtil.InitializeGrid(this.grid1, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 70, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTTYPE_CODE", "LOT 설정코드", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTTYPE_NAME", "LOT 설정명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "정보", true, GridColDataType_emu.VarChar, 200, 90, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                // Grid2 SHELL DETAIL
                _GridUtil.InitializeGrid(this.grid2, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 150, 50, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 300, 50, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                _GridUtil.InitializeGrid(this.grid3, true, false, true, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 150, 50, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 300, 50, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid3);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.Common.FillComboboxMaster(this.txt_PLANTCODE, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.Common.FillComboboxMaster(this.cboUseFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, null, null });  // 품목
                #endregion

                Common.DoInit(splitContainer2.Panel1);

                // 그리드와 컨트롤을 동기화 시킨다.
                Control.GridExtendUtil.SetLink(splitContainer2.Panel1, grid1, Grid_Search2);
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
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
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid3); // 조회전 그리드 초기화

            Common.DoInit(this.splitContainer2.Panel1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM5900_I1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Value), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTTYPE_CODE", txtLOTTYPE_CODE.Text.Trim(), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_LOTTYPE_NAME", txtLOTTYPE_NAME.Text.Trim(), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMCODE", txt_ITEMCODE_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ITEMNAME", txt_ITEMNAME_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                                                            );
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);

                foreach (UltraGridRow ugr in grid1.Rows)
                {
                    ugr.Activation = Activation.NoEdit;
                }

                rtnDtTemp = helper.FillTable("USP_BM5900_I1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(cbo_PLANTCODE_H.Value), DbType.String, ParameterDirection.Input)
                                                            );

                grid3.DataSource = rtnDtTemp;
                grid3.DataBinds(rtnDtTemp);

                foreach (UltraGridRow ugr in grid3.Rows)
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

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                string sPlant = DBHelper.nvlString(cbo_PLANTCODE_H.Value);

                sPlant = sPlant == "" ? WIZ.LoginInfo.PlantCode : sPlant;

                base.DoNew();

                this.grid1.InsertRow();

                grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
                grid1.ActiveRow.Cells["PLANTCODE"].Value = sPlant;
                grid1.ActiveRow.Activation = Activation.NoEdit;

                //사업장과 사용여부는 행 추가시 기본으로 세팅
                Common.DoInit(this.splitContainer2.Panel1);
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
            DBHelper helper = new DBHelper("", true);

            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                helper.ExecuteNoneQuery("USP_BM5900_I1"
                                        , CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PCODE", "U1", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(txt_PLANTCODE.Value), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LOTTYPE_CODE", DBHelper.nvlString(txtLOTTYPE_CODE.Text.Trim()), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LOTTYPE_NAME", DBHelper.nvlString(txtLOTTYPE_NAME.Text.Trim()), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(txtRemark.Text.Trim()), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(cboUseFlag.Value), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "E")
                {
                    throw new Exception(helper.RSMSG);
                }

                foreach (UltraGridRow drRow in grid2.Rows)
                {
                    //필수입력항목이 입력되었는지 확인
                    helper.ExecuteNoneQuery("USP_BM5900_I1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_PCODE", "U2", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(txt_PLANTCODE.Value), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_LOTTYPE_CODE", DBHelper.nvlString(txtLOTTYPE_CODE.Text.Trim()), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow.Cells["ITEMCODE"].Value), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }

                if (helper.RSCODE == "S")
                {
                    this.ClosePrgFormNew();
                    helper.Commit();
                    DoInquire(); //성공적으로 수행되었을 경우에만 조회
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
                this.ClosePrgFormNew();
            }
        }
        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {
            base.DoImportExcel();

            //BM5900_EXCEL BM5900_excel = new BM5900_EXCEL();
            //BM5900_excel.ShowDialog();

            base.DoInquire();
        }

        #endregion

        #region < EVENT AREA >
        private void Grid_Search2()
        {
            DBHelper helper = new DBHelper(false);

            // 조회전 데이터 초기화
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);

            try
            {
                if (grid1.ActiveRow != null)
                {
                    string sPlantCode = DBHelper.nvlString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sLotTypeCode = DBHelper.nvlString(grid1.ActiveRow.Cells["LOTTYPE_CODE"].Value);

                    DataSet ds = helper.FillDataSet("USP_BM5900_I1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                , helper.CreateParameter("AS_LOTTYPE_CODE", sLotTypeCode, DbType.String, ParameterDirection.Input)
                                                                );

                    if (ds.Tables.Count >= 1)
                    {
                        grid2.DataSource = ds.Tables[0];
                        grid2.DataBinds(ds.Tables[0]);
                    }

                    if (ds.Tables.Count >= 2)
                    {
                        grid3.DataSource = ds.Tables[1];
                        grid3.DataBinds(ds.Tables[1]);
                    }

                    foreach (UltraGridRow ugr in grid2.Rows)
                    {
                        ugr.Activation = Activation.NoEdit;
                    }

                    foreach (UltraGridRow ugr in grid3.Rows)
                    {
                        ugr.Activation = Activation.NoEdit;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow dr in grid3.Selected.Rows)
            {
                this.grid2.InsertRow();

                this.grid2.ActiveRow.Cells["ITEMCODE"].Value = dr.Cells["ITEMCODE"].Value;
                this.grid2.ActiveRow.Cells["ITEMNAME"].Value = dr.Cells["ITEMNAME"].Value;

                grid2.ActiveRow.Activation = Activation.NoEdit;

                dr.Delete(false);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow dr in grid2.Selected.Rows)
            {
                this.grid3.InsertRow();

                this.grid3.ActiveRow.Cells["ITEMCODE"].Value = dr.Cells["ITEMCODE"].Value;
                this.grid3.ActiveRow.Cells["ITEMNAME"].Value = dr.Cells["ITEMNAME"].Value;

                grid3.ActiveRow.Activation = Activation.NoEdit;

                dr.Delete(false);

            }
        }
        #endregion

        private void txtLOTTYPE_CODE_ValueChanged(object sender, EventArgs e)
        {
            Grid_Search2();
        }
    }
}