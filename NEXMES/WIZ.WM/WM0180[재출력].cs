#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM0180
//   Form Name    : 자재 출고이력
//   Name Space   : WIZ.WM
//   Created Date : 
//   Made By      : WIZCORE
//   Editor       : 
//   Edit Date    :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.WM
{
    public partial class WM0180 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통

        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common(); //콤보박스 객체 생성
        BizTextBoxManager btbManager = new BizTextBoxManager();
        DataRow drSubData;
        #endregion

        #region < CONSTRUCTOR >
        public WM0180()
        {
            InitializeComponent();
        }

        protected override void SetSubData()
        {
            base.SetSubData();

            drSubData = this.subData["METHOD_TYPE", "ADDBARCODE"];
        }
        #endregion

        #region < FORM LOAD >
        private void WM0180_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "바코드", false, GridColDataType_emu.VarChar, 300, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "위치 정보", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "INSERTTIME", "출력일시", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "REISSUE", "재출력정보", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CIP", "특정 프린트서버 위치", false, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Left, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion


                #region COMBOBOX SETTING
                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                #endregion

                cbo_STARTDATE_H.Value = DateTime.Now;
                cbo_ENDDATE_H.Value = DateTime.Now;

                //txt_LOTNO_H.Select();
            }
            catch (Exception ex)
            {
                //Common.getLangText(해당 텍스트, 팝업창일 경우 "MSG", 나머지는 "TEXT") -> 다국어를 위한 기능이므로 필히 활용바람
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }
        #endregion 

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            base.DoInquire();

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);

                rtnDtTemp = helper.FillTable("USP_WM0180_S1", CommandType.StoredProcedure
                                             , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_LOTNO", txtBarcode_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_WORKCENTERCODE", txtWorkCenterCode_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("AS_CIP", txtCIP_H.Text.Trim(), DbType.String, ParameterDirection.Input)
                                             );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds();
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    return;
                }

                chkAddBarcode.Checked = false;
            }
            catch (Exception ex)
            {
                ClosePrgFormNew();
                this.ShowDialog(ex.Message.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
                ClosePrgFormNew();
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DBHelper helper;
            helper = new DBHelper(false);
            StringBuilder sSQL = new StringBuilder();

            bool bOpenMsg = true;

            try
            {
                if (chkAddBarcode.Checked)
                {
                    if (drSubData != null)
                    {
                        try
                        {
                            sSQL = new StringBuilder();
                            sSQL.Append("Select " + CModule.ToString(drSubData["RELCODE3"]) + " from " + CModule.ToString(drSubData["RELCODE1"]) + " with (NOLOCK) ");
                            sSQL.Append(" where PLANTCODE = '" + LoginInfo.PlantCode + "' ");
                            sSQL.Append("   and " + CModule.ToString(drSubData["RELCODE2"]) + " = '" + txtBarcode.Text.Trim() + "' ");

                            DataTable dt = helper.FillTable(sSQL.ToString());

                            if (dt.Rows.Count == 1)
                            {
                                string sQty = CModule.ToString(dt.Rows[0][CModule.ToString(drSubData["RELCODE3"])]);

                                bOpenMsg = false;

                                if (this.ShowDialog("[" + Common.getLangText(txtBarcode.Text.Trim() + "] 추가 바코드가 [" + sQty + "] 장 더 출력됩니다. 진행하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                                {
                                    CancelProcess = true;
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                if (bOpenMsg)
                {
                    if (this.ShowDialog("[" + Common.getLangText(txtBarcode.Text.Trim() + "] 를 출력합니다. 진행하시겠습니까?", "MSG")) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        CancelProcess = true;
                        return;
                    }
                }

                sSQL = new StringBuilder();
                sSQL.Append("exec USP_CALLPRINT_I1 ");
                sSQL.Append("  @AS_PLANTCODE = '" + txtPlantCode.Text.Trim() + "'");
                sSQL.Append(", @AS_LOTNO = '" + txtBarcode.Text.Trim() + "' ");
                sSQL.Append(", @AS_WORKCENTERCODE = '" + txtWorkCenterCode.Text.Trim() + "' ");
                sSQL.Append(", @AS_CIP = '" + txtCIP.Text.Trim() + "' ");
                sSQL.Append(", @AS_REISSUE = 'R" + (chkAddBarcode.Checked ? "" : "N") + "' ");

                helper.ExecuteNoneQuery(sSQL.ToString());

                MessageBox.Show("정상적으로 처리되었습니다.");
            }

            catch (Exception ex)
            {
                this.ShowDialog(ex.ToString(), WIZ.Forms.DialogForm.DialogType.OK);
            }
        }

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            Control.Grid grid = sender as Control.Grid;

            if (grid == null) return;

            if (e.Cell.Row.Index < 0) return;

            txtPlantCode.Text = DBHelper.nvlString(grid.ActiveRow.Cells["PLANTCODE"].Value);
            txtBarcode.Text = DBHelper.nvlString(grid.ActiveRow.Cells["LOTNO"].Value);
            txtWorkCenterCode.Text = DBHelper.nvlString(grid.ActiveRow.Cells["WORKCENTERCODE"].Value);
            txtCIP.Text = DBHelper.nvlString(grid.ActiveRow.Cells["CIP"].Value);
        }
    }
}
