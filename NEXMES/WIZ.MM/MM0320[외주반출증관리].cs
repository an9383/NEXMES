#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0320
//   Form Name    : 외주임가공 반출증 관리(자재)
//   Name Space   : WIZ.MM
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

#endregion

namespace WIZ.MM
{
    public partial class MM0320 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table = new DataTable();
        DataTable rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        string ChkInquire = "true";

        int Grid1RowIndex = 0;
        int Grid2RowIndex = 0;
        #endregion

        #region < CONSTRUCTOR >

        public MM0320()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode, txtCustName, "TBM0300", new object[] { "", "Y", "" });
            btbManager.PopUpAdd(txtWorkerID, txtWorkerName, "TBM0200", new object[] { cboPlantCode, "", "", "", "" });
        }
        #endregion

        #region  MM0320_Load
        private void MM0320_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성

            #region Grid 셋팅 //100 130 100 196 165 100 87 123 123 100 201 100 100 191 228 100 100

            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRANO", "반출증 번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRATYPE", "반출증 유형", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "반출증 등록일", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRAPLANDATE", "반출 예정일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TRASTATUS", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARCARRYDATE", "상차일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CARCARRYPERSON", "상차담당자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTPERSON", "출고담당자", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "TRANO", "반출증 번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "StockQty", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);


            _GridUtil.InitializeGrid(this.grid3, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid3, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE", "반출증 등록일", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRAPLANDATE", "반출 예정일자", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRANO", "반출증 번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRATYPE", "반출증 유형", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "TRASTATUS", "상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTCODE", "거래처", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CUSTNAME", "거래처명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CARCARRYDATE", "상차일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "CARCARRYPERSON", "상차담당자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "OUTDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "OUTPERSON", "출고담당자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "MDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid3, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid4, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid4, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "TRANO", "반출증 번호", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "ITEMNAME", "품목명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "StockQty", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "UnitCode", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "MAKER", "생성자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "MDATE", "생성일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid4, "EDITDATE", "수정일시", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid4);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
            this.cboPlantCode.Value = "1100";

            rtnDtTemp = _Common.GET_BM0000_CODE("TRASTATUS");  //사업장
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TRASTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "TRASTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion
            ChkInquire = "false";
        }
        #endregion  MM0320_Load

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            if (!CheckData())
            {
                return;
            }
            string CheckTabControl = "";
            if (tabControl1.SelectedTab.Index == 0)
            {
                CheckTabControl = "1";
                this._GridUtil.Grid_Clear(grid1);
                this._GridUtil.Grid_Clear(grid2);
            }
            else
            {
                CheckTabControl = "2";
                this._GridUtil.Grid_Clear(grid3);
                this._GridUtil.Grid_Clear(grid4);
            }

            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();


                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sTrano = this.txtCoilNo.Text;
                string sCustCode = this.txtCustCode.Text.Trim();
                if (rdoTraCheck.Checked == true)
                {
                    sSrart = "1900-01-01";
                    sEnd = "9999-01-01";
                    sCustCode = "";
                }
                rtnDtTemp = helper.FillTable("USP_MM0320_S1N", CommandType.StoredProcedure
                                              , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("STARTDATE", sSrart, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ENDDATE", sEnd, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("TRANO", sTrano, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("CUSTCODE", sCustCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("tabcontrol", CheckTabControl, DbType.String, ParameterDirection.Input)
                                              );
                if (CheckTabControl == "1")
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    grid3.DataSource = rtnDtTemp;
                    grid3.DataBinds();
                }

                this.ClosePrgFormNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void grid1_ClickCell_1(object sender, EventArgs e)
        {
            string CheckTabControl = "";
            string sPlantCode = "";
            string sTrano = "";
            if (tabControl1.SelectedTab.Index == 0)
            {
                CheckTabControl = "1";
                this._GridUtil.Grid_Clear(grid2);
                sPlantCode = Convert.ToString(this.grid1.ActiveRow.Cells["PLANTCODE"].Value);
                sTrano = Convert.ToString(this.grid1.ActiveRow.Cells["TRANO"].Value); ;
            }
            else
            {
                CheckTabControl = "2";
                this._GridUtil.Grid_Clear(grid4);
                sPlantCode = Convert.ToString(this.grid3.ActiveRow.Cells["PLANTCODE"].Value);
                sTrano = Convert.ToString(this.grid3.ActiveRow.Cells["TRANO"].Value); ;
            }

            DBHelper helper = new DBHelper(false);

            try
            {

                rtnDtTemp = helper.FillTable("USP_MM0320_S2N", CommandType.StoredProcedure
                                              , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("TRANO", sTrano, DbType.String, ParameterDirection.Input));
                if (CheckTabControl == "1")
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();
                }
                else
                {
                    grid4.DataSource = rtnDtTemp;
                    grid4.DataBinds();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtStart_H.Value));
            int sEnd = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog(Common.getLangText("조회 시작일자가 종료일자보다 큽니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        #region <METHOD AREA>
        #endregion
        public override void DoSave()
        {

            DataTable dt = new DataTable();
            string sOutDate = "";
            string sWorkerid = "";
            if (tabControl1.SelectedTab.Index == 0)
            {
                if (this.txtWorkerID.Text.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("출고자를 등록하세요", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
                dt = grid1.chkChange();
                if (dt == null)
                    return;
                sOutDate = string.Format("{0:yyyy-MM-dd}", ultraCalendarCombo1.Value);
                sWorkerid = txtWorkerID.Text.ToString();
            }
            else
            {
                dt = grid3.chkChange();
                if (dt == null)
                    return;
            }
            DBHelper helper = new DBHelper("", false);

            try
            {
                this.Select();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();


                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;
                        case DataRowState.Added:
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            if (tabControl1.SelectedTab.Index == 0)
                            {
                                helper.ExecuteNoneQuery("USP_MM0320_U"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CARCARRYDATE", sOutDate, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("CARCARRYPERSON", sWorkerid, DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("TRANO", Convert.ToString(drRow["TRANO"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));
                            }
                            else
                            {
                                helper.ExecuteNoneQuery("USP_MM0320_U2"
                                                        , CommandType.StoredProcedure
                                                        , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("TRANO", Convert.ToString(drRow["TRANO"]), DbType.String, ParameterDirection.Input)
                                                        , helper.CreateParameter("WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));
                            }
                            if (helper.RSCODE == "S")
                            {
                                if (tabControl1.SelectedTab.Index == 0) grid1.SetAcceptChanges();
                                else grid3.SetAcceptChanges();
                                helper.Commit();
                                this.ClosePrgFormNew();
                                this.ShowDialog(Common.getLangText("반출실적 등록을 완료 하였습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                                DoInquire();

                            }
                            else
                            {
                                helper.Rollback();
                                //15-09-30 마감일자관련 수정 최재형
                                //MessageBox.Show("반출 실적 등록을 실패 하였습니다." + Environment.NewLine + helper.RSMSG);
                                this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                            }
                            #endregion
                            break;
                    }
                    if (tabControl1.SelectedTab.Index == 0) grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                    else grid3.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }

            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void tabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (tabControl1.SelectedTab.Index == 0)
            {
                this.ultraCalendarCombo1.ReadOnly = false;
                this.txtWorkerID.ReadOnly = false;
                this.txtWorkerID.Enabled = true;
                this.txtWorkerName.ReadOnly = false;
                this.txtWorkerName.Enabled = true;

            }
            else
            {
                this.ultraCalendarCombo1.ReadOnly = true;
                this.txtWorkerID.ReadOnly = true;
                this.txtWorkerID.Enabled = false;
                this.txtWorkerName.Enabled = false;
                this.txtWorkerName.ReadOnly = true;
            }
            if (ChkInquire == "true") return;
            DoInquire();
        }
    }
}

