#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID        : BM1000
//   Form Name      : 품목별 측정 SPEC 관리
//   Name Space     : MHSPC.BM
//   Created Date   : 2012.10.08
//   Made By        : WIZCORE
//   Description    : 품목별 측정 SPEC 관리
//   DB Table       : BM1000
//   StoreProcedure : USP_BM1000_S1(S2, I1, D1, U1)
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
#endregion

namespace WIZ.BM
{
    public partial class BM7100 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        // 변수나 Form에서 사용될 Class를 정의
        private string PlantCode;


        private DataTable rtnDtTemp = new DataTable();
        private DataTable DtGrid1 = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();

        private bool StatusCheck = false;   //DoSearch 시점에 상태값 변경 하기 위해 사용
        #endregion

        #region < CONSTRUCTOR >
        public BM7100()
        {
            InitializeComponent();
            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            PlantCode = CModule.GetAppSetting("Site", "10");

        }
        #endregion

        #region<BM1000_Load>
        private void BM1000_Load(object sender, EventArgs e)
        {
            #region Grid1 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", true);

            // InitColumnUltraGrid 
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "Org Code", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CRITICALID", "이상원인코드", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CRITICALDESC", "이상원인내용", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CONTROLFLAG", "관리유무", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SORTID", "정렬순서", false, GridColDataType_emu.Integer, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CRITICALSPEC", "", false, GridColDataType_emu.Double, 250, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARKS", "비고", false, GridColDataType_emu.VarChar, 400, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용유무", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

            //데이터 머지 된 상태에서 그리드 컬럼 소트 기능 막기     
            //  grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            _GridUtil.SetInitUltraGridBind(grid1);
            DtGrid1 = (DataTable)this.grid1.DataSource;
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("UseFlag");     //사용여부
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "CONTROLFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (StatusCheck == false)
            {
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                //_GridUtil.Grid_Clear(grid2);

                rtnDtTemp = USP_BM7100_S1(this.PlantCode);

                grid1.DataSource = rtnDtTemp;
                grid1.DataBind();

                DtGrid1 = rtnDtTemp;

                if (rtnDtTemp.Rows.Count == 0)
                {
                    _GridUtil.Grid_Clear(this.grid1);

                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                StatusCheck = true;
                this.grid1.GetRow();
            }
            else
            {
                #region 그리드 상테에서 삭제 신규나, 수정의 상태 변경을 찾아 메세지 경고를 보여줌
                if (UltraGridUtil.CheckSearchDataGrid(this, this.grid1, this.DtGrid1, false) == true)
                {
                    DialogResult result = MessageBox.Show(Common.getLangText("자료를 저장하지 않았습니다. \n\r\n\r저장하지 않고 검색하겠습니까?", "MSG"), "변경데이터 있음", MessageBoxButtons.OKCancel);
                    if (result != DialogResult.OK)
                    {
                        StatusCheck = true;
                    }
                    else
                    {
                        StatusCheck = false;
                        DoInquire();
                    }
                }
                else
                {
                    StatusCheck = false;
                    DoInquire();
                }
                #endregion
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            this.grid1.InsertRow();
            // 초기값 설정
            this.grid1.ActiveRow.Cells["UseFlag"].Value = "Y";
            this.grid1.ActiveRow.Cells["PlantCode"].Value = this.PlantCode;
            this.grid1.ActiveRow.Cells["CONTROLFLAG"].Value = "Y";
            this.grid1.ActiveRow.Cells["CRITICALSPEC"].Value = 0.0;
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            try
            {
                base.DoSave();

                this.grid1.SetRow();

                this.grid1.PerformAction(UltraGridAction.DeactivateCell);

                if (UltraGridUtil.CheckSaveDataGrid(this, this.grid1, DtGrid1, true) == true)
                {
                    USP_BM7100_CRUD(DtGrid1, this.WorkerID);
                    StatusCheck = false;
                }
                else
                {
                    StatusCheck = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
        }

        public override void DoDownloadExcel()
        {
            if (this.grid1.Rows.Count == 0)
            {

                this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            this.grid1.ExportExcel();
            base.DoDownloadExcel();
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

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            string enter = e.KeyCode.ToString();
            if (enter == "Return")
            {
                Infragistics.Win.UltraWinGrid.GridKeyActionMapping KeyMapping1 = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Tab, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0);
                this.grid1.KeyActionMappings.Add(KeyMapping1);
                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
            }
        }
        #endregion

        #region 이상발생코드 조회

        private DataTable USP_BM7100_S1(string AS_PLANTCODE)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                return helper.FillTable("USP_BM7100_S1N", CommandType.StoredProcedure
                                                                      , helper.CreateParameter("PLANTCODE", AS_PLANTCODE, DbType.String, ParameterDirection.Input)
                                                                      , helper.CreateParameter("USEFLAG", string.Empty, DbType.String, ParameterDirection.Input));//임의로추가




            }
            catch (Exception ex)
            {

                WIZ.Forms.CheckForm checkform = new WIZ.Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();

                return new DataTable();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion

        #region 저장/수정/삭제
        public void USP_BM7100_CRUD(DataTable DtChange, string USER_ID)
        {
            DBHelper helper = new DBHelper("", true);

            try
            {


                foreach (DataRow drRow in DtChange.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:

                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM7100_D1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALID", Convert.ToString(drRow["CRITICALID"]), DbType.String, ParameterDirection.Input));
                            #endregion

                            break;

                        case DataRowState.Added:

                            #region [신규 추가]

                            helper.ExecuteNoneQuery("USP_BM7100_I1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALID", Convert.ToString(drRow["CRITICALID"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALDESC", Convert.ToString(drRow["CRITICALDESC"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CONTROLFLAG", Convert.ToString(drRow["CONTROLFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SORTID", Convert.ToInt16(drRow["SORTID"]), DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALSPEC", Convert.ToDouble(drRow["CRITICALSPEC"]), DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("MAKER", Convert.ToString(drRow["MAKER"]), DbType.String, ParameterDirection.Input));

                            #endregion

                            break;
                        case DataRowState.Modified:

                            #region [수정]

                            helper.ExecuteNoneQuery("USP_BM7100_U1N", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALID", Convert.ToString(drRow["CRITICALID"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALDESC", Convert.ToString(drRow["CRITICALDESC"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CONTROLFLAG", Convert.ToString(drRow["CONTROLFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("SORTID", Convert.ToInt16(drRow["SORTID"]), DbType.Int16, ParameterDirection.Input)
                                                                   , helper.CreateParameter("CRITICALSPEC", Convert.ToDouble(drRow["CRITICALSPEC"]), DbType.Double, ParameterDirection.Input)
                                                                   , helper.CreateParameter("REMARKS", Convert.ToString(drRow["REMARKS"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("EDITOR", Convert.ToString(drRow["EDITOR"]), DbType.String, ParameterDirection.Input));
                            #endregion

                            break;
                    }
                }

                helper.Commit();
            }
            catch (Exception ex)
            {

                helper.Rollback();


                WIZ.Forms.CheckForm checkform = new Forms.CheckForm(ex.ToString());
                checkform.ShowDialog();
            }
            finally
            {

                helper.Close();
            }
        }
        #endregion 

        #region<btnSample_Click>
        private void btnSample_Click(object sender, EventArgs e)
        {
            //WIZ.POPUP.PP4500 pp4500 = new POPUP.PP4500();
            //pp4500.ShowDialog();
        }
        #endregion
    }
}
