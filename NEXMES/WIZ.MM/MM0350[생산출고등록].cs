#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0350
//   Form Name    : 생산출고 등록/취소
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
    public partial class MM0350 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table = new DataTable();
        DataTable rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        string ChkInquire = "true";
        string CheckTabControl = "";
        #endregion

        #region < CONSTRUCTOR >

        public MM0350()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();

            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode, "" });


        }
        #endregion

        #region  MM0350_Load
        private void MM0350_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            #region Grid 셋팅 //100 130 100 196 165 100 87 123 123 100 201 100 100 191 228 100 100

            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "입고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, "#,##0", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCode", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "입고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "CHK", "선택", false, GridColDataType_emu.CheckBox, 70, 100, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "출고일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MATLOTNO", "LOTNO", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTBASEQTY", "기본수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STOCKQTY", "변경수량", false, GridColDataType_emu.Double, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHCODE", "창고코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WHNAME", "창고", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCCODE", "위치코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "STORAGELOCNAME", "위치", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "출고자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");
            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
            //this.cboPlantCode.Value = "1100";

            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE", "RELCODE1 = '" + cboWhCode.Value + "'");  // 저장위치
            //rtnDtTemp = _Common.GET_TBM0000_CODE("STORAGELOCCODE", "RELCODE2 = ''");
            WIZ.Common.FillComboboxMaster(this.cboStoreageLocCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            #endregion
            ChkInquire = "false";
        }
        #endregion  MM0350_Load

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

            if (tabControl1.SelectedTab.Index == 0)
            {
                CheckTabControl = "1";
                this._GridUtil.Grid_Clear(grid1);

            }
            else
            {
                CheckTabControl = "2";
                this._GridUtil.Grid_Clear(grid2);
            }

            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sSrart = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEnd = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sLotNo = this.txtLotNo.Text;
                string sItemCode = this.txtItemCode_H.Text;

                rtnDtTemp = helper.FillTable("USP_MM0350_S1N", CommandType.StoredProcedure
                                              , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("STARTDATE", sSrart, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ENDDATE", sEnd, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("TABCONTROL", CheckTabControl, DbType.String, ParameterDirection.Input)
                                              );
                if (CheckTabControl == "1")
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    grid2.DataSource = rtnDtTemp;
                    grid2.DataBinds();
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
                this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), Forms.DialogForm.DialogType.OK); //시작일자를 종료일자보다 이전으로 선택해주십시오.
                return false;
            }
            return true;
        }
        #region <METHOD AREA>
        #endregion
        public override void DoSave()
        {

            DataTable dt = new DataTable();

            if (tabControl1.SelectedTab.Index == 0)
            {
                dt = grid1.chkChange();
                if (dt == null)
                    return;

                if (this.cboWhCode.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("창고를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                //if (this.cboStoreageLocCode.Value.ToString() == "")
                //{
                //    this.ShowDialog("저장위치를 선택하세요", Forms.DialogForm.DialogType.OK);
                //    return;
                //}


            }
            else
            {
                dt = grid2.chkChange();
                if (dt == null)
                    return;

                if (this.cboWhCode.Value.ToString() == "")
                {
                    this.ShowDialog(Common.getLangText("창고를 선택하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                //if (this.cboStoreageLocCode.Value.ToString() == "")
                //{
                //    this.ShowDialog("MM00029", Forms.DialogForm.DialogType.OK); //저장위치를 선택하세요.
                //    return;
                //}

            }

            bool flgTranjation_Finished_Error = false;

            DBHelper helper = new DBHelper("", false);

            try
            {
                //base.DoSave();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue;

                    //출고취소 수량 < LOT 기본수량 비교
                    if (tabControl1.SelectedTab.Index == 1)
                    {
                        int sQty = Convert.ToInt16(dt.Rows[i]["STOCKQTY"]);
                        int sBaseQty = Convert.ToInt16(dt.Rows[i]["LOTBASEQTY"]);
                        if (sQty == 0)
                        {
                            this.ShowDialog(Common.getLangText("출고취소 변경수량을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                            helper.Rollback();
                            return;
                        }

                        if (sQty > sBaseQty)
                        {
                            this.ShowDialog(Common.getLangText("출고취소 변경수량은 LOT 기본수량을 초과할 수 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                            helper.Rollback();
                            return;
                        }
                    }

                    //생산출고 등록 / 취소
                    helper.ExecuteNoneQuery("USP_MM0350_I1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE", Convert.ToString(dt.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("LOTNO", Convert.ToString(dt.Rows[i]["MATLOTNO"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ITEMCODE", Convert.ToString(dt.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("QTY", Convert.ToString(dt.Rows[i]["STOCKQTY"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("UnitCode", Convert.ToString(dt.Rows[i]["UnitCode"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("TABCONTROL", CheckTabControl, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WhCode", Convert.ToString(cboWhCode.Value), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("STORAGELOCCODE", Convert.ToString(cboStoreageLocCode.Value), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        flgTranjation_Finished_Error = true;
                        //if (tabControl1.SelectedTab.Index == 0) grid1.SetRowError(dt.Rows[i], helper.RSMSG, helper.RSCODE);
                        //if (tabControl1.SelectedTab.Index == 1) grid2.SetRowError(dt.Rows[i], helper.RSMSG, helper.RSCODE);
                    }

                    //선입선출 위반시
                    if (helper.RSCODE == "X")
                    {
                        if (this.ShowDialog(Common.getLangText("선입 자재가 존재합니다. 그래도 진행 하시겠습니까?", "MSG"), Forms.DialogForm.DialogType.YESNO) == DialogResult.Cancel)
                        {
                            helper.Rollback();
                            DoInquire();
                            return;
                        }
                    }
                }

                if (flgTranjation_Finished_Error == true)
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    helper.Rollback();
                    return;
                }
                else
                {
                    if (tabControl1.SelectedTab.Index == 0) grid1.SetAcceptChanges();
                    if (tabControl1.SelectedTab.Index == 1) grid2.SetAcceptChanges();
                    this.ShowDialog(Common.getLangText("데이터가 저장되었습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    helper.Commit();
                    this.ClosePrgFormNew();

                    DoInquire();
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
            Common _Common = new Common();

            if (tabControl1.SelectedTab.Index == 0)
            {
                lblWhcode.Text = "출고창고";
                lblStoreageLocCode.Text = "출고저장위치";

                rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE", "MINORCODE IN ('WH003', 'WH004', 'WH005', 'WH006')");  //출고 창고
                WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                cboWhCode.Value = "WH003";

            }
            else
            {
                lblWhcode.Text = "입고창고";
                lblStoreageLocCode.Text = "입고저장위치";

                rtnDtTemp = _Common.GET_BM0000_CODE("WHCODE", "MINORCODE IN ('WH001','WH002')");  //입고 창고
                WIZ.Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                cboWhCode.Value = "WH001";

            }
            if (ChkInquire == "true") return;
            DoInquire();
        }

        private void cboWhCode_ValueChanged(object sender, EventArgs e)
        {
            Common _Common = new Common();
            rtnDtTemp = _Common.GET_BM0000_CODE("STORAGELOCCODE", "RELCODE1 = '" + cboWhCode.Value + "'");  // 저장위치
            WIZ.Common.FillComboboxMaster(this.cboStoreageLocCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
        }
    }
}

