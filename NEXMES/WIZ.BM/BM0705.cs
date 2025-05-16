#region < HEADER AREA >

#endregion

#region <USING AREA>
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0705 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region < CONSTRUCTOR >
        public BM0705()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtMachCode, txtMachName, "TBM0700", new object[] { "", "", "", "" });                     //설비 팝업

        }
        #endregion

        #region  <BM0705_Load>
        private void BM0705_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "MachCode", "설비코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MachName", "설비명", false, GridColDataType_emu.VarChar, 230, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QcCode", "기준", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QcValue", "배점", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RpCode", "기준", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RpValue", "배점", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EsCode", "기준", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EsValue", "배점", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일자", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);


            string[] sMergeColumn1 = { "QcCode", "QcValue" };
            string[] sMergeColumn2 = { "RpCode", "RpValue" };
            string[] sMergeColumn3 = { "EsCode", "EsValue" };

            string[] sHeadColumn = { "MachCode", "MachName", "QcCode", "QcValue", "RpCode", "RpValue", "EsCode", "EsValue", "Remark", "MakeDate", "Maker", "EditDate", "Editor" };

            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            //그리드 머지


            _GridUtil.GridHeaderMerge(grid1, "G1", "품질영향", sMergeColumn1, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G2", "대체설비", sMergeColumn2, sHeadColumn);
            _GridUtil.GridHeaderMerge(grid1, "G3", "환경안전영향", sMergeColumn3, sHeadColumn);


            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 0, 1);

            _GridUtil.GridHeaderMergeVertical(grid1, sHeadColumn, 8, 12);


            grid1.Columns["G1"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.Columns["G2"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.Columns["G3"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;





            // row numbering
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region 콤보박스
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("MACHGD_QC");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "QcCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHGD_RP");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "RpCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("MACHGD_ES");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "EsCode", rtnDtTemp, "CODE_ID", "CODE_NAME");





            #endregion

        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            ///////////////////

            DBHelper helper = new DBHelper(false);

            try
            {


                base.DoInquire();

                string sMachcode = txtMachCode.Text.Trim();
                string sMachname = txtMachName.Text.Trim();

                grid1.DataSource = helper.FillTable("USP_BM0705_S1"
                                             , CommandType.StoredProcedure
                                             , helper.CreateParameter("@MACHCODE", sMachcode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@MACHNAME", sMachname, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@SPARE1", string.Empty, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@SPARE2", string.Empty, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("@SPARE3", string.Empty, DbType.String, ParameterDirection.Input));
                grid1.DataBinds();

            }
            catch
            {
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        /*   public override void DoNew()
           {

               try
               {
                   base.DoNew();

               }
               catch (Exception ex)
               {
                   this.ShowDialog(ex.ToString());
               }
               ////
               //base.DoNew();

               //this.grid1.InsertRow();
           }*/
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            //UltraGridUtil.DeleteCurrentRowGrid(this, this.grid1, DtChange);
            base.DoDelete();
            this.grid1.DeleteRow();
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            //DBHelper helper = new DBHelper(false,"Data Source=192.168.100.20;Initial Catalog=MTMES;User ID=sa;Password=qwer1234!~");
            DBHelper helper = new DBHelper("", true);

            try
            {

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    return;
                base.DoSave();



                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["MachCode"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, "설비코드 error!");
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM0705_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("@MACHCODE", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input));           // 품목

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM0705_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("@MACHCODE", Convert.ToString(drRow["MachCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@QCCODE", Convert.ToString(drRow["QcCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@RPCODE", Convert.ToString(drRow["RpCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@ESCODE", Convert.ToString(drRow["EsCode"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@REMARK", Convert.ToString(drRow["Remark"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("@USER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges("MachCode");
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
                    e.Row.RowError = "작업자 정보가 있습니다.";
                    throw (new SException("S00099", e.Errors));
                default:
                    break;
            }
        }



        #endregion

        #region <METHOD AREA>
        // Form에서 사용할 함수나 메소드를 정의





        #endregion

    }
}
