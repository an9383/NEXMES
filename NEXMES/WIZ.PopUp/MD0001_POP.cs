#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0010
//   Form Name    : 품목마스터 POP-UP
//   Name Space   : WIZ.POPUP
//   Created Date : 2018-01-09
//   Made By      : WIZCORE 남부사무소 사원 정길상
//   Edited Date  : 
//   Edit By      :
//   Description  : 품목과 품목관련 기준정보 POP-UP
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WIZ;
using WIZ.PopUp;
#endregion


namespace WIZ.PopUp
{
    public partial class MD0001_POP : WIZ.Forms.BasePopupForm
    {
        #region < MEMBER AREA >

        string[] argument;

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();

        //비지니스 로직 객체 생성
        PopUp_Biz _biz = new PopUp_Biz();

        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >

        public MD0001_POP(string[] param)
        {
            InitializeComponent();

            InitGrid();

            argument = new string[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];

                #region [Parameter Show]
                switch (i)
                {
                    case 4:
                        cbo_USEFLAG_H.Text = argument[4].ToUpper() == "" ? "ALL" : argument[4].ToUpper(); //사용여부                   
                        break;
                }
                #endregion
            }

            Search();

        }
        #endregion

        #region < METHOD AREA >
        private void InitGrid()
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1);

                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CORE", "코아", false, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 250, 200, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DEGREE", "차수", false, GridColDataType_emu.VarChar, 80, 80, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CORENAME", "코아명", false, GridColDataType_emu.VarChar, 150, 150, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCOST", "단가", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LOC", "보관장소", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, true, true);

                _GridUtil.SetInitUltraGridBind(grid1);

                rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG"); //사용여부
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.Common.FillComboboxMaster(this.cbo_USEFLAG_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);

                rtnDtTemp = _Common.GET_BM0090_CODE_ALL(); //모든창고
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "LOC", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0010_CODE("");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Search()
        {
            string RS_CODE = string.Empty;
            string RS_MSG = string.Empty;
            string sPlantCode = string.Empty;
            string sItemType = string.Empty;
            string sItemCode = string.Empty;
            string sItemName = string.Empty;
            string sUseFlag = string.Empty;

            _DtTemp = _biz.SEL_MD0001(sPlantCode, sItemCode, sItemName, sItemType, sUseFlag);

            grid1.DataSource = _DtTemp;
            grid1.DataBind();
        }

        #endregion

        #region < EVENT AREA >

        private void grid1_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (DBHelper.nvlString(e.Row.Cells["CORE"].Value) != "[ NEW CORE ]")
            {
                DataTable TmpDt = new DataTable();
                TmpDt.Columns.Add("CORE", typeof(string));
                TmpDt.Columns.Add("CORENAME", typeof(string));

                TmpDt.Rows.Add(new object[] { e.Row.Cells["CORE"].Value, e.Row.Cells["CORENAME"].Value });

                this.Tag = TmpDt;
                this.Close();
            }
        }

        private void btn_SEARCH_H_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            this.grid1.InsertRow();

            this.grid1.ActiveRow.Cells["CORE"].Value = "[ NEW CORE ]";
            this.grid1.ActiveRow.Cells["ITEMCODE"].Value = "";
            this.grid1.ActiveRow.Cells["DEGREE"].Value = 0;
            this.grid1.ActiveRow.Cells["CORENAME"].Value = "";
            this.grid1.ActiveRow.Cells["UNITCOST"].Value = 0;
            this.grid1.ActiveRow.Cells["LOC"].Value = "";
            this.grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";
        }

        private void btn_SAVE_Click(object sender, EventArgs e)
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                foreach (DataRow drRow in dt.Rows)
                {
                    if (drRow.RowState != DataRowState.Deleted)
                    {
                        if (drRow["CORENAME"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(drRow, Common.getLangText("코아명 미입력", "TEXT"));
                            continue;
                        }
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            /*
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("USP_BM0685_D1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("MAKEDATE", DBHelper.nvlDateTime(drRow["MAKEDATE"]), DbType.DateTime, ParameterDirection.Input));
                            */
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            helper.ExecuteNoneQuery("USP_MD0001_UJ_SAVE", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_CORE", DBHelper.nvlString(drRow["CORE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DEGREE", DBHelper.nvlString(drRow["DEGREE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CORENAME", DBHelper.nvlString(drRow["CORENAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_UNITCOST", DBHelper.nvlString(drRow["UNITCOST"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FLAG", "I", DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            helper.ExecuteNoneQuery("USP_MD0001_UJ_SAVE", CommandType.StoredProcedure
                                                    , helper.CreateParameter("AS_CORE", DBHelper.nvlString(drRow["CORE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_ITEMCODE", DBHelper.nvlString(drRow["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_DEGREE", DBHelper.nvlString(drRow["DEGREE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_CORENAME", DBHelper.nvlString(drRow["CORENAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_UNITCOST", DBHelper.nvlString(drRow["UNITCOST"]), DbType.Double, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_USEFLAG", DBHelper.nvlString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("AS_FLAG", "U", DbType.String, ParameterDirection.Input));
                            #endregion
                            break;
                    }
                    grid1.SetRowError(drRow, helper.RSMSG, helper.RSCODE);
                }
                grid1.SetAcceptChanges();
                helper.Commit();
                Search();
            }
            catch (SException ex)
            {
                CancelProcess = true;
                helper.Rollback();
                throw ex;
            }
            finally
            {


            }

            #endregion

        }
    }
}
