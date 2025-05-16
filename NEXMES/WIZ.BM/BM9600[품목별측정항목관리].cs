#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM9600
//   Form Name    : 품목별측정항목관리
//   Name Space   : WIZ.BM
//   Created Date : 2017-01-25
//   Made By      : WIZCORE 남부사무소 개발팀 사원 윤근욱
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM9600 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();   //그리드 객체 생성

        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();

        DataTable rtnDtTemp = new DataTable();

        string sPlantCode = "";
        string sItemCode = "";
        string sUseFlag = "";
        string sMesrCode = "";

        Image img;
        #endregion

        #region < CONSTRUCTOR >
        public BM9600()
        {
            InitializeComponent();

        }
        #endregion

        #region < FORM LOAD >
        private void BM9600_Load(object sender, EventArgs e)
        {

            GridInitialize();

            #region < COMBOBOX >

            //사업장
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cboPlantCode_H.Value = WIZ.LoginInfo.PlantCode;

            //사용여부
            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid3, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cboUseFlag_H.Value = "Y";

            //SPEC구분(상한관리, 하한관리, 양쪽관리)
            rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "SPECTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //측정구분(값, 판정)
            rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "VALUETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region < POP-UP >
            //품목
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "", "" });
            //측정항목
            btbManager.PopUpAdd(txtMesrCode, txtMesrName, "TBM6100", new object[] { cboPlantCode_H, "" });
            #endregion

        }

        #region < GRID >
        private void GridInitialize()
        {
            try
            {
                //GRID1- 품목별 측정항목
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MESRCODE", "측정항목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MESRNAME", "측정항목명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "측정구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECTYPE", "관리구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "REMARK", "비고", false, GridColDataType_emu.VarChar, 500, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", false, GridColDataType_emu.DateTime24, 170, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", false, GridColDataType_emu.DateTime24, 170, 140, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MESRCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["MESRNAME"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["VALUETYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECNOL"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECUSL"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid1.DisplayLayout.Bands[0].Columns["SPECLSL"].Header.Appearance.ForeColor = Color.SkyBlue;


                // GRID2 - 품목
                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "REMARK", "비고", false, GridColDataType_emu.VarChar, 250, 100, Infragistics.Win.HAlign.Left, true, false);


                _GridUtil.SetInitUltraGridBind(grid2);

                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Appearance.ForeColor = Color.SkyBlue;


                //GRID3 - 측정항목
                _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid3, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MESRCODE", "측정항목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "MESRNAME", "측정항목명", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid3, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

                _GridUtil.SetInitUltraGridBind(grid3);

                grid3.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["MESRCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
                grid3.DisplayLayout.Bands[0].Columns["MESRNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
        #endregion

        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);
            _GridUtil.Grid_Clear(grid1);
            _GridUtil.Grid_Clear(grid2);
            _GridUtil.Grid_Clear(grid3);

            try
            {
                sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                sItemCode = Convert.ToString(this.txtItemCode_H.Value);
                sMesrCode = Convert.ToString(this.txtMesrCode.Value);
                sUseFlag = Convert.ToString(this.cboUseFlag_H.Value);

                base.DoInquire();

                //품목조회
                rtnDtTemp = helper.FillTable("USP_BM9600_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid2.DataSource = rtnDtTemp;
                        grid2.DataBinds();
                    }
                    else
                    {
                        this.ClosePrgFormNew();
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }

                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid2);
                }


                //측정항목조회
                rtnDtTemp = helper.FillTable("USP_BM9600_S2", CommandType.StoredProcedure
                                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_MESRCODE", sMesrCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid3.DataSource = rtnDtTemp;
                        grid3.DataBinds();
                    }
                    else
                    {
                        this.ClosePrgFormNew();
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                    _GridUtil.Grid_Clear(grid1);
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
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
            DataTable dt = grid1.chkChange();
            DateTime NOW = DateTime.Now;

            if (dt == null) { return; }

            DBHelper helper = new DBHelper("", true);

            try
            {
                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    if (DBHelper.nvlString(drRow["VALUETYPE"]) == "")
                    {
                        this.ShowDialog(Common.getLangText("측정구분은 필수항목입니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }

                    //측정구분이 값일경우
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


                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            break;
                        case DataRowState.Added:
                            helper.ExecuteNoneQuery("USP_BM9600_I1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MESRCODE", DBHelper.nvlString(drRow["MESRCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_VALUETYPE", DBHelper.nvlString(drRow["VALUETYPE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SPECTYPE", DBHelper.nvlString(drRow["SPECTYPE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_UNITCODE", DBHelper.nvlString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AD_SPECNOL", drRow["SPECNOL"], DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AD_SPECUSL", drRow["SPECUSL"], DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AD_SPECLSL", drRow["SPECLSL"], DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MAKER", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            break;

                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("USP_BM9600_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", DBHelper.nvlString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_MESRCODE", DBHelper.nvlString(drRow["MESRCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_SPECTYPE", DBHelper.nvlString(drRow["SPECTYPE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_VALUETYPE", DBHelper.nvlString(drRow["VALUETYPE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_UNITCODE", DBHelper.nvlString(drRow["UNITCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AD_SPECNOL", drRow["SPECNOL"], DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AD_SPECUSL", drRow["SPECUSL"], DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AD_SPECLSL", drRow["SPECLSL"], DbType.Double, ParameterDirection.Input)
                            , helper.CreateParameter("AS_REMARK", DBHelper.nvlString(drRow["REMARK"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                            break;
                    }

                    if (helper.RSCODE == "S")
                    {
                        this.ClosePrgFormNew();
                        helper.Commit();
                    }
                    else if (helper.RSCODE == "E")
                    {
                        this.ClosePrgFormNew();
                        CancelProcess = true;
                        helper.Rollback();
                        this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                    }
                }

                this.ShowDialog(Common.getLangText("저장되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();
                DoInquire();
            }
        }

        #endregion

        #region < EVENT >

        #region < GRID_EVENT >

        //품목별 측정항목 GRID Cell 클릭
        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sMesrCode = Convert.ToString(grid1.ActiveRow.Cells["MESRCODE"].Value);

            byte[] bImage = GetImage(sPlantCode, sItemCode, sMesrCode);

            if (bImage != null)
            {
                MemoryStream MS = new MemoryStream(bImage);
                img = new Bitmap(MS);
                picView.Image = img;
            }
            else
            {
                picView.Image = null;
            }
        }

        //품목 GRID Cell 클릭
        private void grid2_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                string sItemCode = Convert.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
                string sMesrCode = Convert.ToString(grid3.ActiveRow.Cells["MESRCODE"].Value);
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);

                //품목별 측정항목 조회
                rtnDtTemp = helper.FillTable("USP_BM9600_S3", CommandType.StoredProcedure
                                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);

                    _GridUtil.Grid_Clear(grid1);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();
            }
        }

        private void grid1_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "VALUETYPE")
            {
                if (e.Cell.Column.Editor.Value.ToString() == "V")
                {
                    grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.AllowEdit;
                }
                else
                {
                    grid1.ActiveRow.Cells["SPECNOL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;
                    grid1.ActiveRow.Cells["SPECTYPE"].Value = "";
                    grid1.ActiveRow.Cells["UNITCODE"].Value = "";

                    grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;

                }
            }

            else if (e.Cell.Column.ToString() == "SPECTYPE")
            {
                if (e.Cell.Column.Editor.Value.ToString() == "U")
                {
                    grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;

                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                }
                else if (e.Cell.Column.Editor.Value.ToString() == "L")
                {
                    grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;

                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
                }
                else if (e.Cell.Column.Editor.Value.ToString() == "B")
                {
                    grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                    grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
                }
            }

        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {

            if (grid1.ActiveRow.Cells["VALUETYPE"].Value.ToString() == "V")
            {
                grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.AllowEdit;
            }
            else
            {
                grid1.ActiveRow.Cells["SPECNOL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;
                grid1.ActiveRow.Cells["SPECTYPE"].Value = "";
                grid1.ActiveRow.Cells["UNITCODE"].Value = "";

                grid1.ActiveRow.Cells["SPECTYPE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["UNITCODE"].Activation = Activation.NoEdit;

            }

            if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "U")
            {
                grid1.ActiveRow.Cells["SPECLSL"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
            }
            else if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "L")
            {
                grid1.ActiveRow.Cells["SPECUSL"].Value = DBNull.Value;

                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
            }
            else if (grid1.ActiveRow.Cells["SPECTYPE"].Value.ToString() == "B")
            {
                grid1.ActiveRow.Cells["SPECNOL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECUSL"].Activation = Activation.AllowEdit;
                grid1.ActiveRow.Cells["SPECLSL"].Activation = Activation.AllowEdit;
            }
        }
        #endregion

        #region < Image Upload & View >

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null)
            {
                return;
            }

            DialogResult drResult;

            //등록할 이미지 or 파일 찾기
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "비트맵 (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|사용 가능한 이미지 파일|*.bmp;*.gif;*.jpg;*.png";
            openFileDlg.FilterIndex = 5;
            openFileDlg.RestoreDirectory = true;
            drResult = openFileDlg.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                drResult = this.ShowDialog(Common.getLangText("업로드 하시겠습니까?", "MSG"), WIZ.Forms.DialogForm.DialogType.YESNO);

                // 이미지 파일 저장          
                if (!string.IsNullOrEmpty(openFileDlg.FileName) && drResult.ToString() == "OK")
                {
                    string strFile = System.IO.Path.GetFileName(openFileDlg.FileName);

                    Bitmap bitMap = new Bitmap(openFileDlg.FileName);

                    MemoryStream ms = new MemoryStream();
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] bImage = ms.ToArray();

                    picView.Image = bitMap;

                    ms.Dispose();

                    DBHelper helper = new DBHelper("", true);

                    string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                    string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                    string sMesrCode = Convert.ToString(grid1.ActiveRow.Cells["MESRCODE"].Value);


                    // 이미지 저장 프로시저
                    try
                    {
                        helper.ExecuteNoneQuery("USP_BM9600_U2", CommandType.StoredProcedure
                      , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AS_MESRCODE", sMesrCode, DbType.String, ParameterDirection.Input)
                      , helper.CreateParameter("AB_IMG", bImage, DbType.Binary, ParameterDirection.Input)
                      , helper.CreateParameter("AS_EDITOR", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input));

                        if (helper.RSCODE == "S")
                        {
                            this.ClosePrgFormNew();
                            helper.Commit();
                            this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                        }
                        else if (helper.RSCODE == "E")
                        {
                            this.ClosePrgFormNew();
                            CancelProcess = true;
                            helper.Rollback();
                            this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        CancelProcess = true;
                        helper.Rollback();
                        ShowErrorMessage(ex);
                    }
                    finally
                    {
                        helper.Close();
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null)
            {
                return;
            }


            string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sMesrCode = Convert.ToString(grid1.ActiveRow.Cells["MESRCODE"].Value);

            byte[] bImage = GetImage(sPlantCode, sItemCode, sMesrCode);

            if (bImage != null)
            {
                IMAGEVIEW_POP pop_ImageView = new IMAGEVIEW_POP(bImage);
                pop_ImageView.ShowDialog();
            }
            else
            {
                this.ShowDialog(Common.getLangText("등록된 이미지가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
        }

        #endregion

        #region < 품목별 측정항목 신규 Row 추가 >
        private void btnDoNew_Click(object sender, EventArgs e)
        {
            if (grid2.ActiveRow == null || grid3.ActiveRow == null)
            {
                this.ShowDialog(Common.getLangText("품목과 측정항목을 선택해주세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                return;
            }
            try
            {
                //기존 Row와 중복여부 조회
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["MESRCODE"].Value.ToString() == grid3.ActiveRow.Cells["MESRCODE"].Value.ToString())
                    {
                        this.ShowDialog(Common.getLangText("등록하고자 하는 측정항목이 중복됩니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }

                //신규 Row 추가
                base.DoNew();

                int iRow = 0;

                iRow = this.grid1.InsertRow();

                this.grid1.Rows[iRow].Cells["PLANTCODE"].Value = Convert.ToString(grid2.ActiveRow.Cells["PLANTCODE"].Value);
                this.grid1.Rows[iRow].Cells["ITEMCODE"].Value = Convert.ToString(grid2.ActiveRow.Cells["ITEMCODE"].Value);
                this.grid1.Rows[iRow].Cells["ITEMNAME"].Value = Convert.ToString(grid2.ActiveRow.Cells["ITEMNAME"].Value);
                this.grid1.Rows[iRow].Cells["MESRCODE"].Value = Convert.ToString(grid3.ActiveRow.Cells["MESRCODE"].Value);
                this.grid1.Rows[iRow].Cells["MESRNAME"].Value = Convert.ToString(grid3.ActiveRow.Cells["MESRNAME"].Value);
                this.grid1.Rows[iRow].Cells["USEFLAG"].Value = "Y";

                grid1.UpdateData();

                grid1.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MESRCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["MESRNAME"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
        #endregion

        #endregion

        #region < METHOD AREA >

        private byte[] GetImage(string sPlantCode, string sItemCode, string sMesrCode)
        {
            byte[] bImage = null;

            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM9600_GETIMAGE", CommandType.StoredProcedure
                          , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                          , helper.CreateParameter("AS_MESRCODE", sMesrCode, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {

                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            finally
            {
                helper.Close();

            }

            if (rtnDtTemp.Rows.Count > 0 && rtnDtTemp.Rows[0]["IMG"] != DBNull.Value)
            {
                bImage = (byte[])rtnDtTemp.Rows[0]["IMG"];
            }

            return bImage;
        }

        #endregion   
    }
}
