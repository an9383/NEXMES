
#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      :  MM9910
//   Form Name    : 자재LOT(발행) 정보 관리
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM9910 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private string sPlant = string.Empty;

        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public MM9910()
        {
            InitializeComponent();


        }
        #endregion

        #region < MM9910_Load >
        private void MM9910_Load(object sender, EventArgs e)
        {
            Common _Common = new Common();
            #region Grid 셋팅

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PREINGROUPNO", "발행그룹번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PRTDATE", "라벨발행일", false, GridColDataType_emu.YearMonthDay, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "업체", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "업체명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTLOTNO", "자재번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPGOCNT", "수량(EA)", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "IPGOQTY", "중량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INCNT", "수량(EA)", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "중량", false, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            string[] arrMerCol1 = { "IPGOCNT", "IPGOQTY" };
            string[] arrMerCol2 = { "INCNT", "INQTY" };


            //string[] arrColTot = { "CHK", "PONO", "POSEQNO","CUSTCODE","CUSTNAME","RAPDATE","PREINGROUPNO",
            //                       "COILNO","ItemCode","ItemName","UnitCode", "ISSUELOTSIZE", "ISSUELOTBASEQTY", "INSPLOTSIZE", "INSPLOTBASEQTY", "WAITINGLOTSIZE", "WAITINGLOTBASEQTY"};

            _GridUtil.GridHeaderMerge(grid1, "A", "발행", arrMerCol1, null);
            _GridUtil.GridHeaderMerge(grid1, "B", "수입검사등록", arrMerCol2, null);
            //_GridUtil.GridHeaderMerge(grid1, "C", "수입검사대기잔량ⓐ-ⓑ", arrMerCol3, null);


            #endregion

            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0130_CODE_1("C", "Y");  // 단위
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UnitCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region --- POP-Up Setting ---
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "ROH" });
            #endregion
            System.DateTime datetoday = System.DateTime.Now;
            cboStartDate_H.Value = datetoday.AddDays(1 - datetoday.Day);
            sPlant = CModule.GetAppSetting("Site", "10");
            cboPlantCode_H.Value = sPlant;

            DoInquire();
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);                              // 공장코드     
                string sSrart = string.Format("{0:yyyy-MM-dd}", cboStartDate_H.Value);               // 시작일자
                string sEnd = string.Format("{0:yyyy-MM-dd}", cboEndDate_H.Value);
                string sItemCode = this.txtItemCode_H.Text;                                             // 품목
                string sCOILNO = this.txtCoilNo_H.Text;                                               // 자재번호(코일번호에서 자재번호로 수정)
                string sPoNo = this.txtPoNo_H.Text.Trim();                                          // 발주번호

                rtnDtTemp = helper.FillTable("USP_MM9910_S1N", CommandType.StoredProcedure
                                                           , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_STARTDATE", sSrart, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ENDDATE", sEnd, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_PONO", sPoNo, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("AS_COILNO", sCOILNO, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBinds();

                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;

                    }
                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);

                    _GridUtil.Grid_Clear(grid1);
                }

            }
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
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            grid1.UpdateData();
            if (grid1.Rows.Count == 0) return;

            int cnt = 0;

            for (int i = 0; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper() == "TRUE")
                    break;
                else
                {
                    cnt++;

                    if (cnt == grid1.Rows.Count)
                    {
                        this.ShowDialog(Common.getLangText("선택된 삭제 내역이 없습니다. 선택 후 진행하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
            }

            base.DoSave();

            DialogResult result = this.ShowDialog(Common.getLangText("선택된 발행내역을 삭제합니다. 삭제하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO);

            if (result.ToString().ToUpper() == "CANCEL")
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper() == "TRUE")
                    {
                        helper.ExecuteNoneQuery("USP_MM9910_D1"
                                                , CommandType.StoredProcedure
                                                , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("PONO", Convert.ToString(grid1.Rows[i].Cells["PONO"].Value), DbType.String, ParameterDirection.Input)
                                                , helper.CreateParameter("PREINGROUPNO", Convert.ToString(grid1.Rows[i].Cells["PREINGROUPNO"].Value), DbType.String, ParameterDirection.Input));

                    }
                }

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("라벨 발행 내역이 정상적으로 삭제 되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);

                    this.DoInquire();
                }
                else
                {
                    helper.Rollback();
                    this.ShowDialog(Common.getLangText("라벨 발행 내역 삭제 중 오류 발생", "MSG") + Environment.NewLine + helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {

                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }

            base.DoInquire();

            //if(grid1.ActiveRow.Cells["INSPLOTSIZE"].Value.ToString() != "0" ) 
            //{
            //     this.ShowDialog("수입 검사 대기 등록중인 LOT가 있습니다. 확인 후 삭제해주세요.", Forms.DialogForm.DialogType.OK);
            //    return;
            //}

            //this.grid1.DeleteRow();
        }

        public override void DoSave()
        {
            //grid1.UpdateData();
            //if (grid1.Rows.Count == 0) return;

            //int cnt = 0;

            //for (int i = 0; i < grid1.Rows.Count; i++)
            //{
            //    if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper() == "TRUE")
            //        break;
            //    else
            //    {
            //        cnt++;

            //        if (cnt == grid1.Rows.Count)
            //        {
            //            this.ShowDialog("선택된 삭제 내역이 없습니다. 선택 후 진행하세요.", Forms.DialogForm.DialogType.OK);
            //            return;
            //        }
            //    }
            //}

            //base.DoSave();

            //this.ClosePrgFormNew();

            //DialogResult result = this.ShowDialog("선택된 발행내역을 삭제합니다. 삭제하시겠습니까?", Forms.DialogForm.DialogType.YESNO);

            //if (result.ToString().ToUpper() == "CANCEL")
            //    return;

            //DBHelper helper = new DBHelper("", true);

            //try
            //{
            //    for (int i = 0; i < grid1.Rows.Count; i++)
            //    {
            //        if (Convert.ToString(grid1.Rows[i].Cells["CHK"].Value).ToUpper() == "TRUE")
            //        {
            //            helper.ExecuteNoneQuery("USP_MM9910_D1"
            //                                    , CommandType.StoredProcedure
            //                                    , helper.CreateParameter("EDITOR",       this.WorkerID,                                               DbType.String, ParameterDirection.Input)
            //                                    , helper.CreateParameter("PONO",         Convert.ToString(grid1.Rows[i].Cells["PONO"].Value),         DbType.String, ParameterDirection.Input)
            //                                    , helper.CreateParameter("PREINGROUPNO", Convert.ToString(grid1.Rows[i].Cells["PREINGROUPNO"].Value), DbType.String, ParameterDirection.Input));

            //        }
            //    }

            //    if (helper.RSCODE == "S")
            //    {
            //        this.ClosePrgFormNew();
            //        helper.Commit();
            //        this.ShowDialog("라벨 발행 내역이 정상적으로 삭제 되었습니다.", Forms.DialogForm.DialogType.OK);

            //        this.DoInquire();
            //    }
            //    else
            //    {
            //        this.ClosePrgFormNew();
            //        helper.Rollback();
            //        this.ShowDialog("라벨 발행 내역 삭제 중 오류 발생" + Environment.NewLine + helper.RSMSG, Forms.DialogForm.DialogType.OK);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    this.ClosePrgFormNew();
            //    helper.Rollback();
            //    this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }

        ///// <summary>
        ///// ToolBar의 저장 버튼 Click
        ///// </summary>
        //public override void DoSave()
        //{
        //    DataTable dt = grid1.chkChange();
        //    if (dt == null)
        //        return;

        //    DBHelper helper = new DBHelper(false);

        //    try
        //    {
        //        this.Focus();


        //        base.DoSave();
        //        string RS_CODE = string.Empty;
        //        string RS_MSG = string.Empty;

        //        string sPoOrderDate = string.Empty;
        //        string sPlanInDate = string.Empty;
        //        string sFinishFlag = string.Empty;

        //        foreach (DataRow drRow in dt.Rows)
        //        {
        //            if (drRow.RowState != DataRowState.Deleted)
        //            {
        //                if (drRow["PLANTCODE"].ToString().Trim() == string.Empty)
        //                {
        //                    this.ClosePrgFormNew();
        //                    this.ShowDialog("공장을 확인하세요.", Forms.DialogForm.DialogType.OK);
        //                    return;
        //                }

        //            }

        //            this.ClosePrgFormNew();

        //            if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
        //            {

        //                CancelProcess = true;
        //                return;
        //            }

        //            switch (drRow.RowState)
        //            {
        //                case DataRowState.Deleted:
        //                    #region 삭제
        //                    drRow.RejectChanges();

        //                    helper.ExecuteNoneQuery("USP_MM9910_D1"
        //                                            , CommandType.StoredProcedure
        //                                            , helper.CreateParameter("EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input)
        //                                            , helper.CreateParameter("PONO", Convert.ToString(drRow["PoNo"]), DbType.String, ParameterDirection.Input)
        //                                            , helper.CreateParameter("PREINGROUPNO", Convert.ToString(drRow["PREINGROUPNO"]), DbType.String, ParameterDirection.Input));
        //                    #endregion
        //                    break;
        //                case DataRowState.Added:
        //                    #region 추가

        //                    #endregion
        //                    break;
        //                case DataRowState.Modified:
        //                    #region 수정

        //                    #endregion
        //                    break;
        //            }
        //        }
        //        if (helper.RSCODE == "S")
        //        {
        //            helper.Commit();
        //        }
        //        else if (helper.RSCODE == "E")
        //        {
        //            this.ClosePrgFormNew();
        //            helper.Rollback();
        //            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ClosePrgFormNew();
        //        CancelProcess = true;
        //        helper.Rollback();
        //        this.ShowDialog(ex.ToString());
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

        #endregion

        #region [ Event Area ]

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            bool chk = Convert.ToString(this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value).ToUpper() == "TRUE" ? true : false;

            if (chk == true)
            {
                this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = false;
            }
            else
            {
                this.grid1.Rows[this.grid1.ActiveRow.Index].Cells["CHK"].Value = true;
            }
        }
        #endregion
    }
}
