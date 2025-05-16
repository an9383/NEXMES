#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0800
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
    public partial class BM0800 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); 
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성


        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0800()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0800_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //grid1 품목 (grid1는 좌측 상단 두번쨰 GRID, GRID를 추가시 좌측상단부터 GRID 채번) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "사업장", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",    "품목",   true, GridColDataType_emu.VarChar, 150, 200, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",    "품명",   true, GridColDataType_emu.VarChar, 260, 300, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",    "단위",   true, GridColDataType_emu.VarChar, 40, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST",    "단가",   true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, false, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 80, 200, HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "DRAWID", "도면코드", false, GridColDataType_emu.VarChar, 120, 200, HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", false, GridColDataType_emu.VarChar, 100, 180, HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목코드", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "FILE", "파일", false, GridColDataType_emu.Image, 150, 100, HAlign.Left, false, true, null, null, null, null, null);
                _GridUtil.SetInitUltraGridBind(grid2);
                
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                
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
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);
            string sTabIdx = string.Empty;
            

            try
            {
                //grid1 품목 조회
                try
                {

                    rtnDtTemp = helper.FillTable("USP_BM0800_S1", CommandType.StoredProcedure
                                                                , helper.CreateParameter("AS_PLANTCODE", DbType.String , sPlantCode)
                                                                , helper.CreateParameter("AS_ITEMCODE",  DbType.String , sItemCode )
                                                                , helper.CreateParameter("AS_USEFLAG",   DbType.String ,sUseFlag ));

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
                    this.ClosePrgFormNew(); // GRID가 2개이므로 마지막으로 바인딩 되는 GRID 종료시 PrgForm Close
                    helper.Close();
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


                if(grid1.ActiveRow.Cells["ITEMCODE"].ToString().Equals("") == false)
                {
                    this.grid2.InsertRow();

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = Application.StartupPath;
                    openFileDialog.Filter = "PDF|*.PDF";

                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Read);
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, Convert.ToInt32(fileStream.Length));
                    this.grid2.ActiveRow.Cells["FILE"].Value = array;
                    fileStream.Close();

                    //사업장과 사용여부는 행 추가시 기본으로 세팅
                    this.grid2.ActiveRow.Cells["PLANTCODE"].Value = WIZ.LoginInfo.PlantCode;
                    this.grid2.ActiveRow.Cells["ITEMCODE"].Value = grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                    this.grid2.ActiveRow.Cells["DRAWID"].Value = DateTime.Now.ToString("yyyyMMddhhmmss");
                }

                
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
            DBHelper helper = new DBHelper("", true);
            helper.ExecuteNoneQuery("USP_BM0800_D1"
                        , CommandType.StoredProcedure
                        , helper.CreateParameter("AS_PLANTCODE", this.grid2.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_DRAWID", this.grid2.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_ITEMCODE", this.grid2.ActiveRow.Cells["PLANTCODE"].Value, DbType.String, ParameterDirection.Input));

            base.DoDelete();

            this.grid2.DeleteRow(); //신규로 추가된 행을 제거하는 용도로 사용

            this.ClosePrgFormNew();
            helper.Commit();
            helper.Close();


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
            rtnDtTemp = grid2.chkChange();

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
                    /*if (drRow.RowState != DataRowState.Deleted)
                    {
                        #region [ validation 체크 ]
                        if (DBHelper.nvlString(drRow["VALUETYPE"]) == "")
                        {
                            this.ShowDialog(Common.getLangText("검사값구분은 필수항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                            return;
                        }

                        //검사값구분이 값일경우
                        if (DBHelper.nvlString(drRow["VALUETYPE"]) != "J")
                        {
                            if (DBHelper.nvlString(drRow["SPECTYPE"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("관리구분은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["UNITCODE"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("단위는 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["SPECNOL"]) == "")
                            {
                                this.ShowDialog(Common.getLangText("기준값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            //하한관리가 아니면 상한값은 필수입력
                            if (DBHelper.nvlString(drRow["SPECUSL"]) == "" && DBHelper.nvlString(drRow["SPECTYPE"]) != "L")
                            {
                                this.ShowDialog(Common.getLangText("상한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            //상한관리가 아니면 하한값은 필수입력
                            if (DBHelper.nvlString(drRow["SPECLSL"]) == "" && DBHelper.nvlString(drRow["SPECTYPE"]) != "U")
                            {
                                this.ShowDialog(Common.getLangText("하한값은 필수 입력 항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["SPECTYPE"]) != "L" && Convert.ToDouble(drRow["SPECUSL"]) < Convert.ToDouble(drRow["SPECNOL"]))
                            {
                                this.ShowDialog(Common.getLangText("상한값은 기준값보다 작을수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }

                            if (DBHelper.nvlString(drRow["SPECTYPE"]) != "U" && Convert.ToDouble(drRow["SPECLSL"]) > Convert.ToDouble(drRow["SPECNOL"]))
                            {
                                this.ShowDialog(Common.getLangText("하한값은 기준값보다 클수 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                                return;
                            }
                        }
                        else
                        {
                            drRow["SPECTYPE"] = "";
                            drRow["UNITCODE"] = "";
                            drRow["SPECNOL"] = DBNull.Value;
                            drRow["SPECUSL"] = DBNull.Value;
                            drRow["SPECLSL"] = DBNull.Value;
                        }

                        #endregion
                }*/
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 < BM은 삭제기능 비 활성화 >
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM0800_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DRAWID", DBHelper.nvlString(drRow["DRAWID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가                            
                            helper.ExecuteNoneQuery("USP_BM0800_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", DbType.String, DBHelper.nvlString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("AS_DRAWID", DbType.String, DBHelper.nvlString(drRow["DRAWID"]))
                                                    , helper.CreateParameter("AS_ITEMCODE", DbType.String, DBHelper.nvlString(drRow["ITEMCODE"]))
                                                    , helper.CreateParameter("AS_FILE", DbType.Binary, drRow["FILE"])
                                                    , helper.CreateParameter("AS_REMARK", DbType.String, DBHelper.nvlString(drRow["REMARK"]))
                                                    , helper.CreateParameter("AS_MAKER", DbType.String, DBHelper.nvlString(sUserID)));
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

        private void btn_ROWDELETE_B_Click(object sender, EventArgs e)
        {
            DoDelete();
        }

        #region < EVENT AREA >

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = this.grid1.ActiveRow.Cells["ITEMCODE"].Value.ToString();
            string sUseFlag = DBHelper.nvlString(cbo_USEFLAG_H.Value);


            //grid2 공정 조회
            try
            {
                if (!(Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value) == string.Empty))
                {
                    rtnDtTemp = helper.FillTable("USP_BM0800_S2", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", DbType.String, sPlantCode)
                                                            , helper.CreateParameter("AS_ITEMCODE", DbType.String, sItemCode));


                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        _GridUtil.Grid_Clear(grid2);
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBind();
                        grid2.GetRow();

                    }

                    else
                    {
                        this.grid2.Selected.Rows.AddRange((UltraGridRow[])this.grid2.Rows.All);
                        this.grid2.DeleteSelectedRows(false);
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
                this.ClosePrgFormNew(); // GRID가 2개이므로 마지막으로 바인딩 되는 GRID 종료시 PrgForm Close
                helper.Close();
            }
        }

        #endregion


        /*private byte[] GetImage(string sPlantCode, string sItemCode, string sDrawId)
        {
            byte[] bImage = null;

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0800_S3", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_DRAWID", sDrawId, DbType.String, ParameterDirection.Input));

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();

            }

            if (rtnDtTemp.Rows.Count > 0 && rtnDtTemp.Rows[0]["FILE"] != DBNull.Value)
            {
                bImage = (byte[])rtnDtTemp.Rows[0]["FILE"];
            }
            else if (grid1.ActiveRow.Cells["FILE"].Value != DBNull.Value)
            {
                bImage = (byte[])grid1.ActiveRow.Cells["FILE"].Value;
            }
            else
            {
                bImage = ConvertImageToByteArray(Properties.Resources.Default_Image);
            }

            return bImage;
        }

        public byte[] ConvertImageToByteArray(Image theImage)
        {
            MemoryStream ms = new MemoryStream();
            byte[] pByte;

            theImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            pByte = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(pByte, 0, (int)ms.Length);
            ms.Close();
            return pByte;
        }

        public Image ConvertByteArrayToImage(byte[] pByte)
        {
            MemoryStream ms = new MemoryStream();

            Image theImage = null;

            try
            {
                ms.Position = 0;

                ms.Write(pByte, 0, (int)pByte.Length);

                theImage = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return theImage;
        }

        private void DownLoadFile(DataTable dtUpdate, bool[] Chk)
        {
            DataTable dtUpdateFile;

            for (int i = 0; i < dtUpdate.Rows.Count; i++)
            {
                try
                {
                    if (Chk[i] == false) continue;

                    byte[] fileimage = new byte[0];
                    fileimage = (byte[])dtUpdate.Rows[i]["FILE"];

                    FileStream fs = new FileStream(Application.StartupPath + @"\UPDATE\" + dtUpdate.Rows[i]["DRAWID"].ToString() + "_" + dtUpdate.Rows[i]["ITEMCODE"].ToString() ,
                                                   FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(fileimage, 0, fileimage.Length);
                    fs.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }*/

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


        private void grid2_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
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
}
#endregion