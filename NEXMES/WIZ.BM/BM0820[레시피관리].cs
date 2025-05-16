#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0820
//   Form Name    : 공정BOM 마스터
//   Name Space   : WIZ.BM
//   Created Date : 2018-01-05
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : BOM 관련 기준정보 관리
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
using System.IO;
using System.Diagnostics;

using WIZ.PopUp;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Configuration;
#endregion

namespace WIZ.BM
{
    public partial class BM0820 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성


        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0820()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0820_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",     "품명",         true, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Center,   true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산계획", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "생산지시", true, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTBASEQTY", "기초수량", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "현재수량", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, "#,###,###");
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "생산일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

                //_GridUtil.InitColumnUltraGrid(grid1, "WHCODE",       "창고명",       true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center,   true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "INWHDATE",     "창고입고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "OUTWHDATE",    "창고출고일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "INSPYESNO",    "제품검사여부", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center,   true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "INSPDATE",     "제품검사일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT",   "제품검사결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "LOTCLOSEDATE", "LOT종료일시",  true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", true, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                //그리드 객체 생성
                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPINFO", "공정정보", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정코드", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERINFO", "작업장정보", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANNO", "생산계획", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMINFO", "품목정보", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "RECDATE", "일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "WORKSTATDATE", "생산시작", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "WORKENDDATE", "생산종료", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid2, "PRODDATE", "생산일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.SetInitUltraGridBind(grid2);

                _GridUtil.InitializeGrid(grid3, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 200, HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "DRAWID", "도면코드", false, GridColDataType_emu.VarChar, 120, 200, HAlign.Center, true, false, null, null, null, null, null);
                //_GridUtil.InitColumnUltraGrid(grid3, "REMARK", "비고", false, GridColDataType_emu.VarChar, 80, 180, HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid3, "FILE", "파일", false, GridColDataType_emu.Image, 150, 100, HAlign.Center, false, true, null, null, null, null, null);
                _GridUtil.SetInitUltraGridBind(grid3);

                #endregion

