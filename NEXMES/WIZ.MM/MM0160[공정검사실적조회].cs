#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0160
//   Form Name    : 수입검사대기현황조회
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-21
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.MM
{
    public partial class MM0160 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        #endregion

        #region < CONSTRUCTOR >
        public MM0160()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0160_Load(object sender, EventArgs e)
        {
            #region < GRID SETTING >
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "VALUE",         "검사값",       true, GridColDataType_emu.VarChar,  100, 130, Infragistics.Win.HAlign.Right,  true,  false);
            _GridUtil.InitColumnUltraGrid(grid1, "RESULT", "검사결과", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "검사단위", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPUSER", "검사자", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "검사일시", true, GridColDataType_emu.DateTime, 180, 130, Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            string[] arrMerCol1 = { "INSPCODE", "INSPNAME", "RESULT", "UNITCODE", "SPECNOL", "SPECLSL", "SPECUSL" };

            _GridUtil.GridHeaderMerge(grid1, "A", "개별판정", arrMerCol1, null);
            //_GridUtil.SetColumnMerge(this,grid1, "SEQNO");
            #endregion

            #region < COMBOBOX SETTING >
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("OKNG");  //종합검사결과
            WIZ.Common.FillComboboxMaster(this.cbo_RESULT_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            cbo_ENDDATE_H.Value = DateTime.Now.AddDays(+1);
            #endregion

            #region < POPUP SETTING >
            btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" }); // 품목
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "Y" }); // 작업장
            #endregion

        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sWorkCenterCode = txt_WORKCENTERCODE_H.Text.Trim();
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sResult = DBHelper.nvlString(cbo_RESULT_H.Value);
                string sInspCode = "";

                rtnDtTemp = helper.FillTable("USP_MM0160_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_RESULT", sResult, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }

                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    return;
                }

                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid1.DisplayLayout.Bands[0].Columns["RESULT"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["RESULT"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;


                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                //grid1.DisplayLayout.Bands[0].Columns["SEQNO"].MergedCellStyle = MergedCellStyle.Always;
                //grid1.DisplayLayout.Bands[0].Columns["SEQNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["RESULT"].Value.ToString() == "NG")
                    {
                        grid1.Rows[i].Cells["RESULT"].Appearance.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grid1.Rows[i].Cells["RESULT"].Appearance.BackColor = Color.DarkCyan;
                        grid1.Rows[i].Cells["RESULT"].Appearance.ForeColor = Color.White;
                    }

                    //if (grid1.Rows[i].Cells["RESULT"].Value.ToString() == "NG")
                    //{
                    //    grid1.Rows[i].Cells["RESULT"].Appearance.BackColor = Color.LightPink;
                    //}
                    //else
                    //{
                    //    grid1.Rows[i].Cells["RESULT"].Appearance.BackColor = Color.DarkCyan;
                    //    grid1.Rows[i].Cells["RESULT"].Appearance.ForeColor = Color.White;
                    //}
                }

            }
            catch (Exception ex)
            {
                this.ClosePrgFormNew();
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
            finally
            {
                this.ClosePrgFormNew();
                helper.Close();
            }
        }
        #endregion
    }
}