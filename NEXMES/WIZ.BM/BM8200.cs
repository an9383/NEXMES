#region < HEADER AREA >
/******************************************************************
 * 1. 작성자   : 
 * 2. 작성일자 : 
 * 3. 수정자   : 
 * 4. 수정일자 :
 * 5. 화면설명 : 품목별 제품검사 관리(BM8200)
******************************************************************/
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM8200 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        Common _Common = new Common();
        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        BizTextBoxManager btbManager = new BizTextBoxManager();
        DataTable rtnDtTemp = new DataTable();

        private string sPlantCode = string.Empty;
        private double UPH = -1;
        int Grid2Index = 0;

        #endregion

        #region < CONSTRUCTOR >
        public BM8200()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM8200_Load(object sender, EventArgs e)
        {
            try
            {
                BizGridManager gridManager_grid1 = new BizGridManager(grid1);
                BizGridManager gridManager_grid2 = new BizGridManager(grid2);

                #region [ grid ]
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "측정값구분", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);

                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(this.grid2, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPCODE", "검사코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "VALUETYPE", "측정값구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECTYPE", "SPEC 적용기준", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECUSL", "상한값", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "SPECLSL", "하한값", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Center, true, true, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 140, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);


                grid2.DisplayLayout.Bands[0].Columns["SPECTYPE"].Header.Appearance.ForeColor = Color.SkyBlue;

                _GridUtil.SetInitUltraGridBind(grid2);

                //     ///row number
                grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
                grid1.DisplayLayout.Override.RowSelectorWidth = 50;
                grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
                grid2.DisplayLayout.Override.RowSelectorWidth = 50;
                grid2.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grid2.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                #endregion

                #region [ PopUp & ComboBox ]
                //Form Load 시 로그인 시 선택한 공장 표시
                sPlantCode = CModule.GetAppSetting("Site", "10");

                btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { "", "" });
                btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { "", "" });

                DataTable rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE"); //측정값구분
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "VALUETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE"); //SPEC 적용기준
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "SPECTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion
            }
            catch
            {

            }
        }

        #endregion

        #region [ Toolbar Area ]
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = WIZ.LoginInfo.PlantCode;
                string sItemCode = Convert.ToString(this.txtItemCode_H.Text);

                if (sItemCode == string.Empty)
                {
                    this.ClosePrgFormNew();

                    this.ShowDialog(Common.getLangText("품목을 선택 후 조회하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                if (ItemCodeChk() == false)
                {
                    this.ClosePrgFormNew();

                    this.ShowDialog(Common.getLangText("품목을 확인하세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }

                base.DoInquire();

                //해당 작업장에 등록되지 않은 모든 품목 조회
                grid1.DataSource = helper.FillTable("USP_BM8200_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)         //공장
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));       //라인

                grid1.DataBinds();

                //해당 작업장에 등록된 품목 조회
                grid2.DataSource = helper.FillTable("USP_BM8200_S2", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)         //공장
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input));       //라인

                grid2.DataBinds();

                grid1.DisplayLayout.Bands[0].Columns["INSPCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["INSPNAME"].CellActivation = Activation.NoEdit;

                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["INSPCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["INSPNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;

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
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            UltraGridUtil.DataRowDelete(this.grid2);
            this.grid2.UpdateData();
            if (((DataTable)grid2.DataSource).GetChanges() == null)
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in ((DataTable)grid2.DataSource).GetChanges().Rows)
                {
                    //if (drRow.RowState == DataRowState.Added)
                    //{
                    //    if (Convert.ToString(drRow["VALUETYPE"]) == "V" || Convert.ToString(drRow["VALUETYPE"]) == "J")
                    //    {
                    //        if (Convert.ToString(drRow["SPECTYPE"]) == "B")
                    //        {
                    //            if (Convert.ToString(drRow["SPECUSL"]) == "" || Convert.ToString(drRow["SPECLSL"]) == "")
                    //            {
                    //                this.ShowDialog(Common.getLangText("상한값과 하한값을 입력해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    //                return;
                    //            }

                    //            if (Convert.ToInt64(drRow["SPECUSL"]) <= Convert.ToInt64(drRow["SPECLSL"]))
                    //            {
                    //                this.ShowDialog(Common.getLangText("상한값은 하한값보다 값이 커야합니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    //                return;
                    //            }
                    //        }
                    //        else if (Convert.ToString(drRow["SPECTYPE"]) == "L")
                    //        {
                    //            if (Convert.ToString(drRow["SPECLSL"]) == "")
                    //            {
                    //                this.ShowDialog(Common.getLangText("하한값을 입력해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    //                return;
                    //            }

                    //            if (!(Convert.ToString(drRow["SPECUSL"]) == ""))
                    //            {
                    //                this.ShowDialog(Common.getLangText("하한관리에서 상한값은 입력사항이 아닙니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    //                return;
                    //            }
                    //        }
                    //        else if (Convert.ToString(drRow["SPECTYPE"]) == "U")
                    //        {
                    //            if (Convert.ToString(drRow["SPECUSL"]) == "")
                    //            {
                    //                this.ShowDialog(Common.getLangText("상한값을 입력해주세요.", "MSG"), Forms.DialogForm.DialogType.OK);
                    //                return;
                    //            }

                    //            if (!(Convert.ToString(drRow["SPECLSL"]) == ""))
                    //            {
                    //                this.ShowDialog(Common.getLangText("상한관리에서 하한값은 입력사항이 아닙니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    //                return;
                    //            }
                    //        }
                    //    }
                    //}

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM8200_D1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)                       // 공장코드
                            , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input));           // 품목
                            drRow.Delete();
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            string sPlantCode = Convert.ToString(drRow["PLANTCODE"]);
                            helper.ExecuteNoneQuery("USP_BM8200_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("AS_SPECTYPE", Convert.ToString(drRow["SPECTYPE"]), DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("AS_SPECLSL", Convert.ToString(drRow["SPECLSL"]), DbType.String, ParameterDirection.Input)
                                                    //, helper.CreateParameter("AS_SPECUSL", Convert.ToString(drRow["SPECUSL"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            sPlantCode = Convert.ToString(drRow["PLANTCODE"]);

                            helper.ExecuteNoneQuery("USP_BM8200_U1", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ITEMCODE", Convert.ToString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }
                this.ClosePrgFormNew();
                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.ShowDialog(Common.getLangText("데이터가 저장 되었습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

                    DoInquire();
                }
                else
                {
                    // 데이터 등록을 실패하였습니다.
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, WIZ.Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ClosePrgFormNew();
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                Grid2Index = 0;
                helper.Close();
            }
        }
        #endregion

        #region [ User Method Area ]
        private bool ItemCodeChk()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder command = new StringBuilder();
                string sItemCode = txtItemCode_H.Text;

                command.AppendLine("SELECT ITEMCODE                             AS CODE_ID,           ");
                command.AppendLine("      ITEMNAME                              AS CODE_NAME        ");
                command.AppendLine("  FROM TBM0100Y                                                         ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                                    ");
                command.AppendLine("   AND ITEMCODE = '" + sItemCode + "'                                  ");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                if (dttemp.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
                return false;
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ Event Area ]

        /// <summary>
        /// 품목 추가
        /// </summary>
        private void btnAddInspCode_Click(object sender, EventArgs e)
        {
            try
            {
                rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE"); //측정값구분
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "VALUETYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");     //사용여부
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("SPECTYPE"); //SPEC 적용기준
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "SPECTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                if (this.grid1.Rows.Count == 0) return;

                string sPlantCode = string.Empty;
                string sItemCode = string.Empty;
                string sItemName = string.Empty;

                if (this.grid2.Rows.Count != 0)
                {
                    sPlantCode = this.grid2.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                    sItemCode = this.grid2.ActiveRow.Cells["ITEMCODE"].Value.ToString();
                    sItemName = this.grid2.ActiveRow.Cells["ITEMNAME"].Value.ToString();
                }
                else
                {
                    sPlantCode = WIZ.LoginInfo.PlantCode;
                    sItemCode = this.txtItemCode.Text;
                    sItemName = this.txtItemName.Text;
                }


                this.grid2.InsertRow();
                this.grid2.ActiveRow.Cells["PLANTCODE"].Value = sPlantCode;
                this.grid2.ActiveRow.Cells["ITEMCODE"].Value = sItemCode;
                this.grid2.ActiveRow.Cells["ITEMNAME"].Value = sItemName;
                this.grid2.ActiveRow.Cells["INSPCODE"].Value = this.grid1.ActiveRow.Cells["INSPCODE"].Value.ToString();
                this.grid2.ActiveRow.Cells["INSPNAME"].Value = this.grid1.ActiveRow.Cells["INSPNAME"].Value.ToString();
                //this.grid2.ActiveRow.Cells["VALUETYPE"].Value = this.grid1.ActiveRow.Cells["VALUETYPE"].Value.ToString();
                this.grid2.ActiveRow.Cells["USEFLAG"].Value = "Y";

                //if (Convert.ToString(grid2.ActiveRow.Cells["VALUETYPE"].Value) == "J")
                //{
                //    grid2.ActiveRow.Cells["SPECTYPE"].Activation = Activation.NoEdit;
                //    grid2.ActiveRow.Cells["SPECUSL"].Activation = Activation.NoEdit;
                //    grid2.ActiveRow.Cells["SPECLSL"].Activation = Activation.NoEdit;
                //}

                int Gird1Index = this.grid1.ActiveRow.Index - 1;
                this.grid1.DeleteRow();
                if (this.grid1.Rows.Count == 0) return;
                if (Gird1Index == -1) this.grid1.Rows[0].Activated = true;
                else this.grid1.Rows[Gird1Index].Activated = true;

                grid2.ActiveRow.Cells["PLANTCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["ITEMCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["ITEMNAME"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["INSPCODE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["INSPNAME"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
                grid2.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;

                grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["INSPCODE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["INSPNAME"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Activation.NoEdit;
                grid2.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// 작업장별 품목 등록 내역 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelInspItemCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grid2.Rows.Count == 0) return;
                string sInspCode2 = this.grid2.ActiveRow.Cells["INSPCODE"].Value.ToString();
                string sInspName2 = this.grid2.ActiveRow.Cells["INSPNAME"].Value.ToString();
                //string sValueType = this.grid2.ActiveRow.Cells["ValueTYPE"].Value.ToString();

                int Gird1Index = this.grid2.ActiveRow.Index - 1;
                this.grid2.DeleteRow();
                if (this.grid2.Rows.Count == 0)
                {
                    this.grid1.InsertRow();

                    this.grid1.ActiveRow.Cells["INSPCODE"].Value = sInspCode2;
                    this.grid1.ActiveRow.Cells["INSPNAME"].Value = sInspName2;
                    //this.grid1.ActiveRow.Cells["VALUETYPE"].Value = sValueType;
                    return;
                }
                else
                {
                    if (Gird1Index == -1) this.grid2.Rows[0].Activated = true;
                    else this.grid2.Rows[Gird1Index].Activated = true;

                    this.grid1.InsertRow();

                    this.grid1.ActiveRow.Cells["INSPCODE"].Value = sInspCode2;
                    this.grid1.ActiveRow.Cells["INSPNAME"].Value = sInspName2;
                    //this.grid1.ActiveRow.Cells["VALUETYPE"].Value = sValueType;
                }

                grid1.ActiveRow.Cells["INSPCODE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["INSPNAME"].Activation = Activation.NoEdit;

                grid1.DisplayLayout.Bands[0].Columns["INSPCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["INSPNAME"].CellActivation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        private void txtItemCode_ValueChanged(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                StringBuilder command = new StringBuilder();
                string sItemCode = txtItemCode.Text;

                command.AppendLine("SELECT ITEMCODE                             AS CODE_ID,           ");
                command.AppendLine("      ITEMNAME                              AS CODE_NAME        ");
                command.AppendLine("  FROM TBM0100Y                                                         ");
                command.AppendLine(" WHERE USEFLAG = 'Y'                                                    ");
                command.AppendLine("   AND ITEMCODE = '" + sItemCode + "'                                  ");

                DataTable dttemp = helper.FillTable(command.ToString(), CommandType.Text);
                if (dttemp.Rows.Count > 0)
                {
                    txtItemName.Text = Convert.ToString(dttemp.Rows[0]["CODE_NAME"]);
                }

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        private void txtItemCode_H_ValueChanged(object sender, EventArgs e)
        {
            txtItemCode.Text = txtItemCode_H.Text;
        }
    }
}
