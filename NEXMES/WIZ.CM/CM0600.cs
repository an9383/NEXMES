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
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.CM
{
    public partial class CM0600 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        int iColCount;
        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >

        public CM0600()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });
        }

        private void CM0600_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern
            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Machname", "설비명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "점검코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "점검항목", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCMETHOD", "점검방법", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCRUNSTOP", "운/휴", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCINSTRUMENT", "측정기구", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCSTANDARD", "판정기준", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MCCHECKCYLE", "교환,점검주기", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspValType", "검사구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "점검날짜", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT", "결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);

            iColCount = grid1.Columns.Count;

            //string[] sMergeColumn = {"MachCode", "Machname"};
            //string[] sHeadColumn = {"PlantCode", "MachCode","Machname", "InspCode","InspName", "MCMETHOD","MCRUNSTOP", "MCINSTRUMENT","MCSTANDARD", "MCCHECKCYLE","InspValType"};

            ////그리드 머지
            //_GridUtil.GridHeaderMerge(grid1, "G1", "10 가공", sMergeColumn,sHeadColumn);


            _GridUtil.SetInitUltraGridBind(grid1);

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

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPVALTYPE"); //
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspValType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UseFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            WIZ.UltraGridUtil.SetGridDataCopy(this.grid1);
            #endregion

            #endregion Grid 셋팅
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
                base.DoInquire();

                string sPlantCode = cboPlantCode_H.SelectedText.ToString() == "ALL" ? "" : cboPlantCode_H.SelectedText.ToString();
                string sMachCode = txtMachCode.Text.Trim();
                string sWMachName = txtMachName.Text.Trim();
                string sdate = cbo_date.Text.Trim().ToString();
                string sdate_to = cbo_dateto.Text.Trim().ToString();

                DataTable rtnDtTemp = helper.FillTable("USP_CM0600_S1", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("MachCode", sMachCode, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("Machname", sWMachName, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("date", sdate, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("date_to", sdate_to, DbType.String, ParameterDirection.Input));

                DataTable dt = new DataTable();

                foreach (DataColumn dc in rtnDtTemp.Columns)
                {
                    if (!(dc.ColumnName == "Inspdate" || dc.ColumnName == "Result"))
                        dt.Columns.Add(dc.ColumnName);
                }

                // 최초 설정한 컬럼 뒷부분은 모두 숨김.
                for (int i = iColCount; i < grid1.Columns.Count; i++)
                {
                    grid1.Columns[i].Hidden = true;
                }

                int iIndex = iColCount;
                string sPreInspDate = "";

                foreach (DataRow dr in rtnDtTemp.Rows)
                {
                    string sInspDate = Convert.ToString(dr["Inspdate"]);

                    // 새로운 날짜 데이터가 나타나면, 컬럼명을 수정해야 한다.
                    bool bChange = sPreInspDate != sInspDate;

                    // 선택된 날짜 데이터 저장
                    sPreInspDate = sInspDate;

                    // 해당 컬럼명을 수정해야 하면
                    if (bChange)
                    {
                        iIndex++;

                        // 현재 위치의 데이터가 그리드의 컬럼수보다 뒤에 있을 경우에
                        if (grid1.Columns.Count < iIndex)
                        {
                            // 추가 되어야 함.
                            _GridUtil.InitColumnUltraGrid(grid1, iIndex.ToString(), sInspDate, false, GridColDataType_emu.VarChar
                                , 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
                        }
                        else
                        {
                            // 그리드에는 현재 위치에 컬럼이 있을 때,
                            grid1.Columns[iIndex.ToString()].Header.Caption = sInspDate;
                            grid1.Columns[iIndex.ToString()].Hidden = false;
                        }
                    }

                    // DataTable 에 iIndex 컬럼이 없으면 입력
                    if (!dt.Columns.Contains(iIndex.ToString()))
                    {
                        dt.Columns.Add(iIndex.ToString());
                    }

                    bool bEqual = false;

                    // 현재 입력된 Row 에서
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // 동일한 데이터가 있는지 확인
                        bEqual = true;

                        foreach (DataColumn dc in rtnDtTemp.Columns)
                        {
                            // 조회된 데이터와 Inspdate, Result 를 제외한 데이터가 모두 동일한지 확인
                            if (!(dc.ColumnName == "Inspdate" || dc.ColumnName == "Result"))
                            {
                                if (Convert.ToString(dt.Rows[i][dc.ColumnName]) != Convert.ToString(dr[dc.ColumnName]))
                                {
                                    bEqual = false;
                                    break;
                                }
                            }
                        }

                        // 동일한 Row로 확인되면
                        if (bEqual)
                        {
                            // 해당 Rows 의 iIndex 컬럼에 데이터 입력
                            dt.Rows[i][iIndex.ToString()] = Convert.ToString(dr["Result"]);
                            break;
                        }
                    }

                    // 동일한 Row 가 아니라면
                    if (!bEqual)
                    {
                        // 신규 Row 생성/
                        DataRow tdr = dt.NewRow();

                        // 조회된 데이터에서 Inspdate, Result 를 제외한 데이터를 입력
                        foreach (DataColumn dc in rtnDtTemp.Columns)
                        {
                            if (!(dc.ColumnName == "Inspdate" || dc.ColumnName == "Result"))
                            {
                                tdr[dc.ColumnName] = dr[dc.ColumnName];
                            }
                        }

                        // iIndex 에 결과값 삽입
                        tdr[iIndex.ToString()] = Convert.ToString(dr["Result"]);

                        // 데이터테이블에 추가
                        dt.Rows.Add(tdr);
                    }
                }
                //_GridUtil.InitColumnUltraGrid(grid1, "Inspdate", "작업일자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                //_GridUtil.InitColumnUltraGrid(grid1, "Result", "검사결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DataSource = dt;
                grid1.DataBinds();

            }
            catch
            {
            }
            finally
            {
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

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

        }

        private void txtMachName_KeyDown(object sender, KeyEventArgs e)
        {
            this.txtMachCode.Text = string.Empty;
        }

        private void txtMachName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbo_date_BeforeDropDown(object sender, CancelEventArgs e)
        {

        }

        private void cbo_dateto_BeforeDropDown(object sender, CancelEventArgs e)
        {

        }
        // Form에서 사용할 함수나 메소드를 정의
        #endregion
    }
}
