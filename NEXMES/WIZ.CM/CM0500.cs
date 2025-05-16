#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 
//   Name Space   : 
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class CM0500 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >

        public CM0500()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            //    * TBM0700 : 설비
            //*          - 1 : MachCode, 2 : MachName, param[0] : MachType, param[1] : MachType1
            //*          , param[2] : MachType2, param[3] : UseFlag
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });

            //   * TBM0400 : 작업장 
            //*          - 1 : OPCode, 2 : OPName, param[0] : PlantCode, param[1] : UseFlag 
            btbManager.PopUpAdd(txtOPCode, txtOPName, "TBM0400", new object[] { cboPlantCode_H, "" });
        }

        private void CM0500_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Machname", "설비명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "점검코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "점검항목", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCMETHOD", "점검방법", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCRUNSTOP", "운/휴", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCINSTRUMENT", "측정기구", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCSTANDARD", "판정기준", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCCHECKCYLE", "교환,점검주기", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "점검여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["MachCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["MachCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["MachCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["Machname"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["Machname"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["Machname"].MergedCellStyle = MergedCellStyle.Always;
            #endregion Grid MERGE

            #endregion

            #region 그리드팝업
            BizGridManager gridManager = new BizGridManager(grid1);
            gridManager.PopUpAdd("MachCode", "Machname", "TBM0700", new string[] { "", "", "", "" });
            gridManager.PopUpAdd("InspCode", "InspName", "TBM1500", new string[] { "", "", "", "" });

            #endregion

            #region 콤보박스

            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("MCINSTRUMENT");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCINSTRUMENT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCRUNSTOP");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCRUNSTOP", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCSTANDARD");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCSTANDARD", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.GET_TBM0000_CODE("INSPVALTYPE"); //
            // WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CHK", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MCMETHOD");  //점검방법
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "MCMETHOD", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("InspValType");     //검사구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPFLAG");     //점검여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CHK", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion
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
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);  // 공장코드 
                string sMachCode = txtMachCode.Text.Trim();
                string sWMachName = txtMachName.Text.Trim();
                string sDtp_date = cbo_date.Value.ToString();

                base.DoInquire();
                grid1.DataSource = helper.FillTable("USP_CM0500_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MachCode", sMachCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Machname", sWMachName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("Date", sDtp_date.Substring(0, 10), DbType.String, ParameterDirection.Input));
                //테스트 데이터를 기준으로 Update 내역이 저장은 되나, 조회가 되지 않아 sDtp_date를 SubString(0, 10)으로 처리.
                //, helper.CreateParameter("Date", sDtp_date, DbType.String, ParameterDirection.Input)); 

                grid1.DataBinds();


                //_Common.Grid_Column_Width(this.grid1); //grid 정리용

                //////////




                //이하 주석처리 _130819
                //if (rtnDtTemp.Rows.Count > 0)
                //{
                //     Cboparam[0] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                //     Cboparam[1] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                //     CboDtTemp = DBHelper.FillTable("USP_CM0500_S2", CommandType.StoredProcedure, Cboparam);



                //    for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                //    {
                //        string sChk = DBHelper.gGetCode(rtnDtTemp.Rows[i]["InspValType"]);
                //        if (DBHelper.gGetCode(rtnDtTemp.Rows[i]["InspValType"]) == string.Empty)
                //        {

                //            grid1.Rows[i].Cells["CHK"].Activation = Activation.NoEdit;
                //        }

                //             // 선택된 품목에 연결된 공급처가 많을 경우
                //        ValueList list = grid1.DisplayLayout.ValueLists.Add();
                //         switch (sChk)
                //        {
                //            case "1":
                //            list.ValueListItems.Add("");
                //            list.ValueListItems.Add(CboDtTemp.Rows[0]["RelCode1"]);
                //            list.ValueListItems.Add(CboDtTemp.Rows[0]["RelCode2"]);
                //            grid1.Rows[i].Cells["CHK"].ValueList = list;
                //            break;
                //            case "2":
                //            list.ValueListItems.Add("");
                //            list.ValueListItems.Add(CboDtTemp.Rows[1]["RelCode1"]);
                //            list.ValueListItems.Add(CboDtTemp.Rows[1]["RelCode2"]);
                //            grid1.Rows[i].Cells["CHK"].ValueList = list;
                //            break;
                //            case "3":
                //            list.ValueListItems.Add("");
                //            list.ValueListItems.Add(CboDtTemp.Rows[2]["RelCode1"]);
                //            list.ValueListItems.Add(CboDtTemp.Rows[2]["RelCode2"]);
                //            grid1.Rows[i].Cells["CHK"].ValueList = list;    
                //            break;
                //            case "5":
                //            list.ValueListItems.Add("");
                //            list.ValueListItems.Add(CboDtTemp.Rows[4]["RelCode1"]);
                //            list.ValueListItems.Add(CboDtTemp.Rows[4]["RelCode2"]);
                //            grid1.Rows[i].Cells["CHK"].ValueList = list;
                //            break;
                //         }
                //    }
                //}
                //DtChange = rtnDtTemp;

            }
            //catch (SqlException )
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

            //int iRow = grid1.InsertRow();
            int iRow = _GridUtil.AddRow(this.grid1);
            grid1.ActiveRow.Cells["PlantCode"].Value = 820;
            grid1.ActiveRow.Cells["CHK"].Value = "N";
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            try
            {
                if (grid1.ActiveRow != null && grid1.ActiveRow.Cells["InspValType"].Value.ToString() != string.Empty)
                {
                    grid1.ActiveRow.Cells["CHK"].Value = null;
                    //grid1.ActiveRow.Cells["CHK"].Column.ValueList.SelectedItemIndex = -1;
                }
            }
            catch
            {
            }

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
                string sPlantCode = "";
                this.Focus();
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)  // .GetChanges().Rows = 변경된 Rows 만 작업
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["PlantCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "사업장 코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Added:
                            #region 수정
                            //  param = new System.Data.Common.DbParameter[16];

                            //param[0] = helper.CreateParameter("PlantCode", drRow["PlantCode"].ToString(), DbType.String, ParameterDirection.Input);     
                            //param[1] = helper.CreateParameter("MachCode", drRow["MachCode"].ToString(), DbType.String, ParameterDirection.Input);   
                            //param[2] = helper.CreateParameter("Machname", drRow["Machname"].ToString(), DbType.String, ParameterDirection.Input);    
                            //param[3] = helper.CreateParameter("InspCode", drRow["InspCode"].ToString(), DbType.String, ParameterDirection.Input);    
                            //param[4] = helper.CreateParameter("InspName",   drRow["InspName"].ToString(), DbType.String, ParameterDirection.Input);       
                            //param[5] = helper.CreateParameter("MCMETHOD", drRow["MCMETHOD"].ToString(), DbType.String, ParameterDirection.Input); 
                            //param[6] = helper.CreateParameter("MCRUNSTOP", drRow["MCRUNSTOP"].ToString(), DbType.String, ParameterDirection.Input);  
                            //param[7] = helper.CreateParameter("MCINSTRUMENT", drRow["MCINSTRUMENT"].ToString(), DbType.String, ParameterDirection.Input);  
                            //param[8] = helper.CreateParameter("MCSTANDARD", drRow["MCSTANDARD"].ToString(), DbType.String, ParameterDirection.Input);     
                            //param[9] = helper.CreateParameter("MCCHECKCYLE", drRow["MCCHECKCYLE"].ToString(), DbType.String, ParameterDirection.Input);     
                            //param[10] = helper.CreateParameter("InspValType", drRow["InspValType"].ToString(), DbType.String, ParameterDirection.Input);     
                            //param[11] = helper.CreateParameter("CHK", drRow["CHK"].ToString(), DbType.String, ParameterDirection.Input);     
                            //param[12] = helper.CreateParameter("Maker", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input);     // 등록자\
                            //param[13] = helper.CreateParameter("inspDate",cbo_date.Text.Trim().ToString(), DbType.String, ParameterDirection.Input);     // 등록자

                            //param[14] = helper.CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1);
                            //param[15] = helper.CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200);

                            //DBHelper.ExecuteNoneQuery("USP_CM0500_I1", CommandType.StoredProcedure, param);

                            //if (param[14].Value.ToString() == "E") throw new Exception(param[15].Value.ToString()); 
                            sPlantCode = Convert.ToString(drRow["PlantCode"]);
                            helper.ExecuteNoneQuery("USP_CM0500_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MachCode", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Machname", Convert.ToString(drRow["Machname"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspCode", Convert.ToString(drRow["InspCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspName", Convert.ToString(drRow["InspName"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MCMETHOD", Convert.ToString(drRow["MCMETHOD"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MCRUNSTOP", Convert.ToString(drRow["MCRUNSTOP"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MCINSTRUMENT", Convert.ToString(drRow["MCINSTRUMENT"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MCSTANDARD", Convert.ToString(drRow["MCSTANDARD"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MCCHECKCYLE", Convert.ToString(drRow["MCCHECKCYLE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("InspValType", Convert.ToString(drRow["InspValType"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CHK", Convert.ToString(drRow["CHK"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("Maker", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("inspDate", cbo_date.Text.Trim().ToString(), DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("PlantCode");
                helper.Commit();

            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw (ex);
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
        /// <summary>
        /// DATABASE UPDATE전 VALIDATEION CHECK 및 값을 수정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {
                e.Command.Parameters["@Editor"].Value = this.WorkerID;
                return;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                e.Command.Parameters["@Maker"].Value = this.WorkerID;
                return;
            }
        }

        /// <summary>
        /// 저장처리시 오류가 발생한 경우 오류 메세지에 대한 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Errors == null) return;

            switch (((SqlException)e.Errors).Number)
            {
                // 중복
                case 2627:
                    e.Row.RowError = "설비코드가 있습니다.";
                    throw (new SException("C:S00099", e.Errors));
                default:
                    break;
            }
        }
        #endregion

        #region <METHOD AREA>

        #region 설비정보
        private void Search_Pop_TBM0700()
        {
            //비지니스 로직 객체 생성
            PopUp_Biz _biz = new PopUp_Biz();
            string sMachCode = txtMachCode.Text.Trim();       //설비코드
            string sMachName = txtMachName.Text.Trim();      //설비명 


            try
            {
                _biz.BM0070_POP(sMachCode, sMachName, "", "", "", txtMachCode, txtMachName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }

        }
        #endregion        //설비

        private void txtMachCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtMachName.Text = string.Empty;
        }

        private void txtMachCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0700();
            }
        }

        private void txtMachCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0700();
        }

        private void txtMachName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtMachCode.Text = string.Empty;
        }

        private void txtMachName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search_Pop_TBM0700();
            }
        }

        private void txtMachName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Pop_TBM0700();
        }
        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                try
                {
                    if (grid1.ActiveRow != null && grid1.ActiveRow.Cells["CHK"].Activated && grid1.ActiveRow.Cells["InspValType"].Value.ToString() != string.Empty && grid1.ActiveRow.Cells["InspValType"].Value.ToString() != "4")
                    {
                        grid1.ActiveRow.Cells["CHK"].Value = null;

                        //     grid1.ActiveRow.Cells["CHK"].Column.ValueList.SelectedItemIndex = -1;
                    }
                }
                catch
                {
                }
            }

        }

        // Form에서 사용할 함수나 메소드를 정의
        #endregion

    }
}