                #region COMBOBOX SETTING

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-47);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(7);
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0130_CODE(""); //단위              
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "Y" });

                #endregion

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
            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();

                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sSDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim().ToUpper());

                rtnDtTemp = helper.FillTable("USP_PP0210_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_SDATE", sSDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_EDATE", sEDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            //try
            //{
            //    base.DoNew();


            //    if (grid1.ActiveRow.Cells["ITEMCODE"].ToString().Equals("") == false)
            //    {
            //        this.grid2.InsertRow();

            //        OpenFileDialog openFileDialog = new OpenFileDialog();
            //        openFileDialog.InitialDirectory = Application.StartupPath;
            //        openFileDialog.Filter = "PDF|*.PDF";

            //        if (openFileDialog.ShowDialog() != DialogResult.OK)
            //        {
            //            return;
            //        }

            //        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
            //        FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Read);
            //        byte[] array = new byte[fileStream.Length];
            //        fileStream.Read(array, 0, Convert.ToInt32(fileStream.Length));
            //        this.grid2.ActiveRow.Cells["FILE"].Value = array;
            //        fileStream.Close();

            //        //사업장과 사용여부는 행 추가시 기본으로 세팅
            //        this.grid2.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
            //        this.grid2.ActiveRow.Cells["ITEMCODE"].Value = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
            //        this.grid2.ActiveRow.Cells["DRAWID"].Value = DateTime.Now.ToString("yyyyMMddhhmmss");

            //    }


            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            //DBHelper helper = new DBHelper("", true);
            //helper.ExecuteNoneQuery("USP_BM0800_D1"
            //            , CommandType.StoredProcedure
            //            , helper.CreateParameter("AS_PLANTCODE", this.grid2.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input)
            //            , helper.CreateParameter("AS_DRAWID", this.grid2.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input)
            //            , helper.CreateParameter("AS_ITEMCODE", this.grid2.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input));

            //base.DoDelete();

            //this.grid2.DeleteRow(); //신규로 추가된 행을 제거하는 용도로 사용

            //this.ClosePrgFormNew();
            //helper.Commit();
            //helper.Close();


            //base.DoDelete();
            //DataRow dr;
            //DBHelper helper = new DBHelper("", true);

            //try
            //{
            //    if (grid2.IsActivate)
            //    {
            //        dr = (grid2.ActiveRow.ListObject as DataRowView).Row;

            //        if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Deleted)
            //        {
            //            grid2.ActiveRow.Delete();
            //        }
            //        else
            //        {
            //            /*helper.ExecuteNoneQuery("USP_BM0800_D1"
            //                                    , CommandType.StoredProcedure
            //                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(dr["PLANTCODE"]), DbType.String, ParameterDirection.Input)
            //                                    , helper.CreateParameter("AS_DRAWID", DBHelper.nvlString(dr["DRAWID"]), DbType.String, ParameterDirection.Input)
            //                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(dr["ITEMCODE"]), DbType.String, ParameterDirection.Input));

            //            if (helper.RSCODE == "S")
            //            {
            //                this.ClosePrgFormNew();
            //                grid2.ActiveRow.Delete();
            //                //helper.Commit();

            //            }
            //            else if (helper.RSCODE == "E")
            //            {
            //                this.ClosePrgFormNew();
            //                helper.Rollback();
            //                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
            //            }*/
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    CancelProcess = true;
            //    helper.Rollback();
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            //rtnDtTemp = grid2.chkChange();

            //DateTime dtNow = DateTime.Now;

            //if (rtnDtTemp == null)
            //{
            //    return;
            //}

            //DBHelper helper = new DBHelper("", true);

            //try
            //{
            //    if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
            //    {
            //        CancelProcess = true;
            //        return;
            //    }

            //    base.DoSave();

            //    foreach (DataRow drRow in rtnDtTemp.Rows)
            //    {
            //        //필수입력항목이 입력되었는지 확인
            //        /*if (drRow.RowState != DataRowState.Deleted)
            //        {
            //            #region [ validation 체크 ]
            //            if (DBHelper.nvlString(drRow["VALUETYPE"]) == "")
            //            {
            //                this.ShowDialog(Common.getLangText("검사값구분은 필수항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                return;
            //            }

            //            //검사값구분이 값일경우
            //            if (DBHelper.nvlString(drRow["VALUETYPE"]) != "J")
            //            {
            //                if (DBHelper.nvlString(drRow["SPECTYPE"]) == "")
            //                {
            //                    this.ShowDialog(Common.getLangText("관리구분은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                    return;
            //                }

            //                if (DBHelper.nvlString(drRow["UNITCODE"]) == "")
            //                {
            //                    this.ShowDialog(Common.getLangText("단위는 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                    return;
            //                }

            //                if (DBHelper.nvlString(drRow["SPECNOL"]) == "")
            //                {
            //                    this.ShowDialog(Common.getLangText("기준값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                    return;
            //                }

            //                //하한관리가 아니면 상한값은 필수입력
            //                if (DBHelper.nvlString(drRow["SPECUSL"]) == "" && DBHelper.nvlString(drRow["SPECTYPE"]) != "L")
            //                {
            //                    this.ShowDialog(Common.getLangText("상한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                    return;
            //                }

            //                //상한관리가 아니면 하한값은 필수입력
            //                if (DBHelper.nvlString(drRow["SPECLSL"]) == "" && DBHelper.nvlString(drRow["SPECTYPE"]) != "U")
            //                {
            //                    this.ShowDialog(Common.getLangText("하한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                    return;
            //                }

            //                if (DBHelper.nvlString(drRow["SPECTYPE"]) != "L" && Convert.ToDouble(drRow["SPECUSL"]) < Convert.ToDouble(drRow["SPECNOL"]))
            //                {
            //                    this.ShowDialog(Common.getLangText("상한값은 기준값보다 작을수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                    return;
            //                }

            //                if (DBHelper.nvlString(drRow["SPECTYPE"]) != "U" && Convert.ToDouble(drRow["SPECLSL"]) > Convert.ToDouble(drRow["SPECNOL"]))
            //                {
            //                    this.ShowDialog(Common.getLangText("하한값은 기준값보다 클수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                drRow["SPECTYPE"] = "";
            //                drRow["UNITCODE"] = "";
            //                drRow["SPECNOL"] = DBNull.Value;
            //                drRow["SPECUSL"] = DBNull.Value;
            //                drRow["SPECLSL"] = DBNull.Value;
            //            }

            //            #endregion
            //    }*/
            //        switch (drRow.RowState)
            //        {
            //            case DataRowState.Deleted:
            //                #region 삭제 < BM은 삭제기능 비 활성화 >
            //                drRow.RejectChanges();
            //                helper.ExecuteNoneQuery("USP_BM0800_D1"
            //                                        , CommandType.StoredProcedure
            //                                        , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
            //                                        , helper.CreateParameter("AS_DRAWID", DBHelper.nvlString(drRow["DRAWID"]), DbType.String, ParameterDirection.Input)
            //                                        , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input));
            //                #endregion
            //                break;
            //            case DataRowState.Added:
            //                #region 추가                            
            //                helper.ExecuteNoneQuery("USP_BM0800_I1"
            //                                        , CommandType.StoredProcedure
            //                                        , helper.CreateParameter("AS_PLANTCODE", DbType.String, DBHelper.nvlString(drRow["PLANTCODE"]))
            //                                        , helper.CreateParameter("AS_DRAWID", DbType.String, DBHelper.nvlString(drRow["DRAWID"]))
            //                                        , helper.CreateParameter("AS_ITEMCODE", DbType.String, DBHelper.nvlString(drRow["ITEMCODE"]))
            //                                        , helper.CreateParameter("AS_FILE", DbType.Binary, drRow["FILE"])
            //                                        , helper.CreateParameter("AS_REMARK", DbType.String, DBHelper.nvlString(drRow["REMARK"]))
            //                                        , helper.CreateParameter("AS_MAKER", DbType.String, DBHelper.nvlString(sUserID)));
            //                #endregion
            //                break;
            //            case DataRowState.Modified:
            //                #region 수정
            //                helper.ExecuteNoneQuery("USP_BM0800_U1"
            //                                         , CommandType.StoredProcedure
            //                                        , helper.CreateParameter("AS_PLANTCODE", DbType.String, DBHelper.nvlString(drRow["PLANTCODE"]))
            //                                        , helper.CreateParameter("AS_DRAWID", DbType.String, DBHelper.nvlString(drRow["DRAWID"]))
            //                                        , helper.CreateParameter("AS_ITEMCODE", DbType.String, DBHelper.nvlString(drRow["ITEMCODE"]))
            //                                        , helper.CreateParameter("AS_REMARK", DbType.String, DBHelper.nvlString(drRow["REMARK"]))
            //                                        , helper.CreateParameter("AS_EDITOR", DbType.String, DBHelper.nvlString(sUserID)));
            //                #endregion
            //                break;
            //        }
            //    }
            //    if (helper.RSCODE == "S")
            //    {
            //        this.ClosePrgFormNew();
            //        helper.Commit();
            //        DoInquire(); //성공적으로 수행되었을 경우에만 조회
            //    }
            //    else if (helper.RSCODE == "E")
            //    {
            //        this.ClosePrgFormNew();
            //        helper.Rollback();
            //        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CancelProcess = true;
            //    helper.Rollback();
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();
            //}

            /*DateTime dtNow = DateTime.Now;
            DBHelper helper = new DBHelper("", true);            

            string sOPCODE = string.Empty;
            string sITEMCODE = string.Empty;

            DataTable rtnDtTemp2 = new DataTable();
                       
            rtnDtTemp = grid2.chkChange();

            sITEMCODE = grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();

            try
            {
                //if (rtnDtTemp != null )
                //{
                //    if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                //    {
                //        CancelProcess = true;
                //        return;
                //    }
                //}               

                base.DoSave();

                if (rtnDtTemp != null)
                {

                    foreach (DataRow drRow in rtnDtTemp.Rows)
                    {
                        switch (drRow.RowState)
                        {
                            case DataRowState.Deleted:
                                #region 삭제 < BM은 삭제기능 비 활성화 >
                                //drRow.RejectChanges();
                                helper.ExecuteNoneQuery("USP_BM0800_D1"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", DbType.String, grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString())
                                                        , helper.CreateParameter("AS_DRAWID", DbType.String, grid2.ActiveRow.Cells["DRAWID"].Value.ToString())
                                                        , helper.CreateParameter("AS_ITEMCODE", DbType.String, grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString()));
                                #endregion
                                break;
                            case DataRowState.Added:
                                #region 추가                            
                                helper.ExecuteNoneQuery("USP_BM0800_I1"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE",DbType.String , DBHelper.nvlString(drRow["PLANTCODE"]))
                                                        , helper.CreateParameter("AS_DRAWID",   DbType.String , DBHelper.nvlString(drRow["DRAWID"]))
                                                        , helper.CreateParameter("AS_ITEMCODE", DbType.String , DBHelper.nvlString(drRow["ITEMCODE"]))
                                                        , helper.CreateParameter("AS_FILE",     DbType.Binary , drRow["FILE"])
                                                        , helper.CreateParameter("AS_REMARK",   DbType.String , DBHelper.nvlString(drRow["REMARK"]))                                                        
                                                        , helper.CreateParameter("AS_MAKER",    DbType.String , DBHelper.nvlString(sUserID)));
                                #endregion
                                break;
                            case DataRowState.Modified:
                                #region 수정
                                helper.ExecuteNoneQuery("USP_BM0800_U1"
                                                         , CommandType.StoredProcedure
                                                        , helper.CreateParameter("AS_PLANTCODE", DbType.String, DBHelper.nvlString(drRow["PLANTCODE"]))
                                                        , helper.CreateParameter("AS_DRAWID", DbType.String, DBHelper.nvlString(drRow["DRAWID"]))
                                                        , helper.CreateParameter("AS_ITEMCODE", DbType.String, DBHelper.nvlString(drRow["ITEMCODE"]))
                                                        , helper.CreateParameter("AS_REMARK", DbType.String, DBHelper.nvlString(drRow["REMARK"]))
                                                        , helper.CreateParameter("AS_EDITOR", DbType.String, DBHelper.nvlString(sUserID)));
                                #endregion
                                break;
                        }
                    }
                    if (helper.RSCODE == "S")
                    {
                        this.ClosePrgFormNew();
                        //this.grid2.SetAcceptChanges();
                        helper.Commit();
                        DoInquire();

                    }
                    else if (helper.RSCODE == "E")
                    {
                        this.ClosePrgFormNew();
                        helper.Rollback();
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
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
            }*/
        }
        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {

        }


        #region < EVENT AREA >

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            if (e.Cell.Row.Index < 0)
                return;

            DBHelper helper = new DBHelper(false);

            if (grid1.Rows.Count <= 0)
                return;

            try
            {
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = DBHelper.nvlString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);              //공장

                string sLotNo = DBHelper.nvlString(this.grid1.ActiveRow.Cells["LOTNO"].Value);

                //string sPlanNo = DBHelper.nvlString(cbo_PLANTCODE_H.Text);

                if (sPlantCode == string.Empty || sLotNo == string.Empty)
                    return;

                rtnDtTemp = helper.FillTable("USP_BM0820_S1", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_LOTNO", this.grid1.ActiveRow.Cells["LOTNO"].Value.ToString(), DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("PC_CODE", "S1", DbType.String, ParameterDirection.Input));

                grid2.DataSource = rtnDtTemp;
                grid2.DataBinds();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }

        #endregion



        public void InitateDirectory(string path)
        {
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (System.IO.FileInfo file in dir.GetFiles("*.*", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    file.Delete();
                    System.Threading.Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = this.grid2.ActiveRow.Cells["ITEMINFO"].Value.ToString();
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);

            try
            {
                if (!(Convert.ToString(grid2.ActiveRow.Cells["ITEMINFO"].Value) == string.Empty))
                {
                    rtnDtTemp = helper.FillTable("USP_BM0820_S2", CommandType.StoredProcedure
                                 , helper.CreateParameter("AS_PLANTCODE", DbType.String, sPlantCode)
                                 , helper.CreateParameter("AS_ITEMCODE", DbType.String, grid2.ActiveRow.Cells["ITEMINFO"].Value.ToString())
                                 , helper.CreateParameter("AS_OPCODE", DbType.String, grid2.ActiveRow.Cells["OPCODE"].Value.ToString()));
                   
                    
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        _GridUtil.Grid_Clear(grid3);
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBind();
                        grid3.GetRow();
                    }

                    else
                    {
                        this.grid3.Selected.Rows.AddRange((UltraGridRow[])this.grid3.Rows.All);
                        this.grid3.DeleteSelectedRows(false);
                    }
                }

                //axPDF.LoadFile("Empty");

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

        //private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        //{
        //    if (e.Cell.Row.Index < 0)
        //        return;

        //    DBHelper helper = new DBHelper(false);

        //    if (grid2.Rows.Count <= 0)
        //        return;

        //    try
        //    {
        //        _GridUtil.Grid_Clear(grid3);

        //        string sPlantCode = DBHelper.nvlString(this.grid2.ActiveRow.Cells["PLANTCODE"].Value);              //공장

        //        string sLotNo = DBHelper.nvlString(this.grid2.ActiveRow.Cells["LOTNO"].Value);

        //        //string sPlanNo = DBHelper.nvlString(cbo_PLANTCODE_H.Text);

        //        if (sPlantCode == string.Empty || sLotNo == string.Empty)
        //            return;


        //        rtnDtTemp = helper.FillTable("USP_PP0225_S1", CommandType.StoredProcedure
        //                                     , helper.CreateParameter("AS_PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
        //                                     , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

        //        if (rtnDtTemp.Rows.Count > 0)
        //        {
        //            grid3.DataSource = rtnDtTemp;
        //            grid3.DataBinds();

        //            //조회시 입력한 LOTNO와 GRID의 LOTNO가 같으면 노란색으로 표시
        //            //for (int i = 0; i < this.grid1.Rows.Count; i++)
        //            //{
        //            //    if (Convert.ToString(grid1.Rows[i].Cells["LOTNO"].Value.ToString()) == sLotNo)
        //            //    {
        //            //        grid1.Rows[i].Appearance.BackColor = Color.FromArgb(254, 255, 100);
        //            //    }
        //            //}

        //            this.grid3.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
        //            this.grid3.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
        //            //this.grid3.DisplayLayout.Bands[0].Columns["RECDATE"].MergedCellStyle = MergedCellStyle.Always;
        //            //this.grid3.DisplayLayout.Bands[0].Columns["MAKEDATE"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;
        //            //this.grid1.DisplayLayout.Bands[0].Columns["LOTQTY"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["UNITCODE"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["INITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["INITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["INLOTNO"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["INUNITCODE"].MergedCellStyle = MergedCellStyle.Always;
        //            this.grid3.DisplayLayout.Bands[0].Columns["LVL"].MergedCellStyle = MergedCellStyle.Always;
        //            //this.grid1.DisplayLayout.Bands[0].Columns["INLOTQTY"].MergedCellStyle = MergedCellStyle.Always;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ClosePrgFormNew();
        //        this.ShowDialog(ex.Message.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        helper.Close();
        //        ClosePrgFormNew();
        //    }
        //}

        private void grid3_ClickCell(object sender, ClickCellEventArgs e)
        {
            try
            {
                //this.InitateDirectory(Application.StartupPath + @"\DRAW");

                byte[] fileimage = new byte[0];
                fileimage = (byte[])e.Cell.Row.Cells["FILE"].Value;

                //string fileName = Application.StartupPath + @"\DRAW\temp.pdf";

                //GC.Collect();
                //GC.WaitForPendingFinalizers();

                //if (File.Exists(fileName))
                //{
                //    File.Delete(fileName);
                //}

                //FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

                //fs.Write(fileimage, 0, fileimage.Length);
                //fs.Close();

                System.IO.MemoryStream ms = new System.IO.MemoryStream(fileimage);

                pdfViewer1.LoadFromStream(ms);
                //pdfViewer1.LoadFromStream();
                //axPDF.LoadFile("Empty");
                //axPDF.LoadFile(fileName);
                //axPDF.setPageMode("none");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    #endregion
}
