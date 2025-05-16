#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM8100
//   Form Name    : 제품검사 항목관리
//   Name Space   : WIZ.BM
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
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM8100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        private string plantCode = string.Empty; //plantcode default 설정
        private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public BM8100()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >
        private void BM8100_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사코드", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 30, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            //_GridUtil.InitColumnUltraGrid(grid1, "VALUETYPE", "측정값구분", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left,   true, true,  null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar, 80, 500, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].Header.Appearance.ForeColor = Color.SkyBlue;
            grid1.DisplayLayout.Bands[0].Columns["INSPNAME"].Header.Appearance.ForeColor = Color.SkyBlue;

            _GridUtil.SetInitUltraGridBind(grid1);

            this.plantCode = CModule.GetAppSetting("Site", "10");

            #region < COMBO BOX SETTING >
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");  //사용여부
            WIZ.Common.FillComboboxMaster(this.cboUseFlag_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("VALUETYPE"); //측정값구분
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ValueType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            btbManager.PopUpAdd(txtInspCode_H, txtInspName_H, "TBM8100", new object[] { cboPlantCode_H, cboUseFlag_H });

            cboPlantCode_H.Value = this.plantCode;
            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sInspCode = txtInspCode_H.Text;
                string sUseFlag = Convert.ToString(cboUseFlag_H.Value);

                rtnDtTemp = helper.FillTable("USP_BM8100_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("AS_USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;

                        grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["INSPCODE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["MAKER"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["EDITOR"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                    else
                    {
                        this.ClosePrgFormNew();
                        _GridUtil.Grid_Clear(grid1);
                        this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                        return;
                    }
                }
                else
                {
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                this.ClosePrgFormNew();
            }
        }

        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();
        }

        public override void DoNew()
        {
            base.DoNew();
            this.grid1.InsertRow();

            grid1.SetDefaultValue("PLANTCODE", this.plantCode);
            grid1.SetDefaultValue("USEFLAG", "Y");


            grid1.ActiveRow.Cells["INSPCODE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKER"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
        }

        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                if (this.ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                UltraGridUtil.DataRowDelete(this.grid1);

                this.grid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell);

                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["INSPNAME"].ToString().Length > 50)
                        {
                            this.ClosePrgFormNew();
                            grid1.SetRowError(drRow, "검사항목명은 최대 50자리까지 입력가능합니다.");
                            return;
                        }
                    }

                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("USP_BM8100_D1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input));
                            #endregion
                            break;

                        case DataRowState.Added:
                            #region 추가

                            helper.ExecuteNoneQuery("USP_BM8100_I1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_INSPNAME", Convert.ToString(drRow["INSPNAME"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_VALUETYPE", Convert.ToString(drRow["VALUETYPE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_MAKER", this.WorkerID, DbType.String, ParameterDirection.Input));

                            //if (helper.RSCODE == "S")
                            //    helper.Commit();


                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정

                            helper.ExecuteNoneQuery("USP_BM8100_U1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("AS_PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_INSPCODE", Convert.ToString(drRow["INSPCODE"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_INSPNAME", Convert.ToString(drRow["INSPNAME"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("AS_EDITOR", this.WorkerID, DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                }

                if (helper.RSCODE == "S")
                {
                    helper.Commit();
                    this.DoInquire();
                }
                else
                {
                    this.ClosePrgFormNew();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, Forms.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                CancelProcess = true;
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        #region [ User Method Area ]

        #endregion

        #region [ Event Area ]

        #endregion


    }
}
