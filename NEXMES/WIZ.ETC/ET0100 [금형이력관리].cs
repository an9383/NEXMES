#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : ET0000
//   Form Name    : 금형수리현황
//   Name Space   : WIZ.MD
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 금형수리현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using WIZ;
using WIZ.PopUp;

#endregion

namespace WIZ.ETC
{
    public partial class ET0100 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        int CheckCount = 0;
        Common _Common = new Common();

        #endregion

        #region < CONSTRUCTOR >
        public ET0100()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >

        private void ET0100_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "MOLDCODE", "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MOLDNAME", "금형명",   false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DEGREE",   "차수",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "GRADE",    "금형등급", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "CHECKTIME", "점검일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MINORCODE", "점검번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CODENAME",  "점검사항", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "RESULT",    "점검결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid2, "ETC1",      "비고",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, true);

            _GridUtil.SetInitUltraGridBind(grid3);

            _GridUtil.InitializeGrid(this.grid3, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid3, "MOLDCODE",  "금형코드", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "CHECKCODE", "점검번호", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "CHECKTEXT", "점검사항", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "CODENAME",  "점검결과", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKEDATE",  "점검일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "MAKER",     "사용자",   false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid3, "ETC1",      "비고",     false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid3);

            #endregion

            //COMBOBOX SETTING 

            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            cbo_PLANTCODE_H.Value = LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("MOLDCHECK2");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "RESULT", rtnDtTemp, "CODE_ID", "CODE_NAME");
        }
        #endregion

        #region POPUP SETTING

        #endregion

        #region < TOOL BAR AREA >

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                ds = helper.FillDataSet("USP_MD0100_S1", CommandType.StoredProcedure);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = ds.Tables[0];
                    grid1.DataBinds();
                }

                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }


                if (ds.Tables[1].Rows.Count > 0)
                {
                    grid2.DataSource = ds.Tables[1];
                    grid2.DataBinds();
                }

                else
                {
                    ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), Forms.DialogForm.DialogType.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {

        }

        public override void DoSave()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (txtMOLDCODE.Text == "")
                {
                    this.ShowDialog("금형을 선택해주세요.", Forms.DialogForm.DialogType.OK);
                }
                else
                {
                    for (int i = 0; i < grid2.Rows.Count; i++)
                    {
                        helper.ExecuteNoneQuery("USP_MD0100_SAVE", CommandType.StoredProcedure
                            , helper.CreateParameter("AS_PLANTCODE", LoginInfo.PlantCode, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_USER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String, ParameterDirection.Input)

                            , helper.CreateParameter("AS_MOLDCODE",  txtMOLDCODE.Text, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CHECKCODE", grid2.Rows[i].Cells["MINORCODE"].Value, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_CHECKTEXT", grid2.Rows[i].Cells["CODENAME"].Value, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_RESULT",    grid2.Rows[i].Cells["RESULT"].Value, DbType.String, ParameterDirection.Input)
                            , helper.CreateParameter("AS_ETC1",      grid2.Rows[i].Cells["ETC1"].Value, DbType.String, ParameterDirection.Input));
                    }

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    helper.Commit();
                    this.ShowDialog("금형점검이 완료되었습니다.", Forms.DialogForm.DialogType.OK);
                    DoInquire();
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }

        public override void DoDelete()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                if (this.ShowDialog("금형점검내역을 삭제하시겠습니까?", Forms.DialogForm.DialogType.YESNO) == DialogResult.OK)
                {
                    helper.ExecuteNoneQuery("USP_MD0100_D1", CommandType.StoredProcedure
                        , helper.CreateParameter("AS_MOLDCODE", grid3.ActiveRow.Cells["MOLDCODE"].Value, DbType.String, ParameterDirection.Input)
                        , helper.CreateParameter("AS_TIME",     grid3.ActiveRow.Cells["MAKEDATE"].Value, DbType.String, ParameterDirection.Input));

                    if (helper.RSCODE == "E")
                    {
                        throw new Exception(helper.RSMSG);
                    }

                    helper.Commit();
                    this.ShowDialog("금형점검내역이 삭제되었습니다.", Forms.DialogForm.DialogType.OK);
                    DoInquire();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }

            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }

        public override void DoImportExcel()
        {
            base.DoImportExcel();
            base.DoInquire();
        }

        #endregion

        #region < METHOD AREA >

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.Grid_Clear(grid3);
            try
            {
                txtMOLDNAME.Text  = Convert.ToString(grid1.ActiveRow.Cells["MOLDNAME"].Value);
                txtMOLDGRADE.Text = Convert.ToString(grid1.ActiveRow.Cells["GRADE"].Value);
                txtMOLDCODE.Text  = Convert.ToString(grid1.ActiveRow.Cells["MOLDCODE"].Value);
                txtUSERID.Text    = LoginInfo.UserID;

                ds = helper.FillDataSet("USP_MD0100_S2", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_MOLDCODE", grid1.ActiveRow.Cells["MOLDCODE"].Value, DbType.String, ParameterDirection.Input));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid3.DataSource = ds.Tables[0];
                    grid3.DataBinds();
                }

                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
    }
}
