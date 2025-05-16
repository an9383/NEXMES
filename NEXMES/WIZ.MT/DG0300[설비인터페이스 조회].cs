#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DG0300
//   Form Name    : 설비 키컬럼 리스트
//   Name Space   : WIZ.BM
//   Created Date : 2020-09-07
//   Made By      : WIZCORE IFS2팀 차장 신효철
//   Edited Date  : 
//   Edit By      :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;


using WIZ.PopUp;
#endregion

namespace WIZ.MT
{
    public partial class DG0300 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();

        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public DG0300()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void DG0300_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1 작업장
                _GridUtil.InitializeGrid(this.Grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(Grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "EQPID", "설비", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "DATETIME", "등록일시", true, GridColDataType_emu.VarChar, 150, 190, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "JOBID", "LOTNO", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.InitColumnUltraGrid(Grid1, "TYPE_NO", "분류NO", true, GridColDataType_emu.VarChar, 200, 230, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "IDX", "인덱스", true, GridColDataType_emu.VarChar, 60, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "ColName", "컬럼명", true, GridColDataType_emu.VarChar, 150, 180, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "CAPTION", "주석", true, GridColDataType_emu.VarChar, 230, 300, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "Format_NO", "형식NO", true, GridColDataType_emu.VarChar, 200, 230, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.InitColumnUltraGrid(Grid1, "SEQ", "순서", true, GridColDataType_emu.VarChar, 60, 90, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(Grid1, "SpecCode", "규격코드", true, GridColDataType_emu.VarChar, 230, 280, Infragistics.Win.HAlign.Left, true, false);

                //_GridUtil.InitColumnUltraGrid(Grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 70, 90, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(Grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 180, 190, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(Grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 70, 90, Infragistics.Win.HAlign.Left, true, false);
                //_GridUtil.InitColumnUltraGrid(Grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 180, 190, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(Grid1);



                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.Cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                Cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                DBHelper db = new DBHelper("", false);

                rtnDtTemp = db.FillTable("USP_DG0300_S1", CommandType.StoredProcedure
                                , db.CreateParameter("PCODE", "L0", DbType.String, ParameterDirection.Input)
                                , db.CreateParameter("AS_PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input));

                WIZ.Common.FillComboboxMaster(this.Cbo_TypeNo_H, rtnDtTemp, "TYPE_NO", "TYPE_REMARK", null, null);
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DATA_TYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("HIMSEQUIP"); //설비코드
                WIZ.Common.FillComboboxMaster(this.cbo_HIMSEQUIP_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                string sPlantCode = DBHelper.nvlString(Cbo_PLANTCODE_H.Value);

                //cbo_STARTDATE_H.Value = DateTime.Now.AddHours(-1);
                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-1);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(1);


                //Grid1 이벤트 순서
                //1. Grid1_ClickCell
                //2. Grid1_CellListSelect
                //3. Grid1_AfterCellListCloseUp
                //4. Grid1_AfterCellListCloseUp - cell.Column.Key = SPECCODE


                #endregion

                #region POPUP SETTING

                //작업장명
                //btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { Cbo_PLANTCODE_H, "", "", "" });
                //공정명
                //btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });
                //라인명
                //btbManager.PopUpAdd(txt_LINECODE_H, txt_LINENAME_H, "BM0050", new object[] { cbo_PLANTCODE_H, "", "" });

                //BizGridManager bizGridManager = new BizGridManager(grid1);
                //bizGridManager.PopUpAdd("LINECODE", "LINENAME", "BM0050", new string[] { "PLANTCODE", "", "Y" });
                //bizGridManager.PopUpAdd("OPCODE", "OPNAME", "BM0040", new string[] { "PLANTCODE", "", "Y" });

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
            _GridUtil.Grid_Clear(Grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(Cbo_PLANTCODE_H.Value);
                string sTYPE_NO = DBHelper.nvlString(Cbo_TypeNo_H.Value);
                string sDataType = DBHelper.nvlString(Cbo_Table.Value);
                //string sWorkCenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Value);
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd HH:mm:ss");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd HH:mm:ss");
                //string sDATA_TYPE = DBHelper.nvlString(Cbo_DataType_H.Value);
                //string sSpecCode = DBHelper.nvlString(Cbo_SpecCode_H.Value);

                rtnDtTemp = helper.FillTable("USP_DG0300_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PCODE", "S1", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_TYPE_NO", sTYPE_NO, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_DATATYPE", sDataType, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_WORKCENTERCODE", "", DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));

                _GridUtil.InitializeGrid(this.Grid1, false, true, false, "", false);
                Grid1.DataSource = rtnDtTemp;
                Grid1.DataBinds(rtnDtTemp);
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

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            base.DoSave();
        }
        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>
        public override void DoImportExcel()
        {
        }

        #endregion

        #region < EVENT AREA >
        //private DataTable selectPrinterList()
        //{
        //    DBHelper helper = new DBHelper(false);
        //    DataTable tmpTable = new DataTable();
        //    try
        //    {
        //        tmpTable = helper.FillTable("USP_PRINTERADD_S1", CommandType.StoredProcedure
        //                                                    , helper.CreateParameter("PRINTERNAME", "", DbType.String, ParameterDirection.Input)
        //                                                    , helper.CreateParameter("CIP", "", DbType.String, ParameterDirection.Input)
        //                                                    , helper.CreateParameter("USEFLAG", "Y", DbType.String, ParameterDirection.Input));       
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ClosePrgFormNew();
        //        this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
        //    }
        //    finally
        //    {
        //        this.ClosePrgFormNew();
        //        helper.Close();
        //    }

        //    return tmpTable;
        //}


        #endregion

        private void DG0300_Activated(object sender, EventArgs e)
        {
            ////2020-09-14 ADD
            //try
            //{
            //    if (rtnDtTemp.Rows.Count > 0 && grid1 != null)
            //    {
            //        //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
            //        grid1.ActiveRow.Cells["IDX"].Activation = Activation.NoEdit;
            //    }
            //}
            //catch (Exception)
            //{
            //    //
            //}
        }

        /// <summary>
        /// 형식no의 값이 변경될때 이벤트로 데이터 셋팅시에도 발생함(화면 _Load시에  부적합함)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbo_TypeNo_H_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DBHelper db = new DBHelper("", false);

                rtnDtTemp = db.FillTable("USP_DG0300_S1", CommandType.StoredProcedure
                                    , db.CreateParameter("PCODE", "L1", DbType.String, ParameterDirection.Input)
                                    , db.CreateParameter("AS_PLANTCODE", WIZ.LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                                    , db.CreateParameter("AS_TYPE_NO", Cbo_TypeNo_H.Value, DbType.String, ParameterDirection.Input));

                WIZ.Common.FillComboboxMaster(this.Cbo_Table, rtnDtTemp, "COLNAME", "CAPTION", null, null);
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }


        /// <summary>
        /// 형식no의 선택이 끝난 후에 - 화면 _Load() 이벤트에서 호출해주는게 적합함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbo_TypeNo_H_AfterCloseUp(object sender, EventArgs e)
        {
            //Debug.WriteLine("Cbo_TypeNo_H_AfterCloseUp");
            //DataTable rtnDtTemp2;//= new DataTable(); // return DataTable 공통
            try
            {
                //string sPlantCode = DBHelper.nvlString(Cbo_PLANTCODE_H.Value);
                //string sTypeNo = DBHelper.nvlString(Cbo_TypeNo_H.Value);
                //rtnDtTemp = _Common.GET_DG0100_CODE(sPlantCode, sTypeNo); //규격코드(컬럼명)
                //WIZ.Common.FillComboboxMaster(this.Cbo_SpecCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.Grid1, "SpecCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
                //rtnDtTemp2 = null;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// 코드와 명이 있는 상태에서 코드을 가져옴. - 2020-09-16 ADD
        /// </summary>
        /// <param name="vInString">코드 가져올 데이터</param>
        /// <param name="bDefault"> true = :기준,  false = (/@..등 지정값 으로 코드 가져옴</param>
        /// <returns> : 이전의 데이터를 반환(:이 없으면 전체데이터 반환)</returns>
        public string GetCode(string vInString, bool bDefault = false, string sStartStr = "[", string sEndStr = "]")
        {
            string sRtn = vInString;
            int iStart, iEnd;

            try
            {
                if (bDefault)
                {
                    if (vInString.Contains(":"))
                        sRtn = vInString.Substring(0, vInString.IndexOf(":")).Trim();
                }
                else
                {
                    if (vInString.Contains(sStartStr))
                    {
                        iStart = vInString.IndexOf(sStartStr);
                        iEnd = vInString.IndexOf(sEndStr);
                        if (iStart > -1 && iEnd > -1 && iEnd >= iStart)
                        {
                            iStart++;
                            sRtn = vInString.Substring(iStart, iEnd - iStart).Trim();
                        }
                    }
                }
            }
            catch //(Exception ex)
            {
                //    gMsg("[" + MethodBase.GetCurrentMethod().Name + "]" + ex.Message, ClsEnum.geMsgType.ERROR, true);
            }

            return sRtn;
        }

    }
}